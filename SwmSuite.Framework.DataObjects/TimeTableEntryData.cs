using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class TimeTableEntryData : DataObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the date.
		/// </summary>
		/// <value>The date.</value>
		public DateTime Date { get; set; }

		/// <summary>
		/// Gets or sets the internal id of the employee this TimeTableEntry applies to.
		/// </summary>
		/// <value>The internal id of the employee this TimeTableEntry applies to.</value>
		public int EmployeeSysId { get; set; }

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
		/// Initializes a new instance of the <see cref="TimeTableEntryData"/> class.
		/// </summary>
		public TimeTableEntryData() {

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTableEntryData"/> class.
		/// </summary>
		/// <param name="date">The date.</param>
		/// <param name="employeeSysId">The employee sys id.</param>
		/// <param name="from">The start time.</param>
		/// <param name="to">The end time.</param>
		/// <param name="purposeSysId">The internal id of the TimeTablePurpose this entry uses.</param>
		public TimeTableEntryData( DateTime date , int employeeSysId , DateTime from , DateTime to , int purposeSysId ){
			this.Date = date;
			this.EmployeeSysId = employeeSysId;
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
