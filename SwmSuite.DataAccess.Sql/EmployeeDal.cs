using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.DataAccess.Interface;

using System.Data.SqlClient;
using SwmSuite.Configuration;
using System.Transactions;
using SwmSuite.DataAccess.Sql.SqlHelper;
using SwmSuite.DataAccess.Sql.SqlHelper.Main;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Sql {

	public sealed class EmployeeDal : IEmployeeDal {

		#region -_ Private Members _-

		private EmployeeSqlHelper _sqlHelper = new EmployeeSqlHelper();
		private EmployeeSettingsSqlHelper _employeeSettingsSqlHelper = new EmployeeSettingsSqlHelper();

		#endregion

		#region -_ IEmployeeDal Members _-

		/// <summary>
		/// Get all employees from the database.
		/// </summary>
		/// <returns>A EmployeeCollection containing all employees.</returns>
		EmployeeDataCollection IEmployeeDal.GetEmployeeData() {
			EmployeeDataCollection employeesToReturn = new EmployeeDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							employeesToReturn.Add( _sqlHelper.EmployeeFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return employeesToReturn;
		}

		/// <summary>
		/// Get a single employee from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the employee to retrieve.</param>
		/// <returns>An EmployeeCollection containing the requested employee.</returns>
		EmployeeDataCollection IEmployeeDal.GetEmployeeDataBySysId( int sysId ) {
			return ( (IEmployeeDal)this ).GetEmployeeDataBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple employees from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the employees to retrieve.</param>
		/// <returns>An EmployeeCollection containing the requested employees.</returns>
		EmployeeDataCollection IEmployeeDal.GetEmployeeDataBySysIds( int[] sysIds ) {
			EmployeeDataCollection employeesToReturn = new EmployeeDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							employeesToReturn.Add( _sqlHelper.EmployeeFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return employeesToReturn;
		}

		/// <summary>
		/// Get all employees from the database for a specific employeegroup.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employeegroup to get the employees for.</param>
		/// <returns>An EmployeeCollection containing all requested employees.</returns>
		EmployeeDataCollection IEmployeeDal.GetEmployeeDataForEmployeeGroup( int employeeGroupSysId ) {
			EmployeeDataCollection employeesToReturn = new EmployeeDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByGroup() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmployeeGroupSysId , employeeGroupSysId );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							employeesToReturn.Add( _sqlHelper.EmployeeFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return employeesToReturn;
		}

		/// <summary>
		/// Get all employees from the database for a specific machinename.
		/// </summary>
		/// <param name="machineName">The machine name to get the default employee for.</param>
		/// <returns>An EmployeeDataCollection containing all requested employees.</returns>
		/// <remarks>This method gets the employees that have an autologin setting on a specific machine.</remarks>
		EmployeeDataCollection IEmployeeDal.GetDefaultEmployeeForMachineName( String machineName ) {
			EmployeeDataCollection employeesToReturn = new EmployeeDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByMachine() , conn ) ) {
					cmd.Parameters.AddWithValue( _employeeSettingsSqlHelper.DBParameterAutoLogonHost , machineName );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							employeesToReturn.Add( _sqlHelper.EmployeeFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return employeesToReturn;
		}

		/// <summary>
		/// Insert one or more employees to the database.
		/// </summary>
		/// <param name="employees">An EmployeeCollection containing the employees to insert.</param>
		/// <returns>An EmployeeCollection containing the inserted employees.</returns>
		EmployeeDataCollection IEmployeeDal.InsertEmployeeData( EmployeeDataCollection employees ) {
			return Save( employees , true );
		}

		/// <summary>
		/// Update one or more employees in the database.
		/// </summary>
		/// <param name="employees">An EmployeeCollection containing the employees to update.</param>
		/// <returns>An EmployeeCollection containing the updated employees.</returns>
		EmployeeDataCollection IEmployeeDal.UpdateEmployeeData( EmployeeDataCollection employees ) {
			return Save( employees , false );
		}

		/// <summary>
		/// Remove one or more employees from the database.
		/// </summary>
		/// <param name="employees">An EmployeeCollection containing the employees to remove.</param>
		void IEmployeeDal.RemoveEmployeeData( EmployeeDataCollection employees ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( EmployeeData employee in employees ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , employee.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , employee.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , employee.ToString( ) , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
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
		/// Remove all employees from the database.
		/// </summary>
		void IEmployeeDal.RemoveAllEmployeeData() {
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

		private EmployeeDataCollection Save( EmployeeDataCollection employees , bool insert ) {
			EmployeeDataCollection employeesToReturn = new EmployeeDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( EmployeeData employee in employees ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterUserSysId , employee.UserSysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterName , employee.Name );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterFirstName , employee.FirstName );
							if( !String.IsNullOrEmpty( employee.Address ) ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterAddress , employee.Address );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterAddress , DBNull.Value );
							}
							if( employee.ZipCodeSysId.HasValue ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterZipCodeSysId , employee.ZipCodeSysId );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterZipCodeSysId , DBNull.Value );
							}
							if( !String.IsNullOrEmpty( employee.PrivatePhoneNumber ) ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterPrivatePhoneNumber , employee.PrivatePhoneNumber );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterPrivatePhoneNumber , DBNull.Value );
							}
							if( !String.IsNullOrEmpty( employee.WorkPhoneNumber ) ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterWorkPhoneNumber , employee.WorkPhoneNumber );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterWorkPhoneNumber , DBNull.Value );
							}
							if( !String.IsNullOrEmpty( employee.CellPhoneNumber ) ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCellPhoneNumber , employee.CellPhoneNumber );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCellPhoneNumber , DBNull.Value );
							}
							if( !String.IsNullOrEmpty( employee.EmailAddress1 ) ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmailAddress1 , employee.EmailAddress1 );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmailAddress1 , DBNull.Value );
							}
							if( !String.IsNullOrEmpty( employee.EmailAddress2 ) ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmailAddress2 , employee.EmailAddress2 );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmailAddress2 , DBNull.Value );
							}
							if( !String.IsNullOrEmpty( employee.EmailAddress3 ) ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmailAddress3 , employee.EmailAddress3 );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmailAddress3 , DBNull.Value );
							}
							if( !String.IsNullOrEmpty( employee.EmailAddress4 ) ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmailAddress4 , employee.EmailAddress4 );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmailAddress4 , DBNull.Value );
							}
							if( !String.IsNullOrEmpty( employee.EmailAddress5 ) ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmailAddress5 , employee.EmailAddress5 );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmailAddress5 , DBNull.Value );
							}
							if( employee.AvatarSysId.HasValue ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterAvatarSysId , employee.AvatarSysId );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterAvatarSysId , DBNull.Value );
							}
							if( employee.ApplicationSettingsSysId.HasValue ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterApplicationSettingsSysId , employee.ApplicationSettingsSysId );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterApplicationSettingsSysId , DBNull.Value );
							}
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmployeeGroupSysId , employee.EmployeeGroupSysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterAdministrator , employee.Administrator );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , employee.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , employee.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									employeesToReturn.Add( _sqlHelper.EmployeeFromReader( reader ) );
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
			return employeesToReturn;
		}

		#endregion

	}

}