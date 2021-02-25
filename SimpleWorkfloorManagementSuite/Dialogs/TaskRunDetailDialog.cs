using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.BusinessObjects;

namespace SimpleWorkfloorManagementSuite.Dialogs {
	
	public partial class TaskRunDetailDialog : Form {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the task run.
		/// </summary>
		/// <value>The task run.</value>
		public TaskRun TaskRun { get; set; }

		/// <summary>
		/// Gets or sets the task.
		/// </summary>
		/// <value>The task.</value>
		public Task Task { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="EndTaskDialog"/> class.
		/// </summary>
		public TaskRunDetailDialog() {
			InitializeComponent();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="EndTaskDialog"/> class.
		/// </summary>
		/// <param name="task">The task.</param>
		public TaskRunDetailDialog( Task task ) {
			InitializeComponent();
			this.Task = task;
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Click event of the okButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void okButton_Click( object sender , EventArgs e ) {
			this.TaskRun = new TaskRun();
			this.TaskRun.Finished = new DateTime(
				monthCalendar.SelectionStart.Year , monthCalendar.SelectionStart.Month , monthCalendar.SelectionStart.Day ,
				timePicker.Value.Hour , timePicker.Value.Minute , timePicker.Value.Second );
			this.TaskRun.Remarks = remarksTextBox.Client.Text;
			if( taskSuccesfullRadioButton.Checked ) {
				this.TaskRun.Mode = SwmSuite.Data.Common.TaskRunMode.TaskFinished;
			}
			if( taskFailedRadioButton.Checked ) {
				this.TaskRun.Mode = SwmSuite.Data.Common.TaskRunMode.TaskFailed;
			}
			this.TaskRun.Task = this.Task;
		}

		#endregion

		private void TaskRunDetailDialog_Load( object sender , EventArgs e ) {
			monthCalendar.SelectionStart = DateTime.Today;
			monthCalendar.SelectionEnd = DateTime.Today;
			timePicker.Value = DateTime.Now;
			Validate();
		}

		#region -_ Validation _-

		private void Validate() {
			okButton.Enabled = ValidateComments();
		}

		private bool ValidateComments() {
			bool valid = !String.IsNullOrEmpty( remarksTextBox.Client.Text );
			remarksTextBox.DoError( !valid );
			return valid;
		}

		#endregion

		private void remarksTextBox_TextChanged( object sender , EventArgs e ) {
			Validate();
		}

	}

}
