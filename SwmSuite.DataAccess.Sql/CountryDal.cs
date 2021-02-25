using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.DataAccess.Sql.SqlHelper.Main;
using SwmSuite.Data.DataObjects;
using SwmSuite.DataAccess.Interface;
using System.Data.SqlClient;
using SwmSuite.Configuration;
using System.Transactions;

namespace SwmSuite.DataAccess.Sql {

	public sealed class CountryDal : ICountryDal {

		#region -_ Private Members _-

		private CountrySqlHelper _sqlHelper = new CountrySqlHelper();

		#endregion

		#region -_ ICountryDal Members _-

		/// <summary>
		/// Get all countries from the database.
		/// </summary>
		/// <returns>A CountryCollection containing all countries.</returns>
		CountryDataCollection ICountryDal.GetCountryData() {
			CountryDataCollection countriesToReturn = new CountryDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateBaseSelect() , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							countriesToReturn.Add( _sqlHelper.CountryFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return countriesToReturn;
		}

		/// <summary>
		/// Get a single country from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the country to retrieve.</param>
		/// <returns>An CountryCollection containing the requested country.</returns>
		CountryDataCollection ICountryDal.GetCountryDataBySysId( int sysId ) {
			return ( (ICountryDal)this ).GetCountryDataBySysIds( new int[] { sysId } );
		}

		/// <summary>
		/// Get multiple countries from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the countries to retrieve.</param>
		/// <returns>An CountryCollection containing the requested countries.</returns>
		CountryDataCollection ICountryDal.GetCountryDataBySysIds( int[] sysIds ) {
			CountryDataCollection countriesToReturn = new CountryDataCollection();
			using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
				conn.Open();
				using( SqlCommand cmd = new SqlCommand( _sqlHelper.CreateSelectBySysIds( sysIds ) , conn ) ) {
					using( SqlDataReader reader = cmd.ExecuteReader() ) {
						while( reader.Read() ) {
							countriesToReturn.Add( _sqlHelper.CountryFromReader( reader ) );
						}
					}
				}
				conn.Close();
			}
			return countriesToReturn;
		}

		/// <summary>
		/// Insert one or more countries to the database.
		/// </summary>
		/// <param name="countries">An CountryCollection containing the countries to insert.</param>
		/// <returns>An CountryCollection containing the inserted countries.</returns>
		CountryDataCollection ICountryDal.InsertCountryData( CountryDataCollection countries ) {
			return Save( countries , true );
		}

		/// <summary>
		/// Update one or more countries in the database.
		/// </summary>
		/// <param name="countries">An CountryCollection containing the countries to update.</param>
		/// <returns>An CountryCollection containing the updated countries.</returns>
		CountryDataCollection ICountryDal.UpdateCountryData( CountryDataCollection countries ) {
			return Save( countries , false );
		}

		/// <summary>
		/// Remove one or more countries from the database.
		/// </summary>
		/// <param name="countries">An CountryCollection containing the countries to remove.</param>
		void ICountryDal.RemoveCountryData( CountryDataCollection countries ) {
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( CountryData country in countries ) {
							SqlCommand cmd = new SqlCommand( _sqlHelper.CreateDeleteCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , country.SysId );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , country.RowVersion );
							DalUtil.CreateLogDeleteParameters( cmd.Parameters , _sqlHelper.DBTableName , country.ToString() , SwmSuiteDalPrincipal.EmployeeId , DateTime.Now );
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
		/// Remove all countries from the database.
		/// </summary>
		void ICountryDal.RemoveAllCountryData() {
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

		private CountryDataCollection Save( CountryDataCollection countries , bool insert ) {
			CountryDataCollection countriesToReturn = new CountryDataCollection();
			using( TransactionScope transactionScope = new TransactionScope( TransactionScopeOption.Required ) ) {
				using( SqlConnection conn = SwmSuiteSqlConnection.CreateConnection() ) {
					conn.Open();
					try {
						foreach( CountryData country in countries ) {
							SqlCommand cmd = new SqlCommand( insert ? _sqlHelper.CreateInsertCommand() : _sqlHelper.CreateUpdateCommand() , conn );
							cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCountry , country.CountryName );
							if( insert ) {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterCreatedOn , DateTime.Now );
							} else {
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedBy , SwmSuiteDalPrincipal.EmployeeId ); 
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterEditedOn , DateTime.Now );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterSysId , country.SysId );
								cmd.Parameters.AddWithValue( _sqlHelper.DBParameterRowVersion , country.RowVersion );
							}
							using( SqlDataReader reader = cmd.ExecuteReader() ) {
								while( reader.Read() ) {
									countriesToReturn.Add( _sqlHelper.CountryFromReader( reader ) );
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
			return countriesToReturn;
		}

		#endregion

	}

}
