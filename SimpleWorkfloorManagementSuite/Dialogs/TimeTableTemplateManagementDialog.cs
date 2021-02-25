using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwmSuite.Presentation.Drawing.VistaRenderer;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Proxy.Interface;
using SwmSuite.Framework.Exceptions;

namespace SimpleWorkfloorManagementSuite.Dialogs {

	public partial class TimeTableTemplateManagementDialog : Form {

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTableTemplateManagementDialog"/> class.
		/// </summary>
		public TimeTableTemplateManagementDialog() {
			InitializeComponent();
			toolStrip.Renderer = new WindowsVistaRenderer();
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Load event of the TimeTableTemplateManagementDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void TimeTableTemplateManagementDialog_Load( object sender , EventArgs e ) {
			LoadEmployeeGroups();
		}

		#endregion

		#region -_ Private Methods _-

		/// <summary>
		/// Loads the employee groups.
		/// </summary>
		private void LoadEmployeeGroups() {
			employeeGroupBrowserView.Items.Clear();
			EmployeeGroupCollection employeeGroups = SwmSuiteFacade.EmployeeFacade.GetEmployeeGroups();
			foreach( EmployeeGroup employeeGroup in employeeGroups ) {
				ListViewItem newListViewItem = new ListViewItem( employeeGroup.Name );
				newListViewItem.Tag = employeeGroup;
				employeeGroupBrowserView.Items.Add( newListViewItem );
			}
		}

		/// <summary>
		/// Loads the time table templates.
		/// </summary>
		private void LoadTimeTableTemplates() {
			timeTableTemplateBrowserView.Items.Clear();
			if( employeeGroupBrowserView.SelectedItems.Count == 1 ) {
				EmployeeGroup selectedEmployeeGroup = (EmployeeGroup)employeeGroupBrowserView.SelectedItems[0].Tag;
				TimeTableTemplateCollection timeTableTemplates =
					SwmSuiteFacade.TimeTableFacade.GetTimeTableTemplatesForEmployeeGroup( selectedEmployeeGroup );
				foreach( TimeTableTemplate timeTableTemplate in timeTableTemplates ) {
					ListViewItem newListViewItem = new ListViewItem( timeTableTemplate.Name );
					newListViewItem.Tag = timeTableTemplate;
					timeTableTemplateBrowserView.Items.Add( newListViewItem );
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
		/// Handles the Click event of the addToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void addToolStripButton_Click( object sender , EventArgs e ) {
			EmployeeGroup selectedEmployeeGroup = (EmployeeGroup)employeeGroupBrowserView.SelectedItems[0].Tag;
			TimeTableTemplateDetailDialog.AddTimeTableTemplateDetailDialog( selectedEmployeeGroup );
			LoadTimeTableTemplates();
		}

		/// <summary>
		/// Handles the Click event of the editToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void editToolStripButton_Click( object sender , EventArgs e ) {
			EmployeeGroup selectedEmployeeGroup = (EmployeeGroup)employeeGroupBrowserView.SelectedItems[0].Tag;
			TimeTableTemplate selectedTimeTableTemplate = (TimeTableTemplate)timeTableTemplateBrowserView.SelectedItems[0].Tag;
			TimeTableTemplateDetailDialog.EditTimeTableTemplateDetailDialog( selectedTimeTableTemplate , selectedEmployeeGroup );
			LoadTimeTableTemplates();
		}

		/// <summary>
		/// Handles the Click event of the removeToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void removeToolStripButton_Click( object sender , EventArgs e ) {
			if( QueryDialog.ShowQueryDialog( "Uurrooster sjablonen" , "bent u zeker dat u de geselecteerde sjablonen wilt verwijderen?" ) == DialogResult.Yes ) {
				try {
					TimeTableTemplateCollection timeTableTemplatesToRemove = new TimeTableTemplateCollection();
					foreach( ListViewItem selectedListViewItem in timeTableTemplateBrowserView.SelectedItems ) {
						timeTableTemplatesToRemove.Add( (TimeTableTemplate)selectedListViewItem.Tag );
					}
					SwmSuiteFacade.TimeTableFacade.RemoveTimeTableTemplates( timeTableTemplatesToRemove );
					LoadTimeTableTemplates();
				} catch( SwmSuiteException exception ) {
					ErrorDialog.ShowErrorDialog( exception.Message );
				}
			}
		}

		/// <summary>
		/// Handles the SelectedIndexChanged event of the employeeGroupBrowserView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void employeeGroupBrowserView_SelectedIndexChanged( object sender , EventArgs e ) {
			LoadTimeTableTemplates();
		}

		/// <summary>
		/// Handles the SelectedIndexChanged event of the timeTableTemplateBrowserView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void timeTableTemplateBrowserView_SelectedIndexChanged( object sender , EventArgs e ) {
			if( timeTableTemplateBrowserView.SelectedItems.Count == 0 ) {
				addToolStripButton.Enabled = true;
				editToolStripButton.Enabled = false;
				removeToolStripButton.Enabled = false;
			} else if( timeTableTemplateBrowserView.SelectedItems.Count == 1 ) {
				addToolStripButton.Enabled = true;
				editToolStripButton.Enabled = true;
				removeToolStripButton.Enabled = true;
			} else {
				addToolStripButton.Enabled = true;
				editToolStripButton.Enabled = false;
				removeToolStripButton.Enabled = true;
			}
		}

		/// <summary>
		/// Handles the DoubleClick event of the timeTableTemplateBrowserView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void timeTableTemplateBrowserView_DoubleClick( object sender , EventArgs e ) {
			editToolStripButton.PerformClick();
		}

		#endregion
	}
}
