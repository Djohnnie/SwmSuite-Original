using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business;

namespace SwmSuite.Proxy.Inproc {
	
	public sealed class CountryFacade : ICountryFacade {

		/// <summary>
		/// Get all countries from the database.
		/// </summary>
		/// <returns></returns>
		CountryCollection ICountryFacade.GetCountries() {
			return new CountryBll().GetCountries();
		}

		/// <summary>
		/// Get a specif country from the database.
		/// </summary>
		/// <returns></returns>
		Country ICountryFacade.GetCountry( int sysId ) {
			return new CountryBll().GetCountry( sysId );
		}

		/// <summary>
		/// Add a new country to the database.
		/// </summary>
		/// <param name="country">The country to add.</param>
		/// <returns>The created data.</returns>
		Country ICountryFacade.CreateCountry( Country country ) {
			return new CountryBll().CreateCountry( country );
		}

		/// <summary>
		/// Update an existing country in the database.
		/// </summary>
		/// <param name="country">The country to update.</param>
		/// <returns>The updated country.</returns>
		Country ICountryFacade.UpdateCountry( Country country ) {
			return new CountryBll().UpdateCountry( country );
		}

		/// <summary>
		/// Remove one or more countries from the database.
		/// </summary>
		/// <param name="countries">The countries to remove.</param>
		void ICountryFacade.RemoveCountries( CountryCollection countries ) {
			new CountryBll().RemoveCountries( countries );
		}

	}
}
