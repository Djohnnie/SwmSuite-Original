using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.BusinessObjects;

namespace SimpleWorkfloorManagementSuite.Controls {
	
	public class LoginGroupLoginEventArgs : EventArgs {

		#region -_ Public Properties _-

		public Employee Employee {get;set;}

		#endregion

		#region -_ Construction _-

		public LoginGroupLoginEventArgs() {
		}

		public LoginGroupLoginEventArgs( Employee employee ) {
			this.Employee = employee;
		}

		#endregion

	}

}
