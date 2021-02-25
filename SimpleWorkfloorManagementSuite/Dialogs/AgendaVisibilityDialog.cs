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
using SimpleWorkfloorManagementSuite.Controls;
using SwmSuite.Data.BusinessObjects;

namespace SimpleWorkfloorManagementSuite.Dialogs {
	public partial class AgendaVisibilityDialog : Form {
		public AgendaVisibilityDialog() {
			InitializeComponent();
		}

		private void AgendaVisibilityDialog_Load( object sender , EventArgs e ) {
			AgendaCollection agendas = SwmSuiteFacade.AgendaFacade.GetAgendasForEmployee( SwmSuitePrincipal.CurrentEmployee );
			foreach( Agenda agenda in agendas ) {
				CheckListItem newCheckListItem = new CheckListItem( agenda.Title );
				newCheckListItem.Tag = agenda;
				newCheckListItem.Checked = false;
				agendaCheckListControl.Items.Add( newCheckListItem );
			}
		}

		private void agendaCheckListControl_CheckListItemChanged( object sender , CheckListItemEventArgs e ) {
			MessageBox.Show( e.Item.Text + ": " + e.Item.Checked.ToString() );
		}
	}
}
