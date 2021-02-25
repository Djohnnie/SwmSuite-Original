using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleWorkfloorManagementSuite.Controls {
	
	/// <summary>
	/// Class defining a checklist item fot the checklist control.
	/// </summary>
	public class CheckListItem {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the checked state for this checklist item.
		/// </summary>
		public bool Checked { get; set; }

		/// <summary>
		/// Gets or sets the text for this checklist item.
		/// </summary>
		public String Text { get; set; }

		/// <summary>
		/// Gets or sets the tag object for this checklist item.
		/// </summary>
		public Object Tag { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="CheckListItem"/> class.
		/// </summary>
		/// <param name="text">The text for the new checklist item.</param>
		public CheckListItem( String text ) {
			this.Text = text;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CheckListItem"/> class.
		/// </summary>
		/// <param name="text">The text for the new checklist item..</param>
		/// <param name="tag">The tag object for the new checklist item.</param>
		public CheckListItem( String text , Object tag ) {
			this.Text = text;
			this.Tag = tag;
		}

		#endregion

	}

}
