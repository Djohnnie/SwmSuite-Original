namespace SimpleWorkfloorManagementSuite.Modules {
	partial class HomeModule {
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
			SimpleWorkfloorManagementSuite.Modules.Notification.NotificationScheme notificationScheme1 = new SimpleWorkfloorManagementSuite.Modules.Notification.NotificationScheme();
			SimpleWorkfloorManagementSuite.Modules.Notification.NotificationScheme notificationScheme2 = new SimpleWorkfloorManagementSuite.Modules.Notification.NotificationScheme();
			SimpleWorkfloorManagementSuite.Modules.Notification.NotificationScheme notificationScheme3 = new SimpleWorkfloorManagementSuite.Modules.Notification.NotificationScheme();
			SimpleWorkfloorManagementSuite.Modules.Notification.NotificationScheme notificationScheme4 = new SimpleWorkfloorManagementSuite.Modules.Notification.NotificationScheme();
			SimpleWorkfloorManagementSuite.Modules.Notification.NotificationScheme notificationScheme5 = new SimpleWorkfloorManagementSuite.Modules.Notification.NotificationScheme();
			this.agendaNotification = new SimpleWorkfloorManagementSuite.Modules.Notification.AgendaNotification();
			this.timeTableNotification = new SimpleWorkfloorManagementSuite.Modules.Notification.TimeTableNotification();
			this.holidayNotification = new SimpleWorkfloorManagementSuite.Modules.Notification.HolidayNotification();
			this.taskNotification = new SimpleWorkfloorManagementSuite.Modules.Notification.TaskNotification();
			this.messageNotification = new SimpleWorkfloorManagementSuite.Modules.Notification.MessageNotification();
			this.SuspendLayout();
			// 
			// agendaNotification
			// 
			this.agendaNotification.AgendaData = null;
			this.agendaNotification.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.agendaNotification.LoadingText = "Afspraken worden opgehaald...";
			this.agendaNotification.Location = new System.Drawing.Point( 22 , 127 );
			this.agendaNotification.Name = "agendaNotification";
			notificationScheme1.BackgroundColor1Hovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 234 ) ) ) ) , ( (int)( ( (byte)( 194 ) ) ) ) );
			notificationScheme1.BackgroundColor1Normal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			notificationScheme1.BackgroundColor2Hovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 211 ) ) ) ) , ( (int)( ( (byte)( 125 ) ) ) ) );
			notificationScheme1.BackgroundColor2Normal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 246 ) ) ) ) );
			notificationScheme1.BackgroundColor3Hovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) , ( (int)( ( (byte)( 71 ) ) ) ) );
			notificationScheme1.BackgroundColor3Normal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 246 ) ) ) ) );
			notificationScheme1.BackgroundColor4Hovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 185 ) ) ) ) );
			notificationScheme1.BackgroundColor4Normal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			notificationScheme1.BorderColorHovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 150 ) ) ) ) , ( (int)( ( (byte)( 150 ) ) ) ) , ( (int)( ( (byte)( 150 ) ) ) ) );
			notificationScheme1.BorderColorNormal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 189 ) ) ) ) , ( (int)( ( (byte)( 189 ) ) ) ) , ( (int)( ( (byte)( 189 ) ) ) ) );
			notificationScheme1.MainText2Font = new System.Drawing.Font( "Verdana" , 10F );
			notificationScheme1.MainTextColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			notificationScheme1.MainTextFont = new System.Drawing.Font( "Verdana" , 11F );
			notificationScheme1.TitleColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 128 ) ) ) ) );
			notificationScheme1.TitleFont = new System.Drawing.Font( "Verdana" , 14F , System.Drawing.FontStyle.Bold );
			this.agendaNotification.Scheme = notificationScheme1;
			this.agendaNotification.Size = new System.Drawing.Size( 619 , 100 );
			this.agendaNotification.TabIndex = 10;
			this.agendaNotification.Click += new System.EventHandler( this.agendaNotification_Click );
			// 
			// timeTableNotification
			// 
			this.timeTableNotification.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.timeTableNotification.LoadingText = "Uurrooster wordt opgehaald...";
			this.timeTableNotification.Location = new System.Drawing.Point( 22 , 233 );
			this.timeTableNotification.Name = "timeTableNotification";
			notificationScheme2.BackgroundColor1Hovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 234 ) ) ) ) , ( (int)( ( (byte)( 194 ) ) ) ) );
			notificationScheme2.BackgroundColor1Normal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			notificationScheme2.BackgroundColor2Hovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 211 ) ) ) ) , ( (int)( ( (byte)( 125 ) ) ) ) );
			notificationScheme2.BackgroundColor2Normal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 246 ) ) ) ) );
			notificationScheme2.BackgroundColor3Hovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) , ( (int)( ( (byte)( 71 ) ) ) ) );
			notificationScheme2.BackgroundColor3Normal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 246 ) ) ) ) );
			notificationScheme2.BackgroundColor4Hovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 185 ) ) ) ) );
			notificationScheme2.BackgroundColor4Normal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			notificationScheme2.BorderColorHovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 150 ) ) ) ) , ( (int)( ( (byte)( 150 ) ) ) ) , ( (int)( ( (byte)( 150 ) ) ) ) );
			notificationScheme2.BorderColorNormal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 189 ) ) ) ) , ( (int)( ( (byte)( 189 ) ) ) ) , ( (int)( ( (byte)( 189 ) ) ) ) );
			notificationScheme2.MainText2Font = new System.Drawing.Font( "Verdana" , 10F );
			notificationScheme2.MainTextColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			notificationScheme2.MainTextFont = new System.Drawing.Font( "Verdana" , 11F );
			notificationScheme2.TitleColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 128 ) ) ) ) );
			notificationScheme2.TitleFont = new System.Drawing.Font( "Verdana" , 14F , System.Drawing.FontStyle.Bold );
			this.timeTableNotification.Scheme = notificationScheme2;
			this.timeTableNotification.Size = new System.Drawing.Size( 619 , 100 );
			this.timeTableNotification.TabIndex = 11;
			this.timeTableNotification.TimeTableData = null;
			this.timeTableNotification.Click += new System.EventHandler( this.timeTableNotification_Click );
			// 
			// holidayNotification
			// 
			this.holidayNotification.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.holidayNotification.LoadingText = "Verlofgegevens worden opgehaald...";
			this.holidayNotification.Location = new System.Drawing.Point( 22 , 339 );
			this.holidayNotification.Name = "holidayNotification";
			notificationScheme3.BackgroundColor1Hovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 234 ) ) ) ) , ( (int)( ( (byte)( 194 ) ) ) ) );
			notificationScheme3.BackgroundColor1Normal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			notificationScheme3.BackgroundColor2Hovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 211 ) ) ) ) , ( (int)( ( (byte)( 125 ) ) ) ) );
			notificationScheme3.BackgroundColor2Normal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 246 ) ) ) ) );
			notificationScheme3.BackgroundColor3Hovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) , ( (int)( ( (byte)( 71 ) ) ) ) );
			notificationScheme3.BackgroundColor3Normal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 246 ) ) ) ) );
			notificationScheme3.BackgroundColor4Hovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 185 ) ) ) ) );
			notificationScheme3.BackgroundColor4Normal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			notificationScheme3.BorderColorHovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 150 ) ) ) ) , ( (int)( ( (byte)( 150 ) ) ) ) , ( (int)( ( (byte)( 150 ) ) ) ) );
			notificationScheme3.BorderColorNormal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 189 ) ) ) ) , ( (int)( ( (byte)( 189 ) ) ) ) , ( (int)( ( (byte)( 189 ) ) ) ) );
			notificationScheme3.MainText2Font = new System.Drawing.Font( "Verdana" , 10F );
			notificationScheme3.MainTextColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			notificationScheme3.MainTextFont = new System.Drawing.Font( "Verdana" , 11F );
			notificationScheme3.TitleColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 128 ) ) ) ) );
			notificationScheme3.TitleFont = new System.Drawing.Font( "Verdana" , 14F , System.Drawing.FontStyle.Bold );
			this.holidayNotification.Scheme = notificationScheme3;
			this.holidayNotification.Size = new System.Drawing.Size( 619 , 100 );
			this.holidayNotification.TabIndex = 12;
			this.holidayNotification.Click += new System.EventHandler( this.holidayNotification_Click );
			// 
			// taskNotification
			// 
			this.taskNotification.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.taskNotification.LoadingText = "Taken worden opgehaald...";
			this.taskNotification.Location = new System.Drawing.Point( 22 , 445 );
			this.taskNotification.Name = "taskNotification";
			notificationScheme4.BackgroundColor1Hovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 234 ) ) ) ) , ( (int)( ( (byte)( 194 ) ) ) ) );
			notificationScheme4.BackgroundColor1Normal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			notificationScheme4.BackgroundColor2Hovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 211 ) ) ) ) , ( (int)( ( (byte)( 125 ) ) ) ) );
			notificationScheme4.BackgroundColor2Normal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 246 ) ) ) ) );
			notificationScheme4.BackgroundColor3Hovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) , ( (int)( ( (byte)( 71 ) ) ) ) );
			notificationScheme4.BackgroundColor3Normal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 246 ) ) ) ) );
			notificationScheme4.BackgroundColor4Hovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 185 ) ) ) ) );
			notificationScheme4.BackgroundColor4Normal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			notificationScheme4.BorderColorHovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 150 ) ) ) ) , ( (int)( ( (byte)( 150 ) ) ) ) , ( (int)( ( (byte)( 150 ) ) ) ) );
			notificationScheme4.BorderColorNormal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 189 ) ) ) ) , ( (int)( ( (byte)( 189 ) ) ) ) , ( (int)( ( (byte)( 189 ) ) ) ) );
			notificationScheme4.MainText2Font = new System.Drawing.Font( "Verdana" , 10F );
			notificationScheme4.MainTextColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			notificationScheme4.MainTextFont = new System.Drawing.Font( "Verdana" , 11F );
			notificationScheme4.TitleColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 128 ) ) ) ) );
			notificationScheme4.TitleFont = new System.Drawing.Font( "Verdana" , 14F , System.Drawing.FontStyle.Bold );
			this.taskNotification.Scheme = notificationScheme4;
			this.taskNotification.Size = new System.Drawing.Size( 619 , 100 );
			this.taskNotification.TabIndex = 13;
			this.taskNotification.TaskData = null;
			this.taskNotification.Click += new System.EventHandler( this.taskNotification_Click );
			// 
			// messageNotification
			// 
			this.messageNotification.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.messageNotification.LoadingText = "Berichten worden opgehaald...";
			this.messageNotification.Location = new System.Drawing.Point( 22 , 21 );
			this.messageNotification.MessageData = null;
			this.messageNotification.Name = "messageNotification";
			notificationScheme5.BackgroundColor1Hovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 234 ) ) ) ) , ( (int)( ( (byte)( 194 ) ) ) ) );
			notificationScheme5.BackgroundColor1Normal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			notificationScheme5.BackgroundColor2Hovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 211 ) ) ) ) , ( (int)( ( (byte)( 125 ) ) ) ) );
			notificationScheme5.BackgroundColor2Normal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 246 ) ) ) ) );
			notificationScheme5.BackgroundColor3Hovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) , ( (int)( ( (byte)( 71 ) ) ) ) );
			notificationScheme5.BackgroundColor3Normal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 246 ) ) ) ) );
			notificationScheme5.BackgroundColor4Hovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 185 ) ) ) ) );
			notificationScheme5.BackgroundColor4Normal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			notificationScheme5.BorderColorHovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 150 ) ) ) ) , ( (int)( ( (byte)( 150 ) ) ) ) , ( (int)( ( (byte)( 150 ) ) ) ) );
			notificationScheme5.BorderColorNormal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 189 ) ) ) ) , ( (int)( ( (byte)( 189 ) ) ) ) , ( (int)( ( (byte)( 189 ) ) ) ) );
			notificationScheme5.MainText2Font = new System.Drawing.Font( "Verdana" , 10F );
			notificationScheme5.MainTextColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			notificationScheme5.MainTextFont = new System.Drawing.Font( "Verdana" , 11F );
			notificationScheme5.TitleColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 128 ) ) ) ) );
			notificationScheme5.TitleFont = new System.Drawing.Font( "Verdana" , 14F , System.Drawing.FontStyle.Bold );
			this.messageNotification.Scheme = notificationScheme5;
			this.messageNotification.Size = new System.Drawing.Size( 619 , 100 );
			this.messageNotification.TabIndex = 9;
			this.messageNotification.Click += new System.EventHandler( this.messageNotification_Click );
			// 
			// HomeModule
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add( this.taskNotification );
			this.Controls.Add( this.holidayNotification );
			this.Controls.Add( this.timeTableNotification );
			this.Controls.Add( this.agendaNotification );
			this.Controls.Add( this.messageNotification );
			this.Name = "HomeModule";
			this.Size = new System.Drawing.Size( 670 , 639 );
			this.Load += new System.EventHandler( this.HomeModule_Load );
			this.Resize += new System.EventHandler( this.HomeModule_Resize );
			this.ResumeLayout( false );

		}

		#endregion

		private SimpleWorkfloorManagementSuite.Modules.Notification.AgendaNotification agendaNotification;
		private SimpleWorkfloorManagementSuite.Modules.Notification.TimeTableNotification timeTableNotification;
		private SimpleWorkfloorManagementSuite.Modules.Notification.HolidayNotification holidayNotification;
		private SimpleWorkfloorManagementSuite.Modules.Notification.TaskNotification taskNotification;
		private SimpleWorkfloorManagementSuite.Modules.Notification.MessageNotification messageNotification;
	}
}
