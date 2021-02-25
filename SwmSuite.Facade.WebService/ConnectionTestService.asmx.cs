using System;
using System.Collections;
using System.ComponentModel;
using System.Data;

using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using SwmSuite.Proxy.Interface;
using SwmSuite.Business;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Facade.WebService {
	/// <summary>
	/// Summary description for ConnectionTestService
	/// </summary>
	[WebService( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	[WebServiceBinding( ConformsTo = WsiProfiles.BasicProfile1_1 )]
	[ToolboxItem( false )]
	public sealed class ConnectionTestService : System.Web.Services.WebService , IConnectionTestFacade {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the SOAP header.
		/// </summary>
		/// <value>The SOAP header.</value>
		public SwmSuiteSoapHeader SoapHeader { get; set; }

		#endregion

		[WebMethod( Description =
			"<font color = blue>summary: </font>Check the connection by returing the value in the ConnectionTest table."
			+ "</br><font color = blue>returns: </font>True if the value could be retrieved from the database." )]
		[SoapHeader( "SoapHeader" )]
		public bool CheckConnection() {
			try {
				//WebServerAuthentication.Authenticate( this.SoapHeader );
				return new ConnectionTestBll().CheckConnection();
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}
	}
}
