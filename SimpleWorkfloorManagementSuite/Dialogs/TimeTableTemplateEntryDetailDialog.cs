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
	public partial class TimeTableTemplateEntryDetailDialog : Form {

		#region -_ Private Members _-

		private EmployeeGroup _employeeGroup;

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the time table entry.
		/// </summary>
		/// <value>The time table entry.</value>
		public TimeTableTemplateEntry TimeTableTemplateEntry { get; set; }

		/// <summary>
		/// Gets or sets the sub header text.
		/// </summary>
		/// <value>The sub header text.</value>
		public String SubHeaderText { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTableTemplateEntryDetailDialog"/> class.
		/// </summary>
		/// <param name="employeeGroup">The employee group.</param>
		public TimeTableTemplateEntryDetailDialog( EmployeeGroup employeeGroup ) {
			InitializeComponent();
			_employeeGroup = employeeGroup;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTableTemplateEntryDetailDialog"/> class.
		/// </summary>
		/// <param name="employeeGroup">The employee group.</param>
		/// <param name="timeTableTemplateEntry">The time table entry.</param>
		public TimeTableTemplateEntryDetailDialog( EmployeeGroup employeeGroup , TimeTableTemplateEntry timeTableTemplateEntry )
			: this( employeeGroup ) {
			this.TimeTableTemplateEntry = timeTableTemplateEntry;
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Click event of the browseForTimeTablePurposeButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void browseForTimeTablePurposeButton_Click( object sender , EventArgs e ) {
			this.TimeTableTemplateEntry.TimeTablePurpose =
				BrowseForTimeTablePurposeDialog.ShowBrowseForTimeTablePurposeDialog( _employeeGroup , this.TimeTableTemplateEntry.TimeTablePurpose );
			if( this.TimeTableTemplateEntry.TimeTablePurpose != null ) {
				timeTablePurposeTextBox.Client.Text = this.TimeTableTemplateEntry.TimeTablePurpose.Description;
			} else {
				timeTablePurposeTextBox.Client.Text = String.Empty;
			}
		}

		/// <summary>
		/// Handles the Load event of the TimeTableTemplateEntryDetailDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void TimeTableTemplateEntryDetailDialog_Load( object sender , EventArgs e ) {
			dialogHeaderControl.SubText = this.SubHeaderText;

			startDateTimePicker.Value = this.TimeTableTemplateEntry.From;
			stopDateTimePicker.Value = this.TimeTableTemplateEntry.To;
			if( this.TimeTableTemplateEntry.TimeTablePurpose != null ) {
				timeTablePurposeTextBox.Client.Text = this.TimeTableTemplateEntry.TimeTablePurpose.Description;
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
			this.TimeTableTemplateEntry.From = startDateTimePicker.Value;
			this.TimeTableTemplateEntry.To = stopDateTimePicker.Value;
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
		/// <param name="timeTableTemplateEntry">The time table entry to edit.</param>
		/// <returns>The updated time table entry.</returns>
		public static TimeTableTemplateEntry EditTimeTableTemplateEntryDetailDialog( EmployeeGroup employeeGroup , TimeTableTemplateEntry timeTableTemplateEntry ) {
			TimeTableTemplateEntry timeTableTemplateEntryToReturn = null;
			TimeTableTemplateEntryDetailDialog dialog = new TimeTableTemplateEntryDetailDialog( employeeGroup , timeTableTemplateEntry );
			dialog.SubHeaderText = "Uurroosterplanning inschrijving aanpassen...";
			if( dialog.ShowDialog() == DialogResult.OK ) {
				try {
					timeTableTemplateEntryToReturn =
						SwmSuiteFacade.TimeTableFacade.UpdateTimeTableTemplateEntry( dialog.TimeTableTemplateEntry );
				} catch( SwmSuiteException e ) {

				}
			}
			return timeTableTemplateEntryToReturn;
		}

		/// <summary>
		/// Shows the time table entry detail dialog for adding a new entry.
		/// </summary>
		/// <param name="employee">The employee.</param>
		/// <param name="dateTime">The date time.</param>
		/// <param name="employeeGroup">The employee group.</param>
		/// <returns>The created time table entry.</returns>
		public static TimeTableTemplateEntry AddTimeTableTemplateEntryDetailDialog( TimeTableTemplate timeTableTemplate , DateTime dateTime, EmployeeGroup employeeGroup ) {
			TimeTableTemplateEntry timeTableTemplateEntryToReturn = null;
			TimeTableTemplateEntry newTimeTableTemplateEntry = new TimeTableTemplateEntry();
			newTimeTableTemplateEntry.Date = dateTime.Date;
			newTimeTableTemplateEntry.From = new DateTime( dateTime.Year , dateTime.Month , dateTime.Day , 9 , 0 , 0 );
			newTimeTableTemplateEntry.To = new DateTime( dateTime.Year , dateTime.Month , dateTime.Day , 10 , 0 , 0 );
			TimeTableTemplateEntryDetailDialog dialog = new TimeTableTemplateEntryDetailDialog( employeeGroup , newTimeTableTemplateEntry );
			dialog.SubHeaderText = "Nieuwe uurroosterplanning inschrijving...";
			if( dialog.ShowDialog() == DialogResult.OK ) {
				try {
					timeTableTemplateEntryToReturn =
						SwmSuiteFacade.TimeTableFacade.CreateTimeTableTemplateEntry( dialog.TimeTableTemplateEntry , timeTableTemplate );
				} catch( SwmSuiteException e ) {

				}
			}
			return timeTableTemplateEntryToReturn;
		}

		#endregion

	}
}
