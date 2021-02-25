using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwmSuite.Proxy.Interface {

	public class SwmSuiteAuthenticationFailedException : Exception {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the name of the user.
		/// </summary>
		/// <value>The name of the user.</value>
		public String UserName { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="SwmSuiteAuthenticationFailedException"/> class.
		/// </summary>
		/// <param name="userName">Name of the user.</param>
		public SwmSuiteAuthenticationFailedException( String userName ) {
			this.UserName = userName;
		}

		#endregion

	}

}
