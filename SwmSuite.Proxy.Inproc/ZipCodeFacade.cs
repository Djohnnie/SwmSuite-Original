using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business;

namespace SwmSuite.Proxy.Inproc {
	
	public sealed class ZipCodeFacade : IZipCodeFacade {

		/// <summary>
		/// Get all zipcodes from the database.
		/// </summary>
		/// <returns></returns>
		ZipCodeCollection IZipCodeFacade.GetZipCodes() {
			return new ZipCodeBll().GetZipCodes();
		}

		/// <summary>
		/// Get all zipcodes from the database.
		/// </summary>
		/// <returns></returns>
		ZipCodeCollection IZipCodeFacade.GetZipCodesByCountry( Country country ) {
			return new ZipCodeBll().GetZipCodesByCountry( country );
		}

		/// <summary>
		/// Get a specific zipcode from the database.
		/// </summary>
		/// <returns></returns>
		ZipCode IZipCodeFacade.GetZipCode( int sysId ) {
			return new ZipCodeBll().GetZipCode( sysId );
		}

		/// <summary>
		/// Add a new zipcode to the database.
		/// </summary>
		/// <param name="zipcode">The zipcode to add.</param>
		/// <returns>The zipcode created.</returns>
		ZipCode IZipCodeFacade.CreateZipCode( ZipCode zipcode , Country country ) {
			return new ZipCodeBll().CreateZipCode( zipcode , country );
		}

		/// <summary>
		/// Update an existing zipcode in the database.
		/// </summary>
		/// <param name="zipcode">The zipcode to update.</param>
		/// <returns>The zipcode updated.</returns>
		ZipCode IZipCodeFacade.UpdateZipCode( ZipCode zipcode , Country country ) {
			return new ZipCodeBll().UpdateZipCode( zipcode , country );
		}

		/// <summary>
		/// Remove one or more zipcodes from the database.
		/// </summary>
		/// <param name="zipcodes">The zipcodes to remove.</param>
		void IZipCodeFacade.RemoveZipCodes( ZipCodeCollection zipcodes ) {
			new ZipCodeBll().RemoveZipCodes( zipcodes );
		}

	}

}
