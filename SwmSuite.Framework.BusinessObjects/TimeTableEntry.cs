using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.Common;

namespace SwmSuite.Data.BusinessObjects {

	/// <summary>
	/// Class defining an employee.
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class TimeTableEntry : BusinessObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the date.
		/// </summary>
		/// <value>The date.</value>
		public DateTime Date { get; set; }

		/// <summary>
		/// Gets or sets the employee this TimeTableEntry applies to.
		/// </summary>
		/// <value>The employee this TimeTableEntry applies to.</value>
		public Employee Employee { get; set; }

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
		public TimeTableEntry() {

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTableEntry"/> class.
		/// </summary>
		/// <param name="date">The date.</param>
		/// <param name="employee">The employee.</param>
		/// <param name="from">The start time.</param>
		/// <param name="to">The end time.</param>
		/// <param name="purpose">The internal id of the TimeTablePurpose this entry uses.</param>
		public TimeTableEntry( DateTime date , Employee employee , DateTime from , DateTime to , TimeTablePurpose purpose ){
			this.Date = date;
			this.Employee = employee;
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
		public override string ToString( ) {
			return this.From.ToShortTimeString() + " - " + this.To.ToShortTimeString();
		}

		/// <summary>
		/// Creates the appointment.
		/// </summary>
		/// <returns></returns>
		public Appointment CreateAppointment() {
			Appointment appointment = new Appointment();
			appointment.Agenda = null;
			appointment.Contents = this.TimeTablePurpose + ": " + this.TimeTablePurpose.Description;
			appointment.Title = "Werk";
			appointment.DateTimeStart = this.From;
			appointment.DateTimeEnd = this.To;
			appointment.OwnerEmployee = this.Employee;
			appointment.Place = "";
			appointment.Visibility = AppointmentVisibility.Public;
			return appointment;
		}

		#endregion

	}

}
