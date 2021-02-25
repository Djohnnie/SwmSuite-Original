using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using SimpleWorkfloorManagementSuite.Dialogs;
using SwmSuite.Presentation.Drawing.VistaRenderer;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Proxy.Interface;

namespace SimpleWorkfloorManagementSuite.Modules {

	public partial class TaskManagementModule : UserControl {

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

		/// <summary>
		/// Initializes a new instance of the <see cref="TaskManagementModule"/> class.
		/// </summary>
		public TaskManagementModule() {
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
		/// Handles the Load event of the TaskManagementModule control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void TaskManagementModule_Load( object sender , EventArgs e ) {
			toolStrip.Renderer = new WindowsVistaRenderer();
		}

		/// <summary>
		/// Handles the Click event of the newTaskToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void newTaskToolStripButton_Click( object sender , EventArgs e ) {
			TaskDetailDialog dialog = new TaskDetailDialog();
			if( dialog.ShowDialog() == DialogResult.OK ) {
				SwmSuiteFacade.TaskFacade.CreateTask( dialog.Task );
				RefreshData();
			}
		}

		/// <summary>
		/// Handles the Click event of the pendingTasksToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void pendingTasksToolStripButton_Click( object sender , EventArgs e ) {
			UncheckAllMenuItems();
			pendingTasksToolStripButton.Checked = true;
			RefreshTaskData();
		}

		/// <summary>
		/// Handles the Click event of the finishedTasksToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void finishedTasksToolStripButton_Click( object sender , EventArgs e ) {
			UncheckAllMenuItems();
			finishedTasksToolStripButton.Checked = true;
			RefreshTaskData();
		}

		/// <summary>
		/// Handles the Click event of the dueTasksToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void dueTasksToolStripButton_Click( object sender , EventArgs e ) {
			UncheckAllMenuItems();
			dueTasksToolStripButton.Checked = true;
			RefreshTaskData();
		}

		/// <summary>
		/// Handles the Click event of the allTasksToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void allTasksToolStripButton_Click( object sender , EventArgs e ) {
			UncheckAllMenuItems();
			allTasksToolStripButton.Checked = true;
			RefreshTaskData();
		}

		/// <summary>
		/// Handles the AfterSelect event of the employeeTreeView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.TreeViewEventArgs"/> instance containing the event data.</param>
		private void employeeTreeView_AfterSelect( object sender , TreeViewEventArgs e ) {
			RefreshTaskData();
		}

		/// <summary>
		/// Handles the SelectedTaskChanged event of the taskBrowserViewControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="SimpleWorkfloorManagementSuite.Controls.SelectedTaskChangedEventArgs"/> instance containing the event data.</param>
		private void taskBrowserViewControl_SelectedTaskChanged( object sender , SimpleWorkfloorManagementSuite.Controls.SelectedTaskChangedEventArgs e ) {
			taskContentsControl.SetTask( e.Task );
			taskDetailControl1.SetTask( e.Task );
		}

		/// <summary>
		/// Handles the Click event of the previousYearToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void previousYearToolStripButton_Click( object sender , EventArgs e ) {
			this.Year--;
			RefreshTaskData();
		}

		/// <summary>
		/// Handles the Click event of the nextYearToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void nextYearToolStripButton_Click( object sender , EventArgs e ) {
			this.Year++;
			RefreshTaskData();
		}

		#endregion

		#region -_ Public Methods _-

		public void RefreshData() {
			RefreshEmployeeTreeView();
		}

		#endregion

		#region -_ Private Methods _-

		private void RefreshEmployeeTreeView() {
			employeeTreeView.Nodes.Clear();

			EmployeeGroupCollection employeeGroups = SwmSuiteFacade.EmployeeFacade.GetEmployeeGroups();
			EmployeeCollection employees = SwmSuiteFacade.EmployeeFacade.GetEmployees();

			// Create root node.
			TreeNode rootNode = new TreeNode( "Iedereen" );
			rootNode.Tag = employees;
			rootNode.ImageIndex = 0;
			rootNode.SelectedImageIndex = 0;

			foreach( EmployeeGroup employeeGroup in employeeGroups ) {

				EmployeeCollection employeesInGroup =
					SwmSuiteFacade.EmployeeFacade.GetEmployeesForEmployeeGroup( employeeGroup );

				TreeNode employeeGroupTreeNode = new TreeNode( employeeGroup.Name );
				employeeGroupTreeNode.Tag = employeesInGroup;
				employeeGroupTreeNode.ImageIndex = 1;
				employeeGroupTreeNode.SelectedImageIndex = 1;

				foreach( Employee employee in employeesInGroup ) {
					TreeNode employeeTreeNode = new TreeNode( employee.FullName );
					employeeTreeNode.Tag = EmployeeCollection.FromSingleEmployee( employee );
					employeeTreeNode.ImageIndex = 2;
					employeeTreeNode.SelectedImageIndex = 2;
					employeeGroupTreeNode.Nodes.Add( employeeTreeNode );
				}

				rootNode.Nodes.Add( employeeGroupTreeNode );
			}

			employeeTreeView.Nodes.Add( rootNode );
			employeeTreeView.ExpandAll();
			employeeTreeView.SelectedNode = rootNode;
		}

		private void UncheckAllMenuItems() {
			pendingTasksToolStripButton.Checked = false;
			finishedTasksToolStripButton.Checked = false;
			dueTasksToolStripButton.Checked = false;
			allTasksToolStripButton.Checked = false;
		}

		private void RefreshTaskData() {
			TaskCollection tasks = new TaskCollection();
			if( employeeTreeView.SelectedNode != null ) {
				EmployeeCollection selectedEmployees =
					(EmployeeCollection)employeeTreeView.SelectedNode.Tag;
				foreach( Employee employee in selectedEmployees ) {
					if( pendingTasksToolStripButton.Checked ) {
						tasks.Add( SwmSuiteFacade.TaskFacade.GetPendingTasksForEmployee( employee , this.Year ) );
					}
					if( finishedTasksToolStripButton.Checked ) {
						tasks.Add( SwmSuiteFacade.TaskFacade.GetCompletedTasksForEmployee( employee , this.Year ) );
						tasks.Add( SwmSuiteFacade.TaskFacade.GetFailedTasksForEmployee( employee , this.Year ) );
					}
					if( dueTasksToolStripButton.Checked ) {
						tasks.Add( SwmSuiteFacade.TaskFacade.GetOverDueTasksForEmployee( employee , this.Year ) );
					}
					if( allTasksToolStripButton.Checked ) {
						tasks.Add( SwmSuiteFacade.TaskFacade.GetTasksForEmployee( employee , this.Year ) );
					}
				}
			}
			taskBrowserViewControl.SetTasks( tasks );
		}

		#endregion

	}

}
