using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using SwmSuite.Presentation.Drawing.VistaRenderer;
using SwmSuite.Proxy.Interface;

using SwmSuite.Data.BusinessObjects;
using SimpleWorkfloorManagementSuite.Dialogs;
using SwmSuite.Framework.Exceptions;

namespace SimpleWorkfloorManagementSuite.Modules {

	public partial class TaskModule : UserControl {

		#region -_ Private Members _-

		private int _year;

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the year.
		/// </summary>
		/// <value>The year.</value>
		public int Year {
			get {
				return _year;
			}
			set {
				_year = value;
				yearToolStripLabel.Text = value.ToString();
			}
		}

		#endregion

		#region -_ Construction _-

		public TaskModule() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );

			this.Year = DateTime.Now.Year;
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Load event of the TaskModule control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void TaskModule_Load( object sender , EventArgs e ) {
			toolStrip.Renderer = new WindowsVistaRenderer();
		}

		/// <summary>
		/// Handles the SelectedTaskChanged event of the taskBrowserViewControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="SimpleWorkfloorManagementSuite.Controls.SelectedTaskChangedEventArgs"/> instance containing the event data.</param>
		private void taskBrowserViewControl_SelectedTaskChanged( object sender , SimpleWorkfloorManagementSuite.Controls.SelectedTaskChangedEventArgs e ) {
			taskContentsControl.SetTask( e.Task );
			taskDetailControl.SetTask( e.Task );
			endTasksToolStripButton.Tag = e.Task;
			endTasksToolStripButton.Enabled = e.Task != null && e.Task.TaskRun == null;
		}

		/// <summary>
		/// Handles the Click event of the pendingTasksToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void pendingTasksToolStripButton_Click( object sender , EventArgs e ) {
			UncheckAllMenuItems();
			pendingTasksToolStripButton.Checked = true;

			RefreshData();
		}

		/// <summary>
		/// Handles the Click event of the finishedTasksToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void finishedTasksToolStripButton_Click( object sender , EventArgs e ) {
			UncheckAllMenuItems();
			finishedTasksToolStripButton.Checked = true;

			RefreshData();
		}

		/// <summary>
		/// Handles the Click event of the dueTasksToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void dueTasksToolStripButton_Click( object sender , EventArgs e ) {
			UncheckAllMenuItems();
			dueTasksToolStripButton.Checked = true;

			RefreshData();
		}

		/// <summary>
		/// Handles the Click event of the allTasksToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void allTasksToolStripButton_Click( object sender , EventArgs e ) {
			UncheckAllMenuItems();
			allTasksToolStripButton.Checked = true;

			RefreshData();
		}

		#endregion

		#region -_ Private Methods _-

		private void UncheckAllMenuItems() {
			pendingTasksToolStripButton.Checked = false;
			finishedTasksToolStripButton.Checked = false;
			dueTasksToolStripButton.Checked = false;
			allTasksToolStripButton.Checked = false;
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Refreshes the data.
		/// </summary>
		public void RefreshData() {
			if( pendingTasksToolStripButton.Checked ) {
				taskBrowserViewControl.SetTasks(
				SwmSuiteFacade.TaskFacade.GetPendingTasksForEmployee( SwmSuitePrincipal.CurrentEmployee , this.Year) );
			}
			if( finishedTasksToolStripButton.Checked ) {
				TaskCollection tasksToSet = new TaskCollection();
				tasksToSet.Add(
					SwmSuiteFacade.TaskFacade.GetCompletedTasksForEmployee( SwmSuitePrincipal.CurrentEmployee , this.Year ) );
				tasksToSet.Add(
					SwmSuiteFacade.TaskFacade.GetFailedTasksForEmployee( SwmSuitePrincipal.CurrentEmployee , this.Year ) );
				taskBrowserViewControl.SetTasks( tasksToSet );
			}
			if( dueTasksToolStripButton.Checked ) {
				taskBrowserViewControl.SetTasks(
				SwmSuiteFacade.TaskFacade.GetOverDueTasksForEmployee( SwmSuitePrincipal.CurrentEmployee , this.Year ) );
			}
			if( allTasksToolStripButton.Checked ) {
				taskBrowserViewControl.SetTasks(
				SwmSuiteFacade.TaskFacade.GetTasksForEmployee( SwmSuitePrincipal.CurrentEmployee , this.Year ) );
			}
		}

		#endregion

		/// <summary>
		/// Handles the Click event of the endTasksToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void endTasksToolStripButton_Click( object sender , EventArgs e ) {
			TaskRunDetailDialog endTaskDialog = new TaskRunDetailDialog( (Task)endTasksToolStripButton.Tag );
			if( endTaskDialog.ShowDialog() == DialogResult.OK ) {
				try {
					SwmSuiteFacade.TaskFacade.CompleteTask( endTaskDialog.TaskRun );
				} catch( SwmSuiteException exception ) {
					ErrorDialog.ShowErrorDialog( exception.Message );
				}
			}
		}

		/// <summary>
		/// Handles the Click event of the previousYearToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void previousYearToolStripButton_Click( object sender , EventArgs e ) {
			this.Year--;
			RefreshData();
		}

		/// <summary>
		/// Handles the Click event of the nextYearToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void nextYearToolStripButton_Click( object sender , EventArgs e ) {
			this.Year++;
			RefreshData();
		}

	}

}
