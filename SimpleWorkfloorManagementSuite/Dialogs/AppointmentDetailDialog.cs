using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.BusinessObjects;

namespace SimpleWorkfloorManagementSuite.Dialogs {

	public partial class AppointmentDetailDialog : Form {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the appointment.
		/// </summary>
		/// <value>The appointment.</value>
		public Appointment Appointment { get; set; }

		///// <summary>
		///// Gets or sets the selection start.
		///// </summary>
		///// <value>The selection start.</value>
		//public DateTime SelectionStart {
		//   get {
		//      return beginDateTimePicker.Value;
		//   }
		//   set {
		//      try {
		//         beginDateTimePicker.Value = value;
		//      } catch( Exception ) {
		//         beginDateTimePicker.Value = new DateTime( DateTime.Now.Year , DateTime.Now.Month , DateTime.Now.Day , DateTime.Now.Hour , 0 , 0 );
		//      }
		//   }
		//}

		///// <summary>
		///// Gets or sets the selection end.
		///// </summary>
		///// <value>The selection end.</value>
		//public DateTime SelectionEnd {
		//   get {
		//      return endDateTimePicker.Value;
		//   }
		//   set {
		//      try {
		//         endDateTimePicker.Value = value;
		//      } catch( Exception ) {
		//         endDateTimePicker.Value = new DateTime( DateTime.Now.Year , DateTime.Now.Month , DateTime.Now.Day , DateTime.Now.Hour + 1 , 0 , 0 );
		//      }
		//   }
		//}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="AppointmentDetailDialog"/> class.
		/// </summary>
		public AppointmentDetailDialog() {
			InitializeComponent();
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="AppointmentDetailDialog"/> class.
		/// </summary>
		public AppointmentDetailDialog( DateTime selectionStart , DateTime selectionEnd )
			: this() {
			this.Appointment = new Appointment();
			this.Appointment.DateTimeStart = selectionStart;
			this.Appointment.DateTimeEnd = selectionEnd;
			this.Appointment.OwnerEmployee = SwmSuitePrincipal.CurrentEmployee;
			this.Appointment.Guests = new EmployeeCollection();
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Click event of the browseFoAgendaButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void browseFoAgendaButton_Click( object sender , EventArgs e ) {
			BrowseForAgendaDialog dialog = new BrowseForAgendaDialog( this.Appointment.Agenda );
			if( dialog.ShowDialog() == DialogResult.OK ) {
				this.Appointment.Agenda = dialog.Agenda;
				agendaTextBox.Client.Text = this.Appointment.Agenda.Title;
			}
		}

		#endregion

		#region -_ Private Methods _-

		private static String EmployeeLinkCollectionToString( EmployeeCollection employeeLinks ) {
			String stringToReturn = "";
			if( employeeLinks != null ) {
				foreach( Employee employee in employeeLinks ) {
					bool lastItem = employeeLinks.IndexOf( employee ) == employeeLinks.Count - 1;
					stringToReturn += employee.FirstName + " " + employee.Name + ( lastItem ? "" : "; " );
				}
			}
			return stringToReturn;
		}

		#endregion

		/// <summary>
		/// Handles the Click event of the guestsButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void guestsButton_Click( object sender , EventArgs e ) {
			BrowserForEmployeeDialog dialog = new BrowserForEmployeeDialog( this.Appointment.Guests );
			if( dialog.ShowDialog() == DialogResult.OK ) {
				this.Appointment.Guests = dialog.Employees;
				guestsTextBox.Client.Text = EmployeeLinkCollectionToString( this.Appointment.Guests );
			}
		}

		/// <summary>
		/// Handles the Click event of the okButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void okButton_Click( object sender , EventArgs e ) {
			this.Appointment.Title = titleTextBox.Client.Text;
			this.Appointment.Place = locationTextBox.Client.Text;
			this.Appointment.Contents = detailsTextBox.Client.Text;
			this.Appointment.DateTimeStart = beginDateTimePicker.Value;
			this.Appointment.DateTimeEnd = endDateTimePicker.Value;
			this.Appointment.Visibility = SwmSuite.Data.Common.AppointmentVisibility.Public;
		}

		/// <summary>
		/// Handles the Load event of the AppointmentDetailDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void AppointmentDetailDialog_Load( object sender , EventArgs e ) {
			if( this.Appointment != null ) {
				titleTextBox.Client.Text = this.Appointment.Title;
				locationTextBox.Client.Text = this.Appointment.Place;
				detailsTextBox.Client.Text = this.Appointment.Contents;
				try {
					beginDateTimePicker.Value = this.Appointment.DateTimeStart;
				} catch( Exception ) {
					beginDateTimePicker.Value = new DateTime( DateTime.Now.Year , DateTime.Now.Month , DateTime.Now.Day , DateTime.Now.Hour , 0 , 0 );
				}
				try {
					endDateTimePicker.Value = this.Appointment.DateTimeEnd;
				} catch( Exception ) {
					endDateTimePicker.Value = new DateTime( DateTime.Now.Year , DateTime.Now.Month , DateTime.Now.Day , DateTime.Now.Hour , 0 , 0 );
				}
				if( this.Appointment.Agenda != null ) {
					agendaTextBox.Client.Text = this.Appointment.Agenda.Title;
				}
				guestsTextBox.Client.Text = EmployeeLinkCollectionToString( this.Appointment.Guests );
			}
			Validate();
		}

		/// <summary>
		/// Handles the Click event of the recurrenceButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void recurrenceButton_Click( object sender , EventArgs e ) {

		}

		private void titleTextBox_TextChanged( object sender , EventArgs e ) {
			Validate();
		}

		private void agendaTextBox_TextChanged( object sender , EventArgs e ) {
			Validate();
		}

		private void Validate() {
			bool titleValid = ValidateTitle();
			bool agendaValid = ValidateAgenda();
			bool periodValid = ValidatePeriod();
			okButton.Enabled = titleValid && agendaValid && periodValid;
		}

		private bool ValidateTitle() {
			bool valid = !String.IsNullOrEmpty( titleTextBox.Client.Text );
			titleTextBox.DoError( !valid );
			return valid;
		}

		private bool ValidateAgenda() {
			bool valid = !String.IsNullOrEmpty( agendaTextBox.Client.Text );
			agendaTextBox.DoError( !valid );
			return valid;
		}

		private bool ValidatePeriod() {
			bool valid = beginDateTimePicker.Value < endDateTimePicker.Value;
			return valid;
		}

		private void beginDateTimePicker_ValueChanged( object sender , EventArgs e ) {
			Validate();
		}

		private void endDateTimePicker_ValueChanged( object sender , EventArgs e ) {
			Validate();
		}

	}

}
