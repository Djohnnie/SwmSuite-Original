using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.DataAccess.Interface;

using System.Transactions;
using System.Data.SqlClient;
using SwmSuite.Configuration;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Sql {
	
	/// <summary>
	/// DAL Interface for the LogDelete methods.
	/// </summary>
	public sealed class LogDeleteDal : ILogDeleteDal {

		#region IEmployeeDal Members

		/// <summary>
		/// Get all logdeletes from the database.
		/// </summary>
		/// <returns>A LogDeleteCollection containing all logdeletes.</returns>
		LogDeleteDataCollection ILogDeleteDal.GetLogDeleteData() {
			LogDeleteDataCollection logDeletesToReturn = new LogDeleteDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							LogDeleteData logDelete = new LogDeleteData();
							logDelete.SysId = (int)reader[LogDeleteData.DBColumnSysId];
							logDelete.TableName = (String)reader[LogDeleteData.DBColumnTableName];
							logDelete.Info = (String)reader[LogDeleteData.DBColumnInfo];
							logDelete.DeletedBy = (Guid)reader[LogDeleteData.DBColumnDeletedBy];
							logDelete.DeletedOn = (DateTime)reader[LogDeleteData.DBColumnDeletedOn];
							logDeletesToReturn.Add( logDelete );
						}
					}
				}
				conn.Close();
			}
			return logDeletesToReturn;
		}

		/// <summary>
		/// Get a single logdelete from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the logdelete to retrieve.</param>
		/// <returns>A LogDeleteCollection containing the requested logdelete.</returns>
		LogDeleteDataCollection ILogDeleteDal.GetLogDeleteDataBySysId( int sysId ) {
			return ((ILogDeleteDal)this).GetLogDeleteDataBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple logdeletes from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the logdeletes to retrieve.</param>
		/// <returns>A LogDeleteCollection containing the requested logdeletes.</returns>
		LogDeleteDataCollection ILogDeleteDal.GetLogDeleteDataBySysIds( int[] sysIds ) {
			LogDeleteDataCollection logDeletesToReturn = new LogDeleteDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				using( SqlCommand cmd = new SqlCommand( CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							LogDeleteData logDelete = new LogDeleteData();
							logDelete.SysId = (int)reader[LogDeleteData.DBColumnSysId];
							logDelete.TableName = (String)reader[LogDeleteData.DBColumnTableName];
							logDelete.Info = (String)reader[LogDeleteData.DBColumnInfo];
							logDelete.DeletedBy = (Guid)reader[LogDeleteData.DBColumnDeletedBy];
							logDelete.DeletedOn = (DateTime)reader[LogDeleteData.DBColumnDeletedOn];
							logDeletesToReturn.Add( logDelete );
						}
					}
				}
			}
			return logDeletesToReturn;
		}

		/// <summary>
		/// Insert one or more logdeletes to the database.
		/// </summary>
		/// <param name="logDeletes">A LogDeleteCollection containing the logdeletes to insert.</param>
		void ILogDeleteDal.InsertLogDeleteData( LogDeleteDataCollection logDeletes ) {
			using( TransactionScope scope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( LogDeleteData logDelete in logDeletes ) {
							SqlCommand cmd = new SqlCommand( CreateInsertCommand() , conn );
							cmd.Parameters.AddWithValue( LogDeleteData.DBParameterTableName , logDelete.TableName );
							cmd.Parameters.AddWithValue( LogDeleteData.DBParameterInfo , logDelete.Info );
							cmd.Parameters.AddWithValue( LogDeleteData.DBParameterDeletedBy , logDelete.DeletedBy );
							cmd.Parameters.AddWithValue( LogDeleteData.DBParameterDeletedOn , logDelete.DeletedOn );
							cmd.ExecuteNonQuery();
						}
					} catch( SqlException ) {
						// TODO: Exception Handling...
						throw;
					} finally {
						conn.Close();
					}
				}
				scope.Complete();
			}
		}

		/// <summary>
		/// Update one or more logdeletes in the database.
		/// </summary>
		/// <param name="logDeletes">A LogDeleteCollection containing the logdeletes to update.</param>
		void ILogDeleteDal.UpdateLogDeleteData( LogDeleteDataCollection logDeletes ) {
			using( TransactionScope scope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( LogDeleteData logDelete in logDeletes ) {
							SqlCommand cmd = new SqlCommand( CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( LogDeleteData.DBParameterTableName , logDelete.TableName );
							cmd.Parameters.AddWithValue( LogDeleteData.DBParameterInfo , logDelete.Info );
							cmd.Parameters.AddWithValue( LogDeleteData.DBParameterDeletedBy , logDelete.DeletedBy );
							cmd.Parameters.AddWithValue( LogDeleteData.DBParameterDeletedOn , logDelete.DeletedOn );
							cmd.Parameters.AddWithValue( LogDeleteData.DBParameterSysId , logDelete.SysId );
							cmd.ExecuteNonQuery();
						}
					} catch( SqlException ) {
						// TODO: Exception Handling...
						throw;
					} finally {
						conn.Close();
					}
				}
				scope.Complete();
			}
		}

		/// <summary>
		/// Remove one or more logdeletes from the database.
		/// </summary>
		/// <param name="logDeletes">A LogDeleteCollection containing the logdeletes to remove.</param>
		void ILogDeleteDal.RemoveLogDeleteData( LogDeleteDataCollection logDeletes ) {
			using( TransactionScope scope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( LogDeleteData logDelete in logDeletes ) {
							SqlCommand cmd = new SqlCommand( CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( LogDeleteData.DBParameterSysId , logDelete.SysId );
							cmd.ExecuteNonQuery();
						}
					} catch( SqlException ) {
						// TODO: Exception Handling...
						throw;
					} finally {
						conn.Close();
					}
				}
				scope.Complete();
			}
		}

		/// <summary>
		/// Remove one or more logdeletes from the database.
		/// </summary>
		void ILogDeleteDal.RemoveAllLogDeleteData() {
			using( TransactionScope scope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						SqlCommand cmd = new SqlCommand( CreateDeleteAllCommand() , conn );
						cmd.ExecuteNonQuery();
					} catch( SqlException ) {
						// TODO: Exception Handling...
						throw;
					} finally {
						conn.Close();
					}
				}
				scope.Complete();
			}
		}

		#endregion

		#region -_ Helper Methods _-

		#endregion

		#region -_ SQL Methods _-

		private static String CreateBaseSelect() {
			String selectCommand = "";
			selectCommand += "SELECT";
			selectCommand += " tbl_LogDelete." + LogDeleteData.DBColumnSysId + ",";
			selectCommand += " tbl_LogDelete." + LogDeleteData.DBColumnTableName + ",";
			selectCommand += " tbl_LogDelete." + LogDeleteData.DBColumnInfo + ",";
			selectCommand += " tbl_LogDelete." + LogDeleteData.DBColumnDeletedBy + ",";
			selectCommand += " tbl_LogDelete." + LogDeleteData.DBColumnDeletedOn;
			selectCommand += " FROM";
			selectCommand += " tbl_LogDelete";
			return selectCommand;
		}

		private static String CreateSelectBySysIds( int[] sysIds ) {
			String selectCommand = CreateBaseSelect();
			selectCommand += " WHERE";
			selectCommand += " tbl_LogDelete." + LogDeleteData.DBColumnSysId;
			selectCommand += " IN (";
			selectCommand += DalUtil.ConvertIntArrayToString( sysIds );
			selectCommand += ")";
			return selectCommand;
		}

		private static String CreateInsertCommand() {
			String insertCommand = "";
			insertCommand += "INSERT INTO tbl_LogDelete";
			insertCommand += " (" + LogDeleteData.DBColumnTableName + "," + LogDeleteData.DBColumnInfo + "," + LogDeleteData.DBColumnDeletedBy + "," + LogDeleteData.DBColumnDeletedOn + ")";
			insertCommand += " VALUES";
			insertCommand += " (" + LogDeleteData.DBParameterTableName + "," + LogDeleteData.DBParameterInfo + "," + LogDeleteData.DBParameterDeletedBy + "," + LogDeleteData.DBParameterDeletedOn + ")";
			return insertCommand;
		}

		private static String CreateUpdateCommand() {
			String updateCommand = "";
			updateCommand += "UPDATE tbl_LogDelete";
			updateCommand += " SET " + LogDeleteData.DBColumnTableName + " = " + LogDeleteData.DBParameterTableName;
			updateCommand += " , " + LogDeleteData.DBColumnInfo + " = " + LogDeleteData.DBParameterInfo;
			updateCommand += " , " + LogDeleteData.DBColumnDeletedBy + " = " + LogDeleteData.DBParameterDeletedBy;
			updateCommand += " , " + LogDeleteData.DBColumnDeletedOn + " = " + LogDeleteData.DBParameterDeletedOn;
			updateCommand += " WHERE " + LogDeleteData.DBColumnSysId + " = " + LogDeleteData.DBParameterSysId;
			return updateCommand;
		}

		private static String CreateDeleteCommand() {
			String deleteCmd = "";
			deleteCmd += "DELETE FROM tbl_LogDelete";
			deleteCmd += " WHERE " + LogDeleteData.DBColumnSysId + " = " + LogDeleteData.DBParameterSysId;
			return deleteCmd;
		}

		private static String CreateDeleteAllCommand() {
			String deleteCmd = "";
			deleteCmd += "DELETE FROM tbl_LogDelete";
			return deleteCmd;
		}

		#endregion

	}

}
