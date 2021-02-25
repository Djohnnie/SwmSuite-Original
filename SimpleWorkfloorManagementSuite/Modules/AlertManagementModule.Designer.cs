namespace SimpleWorkfloorManagementSuite.Modules {
	partial class AlertManagementModule {
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
			SwmSuite.Presentation.Common.BrowserView.BrowserViewRenderer browserViewRenderer1 = new SwmSuite.Presentation.Common.BrowserView.BrowserViewRenderer();
			SwmSuite.Presentation.Common.BrowserView.BrowserViewScheme browserViewScheme1 = new SwmSuite.Presentation.Common.BrowserView.BrowserViewScheme();
			this.alertBrowserView = new SwmSuite.Presentation.Common.BrowserView.BrowserViewControl();
			this.messageColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.panel1 = new System.Windows.Forms.Panel();
			this.addAlertToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.editAlertToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.deleteAlertToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStrip.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// alertBrowserView
			// 
			this.alertBrowserView.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.messageColumnHeader} );
			this.alertBrowserView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.alertBrowserView.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.alertBrowserView.FullRowSelect = true;
			this.alertBrowserView.GridLines = true;
			this.alertBrowserView.Location = new System.Drawing.Point( 5 , 5 );
			this.alertBrowserView.Name = "alertBrowserView";
			this.alertBrowserView.OwnerDraw = true;
			this.alertBrowserView.Renderer = browserViewRenderer1;
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
			this.alertBrowserView.Scheme = browserViewScheme1;
			this.alertBrowserView.Size = new System.Drawing.Size( 591 , 479 );
			this.alertBrowserView.TabIndex = 1;
			this.alertBrowserView.UseCompatibleStateImageBehavior = false;
			this.alertBrowserView.View = System.Windows.Forms.View.Details;
			this.alertBrowserView.SelectedIndexChanged += new System.EventHandler( this.alertBrowserView_SelectedIndexChanged );
			this.alertBrowserView.DoubleClick += new System.EventHandler( this.alertBrowserView_DoubleClick );
			// 
			// messageColumnHeader
			// 
			this.messageColumnHeader.Text = "Naam";
			this.messageColumnHeader.Width = 587;
			// 
			// toolStrip
			// 
			this.toolStrip.AutoSize = false;
			this.toolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.addAlertToolStripButton,
            this.editAlertToolStripButton,
            this.deleteAlertToolStripButton} );
			this.toolStrip.Location = new System.Drawing.Point( 0 , 0 );
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size( 601 , 35 );
			this.toolStrip.TabIndex = 94;
			this.toolStrip.Text = "toolStrip1";
			// 
			// panel1
			// 
			this.panel1.Controls.Add( this.alertBrowserView );
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point( 0 , 35 );
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding( 5 );
			this.panel1.Size = new System.Drawing.Size( 601 , 489 );
			this.panel1.TabIndex = 95;
			// 
			// addAlertToolStripButton
			// 
			this.addAlertToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.add;
			this.addAlertToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.addAlertToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.addAlertToolStripButton.Name = "addAlertToolStripButton";
			this.addAlertToolStripButton.Size = new System.Drawing.Size( 161 , 32 );
			this.addAlertToolStripButton.Text = "Aankondiging toevoegen";
			this.addAlertToolStripButton.Click += new System.EventHandler( this.addAlertToolstripButton_Click );
			// 
			// editAlertToolStripButton
			// 
			this.editAlertToolStripButton.Enabled = false;
			this.editAlertToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.edit;
			this.editAlertToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.editAlertToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.editAlertToolStripButton.Name = "editAlertToolStripButton";
			this.editAlertToolStripButton.Size = new System.Drawing.Size( 148 , 32 );
			this.editAlertToolStripButton.Text = "Aankondiging wijzigen";
			this.editAlertToolStripButton.Click += new System.EventHandler( this.editAlertToolstripButton_Click );
			// 
			// deleteAlertToolStripButton
			// 
			this.deleteAlertToolStripButton.Enabled = false;
			this.deleteAlertToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.remove;
			this.deleteAlertToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.deleteAlertToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.deleteAlertToolStripButton.Name = "deleteAlertToolStripButton";
			this.deleteAlertToolStripButton.Size = new System.Drawing.Size( 166 , 32 );
			this.deleteAlertToolStripButton.Text = "Aankondiging verwijderen";
			this.deleteAlertToolStripButton.Click += new System.EventHandler( this.deleteAlertToolstripButton_Click );
			// 
			// AlertManagementModule
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add( this.panel1 );
			this.Controls.Add( this.toolStrip );
			this.Name = "AlertManagementModule";
			this.Size = new System.Drawing.Size( 601 , 524 );
			this.toolStrip.ResumeLayout( false );
			this.toolStrip.PerformLayout();
			this.panel1.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		private SwmSuite.Presentation.Common.BrowserView.BrowserViewControl alertBrowserView;
		private System.Windows.Forms.ColumnHeader messageColumnHeader;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton addAlertToolStripButton;
		private System.Windows.Forms.ToolStripButton editAlertToolStripButton;
		private System.Windows.Forms.ToolStripButton deleteAlertToolStripButton;
		private System.Windows.Forms.Panel panel1;
	}
}
