using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Framework;

namespace SwmSuite.Data.BusinessObjects {

	/// <summary>
	/// Class defining an employee.
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class TimeTableTemplateEntry : BusinessObjectBase {

		#region -_ Private Members _-

		private static DateTime _templateFrom = new DateTime( 2000 , 10 , 10 );

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets the template from.
		/// </summary>
		/// <value>The template from.</value>
		public static DateTime TemplateFrom {
			get {
				return _templateFrom.StartOfWeek();
			}
		}

		/// <summary>
		/// Gets the template to.
		/// </summary>
		/// <value>The template to.</value>
		public static DateTime TemplateTo {
			get {
				return _templateFrom.EndOfWeek();
			}
		}

		/// <summary>
		/// Gets or sets the date.
		/// </summary>
		/// <value>The date.</value>
		public DateTime Date { get; set; }

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
		/// Gets or sets the TimeTablePurpose this entry uses.
		/// </summary>
		/// <value>The time table purpose.</value>
		public TimeTablePurpose TimeTablePurpose { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTableEntry"/> class.
		/// </summary>
		public TimeTableTemplateEntry() {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTableEntry"/> class.
		/// </summary>
		/// <param name="date">The date.</param>
		/// <param name="employee">The employee.</param>
		/// <param name="from">The start time.</param>
		/// <param name="to">The end time.</param>
		/// <param name="purpose">The internal id of the TimeTablePurpose this entry uses.</param>
		public TimeTableTemplateEntry( DateTime date , DateTime from , DateTime to , TimeTablePurpose purpose ) {
			this.Date = date;
			this.From = from;
			this.To = to;
			this.TimeTablePurpose = purpose;
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Convert this entry to its string representation.
		/// </summary>
		/// <returns>The time-range of this entry.</returns>
		public override string ToString() {
			return this.From.ToShortTimeString() + " - " + this.To.ToShortTimeString();
		}

		/// <summary>
		/// Toes the time table entry.
		/// </summary>
		/// <param name="date">The date.</param>
		/// <param name="employee">The employee.</param>
		/// <returns></returns>
		public TimeTableEntry ToTimeTableEntry( DateTime date , Employee employee ) {
			TimeTableEntry timeTableEntry = new TimeTableEntry();
			timeTableEntry.Date = date;
			timeTableEntry.From = new DateTime( date.Year , date.Month , date.Day , this.From.Hour , this.From.Minute , this.From.Second );
			timeTableEntry.To = new DateTime( date.Year , date.Month , date.Day , this.To.Hour , this.To.Minute , this.To.Second );
			timeTableEntry.TimeTablePurpose = this.TimeTablePurpose;
			timeTableEntry.Employee = employee;
			return timeTableEntry;
		}

		#endregion

	}
}
