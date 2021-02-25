using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwmSuite.Presentation.Common.TimeTable {
	
	public class OccupationSettings {

		#region -_ Public Properties _-

		public int StartHour { get; set; }

		public int EndHour { get; set; }

		#endregion

		#region -_ Construction _-

		public OccupationSettings() {
			this.StartHour = 7;
			this.EndHour = 23;
		}

		#endregion

	}

}
