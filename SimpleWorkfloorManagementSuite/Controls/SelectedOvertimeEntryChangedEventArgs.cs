using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.BusinessObjects;

namespace SimpleWorkfloorManagementSuite.Controls {

	/// <summary>
	/// Class defining the event arguments for a selection
	/// change on the overtime browserview control.
	/// </summary>
	public class SelectedOvertimeEntryChangedEventArgs : EventArgs {

		#region -_ Public properties _-

		/// <summary>
		/// Gets or sets the overtime entry.
		/// </summary>
		/// <value>The overtime entry.</value>
		public OvertimeEntry OvertimeEntry { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="SelectedOvertimeEntryChangedEventArgs"/> class.
		/// </summary>
		/// <param name="overtimeEntry">The overtime entry.</param>
		public SelectedOvertimeEntryChangedEventArgs( OvertimeEntry overtimeEntry ) {
			this.OvertimeEntry = overtimeEntry;
		}

		#endregion

	}

}
