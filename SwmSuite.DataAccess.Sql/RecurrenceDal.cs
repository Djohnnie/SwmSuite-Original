using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;
using SwmSuite.Configuration;
using System.Transactions;
using SwmSuite.DataAccess.Sql.SqlHelper;

namespace SwmSuite.DataAccess.Sql {

	public sealed class RecurrenceDal : IRecurrenceDal {

		#region -_ Private Members _-

		private RecurrenceSqlHelper _sqlHelper = new RecurrenceSqlHelper();

		#endregion

		#region -_ IRecurrenceDal Members _-

		/// <summary>
		/// Get all recurrences from the database for a specific appointment.
		/// </summary>
		/// <param name="appointmentSysId">The internal id of the appointment to get the recurrences for.</param>
		/// <returns>A RecurrenceCollection containing the requested recurrence.</returns>
		RecurrenceDataCollection IRecurrenceDal.GetRecurrenceDataForAppointment( int appointmentSysId ) {
			RecurrenceDataCollection recurrencesToReturn = new RecurrenceDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByAppointment() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterAppointment , appointmentSysId );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							recurrencesToReturn.Add( _sqlHelper.RecurrenceFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return recurrencesToReturn;
		}

		/// <summary>
		/// Get all recurrences from the database for a specific task.
		/// </summary>
		/// <param name="taskSysId">The internal id of the task to get the recurrences for.</param>
		/// <returns>A RecurrenceCollection containing the requested recurrence.</returns>
		RecurrenceDataCollection IRecurrenceDal.GetRecurrenceDataForTask( int taskSysId ) {
			RecurrenceDataCollection recurrencesToReturn = new RecurrenceDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByTask() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterTask , taskSysId );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							recurrencesToReturn.Add( _sqlHelper.RecurrenceFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return recurrencesToReturn;
		}

		/// <summary>
		/// Get all recurrences from the database.
		/// </summary>
		/// <returns>A RecurrenceDataCollection containing all recurrences.</returns>
		RecurrenceDataCollection IRecurrenceDal.GetRecurrenceData() {
			RecurrenceDataCollection recurrencesToReturn = new RecurrenceDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							recurrencesToReturn.Add( _sqlHelper.RecurrenceFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return recurrencesToReturn;
		}

		/// <summary>
		/// Get a single recurrence from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the recurrence to retrieve.</param>
		/// <returns>An RecurrenceDataCollection containing the requested recurrence.</returns>
		RecurrenceDataCollection IRecurrenceDal.GetRecurrenceDataBySysId( int sysId ) {
			return ( (IRecurrenceDal)this ).GetRecurrenceDataBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple recurrences from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the recurrences to retrieve.</param>
		/// <returns>An RecurrenceDataCollection containing the requested recurrences.</returns>
		RecurrenceDataCollection IRecurrenceDal.GetRecurrenceDataBySysIds( int[] sysIds ) {
			RecurrenceDataCollection recurrencesToReturn = new RecurrenceDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							recurrencesToReturn.Add( _sqlHelper.RecurrenceFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return recurrencesToReturn;
		}

		/// <summary>
		/// Insert one or more recurrences to the database.
		/// </summary>
		/// <param name="recurrences">An RecurrenceDataCollection containing the recurrences to insert.</param>
		/// <returns>An RecurrenceDataCollection containing the inserted recurrences.</returns>
		RecurrenceDataCollection IRecurrenceDal.InsertRecurrenceData( RecurrenceDataCollection recurrences ) {
			return Save( recurrences , true );
		}

		/// <summary>
		/// Update one or more recurrences in the database.
		/// </summary>
		/// <param name="recurrences">An RecurrenceDataCollection containing the recurrences to update.</param>
		/// <returns>An RecurrenceDataCollection containing the updated recurrences.</returns>
		RecurrenceDataCollection IRecurrenceDal.UpdateRecurrenceData( RecurrenceDataCollection recurrences ) {
			return Save( recurrences , false );
		}

		/// <summary>
		/// Remove one or more recurrences from the database.
		/// </summary>
		/// <param name="recurrences">An RecurrenceDataCollection containing the recurrences to remove.</param>
		void IRecurrenceDal.RemoveRecurrenceData( RecurrenceDataCollection recurrences ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( RecurrenceData recurrence in recurrences ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , recurrence.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , recurrence.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , recurrence.ToString() , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
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
		/// Remove all recurrences from the database.
		/// </summary>
		void IRecurrenceDal.RemoveAllRecurrenceData() {
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

		private RecurrenceDataCollection Save( RecurrenceDataCollection recurrences , bool insert ) {
			RecurrenceDataCollection recurrencesToReturn = new RecurrenceDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( RecurrenceData recurrence in recurrences ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRecurrenceMode , recurrence.RecurrenceMode );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEvery , recurrence.Every );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEveryWeekDay , recurrence.EveryWeekDay );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterMonday , recurrence.Monday );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterTuesday , recurrence.Tuesday );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterWednesday , recurrence.Wednesday );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterThursday , recurrence.Thursday );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterFriday , recurrence.Friday );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSaturday , recurrence.Saturday );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSunday , recurrence.Sunday );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDayOfMonth , recurrence.DayOfMonth );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterOccurrence , recurrence.Occurrence );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDay , recurrence.Day );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterMonth , recurrence.Month );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterChoice , recurrence.Choice );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterStartDate , recurrence.StartDate );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEndMode , recurrence.EndMode );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterOccurrences , recurrence.Occurrences );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEndDate , recurrence.EndDate );
							if( !String.IsNullOrEmpty( recurrence.Description ) ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDescription , recurrence.Description );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDescription , DBNull.Value );
							}
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , recurrence.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , recurrence.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									recurrencesToReturn.Add( _sqlHelper.RecurrenceFromReader( reader ) );
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
			return recurrencesToReturn;
		}

		#endregion

	}


}
