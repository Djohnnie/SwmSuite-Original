using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using System.Transactions;
using System.Data.SqlClient;
using SwmSuite.DataAccess.Interface;
using SwmSuite.DataAccess.Sql.SqlHelper.AgendaModule;
using SwmSuite.Configuration;

namespace SwmSuite.DataAccess.Sql {

	public sealed class AppointmentGuestDal : IAppointmentGuestDal {

		#region -_ Private Members _-

		private AppointmentGuestSqlHelper _sqlHelper = new AppointmentGuestSqlHelper();

		#endregion

		#region -_ IAppointmentGuestDal Members _-

		/// <summary>
		/// Get all appointmentguests from the database.
		/// </summary>
		/// <returns>A AppointmentGuestCollection containing all appointmentguests.</returns>
		AppointmentGuestDataCollection IAppointmentGuestDal.GetAppointmentGuestData() {
			AppointmentGuestDataCollection appointmentguestsToReturn = new AppointmentGuestDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							appointmentguestsToReturn.Add( _sqlHelper.AppointmentGuestFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return appointmentguestsToReturn;
		}

		/// <summary>
		/// Get all appointmentguests from the database for a specific appointment.
		/// </summary>
		/// <param name="appointmentSysId">The inernal id of the appointment to get the guest data for.</param>
		/// <returns>An AppointmentGuestCollection containing all appointmentguests.</returns>
		AppointmentGuestDataCollection IAppointmentGuestDal.GetAppointmentGuestDataByAppointment( int appointmentSysId ) {
			AppointmentGuestDataCollection appointmentguestsToReturn = new AppointmentGuestDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByAppointment() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterAppointmentSysId , appointmentSysId );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							appointmentguestsToReturn.Add( _sqlHelper.AppointmentGuestFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return appointmentguestsToReturn;
		}

		/// <summary>
		/// Get a single appointmentguest from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the appointmentguest to retrieve.</param>
		/// <returns>An AppointmentGuestCollection containing the requested appointmentguest.</returns>
		AppointmentGuestDataCollection IAppointmentGuestDal.GetAppointmentGuestDataBySysId( int sysId ) {
			return ( (IAppointmentGuestDal)this ).GetAppointmentGuestsDataBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple appointmentguests from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the appointmentguests to retrieve.</param>
		/// <returns>An AppointmentGuestCollection containing the requested appointmentguests.</returns>
		AppointmentGuestDataCollection IAppointmentGuestDal.GetAppointmentGuestsDataBySysIds( int[] sysIds ) {
			AppointmentGuestDataCollection appointmentguestsToReturn = new AppointmentGuestDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							appointmentguestsToReturn.Add( _sqlHelper.AppointmentGuestFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return appointmentguestsToReturn;
		}

		/// <summary>
		/// Insert one or more appointmentguests to the database.
		/// </summary>
		/// <param name="appointmentguests">An AppointmentGuestCollection containing the appointmentguests to insert.</param>
		/// <returns>An AppointmentGuestCollection containing the inserted appointmentguests.</returns>
		AppointmentGuestDataCollection IAppointmentGuestDal.InsertAppointmentGuestData( AppointmentGuestDataCollection appointmentguests ) {
			return Save( appointmentguests , true );
		}

		/// <summary>
		/// Update one or more appointmentguests in the database.
		/// </summary>
		/// <param name="appointmentguests">An AppointmentGuestCollection containing the appointmentguests to update.</param>
		/// <returns>An AppointmentGuestCollection containing the updated appointmentguests.</returns>
		AppointmentGuestDataCollection IAppointmentGuestDal.UpdateAppointmentGuestData( AppointmentGuestDataCollection appointmentguests ) {
			return Save( appointmentguests , false );
		}

		/// <summary>
		/// Remove one or more appointmentguests from the database.
		/// </summary>
		/// <param name="appointmentguests">An AppointmentGuestCollection containing the appointmentguests to remove.</param>
		void IAppointmentGuestDal.RemoveAppointmentGuestData( AppointmentGuestDataCollection appointmentguests ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( AppointmentGuestData appointmentguest in appointmentguests ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , appointmentguest.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , appointmentguest.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , appointmentguest.ToString( ) , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
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
		/// Remove all appointmentguests from the database.
		/// </summary>
		void IAppointmentGuestDal.RemoveAllAppointmentGuestData() {
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

		private AppointmentGuestDataCollection Save( AppointmentGuestDataCollection appointmentguests , bool insert ) {
			AppointmentGuestDataCollection appointmentguestsToReturn = new AppointmentGuestDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( AppointmentGuestData appointmentguest in appointmentguests ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterAppointmentSysId , appointmentguest.AppointmentSysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmployeeSysId , appointmentguest.EmployeeSysId );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , appointmentguest.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , appointmentguest.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									appointmentguestsToReturn.Add( _sqlHelper.AppointmentGuestFromReader( reader ) );
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
			return appointmentguestsToReturn;
		}

		#endregion

	}

}
