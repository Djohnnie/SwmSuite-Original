using System;
using System.Collections.Generic;
using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;
using System.Transactions;
using SwmSuite.Configuration;
using SwmSuite.DataAccess.Sql.SqlHelper;

namespace SwmSuite.DataAccess.Sql {

	public sealed class AppointmentRecurrenceDal : IAppointmentRecurrenceDal {

		#region -_ Private Members _-

		private AppointmentRecurrenceSqlHelper _sqlHelper = new AppointmentRecurrenceSqlHelper();

		#endregion

		#region -_ IAppointmentRecurrenceDal Members _-

		/// <summary>
		/// Get all appointmentrecurrences from the database.
		/// </summary>
		/// <returns>A AppointmentRecurrenceCollection containing all appointmentrecurrences.</returns>
		AppointmentRecurrenceDataCollection IAppointmentRecurrenceDal.GetAppointmentRecurrenceData() {
			AppointmentRecurrenceDataCollection appointmentrecurrencesToReturn = new AppointmentRecurrenceDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							appointmentrecurrencesToReturn.Add( _sqlHelper.AppointmentRecurrenceFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return appointmentrecurrencesToReturn;
		}

		/// <summary>
		/// Get a single appointmentrecurrence from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the appointmentrecurrence to retrieve.</param>
		/// <returns>An AppointmentRecurrenceCollection containing the requested appointmentrecurrence.</returns>
		AppointmentRecurrenceDataCollection IAppointmentRecurrenceDal.GetAppointmentRecurrenceDataBySysId( int sysId ) {
			return ( (IAppointmentRecurrenceDal)this ).GetAppointmentRecurrencesDataBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple appointmentrecurrences from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the appointmentrecurrences to retrieve.</param>
		/// <returns>An AppointmentRecurrenceCollection containing the requested appointmentrecurrences.</returns>
		AppointmentRecurrenceDataCollection IAppointmentRecurrenceDal.GetAppointmentRecurrencesDataBySysIds( int[] sysIds ) {
			AppointmentRecurrenceDataCollection appointmentrecurrencesToReturn = new AppointmentRecurrenceDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							appointmentrecurrencesToReturn.Add( _sqlHelper.AppointmentRecurrenceFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return appointmentrecurrencesToReturn;
		}

		/// <summary>
		/// Insert one or more appointmentrecurrences to the database.
		/// </summary>
		/// <param name="appointmentrecurrences">An AppointmentRecurrenceCollection containing the appointmentrecurrences to insert.</param>
		/// <returns>An AppointmentRecurrenceCollection containing the inserted appointmentrecurrences.</returns>
		AppointmentRecurrenceDataCollection IAppointmentRecurrenceDal.InsertAppointmentRecurrenceData( AppointmentRecurrenceDataCollection appointmentrecurrences ) {
			return Save( appointmentrecurrences , true );
		}

		/// <summary>
		/// Update one or more appointmentrecurrences in the database.
		/// </summary>
		/// <param name="appointmentrecurrences">An AppointmentRecurrenceCollection containing the appointmentrecurrences to update.</param>
		/// <returns>An AppointmentRecurrenceCollection containing the updated appointmentrecurrences.</returns>
		AppointmentRecurrenceDataCollection IAppointmentRecurrenceDal.UpdateAppointmentRecurrenceData( AppointmentRecurrenceDataCollection appointmentrecurrences ) {
			return Save( appointmentrecurrences , false );
		}

		/// <summary>
		/// Remove one or more appointmentrecurrences from the database.
		/// </summary>
		/// <param name="appointmentrecurrences">An AppointmentRecurrenceCollection containing the appointmentrecurrences to remove.</param>
		void IAppointmentRecurrenceDal.RemoveAppointmentRecurrenceData( AppointmentRecurrenceDataCollection appointmentrecurrences ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( AppointmentRecurrenceData appointmentrecurrence in appointmentrecurrences ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , appointmentrecurrence.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , appointmentrecurrence.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , appointmentrecurrence.ToString() , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
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
		/// Remove all appointmentrecurrences from the database.
		/// </summary>
		void IAppointmentRecurrenceDal.RemoveAllAppointmentRecurrenceData() {
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

		private AppointmentRecurrenceDataCollection Save( AppointmentRecurrenceDataCollection appointmentrecurrences , bool insert ) {
			AppointmentRecurrenceDataCollection appointmentrecurrencesToReturn = new AppointmentRecurrenceDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( AppointmentRecurrenceData appointmentrecurrence in appointmentrecurrences ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterAppointmentSysId , appointmentrecurrence.AppointmentSysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRecurrenceSysId , appointmentrecurrence.RecurrenceSysId );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , appointmentrecurrence.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , appointmentrecurrence.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									appointmentrecurrencesToReturn.Add( _sqlHelper.AppointmentRecurrenceFromReader( reader ) );
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
			return appointmentrecurrencesToReturn;
		}

		#endregion

	}

}
