using System;
using System.Collections.Generic;

using System.Text;
using System.ComponentModel;

namespace SwmSuite.Presentation.Common.ModuleWindowMenu {
	
	public class ModuleWindowMenuItem {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		public string Title { get; set; }

		public string Description { get; set; }

		public bool Selected { get; set; }
		public bool Hovered { get; set; }
		public bool Enabled { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ModuleWindowMenuItem() {
		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		public ModuleWindowMenuItem( string title ) {
			this.Title = title;
		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		public ModuleWindowMenuItem( string title , string description ) {
			this.Title = title;
			this.Description = description;
		}

		#endregion

		#region -_ ToString _-

		/// <summary>
		/// Convert this ModuleWindowMenuItem
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			return this.Title;
		}

		#endregion

	}

}
