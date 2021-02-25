using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Proxy.Interface;
using SwmSuite.Framework.Exceptions;

namespace SimpleWorkfloorManagementSuite.Dialogs {

	/// <summary>
	/// 
	/// </summary>
	public partial class TimeTableEntryDetailDialog : Form {

		#region -_ Private Members _-

		private EmployeeGroup _employeeGroup;

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the time table entry.
		/// </summary>
		/// <value>The time table entry.</value>
		public TimeTableEntry TimeTableEntry { get; set; }

		/// <summary>
		/// Gets or sets the sub header text.
		/// </summary>
		/// <value>The sub header text.</value>
		public String SubHeaderText { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTableEntryDetailDialog"/> class.
		/// </summary>
		/// <param name="employeeGroup">The employee group.</param>
		public TimeTableEntryDetailDialog( EmployeeGroup employeeGroup ) {
			InitializeComponent();
			_employeeGroup = employeeGroup;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTableEntryDetailDialog"/> class.
		/// </summary>
		/// <param name="employeeGroup">The employee group.</param>
		/// <param name="timeTableEntry">The time table entry.</param>
		public TimeTableEntryDetailDialog( EmployeeGroup employeeGroup , TimeTableEntry timeTableEntry )
			: this( employeeGroup ) {
			this.TimeTableEntry = timeTableEntry;
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Click event of the browseForTimeTablePurposeButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void browseForTimeTablePurposeButton_Click( object sender , EventArgs e ) {
			this.TimeTableEntry.TimeTablePurpose =
				BrowseForTimeTablePurposeDialog.ShowBrowseForTimeTablePurposeDialog( _employeeGroup , this.TimeTableEntry.TimeTablePurpose );
			if( this.TimeTableEntry.TimeTablePurpose != null ) {
				timeTablePurposeTextBox.Client.Text = this.TimeTableEntry.TimeTablePurpose.Description;
			} else {
				timeTablePurposeTextBox.Client.Text = String.Empty;
			}
		}

		/// <summary>
		/// Handles the Load event of the TimeTableEntryDetailDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void TimeTableEntryDetailDialog_Load( object sender , EventArgs e ) {
			dialogHeaderControl.SubText = this.SubHeaderText;

			startDateTimePicker.Value = this.TimeTableEntry.From;
			stopDateTimePicker.Value = this.TimeTableEntry.To;
			if( this.TimeTableEntry.TimeTablePurpose != null ) {
				timeTablePurposeTextBox.Client.Text = this.TimeTableEntry.TimeTablePurpose.Description;
			}

			ValidateAll();
		}

		/// <summary>
		/// Handles the ValueChanged event of the startDateTimePicker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void startDateTimePicker_ValueChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		/// <summary>
		/// Handles the ValueChanged event of the stopDateTimePicker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void stopDateTimePicker_ValueChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		/// <summary>
		/// Handles the TextChanged event of the timeTablePurposeTextBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void timeTablePurposeTextBox_TextChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		/// <summary>
		/// Handles the Click event of the okButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void okButton_Click( object sender , EventArgs e ) {
			this.TimeTableEntry.From = startDateTimePicker.Value;
			this.TimeTableEntry.To = stopDateTimePicker.Value;
		}

		#endregion

		#region -_ Validation _-

		private void ValidateAll() {
			bool timeIsValid = ValidateTime();
			bool purposeIsValid = ValidatePurpose();
			okButton.Enabled =
				timeIsValid &&
				purposeIsValid;
		}

		/// <summary>
		/// Validate the "start time" and "stop time" fields.
		/// </summary>
		/// <returns>True if the fields appear to be valid, false otherwise.</returns>
		private bool ValidateTime() {
			bool valueToReturn = startDateTimePicker.Value < stopDateTimePicker.Value;
			return valueToReturn;
		}

		/// <summary>
		/// Validate the "time table purpose" field.
		/// </summary>
		/// <returns>True if the field appears to be valid, false otherwise.</returns>
		private bool ValidatePurpose() {
			bool valueToReturn = !String.IsNullOrEmpty( timeTablePurposeTextBox.Client.Text );
			timeTablePurposeTextBox.DoError( !valueToReturn );
			return valueToReturn;
		}

		#endregion

		#region -_ Static Methods _-

		/// <summary>
		/// Shows the time table entry detail dialog for editing the given entry.
		/// </summary>
		/// <param name="employeeGroup">The employee group.</param>
		/// <param name="timeTableEntry">The time table entry to edit.</param>
		/// <returns>The updated time table entry.</returns>
		public static TimeTableEntry EditTimeTableEntryDetailDialog( EmployeeGroup employeeGroup , TimeTableEntry timeTableEntry ) {
			TimeTableEntry timeTableEntryToReturn = null;
			TimeTableEntryDetailDialog dialog = new TimeTableEntryDetailDialog( employeeGroup , timeTableEntry );
			dialog.SubHeaderText = "Uurroosterplanning inschrijving aanpassen...";
			if( dialog.ShowDialog() == DialogResult.OK ) {
				try {
					timeTableEntryToReturn =
						SwmSuiteFacade.TimeTableFacade.UpdateTimeTableEntry( dialog.TimeTableEntry );
				} catch( SwmSuiteException e ) {

				}
			}
			return timeTableEntryToReturn;
		}

		/// <summary>
		/// Shows the time table entry detail dialog for adding a new entry.
		/// </summary>
		/// <param name="employee">The employee.</param>
		/// <param name="dateTime">The date time.</param>
		/// <param name="employeeGroup">The employee group.</param>
		/// <returns>The created time table entry.</returns>
		public static TimeTableEntry AddTimeTableEntryDetailDialog( Employee employee , DateTime dateTime, EmployeeGroup employeeGroup ) {
			TimeTableEntry timeTableEntryToReturn = null;
			TimeTableEntry newTimeTableEntry = new TimeTableEntry();
			newTimeTableEntry.Employee = employee;
			newTimeTableEntry.Date = dateTime.Date;
			newTimeTableEntry.From = new DateTime( dateTime.Year , dateTime.Month , dateTime.Day , 9 , 0 , 0 );
			newTimeTableEntry.To = new DateTime( dateTime.Year , dateTime.Month , dateTime.Day , 10 , 0 , 0 );
			TimeTableEntryDetailDialog dialog = new TimeTableEntryDetailDialog( employeeGroup , newTimeTableEntry );
			dialog.SubHeaderText = "Nieuwe uurroosterplanning inschrijving...";
			if( dialog.ShowDialog() == DialogResult.OK ) {
				try {
					timeTableEntryToReturn =
						SwmSuiteFacade.TimeTableFacade.CreateTimeTableEntry( dialog.TimeTableEntry );
				} catch( SwmSuiteException e ) {

				}
			}
			return timeTableEntryToReturn;
		}

		#endregion

	}
}
