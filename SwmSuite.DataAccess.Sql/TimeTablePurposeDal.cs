using System;
using System.Collections.Generic;
using System.Text;
using SwmSuite.DataAccess.Sql.SqlHelper;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;
using SwmSuite.Configuration;
using System.Transactions;

namespace SwmSuite.DataAccess.Sql {

	public sealed class TimeTablePurposeDal : ITimeTablePurposeDal {

		#region -_ Private Members _-

		private TimeTablePurposeSqlHelper _sqlHelper = new TimeTablePurposeSqlHelper();

		#endregion

		#region -_ ITimeTablePurposeDataDal Members _-

		/// <summary>
		/// Get all timetablepurposedatacollection from the database.
		/// </summary>
		/// <returns>A TimeTablePurposeDataCollection containing all timetablepurposedatacollection.</returns>
		TimeTablePurposeDataCollection ITimeTablePurposeDal.GetTimeTablePurposeDataCollection() {
			TimeTablePurposeDataCollection timetablepurposedatacollectionToReturn = new TimeTablePurposeDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							timetablepurposedatacollectionToReturn.Add( _sqlHelper.TimeTablePurposeFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return timetablepurposedatacollectionToReturn;
		}

		/// <summary>
		/// Get all timetablepurposedatacollection from the database for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroupSysId">The internal id of the employeegroup to get the timetable purposes for.</param>
		/// <returns>An TimeTablePurposeDataCollection containing all requested timetablepurposedatacollection.</returns>
		TimeTablePurposeDataCollection ITimeTablePurposeDal.GetTimeTablePurposeDataCollectionForEmployeeGroup( int employeeGroupSysId ) {
			TimeTablePurposeDataCollection timetablepurposedatacollectionToReturn = new TimeTablePurposeDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByEmployeeGroup() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmployeeGroupSysId , employeeGroupSysId );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							timetablepurposedatacollectionToReturn.Add( _sqlHelper.TimeTablePurposeFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return timetablepurposedatacollectionToReturn;
		}

		/// <summary>
		/// Get a single timetablepurposedata from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the timetablepurposedata to retrieve.</param>
		/// <returns>An TimeTablePurposeDataCollection containing the requested timetablepurposedata.</returns>
		TimeTablePurposeDataCollection ITimeTablePurposeDal.GetTimeTablePurposeDataBySysId( int sysId ) {
			return ( (ITimeTablePurposeDal)this ).GetTimeTablePurposeDataCollectionBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple timetablepurposedatacollection from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the timetablepurposedatacollection to retrieve.</param>
		/// <returns>An TimeTablePurposeDataCollection containing the requested timetablepurposedatacollection.</returns>
		TimeTablePurposeDataCollection ITimeTablePurposeDal.GetTimeTablePurposeDataCollectionBySysIds( int[] sysIds ) {
			TimeTablePurposeDataCollection timetablepurposedatacollectionToReturn = new TimeTablePurposeDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							timetablepurposedatacollectionToReturn.Add( _sqlHelper.TimeTablePurposeFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return timetablepurposedatacollectionToReturn;
		}

		/// <summary>
		/// Insert one or more timetablepurposedatacollection to the database.
		/// </summary>
		/// <param name="timetablepurposedatacollection">An TimeTablePurposeDataCollection containing the timetablepurposedatacollection to insert.</param>
		/// <returns>An TimeTablePurposeDataCollection containing the inserted timetablepurposedatacollection.</returns>
		TimeTablePurposeDataCollection ITimeTablePurposeDal.InsertTimeTablePurposeDataCollection( TimeTablePurposeDataCollection timetablepurposedatacollection ) {
			return Save( timetablepurposedatacollection , true );
		}

		/// <summary>
		/// Update one or more timetablepurposedatacollection in the database.
		/// </summary>
		/// <param name="timetablepurposedatacollection">An TimeTablePurposeDataCollection containing the timetablepurposedatacollection to update.</param>
		/// <returns>An TimeTablePurposeDataCollection containing the updated timetablepurposedatacollection.</returns>
		TimeTablePurposeDataCollection ITimeTablePurposeDal.UpdateTimeTablePurposeDataCollection( TimeTablePurposeDataCollection timetablepurposedatacollection ) {
			return Save( timetablepurposedatacollection , false );
		}

		/// <summary>
		/// Remove one or more timetablepurposedatacollection from the database.
		/// </summary>
		/// <param name="timetablepurposedatacollection">An TimeTablePurposeDataCollection containing the timetablepurposedatacollection to remove.</param>
		void ITimeTablePurposeDal.RemoveTimeTablePurposeDataCollection( TimeTablePurposeDataCollection timetablepurposedatacollection ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( TimeTablePurposeData timetablepurposedata in timetablepurposedatacollection ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , timetablepurposedata.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , timetablepurposedata.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , timetablepurposedata.ToString() , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
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
		/// Remove all timetablepurposedatacollection from the database.
		/// </summary>
		void ITimeTablePurposeDal.RemoveAllTimeTablePurposeDataCollection() {
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

		private TimeTablePurposeDataCollection Save( TimeTablePurposeDataCollection timetablepurposedatacollection , bool insert ) {
			TimeTablePurposeDataCollection timetablepurposedatacollectionToReturn = new TimeTablePurposeDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( TimeTablePurposeData timetablepurposedata in timetablepurposedatacollection ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmployeeGroupSysId , timetablepurposedata.EmployeeGroupSysId );
							if( !String.IsNullOrEmpty( timetablepurposedata.Description ) ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterPurposeDescription , timetablepurposedata.Description );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterPurposeDescription , DBNull.Value );
							}
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterLegendaColor1 , timetablepurposedata.LegendaColor1 );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterLegendaColor2 , timetablepurposedata.LegendaColor2 );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterLegendaColor3 , timetablepurposedata.LegendaColor3 );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , timetablepurposedata.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , timetablepurposedata.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									timetablepurposedatacollectionToReturn.Add( _sqlHelper.TimeTablePurposeFromReader( reader ) );
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
			return timetablepurposedatacollectionToReturn;
		}

		#endregion

	}

}
