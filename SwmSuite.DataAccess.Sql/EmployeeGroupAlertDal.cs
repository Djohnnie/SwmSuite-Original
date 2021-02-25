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

	public sealed class EmployeeGroupAlertDal : IEmployeeGroupAlertDal {

		#region -_ Private Members _-

		private EmployeeGroupAlertSqlHelper _sqlHelper = new EmployeeGroupAlertSqlHelper();

		#endregion

		#region -_ IEmployeeGroupAlertDal Members _-

		/// <summary>
		/// Get all employeegroupalerts from the database.
		/// </summary>
		/// <returns>A EmployeeGroupAlertDataCollection containing all employeegroupalerts.</returns>
		EmployeeGroupAlertDataCollection IEmployeeGroupAlertDal.GetEmployeeGroupAlerts() {
			EmployeeGroupAlertDataCollection employeegroupalertsToReturn = new EmployeeGroupAlertDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							employeegroupalertsToReturn.Add( _sqlHelper.EmployeeGroupAlertFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return employeegroupalertsToReturn;
		}


		/// <summary>
		/// Get all employeealerts from the database for a specific alert.
		/// </summary>
		/// <param name="alertSysId">The internal id of the alert to get the employeealerts for.</param>
		/// <returns>An EmployeeAlertDataCollection containing the requested employeealert.</returns>
		EmployeeGroupAlertDataCollection IEmployeeGroupAlertDal.GetEmployeeGroupAlertsForAlert( int alertSysId ) {
			EmployeeGroupAlertDataCollection employeegroupalertsToReturn = new EmployeeGroupAlertDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByAlert() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterAlertSysId , alertSysId );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							employeegroupalertsToReturn.Add( _sqlHelper.EmployeeGroupAlertFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return employeegroupalertsToReturn;
		}

		/// <summary>
		/// Get all employeealerts from the database for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroupSysId">The internal id of the employeegroup to get the employeealerts for.</param>
		/// <returns>An EmployeeAlertDataCollection containing the requested employeealert.</returns>
		EmployeeGroupAlertDataCollection IEmployeeGroupAlertDal.GetEmployeeGroupAlertsForEmployeeGroup( int employeeGroupSysId ) {
			EmployeeGroupAlertDataCollection employeegroupalertsToReturn = new EmployeeGroupAlertDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByEmployeeGroup() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmployeeGroupSysId , employeeGroupSysId );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							employeegroupalertsToReturn.Add( _sqlHelper.EmployeeGroupAlertFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return employeegroupalertsToReturn;
		}

		/// <summary>
		/// Get all employeealerts from the database for a specific alert and employeegroup.
		/// </summary>
		/// <param name="alertSysId">The internal id of the alert to get the employeealerts for.</param>
		/// <param name="employeeGroupSysId">The internal id of the employeegroup to get the employeealerts for.</param>
		/// <returns>An EmployeeAlertDataCollection containing the requested employeealert.</returns>
		EmployeeGroupAlertDataCollection IEmployeeGroupAlertDal.GetEmployeeGroupAlertsForAlertAndEmployeeGroup( int alertSysId , int employeeGroupSysId ) {
			EmployeeGroupAlertDataCollection employeegroupalertsToReturn = new EmployeeGroupAlertDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByAlertAndEmployeeGroup() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterAlertSysId , alertSysId );
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmployeeGroupSysId , employeeGroupSysId );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							employeegroupalertsToReturn.Add( _sqlHelper.EmployeeGroupAlertFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return employeegroupalertsToReturn;
		}

		/// <summary>
		/// Get a single employeegroupalert from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the employeegroupalert to retrieve.</param>
		/// <returns>An EmployeeGroupAlertDataCollection containing the requested employeegroupalert.</returns>
		EmployeeGroupAlertDataCollection IEmployeeGroupAlertDal.GetEmployeeGroupAlertBySysId( int sysId ) {
			return ( (IEmployeeGroupAlertDal)this ).GetEmployeeGroupAlertsBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple employeegroupalerts from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the employeegroupalerts to retrieve.</param>
		/// <returns>An EmployeeGroupAlertDataCollection containing the requested employeegroupalerts.</returns>
		EmployeeGroupAlertDataCollection IEmployeeGroupAlertDal.GetEmployeeGroupAlertsBySysIds( int[] sysIds ) {
			EmployeeGroupAlertDataCollection employeegroupalertsToReturn = new EmployeeGroupAlertDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							employeegroupalertsToReturn.Add( _sqlHelper.EmployeeGroupAlertFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return employeegroupalertsToReturn;
		}

		/// <summary>
		/// Insert one or more employeegroupalerts to the database.
		/// </summary>
		/// <param name="employeegroupalerts">An EmployeeGroupAlertDataCollection containing the employeegroupalerts to insert.</param>
		/// <returns>An EmployeeGroupAlertDataCollection containing the inserted employeegroupalerts.</returns>
		EmployeeGroupAlertDataCollection IEmployeeGroupAlertDal.InsertEmployeeGroupAlerts( EmployeeGroupAlertDataCollection employeegroupalerts ) {
			return Save( employeegroupalerts , true );
		}

		/// <summary>
		/// Update one or more employeegroupalerts in the database.
		/// </summary>
		/// <param name="employeegroupalerts">An EmployeeGroupAlertDataCollection containing the employeegroupalerts to update.</param>
		/// <returns>An EmployeeGroupAlertDataCollection containing the updated employeegroupalerts.</returns>
		EmployeeGroupAlertDataCollection IEmployeeGroupAlertDal.UpdateEmployeeGroupAlerts( EmployeeGroupAlertDataCollection employeegroupalerts ) {
			return Save( employeegroupalerts , false );
		}

		/// <summary>
		/// Remove one or more employeegroupalerts from the database.
		/// </summary>
		/// <param name="employeegroupalerts">An EmployeeGroupAlertDataCollection containing the employeegroupalerts to remove.</param>
		void IEmployeeGroupAlertDal.RemoveEmployeeGroupAlerts( EmployeeGroupAlertDataCollection employeegroupalerts ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( EmployeeGroupAlertData employeegroupalert in employeegroupalerts ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , employeegroupalert.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , employeegroupalert.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , employeegroupalert.ToString() , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
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
		/// Remove all employeegroupalerts from the database.
		/// </summary>
		void IEmployeeGroupAlertDal.RemoveAllEmployeeGroupAlerts() {
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

		private EmployeeGroupAlertDataCollection Save( EmployeeGroupAlertDataCollection employeegroupalerts , bool insert ) {
			EmployeeGroupAlertDataCollection employeegroupalertsToReturn = new EmployeeGroupAlertDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( EmployeeGroupAlertData employeegroupalert in employeegroupalerts ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmployeeGroupSysId , employeegroupalert.EmployeeGroupSysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterAlertSysId , employeegroupalert.AlertSysId );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , employeegroupalert.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , employeegroupalert.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									employeegroupalertsToReturn.Add( _sqlHelper.EmployeeGroupAlertFromReader( reader ) );
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
			return employeegroupalertsToReturn;
		}

		#endregion

	}

}
