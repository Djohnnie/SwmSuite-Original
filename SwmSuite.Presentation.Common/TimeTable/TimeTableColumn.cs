using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SwmSuite.Presentation.Common.TimeTable {

	/// <summary>
	/// Class defining a column for the timetable control.
	/// </summary>
	public class TimeTableColumn {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the caption.
		/// </summary>
		public String Caption { get; set; }

		/// <summary>
		/// Gets or sets the tume table entries.
		/// </summary>
		[DesignerSerializationVisibility( DesignerSerializationVisibility.Visible )]
		public TimeTableControlEntryCollection TimeTableEntries { get; set; }

		/// <summary>
		/// Gets or sets a tag object.
		/// </summary>
		public Object Tag { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTableColumn"/> class.
		/// </summary>
		public TimeTableColumn() {
			this.TimeTableEntries = new TimeTableControlEntryCollection();
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Gets the time table control entries on a specific date.
		/// </summary>
		/// <param name="date">The date to get the time table control entries on.</param>
		/// <returns>A TimeTableControlEntryCollection containing the requested time table control entries.</returns>
		public TimeTableControlEntryCollection GetEntriesOnDate( DateTime date ) {
			TimeTableControlEntryCollection entriesToReturn = new TimeTableControlEntryCollection();
			foreach( TimeTableControlEntry entry in this.TimeTableEntries ) {
				if( entry.Begin.Date == date ) {
					entriesToReturn.Add( entry );
				}
			}
			return entriesToReturn;
		}

		#endregion
	}

}
