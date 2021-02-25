using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.Common;

namespace SimpleWorkfloorManagementSuite.Dialogs {

	/// <summary>
	/// Class defining a form to create a new overtime entry.
	/// </summary>
	public partial class OvertimeEntryDetailDialog : Form {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the overtime entry.
		/// </summary>
		/// <value>The overtime entry.</value>
		public OvertimeEntry OvertimeEntry { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="NewOvertimeEntryDialog"/> class.
		/// </summary>
		public OvertimeEntryDetailDialog() {
			InitializeComponent();
			this.OvertimeEntry = new OvertimeEntry();
		}

		#endregion

		#region -_ Event Handling _-

		/// <summary>
		/// Handles the Load event of the NewOvertimeEntryDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void NewOvertimeEntryDialog_Load( object sender , EventArgs e ) {
			beginTimePicker.Value = new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , DateTime.Now.Hour , 0 , 0 );
			endTimePicker.Value = new DateTime( DateTime.Today.Year , DateTime.Today.Month , DateTime.Today.Day , DateTime.Now.Hour + 1 , 0 , 0 );
			ValidateAll();
		}

		/// <summary>
		/// Handles the Click event of the okButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void okButton_Click( object sender , EventArgs e ) {
			this.OvertimeEntry.Employee = SwmSuitePrincipal.CurrentEmployee;
			this.OvertimeEntry.OvertimeStatus = OvertimeStatus.Pending;
			this.OvertimeEntry.Commissioner = (Employee)commissionerTextBox.Tag;
			this.OvertimeEntry.DateTimeStart = new DateTime(
				dateTimePicker.Value.Year , dateTimePicker.Value.Month , dateTimePicker.Value.Day ,
				beginTimePicker.Value.Hour , beginTimePicker.Value.Minute , beginTimePicker.Value.Second );
			this.OvertimeEntry.DateTimeEnd = new DateTime(
				dateTimePicker.Value.Year , dateTimePicker.Value.Month , dateTimePicker.Value.Day ,
				endTimePicker.Value.Hour , endTimePicker.Value.Minute , endTimePicker.Value.Second );
			this.OvertimeEntry.Description = descriptionTextBox.Client.Text;
		}

		/// <summary>
		/// Handles the Click event of the browseForEmployeeButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void browseForEmployeeButton_Click( object sender , EventArgs e ) {
			Employee commissionerEmployee =
				BrowseForSingleEmployeeDialog.BrowseForSingleEmployee( (Employee)commissionerTextBox.Tag );
			if( commissionerEmployee != null ) {
				commissionerTextBox.Client.Text = commissionerEmployee.FullName;
				commissionerTextBox.Tag = commissionerEmployee;
			}
		}

		#endregion

		#region -_ Validation _-

		private void ValidateAll() {
			bool commissionerIsValid = ValidateCommissioner();
			bool timeRangeIsValid = ValidateTimeRange();
			bool descriptionIsValid = ValidateDescription();
			okButton.Enabled =
				commissionerIsValid &&
				timeRangeIsValid &&
				descriptionIsValid;
		}

		/// <summary>
		/// Validate the "commissioner" field.
		/// </summary>
		/// <returns>True if the field appears to be valid, false otherwise.</returns>
		private bool ValidateCommissioner() {
			bool valueToReturn = !String.IsNullOrEmpty( commissionerTextBox.Client.Text );
			commissionerTextBox.DoError( !valueToReturn );
			return valueToReturn;
		}

		/// <summary>
		/// Validate the "time range" fields.
		/// </summary>
		/// <returns>True if the field appears to be valid, false otherwise.</returns>
		private bool ValidateTimeRange() {
			DateTime dateTimeStart = beginTimePicker.Value;
			DateTime dateTimeEnd = endTimePicker.Value;
			bool valueToReturn = dateTimeStart < dateTimeEnd;
			return valueToReturn;
		}

		/// <summary>
		/// Validate the "description" field.
		/// </summary>
		/// <returns>True if the field appears to be valid, false otherwise.</returns>
		private bool ValidateDescription() {
			bool valueToReturn = !String.IsNullOrEmpty( descriptionTextBox.Client.Text );
			descriptionTextBox.DoError( !valueToReturn );
			return valueToReturn;
		}

		#endregion

		private void commissionerTextBox_TextChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		private void descriptionTextBox_TextChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		private void beginTimePicker_ValueChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		private void endTimePicker_ValueChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

	}

}
