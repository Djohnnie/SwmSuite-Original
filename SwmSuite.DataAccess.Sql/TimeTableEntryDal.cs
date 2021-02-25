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

	public sealed class TimeTableEntryDal : ITimeTableEntryDal {

		#region -_ Private Members _-

		private TimeTableEntrySqlHelper _sqlHelper = new TimeTableEntrySqlHelper();

		#endregion

		#region -_ ITimeTableEntryDal Members _-

		/// <summary>
		/// Get all timetableentrydatacollection from the database.
		/// </summary>
		/// <returns>A TimeTableEntryDataCollection containing all timetableentrydatacollection.</returns>
		TimeTableEntryDataCollection ITimeTableEntryDal.GetTimeTableEntryDataCollection() {
			TimeTableEntryDataCollection timetableentrydatacollectionToReturn = new TimeTableEntryDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							timetableentrydatacollectionToReturn.Add( _sqlHelper.TimeTableEntryFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return timetableentrydatacollectionToReturn;
		}

		/// <summary>
		/// Get a single timetableentrydata from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the timetableentrydata to retrieve.</param>
		/// <returns>An TimeTableEntryDataCollection containing the requested timetableentrydata.</returns>
		TimeTableEntryDataCollection ITimeTableEntryDal.GetTimeTableEntryDataBySysId( int sysId ) {
			return ( (ITimeTableEntryDal)this ).GetTimeTableEntryDataCollectionBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple timetableentrydatacollection from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the timetableentrydatacollection to retrieve.</param>
		/// <returns>An TimeTableEntryDataCollection containing the requested timetableentrydatacollection.</returns>
		TimeTableEntryDataCollection ITimeTableEntryDal.GetTimeTableEntryDataCollectionBySysIds( int[] sysIds ) {
			TimeTableEntryDataCollection timetableentrydatacollectionToReturn = new TimeTableEntryDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							timetableentrydatacollectionToReturn.Add( _sqlHelper.TimeTableEntryFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return timetableentrydatacollectionToReturn;
		}

		/// <summary>
		/// Get all timetable entries from the database for a specific employee on a specific date.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the timetable entries for.</param>
		/// <param name="onDate">The date to get the timetable entries for.</param>
		/// <returns>A TimeTableEntryDataCollection containing all requested timetables entries.</returns>
		TimeTableEntryDataCollection ITimeTableEntryDal.GetTimeTableEntryDataCollectionForEmployeeOnDate(
			int employeeSysId , DateTime onDate ) {
			TimeTableEntryDataCollection timetableentrydatacollectionToReturn = new TimeTableEntryDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByEmployeeOnDate() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmployeeSysId , employeeSysId );
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDate , onDate );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							timetableentrydatacollectionToReturn.Add( _sqlHelper.TimeTableEntryFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return timetableentrydatacollectionToReturn;
		}

		/// <summary>
		/// Get all timetable entries from the database for a specific employee in a specific date period.
		/// </summary>
		/// <param name="employeeSysId">The internal id of the employee to get the timetable entries for.</param>
		/// <param name="periodStart">The startdate of the period to get the timetable entries for.</param>
		/// <param name="periodEnd">The enddate of the period to get the timetable entries for.</param>
		/// <returns>A TimeTableEntryDataCollection containing all requested timetables entries.</returns>
		TimeTableEntryDataCollection ITimeTableEntryDal.GetTimeTableEntryDataCollectionForEmployeeInPeriod(
			int employeeSysId , DateTime periodStart , DateTime periodEnd ) {
			TimeTableEntryDataCollection timetableentrydatacollectionToReturn = new TimeTableEntryDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByEmployeeInPeriod() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmployeeSysId , employeeSysId );
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterPeriodStart , periodStart );
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterPeriodEnd , periodEnd );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							timetableentrydatacollectionToReturn.Add( _sqlHelper.TimeTableEntryFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return timetableentrydatacollectionToReturn;
		}

		/// <summary>
		/// Insert one or more timetableentrydatacollection to the database.
		/// </summary>
		/// <param name="timetableentrydatacollection">An TimeTableEntryDataCollection containing the timetableentrydatacollection to insert.</param>
		/// <returns>An TimeTableEntryDataCollection containing the inserted timetableentrydatacollection.</returns>
		TimeTableEntryDataCollection ITimeTableEntryDal.InsertTimeTableEntryDataCollection( TimeTableEntryDataCollection timetableentrydatacollection ) {
			return Save( timetableentrydatacollection , true );
		}

		/// <summary>
		/// Update one or more timetableentrydatacollection in the database.
		/// </summary>
		/// <param name="timetableentrydatacollection">An TimeTableEntryDataCollection containing the timetableentrydatacollection to update.</param>
		/// <returns>An TimeTableEntryDataCollection containing the updated timetableentrydatacollection.</returns>
		TimeTableEntryDataCollection ITimeTableEntryDal.UpdateTimeTableEntryDataCollection( TimeTableEntryDataCollection timetableentrydatacollection ) {
			return Save( timetableentrydatacollection , false );
		}

		/// <summary>
		/// Remove one or more timetableentrydatacollection from the database.
		/// </summary>
		/// <param name="timetableentrydatacollection">An TimeTableEntryDataCollection containing the timetableentrydatacollection to remove.</param>
		void ITimeTableEntryDal.RemoveTimeTableEntryDataCollection( TimeTableEntryDataCollection timetableentrydatacollection ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( TimeTableEntryData timetableentrydata in timetableentrydatacollection ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , timetableentrydata.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , timetableentrydata.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , timetableentrydata.ToString() , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
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
		/// Remove all timetableentrydatacollection from the database.
		/// </summary>
		void ITimeTableEntryDal.RemoveAllTimeTableEntryDataCollection() {
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

		private TimeTableEntryDataCollection Save( TimeTableEntryDataCollection timetableentrydatacollection , bool insert ) {
			TimeTableEntryDataCollection timetableentrydatacollectionToReturn = new TimeTableEntryDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( TimeTableEntryData timetableentrydata in timetableentrydatacollection ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDate , timetableentrydata.Date );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmployeeSysId , timetableentrydata.EmployeeSysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterFrom.Replace( "[" , "" ).Replace( "]" , "" ) , timetableentrydata.From );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterTo.Replace( "[" , "" ).Replace( "]" , "" ) , timetableentrydata.To );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterTimeTablePurposeSysId , timetableentrydata.TimeTablePurposeSysId );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , timetableentrydata.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , timetableentrydata.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									timetableentrydatacollectionToReturn.Add( _sqlHelper.TimeTableEntryFromReader( reader ) );
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
			return timetableentrydatacollectionToReturn;
		}

		#endregion

	}

}
