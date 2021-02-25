using System;
using System.Collections.Generic;

using System.Text;

namespace SwmSuite.Presentation.Common.EmployeeGroupTab {
	
	public class EmployeeGroupTabSelectionEventArgs : EventArgs {

		#region -_ Public Properties _-

		public EmployeeGroupTabItem Item { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public EmployeeGroupTabSelectionEventArgs() {
		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="item">The employeegrouptabitem to associate with these event args.</param>
		public EmployeeGroupTabSelectionEventArgs( EmployeeGroupTabItem item ) {
			this.Item = item;
		}

		#endregion

	}
}
