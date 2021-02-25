using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Proxy.Interface;

namespace SimpleWorkfloorManagementSuite.Dialogs {

	public partial class BrowserForEmployeeDialog : Form {

		#region -_ Public Properties _-

		public EmployeeCollection Employees { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="BrowserForEmployeeDialog"/> class.
		/// </summary>
		public BrowserForEmployeeDialog( EmployeeCollection employees ) {
			InitializeComponent();
			this.Employees = employees;
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Load event of the BrowserForEmployeeDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void BrowserForEmployeeDialog_Load( object sender , EventArgs e ) {
			this.Cursor = Cursors.WaitCursor;
			backgroundWorker.RunWorkerAsync();
		}

		/// <summary>
		/// Handles the Click event of the addButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void addButton_Click( object sender , EventArgs e ) {
			AddEmployee();
		}

		/// <summary>
		/// Handles the Click event of the removeButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void removeButton_Click( object sender , EventArgs e ) {
			RemoveEmployee();
		}

		/// <summary>
		/// Handles the Click event of the okButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void okButton_Click( object sender , EventArgs e ) {
			this.Employees.Clear();
			foreach( ListViewItem listViewItem in employeesBrowserView.Items ) {
				this.Employees.Add( (Employee)listViewItem.Tag );
			}
		}

		/// <summary>
		/// Handles the NodeMouseDoubleClick event of the employeesTreeView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.TreeNodeMouseClickEventArgs"/> instance containing the event data.</param>
		private void employeesTreeView_NodeMouseDoubleClick( object sender , TreeNodeMouseClickEventArgs e ) {
			AddEmployee();
		}

		/// <summary>
		/// Handles the MouseDoubleClick event of the employeesBrowserView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
		private void employeesBrowserView_MouseDoubleClick( object sender , MouseEventArgs e ) {
			RemoveEmployee();
		}

		/// <summary>
		/// Handles the DoWork event of the backgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
		private void backgroundWorker_DoWork( object sender , DoWorkEventArgs e ) {
			e.Result = SwmSuiteFacade.EmployeeFacade.GetEmployeeGroups();
		}

		/// <summary>
		/// Handles the RunWorkerCompleted event of the backgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
		private void backgroundWorker_RunWorkerCompleted( object sender , RunWorkerCompletedEventArgs e ) {
			LoadEmployeeTree( (EmployeeGroupCollection)e.Result );
			LoadEmployeeList();
			this.Cursor = Cursors.Default;
		}

		#endregion

		#region -_ Private Methods _-

		private void LoadEmployeeList() {
			foreach( Employee employee in this.Employees ) {
				ListViewItem newListViewItem = new ListViewItem( employee.FirstName + " " + employee.Name );
				newListViewItem.Tag = employee;
				employeesBrowserView.Items.Add( newListViewItem );
			}
		}

		private void LoadEmployeeTree( EmployeeGroupCollection employeeGroups ) {
			TreeNode rootNode = new TreeNode( "Iedereen" );
			rootNode.Tag = employeeGroups.GetEmployees();
			rootNode.ImageIndex = 0;
			rootNode.SelectedImageIndex = 0;

			foreach( EmployeeGroup employeeGroup in employeeGroups ) {
				TreeNode newTreeNode = new TreeNode( employeeGroup.Name );
				newTreeNode.ForeColor = Color.Blue;
				newTreeNode.Tag = employeeGroup.Employees;
				newTreeNode.ImageIndex = 1;
				newTreeNode.SelectedImageIndex = 1;
				foreach( Employee employee in employeeGroup.Employees ) {
					TreeNode childNode = new TreeNode( employee.FirstName + " " + employee.Name );
					childNode.Tag = EmployeeCollection.FromSingleEmployee( employee );
					childNode.ImageIndex = 2;
					childNode.SelectedImageIndex = 2;
					newTreeNode.Nodes.Add( childNode );
				}
				rootNode.Nodes.Add( newTreeNode );
			}

			employeesTreeView.Nodes.Add( rootNode );
			employeesTreeView.ExpandAll();
			rootNode.EnsureVisible();
		}

		private bool EmployeeSelected( Employee employee ) {
			bool found = false;
			foreach( ListViewItem listViewItem in employeesBrowserView.Items ) {
				if( ( (Employee)listViewItem.Tag ).SysId == employee.SysId ) {
					found = true;
				}
			}
			return found;
		}



		private void AddEmployee() {
			if( employeesTreeView.SelectedNode != null ) {
				EmployeeCollection selectedEmployees =
					(EmployeeCollection)employeesTreeView.SelectedNode.Tag;
				foreach( Employee employee in selectedEmployees ) {
					if( !EmployeeSelected( employee ) ) {
						ListViewItem newListViewItem = new ListViewItem( employee.FirstName + " " + employee.Name );
						newListViewItem.Tag = employee;
						employeesBrowserView.Items.Add( newListViewItem );
					}
				}
			}
		}

		private void RemoveEmployee() {
			if( employeesBrowserView.SelectedItems.Count > 0 ) {
				foreach( ListViewItem selectedItem in employeesBrowserView.SelectedItems ) {
					employeesBrowserView.Items.Remove( selectedItem );
				}
			}
		}

		#endregion

	}

}
