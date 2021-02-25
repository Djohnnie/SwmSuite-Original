using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using SwmSuite.Configuration;
using System.Data.SqlClient;
using System.Transactions;
using SwmSuite.DataAccess.Sql.SqlHelper.AgendaModule;

namespace SwmSuite.DataAccess.Sql {

	public sealed class AppointmentDal : IAppointmentDal {

		#region -_ Private Members _-

		private AppointmentSqlHelper _sqlHelper = new AppointmentSqlHelper();

		#endregion

		#region -_ IAppointmentDal Members _-

		/// <summary>
		/// Get all appointments from the database that have a recurrence defined.
		/// </summary>
		/// <returns>An AppointmentDataCollection containing all requested appointments.</returns>
		AppointmentDataCollection IAppointmentDal.GetRecurrentAppointmentData() {
			AppointmentDataCollection appointmentsToReturn = new AppointmentDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectIfRecurrent() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							appointmentsToReturn.Add( _sqlHelper.AppointmentFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return appointmentsToReturn;
		}

		/// <summary>
		/// Get all employees from the database on a specific date where the given employee is a guest.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the guest appointments for.</param>
		/// <param name="onDate">The date to get the appointments for.</param>
		/// <returns>An AppointmentDataCollection containing all requested appointments.</returns>
		AppointmentDataCollection IAppointmentDal.GetGuestAppointmentDataForEmployeeOnDate( int employeeSysId , DateTime onDate ) {
			AppointmentDataCollection appointmentsToReturn = new AppointmentDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectOnDateGuest() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmployee , employeeSysId );
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterOnDate , onDate );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							appointmentsToReturn.Add( _sqlHelper.AppointmentFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return appointmentsToReturn;
		}

		/// <summary>
		/// Get all appointments from the database on a specific date.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the appointments for.</param>
		/// <param name="onDate">The date to get the appointments for.</param>
		/// <returns>An AppointmentDataCollection containing all requested appointments.</returns>
		AppointmentDataCollection IAppointmentDal.GetAppointmentDataForEmployeeOnDate( int employeeSysId , DateTime onDate ) {
			AppointmentDataCollection appointmentsToReturn = new AppointmentDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectOnDate() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmployee , employeeSysId );
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterOnDate , onDate );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							appointmentsToReturn.Add( _sqlHelper.AppointmentFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return appointmentsToReturn;
		}

		/// <summary>
		/// Get all appointments from the database.
		/// </summary>
		/// <returns>A AppointmentCollection containing all appointments.</returns>
		AppointmentDataCollection IAppointmentDal.GetAppointmentData() {
			AppointmentDataCollection appointmentsToReturn = new AppointmentDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							appointmentsToReturn.Add( _sqlHelper.AppointmentFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return appointmentsToReturn;
		}

		/// <summary>
		/// Get a single appointment from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the appointment to retrieve.</param>
		/// <returns>An AppointmentCollection containing the requested appointment.</returns>
		AppointmentDataCollection IAppointmentDal.GetAppointmentDataBySysId( int sysId ) {
			return ( (IAppointmentDal)this ).GetAppointmentDataBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple appointments from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the appointments to retrieve.</param>
		/// <returns>An AppointmentCollection containing the requested appointments.</returns>
		AppointmentDataCollection IAppointmentDal.GetAppointmentDataBySysIds( int[] sysIds ) {
			AppointmentDataCollection appointmentsToReturn = new AppointmentDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							appointmentsToReturn.Add( _sqlHelper.AppointmentFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return appointmentsToReturn;
		}

		/// <summary>
		/// Insert one or more appointments to the database.
		/// </summary>
		/// <param name="appointments">An AppointmentCollection containing the appointments to insert.</param>
		/// <returns>An AppointmentCollection containing the inserted appointments.</returns>
		AppointmentDataCollection IAppointmentDal.InsertAppointmentData( AppointmentDataCollection appointments ) {
			return Save( appointments , true );
		}

		/// <summary>
		/// Update one or more appointments in the database.
		/// </summary>
		/// <param name="appointments">An AppointmentCollection containing the appointments to update.</param>
		/// <returns>An AppointmentCollection containing the updated appointments.</returns>
		AppointmentDataCollection IAppointmentDal.UpdateAppointmentData( AppointmentDataCollection appointments ) {
			return Save( appointments , false );
		}

		/// <summary>
		/// Remove one or more appointments from the database.
		/// </summary>
		/// <param name="appointments">An AppointmentCollection containing the appointments to remove.</param>
		void IAppointmentDal.RemoveAppointmentData( AppointmentDataCollection appointments ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( AppointmentData appointment in appointments ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , appointment.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , appointment.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , appointment.ToString( ) , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
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
		/// Remove all appointments from the database.
		/// </summary>
		void IAppointmentDal.RemoveAllAppointmentData() {
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

		private AppointmentDataCollection Save( AppointmentDataCollection appointments , bool insert ) {
			AppointmentDataCollection appointmentsToReturn = new AppointmentDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( AppointmentData appointment in appointments ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterTitle , appointment.Title );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDateTimeStart , appointment.DateTimeStart );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDateTimeEnd , appointment.DateTimeEnd );
							if( !String.IsNullOrEmpty( appointment.Place ) ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterPlace , appointment.Place );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterPlace , DBNull.Value );
							}
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterOwnerEmployeeSysId , appointment.OwnerEmployeeSysId );
							if( !String.IsNullOrEmpty( appointment.Contents ) ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterContents , appointment.Contents );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterContents , DBNull.Value );
							}
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterAgendaSysId , appointment.AgendaSysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterVisibility , appointment.Visibility );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , appointment.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , appointment.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									appointmentsToReturn.Add( _sqlHelper.AppointmentFromReader( reader ) );
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
			return appointmentsToReturn;
		}

		#endregion

	}

}
