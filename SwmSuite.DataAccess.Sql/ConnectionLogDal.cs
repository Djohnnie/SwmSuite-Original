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

	public sealed class ConnectionLogDal : IConnectionLogDal {

		#region -_ Private Members _-

		private ConnectionLogSqlHelper _sqlHelper = new ConnectionLogSqlHelper();

		#endregion

		#region -_ IConnectionLogDal Members _-

		/// <summary>
		/// Get all connectionlogs from the database.
		/// </summary>
		/// <returns>A ConnectionLogCollection containing all connectionlogs.</returns>
		ConnectionLogDataCollection IConnectionLogDal.GetConnectionLogData() {
			ConnectionLogDataCollection connectionlogsToReturn = new ConnectionLogDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							connectionlogsToReturn.Add( _sqlHelper.ConnectionLogFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return connectionlogsToReturn;
		}

		/// <summary>
		/// Get all connectionlogs from the database for a specific year and month.
		/// </summary>
		/// <param name="year">The year to get the connectionlogs for.</param>
		/// <param name="month">The month to get the connectionlogs for.</param>
		/// <returns>An LoginLogDataCollection containing all requested connectionlogs.</returns>
		ConnectionLogDataCollection IConnectionLogDal.GetConnectionLogDataByMonth( int year , int month ) {
			ConnectionLogDataCollection connectionlogsToReturn = new ConnectionLogDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByYearAndMonth() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterYear , year );
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterMonth , month );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							connectionlogsToReturn.Add( _sqlHelper.ConnectionLogFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return connectionlogsToReturn;
		}

		/// <summary>
		/// Get a single connectionlog from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the connectionlog to retrieve.</param>
		/// <returns>An ConnectionLogCollection containing the requested connectionlog.</returns>
		ConnectionLogDataCollection IConnectionLogDal.GetConnectionLogDataBySysId( int sysId ) {
			return ( (IConnectionLogDal)this ).GetConnectionLogDataBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple connectionlogs from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the connectionlogs to retrieve.</param>
		/// <returns>An ConnectionLogCollection containing the requested connectionlogs.</returns>
		ConnectionLogDataCollection IConnectionLogDal.GetConnectionLogDataBySysIds( int[] sysIds ) {
			ConnectionLogDataCollection connectionlogsToReturn = new ConnectionLogDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							connectionlogsToReturn.Add( _sqlHelper.ConnectionLogFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return connectionlogsToReturn;
		}

		/// <summary>
		/// Insert one or more connectionlogs to the database.
		/// </summary>
		/// <param name="connectionLogData">An ConnectionLogCollection containing the connectionlogs to insert.</param>
		/// <returns>An ConnectionLogCollection containing the inserted connectionlogs.</returns>
		ConnectionLogDataCollection IConnectionLogDal.InsertConnectionLogData( ConnectionLogDataCollection connectionLogData ) {
			return Save( connectionLogData , true );
		}

		/// <summary>
		/// Update one or more connectionlogs in the database.
		/// </summary>
		/// <param name="connectionLogData">An ConnectionLogCollection containing the connectionlogs to update.</param>
		/// <returns>An ConnectionLogCollection containing the updated connectionlogs.</returns>
		ConnectionLogDataCollection IConnectionLogDal.UpdateConnectionLogData( ConnectionLogDataCollection connectionLogData ) {
			return Save( connectionLogData , false );
		}

		/// <summary>
		/// Remove one or more connectionlogs from the database.
		/// </summary>
		/// <param name="connectionLogData">An ConnectionLogCollection containing the connectionlogs to remove.</param>
		void IConnectionLogDal.RemoveConnectionLogData( ConnectionLogDataCollection connectionLogData ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( ConnectionLogData connectionlog in connectionLogData ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , connectionlog.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , connectionlog.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , connectionlog.ToString() , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
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
		/// Remove all connectionlogs from the database.
		/// </summary>
		void IConnectionLogDal.RemoveAllConnectionLogData() {
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

		private ConnectionLogDataCollection Save( ConnectionLogDataCollection connectionLogData , bool insert ) {
			ConnectionLogDataCollection connectionlogsToReturn = new ConnectionLogDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( ConnectionLogData connectionlog in connectionLogData ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDateTime , connectionlog.DateTime );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterClient , connectionlog.Client );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , connectionlog.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , connectionlog.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									connectionlogsToReturn.Add( _sqlHelper.ConnectionLogFromReader( reader ) );
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
			return connectionlogsToReturn;
		}

		#endregion

	}

}
