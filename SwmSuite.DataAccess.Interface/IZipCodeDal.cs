using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {

	/// <summary>
	/// DAL Interface for the ZipCodeService methods.
	/// </summary>
	public interface IZipCodeDal {

		/// <summary>
		/// Get all zipcodes from the database.
		/// </summary>
		/// <returns>A ZipCodeCollection containing all zipcodes.</returns>
		ZipCodeDataCollection GetZipCodeData();

		/// <summary>
		/// Get all zipcodes from the database for a specific country.
		/// </summary>
		/// <param name="countrySysId">The internal id for the country to get the zipcodes for.</param>
		/// <returns>A ZipCodeCollection containing all requested zipcodes.</returns>
		ZipCodeDataCollection GetZipCodeDataByCountry( int countrySysId );

		/// <summary>
		/// Get a single zipcode from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the zipcode to retrieve.</param>
		/// <returns>An ZipCodeCollection containing the requested zipcode.</returns>
		ZipCodeDataCollection GetZipCodeDataBySysId( int sysId );

		/// <summary>
		/// Get multiple zipcodes from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the zipcodes to retrieve.</param>
		/// <returns>An ZipCodeCollection containing the requested zipcodes.</returns>
		ZipCodeDataCollection GetZipCodesDataBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more zipcodes to the database.
		/// </summary>
		/// <param name="zipcodes">An ZipCodeCollection containing the zipcodes to insert.</param>
		/// <returns>An ZipCodeCollection containing the inserted zipcodes.</returns>
		ZipCodeDataCollection InsertZipCodeData( ZipCodeDataCollection zipcodes );

		/// <summary>
		/// Update one or more zipcodes in the database.
		/// </summary>
		/// <param name="zipcodes">An ZipCodeCollection containing the zipcodes to update.</param>
		/// <returns>An ZipCodeCollection containing the updated zipcodes.</returns>
		ZipCodeDataCollection UpdateZipCodeData( ZipCodeDataCollection zipcodes );

		/// <summary>
		/// Remove one or more zipcodes from the database.
		/// </summary>
		/// <param name="zipcodes">An ZipCodeCollection containing the zipcodes to remove.</param>
		void RemoveZipCodeData( ZipCodeDataCollection zipcodes );

		/// <summary>
		/// Remove all zipcodes from the database.
		/// </summary>
		void RemoveAllZipCodeData();

	}

}
