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

	public sealed class TaskRunDal : ITaskRunDal {

		#region -_ Private Members _-

		private TaskRunSqlHelper _sqlHelper = new TaskRunSqlHelper();

		#endregion

		#region -_ ITaskRunDal Members _-

		/// <summary>
		/// Get all taskruns from the database.
		/// </summary>
		/// <returns>A TaskRunCollection containing all taskruns.</returns>
		TaskRunDataCollection ITaskRunDal.GetTaskRunData() {
			TaskRunDataCollection taskrunsToReturn = new TaskRunDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							taskrunsToReturn.Add( _sqlHelper.TaskRunFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return taskrunsToReturn;
		}

		/// <summary>
		/// Get all taskruns from the database for a specific task.
		/// </summary>
		/// <param name="taskSysId">The internal id of the task to get the taskruns for.</param>
		/// <returns>A TaskRunCollection containing the requested taskruns.</returns>
		TaskRunDataCollection ITaskRunDal.GetTaskRunDataByTask( int taskSysId ) {
			TaskRunDataCollection taskrunsToReturn = new TaskRunDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByTask() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterTaskSysId , taskSysId );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							taskrunsToReturn.Add( _sqlHelper.TaskRunFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return taskrunsToReturn;
		}

		/// <summary>
		/// Get a single taskrun from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the taskrun to retrieve.</param>
		/// <returns>An TaskRunCollection containing the requested taskrun.</returns>
		TaskRunDataCollection ITaskRunDal.GetTaskRunDataBySysId( int sysId ) {
			return ( (ITaskRunDal)this ).GetTaskRunDataBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple taskruns from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the taskruns to retrieve.</param>
		/// <returns>An TaskRunCollection containing the requested taskruns.</returns>
		TaskRunDataCollection ITaskRunDal.GetTaskRunDataBySysIds( int[] sysIds ) {
			TaskRunDataCollection taskrunsToReturn = new TaskRunDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							taskrunsToReturn.Add( _sqlHelper.TaskRunFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return taskrunsToReturn;
		}

		/// <summary>
		/// Insert one or more taskruns to the database.
		/// </summary>
		/// <param name="taskruns">An TaskRunCollection containing the taskruns to insert.</param>
		/// <returns>An TaskRunCollection containing the inserted taskruns.</returns>
		TaskRunDataCollection ITaskRunDal.InsertTaskRunData( TaskRunDataCollection taskruns ) {
			return Save( taskruns , true );
		}

		/// <summary>
		/// Update one or more taskruns in the database.
		/// </summary>
		/// <param name="taskruns">An TaskRunCollection containing the taskruns to update.</param>
		/// <returns>An TaskRunCollection containing the updated taskruns.</returns>
		TaskRunDataCollection ITaskRunDal.UpdateTaskRunData( TaskRunDataCollection taskruns ) {
			return Save( taskruns , false );
		}

		/// <summary>
		/// Remove one or more taskruns from the database.
		/// </summary>
		/// <param name="taskruns">An TaskRunCollection containing the taskruns to remove.</param>
		void ITaskRunDal.RemoveTaskRunData( TaskRunDataCollection taskruns ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( TaskRunData taskrun in taskruns ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , taskrun.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , taskrun.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , taskrun.ToString(  ) , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
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
		/// Remove all taskruns from the database.
		/// </summary>
		void ITaskRunDal.RemoveAllTaskRunData() {
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

		private TaskRunDataCollection Save( TaskRunDataCollection taskruns , bool insert ) {
			TaskRunDataCollection taskrunsToReturn = new TaskRunDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( TaskRunData taskrun in taskruns ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterTaskSysId , taskrun.TaskSysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDateTimeFinished , taskrun.DateTimeFinished );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRemarks , taskrun.Remarks );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterTaskRunMode , taskrun.TaskRunMode );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , taskrun.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , taskrun.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									taskrunsToReturn.Add( _sqlHelper.TaskRunFromReader( reader ) );
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
			return taskrunsToReturn;
		}

		#endregion

	}

}
