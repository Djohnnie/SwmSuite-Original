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
	
	public partial class RecurrenceDialog : Form {
	
		#region -_ Private Members _-

		private bool _createFlag;

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the recurrence associated
		/// with this <see cref="RecurrenceDialog"/>.
		/// </summary>
		/// <value>The recurrence to get or set.</value>
		public Recurrence Recurrence { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="RecurrenceDialog"/> class.
		/// </summary>
		public RecurrenceDialog() {
			_createFlag = true;
			InitializeComponent();
			this.Recurrence = new Recurrence();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="recurrence"/> class.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to use.</param>
		public RecurrenceDialog( Recurrence recurrence ) {
			_createFlag = false;
			InitializeComponent();
			this.Recurrence = recurrence;
		}

		#endregion

		#region -_ Form Event Handlers _-

		private void RecurrenceDialog_Load( object sender , EventArgs e ) {
			



			dailyRadioButton.Checked = this.Recurrence.RecurrenceMode == RecurrenceMode.Daily;
			weeklyRadioButton.Checked = this.Recurrence.RecurrenceMode == RecurrenceMode.Weekly;
			monhlyRadioButton.Checked = this.Recurrence.RecurrenceMode == RecurrenceMode.Monthly;
			yearlyRadioButton.Checked = this.Recurrence.RecurrenceMode == RecurrenceMode.Yearly;

			everyDayRadioButton.Checked = !this.Recurrence.EveryWeekDay;
			everyWeekDayRadioButton.Checked = this.Recurrence.EveryWeekDay;
			everyDayNumericUpDown.Value = this.Recurrence.Every;

			everyWeekNumericUpDown.Value = this.Recurrence.Every;
			mondayCheckBox.Checked = this.Recurrence.Days.Monday;
			tuesdayCheckBox.Checked = this.Recurrence.Days.Tuesday;
			wednesdayCheckBox.Checked = this.Recurrence.Days.Wednesday;
			thursdayCheckBox.Checked = this.Recurrence.Days.Thursday;
			fridayCheckBox.Checked = this.Recurrence.Days.Friday;
			saturdayCheckBox.Checked = this.Recurrence.Days.Saturday;
			sundayCheckBox.Checked = this.Recurrence.Days.Sunday;

			startDateMonthCalendar.SelectionStart = this.Recurrence.StartDate;
			startDateMonthCalendar.SelectionEnd = this.Recurrence.StartDate;
			endDateRadioButton.Checked = this.Recurrence.EndMode == RecurrenceEndMode.ByDate;
			endDateMonthCalendar.SelectionStart = this.Recurrence.EndDate;
			endDateMonthCalendar.SelectionEnd = this.Recurrence.EndDate;
			endAfterRadioButton.Checked = this.Recurrence.EndMode == RecurrenceEndMode.ByNumber;
			neverEndRadioButton.Checked = this.Recurrence.EndMode == RecurrenceEndMode.Infinite;

			dialogHeaderControl.MainText = "Herhaling";
			dialogHeaderControl.SubText = _createFlag ? "Een nieuwe herhaling definiëren..." : "Een bestaande herhaling aanpassen...";
		}

		private void okButton_Click( object sender , EventArgs e ) {

		}

		/// <summary>
		/// Handles the CheckedChanged event of the dailyRadioButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void dailyRadioButton_CheckedChanged( object sender , EventArgs e ) {
			if( dailyRadioButton.Checked ) {
				SelectRecurrenceMode( RecurrenceMode.Daily );
			}
		}

		/// <summary>
		/// Handles the CheckedChanged event of the weeklyRadioButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void weeklyRadioButton_CheckedChanged( object sender , EventArgs e ) {
			if( weeklyRadioButton.Checked ) {
				SelectRecurrenceMode( RecurrenceMode.Weekly );
			}
		}

		/// <summary>
		/// Handles the CheckedChanged event of the monhlyRadioButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void monhlyRadioButton_CheckedChanged( object sender , EventArgs e ) {
			if( monhlyRadioButton.Checked ) {
				SelectRecurrenceMode( RecurrenceMode.Monthly );
			}
		}

		/// <summary>
		/// Handles the CheckedChanged event of the yearlyRadioButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void yearlyRadioButton_CheckedChanged( object sender , EventArgs e ) {
			if( yearlyRadioButton.Checked ) {
				SelectRecurrenceMode( RecurrenceMode.Yearly );
			}
		}

		/// <summary>
		/// Handles the CheckedChanged event of the endDateRadioButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void endDateRadioButton_CheckedChanged( object sender , EventArgs e ) {
			endDateMonthCalendar.Enabled = endDateRadioButton.Checked;
		}

		/// <summary>
		/// Handles the CheckedChanged event of the endAfterRadioButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void endAfterRadioButton_CheckedChanged( object sender , EventArgs e ) {
			endAfterNumericUpDown.Enabled = endAfterRadioButton.Checked;
		}

		/// <summary>
		/// Handles the CheckedChanged event of the neverEndRadioButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void neverEndRadioButton_CheckedChanged( object sender , EventArgs e ) {

		}

		#endregion

		#region -_ Private Methods _-

		/// <summary>
		/// Set controls for the given recurrencemode.
		/// </summary>
		/// <param name="recurrenceMode">The recurrence mode.</param>
		private void SelectRecurrenceMode( RecurrenceMode recurrenceMode ) {
			dailyPanel.Visible = recurrenceMode == RecurrenceMode.Daily;
			weeklyPanel.Visible = recurrenceMode == RecurrenceMode.Weekly;
			monthlyPanel.Visible = recurrenceMode == RecurrenceMode.Monthly;
			yearlyPanel.Visible = recurrenceMode == RecurrenceMode.Yearly;
		}

		#endregion

		
	}

}
