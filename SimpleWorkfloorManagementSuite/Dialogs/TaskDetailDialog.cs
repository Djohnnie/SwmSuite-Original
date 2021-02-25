using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.BusinessObjects;


namespace SimpleWorkfloorManagementSuite.Dialogs {
	
	public partial class TaskDetailDialog : Form {

		#region -_ Private Members _-

		private EmployeeCollection _employees;

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the task.
		/// </summary>
		/// <value>The task.</value>
		public Task Task { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="TaskManagementDetailDialog"/> class.
		/// </summary>
		public TaskDetailDialog() {
			InitializeComponent();
			this.Task = new Task();
			this.Task.Employees = new EmployeeCollection();
			this.Task.Commissioner = SwmSuitePrincipal.CurrentEmployee;
			this.Task.CreationDate = DateTime.Now;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TaskManagementDetailDialog"/> class.
		/// </summary>
		/// <param name="task">The task.</param>
		public TaskDetailDialog( Task task ) {
			InitializeComponent();
			this.Task = task;
		}

		#endregion

		#region -_ Private Methods _-

		private static String EmployeeLinkCollectionToString( EmployeeCollection employeeLinks ) {
			String stringToReturn = "";
			foreach( Employee employee in employeeLinks ) {
				bool lastItem = employeeLinks.IndexOf( employee ) == employeeLinks.Count - 1;
				stringToReturn += employee.FirstName + " " + employee.Name + ( lastItem ? "" : "; " );
			}
			return stringToReturn;
		}

		#endregion

		#region -_ Event Handling _-

		/// <summary>
		/// Handles the Click event of the browseForEmployeeButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void browseForEmployeeButton_Click( object sender , EventArgs e ) {
			BrowserForEmployeeDialog dialog = new BrowserForEmployeeDialog( this.Task.Employees );
			if( dialog.ShowDialog() == DialogResult.OK ) {
				this.Task.Employees = dialog.Employees;
				employeeTextBox.Client.Text = EmployeeLinkCollectionToString( this.Task.Employees );
			}
		}

		/// <summary>
		/// Handles the Click event of the okButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void okButton_Click( object sender , EventArgs e ) {
			this.Task.Description = descriptionTextBox.Client.Text;
			this.Task.Title = titleTextBox.Client.Text;
			if( deadlineCheckBox.Checked ) {
				this.Task.Deadline = new DateTime( monthCalendar.SelectionStart.Year , monthCalendar.SelectionStart.Month , monthCalendar.SelectionStart.Day , timePicker.Value.Hour , timePicker.Value.Minute , timePicker.Value.Second );
			} else {
				this.Task.Deadline = null;
			}
		}

		/// <summary>
		/// Handles the Load event of the TaskManagementDetailDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void TaskManagementDetailDialog_Load( object sender , EventArgs e ) {
			employeeTextBox.Client.Text = EmployeeLinkCollectionToString( this.Task.Employees );
			titleTextBox.Client.Text = this.Task.Title;
			descriptionTextBox.Client.Text = this.Task.Description;
			if( this.Task.Deadline.HasValue ) {
				deadlineCheckBox.Checked = true;
				monthCalendar.SelectionStart = this.Task.Deadline.Value;
				monthCalendar.SelectionEnd = this.Task.Deadline.Value;
				timePicker.Value = this.Task.Deadline.Value;
			} else {
				deadlineCheckBox.Checked = false;
			}

			ValidateAll();
		}

		/// <summary>
		/// Handles the TextChanged event of the employeeTextBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void employeeTextBox_TextChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		/// <summary>
		/// Handles the TextChanged event of the titleTextBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void titleTextBox_TextChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		/// <summary>
		/// Handles the TextChanged event of the descriptionTextBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void descriptionTextBox_TextChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		/// <summary>
		/// Handles the CheckedChanged event of the deadlineCheckBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void deadlineCheckBox_CheckedChanged( object sender , EventArgs e ) {
			monthCalendar.Enabled = deadlineCheckBox.Checked;
			timePicker.Enabled = deadlineCheckBox.Checked;

			ValidateAll();
		}

		/// <summary>
		/// Handles the DateChanged event of the monthCalendar control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.DateRangeEventArgs"/> instance containing the event data.</param>
		private void monthCalendar_DateChanged( object sender , DateRangeEventArgs e ) {
			ValidateAll();
		}

		#endregion

		#region -_ Validation _-

		private void ValidateAll() {
			bool employeesIsValid = ValidateEmployees();
			bool titleIsValid = ValidateTitle();
			bool descriptionIsValid = ValidateDescription();
			bool deadlineIsValid = ValidateDeadline();
			okButton.Enabled =
				employeesIsValid &&
				titleIsValid &&
				descriptionIsValid &&
				deadlineIsValid;
		}

		/// <summary>
		/// Validate the "employee" field.
		/// </summary>
		/// <returns>True if the field appears to be valid, false otherwise.</returns>
		private bool ValidateEmployees() {
			bool valueToReturn = !String.IsNullOrEmpty( employeeTextBox.Client.Text );
			employeeTextBox.DoError( !valueToReturn );
			return valueToReturn;
		}

		/// <summary>
		/// Validate the "title" field.
		/// </summary>
		/// <returns>True if the field appears to be valid, false otherwise.</returns>
		private bool ValidateTitle() {
			bool valueToReturn = !String.IsNullOrEmpty( titleTextBox.Client.Text );
			titleTextBox.DoError( !valueToReturn );
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

		/// <summary>
		/// Validate the "deadline" field.
		/// </summary>
		/// <returns>True if the field appears to be valid, false otherwise.</returns>
		private bool ValidateDeadline() {
			DateTime deadline = new DateTime( monthCalendar.SelectionStart.Year , monthCalendar.SelectionStart.Month , monthCalendar.SelectionStart.Day , timePicker.Value.Hour , timePicker.Value.Minute , timePicker.Value.Second );
			bool valueToReturn = !deadlineCheckBox.Checked || deadline > DateTime.Now;
			
			return valueToReturn;
		}

		#endregion	

	}

}
