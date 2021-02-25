using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace SimpleWorkfloorManagementSuite.Controls {
	
	/// <summary>
	/// Class defining a collection of checklist items for the checklist control.
	/// </summary>
	public class CheckListItemCollection : Collection<CheckListItem> {

		#region -_ Public Events _-

		/// <summary>
		/// Event raised if this collection has been modified.
		/// </summary>
		public event EventHandler<EventArgs> CollectionChanged;

		#endregion

		#region -_ Private Methods _-

		/// <summary>
		/// Raises the collectionchanged event if it is registered.
		/// </summary>
		private void RaiseCollectionChanged() {
			if( this.CollectionChanged != null ) {
				CollectionChanged( this , EventArgs.Empty );
			}
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Adds a checklist item to his collection.
		/// </summary>
		/// <param name="item">The checklist item to add.</param>
		public new void Add( CheckListItem item ) {
			base.Add( item );
			RaiseCollectionChanged();
		}

		/// <summary>
		/// Removes the first occurrence of the checklist item from this collection.
		/// </summary>
		/// <param name="item">The checklist item to remove</param>
		public new void Remove( CheckListItem item ) {
			base.Remove( item );
			RaiseCollectionChanged();
		}

		#endregion

	}

}
