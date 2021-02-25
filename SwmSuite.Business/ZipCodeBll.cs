using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Business {

	public class ZipCodeBll {

		#region -_ Private Members _-

		private IZipCodeDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateZipCodeDal();

		#endregion

		#region -_ Business Methods _-

		/// <summary>
		/// Get all zipcodes from the database.
		/// </summary>
		/// <returns></returns>
		public ZipCodeCollection GetZipCodes() {
			ZipCodeCollection zipcodesToReturn = new ZipCodeCollection();
			ZipCodeDataCollection zipcodeData = this.GetZipCodeData();
			foreach( ZipCodeData zipcode in zipcodeData ) {
				ZipCode newZipCode = new ZipCode( zipcode.Code , zipcode.City );
				newZipCode.SysId = zipcode.SysId;
				newZipCode.RowVersion = zipcode.RowVersion;
				
				zipcodesToReturn.Add( newZipCode );
			}
			return zipcodesToReturn;
		}

		/// <summary>
		/// Get all zipcodes from the database.
		/// </summary>
		/// <returns></returns>
		public ZipCodeCollection GetZipCodesByCountry( Country country ) {
			ZipCodeCollection zipcodesToReturn = new ZipCodeCollection();
			ZipCodeDataCollection zipcodeData = this.GetZipCodeDataByCountry( country.SysId );
			foreach( ZipCodeData zipcode in zipcodeData ) {
				ZipCode newZipCode = new ZipCode( zipcode.Code , zipcode.City );
				newZipCode.SysId = zipcode.SysId;
				newZipCode.RowVersion = zipcode.RowVersion;

				zipcodesToReturn.Add( newZipCode );
			}
			return zipcodesToReturn;
		}

		/// <summary>
		/// Get a specific zipcode from the database.
		/// </summary>
		/// <returns></returns>
		public ZipCode GetZipCode( int sysId ) {
			ZipCode zipcodeToReturn = new ZipCode();
			ZipCodeDataCollection zipcodeData = this.GetZipCodeDataBySysId( sysId );
			if( zipcodeData.Count == 1 ) {
				zipcodeToReturn.SysId = zipcodeData[0].SysId;
				zipcodeToReturn.RowVersion = zipcodeData[0].RowVersion;
				zipcodeToReturn.Code = zipcodeData[0].Code;
				zipcodeToReturn.City = zipcodeData[0].City;
			}
			return zipcodeToReturn;
		}

		/// <summary>
		/// Add a new zipcode to the database.
		/// </summary>
		/// <param name="zipcode">The zipcode to add.</param>
		public ZipCode CreateZipCode( ZipCode zipcode , Country country ) {
			ZipCodeData zipcodeToInsert = new ZipCodeData( zipcode.Code , zipcode.City , country.SysId );
			ZipCodeDataCollection zipcodeResult =
				this.InsertZipCodeData( ZipCodeDataCollection.FromSingleZipCode( zipcodeToInsert ) );
			ZipCode zipcodeToReturn = new ZipCode();
			zipcodeToReturn.SysId = zipcodeResult[0].SysId;
			zipcodeToReturn.RowVersion = zipcodeResult[0].RowVersion;
			zipcodeToReturn.Code = zipcodeResult[0].Code;
			zipcodeToReturn.City = zipcodeResult[0].City;
			zipcodeToReturn.Country = new CountryBll().GetCountry( zipcodeResult[0].CountrySysId ).Name;
			return zipcodeToReturn;
		}

		/// <summary>
		/// Update an existing zipcode in the database.
		/// </summary>
		/// <param name="zipcode">The zipcode to update.</param>
		public ZipCode UpdateZipCode( ZipCode zipcode , Country country ) {
			ZipCodeData zipcodeToUpdate = new ZipCodeData( zipcode.Code , zipcode.City , country.SysId );
			zipcodeToUpdate.SysId = zipcode.SysId;
			zipcodeToUpdate.RowVersion = zipcode.RowVersion;
			ZipCodeDataCollection zipcodeResult =
				this.UpdateZipCodeData( ZipCodeDataCollection.FromSingleZipCode( zipcodeToUpdate ) );
			ZipCode zipcodeToReturn = new ZipCode();
			zipcodeToReturn.SysId = zipcodeResult[0].SysId;
			zipcodeToReturn.RowVersion = zipcodeResult[0].RowVersion;
			zipcodeToReturn.Code = zipcodeResult[0].Code;
			zipcodeToReturn.City = zipcodeResult[0].City;
			zipcodeToReturn.Country = new CountryBll().GetCountry( zipcodeResult[0].CountrySysId ).Name;
			return zipcodeToReturn;
		}

		/// <summary>
		/// Remove one or more zipcodes from the database.
		/// </summary>
		/// <param name="zipcodes">The zipcodes to remove.</param>
		public void RemoveZipCodes( ZipCodeCollection zipcodes ) {
			ZipCodeDataCollection zipcodesToRemove = new ZipCodeDataCollection();
			foreach( ZipCode zipcode in zipcodes ) {
				zipcodesToRemove.Add( new ZipCodeData() { SysId = zipcode.SysId , RowVersion = zipcode.RowVersion } );
			}
			this.RemoveZipCodeData( zipcodesToRemove );
		}

		#endregion

		#region -_ CRUD Methods _-

		/// <summary>
		/// Get all zipcodes from the database.
		/// </summary>
		/// <returns>An ZipCodeCollection containing all zipcodes.</returns>
		public ZipCodeDataCollection GetZipCodeData() {
			return dal.GetZipCodeData();
		}

		/// <summary>
		/// Get all zipcodes from the database for a specific country.
		/// </summary>
		/// <param name="countrySysId">The internal id for the country to get the zipcodes for.</param>
		/// <returns>A ZipCodeCollection containing all requested zipcodes.</returns>
		public ZipCodeDataCollection GetZipCodeDataByCountry( int countrySysId ) {
			return dal.GetZipCodeDataByCountry( countrySysId );
		}

		/// <summary>
		/// Get a single zipcode from the database.
		/// </summary>
		/// <param name="sysId">The internal id of the zipcode to retrieve.</param>
		/// <returns>An ZipCodeCollection containing the requested zipcode.</returns>
		public ZipCodeDataCollection GetZipCodeDataBySysId( int sysId ) {
			return dal.GetZipCodeDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple zipcodes from the database.
		/// </summary>
		/// <param name="sysIds">The internal ids of the zipcodes to retrieve.</param>
		/// <returns>An ZipCodeCollection containing the requested zipcodes.</returns>
		public ZipCodeDataCollection GetZipCodeDataBySysIds( int[] sysIds ) {
			return dal.GetZipCodesDataBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more zipcodes to the database.
		/// </summary>
		/// <param name="zipcodes">An ZipCodeCollection containing the zipcodes to insert.</param>
		/// <returns>An ZipCodeCollection containing the inserted zipcodes.</returns>
		public ZipCodeDataCollection InsertZipCodeData( ZipCodeDataCollection zipcodes ) {
			return dal.InsertZipCodeData( zipcodes );
		}

		/// <summary>
		/// Update one or more zipcodes in the database.
		/// </summary>
		/// <param name="zipcodes">An ZipCodeCollection containing the zipcodes to update.</param>
		/// <returns>An ZipCodeCollection containing the updated zipcodes.</returns>
		public ZipCodeDataCollection UpdateZipCodeData( ZipCodeDataCollection zipcodes ) {
			return dal.UpdateZipCodeData( zipcodes );
		}

		/// <summary>
		/// Remove one or more zipcodes from the database.
		/// </summary>
		/// <param name="zipcodes">An ZipCodeCollection containing the zipcodes to remove.</param>
		public void RemoveZipCodeData( ZipCodeDataCollection zipcodes ) {
			dal.RemoveZipCodeData( zipcodes );
		}

		/// <summary>
		/// Remove all zipcodes from the database.
		/// </summary>
		public void RemoveAllZipCodeData() {
			dal.RemoveAllZipCodeData();
		}

		#endregion

	}


}