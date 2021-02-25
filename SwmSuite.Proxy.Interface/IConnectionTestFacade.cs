using System;
using System.Collections.Generic;

using System.Text;

namespace SwmSuite.Proxy.Interface {
	
	public interface IConnectionTestFacade {

		/// <summary>
		/// Check the connection by returing the value in the ConnectionTest table.
		/// </summary>
		/// <returns>True if the value could be retrieved from the database.</returns>
		bool CheckConnection();

	}

}
