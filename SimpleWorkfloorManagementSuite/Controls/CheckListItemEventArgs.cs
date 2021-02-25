using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleWorkfloorManagementSuite.Controls {
	
	/// <summary>
	/// Class defining a checklist item event argument.
	/// </summary>
	public class CheckListItemEventArgs : EventArgs {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the checklist item to associate with this event argument.
		/// </summary>
		public CheckListItem Item { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="CheckListItemEventArgs"/> class.
		/// </summary>
		/// <param name="item">The checklist item to associate with this event argument.</param>
		public CheckListItemEventArgs( CheckListItem item ) {
			this.Item = item;
		}

		#endregion

	}

}
