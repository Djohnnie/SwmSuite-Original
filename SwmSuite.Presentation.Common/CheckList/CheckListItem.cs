using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwmSuite.Presentation.Common.CheckList {
	
	/// <summary>
	/// Class defining a checklist item for the checklist control.
	/// </summary>
	public class CheckListItem {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the caption.
		/// </summary>
		/// <value>The caption.</value>
		public String Caption { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="CheckListItem"/> is checked.
		/// </summary>
		/// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
		public bool Checked { get; set; }

		/// <summary>
		/// Gets or sets the tag.
		/// </summary>
		/// <value>The tag.</value>
		public Object Tag { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="CheckListItem"/> class.
		/// </summary>
		public CheckListItem() {

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CheckListItem"/> class.
		/// </summary>
		/// <param name="caption">The caption.</param>
		/// <param name="tag">The tag.</param>
		public CheckListItem( String caption , Object tag ) {
			this.Caption = caption;
			this.Checked = true;
			this.Tag = tag;
		}

		#endregion

	}

}
