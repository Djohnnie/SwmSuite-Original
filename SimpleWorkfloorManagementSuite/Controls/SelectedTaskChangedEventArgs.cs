using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.BusinessObjects;

namespace SimpleWorkfloorManagementSuite.Controls {
	
	/// <summary>
	/// Class defining the event arguments for a selection
	/// change on the task browserview control.
	/// </summary>
	public class SelectedTaskChangedEventArgs : EventArgs {

		#region -_ Public properties _-

		/// <summary>
		/// Gets or sets the task.
		/// </summary>
		/// <value>The task.</value>
		public Task Task { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="SelectedTaskChangedEventArgs"/> class.
		/// </summary>
		/// <param name="task">The task.</param>
		public SelectedTaskChangedEventArgs( Task task ) {
			this.Task = task;
		}

		#endregion

	}

}
