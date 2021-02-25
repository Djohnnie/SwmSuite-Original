using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Proxy.Interface;
using SwmSuite.Presentation.Drawing.VistaRenderer;

namespace SimpleWorkfloorManagementSuite.Dialogs {
	
	/// <summary>
	/// Form representing the agenda management dialog.
	/// </summary>
	public partial class AgendaManagementDialog : Form {

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="AgendaManagementDialog"/> class.
		/// </summary>
		public AgendaManagementDialog() {
			InitializeComponent();
			toolStrip.Renderer = new WindowsVistaRenderer();
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Click event of the addToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void addToolStripButton_Click( object sender , EventArgs e ) {
			AgendaDetailDialog agendaDetailDialog = new AgendaDetailDialog();
			if( agendaDetailDialog.ShowDialog() == DialogResult.OK ) {
				SwmSuiteFacade.AgendaFacade.CreateAgenda( agendaDetailDialog.Agenda );
				RefreshAgendas();
			}
		}

		/// <summary>
		/// Handles the Click event of the editToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void editToolStripButton_Click( object sender , EventArgs e ) {
			if( agendaBrowserView.SelectedItems.Count == 1 ) {
				if( agendaBrowserView.SelectedItems[0].Tag != null ) {
					AgendaDetailDialog agendaDetailDialog = new AgendaDetailDialog( (Agenda)agendaBrowserView.SelectedItems[0].Tag );
					if( agendaDetailDialog.ShowDialog() == DialogResult.OK ) {
						SwmSuiteFacade.AgendaFacade.UpdateAgenda( agendaDetailDialog.Agenda );
						RefreshAgendas();
					}
				}
			}
		}

		/// <summary>
		/// Handles the Click event of the removeToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void removeToolStripButton_Click( object sender , EventArgs e ) {
			if( agendaBrowserView.SelectedItems.Count == 1 ) {
				if( agendaBrowserView.SelectedItems[0].Tag != null ) {
					SwmSuiteFacade.AgendaFacade.DeleteAgenda(
						(Agenda)agendaBrowserView.SelectedItems[0].Tag );
					RefreshAgendas();
				}
			}
		}

		/// <summary>
		/// Handles the Load event of the AgendaManagementDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void AgendaManagementDialog_Load( object sender , EventArgs e ) {
			RefreshAgendas();
		}

		/// <summary>
		/// Handles the SelectedIndexChanged event of the agendaBrowserView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void agendaBrowserView_SelectedIndexChanged( object sender , EventArgs e ) {
			if( agendaBrowserView.SelectedItems.Count == 0 ) {
				addToolStripButton.Enabled = true;
				editToolStripButton.Enabled = false;
				removeToolStripButton.Enabled = false;
			} else if( agendaBrowserView.SelectedItems.Count == 1 ) {
				addToolStripButton.Enabled = true;
				editToolStripButton.Enabled = true;
				removeToolStripButton.Enabled = true;
			} else {
				addToolStripButton.Enabled = true;
				editToolStripButton.Enabled = false;
				removeToolStripButton.Enabled = true;
			}
		}

		#endregion

		#region -_ Helper Methods _-

		private void RefreshAgendas() {
			AgendaCollection agendas =
						 SwmSuiteFacade.AgendaFacade.GetAgendasForEmployee( SwmSuitePrincipal.CurrentEmployee );
			agendaBrowserView.Items.Clear();
			foreach( Agenda agenda in agendas ) {
				ListViewItem newItem = new ListViewItem(agenda.Title);
				newItem.Tag = agenda;
				agendaBrowserView.Items.Add( newItem );
			}
		}

		#endregion

	}

}
