using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Proxy.Interface;

namespace SimpleWorkfloorManagementSuite {
	
	public class SwmSuiteLogOn {

		#region -_ Private Members _-



		#endregion

		#region -_ Public Properties _-

		#endregion

		#region -_ Construction _-

		private SwmSuiteLogOn() {
		}

		#endregion

		#region -_ Public Methods _-

		public static SwmSuiteLogOnProblems Go() {
			SwmSuiteLogOnProblems problems = SwmSuiteLogOnProblems.None;

			if( SwmSuiteFacade.EmployeeFacade.GetEmployeeGroups().Count == 0 ) {
				problems = SwmSuiteLogOnProblems.NoEmployees;
			}

			return problems;
		}

		#endregion

	}
}
