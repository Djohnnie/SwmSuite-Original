using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Utils;
using System.Web.Services.Protocols;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Proxy.WebService {

	public sealed class ZipCodeFacade :
		ServiceFacade<ZipCodeService.ZipCodeService , ZipCodeService.SwmSuiteSoapHeader> ,
		IZipCodeFacade {

		/// <summary>
		/// Get all zipcodes from the database.
		/// </summary>
		/// <returns></returns>
		ZipCodeCollection IZipCodeFacade.GetZipCodes() {
			try {
				ZipCodeCollection zipcodes = new ZipCodeCollection();
				foreach( ZipCodeService.ZipCode zipcode in GetService().GetZipCodes() ) {
					zipcodes.Add( (ZipCode)XmlSerialization.ConvertObject( zipcode , typeof( ZipCodeService.ZipCode ) , typeof( ZipCode ) ) );
				}
				return zipcodes;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get all zipcodes from the database.
		/// </summary>
		/// <returns></returns>
		ZipCodeCollection IZipCodeFacade.GetZipCodesByCountry( Country country ) {
			try {
				ZipCodeCollection zipcodes = new ZipCodeCollection();
				ZipCodeService.Country countryParameter =
					(ZipCodeService.Country)XmlSerialization.ConvertObject( country , typeof( Country ) , typeof( ZipCodeService.Country ) );
				foreach( ZipCodeService.ZipCode zipcode in GetService().GetZipCodesByCountry( countryParameter ) ) {
					zipcodes.Add( (ZipCode)XmlSerialization.ConvertObject( zipcode , typeof( ZipCodeService.ZipCode ) , typeof( ZipCode ) ) );
				}
				return zipcodes;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get a specific zipcode from the database.
		/// </summary>
		/// <returns></returns>
		ZipCode IZipCodeFacade.GetZipCode( int sysId ) {
			try {
				ZipCodeService.ZipCode zipcode = GetService().GetZipCode( sysId );
				return (ZipCode)XmlSerialization.ConvertObject( zipcode , typeof( ZipCodeService.ZipCode ) , typeof( ZipCode ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Add a new zipcode to the database.
		/// </summary>
		/// <param name="zipcode">The zipcode to add.</param>
		/// <returns>The zipcode created.</returns>
		ZipCode IZipCodeFacade.CreateZipCode( ZipCode zipcode , Country country ) {
			try {
				ZipCodeService.ZipCode zipcodeParameter =
				(ZipCodeService.ZipCode)XmlSerialization.ConvertObject( zipcode , typeof( ZipCode ) , typeof( ZipCodeService.ZipCode ) );
				ZipCodeService.Country countryParameter =
					(ZipCodeService.Country)XmlSerialization.ConvertObject( country , typeof( Country ) , typeof( ZipCodeService.Country ) );
				ZipCodeService.ZipCode zipcodeToReturn =
					GetService().CreateZipCode( zipcodeParameter , countryParameter );
				return (ZipCode)XmlSerialization.ConvertObject( zipcodeToReturn , typeof( ZipCodeService.ZipCode ) , typeof( ZipCode ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Update an existing zipcode in the database.
		/// </summary>
		/// <param name="zipcode">The zipcode to update.</param>
		/// <returns>The zipcode updated.</returns>
		ZipCode IZipCodeFacade.UpdateZipCode( ZipCode zipcode , Country country ) {
			try {
				ZipCodeService.ZipCode zipcodeParameter =
				(ZipCodeService.ZipCode)XmlSerialization.ConvertObject( zipcode , typeof( ZipCode ) , typeof( ZipCodeService.ZipCode ) );
				ZipCodeService.Country countryParameter =
					(ZipCodeService.Country)XmlSerialization.ConvertObject( country , typeof( Country ) , typeof( ZipCodeService.Country ) );
				ZipCodeService.ZipCode zipcodeToReturn =
					GetService().UpdateZipCode( zipcodeParameter , countryParameter );
				return (ZipCode)XmlSerialization.ConvertObject( zipcodeToReturn , typeof( ZipCodeService.ZipCode ) , typeof( ZipCode ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Remove one or more zipcodes from the database.
		/// </summary>
		/// <param name="zipcodes">The zipcodes to remove.</param>
		void IZipCodeFacade.RemoveZipCodes( ZipCodeCollection zipcodes ) {
			try {
				ZipCodeService.ZipCode[] zipcodesParameter = new ZipCodeService.ZipCode[zipcodes.Count];
				foreach( ZipCode zipcode in zipcodes ) {
					zipcodesParameter[zipcodes.IndexOf( zipcode )] =
						(ZipCodeService.ZipCode)XmlSerialization.ConvertObject( zipcode , typeof( ZipCode ) , typeof( ZipCodeService.ZipCode ) );
				}
				GetService().RemoveZipCodes( zipcodesParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

	}

}
