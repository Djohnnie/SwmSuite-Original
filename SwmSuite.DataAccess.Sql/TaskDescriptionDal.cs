using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using SwmSuite.Configuration;
using System.Data.SqlClient;
using System.Transactions;
using SwmSuite.DataAccess.Sql.SqlHelper.TaskModule;

namespace SwmSuite.DataAccess.Sql {

	public sealed class TaskDescriptionDal : ITaskDescriptionDal {

		#region -_ Private Members _-

		private TaskDescriptionSqlHelper _sqlHelper = new TaskDescriptionSqlHelper();

		#endregion

		#region -_ ITaskDescriptionDal Members _-

		/// <summary>
		/// Get all taskdescriptions from the database.
		/// </summary>
		/// <returns>A TaskDescriptionCollection containing all taskdescriptions.</returns>
		TaskDescriptionDataCollection ITaskDescriptionDal.GetTaskDescriptionData() {
			TaskDescriptionDataCollection taskdescriptionsToReturn = new TaskDescriptionDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							taskdescriptionsToReturn.Add( _sqlHelper.TaskDescriptionFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return taskdescriptionsToReturn;
		}

		/// <summary>
		/// Get a single taskdescription from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the taskdescription to retrieve.</param>
		/// <returns>An TaskDescriptionCollection containing the requested taskdescription.</returns>
		TaskDescriptionDataCollection ITaskDescriptionDal.GetTaskDescriptionDataBySysId( int sysId ) {
			return ( (ITaskDescriptionDal)this ).GetTaskDescriptionDataBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple taskdescriptions from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the taskdescriptions to retrieve.</param>
		/// <returns>An TaskDescriptionCollection containing the requested taskdescriptions.</returns>
		TaskDescriptionDataCollection ITaskDescriptionDal.GetTaskDescriptionDataBySysIds( int[] sysIds ) {
			TaskDescriptionDataCollection taskdescriptionsToReturn = new TaskDescriptionDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							taskdescriptionsToReturn.Add( _sqlHelper.TaskDescriptionFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return taskdescriptionsToReturn;
		}

		/// <summary>
		/// Insert one or more taskdescriptions to the database.
		/// </summary>
		/// <param name="taskdescriptions">An TaskDescriptionCollection containing the taskdescriptions to insert.</param>
		/// <returns>An TaskDescriptionCollection containing the inserted taskdescriptions.</returns>
		TaskDescriptionDataCollection ITaskDescriptionDal.InsertTaskDescriptionData( TaskDescriptionDataCollection taskdescriptions ) {
			return Save( taskdescriptions , true );
		}

		/// <summary>
		/// Update one or more taskdescriptions in the database.
		/// </summary>
		/// <param name="taskdescriptions">An TaskDescriptionCollection containing the taskdescriptions to update.</param>
		/// <returns>An TaskDescriptionCollection containing the updated taskdescriptions.</returns>
		TaskDescriptionDataCollection ITaskDescriptionDal.UpdateTaskDescriptionData( TaskDescriptionDataCollection taskdescriptions ) {
			return Save( taskdescriptions , false );
		}

		/// <summary>
		/// Remove one or more taskdescriptions from the database.
		/// </summary>
		/// <param name="taskdescriptions">An TaskDescriptionCollection containing the taskdescriptions to remove.</param>
		void ITaskDescriptionDal.RemoveTaskDescriptionData( TaskDescriptionDataCollection taskdescriptions ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( TaskDescriptionData taskdescription in taskdescriptions ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , taskdescription.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , taskdescription.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , taskdescription.ToString(  ) , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
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
		/// Remove all taskdescriptions from the database.
		/// </summary>
		void ITaskDescriptionDal.RemoveAllTaskDescriptionData() {
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

		private TaskDescriptionDataCollection Save( TaskDescriptionDataCollection taskdescriptions , bool insert ) {
			TaskDescriptionDataCollection taskdescriptionsToReturn = new TaskDescriptionDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( TaskDescriptionData taskdescription in taskdescriptions ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterTitle , taskdescription.Title );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreationDate , taskdescription.CreationDate );
							if( !String.IsNullOrEmpty( taskdescription.Description ) ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDescription , taskdescription.Description );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDescription , DBNull.Value );
							}
							if( taskdescription.Deadline.HasValue ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDeadline , taskdescription.Deadline );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDeadline , DBNull.Value );
							}
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCommissionerEmployeeSysId , taskdescription.CommissionerEmployeeSysId );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , taskdescription.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , taskdescription.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									taskdescriptionsToReturn.Add( _sqlHelper.TaskDescriptionFromReader( reader ) );
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
			return taskdescriptionsToReturn;
		}

		#endregion

	}

}
