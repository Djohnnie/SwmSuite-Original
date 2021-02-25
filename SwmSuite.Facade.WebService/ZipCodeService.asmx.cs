using System;
using System.Collections;
using System.ComponentModel;
using System.Data;

using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Facade.WebService {
	/// <summary>
	/// Summary description for ZipCodeService
	/// </summary>
	[WebService( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	[WebServiceBinding( ConformsTo = WsiProfiles.BasicProfile1_1 )]
	[ToolboxItem( false )]
	public class ZipCodeService : System.Web.Services.WebService , IZipCodeFacade {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the SOAP header.
		/// </summary>
		/// <value>The SOAP header.</value>
		public SwmSuiteSoapHeader SoapHeader { get; set; }

		#endregion

		/// <summary>
		/// Get all zipcodes from the database.
		/// </summary>
		/// <returns></returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public ZipCodeCollection GetZipCodes() {
			try {
				//WebServerAuthentication.Authenticate( this.SoapHeader );
				return new ZipCodeBll().GetZipCodes();
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get all zipcodes from the database.
		/// </summary>
		/// <returns></returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public ZipCodeCollection GetZipCodesByCountry( Country country ) {
			try {
				//WebServerAuthentication.Authenticate( this.SoapHeader );
				return new ZipCodeBll().GetZipCodesByCountry( country );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get a specific zipcode from the database.
		/// </summary>
		/// <returns></returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public ZipCode GetZipCode( int sysId ) {
			try {
				//WebServerAuthentication.Authenticate( this.SoapHeader );
				return new ZipCodeBll().GetZipCode( sysId );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Add a new zipcode to the database.
		/// </summary>
		/// <param name="zipcode">The zipcode to add.</param>
		/// <returns>The zipcode created.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public ZipCode CreateZipCode( ZipCode zipcode , Country country ) {
			try {
				//WebServerAuthentication.Authenticate( this.SoapHeader );
				return new ZipCodeBll().CreateZipCode( zipcode , country );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Update an existing zipcode in the database.
		/// </summary>
		/// <param name="zipcode">The zipcode to update.</param>
		/// <returns>The zipcode updated.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public ZipCode UpdateZipCode( ZipCode zipcode , Country country ) {
			try {
				//WebServerAuthentication.Authenticate( this.SoapHeader );
				return new ZipCodeBll().UpdateZipCode( zipcode , country );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Remove one or more zipcodes from the database.
		/// </summary>
		/// <param name="zipcodes">The zipcodes to remove.</param>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public void RemoveZipCodes( ZipCodeCollection zipcodes ) {
			try {
				//WebServerAuthentication.Authenticate( this.SoapHeader );
				new ZipCodeBll().RemoveZipCodes( zipcodes );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

	}
}
