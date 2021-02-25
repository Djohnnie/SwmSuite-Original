using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.DataAccess.Sql.SqlHelper;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;
using SwmSuite.Configuration;
using System.Transactions;
using SwmSuite.DataAccess.Interface;

namespace SwmSuite.DataAccess.Sql {

	public class EmployeeSettingsDal : IEmployeeSettingsDal {

		#region -_ Private Members _-

		private EmployeeSettingsSqlHelper _sqlHelper = new EmployeeSettingsSqlHelper();

		#endregion

		#region -_ IEmployeeSettingsDal Members _-

		/// <summary>
		/// Get all employeesettings from the database.
		/// </summary>
		/// <returns>A EmployeeSettingsCollection containing all employeesettings.</returns>
		EmployeeSettingsDataCollection IEmployeeSettingsDal.GetEmployeeSettingsData() {
			EmployeeSettingsDataCollection employeesettingsToReturn = new EmployeeSettingsDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							employeesettingsToReturn.Add( _sqlHelper.EmployeeSettingsFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return employeesettingsToReturn;
		}

		/// <summary>
		/// Get employee settings for a specific employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the settings for.</param>
		/// <returns>An EmployeeSettingsDataCollection containing the requested settings.</returns>
		EmployeeSettingsDataCollection IEmployeeSettingsDal.GetEmployeeSettingsDataForEmployee( int employeeSysId ) {
			EmployeeSettingsDataCollection employeesettingsToReturn = new EmployeeSettingsDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectForEmployee() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmployeeSysId , employeeSysId ); 
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							employeesettingsToReturn.Add( _sqlHelper.EmployeeSettingsFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return employeesettingsToReturn;
		}

		/// <summary>
		/// Get a single employeesettings from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the employeesettings to retrieve.</param>
		/// <returns>An EmployeeSettingsCollection containing the requested employeesettings.</returns>
		EmployeeSettingsDataCollection IEmployeeSettingsDal.GetEmployeeSettingsDataBySysId( int sysId ) {
			return ( (IEmployeeSettingsDal)this ).GetEmployeeSettingsDataBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple employeesettings from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the employeesettings to retrieve.</param>
		/// <returns>An EmployeeSettingsCollection containing the requested employeesettings.</returns>
		EmployeeSettingsDataCollection IEmployeeSettingsDal.GetEmployeeSettingsDataBySysIds( int[] sysIds ) {
			EmployeeSettingsDataCollection employeesettingsToReturn = new EmployeeSettingsDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							employeesettingsToReturn.Add( _sqlHelper.EmployeeSettingsFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return employeesettingsToReturn;
		}

		/// <summary>
		/// Insert one or more employeesettings to the database.
		/// </summary>
		/// <param name="employeeSettingsData">An EmployeeSettingsCollection containing the employeesettings to insert.</param>
		/// <returns>An EmployeeSettingsCollection containing the inserted employeesettings.</returns>
		EmployeeSettingsDataCollection IEmployeeSettingsDal.InsertEmployeeSettingsData( EmployeeSettingsDataCollection employeeSettingsData ) {
			return Save( employeeSettingsData , true );
		}

		/// <summary>
		/// Update one or more employeesettings in the database.
		/// </summary>
		/// <param name="employeeSettingsData">An EmployeeSettingsCollection containing the employeesettings to update.</param>
		/// <returns>An EmployeeSettingsCollection containing the updated employeesettings.</returns>
		EmployeeSettingsDataCollection IEmployeeSettingsDal.UpdateEmployeeSettingsData( EmployeeSettingsDataCollection employeeSettingsData ) {
			return Save( employeeSettingsData , false );
		}

		/// <summary>
		/// Remove one or more employeesettings from the database.
		/// </summary>
		/// <param name="employeeSettingsData">An EmployeeSettingsCollection containing the employeesettings to remove.</param>
		void IEmployeeSettingsDal.RemoveEmployeeSettingsData( EmployeeSettingsDataCollection employeeSettingsData ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( EmployeeSettingsData settings in employeeSettingsData ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , settings.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , settings.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , settings.ToString() , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
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
		/// Remove all employeesettings from the database.
		/// </summary>
		void IEmployeeSettingsDal.RemoveAllEmployeeSettingsData() {
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

		private EmployeeSettingsDataCollection Save( EmployeeSettingsDataCollection employeeSettingsData , bool insert ) {
			EmployeeSettingsDataCollection employeesettingsToReturn = new EmployeeSettingsDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( EmployeeSettingsData settings in employeeSettingsData ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterLogoutTimeout , settings.LogoutTimeout );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmailNotification , settings.EmailNotification );
							if( !String.IsNullOrEmpty( settings.EmailAddress ) ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmailAddress , settings.EmailAddress );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmailAddress , DBNull.Value );
							}
							if( !String.IsNullOrEmpty( settings.SmtpServer ) ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSmtpServer , settings.SmtpServer );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSmtpServer , DBNull.Value );
							}
							if( settings.SmtpPort.HasValue ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSmtpPort , settings.SmtpPort );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSmtpPort , DBNull.Value );
							}
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSecureConnection , settings.SecureConnection );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterAuthentication , settings.Authentication );
							if( !String.IsNullOrEmpty( settings.Username ) ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterUsername , settings.Username );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterUsername , DBNull.Value );
							}
							if( !String.IsNullOrEmpty( settings.Password ) ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterPassword , settings.Password );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterPassword , DBNull.Value );
							}
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterAutoLogon , settings.AutoLogon );
							if( !String.IsNullOrEmpty( settings.AutoLogonHost ) ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterAutoLogonHost , settings.AutoLogonHost );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterAutoLogonHost , DBNull.Value );
							}
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , settings.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , settings.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									employeesettingsToReturn.Add( _sqlHelper.EmployeeSettingsFromReader( reader ) );
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
			return employeesettingsToReturn;
		}

		#endregion

	}

}
