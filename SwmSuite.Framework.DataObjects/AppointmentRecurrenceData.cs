using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class AppointmentRecurrenceData : DataObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the internal id for the appointment.
		/// </summary>
		public int AppointmentSysId { get; set; }

		/// <summary>
		/// Gets or sets the internal id for the recurrence.
		/// </summary>
		public int RecurrenceSysId { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public AppointmentRecurrenceData() {

		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="appointmentSysId">The internal id for the appointment.</param>
		/// <param name="recurrenceSysId">The internal id for the recurrence.</param>
		public AppointmentRecurrenceData( int appointmentSysId , int recurrenceSysId ) {
			this.AppointmentSysId = appointmentSysId;
			this.RecurrenceSysId = recurrenceSysId;
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Convert this appointmentrecurrence to its string representation.
		/// </summary>
		/// <returns>An empty string.</returns>
		public override string ToString() {
			return String.Empty;
		}

		#endregion

	}
}
