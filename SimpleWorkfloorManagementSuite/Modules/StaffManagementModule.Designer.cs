namespace SimpleWorkfloorManagementSuite.Modules {
	partial class StaffManagementModule {
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
			SwmSuite.Presentation.Common.Group.GroupRenderer groupRenderer1 = new SwmSuite.Presentation.Common.Group.GroupRenderer();
			SwmSuite.Presentation.Common.Group.GroupScheme groupScheme1 = new SwmSuite.Presentation.Common.Group.GroupScheme();
			SwmSuite.Presentation.Common.BrowserView.BrowserViewRenderer browserViewRenderer1 = new SwmSuite.Presentation.Common.BrowserView.BrowserViewRenderer();
			SwmSuite.Presentation.Common.BrowserView.BrowserViewScheme browserViewScheme1 = new SwmSuite.Presentation.Common.BrowserView.BrowserViewScheme();
			SwmSuite.Presentation.Common.Group.GroupRenderer groupRenderer2 = new SwmSuite.Presentation.Common.Group.GroupRenderer();
			SwmSuite.Presentation.Common.Group.GroupScheme groupScheme2 = new SwmSuite.Presentation.Common.Group.GroupScheme();
			SwmSuite.Presentation.Common.BrowserView.BrowserViewRenderer browserViewRenderer2 = new SwmSuite.Presentation.Common.BrowserView.BrowserViewRenderer();
			SwmSuite.Presentation.Common.BrowserView.BrowserViewScheme browserViewScheme2 = new SwmSuite.Presentation.Common.BrowserView.BrowserViewScheme();
			this.employeeGroupBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.employeeBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.groupControl2 = new SwmSuite.Presentation.Common.Group.GroupControl();
			this.panel2 = new System.Windows.Forms.Panel();
			this.employeeBrowserView = new SwmSuite.Presentation.Common.BrowserView.BrowserViewControl();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.employeeToolStrip = new System.Windows.Forms.ToolStrip();
			this.deleteEmployeeToolstripButton = new System.Windows.Forms.ToolStripButton();
			this.editEmployeeToolstripButton = new System.Windows.Forms.ToolStripButton();
			this.addEmployeeToolstripButton = new System.Windows.Forms.ToolStripButton();
			this.groupControl1 = new SwmSuite.Presentation.Common.Group.GroupControl();
			this.panel1 = new System.Windows.Forms.Panel();
			this.employeeGroupBrowserView = new SwmSuite.Presentation.Common.BrowserView.BrowserViewControl();
			this.nameColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.employeeGroupToolStrip = new System.Windows.Forms.ToolStrip();
			this.deleteEmployeeGroupToolstripButton = new System.Windows.Forms.ToolStripButton();
			this.editEmployeeGroupToolstripButton = new System.Windows.Forms.ToolStripButton();
			this.addEmployeeGroupToolstripButton = new System.Windows.Forms.ToolStripButton();
			this.groupControl2.SuspendLayout();
			this.panel2.SuspendLayout();
			this.employeeToolStrip.SuspendLayout();
			this.groupControl1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.employeeGroupToolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// employeeGroupBackgroundWorker
			// 
			this.employeeGroupBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler( this.employeeGroupBackgroundWorker_DoWork );
			this.employeeGroupBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler( this.employeeGroupBackgroundWorker_RunWorkerCompleted );
			// 
			// employeeBackgroundWorker
			// 
			this.employeeBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler( this.employeeBackgroundWorker_DoWork );
			this.employeeBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler( this.employeeBackgroundWorker_RunWorkerCompleted );
			// 
			// groupControl2
			// 
			this.groupControl2.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.groupControl2.Caption = "Personeelsleden";
			this.groupControl2.Controls.Add( this.panel2 );
			this.groupControl2.Controls.Add( this.employeeToolStrip );
			this.groupControl2.Location = new System.Drawing.Point( 307 , 3 );
			this.groupControl2.Name = "groupControl2";
			this.groupControl2.Padding = new System.Windows.Forms.Padding( 0 , 20 , 0 , 0 );
			this.groupControl2.Renderer = groupRenderer1;
			groupScheme1.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			groupScheme1.BorderWidth = 1;
			groupScheme1.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			groupScheme1.CaptionFont = new System.Drawing.Font( "Copperplate Gothic Light" , 10F );
			this.groupControl2.Scheme = groupScheme1;
			this.groupControl2.Size = new System.Drawing.Size( 434 , 488 );
			this.groupControl2.TabIndex = 6;
			// 
			// panel2
			// 
			this.panel2.Controls.Add( this.employeeBrowserView );
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point( 0 , 20 );
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding( 5 );
			this.panel2.Size = new System.Drawing.Size( 434 , 433 );
			this.panel2.TabIndex = 3;
			// 
			// employeeBrowserView
			// 
			this.employeeBrowserView.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4} );
			this.employeeBrowserView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.employeeBrowserView.Font = new System.Drawing.Font( "Verdana" , 9.75F );
			this.employeeBrowserView.FullRowSelect = true;
			this.employeeBrowserView.GridLines = true;
			this.employeeBrowserView.Location = new System.Drawing.Point( 5 , 5 );
			this.employeeBrowserView.Name = "employeeBrowserView";
			this.employeeBrowserView.OwnerDraw = true;
			this.employeeBrowserView.Renderer = browserViewRenderer1;
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
			this.employeeBrowserView.Scheme = browserViewScheme1;
			this.employeeBrowserView.Size = new System.Drawing.Size( 424 , 423 );
			this.employeeBrowserView.TabIndex = 1;
			this.employeeBrowserView.UseCompatibleStateImageBehavior = false;
			this.employeeBrowserView.View = System.Windows.Forms.View.Details;
			this.employeeBrowserView.SelectedIndexChanged += new System.EventHandler( this.employeeBrowserView_SelectedIndexChanged );
			this.employeeBrowserView.DoubleClick += new System.EventHandler( this.employeeBrowserView_DoubleClick );
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Voornaam";
			this.columnHeader3.Width = 177;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Naam";
			this.columnHeader4.Width = 242;
			// 
			// employeeToolStrip
			// 
			this.employeeToolStrip.AutoSize = false;
			this.employeeToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.employeeToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.employeeToolStrip.ImageScalingSize = new System.Drawing.Size( 32 , 32 );
			this.employeeToolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.deleteEmployeeToolstripButton,
            this.editEmployeeToolstripButton,
            this.addEmployeeToolstripButton} );
			this.employeeToolStrip.Location = new System.Drawing.Point( 0 , 453 );
			this.employeeToolStrip.Name = "employeeToolStrip";
			this.employeeToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.employeeToolStrip.Size = new System.Drawing.Size( 434 , 35 );
			this.employeeToolStrip.TabIndex = 2;
			this.employeeToolStrip.Text = "toolStrip1";
			// 
			// deleteEmployeeToolstripButton
			// 
			this.deleteEmployeeToolstripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.deleteEmployeeToolstripButton.Enabled = false;
			this.deleteEmployeeToolstripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.remove;
			this.deleteEmployeeToolstripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.deleteEmployeeToolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.deleteEmployeeToolstripButton.Name = "deleteEmployeeToolstripButton";
			this.deleteEmployeeToolstripButton.Size = new System.Drawing.Size( 89 , 32 );
			this.deleteEmployeeToolstripButton.Text = "Verwijderen";
			this.deleteEmployeeToolstripButton.ToolTipText = "Geselecteerde personeelsleden verwijderen";
			this.deleteEmployeeToolstripButton.Click += new System.EventHandler( this.deleteEmployeeToolstripButton_Click );
			// 
			// editEmployeeToolstripButton
			// 
			this.editEmployeeToolstripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.editEmployeeToolstripButton.Enabled = false;
			this.editEmployeeToolstripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.edit;
			this.editEmployeeToolstripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.editEmployeeToolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.editEmployeeToolstripButton.Name = "editEmployeeToolstripButton";
			this.editEmployeeToolstripButton.Size = new System.Drawing.Size( 78 , 32 );
			this.editEmployeeToolstripButton.Text = "Bewerken";
			this.editEmployeeToolstripButton.ToolTipText = "Geselecteerd personeelslid bewerken";
			this.editEmployeeToolstripButton.Click += new System.EventHandler( this.editEmployeeToolstripButton_Click );
			// 
			// addEmployeeToolstripButton
			// 
			this.addEmployeeToolstripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.addEmployeeToolstripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.add;
			this.addEmployeeToolstripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.addEmployeeToolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.addEmployeeToolstripButton.Name = "addEmployeeToolstripButton";
			this.addEmployeeToolstripButton.Size = new System.Drawing.Size( 86 , 32 );
			this.addEmployeeToolstripButton.Text = "Toevoegen";
			this.addEmployeeToolstripButton.ToolTipText = "Nieuw personeelslid toevoegen";
			this.addEmployeeToolstripButton.Click += new System.EventHandler( this.addEmployeeToolstripButton_Click );
			// 
			// groupControl1
			// 
			this.groupControl1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Left ) ) );
			this.groupControl1.Caption = "Personeelsgroepen";
			this.groupControl1.Controls.Add( this.panel1 );
			this.groupControl1.Controls.Add( this.employeeGroupToolStrip );
			this.groupControl1.Location = new System.Drawing.Point( 3 , 3 );
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Padding = new System.Windows.Forms.Padding( 0 , 20 , 0 , 0 );
			this.groupControl1.Renderer = groupRenderer2;
			groupScheme2.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			groupScheme2.BorderWidth = 1;
			groupScheme2.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			groupScheme2.CaptionFont = new System.Drawing.Font( "Copperplate Gothic Light" , 10F );
			this.groupControl1.Scheme = groupScheme2;
			this.groupControl1.Size = new System.Drawing.Size( 303 , 488 );
			this.groupControl1.TabIndex = 5;
			// 
			// panel1
			// 
			this.panel1.Controls.Add( this.employeeGroupBrowserView );
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point( 0 , 20 );
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding( 5 );
			this.panel1.Size = new System.Drawing.Size( 303 , 433 );
			this.panel1.TabIndex = 4;
			// 
			// employeeGroupBrowserView
			// 
			this.employeeGroupBrowserView.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader} );
			this.employeeGroupBrowserView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.employeeGroupBrowserView.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.employeeGroupBrowserView.FullRowSelect = true;
			this.employeeGroupBrowserView.GridLines = true;
			this.employeeGroupBrowserView.Location = new System.Drawing.Point( 5 , 5 );
			this.employeeGroupBrowserView.Name = "employeeGroupBrowserView";
			this.employeeGroupBrowserView.OwnerDraw = true;
			this.employeeGroupBrowserView.Renderer = browserViewRenderer2;
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
			this.employeeGroupBrowserView.Scheme = browserViewScheme2;
			this.employeeGroupBrowserView.Size = new System.Drawing.Size( 293 , 423 );
			this.employeeGroupBrowserView.TabIndex = 1;
			this.employeeGroupBrowserView.UseCompatibleStateImageBehavior = false;
			this.employeeGroupBrowserView.View = System.Windows.Forms.View.Details;
			this.employeeGroupBrowserView.SelectedIndexChanged += new System.EventHandler( this.employeeGroupBrowserView_SelectedIndexChanged );
			this.employeeGroupBrowserView.DoubleClick += new System.EventHandler( this.employeeGroupBrowserView_DoubleClick );
			// 
			// nameColumnHeader
			// 
			this.nameColumnHeader.Text = "Naam";
			this.nameColumnHeader.Width = 289;
			// 
			// employeeGroupToolStrip
			// 
			this.employeeGroupToolStrip.AutoSize = false;
			this.employeeGroupToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.employeeGroupToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.employeeGroupToolStrip.ImageScalingSize = new System.Drawing.Size( 32 , 32 );
			this.employeeGroupToolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.deleteEmployeeGroupToolstripButton,
            this.editEmployeeGroupToolstripButton,
            this.addEmployeeGroupToolstripButton} );
			this.employeeGroupToolStrip.Location = new System.Drawing.Point( 0 , 453 );
			this.employeeGroupToolStrip.Name = "employeeGroupToolStrip";
			this.employeeGroupToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.employeeGroupToolStrip.Size = new System.Drawing.Size( 303 , 35 );
			this.employeeGroupToolStrip.TabIndex = 3;
			this.employeeGroupToolStrip.Text = "toolStrip2";
			// 
			// deleteEmployeeGroupToolstripButton
			// 
			this.deleteEmployeeGroupToolstripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.deleteEmployeeGroupToolstripButton.Enabled = false;
			this.deleteEmployeeGroupToolstripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.remove;
			this.deleteEmployeeGroupToolstripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.deleteEmployeeGroupToolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.deleteEmployeeGroupToolstripButton.Name = "deleteEmployeeGroupToolstripButton";
			this.deleteEmployeeGroupToolstripButton.Size = new System.Drawing.Size( 89 , 32 );
			this.deleteEmployeeGroupToolstripButton.Text = "Verwijderen";
			this.deleteEmployeeGroupToolstripButton.ToolTipText = "Geselecteerde personeelsgroepen verwijderen";
			this.deleteEmployeeGroupToolstripButton.Click += new System.EventHandler( this.deleteEmployeeGroupToolstripButton_Click );
			// 
			// editEmployeeGroupToolstripButton
			// 
			this.editEmployeeGroupToolstripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.editEmployeeGroupToolstripButton.Enabled = false;
			this.editEmployeeGroupToolstripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.edit;
			this.editEmployeeGroupToolstripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.editEmployeeGroupToolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.editEmployeeGroupToolstripButton.Name = "editEmployeeGroupToolstripButton";
			this.editEmployeeGroupToolstripButton.Size = new System.Drawing.Size( 78 , 32 );
			this.editEmployeeGroupToolstripButton.Text = "Bewerken";
			this.editEmployeeGroupToolstripButton.ToolTipText = "Geselecteerde personeelsgroep bewerken";
			this.editEmployeeGroupToolstripButton.Click += new System.EventHandler( this.editEmployeeGroupToolstripButton_Click );
			// 
			// addEmployeeGroupToolstripButton
			// 
			this.addEmployeeGroupToolstripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.addEmployeeGroupToolstripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.add;
			this.addEmployeeGroupToolstripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.addEmployeeGroupToolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.addEmployeeGroupToolstripButton.Name = "addEmployeeGroupToolstripButton";
			this.addEmployeeGroupToolstripButton.Size = new System.Drawing.Size( 86 , 32 );
			this.addEmployeeGroupToolstripButton.Text = "Toevoegen";
			this.addEmployeeGroupToolstripButton.ToolTipText = "Personeelsgroep toevoegen";
			this.addEmployeeGroupToolstripButton.Click += new System.EventHandler( this.addEmployeeGroupToolstripButton_Click );
			// 
			// StaffManagementModule
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add( this.groupControl2 );
			this.Controls.Add( this.groupControl1 );
			this.Name = "StaffManagementModule";
			this.Size = new System.Drawing.Size( 744 , 494 );
			this.groupControl2.ResumeLayout( false );
			this.panel2.ResumeLayout( false );
			this.employeeToolStrip.ResumeLayout( false );
			this.employeeToolStrip.PerformLayout();
			this.groupControl1.ResumeLayout( false );
			this.panel1.ResumeLayout( false );
			this.employeeGroupToolStrip.ResumeLayout( false );
			this.employeeGroupToolStrip.PerformLayout();
			this.ResumeLayout( false );

		}

		#endregion

		private SwmSuite.Presentation.Common.Group.GroupControl groupControl2;
		private System.Windows.Forms.ToolStrip employeeToolStrip;
		private System.Windows.Forms.ToolStripButton editEmployeeToolstripButton;
		private System.Windows.Forms.ToolStripButton addEmployeeToolstripButton;
		private SwmSuite.Presentation.Common.BrowserView.BrowserViewControl employeeBrowserView;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private SwmSuite.Presentation.Common.Group.GroupControl groupControl1;
		private System.Windows.Forms.ToolStrip employeeGroupToolStrip;
		private System.Windows.Forms.ToolStripButton editEmployeeGroupToolstripButton;
		private System.Windows.Forms.ToolStripButton addEmployeeGroupToolstripButton;
		private SwmSuite.Presentation.Common.BrowserView.BrowserViewControl employeeGroupBrowserView;
		private System.Windows.Forms.ColumnHeader nameColumnHeader;
		private System.ComponentModel.BackgroundWorker employeeGroupBackgroundWorker;
		private System.ComponentModel.BackgroundWorker employeeBackgroundWorker;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ToolStripButton deleteEmployeeToolstripButton;
		private System.Windows.Forms.ToolStripButton deleteEmployeeGroupToolstripButton;
	}
}
