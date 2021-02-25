using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.DataAccess.Sql.SqlHelper.Main;
using SwmSuite.Data.DataObjects;
using System.Data.SqlClient;
using System.Transactions;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Configuration;
using SwmSuite.Framework.Exceptions;
using System.Data;

namespace SwmSuite.DataAccess.Sql {

	public sealed class ZipCodeDal : IZipCodeDal {

		#region -_ Private Members _-

		private ZipCodeSqlHelper _sqlHelper = new ZipCodeSqlHelper();

		#endregion

		#region -_ IZipCodeDal Members _-

		/// <summary>
		/// Get all zipcodes from the database.
		/// </summary>
		/// <returns>A ZipCodeCollection containing all zipcodes.</returns>
		ZipCodeDataCollection IZipCodeDal.GetZipCodeData() {
			ZipCodeDataCollection zipcodesToReturn = new ZipCodeDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							zipcodesToReturn.Add( _sqlHelper.ZipCodeFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return zipcodesToReturn;
		}

		/// <summary>
		/// Get all zipcodes from the database for a specific country.
		/// </summary>
		/// <param name="countrySysId">The internal id for the country to get the zipcodes for.</param>
		/// <returns>A ZipCodeCollection containing all requested zipcodes.</returns>
		ZipCodeDataCollection IZipCodeDal.GetZipCodeDataByCountry( int countrySysId ) {
			ZipCodeDataCollection zipcodesToReturn = new ZipCodeDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection( ) ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectByCountry() , conn ) ) {
					cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCountrySysId , countrySysId );
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							zipcodesToReturn.Add( _sqlHelper.ZipCodeFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return zipcodesToReturn;
		}

		/// <summary>
		/// Get a single zipcode from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the zipcode to retrieve.</param>
		/// <returns>An ZipCodeCollection containing the requested zipcode.</returns>
		ZipCodeDataCollection IZipCodeDal.GetZipCodeDataBySysId( int sysId ) {
			return ( (IZipCodeDal)this ).GetZipCodesDataBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple zipcodes from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the zipcodes to retrieve.</param>
		/// <returns>An ZipCodeCollection containing the requested zipcodes.</returns>
		ZipCodeDataCollection IZipCodeDal.GetZipCodesDataBySysIds( int[] sysIds ) {
			ZipCodeDataCollection zipcodesToReturn = new ZipCodeDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							zipcodesToReturn.Add( _sqlHelper.ZipCodeFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return zipcodesToReturn;
		}

		/// <summary>
		/// Insert one or more zipcodes to the database.
		/// </summary>
		/// <param name="zipcodes">An ZipCodeCollection containing the zipcodes to insert.</param>
		/// <returns>An ZipCodeCollection containing the inserted zipcodes.</returns>
		ZipCodeDataCollection IZipCodeDal.InsertZipCodeData( ZipCodeDataCollection zipcodes ) {
			return Save( zipcodes , true );
		}

		/// <summary>
		/// Update one or more zipcodes in the database.
		/// </summary>
		/// <param name="zipcodes">An ZipCodeCollection containing the zipcodes to update.</param>
		/// <returns>An ZipCodeCollection containing the updated zipcodes.</returns>
		ZipCodeDataCollection IZipCodeDal.UpdateZipCodeData( ZipCodeDataCollection zipcodes ) {
			return Save( zipcodes , false );
		}

		/// <summary>
		/// Remove one or more zipcodes from the database.
		/// </summary>
		/// <param name="zipcodes">An ZipCodeCollection containing the zipcodes to remove.</param>
		void IZipCodeDal.RemoveZipCodeData( ZipCodeDataCollection zipcodes ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( ZipCodeData zipcode in zipcodes ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , zipcode.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , zipcode.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , zipcode.ToString() , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
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
		/// Remove all zipcodes from the database.
		/// </summary>
		void IZipCodeDal.RemoveAllZipCodeData() {
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

		private ZipCodeDataCollection Save( ZipCodeDataCollection zipcodes , bool insert ) {
			ZipCodeDataCollection zipcodesToReturn = new ZipCodeDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( ZipCodeData zipcode in zipcodes ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCode , zipcode.Code );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCity , zipcode.City );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCountrySysId , zipcode.CountrySysId );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , zipcode.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , zipcode.RowVersion );
							}using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									zipcodesToReturn.Add( _sqlHelper.ZipCodeFromReader( reader ) );
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
			return zipcodesToReturn;
		}

		#endregion

	}

}
