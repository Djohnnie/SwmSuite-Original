using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;
using SwmSuite.Data.Common;

namespace SwmSuite.Data.BusinessObjects {

  /// <summary>
  /// Class defining an appointment.
  /// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class Appointment : BusinessObjectBase {

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
		/// Gets or sets the employee owning this appointment.
		/// </summary>
		public Employee OwnerEmployee { get; set; }

		/// <summary>
		/// Gets or sets the contents for this appointment.
		/// </summary>
		public string Contents { get; set; }

		/// <summary>
		/// Gets or sets the agenda this appointment belongs to.
		/// </summary>
		public Agenda Agenda { get; set; }

		/// <summary>
		/// Gets or sets the visibility for this appointment.
		/// </summary>
		public AppointmentVisibility Visibility { get; set; }

		/// <summary>
		/// Gets or sets the guests.
		/// </summary>
		/// <value>The guests.</value>
		public EmployeeCollection Guests { get; set; }

		/// <summary>
		/// Gets or sets the recurrence.
		/// </summary>
		/// <value>The recurrence.</value>
		public Recurrence Recurrence { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="Appointment"/> class.
		/// </summary>
		public Appointment() {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Appointment"/> class.
		/// </summary>
		/// <param name="title">The title this appointment.</param>
		/// <param name="start">The start date and time for this appointment.</param>
		/// <param name="end">The end date and time for this appointment.</param>
		/// <param name="place">The place for this appointment.</param>
		/// <param name="owner">The employee owning this appointment.</param>
		/// <param name="contents">The contents for this appointment.</param>
		/// <param name="agenda">The agenda this appointment belongs to.</param>
		/// <param name="visibility">The visibility for this appointment.</param>
		public Appointment( string title , DateTime start , DateTime end , string place , Employee owner , string contents , Agenda agenda , AppointmentVisibility visibility ) {
			this.RowVersion = 0;
			this.Title = title;
			this.DateTimeEnd = end;
			this.DateTimeStart = start;
			this.OwnerEmployee = owner;
			this.Contents = contents;
			this.Agenda = agenda;
			this.Visibility = visibility;
		}

		#endregion

		#region -_ Validation _-

		/// <summary>
		/// Validates this instance.
		/// </summary>
		/// <returns></returns>
		public bool Validate() {
			bool valid = true;
			this.ValidationErrors.Clear();
			// Validate Title.
			if( String.IsNullOrEmpty( this.Title ) ) {
				valid = false;
				this.ValidationErrors.Add( "Titel is verplicht in te vullen." );
			}
			// Validate Contents.
			if( String.IsNullOrEmpty( this.Contents ) ) {
				valid = false;
				this.ValidationErrors.Add( "Inhoud is verplicht in te vullen." );
			}
			// Validate OwnerEmployee.
			if( this.OwnerEmployee == null ) {
				valid = false;
				this.ValidationErrors.Add( "Eigenaar is verplicht in te vullen." );
			}
			// Validate Agenda.
			if( this.Agenda == null ) {
				valid = false;
				this.ValidationErrors.Add( "Agenda is verplicht in te vullen." );
			}
			// Validate Period
			if( this.DateTimeEnd >= this.DateTimeStart ) {
				valid = false;
				this.ValidationErrors.Add( "Begin en einde vormen een ongeldige periode." );
			}
			return valid;
		}

		#endregion

	}

}
