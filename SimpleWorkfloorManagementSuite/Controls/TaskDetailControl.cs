using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Presentation.Common.StatusGroup;

namespace SimpleWorkfloorManagementSuite.Controls {

	/// <summary>
	/// Usercontrol representing a task detail.
	/// </summary>
	public partial class TaskDetailControl : UserControl {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the task.
		/// </summary>
		/// <value>The task.</value>
		public Task Task { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="TaskDetailControl"/> class.
		/// </summary>
		public TaskDetailControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );
		}

		#endregion

		#region -_ Public methods _-

		/// <summary>
		/// Sets the task.
		/// </summary>
		/// <param name="task">The task to set.</param>
		public void SetTask( Task task ) {
			if( task == null ) {
			} else {
				subjectLabel.Text = task.Title;
				deadlineLabel.Text = task.Deadline.HasValue ? task.Deadline.Value.ToShortDateString() + " " + task.Deadline.Value.ToShortTimeString() : "Geen";
				commissionerLabel.Text = task.Commissioner.FullName;
				employeeLabel.Text = task.Employee.FullName;
				descriptionTextBox.Text = task.Description;

				if( task.TaskRun == null ) {
					commentsLabel.Visible = false;
					commentsTextBox.Visible = false;
					splitContainer.SplitterDistance = splitContainer.Height;
					if( task.IsOverDue ) {
						statusGroup.Status = StatusGroupStatus.Invalid;
					} else {
						statusGroup.Status = StatusGroupStatus.Warn;
					}
					taskRunTitleLabel.Visible = false;
					taskRunLabel.Visible = false;
				} else {
					commentsLabel.Visible = true;
					commentsTextBox.Visible = true;
					commentsTextBox.Text = task.TaskRun.Remarks;
					taskRunLabel.Text = task.TaskRun.Finished.ToShortDateString() + " " + task.TaskRun.Finished.ToShortTimeString();
					splitContainer.SplitterDistance = splitContainer.Height / 2;
					if( task.IsFinished ) {
						statusGroup.Status = StatusGroupStatus.Good;
					}
					if( task.IsFailed ) {
						statusGroup.Status = StatusGroupStatus.Bad;
					}
					taskRunTitleLabel.Visible = true;
					taskRunLabel.Visible = true;
				}
			}
		}

		#endregion

	}

}
