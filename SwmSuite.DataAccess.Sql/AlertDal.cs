using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.DataAccess.Interface;

using System.Data.SqlClient;
using SwmSuite.Configuration;
using SwmSuite.DataAccess.Sql.SqlHelper;
using System.Transactions;
using SwmSuite.DataAccess.Sql.SqlHelper.Main;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Sql {

	public sealed class AlertDal : IAlertDal {

		#region -_ Private Members _-

		private AlertSqlHelper _sqlHelper = new AlertSqlHelper();
		private EmployeeAlertSqlHelper _employeeAlertSqlHelper = new EmployeeAlertSqlHelper();
		private EmployeeGroupAlertSqlHelper _employeeGroupAlertSqlHelper = new EmployeeGroupAlertSqlHelper();

		#endregion

		#region -_ IAlertDal Members _-

		/// <summary>
		/// Get all alerts from the database.
		/// </summary>
		/// <returns>A AlertCollection containing all alerts.</returns>
		AlertDataCollection IAlertDal.GetAlertData() {
			AlertDataCollection alertsToReturn = new AlertDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							alertsToReturn.Add( _sqlHelper.AlertFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return alertsToReturn;
		}

		/// <summary>
		/// Get all alerts from the database not linked to an employee or employeegroup.
		/// </summary>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		AlertDataCollection IAlertDal.GetGlobalAlertData() {
			AlertDataCollection alertsToReturn = new AlertDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectForGlobalAlerts() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							alertsToReturn.Add( _sqlHelper.AlertFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return alertsToReturn;
		}

		/// <summary>
		/// Get all alerts from the database for a specific employee.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the alerts for.</param>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		AlertDataCollection IAlertDal.GetAlertDataForEmployee( int employeeSysId ) {
			AlertDataCollection alertsToReturn = new AlertDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByEmployee() , conn ) ) {
					cmd.Parameters.AddWithValue( _employeeAlertSqlHelper.DBParameterEmployeeSysId , employeeSysId );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							alertsToReturn.Add( _sqlHelper.AlertFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return alertsToReturn;
		}

		/// <summary>
		/// Get all alerts from the database for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroupSysId">The internal id of the employeegroup to get the alerts for.</param>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		AlertDataCollection IAlertDal.GetAlertDataForEmployeeGroup( int employeeGroupSysId ) {
			AlertDataCollection alertsToReturn = new AlertDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByEmployeeGroup() , conn ) ) {
					cmd.Parameters.AddWithValue( _employeeGroupAlertSqlHelper.DBParameterEmployeeGroupSysId , employeeGroupSysId );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							alertsToReturn.Add( _sqlHelper.AlertFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return alertsToReturn;
		}

		/// <summary>
		/// Get a single alert from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the alert to retrieve.</param>
		/// <returns>An AlertCollection containing the requested alert.</returns>
		AlertDataCollection IAlertDal.GetAlertDataBySysId( int sysId ) {
			return ( (IAlertDal)this ).GetAlertDataBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple alerts from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the alerts to retrieve.</param>
		/// <returns>An AlertCollection containing the requested alerts.</returns>
		AlertDataCollection IAlertDal.GetAlertDataBySysIds( int[] sysIds ) {
			AlertDataCollection alertsToReturn = new AlertDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							alertsToReturn.Add( _sqlHelper.AlertFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return alertsToReturn;
		}

		/// <summary>
		/// Insert one or more alerts to the database.
		/// </summary>
		/// <param name="alerts">An AlertCollection containing the alerts to insert.</param>
		/// <returns>An AlertCollection containing the inserted alerts.</returns>
		AlertDataCollection IAlertDal.InsertAlertData( AlertDataCollection alerts ) {
			return Save( alerts , true );
		}

		/// <summary>
		/// Update one or more alerts in the database.
		/// </summary>
		/// <param name="alerts">An AlertCollection containing the alerts to update.</param>
		/// <returns>An AlertCollection containing the updated alerts.</returns>
		AlertDataCollection IAlertDal.UpdateAlertData( AlertDataCollection alerts ) {
			return Save( alerts , false );
		}

		/// <summary>
		/// Remove one or more alerts from the database.
		/// </summary>
		/// <param name="alerts">An AlertCollection containing the alerts to remove.</param>
		void IAlertDal.RemoveAlertData( AlertDataCollection alerts ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( AlertData alert in alerts ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , alert.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , alert.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , alert.ToString( ) , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
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
		/// Remove all alerts from the database.
		/// </summary>
		void IAlertDal.RemoveAllAlertData() {
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

		private AlertDataCollection Save( AlertDataCollection alerts , bool insert ) {
			AlertDataCollection alertsToReturn = new AlertDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( AlertData alert in alerts ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterVisible , alert.Visible );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterMessage , alert.Message );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , alert.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , alert.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									alertsToReturn.Add( _sqlHelper.AlertFromReader( reader ) );
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
			return alertsToReturn;
		}

		#endregion

	}

}
