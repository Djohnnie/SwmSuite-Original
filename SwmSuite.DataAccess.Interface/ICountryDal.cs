using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {

	/// <summary>
	/// DAL Interface for the CountryService methods.
	/// </summary>
	public interface ICountryDal {

		/// <summary>
		/// Get all countries from the database.
		/// </summary>
		/// <returns>A CountryCollection containing all countries.</returns>
		CountryDataCollection GetCountryData();

		/// <summary>
		/// Get a single country from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the country to retrieve.</param>
		/// <returns>An CountryCollection containing the requested country.</returns>
		CountryDataCollection GetCountryDataBySysId( int sysId );

		/// <summary>
		/// Get multiple countries from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the countries to retrieve.</param>
		/// <returns>An CountryCollection containing the requested countries.</returns>
		CountryDataCollection GetCountryDataBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more countries to the database.
		/// </summary>
		/// <param name="countries">An CountryCollection containing the countries to insert.</param>
		/// <returns>An CountryCollection containing the inserted countries.</returns>
		CountryDataCollection InsertCountryData( CountryDataCollection countries );

		/// <summary>
		/// Update one or more countries in the database.
		/// </summary>
		/// <param name="countries">An CountryCollection containing the countries to update.</param>
		/// <returns>An CountryCollection containing the updated countries.</returns>
		CountryDataCollection UpdateCountryData( CountryDataCollection countries );

		/// <summary>
		/// Remove one or more countries from the database.
		/// </summary>
		/// <param name="countries">An CountryCollection containing the countries to remove.</param>
		void RemoveCountryData( CountryDataCollection countries );

		/// <summary>
		/// Remove all countries from the database.
		/// </summary>
		void RemoveAllCountryData();

	}


}
