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

namespace SimpleWorkfloorManagementSuite.Dialogs {

	public partial class BrowseForSingleEmployeeDialog : Form {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the employee.
		/// </summary>
		/// <value>The employee.</value>
		public Employee Employee { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="BrowseForSingleEmployeeDialog"/> class.
		/// </summary>
		public BrowseForSingleEmployeeDialog() {
			InitializeComponent();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BrowseForSingleEmployeeDialog"/> class.
		/// </summary>
		/// <param name="employee">The employee.</param>
		public BrowseForSingleEmployeeDialog( Employee employee )
			: this() {
			this.Employee = employee;
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Load event of the BrowseForSingleEmployeeDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void BrowseForSingleEmployeeDialog_Load( object sender , EventArgs e ) {
			LoadEmployeeTree();
		}

		/// <summary>
		/// Handles the NodeMouseDoubleClick event of the employeesTreeView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.TreeNodeMouseClickEventArgs"/> instance containing the event data.</param>
		private void employeesTreeView_NodeMouseDoubleClick( object sender , TreeNodeMouseClickEventArgs e ) {
			Employee selectedEmployee = e.Node.Tag as Employee;
			if( selectedEmployee != null ) {
				this.Employee = selectedEmployee;
				okButton.PerformClick();
			}
		}

		/// <summary>
		/// Handles the Click event of the okButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void okButton_Click( object sender , EventArgs e ) {
			Employee selectedEmployee = employeesTreeView.SelectedNode.Tag as Employee;
			if( selectedEmployee != null ) {
				this.Employee = selectedEmployee;
			}
		}

		/// <summary>
		/// Handles the AfterSelect event of the employeesTreeView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.TreeViewEventArgs"/> instance containing the event data.</param>
		private void employeesTreeView_AfterSelect( object sender , TreeViewEventArgs e ) {
			Employee selectedEmployee = employeesTreeView.SelectedNode.Tag as Employee;
			if( selectedEmployee != null ) {
				okButton.Enabled = true;
			} else {
				okButton.Enabled = false;
			}
		}

		#endregion

		#region -_ Private Methods _-

		private void LoadEmployeeTree() {
			EmployeeCollection allEmployees = SwmSuiteFacade.EmployeeFacade.GetEmployees();
			TreeNode rootNode = new TreeNode( "Iedereen" );
			rootNode.Tag = allEmployees;
			rootNode.ImageIndex = 0;
			rootNode.SelectedImageIndex = 0;

			EmployeeGroupCollection employeeGroups = SwmSuiteFacade.EmployeeFacade.GetEmployeeGroups();
			foreach( EmployeeGroup employeeGroup in employeeGroups ) {
				EmployeeCollection employees = SwmSuiteFacade.EmployeeFacade.GetEmployeesForEmployeeGroup( employeeGroup );
				TreeNode newTreeNode = new TreeNode( employeeGroup.Name );
				newTreeNode.ForeColor = Color.Blue;
				newTreeNode.Tag = employees;
				newTreeNode.ImageIndex = 1;
				newTreeNode.SelectedImageIndex = 1;
				foreach( Employee employee in employees ) {
					TreeNode childNode = new TreeNode( employee.FirstName + " " + employee.Name );
					childNode.Tag = employee;
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

		#endregion

		#region -_ Static Methods _-

		public static Employee BrowseForSingleEmployee( Employee employee ) {
			Employee employeeToReturn = employee;
			BrowseForSingleEmployeeDialog dialog = new BrowseForSingleEmployeeDialog( employee );
			if( dialog.ShowDialog() == DialogResult.OK ) {
				employeeToReturn = dialog.Employee;
			}
			return employeeToReturn;
		}

		#endregion

	}

}
