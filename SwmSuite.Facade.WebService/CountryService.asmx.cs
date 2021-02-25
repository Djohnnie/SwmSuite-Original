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
	/// Summary description for CountryService
	/// </summary>
	[WebService( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	[WebServiceBinding( ConformsTo = WsiProfiles.BasicProfile1_1 )]
	[ToolboxItem( false )]
	public class CountryService : System.Web.Services.WebService , ICountryFacade {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the SOAP header.
		/// </summary>
		/// <value>The SOAP header.</value>
		public SwmSuiteSoapHeader SoapHeader { get; set; }

		#endregion

		/// <summary>
		/// Get all countries from the database.
		/// </summary>
		/// <returns></returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public CountryCollection GetCountries() {
			try {
				//WebServerAuthentication.Authenticate( this.SoapHeader );
				return new CountryBll().GetCountries();
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get a specif country from the database.
		/// </summary>
		/// <returns></returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public Country GetCountry( int sysId ) {
			try {
				//WebServerAuthentication.Authenticate( this.SoapHeader );
				return new CountryBll().GetCountry( sysId );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Add a new country to the database.
		/// </summary>
		/// <param name="country">The country to add.</param>
		/// <returns>The country created.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public Country CreateCountry( Country country ) {
			try {
				//WebServerAuthentication.Authenticate( this.SoapHeader );
				return new CountryBll().CreateCountry( country );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Update an existing country in the database.
		/// </summary>
		/// <param name="country">The country to update.</param>
		/// <returns>The country updated.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public Country UpdateCountry( Country country ) {
			try {
				//WebServerAuthentication.Authenticate( this.SoapHeader );
				return new CountryBll().UpdateCountry( country );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Remove one or more countries from the database.
		/// </summary>
		/// <param name="countries">The countries to remove.</param>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public void RemoveCountries( CountryCollection countries ) {
			try {
				//WebServerAuthentication.Authenticate( this.SoapHeader );
				new CountryBll().RemoveCountries( countries );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}
	}
}
