using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using SwmSuite.Presentation.Drawing.VistaRenderer;
using SwmSuite.Presentation.Drawing.Office2007Renderer;
using SwmSuite.Data.BusinessObjects;
using SimpleWorkfloorManagementSuite.Dialogs;
using SwmSuite.Proxy.Interface;
using SwmSuite.Presentation.Common.MessageDialog;

namespace SimpleWorkfloorManagementSuite.Modules {

	public partial class MessageModule : UserControl {

		#region -_ Private Members _-

		private MessageFolder _inboxFolder;
		private MessageFolder _outboxFolder;
		private MessageFolder _archiveFolder;

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public MessageModule() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );
		}

		#endregion

		#region -_ Public Methods _-

		public void RefreshData() {
			LoadMessageFolders();
		}

		#endregion

		#region -_ Private Methods _-

		private void LoadMessageFolders() {
			messageFolderTreeView.Nodes.Clear();
			MessageFolderCollection messageFolders =
				SwmSuiteFacade.MessageFacade.GetRootMessageFolders( SwmSuitePrincipal.CurrentEmployee );
			foreach( MessageFolder messageFolder in messageFolders ) {
				switch( messageFolder.SpecialFolder ) {
					case SwmSuite.Data.Common.MessageSpecialFolder.Inbox: {
							_inboxFolder = messageFolder;
							break;
						}
					case SwmSuite.Data.Common.MessageSpecialFolder.Outbox: {
							_outboxFolder = messageFolder;
							break;
						}
					case SwmSuite.Data.Common.MessageSpecialFolder.Archive: {
							_archiveFolder = messageFolder;
							break;
						}
				}
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
			messageFolder.ChildFolders = new MessageFolderCollection();
			foreach( MessageFolder childMessageFolder in SwmSuiteFacade.MessageFacade.GetMessageFolders( messageFolder ) ) {
				messageFolder.ChildFolders.Add( childMessageFolder );
				childMessageFolder.ParentFolder = messageFolder;
				TreeNode newTreeNode = new TreeNode( childMessageFolder.Name );
				newTreeNode.Tag = childMessageFolder;
				LoadMessageFolders( childMessageFolder , newTreeNode );
				parentTreeNode.Nodes.Add( newTreeNode );
			}
		}

		private void ShowFolderContextMenu() {
			contextMenuStrip.Show( Cursor.Position );
		}

		private void RefreshMessages( MessageCollection messages ) {
			messageBrowserView.Items.Clear();
			foreach( SwmSuite.Data.BusinessObjects.Message message in messages ) {
				ListViewItem newListViewItem = new ListViewItem( new string[] { String.Empty , message.Subject , message.Sender.Name , message.Date.ToShortDateString() + " " + message.Date.ToShortTimeString() } );
				newListViewItem.Tag = message;
				if( message.IsNew ) {
					newListViewItem.ImageIndex = 4;
				} else {
					newListViewItem.ImageIndex = 5;
				}
				messageBrowserView.Items.Add( newListViewItem );
			}
		}

		#endregion

		private void MessageModule_Load( object sender , EventArgs e ) {
			toolStrip.Renderer = new WindowsVistaRenderer();
			contextMenuStrip.Renderer = new Office2007Renderer();
		}

		private void messageFolderTreeView_NodeMouseClick( object sender , TreeNodeMouseClickEventArgs e ) {
			if( e.Button == MouseButtons.Right ) {
				ShowFolderContextMenu();
				messageFolderTreeView.SelectedNode = e.Node;
			}
		}

		private void changeMessageFolderNameToolStripMenuItem_Click( object sender , EventArgs e ) {
			MessageFolderDetailDialog messageFolderDetailDialog = new MessageFolderDetailDialog( (MessageFolder)messageFolderTreeView.SelectedNode.Tag );
			if( messageFolderDetailDialog.ShowDialog() == DialogResult.OK ) {
				MessageFolder updatedMessageFolder =
					SwmSuiteFacade.MessageFacade.UpdateMessageFolder( messageFolderDetailDialog.MessageFolder , SwmSuitePrincipal.CurrentEmployee );
				messageFolderTreeView.SelectedNode.Tag = updatedMessageFolder;
				messageFolderTreeView.SelectedNode.Text = updatedMessageFolder.Name;
			}
		}

		private void newMessageFolderToolStripMenuItem_Click( object sender , EventArgs e ) {
			MessageFolderDetailDialog messageFolderDetailDialog = new MessageFolderDetailDialog();
			if( messageFolderDetailDialog.ShowDialog() == DialogResult.OK ) {
				MessageFolder createdMessageFolder =
					SwmSuiteFacade.MessageFacade.CreateMessageFolder( messageFolderDetailDialog.MessageFolder , (MessageFolder)messageFolderTreeView.SelectedNode.Tag );
				TreeNode newTreeNode = new TreeNode( createdMessageFolder.Name );
				newTreeNode.Tag = createdMessageFolder;
				messageFolderTreeView.SelectedNode.Nodes.Add( newTreeNode );
				messageFolderTreeView.SelectedNode = newTreeNode;
			}
		}

		private void removeMessageFolderNameToolStripMenuItem_Click( object sender , EventArgs e ) {
			MessageFolder selectedMessageFolder =
				(MessageFolder)messageFolderTreeView.SelectedNode.Tag;
			if( SwmSuiteFacade.MessageFacade.DeleteMessageFolder( selectedMessageFolder ) ) {
				TreeNode selectedNode = messageFolderTreeView.SelectedNode;
				messageFolderTreeView.SelectedNode = selectedNode.Parent;
				selectedNode.Remove();
			}
		}

		private void messageFolderTreeView_AfterSelect( object sender , TreeViewEventArgs e ) {
			MessageCollection messages = SwmSuiteFacade.MessageFacade.GetMessagesForMessageFolder( (MessageFolder)e.Node.Tag );
			RefreshMessages( messages );
		}

		private void newMessageToolStripButton_Click( object sender , EventArgs e ) {
			MessageDetailDialog newMessageDialog = new MessageDetailDialog();
			if( newMessageDialog.ShowDialog() == DialogResult.OK ) {
				SwmSuiteFacade.MessageFacade.SendMessage( newMessageDialog.Message , newMessageDialog.Message.Recipients );
			}
		}

		private void messageBrowserView_SelectedIndexChanged( object sender , EventArgs e ) {
			if( messageBrowserView.SelectedItems.Count == 1 ) {
				SwmSuite.Data.BusinessObjects.Message message =
					(SwmSuite.Data.BusinessObjects.Message)messageBrowserView.SelectedItems[0].Tag;
				MessageFolder messageFolder =
						(MessageFolder)messageFolderTreeView.SelectedNode.Tag;
				messageContents.SetMessage( message , messageFolder );
			} else {
				messageContents.SetMessage( null , null );
			}
		}

		private void deleteMessageToolStripButton_Click( object sender , EventArgs e ) {
			if( messageBrowserView.SelectedItems.Count > 0 ) {
				//foreach( ListViewItem selectedListViewItem
				SwmSuite.Data.BusinessObjects.Message message =
					(SwmSuite.Data.BusinessObjects.Message)messageBrowserView.SelectedItems[0].Tag;
				if( messageFolderTreeView.SelectedNode != null ) {
					MessageFolder messageFolder =
						(MessageFolder)messageFolderTreeView.SelectedNode.Tag;
					MessageFolder archiveFolder =
						SwmSuiteFacade.MessageFacade.GetSpecialMessageFolderForEmployee( SwmSuitePrincipal.CurrentEmployee , SwmSuite.Data.Common.MessageSpecialFolder.Archive );
					SwmSuiteFacade.MessageFacade.MoveMessage( message , messageFolder , archiveFolder );
					MessageCollection messages = SwmSuiteFacade.MessageFacade.GetMessagesForMessageFolder( messageFolder );
					RefreshMessages( messages );
				}
			}
		}

		private void replyToMessageToolStripButton_Click( object sender , EventArgs e ) {
			if( messageBrowserView.SelectedItems.Count == 1 ) {
				SwmSuite.Data.BusinessObjects.Message message =
					(SwmSuite.Data.BusinessObjects.Message)messageBrowserView.SelectedItems[0].Tag;
				MessageDetailDialog newMessageDialog = new MessageDetailDialog( message );
				if( newMessageDialog.ShowDialog() == DialogResult.OK ) {
					SwmSuiteFacade.MessageFacade.SendMessage( newMessageDialog.Message , newMessageDialog.Message.Recipients );
				}
			}
		}

		private void moveMessageToolStripButton_Click( object sender , EventArgs e ) {
			if( messageBrowserView.SelectedItems.Count == 1 ) {
				SwmSuite.Data.BusinessObjects.Message message =
					(SwmSuite.Data.BusinessObjects.Message)messageBrowserView.SelectedItems[0].Tag;
				MessageFolder source = (MessageFolder)messageFolderTreeView.SelectedNode.Tag;
				MoveMessageDialog dialog = new MoveMessageDialog();
				if( dialog.ShowDialog() == DialogResult.OK ) {
					if( dialog.SelectedMessageFolder != null ) {
						SwmSuiteFacade.MessageFacade.MoveMessage( message , source , dialog.SelectedMessageFolder );
						MessageCollection messages = SwmSuiteFacade.MessageFacade.GetMessagesForMessageFolder( (MessageFolder)messageFolderTreeView.SelectedNode.Tag );
						RefreshMessages( messages );
					}
				}
			}
		}

		private void messageBrowserView_ItemDrag( object sender , ItemDragEventArgs e ) {
			MessageCollection selectedMessages = new MessageCollection();
			foreach( ListViewItem selectedListViewItem in messageBrowserView.SelectedItems ) {
				selectedMessages.Add( (SwmSuite.Data.BusinessObjects.Message)selectedListViewItem.Tag );
			}

			messageBrowserView.DoDragDrop( selectedMessages , DragDropEffects.Move );
		}

		private void messageFolderTreeView_DragEnter( object sender , DragEventArgs e ) {
			if( e.Data.GetDataPresent( typeof( MessageCollection ) ) || e.Data.GetDataPresent( typeof( MessageFolder ) ) ) {
				e.Effect = DragDropEffects.Move;
			}
		}

		private void messageFolderTreeView_DragDrop( object sender , DragEventArgs e ) {
			if( e.Data.GetDataPresent( typeof( MessageCollection ) ) ) {
				//e.Effect = DragDropEffects.Move;
				MessageCollection messagesToMove = (MessageCollection)e.Data.GetData( typeof( MessageCollection ) );
				MessageFolder source = (MessageFolder)messageFolderTreeView.SelectedNode.Tag;
				MessageFolder destination = (MessageFolder)messageFolderTreeView.GetNodeAt( messageFolderTreeView.PointToClient( new Point( e.X , e.Y ) ) ).Tag;
				if( MessageBox.Show( "Ben je zeker dat je de geselecteerde berichten wilt verplaatsen naar de map \"" + destination.Name + "\"?" , "Simple Workfloor Management Suite" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.Yes ) {
					foreach( SwmSuite.Data.BusinessObjects.Message message in messagesToMove ) {
						SwmSuiteFacade.MessageFacade.MoveMessage( message , source , destination );
					}
					MessageCollection messages = SwmSuiteFacade.MessageFacade.GetMessagesForMessageFolder( source );
					RefreshMessages( messages );
				}
			}
			if( e.Data.GetDataPresent( typeof( MessageFolder ) ) ) {
				MessageFolder messageFolderToMove = (MessageFolder)e.Data.GetData( typeof( MessageFolder ) );
				MessageFolder destination = (MessageFolder)messageFolderTreeView.GetNodeAt( messageFolderTreeView.PointToClient( new Point( e.X , e.Y ) ) ).Tag;
				if( messageFolderToMove.SpecialFolder == SwmSuite.Data.Common.MessageSpecialFolder.None ) {
					if( MessageBox.Show( "Ben je zeker dat je de map \"" + messageFolderToMove.Name + "\" wilt verplaatsen naar \"" + destination.Name + "\"?" , "Simple Workfloor Management Suite" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.Yes ) {
						SwmSuiteFacade.MessageFacade.MoveMessageFolder( messageFolderToMove , destination );
						LoadMessageFolders();
					}
				}
			}
		}

		private void messageFolderTreeView_DragOver( object sender , DragEventArgs e ) {
			if( e.Data.GetDataPresent( typeof( MessageFolder ) ) ) {
				if( MoveFolderAllowed( (MessageFolder)e.Data.GetData( typeof( MessageFolder ) ) , (MessageFolder)messageFolderTreeView.GetNodeAt( messageFolderTreeView.PointToClient( new Point( e.X , e.Y ) ) ).Tag ) ) {
					e.Effect = DragDropEffects.Move;
				} else {
					e.Effect = DragDropEffects.None;
				}
			}
			if( e.Data.GetDataPresent( typeof( MessageCollection ) ) ) {
				if( MoveMessageAllowed( (MessageCollection)e.Data.GetData( typeof( MessageCollection ) ) , (MessageFolder)messageFolderTreeView.GetNodeAt( messageFolderTreeView.PointToClient( new Point( e.X , e.Y ) ) ).Tag ) ) {
					e.Effect = DragDropEffects.Move;
				} else {
					e.Effect = DragDropEffects.None;
				}
			}

		}

		private void messageFolderTreeView_ItemDrag( object sender , ItemDragEventArgs e ) {
			MessageFolder selectedMessageFolder = (MessageFolder)messageFolderTreeView.SelectedNode.Tag;
			messageBrowserView.DoDragDrop( selectedMessageFolder , DragDropEffects.Move );
		}

		private bool MoveFolderAllowed( MessageFolder folderToMove , MessageFolder destinationFolder ) {
			return folderToMove.MoveFolderAllowed( destinationFolder );
		}

		private bool MoveMessageAllowed( MessageCollection messageCollectionToMove , MessageFolder destinationFolder ) {
			bool moveAllowed = true;
			foreach( SwmSuite.Data.BusinessObjects.Message message in messageCollectionToMove ) {
				if( !message.MoveMessageAllowed( destinationFolder ) ) {
					moveAllowed = false;
				}
			}
			return moveAllowed;
		}

	}

}
