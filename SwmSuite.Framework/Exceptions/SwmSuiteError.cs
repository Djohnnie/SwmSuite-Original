using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwmSuite.Framework.Exceptions {
	
	/// <summary>
	/// Enumerator defining a SwmSuite error.
	/// </summary>
	public enum SwmSuiteError {

		/// <summary>
		/// Connection error.
		/// </summary>
		ConnectionError,

		/// <summary>
		/// Validation error.
		/// </summary>
		ValidationError,

		/// <summary>
		/// Data access error.
		/// </summary>
		DataAccessError,

		/// <summary>
		/// Business error.
		/// </summary>
		BusinessError,

		/// <summary>
		/// User is locked out error.
		/// </summary>
		UserLockedOutError

	}
}
