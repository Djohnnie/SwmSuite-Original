using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.DataAccess.Sql.SqlHelper;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;
using SwmSuite.Configuration;
using System.Transactions;

namespace SwmSuite.DataAccess.Sql {

	public sealed class LoginLogDataDal : ILoginLogDataDal {

		#region -_ Private Members _-

		private LoginLogSqlHelper _sqlHelper = new LoginLogSqlHelper();

		#endregion

		#region -_ ILoginLogDataDal Members _-

		/// <summary>
		/// Get all loginlogdata from the database.
		/// </summary>
		/// <returns>A LoginLogDataCollection containing all loginlogdata.</returns>
		LoginLogDataCollection ILoginLogDataDal.GetLoginLogData() {
			LoginLogDataCollection loginlogdataToReturn = new LoginLogDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							loginlogdataToReturn.Add( _sqlHelper.LoginLogDataFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return loginlogdataToReturn;
		}

		/// <summary>
		/// Get all loginlogdata from the database for a specific year and month.
		/// </summary>
		/// <param name="year">The year to get the loginlogs for.</param>
		/// <param name="month">The month to get the loginlogs for.</param>
		/// <returns>An LoginLogDataCollection containing all requested loginlogdata.</returns>
		LoginLogDataCollection ILoginLogDataDal.GetLoginLogDataByMonth( int year , int month ) {
			LoginLogDataCollection loginlogdataToReturn = new LoginLogDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByYearAndMonth() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterYear , year );
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterMonth , month );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							loginlogdataToReturn.Add( _sqlHelper.LoginLogDataFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return loginlogdataToReturn;
		}

		/// <summary>
		/// Get a single loginlogdata from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the loginlogdata to retrieve.</param>
		/// <returns>An LoginLogDataCollection containing the requested loginlogdata.</returns>
		LoginLogDataCollection ILoginLogDataDal.GetLoginLogDataBySysId( int sysId ) {
			return ( (ILoginLogDataDal)this ).GetLoginLogDataBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple loginlogdata from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the loginlogdata to retrieve.</param>
		/// <returns>An LoginLogDataCollection containing the requested loginlogdata.</returns>
		LoginLogDataCollection ILoginLogDataDal.GetLoginLogDataBySysIds( int[] sysIds ) {
			LoginLogDataCollection loginlogdataToReturn = new LoginLogDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							loginlogdataToReturn.Add( _sqlHelper.LoginLogDataFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return loginlogdataToReturn;
		}

		/// <summary>
		/// Insert one or more loginlogdata to the database.
		/// </summary>
		/// <param name="loginlogdata">An LoginLogDataCollection containing the loginlogdata to insert.</param>
		/// <returns>An LoginLogDataCollection containing the inserted loginlogdata.</returns>
		LoginLogDataCollection ILoginLogDataDal.InsertLoginLogData( LoginLogDataCollection loginlogdata ) {
			return Save( loginlogdata , true );
		}

		/// <summary>
		/// Update one or more loginlogdata in the database.
		/// </summary>
		/// <param name="loginlogdata">An LoginLogDataCollection containing the loginlogdata to update.</param>
		/// <returns>An LoginLogDataCollection containing the updated loginlogdata.</returns>
		LoginLogDataCollection ILoginLogDataDal.UpdateLoginLogData( LoginLogDataCollection loginlogdata ) {
			return Save( loginlogdata , false );
		}

		/// <summary>
		/// Remove one or more loginlogdata from the database.
		/// </summary>
		/// <param name="loginlogdata">An LoginLogDataCollection containing the loginlogdata to remove.</param>
		void ILoginLogDataDal.RemoveLoginLogData( LoginLogDataCollection loginlogdata ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( LoginLogData loginlog in loginlogdata ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , loginlog.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , loginlog.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , loginlog.ToString() , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
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
		/// Remove all loginlogdata from the database.
		/// </summary>
		void ILoginLogDataDal.RemoveAllLoginLogData() {
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

		private LoginLogDataCollection Save( LoginLogDataCollection loginlogdata , bool insert ) {
			LoginLogDataCollection loginlogdataToReturn = new LoginLogDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( LoginLogData loginlog in loginlogdata ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDateTime , loginlog.DateTime );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmployeeSysId , loginlog.EmployeeSysId );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , loginlog.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , loginlog.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									loginlogdataToReturn.Add( _sqlHelper.LoginLogDataFromReader( reader ) );
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
			return loginlogdataToReturn;
		}

		#endregion

	}

}
