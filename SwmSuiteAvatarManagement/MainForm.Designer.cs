namespace SwmSuiteAvatarManagement {
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
			SwmSuite.Presentation.Common.AvatarBrowser.AvatarBrowserRenderer avatarBrowserRenderer1 = new SwmSuite.Presentation.Common.AvatarBrowser.AvatarBrowserRenderer();
			SwmSuite.Presentation.Common.AvatarBrowser.AvatarBrowserScheme avatarBrowserScheme1 = new SwmSuite.Presentation.Common.AvatarBrowser.AvatarBrowserScheme();
			SwmSuite.Presentation.Common.ButtonRenderer buttonRenderer1 = new SwmSuite.Presentation.Common.ButtonRenderer();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme1 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat1 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme2 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat2 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme3 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat3 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme4 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat4 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonRenderer buttonRenderer2 = new SwmSuite.Presentation.Common.ButtonRenderer();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme5 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat5 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme6 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat6 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme7 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat7 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme8 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat8 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.Status.StatusRenderer statusRenderer1 = new SwmSuite.Presentation.Common.Status.StatusRenderer();
			SwmSuite.Presentation.Common.Status.StatusScheme statusScheme1 = new SwmSuite.Presentation.Common.Status.StatusScheme();
			SwmSuite.Presentation.Common.ModuleWindowHeader.ModuleWindowHeaderRenderer moduleWindowHeaderRenderer1 = new SwmSuite.Presentation.Common.ModuleWindowHeader.ModuleWindowHeaderRenderer();
			SwmSuite.Presentation.Common.ModuleWindowHeader.ModuleWindowHeaderScheme moduleWindowHeaderScheme1 = new SwmSuite.Presentation.Common.ModuleWindowHeader.ModuleWindowHeaderScheme();
			SwmSuite.Presentation.Common.AnalogClock.AnalogClockRenderer analogClockRenderer1 = new SwmSuite.Presentation.Common.AnalogClock.AnalogClockRenderer();
			SwmSuite.Presentation.Common.AnalogClock.AnalogClockScheme analogClockScheme1 = new SwmSuite.Presentation.Common.AnalogClock.AnalogClockScheme();
			SwmSuite.Presentation.Common.MirrorText.MirrorTextRenderer mirrorTextRenderer1 = new SwmSuite.Presentation.Common.MirrorText.MirrorTextRenderer();
			SwmSuite.Presentation.Common.MirrorText.MirrorTextScheme mirrorTextScheme1 = new SwmSuite.Presentation.Common.MirrorText.MirrorTextScheme();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( MainForm ) );
			this.getBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.insertBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.removeBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.circularProgressControl = new SwmSuite.Presentation.Common.UserControls.CircularProgressControl();
			this.avatarBrowserControl1 = new SwmSuite.Presentation.Common.AvatarBrowser.AvatarBrowserControl();
			this.removeButton = new SwmSuite.Presentation.Common.ButtonControl();
			this.addButton = new SwmSuite.Presentation.Common.ButtonControl();
			this.statusControl = new SwmSuite.Presentation.Common.Status.StatusControl();
			this.moduleWindowHeaderControl = new SwmSuite.Presentation.Common.ModuleWindowHeader.ModuleWindowHeaderControl();
			this.analogClockControl1 = new SwmSuite.Presentation.Common.AnalogClock.AnalogClockControl();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.mirrorTextControl = new SwmSuite.Presentation.Common.MirrorText.MirrorTextControl();
			this.moduleWindowHeaderControl.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.pictureBox1 ) ).BeginInit();
			this.SuspendLayout();
			// 
			// getBackgroundWorker
			// 
			this.getBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler( this.getBackgroundWorker_DoWork );
			this.getBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler( this.getBackgroundWorker_RunWorkerCompleted );
			// 
			// insertBackgroundWorker
			// 
			this.insertBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler( this.insertBackgroundWorker_DoWork );
			this.insertBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler( this.insertBackgroundWorker_RunWorkerCompleted );
			// 
			// removeBackgroundWorker
			// 
			this.removeBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler( this.removeBackgroundWorker_DoWork );
			this.removeBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler( this.removeBackgroundWorker_RunWorkerCompleted );
			// 
			// circularProgressControl
			// 
			this.circularProgressControl.ActiveSegmentColour = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 35 ) ) ) ) , ( (int)( ( (byte)( 146 ) ) ) ) , ( (int)( ( (byte)( 33 ) ) ) ) );
			this.circularProgressControl.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.circularProgressControl.InactiveSegmentColour = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 218 ) ) ) ) , ( (int)( ( (byte)( 218 ) ) ) ) , ( (int)( ( (byte)( 218 ) ) ) ) );
			this.circularProgressControl.Location = new System.Drawing.Point( 367 , 173 );
			this.circularProgressControl.Name = "circularProgressControl";
			this.circularProgressControl.Size = new System.Drawing.Size( 50 , 50 );
			this.circularProgressControl.TabIndex = 18;
			this.circularProgressControl.TransistionSegmentColour = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 129 ) ) ) ) , ( (int)( ( (byte)( 242 ) ) ) ) , ( (int)( ( (byte)( 121 ) ) ) ) );
			this.circularProgressControl.Visible = false;
			// 
			// avatarBrowserControl1
			// 
			this.avatarBrowserControl1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.avatarBrowserControl1.Location = new System.Drawing.Point( 23 , 118 );
			this.avatarBrowserControl1.Name = "avatarBrowserControl1";
			this.avatarBrowserControl1.Renderer = avatarBrowserRenderer1;
			avatarBrowserScheme1.AvatarSpacing = 10;
			avatarBrowserScheme1.NavigationButtonBackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 170 ) ) ) ) , ( (int)( ( (byte)( 170 ) ) ) ) , ( (int)( ( (byte)( 170 ) ) ) ) );
			avatarBrowserScheme1.NavigationButtonBackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 50 ) ) ) ) , ( (int)( ( (byte)( 50 ) ) ) ) , ( (int)( ( (byte)( 50 ) ) ) ) );
			avatarBrowserScheme1.NavigationButtonBorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			avatarBrowserScheme1.NavigationButtonWidth = 20;
			avatarBrowserScheme1.SelectedBackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 234 ) ) ) ) , ( (int)( ( (byte)( 194 ) ) ) ) );
			avatarBrowserScheme1.SelectedBackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 211 ) ) ) ) , ( (int)( ( (byte)( 125 ) ) ) ) );
			avatarBrowserScheme1.SelectedBackgroundColor3 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) , ( (int)( ( (byte)( 71 ) ) ) ) );
			avatarBrowserScheme1.SelectedBackgroundColor4 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 185 ) ) ) ) );
			avatarBrowserScheme1.SelectedBorderColor = System.Drawing.Color.Gray;
			this.avatarBrowserControl1.Scheme = avatarBrowserScheme1;
			this.avatarBrowserControl1.SelectedImage = null;
			this.avatarBrowserControl1.Size = new System.Drawing.Size( 739 , 161 );
			this.avatarBrowserControl1.TabIndex = 5;
			// 
			// removeButton
			// 
			this.removeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.removeButton.Caption = "Verwijderen";
			this.removeButton.Location = new System.Drawing.Point( 395 , 297 );
			this.removeButton.Name = "removeButton";
			this.removeButton.Picture = null;
			this.removeButton.Renderer = buttonRenderer1;
			buttonScheme1.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			buttonScheme1.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			buttonScheme1.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme1.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			buttonScheme1.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			buttonScheme1.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat1.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat1.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat1.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme1.CaptionFormat = stringFormat1;
			buttonScheme1.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme1.GreenButton = false;
			buttonScheme1.RedButton = false;
			this.removeButton.SchemeDisabled = buttonScheme1;
			buttonScheme2.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 251 ) ) ) ) , ( (int)( ( (byte)( 253 ) ) ) ) );
			buttonScheme2.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 213 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) , ( (int)( ( (byte)( 252 ) ) ) ) );
			buttonScheme2.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme2.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme2.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme2.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat2.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat2.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat2.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat2.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme2.CaptionFormat = stringFormat2;
			buttonScheme2.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme2.GreenButton = false;
			buttonScheme2.RedButton = false;
			this.removeButton.SchemeHovered = buttonScheme2;
			buttonScheme3.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			buttonScheme3.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			buttonScheme3.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme3.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme3.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme3.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat3.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat3.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat3.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat3.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme3.CaptionFormat = stringFormat3;
			buttonScheme3.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme3.GreenButton = false;
			buttonScheme3.RedButton = false;
			this.removeButton.SchemeNormal = buttonScheme3;
			buttonScheme4.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 214 ) ) ) ) , ( (int)( ( (byte)( 214 ) ) ) ) , ( (int)( ( (byte)( 214 ) ) ) ) );
			buttonScheme4.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) );
			buttonScheme4.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme4.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme4.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme4.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat4.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat4.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat4.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat4.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme4.CaptionFormat = stringFormat4;
			buttonScheme4.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme4.GreenButton = false;
			buttonScheme4.RedButton = false;
			this.removeButton.SchemePushed = buttonScheme4;
			this.removeButton.Size = new System.Drawing.Size( 150 , 25 );
			this.removeButton.State = SwmSuite.Presentation.Common.ButtonState.Normal;
			this.removeButton.TabIndex = 4;
			this.removeButton.Click += new System.EventHandler( this.removeButton_Click );
			// 
			// addButton
			// 
			this.addButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.addButton.Caption = "Toevoegen";
			this.addButton.Location = new System.Drawing.Point( 239 , 297 );
			this.addButton.Name = "addButton";
			this.addButton.Picture = null;
			this.addButton.Renderer = buttonRenderer2;
			buttonScheme5.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			buttonScheme5.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			buttonScheme5.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme5.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			buttonScheme5.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			buttonScheme5.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat5.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat5.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat5.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat5.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme5.CaptionFormat = stringFormat5;
			buttonScheme5.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme5.GreenButton = false;
			buttonScheme5.RedButton = false;
			this.addButton.SchemeDisabled = buttonScheme5;
			buttonScheme6.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 251 ) ) ) ) , ( (int)( ( (byte)( 253 ) ) ) ) );
			buttonScheme6.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 213 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) , ( (int)( ( (byte)( 252 ) ) ) ) );
			buttonScheme6.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme6.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme6.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme6.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat6.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat6.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat6.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat6.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme6.CaptionFormat = stringFormat6;
			buttonScheme6.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme6.GreenButton = false;
			buttonScheme6.RedButton = false;
			this.addButton.SchemeHovered = buttonScheme6;
			buttonScheme7.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			buttonScheme7.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			buttonScheme7.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme7.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme7.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme7.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat7.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat7.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat7.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat7.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme7.CaptionFormat = stringFormat7;
			buttonScheme7.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme7.GreenButton = false;
			buttonScheme7.RedButton = false;
			this.addButton.SchemeNormal = buttonScheme7;
			buttonScheme8.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 214 ) ) ) ) , ( (int)( ( (byte)( 214 ) ) ) ) , ( (int)( ( (byte)( 214 ) ) ) ) );
			buttonScheme8.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) );
			buttonScheme8.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme8.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme8.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme8.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat8.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat8.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat8.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat8.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme8.CaptionFormat = stringFormat8;
			buttonScheme8.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme8.GreenButton = false;
			buttonScheme8.RedButton = false;
			this.addButton.SchemePushed = buttonScheme8;
			this.addButton.Size = new System.Drawing.Size( 150 , 25 );
			this.addButton.State = SwmSuite.Presentation.Common.ButtonState.Normal;
			this.addButton.TabIndex = 2;
			this.addButton.Click += new System.EventHandler( this.addButton_Click );
			// 
			// statusControl
			// 
			this.statusControl.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.statusControl.LeftCaption = null;
			this.statusControl.Location = new System.Drawing.Point( 0 , 344 );
			this.statusControl.MiddleCaption = null;
			this.statusControl.Name = "statusControl";
			this.statusControl.Renderer = statusRenderer1;
			this.statusControl.RightCaption = null;
			statusScheme1.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 67 ) ) ) ) , ( (int)( ( (byte)( 71 ) ) ) ) , ( (int)( ( (byte)( 82 ) ) ) ) );
			statusScheme1.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 48 ) ) ) ) , ( (int)( ( (byte)( 48 ) ) ) ) , ( (int)( ( (byte)( 48 ) ) ) ) );
			statusScheme1.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			statusScheme1.CaptionFont = new System.Drawing.Font( "Copperplate Gothic Light" , 10F );
			this.statusControl.Scheme = statusScheme1;
			this.statusControl.Size = new System.Drawing.Size( 784 , 20 );
			this.statusControl.TabIndex = 1;
			// 
			// moduleWindowHeaderControl
			// 
			this.moduleWindowHeaderControl.Controls.Add( this.analogClockControl1 );
			this.moduleWindowHeaderControl.Controls.Add( this.pictureBox1 );
			this.moduleWindowHeaderControl.Controls.Add( this.mirrorTextControl );
			this.moduleWindowHeaderControl.Dock = System.Windows.Forms.DockStyle.Top;
			this.moduleWindowHeaderControl.Location = new System.Drawing.Point( 0 , 0 );
			this.moduleWindowHeaderControl.Name = "moduleWindowHeaderControl";
			moduleWindowHeaderScheme1.BackgroundFlood1Color = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 89 ) ) ) ) , ( (int)( ( (byte)( 106 ) ) ) ) , ( (int)( ( (byte)( 146 ) ) ) ) );
			moduleWindowHeaderScheme1.BackgroundFlood2Color = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 52 ) ) ) ) , ( (int)( ( (byte)( 56 ) ) ) ) , ( (int)( ( (byte)( 66 ) ) ) ) );
			moduleWindowHeaderScheme1.BackgroundFlood3Color = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			moduleWindowHeaderScheme1.BackgroundFlood4Color = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 56 ) ) ) ) , ( (int)( ( (byte)( 69 ) ) ) ) , ( (int)( ( (byte)( 102 ) ) ) ) );
			moduleWindowHeaderRenderer1.Scheme = moduleWindowHeaderScheme1;
			this.moduleWindowHeaderControl.Renderer = moduleWindowHeaderRenderer1;
			this.moduleWindowHeaderControl.Size = new System.Drawing.Size( 784 , 100 );
			this.moduleWindowHeaderControl.TabIndex = 0;
			// 
			// analogClockControl1
			// 
			this.analogClockControl1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.analogClockControl1.BackColor = System.Drawing.Color.Transparent;
			this.analogClockControl1.Location = new System.Drawing.Point( 682 , 3 );
			this.analogClockControl1.Name = "analogClockControl1";
			this.analogClockControl1.Renderer = analogClockRenderer1;
			analogClockScheme1.BackgroundColor = System.Drawing.Color.Transparent;
			analogClockScheme1.BorderColor = System.Drawing.Color.White;
			analogClockScheme1.BorderWidth = 1F;
			analogClockScheme1.CountDownFillColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 128 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 100 ) ) ) ) , ( (int)( ( (byte)( 100 ) ) ) ) );
			analogClockScheme1.HourHandColor = System.Drawing.Color.White;
			analogClockScheme1.HourHandWidth = 2F;
			analogClockScheme1.HourIndicatorColor = System.Drawing.Color.White;
			analogClockScheme1.HourIndicatorWidth = 1F;
			analogClockScheme1.MinuteHandColor = System.Drawing.Color.White;
			analogClockScheme1.MinuteHandWidth = 2F;
			analogClockScheme1.SecondHandColor = System.Drawing.Color.Red;
			analogClockScheme1.SecondHandWidth = 1F;
			analogClockScheme1.TimeColor = System.Drawing.Color.White;
			analogClockScheme1.TimeFont = new System.Drawing.Font( "Verdana" , 10F );
			this.analogClockControl1.Scheme = analogClockScheme1;
			this.analogClockControl1.Size = new System.Drawing.Size( 99 , 94 );
			this.analogClockControl1.TabIndex = 3;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = global::SwmSuiteAvatarManagement.Properties.Resources.avatar;
			this.pictureBox1.Location = new System.Drawing.Point( 3 , 3 );
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size( 94 , 94 );
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// mirrorTextControl
			// 
			this.mirrorTextControl.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom ) ) );
			this.mirrorTextControl.BackColor = System.Drawing.Color.Transparent;
			this.mirrorTextControl.Caption = "A v a t a r   M a n a g e m e n t";
			this.mirrorTextControl.Location = new System.Drawing.Point( 154 , 20 );
			this.mirrorTextControl.Name = "mirrorTextControl";
			this.mirrorTextControl.Renderer = mirrorTextRenderer1;
			mirrorTextScheme1.Correction = 8;
			mirrorTextScheme1.TextColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			mirrorTextScheme1.TextFont = new System.Drawing.Font( "Verdana" , 20.25F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.mirrorTextControl.Scheme = mirrorTextScheme1;
			this.mirrorTextControl.Size = new System.Drawing.Size( 476 , 58 );
			this.mirrorTextControl.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size( 784 , 364 );
			this.Controls.Add( this.circularProgressControl );
			this.Controls.Add( this.avatarBrowserControl1 );
			this.Controls.Add( this.removeButton );
			this.Controls.Add( this.addButton );
			this.Controls.Add( this.statusControl );
			this.Controls.Add( this.moduleWindowHeaderControl );
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.MinimumSize = new System.Drawing.Size( 800 , 400 );
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Simple Workfloor Management Suite";
			this.Load += new System.EventHandler( this.MainForm_Load );
			this.moduleWindowHeaderControl.ResumeLayout( false );
			( (System.ComponentModel.ISupportInitialize)( this.pictureBox1 ) ).EndInit();
			this.ResumeLayout( false );

		}

		#endregion

		private SwmSuite.Presentation.Common.ModuleWindowHeader.ModuleWindowHeaderControl moduleWindowHeaderControl;
		private SwmSuite.Presentation.Common.Status.StatusControl statusControl;
		private SwmSuite.Presentation.Common.MirrorText.MirrorTextControl mirrorTextControl;
		private System.Windows.Forms.PictureBox pictureBox1;
		private SwmSuite.Presentation.Common.AnalogClock.AnalogClockControl analogClockControl1;
		private SwmSuite.Presentation.Common.ButtonControl addButton;
		private SwmSuite.Presentation.Common.ButtonControl removeButton;
		private SwmSuite.Presentation.Common.AvatarBrowser.AvatarBrowserControl avatarBrowserControl1;
		private SwmSuite.Presentation.Common.UserControls.CircularProgressControl circularProgressControl;
		private System.ComponentModel.BackgroundWorker getBackgroundWorker;
		private System.ComponentModel.BackgroundWorker insertBackgroundWorker;
		private System.ComponentModel.BackgroundWorker removeBackgroundWorker;
	}
}

