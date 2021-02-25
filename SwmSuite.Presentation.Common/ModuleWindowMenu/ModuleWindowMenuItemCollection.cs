using System;
using System.Collections.Generic;

using System.Text;
using System.ComponentModel;

namespace SwmSuite.Presentation.Common.ModuleWindowMenu {
	
	public class ModuleWindowMenuItemCollection {

		#region -_ Private Members _-

		private List<ModuleWindowMenuItem> _list = new List<ModuleWindowMenuItem>();

		#endregion

		#region -_ Public Properties _-

		[DesignerSerializationVisibility( DesignerSerializationVisibility.Content )]
		public List<ModuleWindowMenuItem> List {
			get {
				return _list;
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ModuleWindowMenuItemCollection() {
		}

		#endregion

		#region -_ Public Methods _-

		public void Add( ModuleWindowMenuItem item ) {
			this.List.Add( item );
		}

		public bool Remove( ModuleWindowMenuItem item ) {
			return this.List.Remove( item );
		}

		public void SelectItem( ModuleWindowMenuItem item ) {
			foreach( ModuleWindowMenuItem i in this.List ) {
				if( i.Equals( item ) ) {
					item.Selected = true;
				} else {
					item.Selected = false;
				}
			}
		}

		#endregion

	}
}
