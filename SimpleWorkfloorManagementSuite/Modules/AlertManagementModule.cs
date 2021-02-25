using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.BusinessObjects;
using SimpleWorkfloorManagementSuite.Dialogs;
using SwmSuite.Proxy.Interface;
using SwmSuite.Presentation.Drawing.VistaRenderer;

namespace SimpleWorkfloorManagementSuite.Modules {

	public partial class AlertManagementModule : UserControl {

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="AlertManagementModule"/> class.
		/// </summary>
		public AlertManagementModule() {
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
			LoadAlerts();
		}

		#endregion

		#region -_ Private Methods _-

		private void LoadAlerts() {
			alertBrowserView.Items.Clear();
			AlertCollection alerts = SwmSuiteFacade.Alert.GetAlerts();
			foreach( Alert alert in alerts ) {
				ListViewItem newListViewItem = new ListViewItem( alert.Message );
				newListViewItem.Tag = alert;
				alertBrowserView.Items.Add( newListViewItem );
			}
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Click event of the addAlertToolstripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void addAlertToolstripButton_Click( object sender , EventArgs e ) {
			if( AlertDetailDialog.AddAlert() ) {
				LoadAlerts();
			}
		}

		/// <summary>
		/// Handles the Click event of the editAlertToolstripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void editAlertToolstripButton_Click( object sender , EventArgs e ) {
			if( alertBrowserView.SelectedItems.Count == 1 ) {
				Alert alertToEdit = (Alert)alertBrowserView.SelectedItems[0].Tag;
				if( AlertDetailDialog.EditAlert( alertToEdit ) ) {
					LoadAlerts();
				}
			}
		}

		/// <summary>
		/// Handles the Click event of the deleteAlertToolstripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void deleteAlertToolstripButton_Click( object sender , EventArgs e ) {
			if( QueryDialog.ShowQueryDialog( "Aankondigingen" , "Bent u zeker dat u de geselecteerde aankondigingen wenst te verwijderen?" ) == DialogResult.Yes ) {
				AlertCollection alertsToRemove = new AlertCollection();
				foreach( ListViewItem selectedListViewItems in alertBrowserView.SelectedItems ) {
					alertsToRemove.Add( (Alert)selectedListViewItems.Tag );
				}
				SwmSuiteFacade.Alert.RemoveAlerts( alertsToRemove );
				LoadAlerts();
			}
		}

		/// <summary>
		/// Handles the SelectedIndexChanged event of the alertBrowserView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void alertBrowserView_SelectedIndexChanged( object sender , EventArgs e ) {
			if( alertBrowserView.SelectedItems.Count == 0 ) {
				editAlertToolStripButton.Enabled = false;
				deleteAlertToolStripButton.Enabled = false;
			} else if( alertBrowserView.SelectedItems.Count == 1 ) {
				editAlertToolStripButton.Enabled = true;
				deleteAlertToolStripButton.Enabled = true;
			} else if( alertBrowserView.SelectedItems.Count > 1 ) {
				editAlertToolStripButton.Enabled = false;
				deleteAlertToolStripButton.Enabled = true;
			}
		}

		/// <summary>
		/// Handles the DoubleClick event of the alertBrowserView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void alertBrowserView_DoubleClick( object sender , EventArgs e ) {
			editAlertToolStripButton.PerformClick();
		}

		#endregion

	}

}
