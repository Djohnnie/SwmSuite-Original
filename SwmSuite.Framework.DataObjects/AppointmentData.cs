using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;
using SwmSuite.Data.Common;

namespace SwmSuite.Data.DataObjects {

	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class AppointmentData  : DataObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the title this appointment.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the start date and time for this appointment.
		/// </summary>
		public DateTime DateTimeStart { get; set; }

		/// <summary>
		/// Gets or sets the end date and time for this appointment.
		/// </summary>
		public DateTime DateTimeEnd { get; set; }

		/// <summary>
		/// Gets or sets the place for this appointment.
		/// </summary>
		public string Place { get; set; }

		/// <summary>
		/// Gets or sets the internal id for the employee owning this appointment.
		/// </summary>
		public int OwnerEmployeeSysId { get; set; }

		/// <summary>
		/// Gets or sets the visibility for this appointment.
		/// </summary>
		public AppointmentVisibility Visibility { get; set; }

		/// <summary>
		/// Gets or sets the contents for this appointment.
		/// </summary>
		public string Contents { get; set; }

		/// <summary>
		/// Gets or sets the internal id for the agenda this appointment applies to.
		/// </summary>
		public int AgendaSysId { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public AppointmentData() {

		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="title">The title this appointment.</param>
		/// <param name="start">The start date and time for this appointment.</param>
		/// <param name="end">The end date and time for this appointment.</param>
		/// <param name="place">The place for this appointment.</param>
		/// <param name="ownerSysId">The internal id for the employee owning this appointment.</param>
		/// <param name="contents">The contents for this appointment.</param>
		/// <param name="agendaSysId">The internal id for the agenda this appointment applies to.</param>
		/// <param name="visibility">The visibility for this appointment.</param>
		public AppointmentData( string title , DateTime start , DateTime end , string place , int ownerSysId , string contents , int agendaSysId , AppointmentVisibility visibility ) {
			this.RowVersion = 0;
			this.Title = title;
			this.DateTimeEnd = end;
			this.DateTimeStart = start;
			this.OwnerEmployeeSysId = ownerSysId;
			this.Contents = contents;
			this.AgendaSysId = agendaSysId;
			this.Visibility = visibility;
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Convert this appointment to its string representation.
		/// </summary>
		/// <returns>The title of this appointment.</returns>
		public override string ToString( ) {
			return this.Title;
		}

		#endregion

	}

}
