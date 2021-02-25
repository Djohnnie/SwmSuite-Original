namespace SimpleWorkfloorManagementSuite.Modules {
	partial class LoggingModule {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( LoggingModule ) );
			SwmSuite.Presentation.Common.BrowserView.BrowserViewRenderer browserViewRenderer1 = new SwmSuite.Presentation.Common.BrowserView.BrowserViewRenderer();
			SwmSuite.Presentation.Common.BrowserView.BrowserViewScheme browserViewScheme1 = new SwmSuite.Presentation.Common.BrowserView.BrowserViewScheme();
			SwmSuite.Presentation.Common.BrowserView.BrowserViewRenderer browserViewRenderer2 = new SwmSuite.Presentation.Common.BrowserView.BrowserViewRenderer();
			SwmSuite.Presentation.Common.BrowserView.BrowserViewScheme browserViewScheme2 = new SwmSuite.Presentation.Common.BrowserView.BrowserViewScheme();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.connectionLogsToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.loginLogsToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.nextToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.selectionToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.previousToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.connectionsBrowserView = new SwmSuite.Presentation.Common.BrowserView.BrowserViewControl();
			this.dateTimeColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.clientColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.loginsBrowserView = new SwmSuite.Presentation.Common.BrowserView.BrowserViewControl();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.connectionLogBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.loginLogBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.circularProgressControl = new SwmSuite.Presentation.Common.UserControls.CircularProgressControl();
			this.toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.AutoSize = false;
			this.toolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.connectionLogsToolStripButton,
            this.loginLogsToolStripButton,
            this.nextToolStripButton,
            this.selectionToolStripButton,
            this.previousToolStripButton} );
			this.toolStrip.Location = new System.Drawing.Point( 0 , 0 );
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size( 602 , 35 );
			this.toolStrip.TabIndex = 35;
			this.toolStrip.Text = "toolStrip1";
			// 
			// connectionLogsToolStripButton
			// 
			this.connectionLogsToolStripButton.Checked = true;
			this.connectionLogsToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
			this.connectionLogsToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.logboek;
			this.connectionLogsToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.connectionLogsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.connectionLogsToolStripButton.Name = "connectionLogsToolStripButton";
			this.connectionLogsToolStripButton.Size = new System.Drawing.Size( 94 , 32 );
			this.connectionLogsToolStripButton.Text = "Connecties";
			this.connectionLogsToolStripButton.Click += new System.EventHandler( this.connectionLogsToolStripButton_Click );
			// 
			// loginLogsToolStripButton
			// 
			this.loginLogsToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.logboek;
			this.loginLogsToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.loginLogsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.loginLogsToolStripButton.Name = "loginLogsToolStripButton";
			this.loginLogsToolStripButton.Size = new System.Drawing.Size( 70 , 32 );
			this.loginLogsToolStripButton.Text = "Logins";
			this.loginLogsToolStripButton.Click += new System.EventHandler( this.loginLogsToolStripButton_Click );
			// 
			// nextToolStripButton
			// 
			this.nextToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.nextToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.next_year;
			this.nextToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.nextToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.nextToolStripButton.Name = "nextToolStripButton";
			this.nextToolStripButton.Size = new System.Drawing.Size( 23 , 32 );
			this.nextToolStripButton.ToolTipText = "Volgende week";
			this.nextToolStripButton.Click += new System.EventHandler( this.nextToolStripButton_Click );
			// 
			// selectionToolStripButton
			// 
			this.selectionToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.selectionToolStripButton.AutoSize = false;
			this.selectionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.selectionToolStripButton.Image = ( (System.Drawing.Image)( resources.GetObject( "selectionToolStripButton.Image" ) ) );
			this.selectionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.selectionToolStripButton.Name = "selectionToolStripButton";
			this.selectionToolStripButton.Size = new System.Drawing.Size( 100 , 32 );
			this.selectionToolStripButton.Text = "Juni 2009";
			// 
			// previousToolStripButton
			// 
			this.previousToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.previousToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.previous_year;
			this.previousToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.previousToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.previousToolStripButton.Name = "previousToolStripButton";
			this.previousToolStripButton.Size = new System.Drawing.Size( 23 , 32 );
			this.previousToolStripButton.ToolTipText = "Vorige week";
			this.previousToolStripButton.Click += new System.EventHandler( this.previousToolStripButton_Click );
			// 
			// connectionsBrowserView
			// 
			this.connectionsBrowserView.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.connectionsBrowserView.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.dateTimeColumnHeader,
            this.clientColumnHeader} );
			this.connectionsBrowserView.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.connectionsBrowserView.FullRowSelect = true;
			this.connectionsBrowserView.GridLines = true;
			this.connectionsBrowserView.Location = new System.Drawing.Point( 3 , 38 );
			this.connectionsBrowserView.Name = "connectionsBrowserView";
			this.connectionsBrowserView.OwnerDraw = true;
			this.connectionsBrowserView.Renderer = browserViewRenderer1;
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
			browserViewScheme1.RowSelectedBackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 220 ) ) ) ) , ( (int)( ( (byte)( 235 ) ) ) ) , ( (int)( ( (byte)( 252 ) ) ) ) );
			browserViewScheme1.RowSelectedBackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 193 ) ) ) ) , ( (int)( ( (byte)( 219 ) ) ) ) , ( (int)( ( (byte)( 252 ) ) ) ) );
			this.connectionsBrowserView.Scheme = browserViewScheme1;
			this.connectionsBrowserView.Size = new System.Drawing.Size( 596 , 354 );
			this.connectionsBrowserView.TabIndex = 36;
			this.connectionsBrowserView.UseCompatibleStateImageBehavior = false;
			this.connectionsBrowserView.View = System.Windows.Forms.View.Details;
			// 
			// dateTimeColumnHeader
			// 
			this.dateTimeColumnHeader.Text = "Datum / Tijd";
			this.dateTimeColumnHeader.Width = 238;
			// 
			// clientColumnHeader
			// 
			this.clientColumnHeader.Text = "Client";
			this.clientColumnHeader.Width = 353;
			// 
			// loginsBrowserView
			// 
			this.loginsBrowserView.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.loginsBrowserView.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2} );
			this.loginsBrowserView.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.loginsBrowserView.FullRowSelect = true;
			this.loginsBrowserView.GridLines = true;
			this.loginsBrowserView.Location = new System.Drawing.Point( 3 , 38 );
			this.loginsBrowserView.Name = "loginsBrowserView";
			this.loginsBrowserView.OwnerDraw = true;
			this.loginsBrowserView.Renderer = browserViewRenderer2;
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
			browserViewScheme2.RowSelectedBackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 220 ) ) ) ) , ( (int)( ( (byte)( 235 ) ) ) ) , ( (int)( ( (byte)( 252 ) ) ) ) );
			browserViewScheme2.RowSelectedBackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 193 ) ) ) ) , ( (int)( ( (byte)( 219 ) ) ) ) , ( (int)( ( (byte)( 252 ) ) ) ) );
			this.loginsBrowserView.Scheme = browserViewScheme2;
			this.loginsBrowserView.Size = new System.Drawing.Size( 596 , 354 );
			this.loginsBrowserView.TabIndex = 37;
			this.loginsBrowserView.UseCompatibleStateImageBehavior = false;
			this.loginsBrowserView.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Datum / Tijd";
			this.columnHeader1.Width = 238;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Gebruiker";
			this.columnHeader2.Width = 353;
			// 
			// connectionLogBackgroundWorker
			// 
			this.connectionLogBackgroundWorker.WorkerSupportsCancellation = true;
			this.connectionLogBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler( this.connectionLogBackgroundWorker_DoWork );
			this.connectionLogBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler( this.connectionLogBackgroundWorker_RunWorkerCompleted );
			// 
			// loginLogBackgroundWorker
			// 
			this.loginLogBackgroundWorker.WorkerSupportsCancellation = true;
			this.loginLogBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler( this.loginLogBackgroundWorker_DoWork );
			this.loginLogBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler( this.loginLogBackgroundWorker_RunWorkerCompleted );
			// 
			// circularProgressControl
			// 
			this.circularProgressControl.ActiveSegmentColour = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 35 ) ) ) ) , ( (int)( ( (byte)( 146 ) ) ) ) , ( (int)( ( (byte)( 33 ) ) ) ) );
			this.circularProgressControl.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.circularProgressControl.InactiveSegmentColour = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 218 ) ) ) ) , ( (int)( ( (byte)( 218 ) ) ) ) , ( (int)( ( (byte)( 218 ) ) ) ) );
			this.circularProgressControl.Location = new System.Drawing.Point( 276 , 172 );
			this.circularProgressControl.Name = "circularProgressControl";
			this.circularProgressControl.Size = new System.Drawing.Size( 50 , 50 );
			this.circularProgressControl.TabIndex = 38;
			this.circularProgressControl.TransistionSegmentColour = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 129 ) ) ) ) , ( (int)( ( (byte)( 242 ) ) ) ) , ( (int)( ( (byte)( 121 ) ) ) ) );
			this.circularProgressControl.Visible = false;
			// 
			// LoggingModule
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add( this.circularProgressControl );
			this.Controls.Add( this.loginsBrowserView );
			this.Controls.Add( this.connectionsBrowserView );
			this.Controls.Add( this.toolStrip );
			this.Name = "LoggingModule";
			this.Size = new System.Drawing.Size( 602 , 395 );
			this.Load += new System.EventHandler( this.LoggingModule_Load );
			this.toolStrip.ResumeLayout( false );
			this.toolStrip.PerformLayout();
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton connectionLogsToolStripButton;
		private System.Windows.Forms.ToolStripButton loginLogsToolStripButton;
		private SwmSuite.Presentation.Common.BrowserView.BrowserViewControl connectionsBrowserView;
		private System.Windows.Forms.ColumnHeader dateTimeColumnHeader;
		private System.Windows.Forms.ColumnHeader clientColumnHeader;
		private SwmSuite.Presentation.Common.BrowserView.BrowserViewControl loginsBrowserView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.ComponentModel.BackgroundWorker connectionLogBackgroundWorker;
		private System.ComponentModel.BackgroundWorker loginLogBackgroundWorker;
		private SwmSuite.Presentation.Common.UserControls.CircularProgressControl circularProgressControl;
		private System.Windows.Forms.ToolStripButton nextToolStripButton;
		private System.Windows.Forms.ToolStripButton selectionToolStripButton;
		private System.Windows.Forms.ToolStripButton previousToolStripButton;
	}
}
