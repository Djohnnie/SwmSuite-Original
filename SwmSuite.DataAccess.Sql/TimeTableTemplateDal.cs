using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.DataAccess.Sql.SqlHelper;
using SwmSuite.Data.DataObjects;
using SwmSuite.DataAccess.Interface;
using System.Data.SqlClient;
using SwmSuite.Configuration;
using System.Transactions;

namespace SwmSuite.DataAccess.Sql {

	public class TimeTableTemplateDal : ITimeTableTemplateDal {

		#region -_ Private Members _-

		private TimeTableTemplateSqlHelper _sqlHelper = new TimeTableTemplateSqlHelper();

		#endregion

		#region -_ ITimeTableTemplateDal Members _-

		/// <summary>
		/// Get all timetabletemplates from the database.
		/// </summary>
		/// <returns>A TimeTableTemplateCollection containing all timetabletemplates.</returns>
		TimeTableTemplateDataCollection ITimeTableTemplateDal.GetTimeTableTemplateData() {
			TimeTableTemplateDataCollection timeTableTemplateDataCollectionToReturn = new TimeTableTemplateDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							timeTableTemplateDataCollectionToReturn.Add( _sqlHelper.TimeTableTemplateFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return timeTableTemplateDataCollectionToReturn;
		}

		/// <summary>
		/// Get all timetabletemplatedatacollection from the database for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroupSysId">The internal id of the employeegroup to get the timetable templates for.</param>
		/// <returns>An TimeTableTemplateDataCollection containing all requested timetabletemplatedatacollection.</returns>
		TimeTableTemplateDataCollection ITimeTableTemplateDal.GetTimeTableTemplateDataForEmployeeGroup( int employeeGroupSysId ) {
			TimeTableTemplateDataCollection timeTableTemplateDataCollectionToReturn = new TimeTableTemplateDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByEmployeeGroup() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmployeeGroupSysId , employeeGroupSysId );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							timeTableTemplateDataCollectionToReturn.Add( _sqlHelper.TimeTableTemplateFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return timeTableTemplateDataCollectionToReturn;
		}

		/// <summary>
		/// Get a single timetabletemplate from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the timetabletemplate to retrieve.</param>
		/// <returns>An TimeTableTemplateCollection containing the requested timetabletemplate.</returns>
		TimeTableTemplateDataCollection ITimeTableTemplateDal.GetTimeTableTemplateDataBySysId( int sysId ) {
			return ( (ITimeTableTemplateDal)this ).GetTimeTableTemplateDataBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple timetabletemplates from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the timetabletemplates to retrieve.</param>
		/// <returns>An TimeTableTemplateCollection containing the requested timetabletemplates.</returns>
		TimeTableTemplateDataCollection ITimeTableTemplateDal.GetTimeTableTemplateDataBySysIds( int[] sysIds ) {
			TimeTableTemplateDataCollection timetabletemplatesToReturn = new TimeTableTemplateDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							timetabletemplatesToReturn.Add( _sqlHelper.TimeTableTemplateFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return timetabletemplatesToReturn;
		}

		/// <summary>
		/// Insert one or more timetabletemplates to the database.
		/// </summary>
		/// <param name="timetabletemplates">An TimeTableTemplateCollection containing the timetabletemplates to insert.</param>
		/// <returns>An TimeTableTemplateCollection containing the inserted timetabletemplates.</returns>
		TimeTableTemplateDataCollection ITimeTableTemplateDal.InsertTimeTableTemplateData( TimeTableTemplateDataCollection timetabletemplates ) {
			return Save( timetabletemplates , true );
		}

		/// <summary>
		/// Update one or more timetabletemplates in the database.
		/// </summary>
		/// <param name="timetabletemplates">An TimeTableTemplateCollection containing the timetabletemplates to update.</param>
		/// <returns>An TimeTableTemplateCollection containing the updated timetabletemplates.</returns>
		TimeTableTemplateDataCollection ITimeTableTemplateDal.UpdateTimeTableTemplateData( TimeTableTemplateDataCollection timetabletemplates ) {
			return Save( timetabletemplates , false );
		}

		/// <summary>
		/// Remove one or more timetabletemplates from the database.
		/// </summary>
		/// <param name="timetabletemplates">An TimeTableTemplateCollection containing the timetabletemplates to remove.</param>
		void ITimeTableTemplateDal.RemoveTimeTableTemplateData( TimeTableTemplateDataCollection timetabletemplates ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( TimeTableTemplateData timetabletemplate in timetabletemplates ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , timetabletemplate.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , timetabletemplate.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , timetabletemplate.ToString() , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
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
		/// Remove all timetabletemplates from the database.
		/// </summary>
		void ITimeTableTemplateDal.RemoveAllTimeTableTemplateData() {
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

		private TimeTableTemplateDataCollection Save( TimeTableTemplateDataCollection timetabletemplates , bool insert ) {
			TimeTableTemplateDataCollection timetabletemplatesToReturn = new TimeTableTemplateDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( TimeTableTemplateData timetabletemplate in timetabletemplates ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterName , timetabletemplate.Name );
							if( !String.IsNullOrEmpty( timetabletemplate.Description ) ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDescription , timetabletemplate.Description );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDescription , DBNull.Value );
							}
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEmployeeGroupSysId , timetabletemplate.EmployeeGroupSysId );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , timetabletemplate.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , timetabletemplate.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									timetabletemplatesToReturn.Add( _sqlHelper.TimeTableTemplateFromReader( reader ) );
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
			return timetabletemplatesToReturn;
		}

		#endregion

	}

}
