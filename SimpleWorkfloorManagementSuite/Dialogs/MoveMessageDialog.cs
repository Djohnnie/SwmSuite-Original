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
	
	public partial class MoveMessageDialog : Form {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the selected messagefolder.
		/// </summary>
		public MessageFolder SelectedMessageFolder { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="MoveMessageDialog"/> class.
		/// </summary>
		public MoveMessageDialog() {
			InitializeComponent();
		}

		#endregion

		#region -_ Private Methods _-

		private void LoadMessageFolders() {
			messageFolderTreeView.Nodes.Clear();
			MessageFolderCollection messageFolders =
				SwmSuiteFacade.MessageFacade.GetRootMessageFolders( SwmSuitePrincipal.CurrentEmployee );
			foreach( MessageFolder messageFolder in messageFolders ) {
				TreeNode newTreeNode = new TreeNode( messageFolder.Name );
				newTreeNode.Tag = messageFolder;
				LoadMessageFolders( messageFolder , newTreeNode );
				messageFolderTreeView.Nodes.Add( newTreeNode );
				if( messageFolder.SpecialFolder == SwmSuite.Data.Common.MessageSpecialFolder.Inbox ) {
					messageFolderTreeView.SelectedNode = newTreeNode;
				}
			}
		}

		private void LoadMessageFolders( MessageFolder messageFolder , TreeNode parentTreeNode ) {
			foreach( MessageFolder childMessageFolder in SwmSuiteFacade.MessageFacade.GetMessageFolders( messageFolder ) ) {
				TreeNode newTreeNode = new TreeNode( childMessageFolder.Name );
				newTreeNode.Tag = childMessageFolder;
				LoadMessageFolders( childMessageFolder , newTreeNode );
				parentTreeNode.Nodes.Add( newTreeNode );
			}
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Load event of the MoveMessageDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void MoveMessageDialog_Load( object sender , EventArgs e ) {
			LoadMessageFolders();
		}

		/// <summary>
		/// Handles the Click event of the okButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void okButton_Click( object sender , EventArgs e ) {
			if( messageFolderTreeView.SelectedNode != null ) {
				this.SelectedMessageFolder = (MessageFolder)messageFolderTreeView.SelectedNode.Tag;
			}
		}

		#endregion

	}

}
