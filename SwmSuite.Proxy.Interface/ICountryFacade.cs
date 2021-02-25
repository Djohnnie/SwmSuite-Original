using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Proxy.Interface {
	
	public interface ICountryFacade {

		/// <summary>
		/// Get all countries from the database.
		/// </summary>
		/// <returns></returns>
		CountryCollection GetCountries();

		/// <summary>
		/// Get a specif country from the database.
		/// </summary>
		/// <returns></returns>
		Country GetCountry( int sysId );

		/// <summary>
		/// Add a new country to the database.
		/// </summary>
		/// <param name="country">The country to add.</param>
		/// <returns>The created country.</returns>
		Country CreateCountry( Country country );

		/// <summary>
		/// Update an existing country in the database.
		/// </summary>
		/// <param name="country">The country to update.</param>
		/// <returns>The updated country.</returns>
		Country UpdateCountry( Country country );

		/// <summary>
		/// Remove one or more countries from the database.
		/// </summary>
		/// <param name="countries">The countries to remove.</param>
		void RemoveCountries( CountryCollection countries );

	}

}
