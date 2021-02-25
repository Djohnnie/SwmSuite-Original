using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.BusinessObjects;

using SwmSuite.Proxy.Interface;
using SwmSuite.Presentation.Common.TimeTable;
using SwmSuite.Framework;
using SwmSuite.Presentation.Drawing.VistaRenderer;
using SwmSuite.Data.BusinessObjects;

namespace SimpleWorkfloorManagementSuite.Modules {

	public partial class TimeTableModule : UserControl {

		#region -_ Construction _-

		public TimeTableModule() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );

			toolStrip.Renderer = new WindowsVistaRenderer();
		}

		#endregion

		#region -_ Public Methods _-

		public void RefreshData() {
			timeTable.Columns.Clear();
			occupationControl.Columns.Clear();

			// Get all employees in the current employeegroup.
			EmployeeCollection employees = SwmSuiteFacade.EmployeeFacade.GetEmployeesForEmployeeGroup( SwmSuitePrincipal.CurrentEmployeeGroup );
			foreach( Employee employee in employees ) {
				TimeTableColumn newTimeTableColumnForTimeTable = new TimeTableColumn();
				newTimeTableColumnForTimeTable.Caption = employee.FullName;
				newTimeTableColumnForTimeTable.Tag = employee;
				timeTable.Columns.Add( newTimeTableColumnForTimeTable );
				TimeTableColumn newTimeTableColumnForOccupation = new TimeTableColumn();
				newTimeTableColumnForOccupation.Caption = employee.FullName;
				newTimeTableColumnForOccupation.Tag = employee;
				occupationControl.Columns.Add( newTimeTableColumnForOccupation );
			}
			timeTable.Move( DateTime.Today );
			occupationControl.Move( DateTime.Today );
			occupationControl.Invalidate();

			selectionToolStripButton.Text =
				timeTable.Selection.StartOfWeek().ToString( "dd/MM/yyyy" ) + " - " + timeTable.Selection.EndOfWeek().ToString( "dd/MM/yyyy" );
		}

		#endregion

		#region -_ Private Methods _-

		private TimeTableControlEntryCollection GetTimeTableControlEntries( TimeTableEntryCollection timeTableEntries ) {
			TimeTableControlEntryCollection timeTableEntryCollectionToReturn = new TimeTableControlEntryCollection();
			foreach( TimeTableEntry timeTableEntry in timeTableEntries ) {
				TimeTableControlEntry newTimeTableControlEntry = new TimeTableControlEntry();
				newTimeTableControlEntry.Begin = timeTableEntry.From;
				newTimeTableControlEntry.End = timeTableEntry.To;
				newTimeTableControlEntry.BorderColor = timeTableEntry.TimeTablePurpose.Color1;
				newTimeTableControlEntry.BackColor1 = timeTableEntry.TimeTablePurpose.Color2;
				newTimeTableControlEntry.BackColor2 = timeTableEntry.TimeTablePurpose.Color3;
				newTimeTableControlEntry.Tag = timeTableEntry;
				newTimeTableControlEntry.Description = timeTableEntry.TimeTablePurpose.Description;
				timeTableEntryCollectionToReturn.Add( newTimeTableControlEntry );
			}
			return timeTableEntryCollectionToReturn;
		}

		/// <summary>
		/// Des the select all days.
		/// </summary>
		private void DeSelectAllDays() {
			mondayToolStripButton.Checked = false;
			tuesdayToolStripButton.Checked = false;
			wednesdayToolStripButton.Checked = false;
			thursdayToolStripButton.Checked = false;
			fridayToolStripButton.Checked = false;
			saturdayToolStripButton.Checked = false;
			sundayToolStripButton.Checked = false;
		}

		/// <summary>
		/// Changes the days visibility.
		/// </summary>
		/// <param name="visible">True for visible, false for invisible.</param>
		private void ChangeDaysVisibility( bool visible ) {
			mondayToolStripButton.Visible = visible;
			tuesdayToolStripButton.Visible = visible;
			wednesdayToolStripButton.Visible = visible;
			thursdayToolStripButton.Visible = visible;
			fridayToolStripButton.Visible = visible;
			saturdayToolStripButton.Visible = visible;
			sundayToolStripButton.Visible = visible;
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Click event of the previousToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void previousToolStripButton_Click( object sender , EventArgs e ) {
			timeTable.MovePreviousWeek();
			occupationControl.Move( occupationControl.Selection.AddDays( -7 ) );
			selectionToolStripButton.Text =
				timeTable.Selection.StartOfWeek().ToString( "dd/MM/yyyy" ) + " - " + timeTable.Selection.EndOfWeek().ToString( "dd/MM/yyyy" );
		}

		/// <summary>
		/// Handles the Click event of the nextToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void nextToolStripButton_Click( object sender , EventArgs e ) {
			timeTable.MoveNextWeek();
			occupationControl.Move( occupationControl.Selection.AddDays( 7 ) );
			selectionToolStripButton.Text =
				timeTable.Selection.StartOfWeek().ToString( "dd/MM/yyyy" ) + " - " + timeTable.Selection.EndOfWeek().ToString( "dd/MM/yyyy" );
		}

		/// <summary>
		/// Handles the Click event of the selectionToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void selectionToolStripButton_Click( object sender , EventArgs e ) {
			//timeTable.Move( 
		}

		/// <summary>
		/// Handles the DataNeeded event of the timeTable control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void timeTable_DataNeeded( object sender , EventArgs e ) {
			foreach( TimeTableColumn timeTableColumn in timeTable.Columns ) {
				timeTableColumn.TimeTableEntries.Clear();
				TimeTableEntryCollection timeTableEntries =
					SwmSuiteFacade.TimeTableFacade.GetTimeTableEntries( (Employee)timeTableColumn.Tag , timeTable.Selection.StartOfWeek() , timeTable.Selection.EndOfWeek() );
				timeTableColumn.TimeTableEntries = GetTimeTableControlEntries( timeTableEntries );
			}
		}

		/// <summary>
		/// Handles the DataNeeded event of the occupationControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void occupationControl_DataNeeded( object sender , EventArgs e ) {
			foreach( TimeTableColumn timeTableColumn in occupationControl.Columns ) {
				timeTableColumn.TimeTableEntries.Clear();
				TimeTableEntryCollection timeTableEntries =
					SwmSuiteFacade.TimeTableFacade.GetTimeTableEntries( (Employee)timeTableColumn.Tag , occupationControl.Selection , occupationControl.Selection );
				timeTableColumn.TimeTableEntries = GetTimeTableControlEntries( timeTableEntries );
			}
		}

		/// <summary>
		/// Handles the Click event of the timeTableToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void timeTableToolStripButton_Click( object sender , EventArgs e ) {
			timeTableToolStripButton.Checked = true;
			occupationToolStripButton.Checked = false;
			timeTable.Visible = true;
			occupationControl.Visible = false;

			ChangeDaysVisibility( false );
		}

		/// <summary>
		/// Handles the Click event of the occupationToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void occupationToolStripButton_Click( object sender , EventArgs e ) {
			occupationToolStripButton.Checked = true;
			timeTableToolStripButton.Checked = false;
			occupationControl.Visible = true;
			timeTable.Visible = false;

			ChangeDaysVisibility( true );
		}

		/// <summary>
		/// Handles the Click event of the mondayToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void mondayToolStripButton_Click( object sender , EventArgs e ) {
			DeSelectAllDays();
			mondayToolStripButton.Checked = true;
			occupationControl.Move( timeTable.Selection.StartOfWeek().AddDays( 0 ) );
		}

		/// <summary>
		/// Handles the Click event of the tuesdayToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void tuesdayToolStripButton_Click( object sender , EventArgs e ) {
			DeSelectAllDays();
			tuesdayToolStripButton.Checked = true;
			occupationControl.Move( timeTable.Selection.StartOfWeek().AddDays( 1 ) );
		}

		/// <summary>
		/// Handles the Click event of the wednesdayToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void wednesdayToolStripButton_Click( object sender , EventArgs e ) {
			DeSelectAllDays();
			wednesdayToolStripButton.Checked = true;
			occupationControl.Move( timeTable.Selection.StartOfWeek().AddDays( 2 ) );
		}

		/// <summary>
		/// Handles the Click event of the thursdayToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void thursdayToolStripButton_Click( object sender , EventArgs e ) {
			DeSelectAllDays();
			thursdayToolStripButton.Checked = true;
			occupationControl.Move( timeTable.Selection.StartOfWeek().AddDays( 3 ) );
		}

		/// <summary>
		/// Handles the Click event of the fridayToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void fridayToolStripButton_Click( object sender , EventArgs e ) {
			DeSelectAllDays();
			fridayToolStripButton.Checked = true;
			occupationControl.Move( timeTable.Selection.StartOfWeek().AddDays( 4 ) );
		}

		/// <summary>
		/// Handles the Click event of the saturdayToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void saturdayToolStripButton_Click( object sender , EventArgs e ) {
			DeSelectAllDays();
			saturdayToolStripButton.Checked = true;
			occupationControl.Move( timeTable.Selection.StartOfWeek().AddDays( 5 ) );
		}

		/// <summary>
		/// Handles the Click event of the sundayToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void sundayToolStripButton_Click( object sender , EventArgs e ) {
			DeSelectAllDays();
			sundayToolStripButton.Checked = true;
			occupationControl.Move( timeTable.Selection.StartOfWeek().AddDays( 6 ) );
		}

		#endregion

	}

}
