using System;
using System.Collections.Generic;
using System.Text;
using SwmSuite.Data.DataObjects;
using SwmSuite.Configuration;
using System.Data.SqlClient;
using System.Transactions;
using SwmSuite.DataAccess.Interface;
using SwmSuite.DataAccess.Sql.SqlHelper;

namespace SwmSuite.DataAccess.Sql {

	public sealed class TaskRecurrenceDal : ITaskRecurrenceDal {

		#region -_ Private Members _-

		private TaskRecurrenceSqlHelper _sqlHelper = new TaskRecurrenceSqlHelper();

		#endregion

		#region -_ ITaskRecurrenceDal Members _-

		/// <summary>
		/// Get all taskrecurrences from the database.
		/// </summary>
		/// <returns>A TaskRecurrenceCollection containing all taskrecurrences.</returns>
		TaskRecurrenceDataCollection ITaskRecurrenceDal.GetTaskRecurrenceData() {
			TaskRecurrenceDataCollection taskrecurrencesToReturn = new TaskRecurrenceDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							taskrecurrencesToReturn.Add( _sqlHelper.TaskRecurrenceFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return taskrecurrencesToReturn;
		}

		/// <summary>
		/// Get a single taskrecurrence from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the taskrecurrence to retrieve.</param>
		/// <returns>An TaskRecurrenceCollection containing the requested taskrecurrence.</returns>
		TaskRecurrenceDataCollection ITaskRecurrenceDal.GetTaskRecurrenceDataBySysId( int sysId ) {
			return ( (ITaskRecurrenceDal)this ).GetTaskRecurrenceDataBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple taskrecurrences from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the taskrecurrences to retrieve.</param>
		/// <returns>An TaskRecurrenceCollection containing the requested taskrecurrences.</returns>
		TaskRecurrenceDataCollection ITaskRecurrenceDal.GetTaskRecurrenceDataBySysIds( int[] sysIds ) {
			TaskRecurrenceDataCollection taskrecurrencesToReturn = new TaskRecurrenceDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							taskrecurrencesToReturn.Add( _sqlHelper.TaskRecurrenceFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return taskrecurrencesToReturn;
		}

		/// <summary>
		/// Insert one or more taskrecurrences to the database.
		/// </summary>
		/// <param name="taskrecurrences">An TaskRecurrenceCollection containing the taskrecurrences to insert.</param>
		/// <returns>An TaskRecurrenceCollection containing the inserted taskrecurrences.</returns>
		TaskRecurrenceDataCollection ITaskRecurrenceDal.InsertTaskRecurrenceData( TaskRecurrenceDataCollection taskrecurrences ) {
			return Save( taskrecurrences , true );
		}

		/// <summary>
		/// Update one or more taskrecurrences in the database.
		/// </summary>
		/// <param name="taskrecurrences">An TaskRecurrenceCollection containing the taskrecurrences to update.</param>
		/// <returns>An TaskRecurrenceCollection containing the updated taskrecurrences.</returns>
		TaskRecurrenceDataCollection ITaskRecurrenceDal.UpdateTaskRecurrenceData( TaskRecurrenceDataCollection taskrecurrences ) {
			return Save( taskrecurrences , false );
		}

		/// <summary>
		/// Remove one or more taskrecurrences from the database.
		/// </summary>
		/// <param name="taskrecurrences">An TaskRecurrenceCollection containing the taskrecurrences to remove.</param>
		void ITaskRecurrenceDal.RemoveTaskRecurrenceData( TaskRecurrenceDataCollection taskrecurrences ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( TaskRecurrenceData taskrecurrence in taskrecurrences ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , taskrecurrence.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , taskrecurrence.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , taskrecurrence.ToString() , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
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
		/// Remove all taskrecurrences from the database.
		/// </summary>
		void ITaskRecurrenceDal.RemoveAllTaskRecurrenceData() {
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

		private TaskRecurrenceDataCollection Save( TaskRecurrenceDataCollection taskrecurrences , bool insert ) {
			TaskRecurrenceDataCollection taskrecurrencesToReturn = new TaskRecurrenceDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( TaskRecurrenceData taskrecurrence in taskrecurrences ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterTaskDescriptionSysId , taskrecurrence.TaskDescriptionSysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRecurrenceSysId , taskrecurrence.RecurrenceSysId );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , taskrecurrence.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , taskrecurrence.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									taskrecurrencesToReturn.Add( _sqlHelper.TaskRecurrenceFromReader( reader ) );
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
			return taskrecurrencesToReturn;
		}

		#endregion

	}

}
