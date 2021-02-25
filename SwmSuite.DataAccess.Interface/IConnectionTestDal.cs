using System;
using System.Collections.Generic;

using System.Text;

namespace SwmSuite.DataAccess.Interface {

	/// <summary>
	/// DAL Interface for the ConnectionTestService methods.
	/// </summary>
	public interface IConnectionTestDal {

		/// <summary>
		/// Check the connection by returing the value in the ConnectionTest table.
		/// </summary>
		/// <returns>True if the value could be retrieved from the database.</returns>
		bool CheckConnection();

	}
}
