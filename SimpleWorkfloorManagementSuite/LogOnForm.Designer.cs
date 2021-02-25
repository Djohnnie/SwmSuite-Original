namespace SimpleWorkfloorManagementSuite
{
    partial class LogOnForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			  this.components = new System.ComponentModel.Container();
			  SwmSuite.Presentation.Common.Marquee.MarqueeRenderer marqueeRenderer1 = new SwmSuite.Presentation.Common.Marquee.MarqueeRenderer();
			  SwmSuite.Presentation.Common.Marquee.MarqueeScheme marqueeScheme1 = new SwmSuite.Presentation.Common.Marquee.MarqueeScheme();
			  SwmSuite.Presentation.Common.Marquee.MarqueeRenderer marqueeRenderer2 = new SwmSuite.Presentation.Common.Marquee.MarqueeRenderer();
			  SwmSuite.Presentation.Common.Marquee.MarqueeScheme marqueeScheme2 = new SwmSuite.Presentation.Common.Marquee.MarqueeScheme();
			  SwmSuite.Presentation.Common.Marquee.MarqueeRenderer marqueeRenderer3 = new SwmSuite.Presentation.Common.Marquee.MarqueeRenderer();
			  SwmSuite.Presentation.Common.Marquee.MarqueeScheme marqueeScheme3 = new SwmSuite.Presentation.Common.Marquee.MarqueeScheme();
			  SwmSuite.Presentation.Common.Status.StatusRenderer statusRenderer1 = new SwmSuite.Presentation.Common.Status.StatusRenderer();
			  SwmSuite.Presentation.Common.Status.StatusScheme statusScheme1 = new SwmSuite.Presentation.Common.Status.StatusScheme();
			  SwmSuite.Presentation.Common.EmployeeGroupTab.EmployeeGroupTabRenderer employeeGroupTabRenderer1 = new SwmSuite.Presentation.Common.EmployeeGroupTab.EmployeeGroupTabRenderer();
			  SwmSuite.Presentation.Common.EmployeeGroupTab.EmployeeGroupTabScheme employeeGroupTabScheme1 = new SwmSuite.Presentation.Common.EmployeeGroupTab.EmployeeGroupTabScheme();
			  SwmSuite.Presentation.Common.ModuleWindowHeader.ModuleWindowHeaderRenderer moduleWindowHeaderRenderer1 = new SwmSuite.Presentation.Common.ModuleWindowHeader.ModuleWindowHeaderRenderer();
			  SwmSuite.Presentation.Common.ModuleWindowHeader.ModuleWindowHeaderScheme moduleWindowHeaderScheme1 = new SwmSuite.Presentation.Common.ModuleWindowHeader.ModuleWindowHeaderScheme();
			  SwmSuite.Presentation.Common.MirrorText.MirrorTextRenderer mirrorTextRenderer1 = new SwmSuite.Presentation.Common.MirrorText.MirrorTextRenderer();
			  SwmSuite.Presentation.Common.MirrorText.MirrorTextScheme mirrorTextScheme1 = new SwmSuite.Presentation.Common.MirrorText.MirrorTextScheme();
			  SwmSuite.Presentation.Common.AnalogClock.AnalogClockRenderer analogClockRenderer1 = new SwmSuite.Presentation.Common.AnalogClock.AnalogClockRenderer();
			  SwmSuite.Presentation.Common.AnalogClock.AnalogClockScheme analogClockScheme1 = new SwmSuite.Presentation.Common.AnalogClock.AnalogClockScheme();
			  System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( LogOnForm ) );
			  this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip( this.components );
			  this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			  this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			  this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			  this.panel1 = new System.Windows.Forms.Panel();
			  this.infoButton = new SwmSuite.Presentation.Common.Marquee.MarqueeButtonControl();
			  this.quitButton = new SwmSuite.Presentation.Common.Marquee.MarqueeButtonControl();
			  this.marqueeControl = new SwmSuite.Presentation.Common.Marquee.MarqueeControl();
			  this.statusControl = new SwmSuite.Presentation.Common.Status.StatusControl();
			  this.employeeGroupTabControl = new SwmSuite.Presentation.Common.EmployeeGroupTab.EmployeeGroupTabControl();
			  this.moduleWindowHeaderControl1 = new SwmSuite.Presentation.Common.ModuleWindowHeader.ModuleWindowHeaderControl();
			  this.pictureBox1 = new System.Windows.Forms.PictureBox();
			  this.mirrorTextControl1 = new SwmSuite.Presentation.Common.MirrorText.MirrorTextControl();
			  this.analogClockControl1 = new SwmSuite.Presentation.Common.AnalogClock.AnalogClockControl();
			  this.employeeGroupBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			  this.alertBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			  this.loginGroup = new SimpleWorkfloorManagementSuite.Controls.LoginGroup();
			  this.loginBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			  this.contextMenuStrip.SuspendLayout();
			  this.panel1.SuspendLayout();
			  this.moduleWindowHeaderControl1.SuspendLayout();
			  ( (System.ComponentModel.ISupportInitialize)( this.pictureBox1 ) ).BeginInit();
			  this.SuspendLayout();
			  // 
			  // contextMenuStrip
			  // 
			  this.contextMenuStrip.Font = new System.Drawing.Font( "Verdana" , 10F );
			  this.contextMenuStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem,
            this.connectionToolStripMenuItem,
            this.exitToolStripMenuItem} );
			  this.contextMenuStrip.Name = "contextMenuStrip";
			  this.contextMenuStrip.Size = new System.Drawing.Size( 240 , 70 );
			  // 
			  // infoToolStripMenuItem
			  // 
			  this.infoToolStripMenuItem.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.reply;
			  this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
			  this.infoToolStripMenuItem.Size = new System.Drawing.Size( 239 , 22 );
			  this.infoToolStripMenuItem.Text = "SwmSuite info...";
			  this.infoToolStripMenuItem.Click += new System.EventHandler( this.infoToolStripMenuItem_Click );
			  // 
			  // connectionToolStripMenuItem
			  // 
			  this.connectionToolStripMenuItem.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.action_add;
			  this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
			  this.connectionToolStripMenuItem.Size = new System.Drawing.Size( 239 , 22 );
			  this.connectionToolStripMenuItem.Text = "SwmSuite verbinding...";
			  this.connectionToolStripMenuItem.Click += new System.EventHandler( this.connectionToolStripMenuItem_Click );
			  // 
			  // exitToolStripMenuItem
			  // 
			  this.exitToolStripMenuItem.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.action_delete;
			  this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			  this.exitToolStripMenuItem.Size = new System.Drawing.Size( 239 , 22 );
			  this.exitToolStripMenuItem.Text = "SwmSuite beëindigen";
			  this.exitToolStripMenuItem.Click += new System.EventHandler( this.exitToolStripMenuItem_Click );
			  // 
			  // panel1
			  // 
			  this.panel1.Controls.Add( this.infoButton );
			  this.panel1.Controls.Add( this.quitButton );
			  this.panel1.Controls.Add( this.marqueeControl );
			  this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			  this.panel1.Location = new System.Drawing.Point( 0 , 706 );
			  this.panel1.Name = "panel1";
			  this.panel1.Size = new System.Drawing.Size( 1024 , 42 );
			  this.panel1.TabIndex = 10;
			  // 
			  // infoButton
			  // 
			  this.infoButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							  | System.Windows.Forms.AnchorStyles.Right ) ) );
			  this.infoButton.Caption = "Info";
			  this.infoButton.Cursor = System.Windows.Forms.Cursors.Hand;
			  this.infoButton.Location = new System.Drawing.Point( 874 , 0 );
			  this.infoButton.Name = "infoButton";
			  this.infoButton.Renderer = marqueeRenderer1;
			  marqueeScheme1.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 136 ) ) ) ) , ( (int)( ( (byte)( 180 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
			  marqueeScheme1.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 71 ) ) ) ) , ( (int)( ( (byte)( 139 ) ) ) ) , ( (int)( ( (byte)( 158 ) ) ) ) );
			  marqueeScheme1.BackgroundColor3 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 19 ) ) ) ) , ( (int)( ( (byte)( 97 ) ) ) ) , ( (int)( ( (byte)( 119 ) ) ) ) );
			  marqueeScheme1.BackgroundColor4 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 83 ) ) ) ) , ( (int)( ( (byte)( 159 ) ) ) ) , ( (int)( ( (byte)( 171 ) ) ) ) );
			  marqueeScheme1.TextColor = System.Drawing.Color.White;
			  marqueeScheme1.TextFont = new System.Drawing.Font( "Copperplate Gothic Light" , 12F );
			  this.infoButton.Scheme = marqueeScheme1;
			  this.infoButton.Size = new System.Drawing.Size( 150 , 42 );
			  this.infoButton.TabIndex = 13;
			  this.infoButton.Click += new System.EventHandler( this.infoButton_Click );
			  // 
			  // quitButton
			  // 
			  this.quitButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							  | System.Windows.Forms.AnchorStyles.Left ) ) );
			  this.quitButton.Caption = "Afsluiten";
			  this.quitButton.Cursor = System.Windows.Forms.Cursors.Hand;
			  this.quitButton.Location = new System.Drawing.Point( 0 , 0 );
			  this.quitButton.Name = "quitButton";
			  this.quitButton.Renderer = marqueeRenderer2;
			  marqueeScheme2.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 136 ) ) ) ) , ( (int)( ( (byte)( 180 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
			  marqueeScheme2.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 71 ) ) ) ) , ( (int)( ( (byte)( 139 ) ) ) ) , ( (int)( ( (byte)( 158 ) ) ) ) );
			  marqueeScheme2.BackgroundColor3 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 19 ) ) ) ) , ( (int)( ( (byte)( 97 ) ) ) ) , ( (int)( ( (byte)( 119 ) ) ) ) );
			  marqueeScheme2.BackgroundColor4 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 83 ) ) ) ) , ( (int)( ( (byte)( 159 ) ) ) ) , ( (int)( ( (byte)( 171 ) ) ) ) );
			  marqueeScheme2.TextColor = System.Drawing.Color.White;
			  marqueeScheme2.TextFont = new System.Drawing.Font( "Copperplate Gothic Light" , 12F );
			  this.quitButton.Scheme = marqueeScheme2;
			  this.quitButton.Size = new System.Drawing.Size( 150 , 42 );
			  this.quitButton.TabIndex = 12;
			  this.quitButton.Click += new System.EventHandler( this.quitButton_Click );
			  // 
			  // marqueeControl
			  // 
			  this.marqueeControl.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							  | System.Windows.Forms.AnchorStyles.Left )
							  | System.Windows.Forms.AnchorStyles.Right ) ) );
			  this.marqueeControl.Location = new System.Drawing.Point( 150 , 0 );
			  this.marqueeControl.MarqueeText = "";
			  this.marqueeControl.Name = "marqueeControl";
			  this.marqueeControl.Renderer = marqueeRenderer3;
			  marqueeScheme3.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 136 ) ) ) ) , ( (int)( ( (byte)( 180 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
			  marqueeScheme3.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 71 ) ) ) ) , ( (int)( ( (byte)( 139 ) ) ) ) , ( (int)( ( (byte)( 158 ) ) ) ) );
			  marqueeScheme3.BackgroundColor3 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 19 ) ) ) ) , ( (int)( ( (byte)( 97 ) ) ) ) , ( (int)( ( (byte)( 119 ) ) ) ) );
			  marqueeScheme3.BackgroundColor4 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 83 ) ) ) ) , ( (int)( ( (byte)( 159 ) ) ) ) , ( (int)( ( (byte)( 171 ) ) ) ) );
			  marqueeScheme3.TextColor = System.Drawing.Color.White;
			  marqueeScheme3.TextFont = new System.Drawing.Font( "Copperplate Gothic Light" , 20.25F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			  this.marqueeControl.Scheme = marqueeScheme3;
			  this.marqueeControl.Size = new System.Drawing.Size( 724 , 42 );
			  this.marqueeControl.TabIndex = 8;
			  // 
			  // statusControl
			  // 
			  this.statusControl.Dock = System.Windows.Forms.DockStyle.Bottom;
			  this.statusControl.LeftCaption = "Simple Workfloor Management Suite v1.0";
			  this.statusControl.Location = new System.Drawing.Point( 0 , 748 );
			  this.statusControl.MiddleCaption = "Geen gebruiker ingelogd";
			  this.statusControl.Name = "statusControl";
			  this.statusControl.Renderer = statusRenderer1;
			  this.statusControl.RightCaption = "woensdag 3 december 2008";
			  statusScheme1.BackgroundColor1 = System.Drawing.Color.Black;
			  statusScheme1.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 89 ) ) ) ) , ( (int)( ( (byte)( 106 ) ) ) ) , ( (int)( ( (byte)( 146 ) ) ) ) );
			  statusScheme1.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			  statusScheme1.CaptionFont = new System.Drawing.Font( "Copperplate Gothic Light" , 10F );
			  this.statusControl.Scheme = statusScheme1;
			  this.statusControl.Size = new System.Drawing.Size( 1024 , 20 );
			  this.statusControl.TabIndex = 8;
			  this.statusControl.MouseClick += new System.Windows.Forms.MouseEventHandler( this.statusControl_MouseClick );
			  // 
			  // employeeGroupTabControl
			  // 
			  this.employeeGroupTabControl.BackColor = System.Drawing.Color.White;
			  this.employeeGroupTabControl.Dock = System.Windows.Forms.DockStyle.Top;
			  this.employeeGroupTabControl.Location = new System.Drawing.Point( 0 , 134 );
			  this.employeeGroupTabControl.Name = "employeeGroupTabControl";
			  this.employeeGroupTabControl.Renderer = employeeGroupTabRenderer1;
			  employeeGroupTabScheme1.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 136 ) ) ) ) , ( (int)( ( (byte)( 180 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
			  employeeGroupTabScheme1.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 71 ) ) ) ) , ( (int)( ( (byte)( 139 ) ) ) ) , ( (int)( ( (byte)( 158 ) ) ) ) );
			  employeeGroupTabScheme1.BackgroundColor3 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 19 ) ) ) ) , ( (int)( ( (byte)( 97 ) ) ) ) , ( (int)( ( (byte)( 119 ) ) ) ) );
			  employeeGroupTabScheme1.BackgroundColor4 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 83 ) ) ) ) , ( (int)( ( (byte)( 159 ) ) ) ) , ( (int)( ( (byte)( 171 ) ) ) ) );
			  employeeGroupTabScheme1.ItemCaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			  employeeGroupTabScheme1.ItemCaptionFont = new System.Drawing.Font( "Verdana" , 13F );
			  employeeGroupTabScheme1.ItemGlowColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 100 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			  employeeGroupTabScheme1.ItemGlowColorSelected = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 100 ) ) ) ) , ( (int)( ( (byte)( 100 ) ) ) ) , ( (int)( ( (byte)( 100 ) ) ) ) , ( (int)( ( (byte)( 100 ) ) ) ) );
			  employeeGroupTabScheme1.ItemInnerBorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 217 ) ) ) ) , ( (int)( ( (byte)( 229 ) ) ) ) , ( (int)( ( (byte)( 236 ) ) ) ) );
			  employeeGroupTabScheme1.ItemInnerBorderColorSelected = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 87 ) ) ) ) , ( (int)( ( (byte)( 112 ) ) ) ) , ( (int)( ( (byte)( 125 ) ) ) ) );
			  employeeGroupTabScheme1.ItemOuterBorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 84 ) ) ) ) , ( (int)( ( (byte)( 115 ) ) ) ) , ( (int)( ( (byte)( 131 ) ) ) ) );
			  employeeGroupTabScheme1.ItemOuterBorderColorSelected = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 42 ) ) ) ) , ( (int)( ( (byte)( 58 ) ) ) ) , ( (int)( ( (byte)( 65 ) ) ) ) );
			  this.employeeGroupTabControl.Scheme = employeeGroupTabScheme1;
			  this.employeeGroupTabControl.Size = new System.Drawing.Size( 1024 , 50 );
			  this.employeeGroupTabControl.TabIndex = 5;
			  this.employeeGroupTabControl.SelectionChanged += new System.EventHandler<SwmSuite.Presentation.Common.EmployeeGroupTab.EmployeeGroupTabSelectionEventArgs>( this.employeeGroupTabControl_SelectionChanged );
			  // 
			  // moduleWindowHeaderControl1
			  // 
			  this.moduleWindowHeaderControl1.Controls.Add( this.pictureBox1 );
			  this.moduleWindowHeaderControl1.Controls.Add( this.mirrorTextControl1 );
			  this.moduleWindowHeaderControl1.Controls.Add( this.analogClockControl1 );
			  this.moduleWindowHeaderControl1.Dock = System.Windows.Forms.DockStyle.Top;
			  this.moduleWindowHeaderControl1.Location = new System.Drawing.Point( 0 , 0 );
			  this.moduleWindowHeaderControl1.Name = "moduleWindowHeaderControl1";
			  moduleWindowHeaderScheme1.BackgroundFlood1Color = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 89 ) ) ) ) , ( (int)( ( (byte)( 106 ) ) ) ) , ( (int)( ( (byte)( 146 ) ) ) ) );
			  moduleWindowHeaderScheme1.BackgroundFlood2Color = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 52 ) ) ) ) , ( (int)( ( (byte)( 56 ) ) ) ) , ( (int)( ( (byte)( 66 ) ) ) ) );
			  moduleWindowHeaderScheme1.BackgroundFlood3Color = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			  moduleWindowHeaderScheme1.BackgroundFlood4Color = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 56 ) ) ) ) , ( (int)( ( (byte)( 69 ) ) ) ) , ( (int)( ( (byte)( 102 ) ) ) ) );
			  moduleWindowHeaderRenderer1.Scheme = moduleWindowHeaderScheme1;
			  this.moduleWindowHeaderControl1.Renderer = moduleWindowHeaderRenderer1;
			  this.moduleWindowHeaderControl1.Size = new System.Drawing.Size( 1024 , 134 );
			  this.moduleWindowHeaderControl1.TabIndex = 1;
			  // 
			  // pictureBox1
			  // 
			  this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			  this.pictureBox1.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.icon;
			  this.pictureBox1.Location = new System.Drawing.Point( 13 , 3 );
			  this.pictureBox1.Name = "pictureBox1";
			  this.pictureBox1.Size = new System.Drawing.Size( 139 , 128 );
			  this.pictureBox1.TabIndex = 9;
			  this.pictureBox1.TabStop = false;
			  // 
			  // mirrorTextControl1
			  // 
			  this.mirrorTextControl1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
							  | System.Windows.Forms.AnchorStyles.Right ) ) );
			  this.mirrorTextControl1.BackColor = System.Drawing.Color.Transparent;
			  this.mirrorTextControl1.Caption = "Simple Workfloor Management Suite";
			  this.mirrorTextControl1.Location = new System.Drawing.Point( 148 , 25 );
			  this.mirrorTextControl1.Name = "mirrorTextControl1";
			  this.mirrorTextControl1.Renderer = mirrorTextRenderer1;
			  mirrorTextScheme1.Correction = 10;
			  mirrorTextScheme1.TextColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			  mirrorTextScheme1.TextFont = new System.Drawing.Font( "Copperplate Gothic Light" , 25F );
			  this.mirrorTextControl1.Scheme = mirrorTextScheme1;
			  this.mirrorTextControl1.Size = new System.Drawing.Size( 735 , 80 );
			  this.mirrorTextControl1.TabIndex = 9;
			  // 
			  // analogClockControl1
			  // 
			  this.analogClockControl1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							  | System.Windows.Forms.AnchorStyles.Right ) ) );
			  this.analogClockControl1.BackColor = System.Drawing.Color.Transparent;
			  this.analogClockControl1.Location = new System.Drawing.Point( 889 , 12 );
			  this.analogClockControl1.Name = "analogClockControl1";
			  this.analogClockControl1.Renderer = analogClockRenderer1;
			  analogClockScheme1.BackgroundColor = System.Drawing.Color.Transparent;
			  analogClockScheme1.BorderColor = System.Drawing.Color.Transparent;
			  analogClockScheme1.BorderWidth = 2F;
			  analogClockScheme1.CountDownFillColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 100 ) ) ) ) , ( (int)( ( (byte)( 100 ) ) ) ) );
			  analogClockScheme1.HourHandColor = System.Drawing.Color.White;
			  analogClockScheme1.HourHandWidth = 3F;
			  analogClockScheme1.HourIndicatorColor = System.Drawing.Color.White;
			  analogClockScheme1.HourIndicatorWidth = 1F;
			  analogClockScheme1.MinuteHandColor = System.Drawing.Color.White;
			  analogClockScheme1.MinuteHandWidth = 2F;
			  analogClockScheme1.SecondHandColor = System.Drawing.Color.Red;
			  analogClockScheme1.SecondHandWidth = 1F;
			  analogClockScheme1.TimeColor = System.Drawing.Color.White;
			  analogClockScheme1.TimeFont = new System.Drawing.Font( "Verdana" , 10F );
			  this.analogClockControl1.Scheme = analogClockScheme1;
			  this.analogClockControl1.Size = new System.Drawing.Size( 123 , 109 );
			  this.analogClockControl1.TabIndex = 0;
			  // 
			  // employeeGroupBackgroundWorker
			  // 
			  this.employeeGroupBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler( this.employeeGroupBackgroundWorker_DoWork );
			  this.employeeGroupBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler( this.employeeGroupBackgroundWorker_RunWorkerCompleted );
			  // 
			  // alertBackgroundWorker
			  // 
			  this.alertBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler( this.alertBackgroundWorker_DoWork );
			  this.alertBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler( this.alertBackgroundWorker_RunWorkerCompleted );
			  // 
			  // loginGroup
			  // 
			  this.loginGroup.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							  | System.Windows.Forms.AnchorStyles.Left )
							  | System.Windows.Forms.AnchorStyles.Right ) ) );
			  this.loginGroup.BackColor = System.Drawing.Color.Transparent;
			  this.loginGroup.ButtonGap = 30;
			  this.loginGroup.ButtonHeight = 75;
			  this.loginGroup.Location = new System.Drawing.Point( 71 , 233 );
			  this.loginGroup.Name = "loginGroup";
			  this.loginGroup.Size = new System.Drawing.Size( 881 , 448 );
			  this.loginGroup.TabIndex = 9;
			  this.loginGroup.Login += new System.EventHandler<SimpleWorkfloorManagementSuite.Controls.LoginGroupLoginEventArgs>( this.loginGroup_Login );
			  // 
			  // loginBackgroundWorker
			  // 
			  this.loginBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler( this.loginBackgroundWorker_DoWork );
			  this.loginBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler( this.loginBackgroundWorker_RunWorkerCompleted );
			  // 
			  // LogOnForm
			  // 
			  this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			  this.BackColor = System.Drawing.Color.White;
			  this.ClientSize = new System.Drawing.Size( 1024 , 768 );
			  this.Controls.Add( this.panel1 );
			  this.Controls.Add( this.loginGroup );
			  this.Controls.Add( this.statusControl );
			  this.Controls.Add( this.employeeGroupTabControl );
			  this.Controls.Add( this.moduleWindowHeaderControl1 );
			  this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			  this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			  this.Name = "LogOnForm";
			  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			  this.Text = "SwmSuite";
			  this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			  this.Load += new System.EventHandler( this.LogOnForm_Load );
			  this.Paint += new System.Windows.Forms.PaintEventHandler( this.LogOnForm_Paint );
			  this.contextMenuStrip.ResumeLayout( false );
			  this.panel1.ResumeLayout( false );
			  this.moduleWindowHeaderControl1.ResumeLayout( false );
			  ( (System.ComponentModel.ISupportInitialize)( this.pictureBox1 ) ).EndInit();
			  this.ResumeLayout( false );

        }

        #endregion

		private SwmSuite.Presentation.Common.ModuleWindowHeader.ModuleWindowHeaderControl moduleWindowHeaderControl1;
		private SwmSuite.Presentation.Common.AnalogClock.AnalogClockControl analogClockControl1;
		private SwmSuite.Presentation.Common.EmployeeGroupTab.EmployeeGroupTabControl employeeGroupTabControl;
		private SwmSuite.Presentation.Common.Status.StatusControl statusControl;
		private SwmSuite.Presentation.Common.MirrorText.MirrorTextControl mirrorTextControl1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private SimpleWorkfloorManagementSuite.Controls.LoginGroup loginGroup;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.Panel panel1;
		private SwmSuite.Presentation.Common.Marquee.MarqueeControl marqueeControl;
		private SwmSuite.Presentation.Common.Marquee.MarqueeButtonControl quitButton;
		private SwmSuite.Presentation.Common.Marquee.MarqueeButtonControl infoButton;
		private System.ComponentModel.BackgroundWorker employeeGroupBackgroundWorker;
		private System.ComponentModel.BackgroundWorker alertBackgroundWorker;
		private System.ComponentModel.BackgroundWorker loginBackgroundWorker;








	}
}

