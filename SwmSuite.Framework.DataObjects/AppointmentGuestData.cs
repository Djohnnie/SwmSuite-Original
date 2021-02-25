using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class AppointmentGuestData : DataObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the internal id for the appointment.
		/// </summary>
		public int AppointmentSysId { get; set; }

		/// <summary>
		/// Gets or sets the internal id for the employee.
		/// </summary>
		public int EmployeeSysId { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public AppointmentGuestData() {

		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="appointmentSysId">The internal id for the appointment.</param>
		/// <param name="employeeSysId">The internal id for the employee.</param>
		public AppointmentGuestData( int appointmentSysId , int employeeSysId ) {
			this.AppointmentSysId = appointmentSysId;
			this.EmployeeSysId = employeeSysId;
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Convert this appointmentguest to its string representation.
		/// </summary>
		/// <returns></returns>
		public override string ToString( ) {
			return "";
		}

		#endregion

	}

}
