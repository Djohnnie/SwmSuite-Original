using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Presentation.Common.TimeTable;
using SwmSuite.Presentation.Drawing.VistaRenderer;
using SwmSuite.Proxy.Interface;
using SwmSuite.Framework.Exceptions;

namespace SimpleWorkfloorManagementSuite.Dialogs {

	/// <summary>
	/// 
	/// </summary>
	public partial class TimeTableEntryManagementDialog : Form {

		#region -_ Private Members _-

		private Employee _employee;
		private DateTime _date;
		private EmployeeGroup _employeeGroup;

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the time table entries.
		/// </summary>
		/// <value>The time table entries.</value>
		public TimeTableEntryCollection TimeTableEntries { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTableEntryManagementDialog"/> class.
		/// </summary>
		/// <param name="employee">The employee.</param>
		/// <param name="date">The date.</param>
		/// <param name="employeeGroup">The employee group.</param>
		public TimeTableEntryManagementDialog( Employee employee , DateTime date , EmployeeGroup employeeGroup ) {
			InitializeComponent();
			_employee = employee;
			_date = date;
			_employeeGroup = employeeGroup;
			toolStrip.Renderer = new WindowsVistaRenderer();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTableEntryManagementDialog"/> class.
		/// </summary>
		/// <param name="employee">The employee.</param>
		/// <param name="date">The date.</param>
		/// <param name="employeeGroup">The employee group.</param>
		/// <param name="timeTableEntries">The time table entries.</param>
		public TimeTableEntryManagementDialog( Employee employee , DateTime date , EmployeeGroup employeeGroup , TimeTableEntryCollection timeTableEntries )
			: this( employee , date , employeeGroup ) {
			this.TimeTableEntries = timeTableEntries;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTableEntryManagementDialog"/> class.
		/// </summary>
		/// <param name="employee">The employee.</param>
		/// <param name="date">The date.</param>
		/// <param name="employeeGroup">The employee group.</param>
		/// <param name="timeTableControlEntries">The time table control entries.</param>
		public TimeTableEntryManagementDialog( Employee employee , DateTime date , EmployeeGroup employeeGroup , TimeTableControlEntryCollection timeTableControlEntries )
			: this( employee , date , employeeGroup ) {
			this.TimeTableEntries = new TimeTableEntryCollection();
			List<int> timeTableEntrySysIds = new List<int>();
			foreach( TimeTableControlEntry entry in timeTableControlEntries ) {
				this.TimeTableEntries.Add( (TimeTableEntry)entry.Tag );
			}
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Load event of the TimeTableEntriesDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void TimeTableEntriesDialog_Load( object sender , EventArgs e ) {
			if( this.TimeTableEntries != null ) {
				timeTableEntriesBrowser.SetTimeTableData( this.TimeTableEntries );
				dialogHeaderControl.SubText = "voor " + _employee.FullName + " op " + _date.ToShortDateString();
			}
		}

		/// <summary>
		/// Handles the Click event of the addToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void addToolStripButton_Click( object sender , EventArgs e ) {
			TimeTableEntry entry =
				TimeTableEntryDetailDialog.AddTimeTableEntryDetailDialog( _employee , _date , _employeeGroup );
			if( entry != null ) {
				this.TimeTableEntries.Add( entry );
				timeTableEntriesBrowser.SetTimeTableData( this.TimeTableEntries );
			}
		}

		/// <summary>
		/// Handles the Click event of the editToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void editToolStripButton_Click( object sender , EventArgs e ) {
			TimeTableEntry timeTableEntry = (TimeTableEntry)timeTableEntriesBrowser.SelectedItems[0].Tag;
			timeTableEntry = TimeTableEntryDetailDialog.EditTimeTableEntryDetailDialog( _employeeGroup , timeTableEntry );
			timeTableEntriesBrowser.SetTimeTableData( this.TimeTableEntries );
		}

		/// <summary>
		/// Handles the Click event of the removeToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void removeToolStripButton_Click( object sender , EventArgs e ) {
			if( QueryDialog.ShowQueryDialog( "Uurrooster inschrijvingen" , "bent u zeker dat u de geselecteerde inschrijvingen wilt verwijderen?" ) == DialogResult.Yes ) {
				try {
					TimeTableEntryCollection timeTableEntriesToRemove = new TimeTableEntryCollection();
					foreach( ListViewItem selectedListViewItem in timeTableEntriesBrowser.SelectedItems ) {
						timeTableEntriesToRemove.Add( (TimeTableEntry)selectedListViewItem.Tag );
					}
					SwmSuiteFacade.TimeTableFacade.RemoveTimeTableEntries( timeTableEntriesToRemove );
					this.TimeTableEntries.Remove( timeTableEntriesToRemove );
					timeTableEntriesBrowser.SetTimeTableData( this.TimeTableEntries );
				} catch( SwmSuiteException exception ) {
					ErrorDialog.ShowErrorDialog( exception.Message );
				}
			}
		}

		/// <summary>
		/// Handles the SelectedIndexChanged event of the timeTableEntriesBrowser control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void timeTableEntriesBrowser_SelectedIndexChanged( object sender , EventArgs e ) {
			if( timeTableEntriesBrowser.SelectedItems.Count == 0 ) {
				addToolStripButton.Enabled = true;
				editToolStripButton.Enabled = false;
				removeToolStripButton.Enabled = false;
			} else if( timeTableEntriesBrowser.SelectedItems.Count == 1 ) {
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
		/// Handles the DoubleClick event of the timeTableEntriesBrowser control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void timeTableEntriesBrowser_DoubleClick( object sender , EventArgs e ) {
			editToolStripButton.PerformClick();
		}

		#endregion

		#region -_ Static Methods _-

		/// <summary>
		/// Shows the time table entries dialog.
		/// </summary>
		/// <param name="employee">The employee.</param>
		/// <param name="date">The date.</param>
		/// <param name="employeeGroup">The employee group.</param>
		/// <param name="timeTableEntries">The time table entries.</param>
		/// <returns>
		/// The new timetable entries if accepted, null if canceled.
		/// </returns>
		public static TimeTableEntryCollection ShowTimeTableEntriesDialog( Employee employee , DateTime date , EmployeeGroup employeeGroup , TimeTableEntryCollection timeTableEntries ) {
			TimeTableEntryCollection timeTableEntriesToReturn = null;
			TimeTableEntryManagementDialog dialog = new TimeTableEntryManagementDialog( employee , date , employeeGroup , timeTableEntries );
			if( dialog.ShowDialog() == DialogResult.OK ) {
				timeTableEntriesToReturn = dialog.TimeTableEntries;
			}
			return timeTableEntriesToReturn;
		}

		/// <summary>
		/// Shows the time table entries dialog.
		/// </summary>
		/// <param name="employee">The employee.</param>
		/// <param name="date">The date.</param>
		/// <param name="employeeGroup">The employee group.</param>
		/// <param name="timeTableControlEntries">The time table control entries.</param>
		/// <returns>
		/// The new timetable entries if accepted, null if canceled.
		/// </returns>
		public static TimeTableEntryCollection ShowTimeTableEntriesDialog( Employee employee , DateTime date , EmployeeGroup employeeGroup , TimeTableControlEntryCollection timeTableControlEntries ) {
			TimeTableEntryCollection timeTableEntriesToReturn = null;
			TimeTableEntryManagementDialog dialog = new TimeTableEntryManagementDialog( employee , date , employeeGroup , timeTableControlEntries );
			if( dialog.ShowDialog() == DialogResult.OK ) {
				timeTableEntriesToReturn = dialog.TimeTableEntries;
			}
			return timeTableEntriesToReturn;
		}

		#endregion

	}
}
