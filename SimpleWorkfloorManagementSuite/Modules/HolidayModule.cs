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


namespace SimpleWorkfloorManagementSuite.Modules {

	public partial class HolidayModule : UserControl {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the year.
		/// </summary>
		/// <value>The year.</value>
		public int Year { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="HolidayModule"/> class.
		/// </summary>
		public HolidayModule() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );

			toolStrip.Renderer = new WindowsVistaRenderer();
			this.Year = DateTime.Today.Year;
		}

		#endregion

		#region -_ Private Methods _-

		private void UncheckAllMenuItems() {
			overtimeToolStripButton.Checked = false;
			holidayToolStripButton.Checked = false;
			saldiToolStripButton.Checked = false;
		}

		private void RefreshOvertimeEntries() {
			int year = int.Parse( yearToolStripLabel.Text );
			OvertimeEntryCollection overtimeEntries = SwmSuiteFacade.HolidayFacade.GetOvertimeEntries(
				EmployeeCollection.FromSingleEmployee( SwmSuitePrincipal.CurrentEmployee ) , year );
			overtimeBrowserView.SetOvertimeEntries( overtimeEntries );
		}

		#endregion

		#region -_ Public Properties _-

		public void RefreshData() {
			RefreshOvertimeEntries();
		}

		#endregion

		/// <summary>
		/// Handles the Click event of the previousYearToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void previousYearToolStripButton_Click( object sender , EventArgs e ) {
			this.Year--;
			yearToolStripLabel.Text = this.Year.ToString();
			RefreshOvertimeEntries();
		}

		/// <summary>
		/// Handles the Click event of the nextYearToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void nextYearToolStripButton_Click( object sender , EventArgs e ) {
			this.Year++;
			yearToolStripLabel.Text = this.Year.ToString();
			RefreshOvertimeEntries();
		}

		/// <summary>
		/// Handles the Click event of the overtimeToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void overtimeToolStripButton_Click( object sender , EventArgs e ) {
			UncheckAllMenuItems();
			overtimeToolStripButton.Checked = true;
			RefreshOvertimeEntries();
			overtimeBrowserView.Visible = true;
		}

		/// <summary>
		/// Handles the Click event of the holidayToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void holidayToolStripButton_Click( object sender , EventArgs e ) {
			UncheckAllMenuItems();
			holidayToolStripButton.Checked = true;

			overtimeBrowserView.Visible = false;
		}

		/// <summary>
		/// Handles the Click event of the saldiToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void saldiToolStripButton_Click( object sender , EventArgs e ) {
			UncheckAllMenuItems();
			saldiToolStripButton.Checked = true;

			overtimeBrowserView.Visible = false;
		}

		/// <summary>
		/// Handles the SelectedOvertimeEntryChanged event of the overtimeBrowserView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="SimpleWorkfloorManagementSuite.Controls.SelectedOvertimeEntryChangedEventArgs"/> instance containing the event data.</param>
		private void overtimeBrowserView_SelectedOvertimeEntryChanged( object sender , SimpleWorkfloorManagementSuite.Controls.SelectedOvertimeEntryChangedEventArgs e ) {
			overtimeDetail.SetOvertimeEntry( e.OvertimeEntry );
		}

		/// <summary>
		/// Handles the Click event of the insertOvertimeToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void insertOvertimeToolStripButton_Click( object sender , EventArgs e ) {
			OvertimeEntryDetailDialog overtimeEntryDialog = new OvertimeEntryDetailDialog();
			if( overtimeEntryDialog.ShowDialog() == DialogResult.OK ) {
				OvertimeEntry overtimeEntry = overtimeEntryDialog.OvertimeEntry;
				SwmSuiteFacade.HolidayFacade.CreateOvertimeEntry( overtimeEntry );
			}
			RefreshOvertimeEntries();
		}

	}

}
