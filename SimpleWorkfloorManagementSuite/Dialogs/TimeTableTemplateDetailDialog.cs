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
using SwmSuite.Presentation.Common.TimeTable;
using SwmSuite.Presentation.Drawing.VistaRenderer;

namespace SimpleWorkfloorManagementSuite.Dialogs {

	public partial class TimeTableTemplateDetailDialog : Form {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the time table template.
		/// </summary>
		/// <value>The time table template.</value>
		public TimeTableTemplate TimeTableTemplate { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTableTemplateDetailDialog"/> class.
		/// </summary>
		public TimeTableTemplateDetailDialog() {
			InitializeComponent();
			toolStrip.Renderer = new WindowsVistaRenderer();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTableTemplateDetailDialog"/> class.
		/// </summary>
		/// <param name="timeTableTemplate">The time table template.</param>
		public TimeTableTemplateDetailDialog( TimeTableTemplate timeTableTemplate )
			: this() {
			this.TimeTableTemplate = timeTableTemplate;
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Load event of the TimeTableTemplateDetailDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void TimeTableTemplateDetailDialog_Load( object sender , EventArgs e ) {
			detailsToolStripButton.PerformClick();

			nameTextBox.Client.Text = this.TimeTableTemplate.Name;
			descriptionTextBox.Client.Text = this.TimeTableTemplate.Description;

			timeTableControl.Move( TimeTableTemplateEntry.TemplateFrom );
			LoadTimeTableDetails( this.TimeTableTemplate.TimeTableTemplateEntries );

			ValidateAll();
		}

		/// <summary>
		/// Handles the Click event of the detailsToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void detailsToolStripButton_Click( object sender , EventArgs e ) {
			detailsToolStripButton.Checked = true;
			timeTableToolStripButton.Checked = false;

			detailsPanel.Visible = true;
			timeTablePanel.Visible = false;
		}

		/// <summary>
		/// Handles the Click event of the timeTableToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void timeTableToolStripButton_Click( object sender , EventArgs e ) {
			detailsToolStripButton.Checked = false;
			timeTableToolStripButton.Checked = true;

			detailsPanel.Visible = false;
			timeTablePanel.Visible = true;
		}

		/// <summary>
		/// Handles the Click event of the occupationToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void occupationToolStripButton_Click( object sender , EventArgs e ) {
			detailsToolStripButton.Checked = false;
			timeTableToolStripButton.Checked = false;

			detailsPanel.Visible = false;
			timeTablePanel.Visible = false;
		}

		/// <summary>
		/// Handles the DataClicked event of the timeTableControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="SwmSuite.Presentation.Common.TimeTable.DataClickedEventArgs"/> instance containing the event data.</param>
		private void timeTableControl_DataClicked( object sender , SwmSuite.Presentation.Common.TimeTable.DataClickedEventArgs e ) {
			TimeTableTemplateEntryManagementDialog.ShowTimeTableTemplateTemplateEntryManagementDialog( this.TimeTableTemplate , e.Date , this.TimeTableTemplate.EmployeeGroup , e.Entries );
			timeTableControl.UpdateData();
		}

		/// <summary>
		/// Handles the DataNeeded event of the timeTableControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void timeTableControl_DataNeeded( object sender , EventArgs e ) {
			foreach( TimeTableColumn timeTableColumn in timeTableControl.Columns ) {
				timeTableColumn.TimeTableEntries.Clear();
				TimeTableTemplateEntryCollection timeTableTemplateEntries =
					SwmSuiteFacade.TimeTableFacade.GetTimeTableTemplateEntries( this.TimeTableTemplate );
				timeTableColumn.TimeTableEntries = GetTimeTableControlEntries( timeTableTemplateEntries );
			}
		}

		/// <summary>
		/// Handles the Click event of the okButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void okButton_Click( object sender , EventArgs e ) {
			this.TimeTableTemplate.Name = nameTextBox.Client.Text;
			this.TimeTableTemplate.Description = descriptionTextBox.Client.Text;
		}

		#endregion

		#region -_ Private Methods _-

		/// <summary>
		/// Loads the time table details.
		/// </summary>
		/// <param name="timeTableTemplateEntryCollection">The time table template entry collection.</param>
		private void LoadTimeTableDetails( TimeTableTemplateEntryCollection timeTableTemplateEntryCollection ) {

		}

		private TimeTableControlEntryCollection GetTimeTableControlEntries( TimeTableTemplateEntryCollection timeTableTemplateEntries ) {
			TimeTableControlEntryCollection timeTableEntryCollectionToReturn = new TimeTableControlEntryCollection();
			foreach( TimeTableTemplateEntry timeTableTemplateEntry in timeTableTemplateEntries ) {
				TimeTableControlEntry newTimeTableControlEntry = new TimeTableControlEntry();
				newTimeTableControlEntry.Begin = timeTableTemplateEntry.From;
				newTimeTableControlEntry.End = timeTableTemplateEntry.To;
				newTimeTableControlEntry.BorderColor = timeTableTemplateEntry.TimeTablePurpose.Color1;
				newTimeTableControlEntry.BackColor1 = timeTableTemplateEntry.TimeTablePurpose.Color2;
				newTimeTableControlEntry.BackColor2 = timeTableTemplateEntry.TimeTablePurpose.Color3;
				newTimeTableControlEntry.Tag = timeTableTemplateEntry;
				newTimeTableControlEntry.Description = timeTableTemplateEntry.TimeTablePurpose.Description;
				timeTableEntryCollectionToReturn.Add( newTimeTableControlEntry );
			}
			return timeTableEntryCollectionToReturn;
		}

		#endregion

		#region -_ Static Methods _-

		/// <summary>
		/// Adds the time table template detail dialog.
		/// </summary>
		/// <param name="employeeGroup">The employee group.</param>
		/// <returns></returns>
		public static TimeTableTemplate AddTimeTableTemplateDetailDialog( EmployeeGroup employeeGroup ) {
			TimeTableTemplate timeTableTemplate = new TimeTableTemplate();
			timeTableTemplate.EmployeeGroup = employeeGroup;
			TimeTableTemplateDetailDialog dialog = new TimeTableTemplateDetailDialog( timeTableTemplate );
			dialog.dialogHeaderControl.MainText = "Nieuw uurrooster sjabloon maken";
			dialog.timeTableToolStripButton.Visible = false;
			if( dialog.ShowDialog() == DialogResult.OK ) {
				timeTableTemplate =
					SwmSuiteFacade.TimeTableFacade.CreateTimeTableTemplate( dialog.TimeTableTemplate , employeeGroup );
			}
			return timeTableTemplate;
		}

		/// <summary>
		/// Edits the time table template detail dialog.
		/// </summary>
		/// <param name="timeTableTemplate">The time table template.</param>
		/// <param name="employeeGroup">The employee group.</param>
		/// <returns></returns>
		public static TimeTableTemplate EditTimeTableTemplateDetailDialog( TimeTableTemplate timeTableTemplate , EmployeeGroup employeeGroup ) {
			TimeTableTemplateDetailDialog dialog = new TimeTableTemplateDetailDialog( timeTableTemplate );
			dialog.dialogHeaderControl.MainText = "Uurrooster sjabloon bewerken";
			if( dialog.ShowDialog() == DialogResult.OK ) {
				timeTableTemplate =
					SwmSuiteFacade.TimeTableFacade.UpdateTimeTableTemplate( dialog.TimeTableTemplate , employeeGroup );
			}
			return timeTableTemplate;
		}

		#endregion

		private void nameTextBox_TextChanged( object sender , EventArgs e ) {
			ValidateAll();
		}

		private void ValidateAll() {
			okButton.Enabled = ValidateTitle();
		}

		private bool ValidateTitle() {
			bool valid = !String.IsNullOrEmpty( nameTextBox.Client.Text );
			nameTextBox.DoError( !valid );
			return valid;
		}

	}

}
