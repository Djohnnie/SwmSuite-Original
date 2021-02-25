using System;
using System.Collections.Generic;

using System.Text;

namespace SwmSuite.Presentation.Common.RadioGroup {
	
	public class RadioGroupItem {

		#region -_ Public Properties _-

		public String Text { get; set; }
		public Object Tag { get; set; }
		public bool Checked { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public RadioGroupItem() {
		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="text"></param>
		public RadioGroupItem( String text ) {
			this.Text = text;
		}

		#endregion

	}

}
