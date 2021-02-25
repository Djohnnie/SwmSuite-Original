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
	
	public partial class BrowserForEmployeeGroupDialog : Form {

		#region -_ Public Properties _-

		public EmployeeGroupCollection EmployeeGroups { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="BrowserForEmployeeGroupDialog"/> class.
		/// </summary>
		public BrowserForEmployeeGroupDialog( EmployeeGroupCollection employeeGroups ) {
			InitializeComponent();
			this.EmployeeGroups = employeeGroups;
		}

		#endregion

		/// <summary>
		/// Handles the Load event of the BrowserForEmployeeDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void BrowserForEmployeeDialog_Load( object sender , EventArgs e ) {
			LoadEmployeeTree();
			LoadEmployeeList();
		}

		private void LoadEmployeeList() {
			foreach( EmployeeGroup employeeGroup in this.EmployeeGroups ) {
				ListViewItem newListViewItem = new ListViewItem( employeeGroup.Name );
				newListViewItem.Tag = employeeGroup;
				employeesBrowserView.Items.Add( newListViewItem );
			}
		}

		private void LoadEmployeeTree() {
			EmployeeGroupCollection employeeGroups = SwmSuiteFacade.EmployeeFacade.GetEmployeeGroups();
			foreach( EmployeeGroup employeeGroup in employeeGroups ) {
				TreeNode newTreeNode = new TreeNode( employeeGroup.Name );
				newTreeNode.ForeColor = Color.Blue;
				newTreeNode.Tag = employeeGroup;
				employeesTreeView.Nodes.Add( newTreeNode );
			}
			employeesTreeView.ExpandAll();
		}

		private bool EmployeeGroupSelected( EmployeeGroup employeeGroup ) {
			bool found = false;
			foreach( ListViewItem listViewItem in employeesBrowserView.Items ) {
				if( (EmployeeGroup)listViewItem.Tag == employeeGroup ) {
					found = true;
				}
			}
			return found;
		}

		private void addButton_Click( object sender , EventArgs e ) {
			AddEmployeeGroup();
		}

		private void AddEmployeeGroup() {
			if( employeesTreeView.SelectedNode != null ) {
				EmployeeGroup selectedEmployeeGroup =
					(EmployeeGroup)employeesTreeView.SelectedNode.Tag;
				if( !EmployeeGroupSelected( selectedEmployeeGroup ) ) {
					ListViewItem newListViewItem = new ListViewItem( selectedEmployeeGroup.Name );
					newListViewItem.Tag = selectedEmployeeGroup;
					employeesBrowserView.Items.Add( newListViewItem );
				}
			}
		}

		private void removeButton_Click( object sender , EventArgs e ) {

		}

		private void okButton_Click( object sender , EventArgs e ) {
			this.EmployeeGroups.Clear();
			foreach( ListViewItem listViewItem in employeesBrowserView.Items ) {
				this.EmployeeGroups.Add( (EmployeeGroup)listViewItem.Tag );
			}
		}

		private void employeesTreeView_NodeMouseDoubleClick( object sender , TreeNodeMouseClickEventArgs e ) {
			AddEmployeeGroup();
		}

	}

}
