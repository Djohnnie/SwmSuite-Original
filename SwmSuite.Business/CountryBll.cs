using System;
using System.Collections.Generic;
using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Business {

	public class CountryBll {

		#region -_ Private Members _-

		private ICountryDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateCountryDal();

		#endregion

		#region -_ Business Methods _-

		/// <summary>
		/// Get all countries from the database.
		/// </summary>
		/// <returns></returns>
		public CountryCollection GetCountries(){
			CountryCollection countriesToReturn = new CountryCollection();
			CountryDataCollection countryData = this.GetCountryData();
			foreach( CountryData country in countryData ) {
				Country newCountry = new Country( country.CountryName );
				newCountry.SysId = country.SysId;
				newCountry.RowVersion = country.RowVersion;
				newCountry.ZipCodes = new ZipCodeBll().GetZipCodesByCountry( newCountry );
				countriesToReturn.Add( newCountry );
			}
			return countriesToReturn;
		}

		/// <summary>
		/// Get a specif country from the database.
		/// </summary>
		/// <returns></returns>
		public Country GetCountry( int sysId ) {
			Country countryToReturn = new Country();
			CountryDataCollection countryData = this.GetCountryDataBySysId( sysId );
			if( countryData.Count == 1 ) {
				countryToReturn.SysId = countryData[0].SysId;
				countryToReturn.RowVersion = countryData[0].RowVersion;
				countryToReturn.Name = countryData[0].CountryName;
				countryToReturn.ZipCodes = new ZipCodeBll().GetZipCodesByCountry( countryToReturn );
			}
			return countryToReturn;
		}

		/// <summary>
		/// Add a new country to the database.
		/// </summary>
		/// <param name="country">The country to add.</param>
		public Country CreateCountry( Country country ) {
			CountryData countryToInsert = new CountryData( country.Name );
			CountryDataCollection countriesReturned =
				this.InsertCountryData( CountryDataCollection.FromSingleCountry( countryToInsert ) );
			Country countryToReturn = new Country();
			countryToReturn.SysId = countriesReturned[0].SysId;
			countryToReturn.RowVersion = countriesReturned[0].RowVersion;
			countryToReturn.Name = countriesReturned[0].CountryName;
			return countryToReturn;
		}

		/// <summary>
		/// Update an existing country in the database.
		/// </summary>
		/// <param name="country">The country to update.</param>
		public Country UpdateCountry( Country country ) {
			CountryData countryToUpdate = new CountryData( country.Name );
			countryToUpdate.SysId = country.SysId;
			countryToUpdate.RowVersion = country.RowVersion;
			CountryDataCollection countriesReturned =
				this.UpdateCountryData( CountryDataCollection.FromSingleCountry( countryToUpdate ) );
			Country countryToReturn = new Country();
			countryToReturn.SysId = countriesReturned[0].SysId;
			countryToReturn.RowVersion = countriesReturned[0].RowVersion;
			countryToReturn.Name = countriesReturned[0].CountryName;
			return countryToReturn;
		}

		/// <summary>
		/// Remove one or more countries from the database.
		/// </summary>
		/// <param name="countries">The countries to remove.</param>
		public void RemoveCountries( CountryCollection countries ) {
			CountryDataCollection countriesToRemove = new CountryDataCollection();
			foreach( Country country in countries ) {
				countriesToRemove.Add( new CountryData() { SysId = country.SysId , RowVersion = country.RowVersion , CountryName = country.Name } );
			}
			this.RemoveCountryData( countriesToRemove );
		}

		#endregion

		#region -_ CRUD Methods _-

		/// <summary>
		/// Get all countries from the database.
		/// </summary>
		/// <returns>An CountryCollection containing all countries.</returns>
		public CountryDataCollection GetCountryData() {
			return dal.GetCountryData();
		}

		/// <summary>
		/// Get a single country from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the country to retrieve.</param>
		/// <returns>An CountryCollection containing the requested country.</returns>
		public CountryDataCollection GetCountryDataBySysId( int sysId ) {
			return dal.GetCountryDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple countries from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the countries to retrieve.</param>
		/// <returns>An CountryCollection containing the requested countries.</returns>
		public CountryDataCollection GetCountryDataBySysIds( int[] sysIds ) {
			return dal.GetCountryDataBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more countries to the database.
		/// </summary>
		/// <param name="countries">An CountryCollection containing the countries to insert.</param>
		/// <returns>An CountryCollection containing the inserted countries.</returns>
		public CountryDataCollection InsertCountryData( CountryDataCollection countries ) {
			return dal.InsertCountryData( countries );
		}

		/// <summary>
		/// Update one or more countries in the database.
		/// </summary>
		/// <param name="countries">An CountryCollection containing the countries to update.</param>
		/// <returns>An CountryCollection containing the updated countries.</returns>
		public CountryDataCollection UpdateCountryData( CountryDataCollection countries ) {
			return dal.UpdateCountryData( countries );
		}

		/// <summary>
		/// Remove one or more countries from the database.
		/// </summary>
		/// <param name="countries">An CountryCollection containing the countries to remove.</param>
		public void RemoveCountryData( CountryDataCollection countries ) {
			dal.RemoveCountryData( countries );
		}

		/// <summary>
		/// Remove all countries from the database.
		/// </summary>
		public void RemoveAllCountryData() {
			dal.RemoveAllCountryData();
		}

		#endregion

	}


}
