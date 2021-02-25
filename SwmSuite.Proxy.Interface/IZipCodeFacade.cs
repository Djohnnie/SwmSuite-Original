using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Proxy.Interface {
	
	public interface IZipCodeFacade {

		/// <summary>
		/// Get all zipcodes from the database.
		/// </summary>
		/// <returns></returns>
		ZipCodeCollection GetZipCodes();

		/// <summary>
		/// Get all zipcodes from the database.
		/// </summary>
		/// <returns></returns>
		ZipCodeCollection GetZipCodesByCountry( Country country );

		/// <summary>
		/// Get a specific zipcode from the database.
		/// </summary>
		/// <returns></returns>
		ZipCode GetZipCode( int sysId );

		/// <summary>
		/// Add a new zipcode to the database.
		/// </summary>
		/// <param name="zipcode">The zipcode to add.</param>
		/// <returns>the zipcode created.</returns>
		ZipCode CreateZipCode( ZipCode zipcode , Country country );

		/// <summary>
		/// Update an existing zipcode in the database.
		/// </summary>
		/// <param name="zipcode">The zipcode to update.</param>
		/// <returns>The zipcode updated.</returns>
		ZipCode UpdateZipCode( ZipCode zipcode , Country country );

		/// <summary>
		/// Remove one or more zipcodes from the database.
		/// </summary>
		/// <param name="zipcodes">The zipcodes to remove.</param>
		void RemoveZipCodes( ZipCodeCollection zipcodes );

	}

}
