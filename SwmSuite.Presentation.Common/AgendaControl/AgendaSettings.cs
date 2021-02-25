using System;
using System.Collections.Generic;

using System.Text;

namespace SwmSuite.Presentation.Common.AgendaControl {
	
	public class AgendaSettings {

		#region -_ Public Properties _-

		public int DefaultBeginHour { get; set; }
		public int DefaultEndHour { get; set; }
		public int CurrentBeginPosition { get; set; }

		#endregion

		#region -_ Construction _-

		public AgendaSettings() {
			this.DefaultBeginHour = 7;
			this.DefaultEndHour = 23;
			this.CurrentBeginPosition = this.DefaultBeginHour;
		}

		#endregion

	}

}
