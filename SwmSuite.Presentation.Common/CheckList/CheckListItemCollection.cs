using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace SwmSuite.Presentation.Common.CheckList {

	/// <summary>
	/// Class defining a collection of checklist items.
	/// </summary>
	public class CheckListItemCollection : Collection<CheckListItem> {

		#region -_ Public Methods _-

		/// <summary>
		/// Checks all items.
		/// </summary>
		/// <param name="check">True to check all items, false to uncheck all items.</param>
		public void CheckAllItems( bool check ) {
			foreach( CheckListItem item in this ) {
				item.Checked = false;
			}
		}

		#endregion

	}

}
