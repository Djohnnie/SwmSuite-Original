using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.DataAccess.Sql.SqlHelper;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;
using SwmSuite.Configuration;
using System.Transactions;

namespace SwmSuite.DataAccess.Sql {
	
	public class HolidayDefinitionDal : IHolidayDefinitionDal {

		#region -_ Private Members _-

		private HolidayDefinitionSqlHelper _sqlHelper = new HolidayDefinitionSqlHelper();

		#endregion

		#region -_ IHolidayDefinitionDal Members _-

		/// <summary>
		/// Get all holidaydefinitions from the database.
		/// </summary>
		/// <returns>A HolidayDefinitionCollection containing all holidaydefinitions.</returns>
		HolidayDefinitionDataCollection IHolidayDefinitionDal.GetHolidayDefinitionData() {
			HolidayDefinitionDataCollection holidaydefinitionsToReturn = new HolidayDefinitionDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							holidaydefinitionsToReturn.Add( _sqlHelper.HolidayDefinitionFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return holidaydefinitionsToReturn;
		}

		/// <summary>
		/// Get all holidaydefinitions from the database for a given year.
		/// </summary>
		/// <returns>An HolidayDefinitionCollection containing all requested holidaydefinitions.</returns>
		HolidayDefinitionDataCollection IHolidayDefinitionDal.GetHolidayDefinitionDataByYear( int year ) {
			HolidayDefinitionDataCollection holidaydefinitionsToReturn = new HolidayDefinitionDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							holidaydefinitionsToReturn.Add( _sqlHelper.HolidayDefinitionFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return holidaydefinitionsToReturn;
		}

		/// <summary>
		/// Get a single holidaydefinition from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the holidaydefinition to retrieve.</param>
		/// <returns>An HolidayDefinitionCollection containing the requested holidaydefinition.</returns>
		HolidayDefinitionDataCollection IHolidayDefinitionDal.GetHolidayDefinitionDataBySysId( int sysId ) {
			return ( (IHolidayDefinitionDal)this ).GetHolidayDefinitionDataBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple holidaydefinitions from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the holidaydefinitions to retrieve.</param>
		/// <returns>An HolidayDefinitionCollection containing the requested holidaydefinitions.</returns>
		HolidayDefinitionDataCollection IHolidayDefinitionDal.GetHolidayDefinitionDataBySysIds( int[] sysIds ) {
			HolidayDefinitionDataCollection holidaydefinitionsToReturn = new HolidayDefinitionDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							holidaydefinitionsToReturn.Add( _sqlHelper.HolidayDefinitionFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return holidaydefinitionsToReturn;
		}

		/// <summary>
		/// Insert one or more holidaydefinitions to the database.
		/// </summary>
		/// <param name="holidaydefinitions">An HolidayDefinitionCollection containing the holidaydefinitions to insert.</param>
		/// <returns>An HolidayDefinitionCollection containing the inserted holidaydefinitions.</returns>
		HolidayDefinitionDataCollection IHolidayDefinitionDal.InsertHolidayDefinitionData( HolidayDefinitionDataCollection holidayDefinitionData ) {
			return Save( holidayDefinitionData , true );
		}

		/// <summary>
		/// Update one or more holidaydefinitions in the database.
		/// </summary>
		/// <param name="holidaydefinitions">An HolidayDefinitionCollection containing the holidaydefinitions to update.</param>
		/// <returns>An HolidayDefinitionCollection containing the updated holidaydefinitions.</returns>
		HolidayDefinitionDataCollection IHolidayDefinitionDal.UpdateHolidayDefinitionData( HolidayDefinitionDataCollection holidayDefinitionData ) {
			return Save( holidayDefinitionData , false );
		}

		/// <summary>
		/// Remove one or more holidaydefinitions from the database.
		/// </summary>
		/// <param name="holidaydefinitions">An HolidayDefinitionCollection containing the holidaydefinitions to remove.</param>
		void IHolidayDefinitionDal.RemoveHolidayDefinitionData( HolidayDefinitionDataCollection holidayDefinitionData ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( HolidayDefinitionData holidaydefinition in holidayDefinitionData ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , holidaydefinition.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , holidaydefinition.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , holidaydefinition.ToString() , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
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
		/// Remove all holidaydefinitions from the database.
		/// </summary>
		void IHolidayDefinitionDal.RemoveAllHolidayDefinitionData() {
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

		private HolidayDefinitionDataCollection Save( HolidayDefinitionDataCollection holidayDefinitionData , bool insert ) {
			HolidayDefinitionDataCollection holidaydefinitionsToReturn = new HolidayDefinitionDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( HolidayDefinitionData holidaydefinition in holidayDefinitionData ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterName , holidaydefinition.Name );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRecurringHoliday , holidaydefinition.RecurringHoliday );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDateStart , holidaydefinition.DateStart );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterDateEnd , holidaydefinition.DateEnd );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , holidaydefinition.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , holidaydefinition.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									holidaydefinitionsToReturn.Add( _sqlHelper.HolidayDefinitionFromReader( reader ) );
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
			return holidaydefinitionsToReturn;
		}

		#endregion

	}

}
