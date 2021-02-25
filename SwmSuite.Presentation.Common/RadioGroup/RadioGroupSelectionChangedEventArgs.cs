using System;
using System.Collections.Generic;

using System.Text;

namespace SwmSuite.Presentation.Common.RadioGroup {
	
	public class RadioGroupSelectionChangedEventArgs : EventArgs {

		#region -_ Public Properties _-

		public RadioGroupItem Item { get; set; }

		#endregion

		#region -_ Construction _-

		public RadioGroupSelectionChangedEventArgs( RadioGroupItem item ) {
			this.Item = item;
		}

		#endregion

	}
}
