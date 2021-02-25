using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SwmSuite.Presentation.Drawing.VistaRenderer;
using SimpleWorkfloorManagementSuite.Dialogs;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Proxy.Interface;
using SwmSuite.Framework;
using SwmSuite.Presentation.Common.TimeTable;

namespace SimpleWorkfloorManagementSuite.Modules {

	public partial class TimeTableManagementModule : UserControl {

		#region -_ Construction _-

		public TimeTableManagementModule() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Refreshes the data.
		/// </summary>
		public void RefreshData() {
			RefreshEmployeeTreeView();

			timeTable.Move( DateTime.Today );
			occupationControl.Move( DateTime.Today );
			occupationControl.Invalidate();

			selectionToolStripButton.Text =
				timeTable.Selection.StartOfWeek().ToString( "dd/MM/yyyy" ) + " - " + timeTable.Selection.EndOfWeek().ToString( "dd/MM/yyyy" );
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Load event of the TimeTableManagementModule control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void TimeTableManagementModule_Load( object sender , EventArgs e ) {
			toolStrip.Renderer = new WindowsVistaRenderer();
		}

		/// <summary>
		/// Handles the Click event of the timeTablePurposeToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void timeTablePurposeToolStripButton_Click( object sender , EventArgs e ) {
			TimeTablePurposeManagementDialog timeTablePurposeManagementDialog = new TimeTablePurposeManagementDialog();
			timeTablePurposeManagementDialog.ShowDialog();
		}

		/// <summary>
		/// Handles the Click event of the templateManagementToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void templateManagementToolStripButton_Click( object sender , EventArgs e ) {
			TimeTableTemplateManagementDialog timeTableTemplateManagementDialog = new TimeTableTemplateManagementDialog();
			timeTableTemplateManagementDialog.ShowDialog();
		}

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
			foreach( TimeTableColumn occupationColumn in occupationControl.Columns ) {
				occupationColumn.TimeTableEntries.Clear();
				TimeTableEntryCollection timeTableEntries =
					SwmSuiteFacade.TimeTableFacade.GetTimeTableEntries( (Employee)occupationColumn.Tag , occupationControl.Selection , occupationControl.Selection );
				occupationColumn.TimeTableEntries = GetTimeTableControlEntries( timeTableEntries );
			}
		}

		/// <summary>
		/// Handles the DataClicked event of the timeTable control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="SwmSuite.Presentation.Common.TimeTable.DataClickedEventArgs"/> instance containing the event data.</param>
		private void timeTable_DataClicked( object sender , DataClickedEventArgs e ) {
			Employee employee = (Employee)e.Column.Tag;
			if( timeTable.TemplateApply ) {
				// Delete all previous data...
				TimeTableEntryCollection timeTableEntriesToRemove = new TimeTableEntryCollection();
				foreach( TimeTableControlEntry entry in e.Column.TimeTableEntries ){
					timeTableEntriesToRemove.Add( (TimeTableEntry)entry.Tag );
				}
				SwmSuiteFacade.TimeTableFacade.RemoveTimeTableEntries( timeTableEntriesToRemove );
				// Add the new data...
				foreach( TimeTableControlEntry entry in timeTable.TimeTableTemplateColumn.TimeTableEntries ) {
					TimeTableTemplateEntry timeTableTemplateEntry = (TimeTableTemplateEntry)entry.Tag;
					SwmSuiteFacade.TimeTableFacade.CreateTimeTableEntry( timeTableTemplateEntry.ToTimeTableEntry( e.Date.StartOfWeek().AddDays( ( (TimeSpan)( timeTableTemplateEntry.Date - timeTableTemplateEntry.Date.StartOfWeek() ) ).Days ) , employee ) );
				}
				timeTable.UpdateData();
			} else {
				EmployeeGroup employeeGroup = SwmSuiteFacade.EmployeeFacade.GetEmployeeGroupForEmployee( employee );
				TimeTableEntryManagementDialog.ShowTimeTableEntriesDialog( employee , e.Date , employeeGroup , e.Entries );
				timeTable.UpdateData();
			}
		}

		/// <summary>
		/// Handles the AfterSelect event of the employeeTreeView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.TreeViewEventArgs"/> instance containing the event data.</param>
		private void employeeTreeView_AfterSelect( object sender , TreeViewEventArgs e ) {
			EmployeeCollection employeeCollection = (EmployeeCollection)e.Node.Tag;
			timeTable.Columns.Clear();
			occupationControl.Columns.Clear();
			foreach( Employee employee in employeeCollection ) {
				TimeTableEntryCollection timeTableEntries =
					SwmSuiteFacade.TimeTableFacade.GetTimeTableEntries( employee , timeTable.Selection.StartOfWeek() , timeTable.Selection.EndOfWeek() );
				TimeTableColumn timeTableColumn = new TimeTableColumn();
				timeTableColumn.Caption = employee.FirstName;
				timeTableColumn.Tag = employee;
				timeTableColumn.TimeTableEntries = GetTimeTableControlEntries( timeTableEntries );
				timeTable.Columns.Add( timeTableColumn );
				TimeTableColumn occupationColumn = new TimeTableColumn();
				occupationColumn.Caption = employee.FirstName;
				occupationColumn.Tag = employee;
				occupationColumn.TimeTableEntries = GetTimeTableControlEntries( timeTableEntries );
				occupationControl.Columns.Add( occupationColumn );
			}
			timeTable.Renderer.Invalidate();
			timeTable.Invalidate();
			occupationControl.Invalidate();
		}

		/// <summary>
		/// Handles the Click event of the occupationToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void occupationToolStripButton_Click( object sender , EventArgs e ) {
			occupationToolStripButton.Checked = !occupationToolStripButton.Checked;
			if( occupationToolStripButton.Checked ) {
				templateToolStripButton.Visible = false;
				occupationControl.Visible = true;
				timeTable.Visible = false;
				ChangeDaysVisibility( true );
			} else {
				templateToolStripButton.Visible = true;
				timeTable.Visible = true;
				occupationControl.Visible = false;
				ChangeDaysVisibility( false );
			}
		}

		/// <summary>
		/// Handles the Click event of the templateToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void templateToolStripButton_Click( object sender , EventArgs e ) {
			templateToolStripButton.Checked = !templateToolStripButton.Checked;
			if( templateToolStripButton.Checked ) {
				TimeTableTemplateSelectionDialog dialog = new TimeTableTemplateSelectionDialog();
				if( dialog.ShowDialog() == DialogResult.OK ) {
					occupationToolStripButton.Enabled = false;
					timeTable.TemplateApply = true;
					timeTable.TimeTableTemplateColumn = new TimeTableColumn();
					TimeTableTemplateEntryCollection timeTableTemplateEntries =
						SwmSuiteFacade.TimeTableFacade.GetTimeTableTemplateEntries( dialog.TimeTableTemplate );
					timeTable.TimeTableTemplateColumn.TimeTableEntries = GetTimeTableControlEntries( timeTableTemplateEntries );
					if( timeTableTemplateEntries.Count > 0 ) {
						timeTable.TimeTableTemplateColumn.Tag = timeTableTemplateEntries[0].Date;
					}
				} else {
					templateToolStripButton.Checked = !templateToolStripButton.Checked;
				}
			} else {
				occupationToolStripButton.Enabled = true;
				timeTable.TemplateApply = false;
				timeTable.TimeTableTemplateColumn = null;
			}
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

		#region -_ Private Methods _-

		private void RefreshEmployeeTreeView() {
			employeeTreeView.Nodes.Clear();

			EmployeeGroupCollection employeeGroups = SwmSuiteFacade.EmployeeFacade.GetEmployeeGroups();
			EmployeeCollection employees = SwmSuiteFacade.EmployeeFacade.GetEmployees();

			// Create root node.
			TreeNode rootNode = new TreeNode( "Iedereen" );
			rootNode.Tag = employees;
			rootNode.ImageIndex = 0;
			rootNode.SelectedImageIndex = 0;

			foreach( EmployeeGroup employeeGroup in employeeGroups ) {

				EmployeeCollection employeesInGroup =
					SwmSuiteFacade.EmployeeFacade.GetEmployeesForEmployeeGroup( employeeGroup );

				TreeNode employeeGroupTreeNode = new TreeNode( employeeGroup.Name );
				employeeGroupTreeNode.Tag = employeesInGroup;
				employeeGroupTreeNode.ImageIndex = 1;
				employeeGroupTreeNode.SelectedImageIndex = 1;

				foreach( Employee employee in employeesInGroup ) {
					TreeNode employeeTreeNode = new TreeNode( employee.FullName );
					employeeTreeNode.Tag = EmployeeCollection.FromSingleEmployee( employee );
					employeeTreeNode.ImageIndex = 2;
					employeeTreeNode.SelectedImageIndex = 2;
					employeeGroupTreeNode.Nodes.Add( employeeTreeNode );
				}

				rootNode.Nodes.Add( employeeGroupTreeNode );
			}

			employeeTreeView.Nodes.Add( rootNode );
			employeeTreeView.ExpandAll();
			employeeTreeView.SelectedNode = rootNode;
		}

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

		private TimeTableControlEntryCollection GetTimeTableControlEntries( TimeTableTemplateEntryCollection timeTableEntries ) {
			TimeTableControlEntryCollection timeTableEntryCollectionToReturn = new TimeTableControlEntryCollection();
			foreach( TimeTableTemplateEntry timeTableEntry in timeTableEntries ) {
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

	}

}
