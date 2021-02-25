using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwmSuite.Presentation.Common.AgendaControl {
	
	/// <summary>
	/// Event arguments class defining the event arguments for the agenda control needsupdate event.
	/// </summary>
	public class AgendaNeedsUpdateEventArgs : EventArgs {

		#region -_ Public Properties _-

		/// <summary>
		/// gets or sets the dates associated with this event arguments.
		/// </summary>
		public DateTime[] Dates { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public AgendaNeedsUpdateEventArgs() {
		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="dates">Dates associated with this event arguments.</param>
		public AgendaNeedsUpdateEventArgs( DateTime[] dates ) {
			this.Dates = dates;
		}

		#endregion

	}

}
