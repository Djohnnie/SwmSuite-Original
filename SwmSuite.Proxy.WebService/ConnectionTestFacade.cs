using System;
using System.Collections.Generic;
using System.Text;
using SwmSuite.Proxy.Interface;
using System.Net;

namespace SwmSuite.Proxy.WebService {

	public class ConnectionTestFacade :
		ServiceFacade<ConnectionTestService.ConnectionTestService ,ConnectionTestService.SwmSuiteSoapHeader> , 
		IConnectionTestFacade {

		/// <summary>
		/// Check the connection by returing the value in the ConnectionTest table.
		/// </summary>
		/// <returns>True if the value could be retrieved from the database.</returns>
		bool IConnectionTestFacade.CheckConnection() {
			try {
				return GetService().CheckConnection();
			} catch( WebException e ) {
				return false;
			}
		}

	}

}
