using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class TimeTableTemplateEntryData : DataObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the date.
		/// </summary>
		/// <value>The date.</value>
		public DateTime Date { get; set; }

		/// <summary>
		/// Gets or sets the internal id of the timetable template this TimeTableTemplateEntry applies to.
		/// </summary>
		/// <value>The internal id of the timetable template this TimeTableTemplateEntry applies to.</value>
		public int TimeTableTemplateSysId { get; set; }

		/// <summary>
		/// Gets or sets the start time.
		/// </summary>
		/// <value>The start time.</value>
		public DateTime From { get; set; }

		/// <summary>
		/// Gets or sets the end time.
		/// </summary>
		/// <value>The end time.</value>
		public DateTime To { get; set; }

		/// <summary>
		/// Gets or sets the internal id of the TimeTablePurpose this entry uses.
		/// </summary>
		/// <value>The time table purpose sys id.</value>
		public int TimeTablePurposeSysId { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTableTemplateEntryData"/> class.
		/// </summary>
		public TimeTableTemplateEntryData() {

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTableTemplateEntryData"/> class.
		/// </summary>
		/// <param name="date">The date.</param>
		/// <param name="timeTableTemplateSysId">The timetable template sys id.</param>
		/// <param name="from">The start time.</param>
		/// <param name="to">The end time.</param>
		/// <param name="purposeSysId">The internal id of the TimeTablePurpose this entry uses.</param>
		public TimeTableTemplateEntryData( DateTime date , int timeTableTemplateSysId , DateTime from , DateTime to , int purposeSysId ) {
			this.Date = date;
			this.TimeTableTemplateSysId = timeTableTemplateSysId;
			this.From = from;
			this.To = to;
			this.TimeTablePurposeSysId = purposeSysId;
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Convert this entry to its string representation.
		/// </summary>
		/// <returns>The time-range of this entry.</returns>
		public override string ToString( ) {
			return this.From.ToShortTimeString() + " - " + this.To.ToShortTimeString();
		}

		#endregion

	}

}
