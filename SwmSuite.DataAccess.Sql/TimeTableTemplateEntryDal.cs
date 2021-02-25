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

	public class TimeTableTemplateEntryDal : ITimeTableTemplateEntryDal {

		#region -_ Private Members _-

		private TimeTableTemplateEntrySqlHelper _sqlHelper = new TimeTableTemplateEntrySqlHelper();

		#endregion

		#region -_ ITimeTableTemplateEntryDal Members _-

		/// <summary>
		/// Get all timetabletemplateentries from the database.
		/// </summary>
		/// <returns>A TimeTableTemplateEntryDataCollection containing all timetabletemplateentries.</returns>
		TimeTableTemplateEntryDataCollection ITimeTableTemplateEntryDal.GetTimeTableTemplateEntryData() {
			TimeTableTemplateEntryDataCollection timetabletemplateentriesToReturn = new TimeTableTemplateEntryDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							timetabletemplateentriesToReturn.Add( _sqlHelper.TimeTableTemplateEntryFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return timetabletemplateentriesToReturn;
		}

		/// <summary>
		/// Get all timetable entries from the database for a specific employee on a specific date.
		/// </summary>
		/// <param name="timeTableTemplateSysId">The internal id of the employee to get the timetable entries for.</param>
		/// <returns>A TimeTableTemplateEntryDataCollection containing all requested timetables entries.</returns>
		TimeTableTemplateEntryDataCollection ITimeTableTemplateEntryDal.GetTimeTableTemplateEntryDataForTemplateOnDate( int timeTableTemplateSysId ) {
			TimeTableTemplateEntryDataCollection timetableentrydatacollectionToReturn = new TimeTableTemplateEntryDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByTemplateOnDate() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterTimeTableTemplateSysId , timeTableTemplateSysId );;
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							timetableentrydatacollectionToReturn.Add( _sqlHelper.TimeTableTemplateEntryFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return timetableentrydatacollectionToReturn;
		}

		/// <summary>
		/// Get a single timetabletemplateentry from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the timetabletemplateentry to retrieve.</param>
		/// <returns>An TimeTableTemplateEntryDataCollection containing the requested timetabletemplateentry.</returns>
		TimeTableTemplateEntryDataCollection ITimeTableTemplateEntryDal.GetTimeTableTemplateEntryDataBySysId( int sysId ) {
			return ( (ITimeTableTemplateEntryDal)this ).GetTimeTableTemplateEntryDataBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple timetabletemplateentries from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the timetabletemplateentries to retrieve.</param>
		/// <returns>An TimeTableTemplateEntryDataCollection containing the requested timetabletemplateentries.</returns>
		TimeTableTemplateEntryDataCollection ITimeTableTemplateEntryDal.GetTimeTableTemplateEntryDataBySysIds( int[] sysIds ) {
			TimeTableTemplateEntryDataCollection timetabletemplateentriesToReturn = new TimeTableTemplateEntryDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							timetabletemplateentriesToReturn.Add( _sqlHelper.TimeTableTemplateEntryFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return timetabletemplateentriesToReturn;
		}

		/// <summary>
		/// Insert one or more timetabletemplateentries to the database.
		/// </summary>
		/// <param name="timetabletemplateentries">An TimeTableTemplateEntryDataCollection containing the timetabletemplateentries to insert.</param>
		/// <returns>An TimeTableTemplateEntryDataCollection containing the inserted timetabletemplateentries.</returns>
		TimeTableTemplateEntryDataCollection ITimeTableTemplateEntryDal.InsertTimeTableTemplateEntryData( TimeTableTemplateEntryDataCollection timetabletemplateentries ) {
			return Save( timetabletemplateentries , true );
		}

		/// <summary>
		/// Update one or more timetabletemplateentries in the database.
		/// </summary>
		/// <param name="timetabletemplateentries">An TimeTableTemplateEntryDataCollection containing the timetabletemplateentries to update.</param>
		/// <returns>An TimeTableTemplateEntryDataCollection containing the updated timetabletemplateentries.</returns>
		TimeTableTemplateEntryDataCollection ITimeTableTemplateEntryDal.UpdateTimeTableTemplateEntryData( TimeTableTemplateEntryDataCollection timetabletemplateentries ) {
			return Save( timetabletemplateentries , false );
		}

		/// <summary>
		/// Remove one or more timetabletemplateentries from the database.
		/// </summary>
		/// <param name="timetabletemplateentries">An TimeTableTemplateEntryDataCollection containing the timetabletemplateentries to remove.</param>
		void ITimeTableTemplateEntryDal.RemoveTimeTableTemplateEntryData( TimeTableTemplateEntryDataCollection timetabletemplateentries ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( TimeTableTemplateEntryData timetabletemplateentry in timetabletemplateentries ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , timetabletemplateentry.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , timetabletemplateentry.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , timetabletemplateentry.ToString() , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
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
		/// Remove all timetabletemplateentries from the database.
		/// </summary>
		void ITimeTableTemplateEntryDal.RemoveAllTimeTableTemplateEntryData() {
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

		private TimeTableTemplateEntryDataCollection Save( TimeTableTemplateEntryDataCollection timetabletemplateentries , bool insert ) {
			TimeTableTemplateEntryDataCollection timetabletemplateentriesToReturn = new TimeTableTemplateEntryDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( TimeTableTemplateEntryData timetabletemplateentry in timetabletemplateentries ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDate , timetabletemplateentry.Date );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterTimeTableTemplateSysId , timetabletemplateentry.TimeTableTemplateSysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterFrom , timetabletemplateentry.From );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterTo , timetabletemplateentry.To );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterTimeTablePusposeSysId , timetabletemplateentry.TimeTablePurposeSysId );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , timetabletemplateentry.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , timetabletemplateentry.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									timetabletemplateentriesToReturn.Add( _sqlHelper.TimeTableTemplateEntryFromReader( reader ) );
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
			return timetabletemplateentriesToReturn;
		}

		#endregion


	}

}
