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

	public partial class BrowseForTimeTablePurposeDialog : Form {

		#region -_ Private Members _-

		private EmployeeGroup _employeeGroup;

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the time table purpose.
		/// </summary>
		/// <value>The time table purpose.</value>
		public TimeTablePurpose TimeTablePurpose { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="BrowseForTimeTablePurposeDialog"/> class.
		/// </summary>
		public BrowseForTimeTablePurposeDialog( EmployeeGroup employeeGroup ) {
			InitializeComponent();
			_employeeGroup = employeeGroup;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BrowseForTimeTablePurposeDialog"/> class.
		/// </summary>
		/// <param name="timeTablePurpose">The time table purpose to defaultly select.</param>
		public BrowseForTimeTablePurposeDialog( EmployeeGroup employeeGroup , TimeTablePurpose timeTablePurpose )
			: this( employeeGroup ) {
			this.TimeTablePurpose = timeTablePurpose;
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Load event of the BrowseForTimeTablePurposeDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void BrowseForTimeTablePurposeDialog_Load( object sender , EventArgs e ) {
			TimeTablePurposeCollection timeTablePurposeCollection =
				SwmSuiteFacade.TimeTableFacade.GetTimeTablePurposesForEmployeeGroup( _employeeGroup );
			foreach( TimeTablePurpose purpose in timeTablePurposeCollection ) {
				ListViewItem newListViewItem = new ListViewItem( purpose.Description );
				newListViewItem.Tag = purpose;
				timeTablePurposesBrowserView.Items.Add( newListViewItem );
				if( this.TimeTablePurpose != null ) {
					if( purpose.SysId == this.TimeTablePurpose.SysId ) {
						newListViewItem.Selected = true;
					}
				}
			}
		}

		/// <summary>
		/// Handles the SelectedIndexChanged event of the timeTablePurposesBrowserView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void timeTablePurposesBrowserView_SelectedIndexChanged( object sender , EventArgs e ) {
			if( timeTablePurposesBrowserView.SelectedItems.Count == 1 && timeTablePurposesBrowserView.SelectedItems[0].Tag is TimeTablePurpose ) {
				okButton.Enabled = true;
			} else {
				okButton.Enabled = false;
			}
		}

		/// <summary>
		/// Handles the Click event of the okButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void okButton_Click( object sender , EventArgs e ) {
			this.TimeTablePurpose = (TimeTablePurpose)timeTablePurposesBrowserView.SelectedItems[0].Tag;
		}

		/// <summary>
		/// Handles the DoubleClick event of the timeTablePurposesBrowserView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void timeTablePurposesBrowserView_DoubleClick( object sender , EventArgs e ) {
			okButton.PerformClick();
		}

		#endregion

		#region -_ Static Methods _-

		/// <summary>
		/// Shows the browse for time table purpose dialog.
		/// </summary>
		/// <param name="employeeGroup">The employee group.</param>
		/// <param name="timeTablePurpose">The time table purpose.</param>
		/// <returns>The selected timetable purpose.</returns>
		public static TimeTablePurpose ShowBrowseForTimeTablePurposeDialog( EmployeeGroup employeeGroup , TimeTablePurpose timeTablePurpose ) {
			TimeTablePurpose timeTablePurposeToReturn = timeTablePurpose;
			BrowseForTimeTablePurposeDialog dialog = new BrowseForTimeTablePurposeDialog( employeeGroup , timeTablePurpose );
			if( dialog.ShowDialog() == DialogResult.OK ) {
				timeTablePurposeToReturn = dialog.TimeTablePurpose;
			}
			return timeTablePurposeToReturn;
		}

		#endregion

	}

}
