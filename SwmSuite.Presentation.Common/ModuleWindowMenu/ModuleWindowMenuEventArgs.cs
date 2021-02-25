using System;
using System.Collections.Generic;

using System.Text;

namespace SwmSuite.Presentation.Common.ModuleWindowMenu {
	
	/// <summary>
	/// EventArgs representing the arguments on the <see cref="ModuleWindowMenuControl"/> MenuItemClicked event.
	/// </summary>
	public class ModuleWindowMenuEventArgs : EventArgs {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the menu item represented by this <see cref="ModuleWindowMenuEventArgs"/>.
		/// </summary>
		/// <value>the menu item represented by this <see cref="ModuleWindowMenuEventArgs"/>.</value>
		public ModuleWindowMenuItem MenuItem { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="ModuleWindowMenuEventArgs"/> class.
		/// </summary>
		/// <param name="menuItem">The menu item represented by this <see cref="ModuleWindowMenuEventArgs"/>.</param>
		public ModuleWindowMenuEventArgs( ModuleWindowMenuItem menuItem ) {
			this.MenuItem = menuItem;
		}

		#endregion

	}

}
