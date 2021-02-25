using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using SwmSuite.Data.Common;

namespace SwmSuite.Data.DataObjects {

	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class RecurrenceData : DataObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets a recurrencemode.
		/// </summary>
		public RecurrenceMode RecurrenceMode { get; set; }

		/// <summary>
		/// Gets or sets an interval for this recurrence.
		/// </summary>
		public int Every { get; set; }

		/// <summary>
		/// Gets or sets wether this recurrence should occur every weekday.
		/// </summary>
		public bool EveryWeekDay { get; set; }

		/// <summary>
		/// Gets or sets a selection of days for this recurrence.
		/// </summary>
		public bool Monday { get; set; }

		/// <summary>
		/// Gets or sets a selection of days for this recurrence.
		/// </summary>
		public bool Tuesday { get; set; }

		/// <summary>
		/// Gets or sets a selection of days for this recurrence.
		/// </summary>
		public bool Wednesday { get; set; }

		/// <summary>
		/// Gets or sets a selection of days for this recurrence.
		/// </summary>
		public bool Thursday { get; set; }

		/// <summary>
		/// Gets or sets a selection of days for this recurrence.
		/// </summary>
		public bool Friday { get; set; }

		/// <summary>
		/// Gets or sets a selection of days for this recurrence.
		/// </summary>
		public bool Saturday { get; set; }

		/// <summary>
		/// Gets or sets a selection of days for this recurrence.
		/// </summary>
		public bool Sunday { get; set; }

		/// <summary>
		/// Gets or sets the day of the month this recurrence should occur.
		/// </summary>
		public int DayOfMonth { get; set; }

		/// <summary>
		/// Gets or sets the occurence.
		/// </summary>
		public Occurrence Occurrence { get; set; }

		/// <summary>
		/// Gets or sets the day for the recurrence.
		/// </summary>
		public Days Day { get; set; }

		/// <summary>
		/// Gets or sets the month for the recurrence.
		/// </summary>
		public Months Month { get; set; }

		public bool Choice { get; set; }

		/// <summary>
		/// Gets or sets the startdate for this recurrence.
		/// </summary>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// Gets or sets the end mode for this recurrence.
		/// </summary>
		public RecurrenceEndMode EndMode { get; set; }

		/// <summary>
		/// Gets or sets the number of occurences for this recurrence.
		/// </summary>
		public int Occurrences { get; set; }

		/// <summary>
		/// Gets or sets the enddate for this recurrence.
		/// </summary>
		public DateTime EndDate { get; set; }

		/// <summary>
		/// Gets or sets a description.
		/// </summary>
		public String Description { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public RecurrenceData() {
		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="recurrenceMode">The recurrencemode.</param>
		/// <param name="startDate">The start date and time for this recurrence.</param>
		public RecurrenceData( RecurrenceMode recurrenceMode , DateTime startDate ) : this() {
			this.RecurrenceMode = recurrenceMode;
			this.StartDate = startDate;
			this.EndDate = startDate;
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Convert this recurrence to its string representation.
		/// </summary>
		/// <returns>An empty string.</returns>
		public override string ToString() {
			return String.Empty;
		}

		#endregion

	}

}