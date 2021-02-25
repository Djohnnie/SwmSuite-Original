using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using SimpleWorkfloorManagementSuite.Dialogs;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;

using SwmSuite.Presentation.Drawing.VistaRenderer;
using SwmSuite.Framework.Exceptions;

namespace SimpleWorkfloorManagementSuite.Modules {

	public partial class StaffManagementModule : UserControl {

		#region -_ Private Members _-

		//private IEmployeeFacade _employeeFacade = ServiceBroker.CreateBroker().CreateEmployeeFacade();
		//private IEmployeeFacade _employeeGroupFacade = ServiceBroker.CreateBroker().CreateEmployeeFacade();

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public StaffManagementModule() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );

			employeeGroupToolStrip.Renderer = new WindowsVistaRenderer();
			employeeToolStrip.Renderer = new WindowsVistaRenderer();
		}

		#endregion

		#region -_ Public Methods _-

		public void RefreshData() {
			LoadEmployeeGroups();
		}

		#endregion

		#region -_ Private Methods _-

		private void LoadEmployeeGroups() {
			employeeGroupBackgroundWorker.RunWorkerAsync();
		}

		private void LoadEmployees() {
			if( employeeGroupBrowserView.SelectedItems.Count == 1 ) {
				EmployeeGroup selectedEmployeeGroup = (EmployeeGroup)
					employeeGroupBrowserView.SelectedItems[0].Tag;
				employeeBackgroundWorker.RunWorkerAsync( selectedEmployeeGroup );
			}
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Click event of the addEmployeeGroupToolstripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void addEmployeeGroupToolstripButton_Click( object sender , EventArgs e ) {
			EmployeeGroupDetailDialog dialog = new EmployeeGroupDetailDialog();
			if( dialog.ShowDialog() == DialogResult.OK ) {
				ServiceBroker.CreateBroker().CreateEmployeeFacade().CreateEmployeeGroup( dialog.EmployeeGroup );
				LoadEmployeeGroups();
			}
		}

		/// <summary>
		/// Handles the Click event of the editEmployeeGroupToolstripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void editEmployeeGroupToolstripButton_Click( object sender , EventArgs e ) {
			if( employeeGroupBrowserView.SelectedItems.Count == 1 ) {
				EmployeeGroup selectedEmployeeGroup = (EmployeeGroup)
					employeeGroupBrowserView.SelectedItems[0].Tag;
				EmployeeGroupDetailDialog dialog = new EmployeeGroupDetailDialog( selectedEmployeeGroup );
				if( dialog.ShowDialog() == DialogResult.OK ) {
					ServiceBroker.CreateBroker().CreateEmployeeFacade().UpdateEmployeeGroup( dialog.EmployeeGroup );
					LoadEmployeeGroups();
				}
			}
		}

		/// <summary>
		/// Handles the Click event of the deleteEmployeeGroupToolstripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void deleteEmployeeGroupToolstripButton_Click( object sender , EventArgs e ) {
			EmployeeGroupCollection employeeGroups = new EmployeeGroupCollection();
			foreach( ListViewItem selectedListViewItem in employeeGroupBrowserView.SelectedItems ) {
				employeeGroups.Add( (EmployeeGroup)selectedListViewItem.Tag );
			}
			try {
				SwmSuiteFacade.EmployeeFacade.RemoveEmployeeGroups( employeeGroups );
			} catch( SwmSuiteException exception ) {
				ErrorDialog.ShowErrorDialog( exception.Message );
			}
		}

		/// <summary>
		/// Handles the Click event of the addEmployeeToolstripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void addEmployeeToolstripButton_Click( object sender , EventArgs e ) {
			if( employeeGroupBrowserView.SelectedItems.Count == 1 ) {
				EmployeeGroup selectedEmployeeGroup = (EmployeeGroup)
					employeeGroupBrowserView.SelectedItems[0].Tag;
				EmployeeDetailDialog dialog = new EmployeeDetailDialog();
				if( dialog.ShowDialog() == DialogResult.OK ) {
					SwmSuiteFacade.EmployeeFacade.CreateEmployee( dialog.Employee , selectedEmployeeGroup );
					LoadEmployees();
				}
			}
		}

		/// <summary>
		/// Handles the Click event of the editEmployeeToolstripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void editEmployeeToolstripButton_Click( object sender , EventArgs e ) {
			if( employeeBrowserView.SelectedItems.Count == 1 ) {
				EmployeeGroup selectedEmployeeGroup = (EmployeeGroup)
					employeeGroupBrowserView.SelectedItems[0].Tag;
				EmployeeDetailDialog dialog = new EmployeeDetailDialog( (Employee)employeeBrowserView.SelectedItems[0].Tag );
				if( dialog.ShowDialog() == DialogResult.OK ) {
					SwmSuiteFacade.EmployeeFacade.UpdateEmployee( dialog.Employee , selectedEmployeeGroup );
					LoadEmployees();
				}
			}
		}

		/// <summary>
		/// Handles the Click event of the deleteEmployeeToolstripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void deleteEmployeeToolstripButton_Click( object sender , EventArgs e ) {
			EmployeeCollection employees = new EmployeeCollection();
			foreach( ListViewItem selectedListViewItem in employeeBrowserView.SelectedItems ) {
				employees.Add( (Employee)selectedListViewItem.Tag );
			}
			try {
				SwmSuiteFacade.EmployeeFacade.RemoveEmployees( employees );
			} catch( SwmSuiteException exception ) {
				ErrorDialog.ShowErrorDialog( exception.Message );
			}
		}

		#endregion

		private void employeeGroupBackgroundWorker_DoWork( object sender , DoWorkEventArgs e ) {
			IEmployeeFacade employeeGroupFacade = ServiceBroker.CreateBroker().CreateEmployeeFacade();
			EmployeeGroupCollection employeeGroups =
				employeeGroupFacade.GetEmployeeGroups();
			e.Result = employeeGroups;
		}

		private void employeeGroupBackgroundWorker_RunWorkerCompleted( object sender , RunWorkerCompletedEventArgs e ) {
			EmployeeGroupCollection employeeGroups = (EmployeeGroupCollection)e.Result;
			employeeGroupBrowserView.Items.Clear();
			foreach( EmployeeGroup employeeGroup in employeeGroups ) {
				ListViewItem newListViewItem = new ListViewItem(
					new String[] { employeeGroup.Name } );
				newListViewItem.Tag = employeeGroup;
				employeeGroupBrowserView.Items.Add( newListViewItem );
			}
		}

		private void employeeBackgroundWorker_DoWork( object sender , DoWorkEventArgs e ) {

		}

		private void employeeBackgroundWorker_RunWorkerCompleted( object sender , RunWorkerCompletedEventArgs e ) {

		}

		/// <summary>
		/// Handles the SelectedIndexChanged event of the employeeGroupBrowserView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void employeeGroupBrowserView_SelectedIndexChanged( object sender , EventArgs e ) {
			employeeBrowserView.Items.Clear();
			if( employeeGroupBrowserView.SelectedItems.Count == 1 ) {
				EmployeeGroup selectedEmployeeGroup =
					(EmployeeGroup)employeeGroupBrowserView.SelectedItems[0].Tag;
				EmployeeCollection employees =
					SwmSuiteFacade.EmployeeFacade.GetEmployeesForEmployeeGroup( selectedEmployeeGroup );
				foreach( Employee employee in employees ) {
					ListViewItem newListViewItem = new ListViewItem(
						new String[] { employee.FirstName , employee.Name } );
					newListViewItem.Tag = employee;
					employeeBrowserView.Items.Add( newListViewItem );
				}
			}

			if( employeeGroupBrowserView.SelectedItems.Count == 0 ) {
				addEmployeeGroupToolstripButton.Enabled = true;
				editEmployeeGroupToolstripButton.Enabled = false;
				deleteEmployeeGroupToolstripButton.Enabled = false;
			} else if( employeeGroupBrowserView.SelectedItems.Count == 1 ) {
				addEmployeeGroupToolstripButton.Enabled = true;
				editEmployeeGroupToolstripButton.Enabled = true;
				deleteEmployeeGroupToolstripButton.Enabled = true;
			} else {
				addEmployeeGroupToolstripButton.Enabled = true;
				editEmployeeGroupToolstripButton.Enabled = false;
				deleteEmployeeGroupToolstripButton.Enabled = true;
			}
		}

		/// <summary>
		/// Handles the SelectedIndexChanged event of the employeeBrowserView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void employeeBrowserView_SelectedIndexChanged( object sender , EventArgs e ) {
			if( employeeBrowserView.SelectedItems.Count == 0 ) {
				addEmployeeToolstripButton.Enabled = true;
				editEmployeeToolstripButton.Enabled = false;
				deleteEmployeeToolstripButton.Enabled = false;
			} else if( employeeBrowserView.SelectedItems.Count == 1 ) {
				addEmployeeToolstripButton.Enabled = true;
				editEmployeeToolstripButton.Enabled = true;
				deleteEmployeeToolstripButton.Enabled = true;
			} else {
				addEmployeeToolstripButton.Enabled = true;
				editEmployeeToolstripButton.Enabled = false;
				deleteEmployeeToolstripButton.Enabled = true;
			}
		}

		/// <summary>
		/// Handles the DoubleClick event of the employeeGroupBrowserView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void employeeGroupBrowserView_DoubleClick( object sender , EventArgs e ) {
			editEmployeeGroupToolstripButton.PerformClick();
		}

		/// <summary>
		/// Handles the DoubleClick event of the employeeBrowserView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void employeeBrowserView_DoubleClick( object sender , EventArgs e ) {
			editEmployeeToolstripButton.PerformClick();
		}

	}

}
