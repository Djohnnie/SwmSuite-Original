namespace SimpleWorkfloorManagementSuite.Dialogs {
	partial class TimeTableTemplateManagementDialog {
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			SwmSuite.Presentation.Common.DialogHeader.DialogHeaderRenderer dialogHeaderRenderer1 = new SwmSuite.Presentation.Common.DialogHeader.DialogHeaderRenderer();
			SwmSuite.Presentation.Common.DialogHeader.DialogHeaderScheme dialogHeaderScheme1 = new SwmSuite.Presentation.Common.DialogHeader.DialogHeaderScheme();
			SwmSuite.Presentation.Common.BrowserView.BrowserViewRenderer browserViewRenderer1 = new SwmSuite.Presentation.Common.BrowserView.BrowserViewRenderer();
			SwmSuite.Presentation.Common.BrowserView.BrowserViewScheme browserViewScheme1 = new SwmSuite.Presentation.Common.BrowserView.BrowserViewScheme();
			SwmSuite.Presentation.Common.BrowserView.BrowserViewRenderer browserViewRenderer2 = new SwmSuite.Presentation.Common.BrowserView.BrowserViewRenderer();
			SwmSuite.Presentation.Common.BrowserView.BrowserViewScheme browserViewScheme2 = new SwmSuite.Presentation.Common.BrowserView.BrowserViewScheme();
			this.dialogHeaderControl = new SwmSuite.Presentation.Common.DialogHeader.DialogHeaderControl();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.editToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.removeToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.employeeGroupBrowserView = new SwmSuite.Presentation.Common.BrowserView.BrowserViewControl();
			this.titleColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.timeTableTemplateBrowserView = new SwmSuite.Presentation.Common.BrowserView.BrowserViewControl();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.toolStrip.SuspendLayout();
			this.panel1.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dialogHeaderControl
			// 
			this.dialogHeaderControl.Dock = System.Windows.Forms.DockStyle.Top;
			this.dialogHeaderControl.Location = new System.Drawing.Point( 0 , 0 );
			this.dialogHeaderControl.MainText = " Beheer van uurrooster sjablonen";
			this.dialogHeaderControl.Name = "dialogHeaderControl";
			this.dialogHeaderControl.OnlyMainText = true;
			this.dialogHeaderControl.Renderer = dialogHeaderRenderer1;
			dialogHeaderScheme1.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 10 ) ) ) ) , ( (int)( ( (byte)( 75 ) ) ) ) , ( (int)( ( (byte)( 115 ) ) ) ) );
			dialogHeaderScheme1.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 50 ) ) ) ) , ( (int)( ( (byte)( 175 ) ) ) ) , ( (int)( ( (byte)( 175 ) ) ) ) );
			dialogHeaderScheme1.SubTitleColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			dialogHeaderScheme1.SubTitleFont = new System.Drawing.Font( "Verdana" , 10F );
			dialogHeaderScheme1.SubTitleRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			dialogHeaderScheme1.TitleColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			dialogHeaderScheme1.TitleFont = new System.Drawing.Font( "Verdana" , 12F , System.Drawing.FontStyle.Bold );
			dialogHeaderScheme1.TitleRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			this.dialogHeaderControl.Scheme = dialogHeaderScheme1;
			this.dialogHeaderControl.Size = new System.Drawing.Size( 680 , 50 );
			this.dialogHeaderControl.SubText = "#Details#";
			this.dialogHeaderControl.TabIndex = 13;
			this.dialogHeaderControl.TabStop = false;
			// 
			// toolStrip
			// 
			this.toolStrip.AutoSize = false;
			this.toolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripButton,
            this.editToolStripButton,
            this.removeToolStripButton} );
			this.toolStrip.Location = new System.Drawing.Point( 0 , 50 );
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size( 680 , 35 );
			this.toolStrip.TabIndex = 37;
			this.toolStrip.Text = "toolStrip1";
			// 
			// addToolStripButton
			// 
			this.addToolStripButton.Enabled = false;
			this.addToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.add;
			this.addToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.addToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.addToolStripButton.Name = "addToolStripButton";
			this.addToolStripButton.Size = new System.Drawing.Size( 86 , 32 );
			this.addToolStripButton.Text = "Toevoegen";
			this.addToolStripButton.Click += new System.EventHandler( this.addToolStripButton_Click );
			// 
			// editToolStripButton
			// 
			this.editToolStripButton.Enabled = false;
			this.editToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.edit;
			this.editToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.editToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.editToolStripButton.Name = "editToolStripButton";
			this.editToolStripButton.Size = new System.Drawing.Size( 78 , 32 );
			this.editToolStripButton.Text = "Bewerken";
			this.editToolStripButton.Click += new System.EventHandler( this.editToolStripButton_Click );
			// 
			// removeToolStripButton
			// 
			this.removeToolStripButton.Enabled = false;
			this.removeToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.remove;
			this.removeToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.removeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.removeToolStripButton.Name = "removeToolStripButton";
			this.removeToolStripButton.Size = new System.Drawing.Size( 89 , 32 );
			this.removeToolStripButton.Text = "Verwijderen";
			this.removeToolStripButton.Click += new System.EventHandler( this.removeToolStripButton_Click );
			// 
			// panel1
			// 
			this.panel1.Controls.Add( this.splitContainer1 );
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point( 0 , 85 );
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding( 5 );
			this.panel1.Size = new System.Drawing.Size( 680 , 229 );
			this.panel1.TabIndex = 38;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point( 5 , 5 );
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add( this.employeeGroupBrowserView );
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add( this.timeTableTemplateBrowserView );
			this.splitContainer1.Size = new System.Drawing.Size( 670 , 219 );
			this.splitContainer1.SplitterDistance = 222;
			this.splitContainer1.TabIndex = 17;
			// 
			// employeeGroupBrowserView
			// 
			this.employeeGroupBrowserView.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.titleColumnHeader} );
			this.employeeGroupBrowserView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.employeeGroupBrowserView.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.employeeGroupBrowserView.FullRowSelect = true;
			this.employeeGroupBrowserView.GridLines = true;
			this.employeeGroupBrowserView.Location = new System.Drawing.Point( 0 , 0 );
			this.employeeGroupBrowserView.Name = "employeeGroupBrowserView";
			this.employeeGroupBrowserView.OwnerDraw = true;
			this.employeeGroupBrowserView.Renderer = browserViewRenderer1;
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
			this.employeeGroupBrowserView.Scheme = browserViewScheme1;
			this.employeeGroupBrowserView.Size = new System.Drawing.Size( 222 , 219 );
			this.employeeGroupBrowserView.TabIndex = 12;
			this.employeeGroupBrowserView.UseCompatibleStateImageBehavior = false;
			this.employeeGroupBrowserView.View = System.Windows.Forms.View.Details;
			this.employeeGroupBrowserView.SelectedIndexChanged += new System.EventHandler( this.employeeGroupBrowserView_SelectedIndexChanged );
			// 
			// titleColumnHeader
			// 
			this.titleColumnHeader.Text = "Personeelsgroep";
			this.titleColumnHeader.Width = 218;
			// 
			// timeTableTemplateBrowserView
			// 
			this.timeTableTemplateBrowserView.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1} );
			this.timeTableTemplateBrowserView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.timeTableTemplateBrowserView.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.timeTableTemplateBrowserView.FullRowSelect = true;
			this.timeTableTemplateBrowserView.GridLines = true;
			this.timeTableTemplateBrowserView.Location = new System.Drawing.Point( 0 , 0 );
			this.timeTableTemplateBrowserView.Name = "timeTableTemplateBrowserView";
			this.timeTableTemplateBrowserView.OwnerDraw = true;
			this.timeTableTemplateBrowserView.Renderer = browserViewRenderer2;
			browserViewScheme2.ColumnHeaderBackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 136 ) ) ) ) , ( (int)( ( (byte)( 180 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
			browserViewScheme2.ColumnHeaderBackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 71 ) ) ) ) , ( (int)( ( (byte)( 139 ) ) ) ) , ( (int)( ( (byte)( 158 ) ) ) ) );
			browserViewScheme2.ColumnHeaderBackgroundColor3 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 19 ) ) ) ) , ( (int)( ( (byte)( 97 ) ) ) ) , ( (int)( ( (byte)( 119 ) ) ) ) );
			browserViewScheme2.ColumnHeaderBackgroundColor4 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 83 ) ) ) ) , ( (int)( ( (byte)( 159 ) ) ) ) , ( (int)( ( (byte)( 171 ) ) ) ) );
			browserViewScheme2.ColumnHeaderCaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			browserViewScheme2.ColumnHeaderCaptionFont = new System.Drawing.Font( "Verdana" , 10F , System.Drawing.FontStyle.Bold );
			browserViewScheme2.ColumnHeaderCaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			browserViewScheme2.RowCaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			browserViewScheme2.RowCaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			browserViewScheme2.RowCaptionRendering = System.Drawing.Text.TextRenderingHint.SystemDefault;
			browserViewScheme2.RowHoveredBackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 248 ) ) ) ) , ( (int)( ( (byte)( 252 ) ) ) ) , ( (int)( ( (byte)( 254 ) ) ) ) );
			browserViewScheme2.RowHoveredBackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 245 ) ) ) ) , ( (int)( ( (byte)( 253 ) ) ) ) );
			browserViewScheme2.RowNormalBackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			browserViewScheme2.RowNormalBackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			browserViewScheme2.RowSelectedBackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 251 ) ) ) ) , ( (int)( ( (byte)( 253 ) ) ) ) );
			browserViewScheme2.RowSelectedBackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 213 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) , ( (int)( ( (byte)( 252 ) ) ) ) );
			this.timeTableTemplateBrowserView.Scheme = browserViewScheme2;
			this.timeTableTemplateBrowserView.Size = new System.Drawing.Size( 444 , 219 );
			this.timeTableTemplateBrowserView.TabIndex = 13;
			this.timeTableTemplateBrowserView.UseCompatibleStateImageBehavior = false;
			this.timeTableTemplateBrowserView.View = System.Windows.Forms.View.Details;
			this.timeTableTemplateBrowserView.SelectedIndexChanged += new System.EventHandler( this.timeTableTemplateBrowserView_SelectedIndexChanged );
			this.timeTableTemplateBrowserView.DoubleClick += new System.EventHandler( this.timeTableTemplateBrowserView_DoubleClick );
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Omschrijving";
			this.columnHeader1.Width = 440;
			// 
			// TimeTableTemplateManagementDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size( 680 , 314 );
			this.Controls.Add( this.panel1 );
			this.Controls.Add( this.toolStrip );
			this.Controls.Add( this.dialogHeaderControl );
			this.Name = "TimeTableTemplateManagementDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Simple Workfloor Management Suite";
			this.Load += new System.EventHandler( this.TimeTableTemplateManagementDialog_Load );
			this.toolStrip.ResumeLayout( false );
			this.toolStrip.PerformLayout();
			this.panel1.ResumeLayout( false );
			this.splitContainer1.Panel1.ResumeLayout( false );
			this.splitContainer1.Panel2.ResumeLayout( false );
			this.splitContainer1.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		private SwmSuite.Presentation.Common.DialogHeader.DialogHeaderControl dialogHeaderControl;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton addToolStripButton;
		private System.Windows.Forms.ToolStripButton editToolStripButton;
		private System.Windows.Forms.ToolStripButton removeToolStripButton;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private SwmSuite.Presentation.Common.BrowserView.BrowserViewControl employeeGroupBrowserView;
		private System.Windows.Forms.ColumnHeader titleColumnHeader;
		private SwmSuite.Presentation.Common.BrowserView.BrowserViewControl timeTableTemplateBrowserView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
	}
}