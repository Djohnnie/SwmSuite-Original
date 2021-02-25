using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;

namespace SimpleWorkfloorManagementSuite.Dialogs {

	public partial class TimeTableTemplateSelectionDialog : Form {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the time table template.
		/// </summary>
		/// <value>The time table template.</value>
		public TimeTableTemplate TimeTableTemplate { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTableTemplateSelectionDialog"/> class.
		/// </summary>
		public TimeTableTemplateSelectionDialog() {
			InitializeComponent();
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Load event of the TimeTableTemplateSelectionDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void TimeTableTemplateSelectionDialog_Load( object sender , EventArgs e ) {
			this.Cursor = Cursors.WaitCursor;
			employeeGroupBackgroundWorker.RunWorkerAsync();
		}

		/// <summary>
		/// Handles the DoWork event of the employeeGroupBackgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
		private void employeeGroupBackgroundWorker_DoWork( object sender , DoWorkEventArgs e ) {
			e.Result = SwmSuiteFacade.EmployeeFacade.GetEmployeeGroups();
		}

		/// <summary>
		/// Handles the RunWorkerCompleted event of the employeeGroupBackgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
		private void employeeGroupBackgroundWorker_RunWorkerCompleted( object sender , RunWorkerCompletedEventArgs e ) {
			EmployeeGroupCollection employeeGroups = (EmployeeGroupCollection)e.Result;
			foreach( EmployeeGroup employeeGroup in employeeGroups ) {
				TreeNode employeeGroupTreeNode = new TreeNode( employeeGroup.Name );
				TimeTableTemplateCollection timeTableTemplates =
					SwmSuiteFacade.TimeTableFacade.GetTimeTableTemplatesForEmployeeGroup( employeeGroup );
				employeeGroupTreeNode.Tag = timeTableTemplates;
				employeeGroupTreeNode.ImageIndex = 1;
				employeeGroupTreeNode.SelectedImageIndex = 1;

				foreach( TimeTableTemplate timeTableTemplate in timeTableTemplates ) {
					TreeNode timeTableTemplateTreeNode = new TreeNode( timeTableTemplate.Name );
					timeTableTemplateTreeNode.Tag = timeTableTemplate;
					timeTableTemplateTreeNode.ImageIndex = 2;
					timeTableTemplateTreeNode.SelectedImageIndex = 2;
					employeeGroupTreeNode.Nodes.Add( timeTableTemplateTreeNode );
				}

				employeeTreeView.Nodes.Add( employeeGroupTreeNode );
			}
			employeeTreeView.ExpandAll();
			this.Cursor = Cursors.Default;
		}

		/// <summary>
		/// Handles the AfterSelect event of the employeeTreeView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.TreeViewEventArgs"/> instance containing the event data.</param>
		private void employeeTreeView_AfterSelect( object sender , TreeViewEventArgs e ) {
			TimeTableTemplate timeTableTemplate = e.Node.Tag as TimeTableTemplate;
			if( timeTableTemplate != null ) {
				okButton.Enabled = true;
				this.TimeTableTemplate = timeTableTemplate;
			} else {
				okButton.Enabled = false;
				this.TimeTableTemplate = null;
			}
		}

		/// <summary>
		/// Handles the Click event of the okButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void okButton_Click( object sender , EventArgs e ) {
		}

		#endregion
		
	}
}
