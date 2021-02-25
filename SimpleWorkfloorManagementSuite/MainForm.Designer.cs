namespace SimpleWorkfloorManagementSuite {
	partial class MainForm {
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( MainForm ) );
			SwmSuite.Presentation.Common.Marquee.MarqueeRenderer marqueeRenderer1 = new SwmSuite.Presentation.Common.Marquee.MarqueeRenderer();
			SwmSuite.Presentation.Common.Marquee.MarqueeScheme marqueeScheme1 = new SwmSuite.Presentation.Common.Marquee.MarqueeScheme();
			SwmSuite.Presentation.Common.Marquee.MarqueeRenderer marqueeRenderer2 = new SwmSuite.Presentation.Common.Marquee.MarqueeRenderer();
			SwmSuite.Presentation.Common.Marquee.MarqueeScheme marqueeScheme2 = new SwmSuite.Presentation.Common.Marquee.MarqueeScheme();
			SwmSuite.Presentation.Common.Marquee.MarqueeRenderer marqueeRenderer3 = new SwmSuite.Presentation.Common.Marquee.MarqueeRenderer();
			SwmSuite.Presentation.Common.Marquee.MarqueeScheme marqueeScheme3 = new SwmSuite.Presentation.Common.Marquee.MarqueeScheme();
			SwmSuite.Presentation.Common.ModuleWindowMenu.ModuleWindowMenuRenderer moduleWindowMenuRenderer1 = new SwmSuite.Presentation.Common.ModuleWindowMenu.ModuleWindowMenuRenderer();
			SwmSuite.Presentation.Common.ModuleWindowMenu.ModuleWindowMenuScheme moduleWindowMenuScheme1 = new SwmSuite.Presentation.Common.ModuleWindowMenu.ModuleWindowMenuScheme();
			SwmSuite.Presentation.Common.ModuleWindowHeader.ModuleWindowHeaderRenderer moduleWindowHeaderRenderer1 = new SwmSuite.Presentation.Common.ModuleWindowHeader.ModuleWindowHeaderRenderer();
			SwmSuite.Presentation.Common.ModuleWindowHeader.ModuleWindowHeaderScheme moduleWindowHeaderScheme1 = new SwmSuite.Presentation.Common.ModuleWindowHeader.ModuleWindowHeaderScheme();
			SwmSuite.Presentation.Common.AnalogClock.AnalogClockRenderer analogClockRenderer1 = new SwmSuite.Presentation.Common.AnalogClock.AnalogClockRenderer();
			SwmSuite.Presentation.Common.AnalogClock.AnalogClockScheme analogClockScheme1 = new SwmSuite.Presentation.Common.AnalogClock.AnalogClockScheme();
			SwmSuite.Presentation.Common.MirrorText.MirrorTextRenderer mirrorTextRenderer1 = new SwmSuite.Presentation.Common.MirrorText.MirrorTextRenderer();
			SwmSuite.Presentation.Common.MirrorText.MirrorTextScheme mirrorTextScheme1 = new SwmSuite.Presentation.Common.MirrorText.MirrorTextScheme();
			SwmSuite.Presentation.Common.Status.StatusRenderer statusRenderer1 = new SwmSuite.Presentation.Common.Status.StatusRenderer();
			SwmSuite.Presentation.Common.Status.StatusScheme statusScheme1 = new SwmSuite.Presentation.Common.Status.StatusScheme();
			this.headerImageList = new System.Windows.Forms.ImageList( this.components );
			this.panel1 = new System.Windows.Forms.Panel();
			this.settingsButton = new SwmSuite.Presentation.Common.Marquee.MarqueeButtonControl();
			this.quitButton = new SwmSuite.Presentation.Common.Marquee.MarqueeButtonControl();
			this.marqueeControl = new SwmSuite.Presentation.Common.Marquee.MarqueeControl();
			this.moduleWindowMenu = new SwmSuite.Presentation.Common.ModuleWindowMenu.ModuleWindowMenuControl();
			this.moduleWindowHeaderControl = new SwmSuite.Presentation.Common.ModuleWindowHeader.ModuleWindowHeaderControl();
			this.analogClockControl = new SwmSuite.Presentation.Common.AnalogClock.AnalogClockControl();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.headerText = new SwmSuite.Presentation.Common.MirrorText.MirrorTextControl();
			this.statusControl = new SwmSuite.Presentation.Common.Status.StatusControl();
			this.applicationIdle = new SwmSuite.Presentation.Common.ApplicationIdle.ApplicationIdle();
			this.personalManagementModule = new SimpleWorkfloorManagementSuite.Modules.PersonalManagementModule();
			this.homeModule = new SimpleWorkfloorManagementSuite.Modules.HomeModule();
			this.holidayManagementModule = new SimpleWorkfloorManagementSuite.Modules.HolidayManagementModule();
			this.alertManagementModule = new SimpleWorkfloorManagementSuite.Modules.AlertManagementModule();
			this.taskManagementModule = new SimpleWorkfloorManagementSuite.Modules.TaskManagementModule();
			this.timeTableManagementModule = new SimpleWorkfloorManagementSuite.Modules.TimeTableManagementModule();
			this.staffManagementModule = new SimpleWorkfloorManagementSuite.Modules.StaffManagementModule();
			this.taskModule = new SimpleWorkfloorManagementSuite.Modules.TaskModule();
			this.holidayModule = new SimpleWorkfloorManagementSuite.Modules.HolidayModule();
			this.timeTableModule = new SimpleWorkfloorManagementSuite.Modules.TimeTableModule();
			this.agendaModule = new SimpleWorkfloorManagementSuite.Modules.AgendaModule();
			this.messageModule = new SimpleWorkfloorManagementSuite.Modules.MessageModule();
			this.loggingModule = new SimpleWorkfloorManagementSuite.Modules.LoggingModule();
			this.alertBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.panel1.SuspendLayout();
			this.moduleWindowHeaderControl.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.pictureBox ) ).BeginInit();
			this.SuspendLayout();
			// 
			// headerImageList
			// 
			this.headerImageList.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "headerImageList.ImageStream" ) ) );
			this.headerImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.headerImageList.Images.SetKeyName( 0 , "home.png" );
			this.headerImageList.Images.SetKeyName( 1 , "berichten.png" );
			this.headerImageList.Images.SetKeyName( 2 , "agenda.png" );
			this.headerImageList.Images.SetKeyName( 3 , "timetable.png" );
			this.headerImageList.Images.SetKeyName( 4 , "holiday.png" );
			this.headerImageList.Images.SetKeyName( 5 , "task.png" );
			this.headerImageList.Images.SetKeyName( 6 , "personal_management.png" );
			this.headerImageList.Images.SetKeyName( 7 , "staff_managment.png" );
			this.headerImageList.Images.SetKeyName( 8 , "timetable_management.png" );
			this.headerImageList.Images.SetKeyName( 9 , "holiday_management.png" );
			this.headerImageList.Images.SetKeyName( 10 , "task_management.png" );
			this.headerImageList.Images.SetKeyName( 11 , "alert.png" );
			this.headerImageList.Images.SetKeyName( 12 , "logboek.png" );
			// 
			// panel1
			// 
			this.panel1.Controls.Add( this.settingsButton );
			this.panel1.Controls.Add( this.quitButton );
			this.panel1.Controls.Add( this.marqueeControl );
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point( 0 , 706 );
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size( 1024 , 42 );
			this.panel1.TabIndex = 23;
			// 
			// settingsButton
			// 
			this.settingsButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.settingsButton.Caption = "Instellingen";
			this.settingsButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.settingsButton.Location = new System.Drawing.Point( 874 , 0 );
			this.settingsButton.Name = "settingsButton";
			this.settingsButton.Renderer = marqueeRenderer1;
			marqueeScheme1.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 136 ) ) ) ) , ( (int)( ( (byte)( 180 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
			marqueeScheme1.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 71 ) ) ) ) , ( (int)( ( (byte)( 139 ) ) ) ) , ( (int)( ( (byte)( 158 ) ) ) ) );
			marqueeScheme1.BackgroundColor3 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 19 ) ) ) ) , ( (int)( ( (byte)( 97 ) ) ) ) , ( (int)( ( (byte)( 119 ) ) ) ) );
			marqueeScheme1.BackgroundColor4 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 83 ) ) ) ) , ( (int)( ( (byte)( 159 ) ) ) ) , ( (int)( ( (byte)( 171 ) ) ) ) );
			marqueeScheme1.TextColor = System.Drawing.Color.White;
			marqueeScheme1.TextFont = new System.Drawing.Font( "Copperplate Gothic Light" , 12F );
			this.settingsButton.Scheme = marqueeScheme1;
			this.settingsButton.Size = new System.Drawing.Size( 150 , 42 );
			this.settingsButton.TabIndex = 13;
			this.settingsButton.Click += new System.EventHandler( this.settingsButton_Click );
			// 
			// quitButton
			// 
			this.quitButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Left ) ) );
			this.quitButton.Caption = "Afmelden";
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
			this.marqueeControl.Location = new System.Drawing.Point( 139 , 0 );
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
			this.marqueeControl.Size = new System.Drawing.Size( 735 , 42 );
			this.marqueeControl.TabIndex = 8;
			// 
			// moduleWindowMenu
			// 
			this.moduleWindowMenu.Dock = System.Windows.Forms.DockStyle.Left;
			this.moduleWindowMenu.Location = new System.Drawing.Point( 0 , 100 );
			this.moduleWindowMenu.Name = "moduleWindowMenu";
			this.moduleWindowMenu.Renderer = moduleWindowMenuRenderer1;
			moduleWindowMenuScheme1.BackgroundColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			moduleWindowMenuScheme1.BackgroundFlood1Color = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 65 ) ) ) ) , ( (int)( ( (byte)( 110 ) ) ) ) , ( (int)( ( (byte)( 165 ) ) ) ) );
			moduleWindowMenuScheme1.BackgroundFlood2Color = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 110 ) ) ) ) , ( (int)( ( (byte)( 185 ) ) ) ) , ( (int)( ( (byte)( 110 ) ) ) ) );
			moduleWindowMenuScheme1.ItemCaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			moduleWindowMenuScheme1.ItemCaptionFont = new System.Drawing.Font( "Copperplate Gothic Light" , 12.25F );
			moduleWindowMenuScheme1.ItemGlowColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 100 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			moduleWindowMenuScheme1.ItemGlowColorSelected = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 100 ) ) ) ) , ( (int)( ( (byte)( 100 ) ) ) ) , ( (int)( ( (byte)( 100 ) ) ) ) , ( (int)( ( (byte)( 100 ) ) ) ) );
			moduleWindowMenuScheme1.ItemInnerBorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 217 ) ) ) ) , ( (int)( ( (byte)( 229 ) ) ) ) , ( (int)( ( (byte)( 236 ) ) ) ) );
			moduleWindowMenuScheme1.ItemInnerBorderColorSelected = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 87 ) ) ) ) , ( (int)( ( (byte)( 112 ) ) ) ) , ( (int)( ( (byte)( 125 ) ) ) ) );
			moduleWindowMenuScheme1.ItemOuterBorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 84 ) ) ) ) , ( (int)( ( (byte)( 115 ) ) ) ) , ( (int)( ( (byte)( 131 ) ) ) ) );
			moduleWindowMenuScheme1.ItemOuterBorderColorSelected = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 42 ) ) ) ) , ( (int)( ( (byte)( 58 ) ) ) ) , ( (int)( ( (byte)( 65 ) ) ) ) );
			moduleWindowMenuScheme1.MenuItemHeight = 50;
			moduleWindowMenuScheme1.MenuItemRoundedCornerRadius = 20;
			moduleWindowMenuScheme1.MenuTopOffset = 10;
			this.moduleWindowMenu.Scheme = moduleWindowMenuScheme1;
			this.moduleWindowMenu.Size = new System.Drawing.Size( 195 , 606 );
			this.moduleWindowMenu.TabIndex = 10;
			this.moduleWindowMenu.MenuItemClicked += new System.EventHandler<SwmSuite.Presentation.Common.ModuleWindowMenu.ModuleWindowMenuEventArgs>( this.moduleWindowMenu_MenuItemClicked );
			// 
			// moduleWindowHeaderControl
			// 
			this.moduleWindowHeaderControl.Controls.Add( this.analogClockControl );
			this.moduleWindowHeaderControl.Controls.Add( this.pictureBox );
			this.moduleWindowHeaderControl.Controls.Add( this.headerText );
			this.moduleWindowHeaderControl.Dock = System.Windows.Forms.DockStyle.Top;
			this.moduleWindowHeaderControl.Location = new System.Drawing.Point( 0 , 0 );
			this.moduleWindowHeaderControl.Name = "moduleWindowHeaderControl";
			moduleWindowHeaderScheme1.BackgroundFlood1Color = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 89 ) ) ) ) , ( (int)( ( (byte)( 106 ) ) ) ) , ( (int)( ( (byte)( 146 ) ) ) ) );
			moduleWindowHeaderScheme1.BackgroundFlood2Color = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 52 ) ) ) ) , ( (int)( ( (byte)( 56 ) ) ) ) , ( (int)( ( (byte)( 66 ) ) ) ) );
			moduleWindowHeaderScheme1.BackgroundFlood3Color = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			moduleWindowHeaderScheme1.BackgroundFlood4Color = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 56 ) ) ) ) , ( (int)( ( (byte)( 69 ) ) ) ) , ( (int)( ( (byte)( 102 ) ) ) ) );
			moduleWindowHeaderRenderer1.Scheme = moduleWindowHeaderScheme1;
			this.moduleWindowHeaderControl.Renderer = moduleWindowHeaderRenderer1;
			this.moduleWindowHeaderControl.Size = new System.Drawing.Size( 1024 , 100 );
			this.moduleWindowHeaderControl.TabIndex = 2;
			// 
			// analogClockControl
			// 
			this.analogClockControl.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.analogClockControl.BackColor = System.Drawing.Color.Transparent;
			this.analogClockControl.Location = new System.Drawing.Point( 926 , 3 );
			this.analogClockControl.Name = "analogClockControl";
			this.analogClockControl.Renderer = analogClockRenderer1;
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
			this.analogClockControl.Scheme = analogClockScheme1;
			this.analogClockControl.Size = new System.Drawing.Size( 95 , 91 );
			this.analogClockControl.TabIndex = 10;
			// 
			// pictureBox
			// 
			this.pictureBox.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.home;
			this.pictureBox.Location = new System.Drawing.Point( 3 , 3 );
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size( 94 , 94 );
			this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox.TabIndex = 3;
			this.pictureBox.TabStop = false;
			// 
			// headerText
			// 
			this.headerText.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.headerText.BackColor = System.Drawing.Color.Transparent;
			this.headerText.Caption = "#TITEL#";
			this.headerText.Location = new System.Drawing.Point( 212 , 16 );
			this.headerText.Name = "headerText";
			this.headerText.Renderer = mirrorTextRenderer1;
			mirrorTextScheme1.Correction = 10;
			mirrorTextScheme1.TextColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			mirrorTextScheme1.TextFont = new System.Drawing.Font( "Copperplate Gothic Light" , 25F );
			this.headerText.Scheme = mirrorTextScheme1;
			this.headerText.Size = new System.Drawing.Size( 600 , 67 );
			this.headerText.TabIndex = 9;
			this.headerText.DoubleClick += new System.EventHandler( this.headerText_DoubleClick );
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
			this.statusControl.TabIndex = 9;
			// 
			// applicationIdle
			// 
			this.applicationIdle.WarnTime = System.TimeSpan.Parse( "00:01:00" );
			this.applicationIdle.Idle += new System.EventHandler( this.applicationIdle_Idle );
			this.applicationIdle.Warn += new System.EventHandler( this.applicationIdle_Warn );
			this.applicationIdle.Tick += new System.EventHandler<SwmSuite.Presentation.Common.ApplicationIdle.TickEventArgs>( this.applicationIdle_Tick );
			this.applicationIdle.Activity += new System.EventHandler<SwmSuite.Presentation.Common.ApplicationIdle.ActivityEventArgs>( this.applicationIdle_Activity );
			// 
			// personalManagementModule
			// 
			this.personalManagementModule.BackColor = System.Drawing.Color.White;
			this.personalManagementModule.Dock = System.Windows.Forms.DockStyle.Fill;
			this.personalManagementModule.Location = new System.Drawing.Point( 195 , 100 );
			this.personalManagementModule.Name = "personalManagementModule";
			this.personalManagementModule.Size = new System.Drawing.Size( 829 , 606 );
			this.personalManagementModule.TabIndex = 17;
			// 
			// homeModule
			// 
			this.homeModule.BackColor = System.Drawing.Color.White;
			this.homeModule.Dock = System.Windows.Forms.DockStyle.Fill;
			this.homeModule.Location = new System.Drawing.Point( 195 , 100 );
			this.homeModule.Name = "homeModule";
			this.homeModule.Size = new System.Drawing.Size( 829 , 606 );
			this.homeModule.TabIndex = 11;
			this.homeModule.TaskNotificationClicked += new System.EventHandler<System.EventArgs>( this.homeModule_TaskNotificationClicked );
			this.homeModule.AgendaNotificationClicked += new System.EventHandler<System.EventArgs>( this.homeModule_AgendaNotificationClicked );
			this.homeModule.HolidayNotificationClicked += new System.EventHandler<System.EventArgs>( this.homeModule_HolidayNotificationClicked );
			this.homeModule.MessageNotificationClicked += new System.EventHandler<System.EventArgs>( this.homeModule_MessageNotificationClicked );
			this.homeModule.TimeTableNotificationClicked += new System.EventHandler<System.EventArgs>( this.homeModule_TimeTableNotificationClicked );
			// 
			// holidayManagementModule
			// 
			this.holidayManagementModule.BackColor = System.Drawing.Color.White;
			this.holidayManagementModule.Dock = System.Windows.Forms.DockStyle.Fill;
			this.holidayManagementModule.Location = new System.Drawing.Point( 195 , 100 );
			this.holidayManagementModule.Name = "holidayManagementModule";
			this.holidayManagementModule.Size = new System.Drawing.Size( 829 , 606 );
			this.holidayManagementModule.TabIndex = 20;
			this.holidayManagementModule.Year = 2009;
			// 
			// alertManagementModule
			// 
			this.alertManagementModule.BackColor = System.Drawing.Color.White;
			this.alertManagementModule.Dock = System.Windows.Forms.DockStyle.Fill;
			this.alertManagementModule.Location = new System.Drawing.Point( 195 , 100 );
			this.alertManagementModule.Name = "alertManagementModule";
			this.alertManagementModule.Size = new System.Drawing.Size( 829 , 606 );
			this.alertManagementModule.TabIndex = 22;
			this.alertManagementModule.Visible = false;
			// 
			// taskManagementModule
			// 
			this.taskManagementModule.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.taskManagementModule.BackColor = System.Drawing.Color.White;
			this.taskManagementModule.Location = new System.Drawing.Point( 201 , 106 );
			this.taskManagementModule.Name = "taskManagementModule";
			this.taskManagementModule.Size = new System.Drawing.Size( 811 , 600 );
			this.taskManagementModule.TabIndex = 21;
			// 
			// timeTableManagementModule
			// 
			this.timeTableManagementModule.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.timeTableManagementModule.BackColor = System.Drawing.Color.White;
			this.timeTableManagementModule.Location = new System.Drawing.Point( 201 , 106 );
			this.timeTableManagementModule.Name = "timeTableManagementModule";
			this.timeTableManagementModule.Size = new System.Drawing.Size( 811 , 600 );
			this.timeTableManagementModule.TabIndex = 19;
			// 
			// staffManagementModule
			// 
			this.staffManagementModule.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.staffManagementModule.BackColor = System.Drawing.Color.White;
			this.staffManagementModule.Location = new System.Drawing.Point( 201 , 106 );
			this.staffManagementModule.Name = "staffManagementModule";
			this.staffManagementModule.Size = new System.Drawing.Size( 811 , 600 );
			this.staffManagementModule.TabIndex = 18;
			// 
			// taskModule
			// 
			this.taskModule.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.taskModule.BackColor = System.Drawing.Color.White;
			this.taskModule.Location = new System.Drawing.Point( 201 , 106 );
			this.taskModule.Name = "taskModule";
			this.taskModule.Size = new System.Drawing.Size( 811 , 600 );
			this.taskModule.TabIndex = 16;
			// 
			// holidayModule
			// 
			this.holidayModule.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.holidayModule.BackColor = System.Drawing.Color.White;
			this.holidayModule.Location = new System.Drawing.Point( 201 , 106 );
			this.holidayModule.Name = "holidayModule";
			this.holidayModule.Size = new System.Drawing.Size( 811 , 600 );
			this.holidayModule.TabIndex = 15;
			this.holidayModule.Year = 2009;
			// 
			// timeTableModule
			// 
			this.timeTableModule.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.timeTableModule.BackColor = System.Drawing.Color.White;
			this.timeTableModule.Location = new System.Drawing.Point( 201 , 106 );
			this.timeTableModule.Name = "timeTableModule";
			this.timeTableModule.Size = new System.Drawing.Size( 811 , 600 );
			this.timeTableModule.TabIndex = 14;
			// 
			// agendaModule
			// 
			this.agendaModule.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.agendaModule.BackColor = System.Drawing.Color.White;
			this.agendaModule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.agendaModule.Location = new System.Drawing.Point( 201 , 106 );
			this.agendaModule.Name = "agendaModule";
			this.agendaModule.Size = new System.Drawing.Size( 811 , 600 );
			this.agendaModule.TabIndex = 13;
			// 
			// messageModule
			// 
			this.messageModule.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.messageModule.BackColor = System.Drawing.Color.White;
			this.messageModule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.messageModule.Location = new System.Drawing.Point( 201 , 106 );
			this.messageModule.Name = "messageModule";
			this.messageModule.Size = new System.Drawing.Size( 811 , 594 );
			this.messageModule.TabIndex = 12;
			// 
			// loggingModule
			// 
			this.loggingModule.BackColor = System.Drawing.Color.White;
			this.loggingModule.Dock = System.Windows.Forms.DockStyle.Fill;
			this.loggingModule.Location = new System.Drawing.Point( 0 , 0 );
			this.loggingModule.Name = "loggingModule";
			this.loggingModule.Size = new System.Drawing.Size( 1024 , 768 );
			this.loggingModule.TabIndex = 24;
			// 
			// alertBackgroundWorker
			// 
			this.alertBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler( this.alertBackgroundWorker_DoWork );
			this.alertBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler( this.alertBackgroundWorker_RunWorkerCompleted );
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size( 1024 , 768 );
			this.ControlBox = false;
			this.Controls.Add( this.personalManagementModule );
			this.Controls.Add( this.homeModule );
			this.Controls.Add( this.holidayManagementModule );
			this.Controls.Add( this.alertManagementModule );
			this.Controls.Add( this.moduleWindowMenu );
			this.Controls.Add( this.taskManagementModule );
			this.Controls.Add( this.timeTableManagementModule );
			this.Controls.Add( this.staffManagementModule );
			this.Controls.Add( this.taskModule );
			this.Controls.Add( this.holidayModule );
			this.Controls.Add( this.timeTableModule );
			this.Controls.Add( this.agendaModule );
			this.Controls.Add( this.messageModule );
			this.Controls.Add( this.moduleWindowHeaderControl );
			this.Controls.Add( this.panel1 );
			this.Controls.Add( this.statusControl );
			this.Controls.Add( this.loggingModule );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler( this.MainForm_Load );
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.MainForm_FormClosing );
			this.panel1.ResumeLayout( false );
			this.moduleWindowHeaderControl.ResumeLayout( false );
			( (System.ComponentModel.ISupportInitialize)( this.pictureBox ) ).EndInit();
			this.ResumeLayout( false );

		}

		#endregion

		private SwmSuite.Presentation.Common.ModuleWindowHeader.ModuleWindowHeaderControl moduleWindowHeaderControl;
		private SwmSuite.Presentation.Common.MirrorText.MirrorTextControl headerText;
		private System.Windows.Forms.PictureBox pictureBox;
		private SwmSuite.Presentation.Common.Status.StatusControl statusControl;
		private SwmSuite.Presentation.Common.ModuleWindowMenu.ModuleWindowMenuControl moduleWindowMenu;
		private SimpleWorkfloorManagementSuite.Modules.HomeModule homeModule;
		private SimpleWorkfloorManagementSuite.Modules.MessageModule messageModule;
		private SimpleWorkfloorManagementSuite.Modules.AgendaModule agendaModule;
		private SimpleWorkfloorManagementSuite.Modules.TimeTableModule timeTableModule;
		private SimpleWorkfloorManagementSuite.Modules.HolidayModule holidayModule;
		private SimpleWorkfloorManagementSuite.Modules.TaskModule taskModule;
		private SimpleWorkfloorManagementSuite.Modules.PersonalManagementModule personalManagementModule;
		private SimpleWorkfloorManagementSuite.Modules.StaffManagementModule staffManagementModule;
		private SimpleWorkfloorManagementSuite.Modules.TimeTableManagementModule timeTableManagementModule;
		private SimpleWorkfloorManagementSuite.Modules.HolidayManagementModule holidayManagementModule;
		private SimpleWorkfloorManagementSuite.Modules.TaskManagementModule taskManagementModule;
		private System.Windows.Forms.ImageList headerImageList;
		private SimpleWorkfloorManagementSuite.Modules.AlertManagementModule alertManagementModule;
		private SwmSuite.Presentation.Common.AnalogClock.AnalogClockControl analogClockControl;
		private System.Windows.Forms.Panel panel1;
		private SwmSuite.Presentation.Common.Marquee.MarqueeButtonControl settingsButton;
		private SwmSuite.Presentation.Common.Marquee.MarqueeButtonControl quitButton;
		private SwmSuite.Presentation.Common.Marquee.MarqueeControl marqueeControl;
		private SwmSuite.Presentation.Common.ApplicationIdle.ApplicationIdle applicationIdle;
		private SimpleWorkfloorManagementSuite.Modules.LoggingModule loggingModule;
		private System.ComponentModel.BackgroundWorker alertBackgroundWorker;
	}
}