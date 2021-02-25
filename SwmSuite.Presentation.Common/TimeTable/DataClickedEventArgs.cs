using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwmSuite.Presentation.Common.TimeTable {
	
	public class DataClickedEventArgs : EventArgs {

		#region -_ Public Properties _-

		public TimeTableColumn Column { get; set; }

		public DateTime Date { get; set; }

		public TimeTableControlEntryCollection Entries { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="DataClickedEventArgs"/> class.
		/// </summary>
		public DataClickedEventArgs() {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DataClickedEventArgs"/> class.
		/// </summary>
		/// <param name="column">The column.</param>
		/// <param name="date">The date.</param>
		/// <param name="entries">The entries.</param>
		public DataClickedEventArgs( TimeTableColumn column , DateTime date , TimeTableControlEntryCollection entries ) {
			this.Column = column;
			this.Date = date;
			this.Entries = entries;
		}

		#endregion

	}

}
