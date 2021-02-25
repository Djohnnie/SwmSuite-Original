using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Proxy.Interface;
using SwmSuite.Business;

namespace SwmSuite.Proxy.Inproc {
	
	public class ConnectionTestFacade : IConnectionTestFacade {

		/// <summary>
		/// Check the connection by returing the value in the ConnectionTest table.
		/// </summary>
		/// <returns>True if the value could be retrieved from the database.</returns>
		bool IConnectionTestFacade.CheckConnection() {
			return new ConnectionTestBll().CheckConnection();
		}

	}

}
