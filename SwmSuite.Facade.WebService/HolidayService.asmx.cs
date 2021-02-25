using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.ComponentModel;
using SwmSuite.Proxy.Interface;
using System.Web.Services.Protocols;
using SwmSuite.Business;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Facade.WebService {

	/// <summary>
	/// Summary description for AvatarService
	/// </summary>
	[WebService( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	[WebServiceBinding( ConformsTo = WsiProfiles.BasicProfile1_1 )]
	[ToolboxItem( false )]
	public class HolidayService : System.Web.Services.WebService , IHolidayFacade {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the SOAP header.
		/// </summary>
		/// <value>The SOAP header.</value>
		public SwmSuiteSoapHeader SoapHeader { get; set; }

		#endregion

		/// <summary>
		/// Get overtime entries for one or more employees and year.
		/// </summary>
		/// <param name="employees">The employees to get the overtime entries for.</param>
		/// <param name="year">The year to get the overtime entries for.</param>
		/// <returns>An OvertimeEntryCollection containing the requested overtime entries.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public OvertimeEntryCollection GetOvertimeEntries( EmployeeCollection employees , int year ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new OvertimeEntryBll().GetOvertimeEntries( employees , year );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Create a new overtime entry.
		/// </summary>
		/// <param name="overtimeEntry">The new overtime entry to create.</param>
		/// <returns>The created overtime entry.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public OvertimeEntry CreateOvertimeEntry( OvertimeEntry overtimeEntry ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new OvertimeEntryBll().CreateOvertimeEntry( overtimeEntry );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Update an existing overtime entry.
		/// </summary>
		/// <param name="overtimeEntry">The existing overtime entry to update.</param>
		/// <returns>The updated overtime entry.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public OvertimeEntry UpdateOvertimeEntry( OvertimeEntry overtimeEntry ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new OvertimeEntryBll().UpdateOvertimeEntry( overtimeEntry );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Accept the specified overtime entry.
		/// </summary>
		/// <param name="overtimeEntry">The overtime entry to accept.</param>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public void AcceptOvertimeEntry( OvertimeEntry overtimeEntry ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				new OvertimeEntryBll().AcceptOvertimeEntry( overtimeEntry );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Deny the specified overtime entry.
		/// </summary>
		/// <param name="overtimeEntry">The overtime entry to deny.</param>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public void DenyOvertimeEntry( OvertimeEntry overtimeEntry ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				new OvertimeEntryBll().DenyOvertimeEntry( overtimeEntry );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

	}

}