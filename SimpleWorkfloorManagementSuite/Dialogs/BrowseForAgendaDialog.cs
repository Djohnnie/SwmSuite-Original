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
using SwmSuite.Data.BusinessObjects;


namespace SimpleWorkfloorManagementSuite.Dialogs {
	
	public partial class BrowseForAgendaDialog : Form {

		#region -_ Public Properties _-

		public Agenda Agenda { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="BrowseForAgendaDialog"/> class.
		/// </summary>
		/// <param name="agenda">The agenda to associate with this dialog.</param>
		public BrowseForAgendaDialog( Agenda agenda ) {
			InitializeComponent();
			this.Agenda = agenda;
		}

		#endregion

		#region -_ Private Methods _-

		private void LoadAgendaTree() {
			AgendaCollection agendas = 
				SwmSuiteFacade.AgendaFacade.GetAgendasForEmployee( SwmSuitePrincipal.CurrentEmployee );
			foreach( Agenda agenda in agendas ) {
				TreeNode newNode = new TreeNode( agenda.Title );
				newNode.Tag = agenda;
				agendaTreeView.Nodes.Add( newNode );
			}
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Load event of the BrowseForAgendaDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void BrowseForAgendaDialog_Load( object sender , EventArgs e ) {
			LoadAgendaTree();
			if( this.Agenda != null ) {
				foreach( TreeNode treeNode in agendaTreeView.Nodes ) {
					Agenda agenda = (Agenda)treeNode.Tag;
					if( agenda.SysId == this.Agenda.SysId ) {
						agendaTreeView.SelectedNode = treeNode;
					}
				}
			}
		}

		/// <summary>
		/// Handles the Click event of the okButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void okButton_Click( object sender , EventArgs e ) {
			if( agendaTreeView.SelectedNode != null ) {
				this.Agenda = (Agenda)agendaTreeView.SelectedNode.Tag;
			}
		}

		/// <summary>
		/// Handles the MouseDoubleClick event of the agendaTreeView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
		private void agendaTreeView_MouseDoubleClick( object sender , MouseEventArgs e ) {
			
		}

		/// <summary>
		/// Handles the NodeMouseDoubleClick event of the agendaTreeView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.TreeNodeMouseClickEventArgs"/> instance containing the event data.</param>
		private void agendaTreeView_NodeMouseDoubleClick( object sender , TreeNodeMouseClickEventArgs e ) {
			okButton.PerformClick();
		}

		#endregion

	}

}
