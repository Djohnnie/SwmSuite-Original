namespace SimpleWorkfloorManagementSuite.Modules {
	partial class MessageModule {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing ) {
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( MessageModule ) );
			SwmSuite.Presentation.Common.BrowserView.BrowserViewRenderer browserViewRenderer1 = new SwmSuite.Presentation.Common.BrowserView.BrowserViewRenderer();
			SwmSuite.Presentation.Common.BrowserView.BrowserViewScheme browserViewScheme1 = new SwmSuite.Presentation.Common.BrowserView.BrowserViewScheme();
			SimpleWorkfloorManagementSuite.Controls.MessageContentsRenderer messageContentsRenderer1 = new SimpleWorkfloorManagementSuite.Controls.MessageContentsRenderer();
			SimpleWorkfloorManagementSuite.Controls.MessageContentsScheme messageContentsScheme1 = new SimpleWorkfloorManagementSuite.Controls.MessageContentsScheme();
			this.messageFolderTreeView = new System.Windows.Forms.TreeView();
			this.imageList = new System.Windows.Forms.ImageList( this.components );
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.newMessageToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.replyToMessageToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.deleteMessageToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.moveMessageToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.messageBrowserView = new SwmSuite.Presentation.Common.BrowserView.BrowserViewControl();
			this.iconColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.subjectColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.fromColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.dateColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip( this.components );
			this.changeMessageFolderNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newMessageFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeMessageFolderNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.messageContents = new SimpleWorkfloorManagementSuite.Controls.MessageContentsControl();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.toolStrip.SuspendLayout();
			this.contextMenuStrip.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.SuspendLayout();
			// 
			// messageFolderTreeView
			// 
			this.messageFolderTreeView.AllowDrop = true;
			this.messageFolderTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.messageFolderTreeView.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.messageFolderTreeView.HideSelection = false;
			this.messageFolderTreeView.ImageIndex = 3;
			this.messageFolderTreeView.ImageList = this.imageList;
			this.messageFolderTreeView.Location = new System.Drawing.Point( 5 , 5 );
			this.messageFolderTreeView.Name = "messageFolderTreeView";
			this.messageFolderTreeView.SelectedImageIndex = 3;
			this.messageFolderTreeView.Size = new System.Drawing.Size( 195 , 500 );
			this.messageFolderTreeView.TabIndex = 1;
			this.messageFolderTreeView.DragDrop += new System.Windows.Forms.DragEventHandler( this.messageFolderTreeView_DragDrop );
			this.messageFolderTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.messageFolderTreeView_AfterSelect );
			this.messageFolderTreeView.DragEnter += new System.Windows.Forms.DragEventHandler( this.messageFolderTreeView_DragEnter );
			this.messageFolderTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler( this.messageFolderTreeView_NodeMouseClick );
			this.messageFolderTreeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler( this.messageFolderTreeView_ItemDrag );
			this.messageFolderTreeView.DragOver += new System.Windows.Forms.DragEventHandler( this.messageFolderTreeView_DragOver );
			// 
			// imageList
			// 
			this.imageList.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "imageList.ImageStream" ) ) );
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName( 0 , "message_priority_low.png" );
			this.imageList.Images.SetKeyName( 1 , "message_priority_normal.png" );
			this.imageList.Images.SetKeyName( 2 , "message_priority_high.png" );
			this.imageList.Images.SetKeyName( 3 , "folder.png" );
			this.imageList.Images.SetKeyName( 4 , "isnew_message.png" );
			this.imageList.Images.SetKeyName( 5 , "message_dot.png" );
			// 
			// toolStrip
			// 
			this.toolStrip.AutoSize = false;
			this.toolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.newMessageToolStripButton,
            this.replyToMessageToolStripButton,
            this.deleteMessageToolStripButton,
            this.moveMessageToolStripButton} );
			this.toolStrip.Location = new System.Drawing.Point( 0 , 0 );
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size( 737 , 35 );
			this.toolStrip.TabIndex = 32;
			this.toolStrip.Text = "toolStrip1";
			// 
			// newMessageToolStripButton
			// 
			this.newMessageToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.new_message;
			this.newMessageToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.newMessageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newMessageToolStripButton.Name = "newMessageToolStripButton";
			this.newMessageToolStripButton.Size = new System.Drawing.Size( 109 , 32 );
			this.newMessageToolStripButton.Text = "Nieuw Bericht";
			this.newMessageToolStripButton.Click += new System.EventHandler( this.newMessageToolStripButton_Click );
			// 
			// replyToMessageToolStripButton
			// 
			this.replyToMessageToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.reply_message;
			this.replyToMessageToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.replyToMessageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.replyToMessageToolStripButton.Name = "replyToMessageToolStripButton";
			this.replyToMessageToolStripButton.Size = new System.Drawing.Size( 152 , 32 );
			this.replyToMessageToolStripButton.Text = "Bericht Beantwoorden";
			this.replyToMessageToolStripButton.Click += new System.EventHandler( this.replyToMessageToolStripButton_Click );
			// 
			// deleteMessageToolStripButton
			// 
			this.deleteMessageToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.delete_message;
			this.deleteMessageToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.deleteMessageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.deleteMessageToolStripButton.Name = "deleteMessageToolStripButton";
			this.deleteMessageToolStripButton.Size = new System.Drawing.Size( 137 , 32 );
			this.deleteMessageToolStripButton.Text = "Bericht Verwijderen";
			this.deleteMessageToolStripButton.Click += new System.EventHandler( this.deleteMessageToolStripButton_Click );
			// 
			// moveMessageToolStripButton
			// 
			this.moveMessageToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.move_message;
			this.moveMessageToolStripButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.moveMessageToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.moveMessageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.moveMessageToolStripButton.Name = "moveMessageToolStripButton";
			this.moveMessageToolStripButton.Size = new System.Drawing.Size( 136 , 32 );
			this.moveMessageToolStripButton.Text = "Bericht Verplaatsen";
			this.moveMessageToolStripButton.Click += new System.EventHandler( this.moveMessageToolStripButton_Click );
			// 
			// messageBrowserView
			// 
			this.messageBrowserView.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.iconColumnHeader,
            this.subjectColumnHeader,
            this.fromColumnHeader,
            this.dateColumnHeader} );
			this.messageBrowserView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.messageBrowserView.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.messageBrowserView.FullRowSelect = true;
			this.messageBrowserView.GridLines = true;
			this.messageBrowserView.HideSelection = false;
			this.messageBrowserView.Location = new System.Drawing.Point( 0 , 5 );
			this.messageBrowserView.Name = "messageBrowserView";
			this.messageBrowserView.OwnerDraw = true;
			this.messageBrowserView.Renderer = browserViewRenderer1;
			browserViewScheme1.ColumnHeaderBackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 136 ) ) ) ) , ( (int)( ( (byte)( 180 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
			browserViewScheme1.ColumnHeaderBackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 71 ) ) ) ) , ( (int)( ( (byte)( 139 ) ) ) ) , ( (int)( ( (byte)( 158 ) ) ) ) );
			browserViewScheme1.ColumnHeaderBackgroundColor3 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 19 ) ) ) ) , ( (int)( ( (byte)( 97 ) ) ) ) , ( (int)( ( (byte)( 119 ) ) ) ) );
			browserViewScheme1.ColumnHeaderBackgroundColor4 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 83 ) ) ) ) , ( (int)( ( (byte)( 159 ) ) ) ) , ( (int)( ( (byte)( 171 ) ) ) ) );
			browserViewScheme1.ColumnHeaderCaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			browserViewScheme1.ColumnHeaderCaptionFont = new System.Drawing.Font( "Verdana" , 10F , System.Drawing.FontStyle.Bold );
			browserViewScheme1.ColumnHeaderCaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			browserViewScheme1.RowCaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			browserViewScheme1.RowCaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			browserViewScheme1.RowCaptionRendering = System.Drawing.Text.TextRenderingHint.SystemDefault;
			browserViewScheme1.RowHoveredBackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 248 ) ) ) ) , ( (int)( ( (byte)( 252 ) ) ) ) , ( (int)( ( (byte)( 254 ) ) ) ) );
			browserViewScheme1.RowHoveredBackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 245 ) ) ) ) , ( (int)( ( (byte)( 253 ) ) ) ) );
			browserViewScheme1.RowNormalBackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			browserViewScheme1.RowNormalBackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			browserViewScheme1.RowSelectedBackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 251 ) ) ) ) , ( (int)( ( (byte)( 253 ) ) ) ) );
			browserViewScheme1.RowSelectedBackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 213 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) , ( (int)( ( (byte)( 252 ) ) ) ) );
			this.messageBrowserView.Scheme = browserViewScheme1;
			this.messageBrowserView.Size = new System.Drawing.Size( 528 , 270 );
			this.messageBrowserView.SmallImageList = this.imageList;
			this.messageBrowserView.TabIndex = 0;
			this.messageBrowserView.UseCompatibleStateImageBehavior = false;
			this.messageBrowserView.View = System.Windows.Forms.View.Details;
			this.messageBrowserView.SelectedIndexChanged += new System.EventHandler( this.messageBrowserView_SelectedIndexChanged );
			this.messageBrowserView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler( this.messageBrowserView_ItemDrag );
			// 
			// iconColumnHeader
			// 
			this.iconColumnHeader.Text = "";
			this.iconColumnHeader.Width = 20;
			// 
			// subjectColumnHeader
			// 
			this.subjectColumnHeader.Text = "Onderwerp";
			this.subjectColumnHeader.Width = 313;
			// 
			// fromColumnHeader
			// 
			this.fromColumnHeader.Text = "Afzender";
			this.fromColumnHeader.Width = 95;
			// 
			// dateColumnHeader
			// 
			this.dateColumnHeader.Text = "Datum";
			this.dateColumnHeader.Width = 95;
			// 
			// contextMenuStrip
			// 
			this.contextMenuStrip.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.contextMenuStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.changeMessageFolderNameToolStripMenuItem,
            this.newMessageFolderToolStripMenuItem,
            this.removeMessageFolderNameToolStripMenuItem} );
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new System.Drawing.Size( 202 , 70 );
			// 
			// changeMessageFolderNameToolStripMenuItem
			// 
			this.changeMessageFolderNameToolStripMenuItem.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.reply;
			this.changeMessageFolderNameToolStripMenuItem.Name = "changeMessageFolderNameToolStripMenuItem";
			this.changeMessageFolderNameToolStripMenuItem.Size = new System.Drawing.Size( 201 , 22 );
			this.changeMessageFolderNameToolStripMenuItem.Text = "Naam wijzigen...";
			this.changeMessageFolderNameToolStripMenuItem.Click += new System.EventHandler( this.changeMessageFolderNameToolStripMenuItem_Click );
			// 
			// newMessageFolderToolStripMenuItem
			// 
			this.newMessageFolderToolStripMenuItem.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.action_add;
			this.newMessageFolderToolStripMenuItem.Name = "newMessageFolderToolStripMenuItem";
			this.newMessageFolderToolStripMenuItem.Size = new System.Drawing.Size( 201 , 22 );
			this.newMessageFolderToolStripMenuItem.Text = "Nieuwe submap...";
			this.newMessageFolderToolStripMenuItem.Click += new System.EventHandler( this.newMessageFolderToolStripMenuItem_Click );
			// 
			// removeMessageFolderNameToolStripMenuItem
			// 
			this.removeMessageFolderNameToolStripMenuItem.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.action_delete;
			this.removeMessageFolderNameToolStripMenuItem.Name = "removeMessageFolderNameToolStripMenuItem";
			this.removeMessageFolderNameToolStripMenuItem.Size = new System.Drawing.Size( 201 , 22 );
			this.removeMessageFolderNameToolStripMenuItem.Text = "Verwijderen";
			this.removeMessageFolderNameToolStripMenuItem.Click += new System.EventHandler( this.removeMessageFolderNameToolStripMenuItem_Click );
			// 
			// messageContents
			// 
			this.messageContents.BackColor = System.Drawing.Color.White;
			this.messageContents.Date = null;
			this.messageContents.Dock = System.Windows.Forms.DockStyle.Fill;
			this.messageContents.From = null;
			this.messageContents.Location = new System.Drawing.Point( 0 , 0 );
			this.messageContents.Name = "messageContents";
			this.messageContents.Renderer = messageContentsRenderer1;
			messageContentsScheme1.BigFont = new System.Drawing.Font( "Verdana" , 12F , System.Drawing.FontStyle.Bold );
			messageContentsScheme1.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			messageContentsScheme1.SmallFont = new System.Drawing.Font( "Verdana" , 10F );
			messageContentsScheme1.TextColor = System.Drawing.Color.White;
			messageContentsScheme1.TitleBackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 10 ) ) ) ) , ( (int)( ( (byte)( 75 ) ) ) ) , ( (int)( ( (byte)( 115 ) ) ) ) );
			messageContentsScheme1.TitleBackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 50 ) ) ) ) , ( (int)( ( (byte)( 175 ) ) ) ) , ( (int)( ( (byte)( 175 ) ) ) ) );
			this.messageContents.Scheme = messageContentsScheme1;
			this.messageContents.Size = new System.Drawing.Size( 528 , 226 );
			this.messageContents.Subject = null;
			this.messageContents.TabIndex = 33;
			this.messageContents.TitleHeight = 75;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point( 0 , 35 );
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add( this.messageFolderTreeView );
			this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding( 5 , 5 , 0 , 5 );
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add( this.splitContainer2 );
			this.splitContainer1.Size = new System.Drawing.Size( 737 , 510 );
			this.splitContainer1.SplitterDistance = 200;
			this.splitContainer1.TabIndex = 34;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point( 0 , 0 );
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add( this.messageBrowserView );
			this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding( 0 , 5 , 5 , 0 );
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add( this.messageContents );
			this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding( 0 , 0 , 5 , 5 );
			this.splitContainer2.Size = new System.Drawing.Size( 533 , 510 );
			this.splitContainer2.SplitterDistance = 275;
			this.splitContainer2.TabIndex = 0;
			// 
			// MessageModule
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add( this.splitContainer1 );
			this.Controls.Add( this.toolStrip );
			this.Name = "MessageModule";
			this.Size = new System.Drawing.Size( 737 , 545 );
			this.Load += new System.EventHandler( this.MessageModule_Load );
			this.toolStrip.ResumeLayout( false );
			this.toolStrip.PerformLayout();
			this.contextMenuStrip.ResumeLayout( false );
			this.splitContainer1.Panel1.ResumeLayout( false );
			this.splitContainer1.Panel2.ResumeLayout( false );
			this.splitContainer1.ResumeLayout( false );
			this.splitContainer2.Panel1.ResumeLayout( false );
			this.splitContainer2.Panel2.ResumeLayout( false );
			this.splitContainer2.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		private SwmSuite.Presentation.Common.BrowserView.BrowserViewControl messageBrowserView;
		private System.Windows.Forms.TreeView messageFolderTreeView;
		private System.Windows.Forms.ColumnHeader subjectColumnHeader;
		private System.Windows.Forms.ColumnHeader fromColumnHeader;
		private System.Windows.Forms.ColumnHeader dateColumnHeader;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton newMessageToolStripButton;
		private System.Windows.Forms.ToolStripButton replyToMessageToolStripButton;
		private System.Windows.Forms.ToolStripButton deleteMessageToolStripButton;
		private System.Windows.Forms.ToolStripButton moveMessageToolStripButton;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem changeMessageFolderNameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newMessageFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeMessageFolderNameToolStripMenuItem;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ColumnHeader iconColumnHeader;
		private SimpleWorkfloorManagementSuite.Controls.MessageContentsControl messageContents;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
	}
}
