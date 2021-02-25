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
using SwmSuite.Presentation.Drawing.VistaRenderer;
using SwmSuite.Framework.Exceptions;

namespace SimpleWorkfloorManagementSuite.Dialogs {

	public partial class TimeTablePurposeManagementDialog : Form {

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTablePurposeManagementDialog"/> class.
		/// </summary>
		public TimeTablePurposeManagementDialog() {
			InitializeComponent();
			toolStrip.Renderer = new WindowsVistaRenderer();
		}

		/// <summary>
		/// Handles the Click event of the addToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void addToolStripButton_Click( object sender , EventArgs e ) {
			TimeTablePurposeDetailDialog timeTablePurposeDetailDialog = new TimeTablePurposeDetailDialog();
			if( timeTablePurposeDetailDialog.ShowDialog() == DialogResult.OK ) {
				EmployeeGroup selectedEmployeeGroup = (EmployeeGroup)employeeGroupBrowserView.SelectedItems[0].Tag;
				SwmSuiteFacade.TimeTableFacade.CreateTimeTablePurpose( timeTablePurposeDetailDialog.TimeTablePurpose , selectedEmployeeGroup );
				LoadTimeTablePurposes();
			}
		}

		/// <summary>
		/// Handles the Click event of the editToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void editToolStripButton_Click( object sender , EventArgs e ) {
			if( timeTablePurposeBrowserView.SelectedItems.Count == 1 ) {
				TimeTablePurpose selectedTimeTablePurpose = (TimeTablePurpose)timeTablePurposeBrowserView.SelectedItems[0].Tag;
				TimeTablePurposeDetailDialog timeTablePurposeDetailDialog = new TimeTablePurposeDetailDialog( selectedTimeTablePurpose );
				if( timeTablePurposeDetailDialog.ShowDialog() == DialogResult.OK ) {
					EmployeeGroup selectedEmployeeGroup = (EmployeeGroup)employeeGroupBrowserView.SelectedItems[0].Tag;
					SwmSuiteFacade.TimeTableFacade.UpdateTimeTablePurpose( timeTablePurposeDetailDialog.TimeTablePurpose , selectedEmployeeGroup );
					LoadTimeTablePurposes();
				}
			}
		}

		/// <summary>
		/// Handles the Click event of the removeToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void removeToolStripButton_Click( object sender , EventArgs e ) {
			if( QueryDialog.ShowQueryDialog( "Uurrooster categorieën" , "bent u zeker dat u de geselecteerde categorieën wilt verwijderen?" ) == DialogResult.Yes ) {
				try {
					TimeTablePurposeCollection timeTablePurposesToRemove = new TimeTablePurposeCollection();
					foreach( ListViewItem selectedListViewItem in timeTablePurposeBrowserView.SelectedItems ) {
						timeTablePurposesToRemove.Add( (TimeTablePurpose)selectedListViewItem.Tag );
					}
					SwmSuiteFacade.TimeTableFacade.RemoveTimeTablePurposes( timeTablePurposesToRemove );
					LoadTimeTablePurposes();
				} catch( SwmSuiteException exception ) {
					ErrorDialog.ShowErrorDialog( exception.Message );
				}
			}
		}

		/// <summary>
		/// Handles the Load event of the TimeTablePurposeManagementDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void TimeTablePurposeManagementDialog_Load( object sender , EventArgs e ) {
			LoadEmployeeGroups();
		}

		private void LoadEmployeeGroups() {
			employeeGroupBrowserView.Items.Clear();
			EmployeeGroupCollection employeeGroups = SwmSuiteFacade.EmployeeFacade.GetEmployeeGroups();
			foreach( EmployeeGroup employeeGroup in employeeGroups ) {
				ListViewItem newListViewItem = new ListViewItem( employeeGroup.Name );
				newListViewItem.Tag = employeeGroup;
				employeeGroupBrowserView.Items.Add( newListViewItem );
			}
		}

		private void LoadTimeTablePurposes() {
			timeTablePurposeBrowserView.Items.Clear();
			if( employeeGroupBrowserView.SelectedItems.Count == 1 ) {
				EmployeeGroup selectedEmployeeGroup = (EmployeeGroup)employeeGroupBrowserView.SelectedItems[0].Tag;
				TimeTablePurposeCollection timeTablePurposes =
					SwmSuiteFacade.TimeTableFacade.GetTimeTablePurposesForEmployeeGroup( selectedEmployeeGroup );
				foreach( TimeTablePurpose timeTablePurpose in timeTablePurposes ) {
					ListViewItem newListViewItem = new ListViewItem( timeTablePurpose.Description );
					newListViewItem.Tag = timeTablePurpose;
					timeTablePurposeBrowserView.Items.Add( newListViewItem );
				}
				addToolStripButton.Enabled = true;
				editToolStripButton.Enabled = false;
				removeToolStripButton.Enabled = false;
			} else {
				addToolStripButton.Enabled = false;
				editToolStripButton.Enabled = false;
				removeToolStripButton.Enabled = false;
			}
		}

		/// <summary>
		/// Handles the SelectedIndexChanged event of the employeeGroupBrowserView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void employeeGroupBrowserView_SelectedIndexChanged( object sender , EventArgs e ) {
			LoadTimeTablePurposes();
		}

		/// <summary>
		/// Handles the SelectedIndexChanged event of the timeTablePurposeBrowserView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void timeTablePurposeBrowserView_SelectedIndexChanged( object sender , EventArgs e ) {
			if( employeeGroupBrowserView.SelectedItems.Count == 1 ) {
				if( timeTablePurposeBrowserView.SelectedItems.Count == 0 ) {
					addToolStripButton.Enabled = true;
					editToolStripButton.Enabled = false;
					removeToolStripButton.Enabled = false;
				} else if( timeTablePurposeBrowserView.SelectedItems.Count == 1 ) {
					addToolStripButton.Enabled = true;
					editToolStripButton.Enabled = true;
					removeToolStripButton.Enabled = true;
				} else {
					addToolStripButton.Enabled = true;
					editToolStripButton.Enabled = false;
					removeToolStripButton.Enabled = true;
				}
			} else {
				addToolStripButton.Enabled = false;
				editToolStripButton.Enabled = false;
				removeToolStripButton.Enabled = false;
			}
		}

		/// <summary>
		/// Handles the DoubleClick event of the timeTablePurposeBrowserView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void timeTablePurposeBrowserView_DoubleClick( object sender , EventArgs e ) {
			editToolStripButton.PerformClick();
		}

	}

}
