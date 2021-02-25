using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwmSuite.Presentation.Drawing.VistaRenderer;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;

namespace SimpleWorkfloorManagementSuite.Modules {

	public partial class LoggingModule : UserControl {

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="LoggingModule"/> class.
		/// </summary>
		public LoggingModule() {
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
			selectionToolStripButton.Tag = DateTime.Today;
			selectionToolStripButton.Text = DateTime.Today.ToString( "MMMM yyyy" );

			RefreshLog();
		}

		#endregion

		#region -_ Private Methods _-

		private bool RefreshConnectionLog() {
			if( !connectionLogBackgroundWorker.IsBusy ) {
				HideAllBrowserView();
				connectionsBrowserView.Items.Clear();
				connectionsBrowserView.Visible = true;
				circularProgressControl.Visible = true;
				connectionLogBackgroundWorker.RunWorkerAsync( (DateTime)selectionToolStripButton.Tag );
				return true;
			} else {
				return false;
			}
		}

		private bool RefreshLoginLog() {
			if( !loginLogBackgroundWorker.IsBusy ) {
				HideAllBrowserView();
				loginsBrowserView.Items.Clear();
				loginsBrowserView.Visible = true;
				circularProgressControl.Visible = true;
				loginLogBackgroundWorker.RunWorkerAsync( (DateTime)selectionToolStripButton.Tag );
				return true;
			} else {
				return false;
			}
		}

		private void UncheckAllMenuItems() {
			connectionLogsToolStripButton.Checked = false;
			loginLogsToolStripButton.Checked = false;
		}

		private void HideAllBrowserView() {
			connectionsBrowserView.Visible = false;
			loginsBrowserView.Visible = false;
		}

		private void LoadConnectionLog( ConnectionLogCollection log ) {
			foreach( ConnectionLog connectionLog in log ) {
				ListViewItem newListViewItem = new ListViewItem( connectionLog.DateTime.ToShortDateString() + " " + connectionLog.DateTime.ToShortTimeString() );
				newListViewItem.SubItems.Add( connectionLog.Client );
				newListViewItem.Tag = connectionLog;
				connectionsBrowserView.Items.Add( newListViewItem );
			}
		}

		private void LoadLoginLog( LoginLogCollection log ) {
			foreach( LoginLog loginLog in log ) {
				ListViewItem newListViewItem = new ListViewItem( loginLog.DateTime.ToShortDateString() + " " + loginLog.DateTime.ToShortTimeString() );
				newListViewItem.SubItems.Add( loginLog.Employee.FullName );
				newListViewItem.Tag = loginLog;
				loginsBrowserView.Items.Add( newListViewItem );
			}
		}

		private bool RefreshLog() {
			if( connectionLogsToolStripButton.Checked ) {
				return RefreshConnectionLog();
			}
			if( loginLogsToolStripButton.Checked ) {
				return RefreshLoginLog();
			}
			return false;
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Load event of the LoggingModule control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void LoggingModule_Load( object sender , EventArgs e ) {
			toolStrip.Renderer = new WindowsVistaRenderer();
		}

		/// <summary>
		/// Handles the Click event of the connectionLogsToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void connectionLogsToolStripButton_Click( object sender , EventArgs e ) {
			UncheckAllMenuItems();
			connectionLogsToolStripButton.Checked = true;
			RefreshConnectionLog();
		}

		/// <summary>
		/// Handles the Click event of the loginLogsToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void loginLogsToolStripButton_Click( object sender , EventArgs e ) {
			UncheckAllMenuItems();
			loginLogsToolStripButton.Checked = true;
			RefreshLoginLog();
		}

		/// <summary>
		/// Handles the DoWork event of the connectionLogBackgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
		private void connectionLogBackgroundWorker_DoWork( object sender , DoWorkEventArgs e ) {
			DateTime selection = (DateTime)e.Argument;
			e.Result = SwmSuiteFacade.LoggingFacade.GetConnectionLogsByMonth( selection.Year , selection.Month );
		}

		/// <summary>
		/// Handles the RunWorkerCompleted event of the connectionLogBackgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
		private void connectionLogBackgroundWorker_RunWorkerCompleted( object sender , RunWorkerCompletedEventArgs e ) {
			circularProgressControl.Visible = false;
			LoadConnectionLog( (ConnectionLogCollection)e.Result );
		}

		/// <summary>
		/// Handles the DoWork event of the loginLogBackgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
		private void loginLogBackgroundWorker_DoWork( object sender , DoWorkEventArgs e ) {
			DateTime selection = (DateTime)e.Argument;
			e.Result = SwmSuiteFacade.LoggingFacade.GetLoginLogsByMonth( selection.Year , selection.Month );
		}

		/// <summary>
		/// Handles the RunWorkerCompleted event of the loginLogBackgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
		private void loginLogBackgroundWorker_RunWorkerCompleted( object sender , RunWorkerCompletedEventArgs e ) {
			circularProgressControl.Visible = false;
			LoadLoginLog( (LoginLogCollection)e.Result );
		}

		/// <summary>
		/// Handles the Click event of the previousToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void previousToolStripButton_Click( object sender , EventArgs e ) {
			DateTime selection = (DateTime)selectionToolStripButton.Tag;
			selection = selection.AddMonths( -1 );
			SetSelectionCaption( selection );
			if( !RefreshLog() ) {
				selection = selection.AddMonths( +1 );
				SetSelectionCaption( selection );
			}
		}

		private void SetSelectionCaption( DateTime selection ) {
			selectionToolStripButton.Tag = selection;
			selectionToolStripButton.Text = selection.ToString( "MMMM yyyy" );
		}

		/// <summary>
		/// Handles the Click event of the nextToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void nextToolStripButton_Click( object sender , EventArgs e ) {
			DateTime selection = (DateTime)selectionToolStripButton.Tag;
			selection = selection.AddMonths( +1 );
			SetSelectionCaption( selection );
			if( !RefreshLog() ) {
				selection = selection.AddMonths( -1 );
				SetSelectionCaption( selection );
			}
		}

		#endregion

	}

}
