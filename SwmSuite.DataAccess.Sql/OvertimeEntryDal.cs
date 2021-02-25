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

	public sealed class OvertimeEntryDal : IOvertimeEntryDal {

		#region -_ Private Members _-

		private OvertimeEntrySqlHelper _sqlHelper = new OvertimeEntrySqlHelper();

		#endregion

		#region -_ IOvertimeEntryDataDal Members _-

		/// <summary>
		/// Get all overtimeentrydata from the database.
		/// </summary>
		/// <returns>A OvertimeEntryDataCollection containing all overtimeentrydata.</returns>
		OvertimeEntryDataCollection IOvertimeEntryDal.GetOvertimeEntryData() {
			OvertimeEntryDataCollection overtimeentrydataToReturn = new OvertimeEntryDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							overtimeentrydataToReturn.Add( _sqlHelper.OvertimeEntryDataFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return overtimeentrydataToReturn;
		}

		/// <summary>
		/// Get all overtimeentrydata from the database for a specific employee and year.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the overtime entries for.</param>
		/// <param name="year">The year to get the overtime entries for.</param>
		/// <returns>An OvertimeEntryDataCollection containing all overtimeentrydata.</returns>
		OvertimeEntryDataCollection IOvertimeEntryDal.GetOvertimeEntryDataByEmployeeAndYear( int employeeSysId , int year ) {
			OvertimeEntryDataCollection overtimeentrydataToReturn = new OvertimeEntryDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByEmployeeAndYear() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmployeeSysId , employeeSysId );
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterYear , year );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							overtimeentrydataToReturn.Add( _sqlHelper.OvertimeEntryDataFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return overtimeentrydataToReturn;
		}

		/// <summary>
		/// Get a single overtimeentrydata from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the overtimeentrydata to retrieve.</param>
		/// <returns>An OvertimeEntryDataCollection containing the requested overtimeentrydata.</returns>
		OvertimeEntryDataCollection IOvertimeEntryDal.GetOvertimeEntryDataBySysId( int sysId ) {
			return ( (IOvertimeEntryDal)this ).GetOvertimeEntryDataBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple overtimeentrydata from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the overtimeentrydata to retrieve.</param>
		/// <returns>An OvertimeEntryDataCollection containing the requested overtimeentrydata.</returns>
		OvertimeEntryDataCollection IOvertimeEntryDal.GetOvertimeEntryDataBySysIds( int[] sysIds ) {
			OvertimeEntryDataCollection overtimeentrydataToReturn = new OvertimeEntryDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							overtimeentrydataToReturn.Add( _sqlHelper.OvertimeEntryDataFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return overtimeentrydataToReturn;
		}

		/// <summary>
		/// Insert one or more overtimeentrydata to the database.
		/// </summary>
		/// <param name="overtimeentrydata">An OvertimeEntryDataCollection containing the overtimeentrydata to insert.</param>
		/// <returns>An OvertimeEntryDataCollection containing the inserted overtimeentrydata.</returns>
		OvertimeEntryDataCollection IOvertimeEntryDal.InsertOvertimeEntryData( OvertimeEntryDataCollection overtimeentrydata ) {
			return Save( overtimeentrydata , true );
		}

		/// <summary>
		/// Update one or more overtimeentrydata in the database.
		/// </summary>
		/// <param name="overtimeentrydata">An OvertimeEntryDataCollection containing the overtimeentrydata to update.</param>
		/// <returns>An OvertimeEntryDataCollection containing the updated overtimeentrydata.</returns>
		OvertimeEntryDataCollection IOvertimeEntryDal.UpdateOvertimeEntryData( OvertimeEntryDataCollection overtimeentrydata ) {
			return Save( overtimeentrydata , false );
		}

		/// <summary>
		/// Remove one or more overtimeentrydata from the database.
		/// </summary>
		/// <param name="overtimeentrydata">An OvertimeEntryDataCollection containing the overtimeentrydata to remove.</param>
		void IOvertimeEntryDal.RemoveOvertimeEntryData( OvertimeEntryDataCollection overtimeentrydata ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( OvertimeEntryData overtimeentry in overtimeentrydata ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , overtimeentry.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , overtimeentry.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , overtimeentry.ToString() , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
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
		/// Remove all overtimeentrydata from the database.
		/// </summary>
		void IOvertimeEntryDal.RemoveAllOvertimeEntryData() {
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

		private OvertimeEntryDataCollection Save( OvertimeEntryDataCollection overtimeentrydata , bool insert ) {
			OvertimeEntryDataCollection overtimeentrydataToReturn = new OvertimeEntryDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( OvertimeEntryData overtimeentry in overtimeentrydata ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDescription , overtimeentry.Description );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDateTimeStart , overtimeentry.DateTimeStart );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDateTimeEnd , overtimeentry.DateTimeEnd );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmployeeSysId , overtimeentry.EmployeeSysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterOvertimeStatus , overtimeentry.OvertimeStatus );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCommissionerSysId , overtimeentry.CommissionerSysId );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , overtimeentry.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , overtimeentry.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									overtimeentrydataToReturn.Add( _sqlHelper.OvertimeEntryDataFromReader( reader ) );
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
			return overtimeentrydataToReturn;
		}

		#endregion

	}

}
