using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.DataAccess.Sql.SqlHelper.Main;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;
using SwmSuite.Configuration;
using System.Transactions;

namespace SwmSuite.DataAccess.Sql {

	public sealed class EmployeeAlertDal : IEmployeeAlertDal {

		#region -_ Private Members _-

		private EmployeeAlertSqlHelper _sqlHelper = new EmployeeAlertSqlHelper();

		#endregion

		#region -_ IEmployeeAlertDal Members _-

		/// <summary>
		/// Get all employeealerts from the database.
		/// </summary>
		/// <returns>A EmployeeAlertDataCollection containing all employeealerts.</returns>
		EmployeeAlertDataCollection IEmployeeAlertDal.GetEmployeeAlertData() {
			EmployeeAlertDataCollection employeealertsToReturn = new EmployeeAlertDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							employeealertsToReturn.Add( _sqlHelper.EmployeeAlertFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return employeealertsToReturn;
		}

		/// <summary>
		/// Get all employeealerts from the database for a specific alert.
		/// </summary>
		/// <param name="alertSysId">The internal id of the alert to get the employeealerts for.</param>
		/// <returns>An EmployeeAlertDataCollection containing the requested employeealert.</returns>
		EmployeeAlertDataCollection IEmployeeAlertDal.GetEmployeeAlertDataForAlert( int alertSysId ) {
			EmployeeAlertDataCollection employeealertsToReturn = new EmployeeAlertDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByAlert() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterAlertSysId , alertSysId );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							employeealertsToReturn.Add( _sqlHelper.EmployeeAlertFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return employeealertsToReturn;
		}

		/// <summary>
		/// Get all employeealerts from the database for a specific employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the employeealerts for.</param>
		/// <returns>An EmployeeAlertDataCollection containing the requested employeealert.</returns>
		EmployeeAlertDataCollection IEmployeeAlertDal.GetEmployeeAlertDataForEmployee( int employeeSysId ) {
			EmployeeAlertDataCollection employeealertsToReturn = new EmployeeAlertDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByEmployee() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmployeeSysId , employeeSysId );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							employeealertsToReturn.Add( _sqlHelper.EmployeeAlertFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return employeealertsToReturn;
		}

		/// <summary>
		/// Get all employeealerts from the database for a specific alert and employee.
		/// </summary>
		/// <param name="alertSysId">The internal id of the alert to get the employeealerts for.</param>
		/// <param name="employeeSysId">The internal id of the employee to get the employeealerts for.</param>
		/// <returns>An EmployeeAlertDataCollection containing the requested employeealert.</returns>
		EmployeeAlertDataCollection IEmployeeAlertDal.GetEmployeeAlertDataForAlertAndEmployee( int alertSysId , int employeeSysId ) {
			EmployeeAlertDataCollection employeealertsToReturn = new EmployeeAlertDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByAlertAndEmployee() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterAlertSysId , alertSysId );
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmployeeSysId , employeeSysId );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							employeealertsToReturn.Add( _sqlHelper.EmployeeAlertFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return employeealertsToReturn;
		}

		/// <summary>
		/// Get a single employeealert from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the employeealert to retrieve.</param>
		/// <returns>An EmployeeAlertDataCollection containing the requested employeealert.</returns>
		EmployeeAlertDataCollection IEmployeeAlertDal.GetEmployeeAlertDataBySysId( int sysId ) {
			return ( (IEmployeeAlertDal)this ).GetEmployeeAlertDataBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple employeealerts from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the employeealerts to retrieve.</param>
		/// <returns>An EmployeeAlertDataCollection containing the requested employeealerts.</returns>
		EmployeeAlertDataCollection IEmployeeAlertDal.GetEmployeeAlertDataBySysIds( int[] sysIds ) {
			EmployeeAlertDataCollection employeealertsToReturn = new EmployeeAlertDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							employeealertsToReturn.Add( _sqlHelper.EmployeeAlertFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return employeealertsToReturn;
		}

		/// <summary>
		/// Insert one or more employeealerts to the database.
		/// </summary>
		/// <param name="employeealerts">An EmployeeAlertDataCollection containing the employeealerts to insert.</param>
		/// <returns>An EmployeeAlertDataCollection containing the inserted employeealerts.</returns>
		EmployeeAlertDataCollection IEmployeeAlertDal.InsertEmployeeAlertData( EmployeeAlertDataCollection employeealerts ) {
			return Save( employeealerts , true );
		}

		/// <summary>
		/// Update one or more employeealerts in the database.
		/// </summary>
		/// <param name="employeealerts">An EmployeeAlertDataCollection containing the employeealerts to update.</param>
		/// <returns>An EmployeeAlertDataCollection containing the updated employeealerts.</returns>
		EmployeeAlertDataCollection IEmployeeAlertDal.UpdateEmployeeAlertData( EmployeeAlertDataCollection employeealerts ) {
			return Save( employeealerts , false );
		}

		/// <summary>
		/// Remove one or more employeealerts from the database.
		/// </summary>
		/// <param name="employeealerts">An EmployeeAlertDataCollection containing the employeealerts to remove.</param>
		void IEmployeeAlertDal.RemoveEmployeeAlertData( EmployeeAlertDataCollection employeealerts ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( EmployeeAlertData employeealert in employeealerts ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , employeealert.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , employeealert.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , employeealert.ToString() , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
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
		/// Remove all employeealerts from the database.
		/// </summary>
		void IEmployeeAlertDal.RemoveAllEmployeeAlertData() {
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

		private EmployeeAlertDataCollection Save( EmployeeAlertDataCollection employeealerts , bool insert ) {
			EmployeeAlertDataCollection employeealertsToReturn = new EmployeeAlertDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( EmployeeAlertData employeealert in employeealerts ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmployeeSysId , employeealert.EmployeeSysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterAlertSysId , employeealert.AlertSysId );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , employeealert.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , employeealert.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									employeealertsToReturn.Add( _sqlHelper.EmployeeAlertFromReader( reader ) );
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
			return employeealertsToReturn;
		}

		#endregion

	}

}
