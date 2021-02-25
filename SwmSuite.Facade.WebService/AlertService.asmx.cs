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
	/// Summary description for AlertService
	/// </summary>
	[WebService( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	[WebServiceBinding( ConformsTo = WsiProfiles.BasicProfile1_1 )]
	[ToolboxItem( false )]
	public class AlertService : System.Web.Services.WebService , IAlertFacade {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the SOAP header.
		/// </summary>
		/// <value>The SOAP header.</value>
		public SwmSuiteSoapHeader SoapHeader { get; set; }

		#endregion

		/// <summary>
		/// Get all alerts from the database.
		/// </summary>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public AlertCollection GetAlerts() {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new AlertBll().GetAlerts();
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get all global alerts from the database.
		/// </summary>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public AlertCollection GetGlobalAlerts() {
			try {
				//WebServerAuthentication.Authenticate( this.SoapHeader );
				return new AlertBll().GetGlobalAlerts();
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get all alerts from the database for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the alerts for.</param>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public AlertCollection GetAlertsForEmployee( Employee employee ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new AlertBll().GetAlerts( employee );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get all alerts from the database for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to get the alerts for.</param>
		/// <returns>An AlertCollection containing all requested alerts.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public AlertCollection GetAlertsForEmployeeGroup( EmployeeGroup employeeGroup ) {
			try {
				//WebServerAuthentication.Authenticate( this.SoapHeader );
				return new AlertBll().GetAlerts( employeeGroup );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Create a new alert.
		/// </summary>
		/// <param name="alert">Alert object that needs to be created.</param>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public void CreateAlert( Alert alert ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				new AlertBll().CreateAlert( alert );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Update an existing alert.
		/// </summary>
		/// <param name="alert">Alert object that needs to be updated.</param>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public void UpdateAlert( Alert alert ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				new AlertBll().UpdateAlert( alert );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Remove one or more existing alerts.
		/// </summary>
		/// <param name="alerts">Alert objects that need to be removed.</param>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public void RemoveAlerts( AlertCollection alerts ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				new AlertBll().RemoveAlerts( alerts );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

	}
}
