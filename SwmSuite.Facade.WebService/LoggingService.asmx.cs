using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business;
using System.ComponentModel;
using SwmSuite.Proxy.Interface;
using System.Web.Services.Protocols;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Facade.WebService {

	/// <summary>
	/// Summary description for AgendaService
	/// </summary>
	[WebService( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	[WebServiceBinding( ConformsTo = WsiProfiles.BasicProfile1_1 )]
	[ToolboxItem( false )]
	public class LoggingService : System.Web.Services.WebService , ILoggingFacade {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the SOAP header.
		/// </summary>
		/// <value>The SOAP header.</value>
		public SwmSuiteSoapHeader SoapHeader { get; set; }

		#endregion

		/// <summary>
		/// Get all connectionlogs from the database.
		/// </summary>
		/// <returns>A ConnectionLogCollection containing all connection logs.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public ConnectionLogCollection GetConnectionLogs() {
			try {
				//WebServerAuthentication.Authenticate( this.SoapHeader );
				return new ConnectionLogBll().GetConnectionLogs();
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get all connection logs from the database for a specific year and month.
		/// </summary>
		/// <param name="year">The year to get the connection logs for.</param>
		/// <param name="month">The month to get the connection logs for.</param>
		/// <returns>A ConnectionLogCollection containing all requested connection logs.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public ConnectionLogCollection GetConnectionLogsByMonth( int year , int month ) {
			try {
				//WebServerAuthentication.Authenticate( this.SoapHeader );
				return new ConnectionLogBll().GetConnectionLogsByMonth( year , month );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Log the given connectionlog to the database.
		/// </summary>
		/// <param name="connectionLog">The connection log to log.</param>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public void LogConnection( ConnectionLog connectionLog ) {
			try {
				//WebServerAuthentication.Authenticate( this.SoapHeader );
				new ConnectionLogBll().LogConnection( connectionLog );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get all login logs from the database.
		/// </summary>
		/// <returns>A LoginLogCollection containing all login logs.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public LoginLogCollection GetLoginLogs() {
			try {
				//WebServerAuthentication.Authenticate( this.SoapHeader );
				return new LoginLogBll().GetLoginLogs();
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get all loginlogs from the database for a specific year and month.
		/// </summary>
		/// <param name="year">The year to get the loginlogs for.</param>
		/// <param name="month">The month to get the loginlogs for.</param>
		/// <returns>A LoginLogCollection containing all requested login logs.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public LoginLogCollection GetLoginLogsByMonth( int year , int month ) {
			try {
				//WebServerAuthentication.Authenticate( this.SoapHeader );
				return new LoginLogBll().GetLoginLogsByMonth( year , month );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Log the given login log to the database.
		/// </summary>
		/// <param name="loginLog">The login log to log.</param>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public void LogLogin( LoginLog loginLog ) {
			try {
				//WebServerAuthentication.Authenticate( this.SoapHeader );
				new LoginLogBll().LogLogin( loginLog );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

	}
}
