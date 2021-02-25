using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;
using SwmSuite.Configuration;
using System.Transactions;
using SwmSuite.DataAccess.Sql.SqlHelper.TaskModule;

namespace SwmSuite.DataAccess.Sql {

	public sealed class TaskDal : ITaskDal {

		#region -_ Private Members _-

		private TaskSqlHelper _sqlHelper = new TaskSqlHelper();
		private TaskDescriptionSqlHelper _taskDescriptionSqlHelper = new TaskDescriptionSqlHelper();

		#endregion

		#region -_ ITaskDal Members _-

		/// <summary>
		/// Get all tasks from the database.
		/// </summary>
		/// <returns>A TaskCollection containing all tasks.</returns>
		TaskDataCollection ITaskDal.GetTaskData() {
			TaskDataCollection tasksToReturn = new TaskDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							tasksToReturn.Add( _sqlHelper.TaskFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return tasksToReturn;
		}

		/// <summary>
		/// Get a single task from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the task to retrieve.</param>
		/// <returns>An TaskCollection containing the requested task.</returns>
		TaskDataCollection ITaskDal.GetTaskDataBySysId( int sysId ) {
			return ( (ITaskDal)this ).GetTaskDataBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get all tasks from the database for a specific employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the tasks for.</param>
		/// <param name="year">The year to get the task data for.</param>
		/// <returns>A TaskDataCollection containing the requested tasks.</returns>
		TaskDataCollection ITaskDal.GetTaskDataByEmployee( int employeeSysId , int year ) {
			TaskDataCollection tasksToReturn = new TaskDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByEmployee() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmployeeSysId , employeeSysId );
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterYear , year );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							tasksToReturn.Add( _sqlHelper.TaskFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return tasksToReturn;
		}

		/// <summary>
		/// Get multiple tasks from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the tasks to retrieve.</param>
		/// <returns>An TaskCollection containing the requested tasks.</returns>
		TaskDataCollection ITaskDal.GetTaskDataBySysIds( int[] sysIds ) {
			TaskDataCollection tasksToReturn = new TaskDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							tasksToReturn.Add( _sqlHelper.TaskFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return tasksToReturn;
		}

		/// <summary>
		/// Insert one or more tasks to the database.
		/// </summary>
		/// <param name="tasks">An TaskCollection containing the tasks to insert.</param>
		/// <returns>An TaskCollection containing the inserted tasks.</returns>
		TaskDataCollection ITaskDal.InsertTaskData( TaskDataCollection tasks ) {
			return Save( tasks , true );
		}

		/// <summary>
		/// Update one or more tasks in the database.
		/// </summary>
		/// <param name="tasks">An TaskCollection containing the tasks to update.</param>
		/// <returns>An TaskCollection containing the updated tasks.</returns>
		TaskDataCollection ITaskDal.UpdateTaskData( TaskDataCollection tasks ) {
			return Save( tasks , false );
		}

		/// <summary>
		/// Remove one or more tasks from the database.
		/// </summary>
		/// <param name="tasks">An TaskCollection containing the tasks to remove.</param>
		void ITaskDal.RemoveTaskData( TaskDataCollection tasks ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( TaskData task in tasks ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , task.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , task.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , task.ToString( ) , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
							cmd.ExecuteNonQuery();
						}
					} catch( SqlException ) {
						// TODO: Exception Handling...
						throw;
					} finally {
						//conn.Close();
					}
					conn.Close();
				}
				transactionScope.Complete();
			}
		}

		/// <summary>
		/// Remove all tasks from the database.
		/// </summary>
		void ITaskDal.RemoveAllTaskData() {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteAllCommand() , conn );
						cmd.ExecuteNonQuery();
					} catch( SqlException ) {
						// TODO: Exception Handling...
						throw;
					} finally {
						//conn.Close();
					}
					conn.Close();
				}
				transactionScope.Complete();
			}

		}

		#endregion

		#region -_ Helper methods _-

		private TaskDataCollection Save( TaskDataCollection tasks , bool insert ) {
			TaskDataCollection tasksToReturn = new TaskDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( TaskData task in tasks ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmployeeSysId , task.EmployeeSysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterTaskDescriptionSysId , task.TaskDescriptionSysId );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , task.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , task.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									tasksToReturn.Add( _sqlHelper.TaskFromReader( reader ) );
								}
							}
						}
					} catch( SqlException ) {
						// TODO: Exception Handling...
						throw;
					} finally {
						//conn.Close();
					}
					conn.Close();
				}
				transactionScope.Complete();
			}
			return tasksToReturn;
		}

		#endregion

	}

}
