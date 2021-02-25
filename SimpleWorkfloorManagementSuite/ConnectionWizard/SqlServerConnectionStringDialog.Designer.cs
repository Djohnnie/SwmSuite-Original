namespace SwmSuite.Presentation.ConnectionWizard {
	partial class SqlServerConnectionStringDialog {
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
			SwmSuite.Presentation.Common.ButtonRenderer buttonRenderer3 = new SwmSuite.Presentation.Common.ButtonRenderer();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme9 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat9 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme10 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat10 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme11 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat11 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme12 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat12 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.Group.GroupRenderer groupRenderer1 = new SwmSuite.Presentation.Common.Group.GroupRenderer();
			SwmSuite.Presentation.Common.Group.GroupScheme groupScheme1 = new SwmSuite.Presentation.Common.Group.GroupScheme();
			SwmSuite.Presentation.Common.Group.GroupRenderer groupRenderer2 = new SwmSuite.Presentation.Common.Group.GroupRenderer();
			SwmSuite.Presentation.Common.Group.GroupScheme groupScheme2 = new SwmSuite.Presentation.Common.Group.GroupScheme();
			SwmSuite.Presentation.Common.DialogHeader.DialogHeaderRenderer dialogHeaderRenderer1 = new SwmSuite.Presentation.Common.DialogHeader.DialogHeaderRenderer();
			SwmSuite.Presentation.Common.DialogHeader.DialogHeaderScheme dialogHeaderScheme1 = new SwmSuite.Presentation.Common.DialogHeader.DialogHeaderScheme();
			this.label2 = new System.Windows.Forms.Label();
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.cancelButton = new SwmSuite.Presentation.Common.ButtonControl();
			this.okButton = new SwmSuite.Presentation.Common.ButtonControl();
			this.resultTextBox = new SwmSuite.Presentation.Common.NiceTextBox.NiceTextBoxControl();
			this.testButton = new SwmSuite.Presentation.Common.ButtonControl();
			this.groupControl2 = new SwmSuite.Presentation.Common.Group.GroupControl();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.passwordTextBox = new SwmSuite.Presentation.Common.NiceTextBox.NiceTextBoxControl();
			this.nameTextBox = new SwmSuite.Presentation.Common.NiceTextBox.NiceTextBoxControl();
			this.sqlAuthenticationRadioButton = new System.Windows.Forms.RadioButton();
			this.windowsAuthenticationRadioButton = new System.Windows.Forms.RadioButton();
			this.groupControl1 = new SwmSuite.Presentation.Common.Group.GroupControl();
			this.circularProgressControl = new SwmSuite.Presentation.Common.UserControls.CircularProgressControl();
			this.databasesRadioGroup = new SwmSuite.Presentation.Common.RadioGroup.RadioGroupControl();
			this.serverTextBox = new SwmSuite.Presentation.Common.NiceTextBox.NiceTextBoxControl();
			this.dialogHeaderControl1 = new SwmSuite.Presentation.Common.DialogHeader.DialogHeaderControl();
			this.groupControl2.SuspendLayout();
			this.groupControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.label2.Location = new System.Drawing.Point( 35 , 71 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 276 , 16 );
			this.label2.TabIndex = 15;
			this.label2.Text = "SQL Server (vb: localhost\\SQLEXPRESS)";
			// 
			// backgroundWorker
			// 
			this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler( this.backgroundWorker_DoWork );
			this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler( this.backgroundWorker_RunWorkerCompleted );
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cancelButton.Caption = "Annuleren";
			this.cancelButton.Location = new System.Drawing.Point( 78 , 443 );
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Picture = null;
			this.cancelButton.Renderer = buttonRenderer1;
			buttonScheme1.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			buttonScheme1.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			buttonScheme1.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme1.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 190 ) ) ) ) , ( (int)( ( (byte)( 190 ) ) ) ) , ( (int)( ( (byte)( 190 ) ) ) ) );
			buttonScheme1.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme1.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat1.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat1.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat1.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme1.CaptionFormat = stringFormat1;
			buttonScheme1.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme1.GreenButton = false;
			buttonScheme1.RedButton = false;
			this.cancelButton.SchemeDisabled = buttonScheme1;
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
			this.cancelButton.SchemeHovered = buttonScheme2;
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
			this.cancelButton.SchemeNormal = buttonScheme3;
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
			this.cancelButton.SchemePushed = buttonScheme4;
			this.cancelButton.Size = new System.Drawing.Size( 115 , 25 );
			this.cancelButton.State = SwmSuite.Presentation.Common.ButtonState.Normal;
			this.cancelButton.TabIndex = 22;
			this.cancelButton.Click += new System.EventHandler( this.cancelButton_Click );
			// 
			// okButton
			// 
			this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.okButton.Caption = "OK";
			this.okButton.Location = new System.Drawing.Point( 199 , 443 );
			this.okButton.Name = "okButton";
			this.okButton.Picture = null;
			this.okButton.Renderer = buttonRenderer2;
			buttonScheme5.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			buttonScheme5.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			buttonScheme5.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme5.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 190 ) ) ) ) , ( (int)( ( (byte)( 190 ) ) ) ) , ( (int)( ( (byte)( 190 ) ) ) ) );
			buttonScheme5.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme5.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat5.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat5.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat5.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat5.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme5.CaptionFormat = stringFormat5;
			buttonScheme5.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme5.GreenButton = false;
			buttonScheme5.RedButton = false;
			this.okButton.SchemeDisabled = buttonScheme5;
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
			this.okButton.SchemeHovered = buttonScheme6;
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
			this.okButton.SchemeNormal = buttonScheme7;
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
			this.okButton.SchemePushed = buttonScheme8;
			this.okButton.Size = new System.Drawing.Size( 115 , 25 );
			this.okButton.State = SwmSuite.Presentation.Common.ButtonState.Normal;
			this.okButton.TabIndex = 21;
			this.okButton.Click += new System.EventHandler( this.okButton_Click );
			// 
			// resultTextBox
			// 
			this.resultTextBox.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.resultTextBox.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.resultTextBox.BorderColorFocused = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 160 ) ) ) ) , ( (int)( ( (byte)( 17 ) ) ) ) );
			this.resultTextBox.BorderColorHovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 153 ) ) ) ) , ( (int)( ( (byte)( 207 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			this.resultTextBox.BorderColorNormal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 125 ) ) ) ) , ( (int)( ( (byte)( 170 ) ) ) ) , ( (int)( ( (byte)( 210 ) ) ) ) );
			// 
			// 
			// 
			this.resultTextBox.Client.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.resultTextBox.Client.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.resultTextBox.Client.Location = new System.Drawing.Point( 4 , 2 );
			this.resultTextBox.Client.Margin = new System.Windows.Forms.Padding( 28 , 17 , 28 , 17 );
			this.resultTextBox.Client.Multiline = true;
			this.resultTextBox.Client.Name = "textbox";
			this.resultTextBox.Client.Size = new System.Drawing.Size( 378 , 33 );
			this.resultTextBox.Client.TabIndex = 0;
			this.resultTextBox.ContentsDisableColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) );
			this.resultTextBox.ContentsErrorColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 232 ) ) ) ) );
			this.resultTextBox.ContentsOkColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.resultTextBox.Enabled = false;
			this.resultTextBox.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.resultTextBox.Location = new System.Drawing.Point( 3 , 475 );
			this.resultTextBox.Margin = new System.Windows.Forms.Padding( 4 , 4 , 4 , 4 );
			this.resultTextBox.Name = "resultTextBox";
			this.resultTextBox.Size = new System.Drawing.Size( 387 , 38 );
			this.resultTextBox.TabIndex = 20;
			// 
			// testButton
			// 
			this.testButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.testButton.Caption = "Test";
			this.testButton.Location = new System.Drawing.Point( 139 , 290 );
			this.testButton.Name = "testButton";
			this.testButton.Picture = null;
			this.testButton.Renderer = buttonRenderer3;
			buttonScheme9.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			buttonScheme9.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			buttonScheme9.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme9.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 190 ) ) ) ) , ( (int)( ( (byte)( 190 ) ) ) ) , ( (int)( ( (byte)( 190 ) ) ) ) );
			buttonScheme9.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme9.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat9.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat9.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat9.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat9.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme9.CaptionFormat = stringFormat9;
			buttonScheme9.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme9.GreenButton = false;
			buttonScheme9.RedButton = false;
			this.testButton.SchemeDisabled = buttonScheme9;
			buttonScheme10.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 251 ) ) ) ) , ( (int)( ( (byte)( 253 ) ) ) ) );
			buttonScheme10.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 213 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) , ( (int)( ( (byte)( 252 ) ) ) ) );
			buttonScheme10.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme10.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme10.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme10.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat10.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat10.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat10.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat10.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme10.CaptionFormat = stringFormat10;
			buttonScheme10.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme10.GreenButton = false;
			buttonScheme10.RedButton = false;
			this.testButton.SchemeHovered = buttonScheme10;
			buttonScheme11.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			buttonScheme11.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			buttonScheme11.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme11.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme11.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme11.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat11.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat11.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat11.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat11.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme11.CaptionFormat = stringFormat11;
			buttonScheme11.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme11.GreenButton = false;
			buttonScheme11.RedButton = false;
			this.testButton.SchemeNormal = buttonScheme11;
			buttonScheme12.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 214 ) ) ) ) , ( (int)( ( (byte)( 214 ) ) ) ) , ( (int)( ( (byte)( 214 ) ) ) ) );
			buttonScheme12.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) );
			buttonScheme12.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme12.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme12.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme12.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat12.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat12.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat12.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat12.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme12.CaptionFormat = stringFormat12;
			buttonScheme12.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme12.GreenButton = false;
			buttonScheme12.RedButton = false;
			this.testButton.SchemePushed = buttonScheme12;
			this.testButton.Size = new System.Drawing.Size( 115 , 22 );
			this.testButton.State = SwmSuite.Presentation.Common.ButtonState.Normal;
			this.testButton.TabIndex = 19;
			this.testButton.Click += new System.EventHandler( this.testButton_Click );
			// 
			// groupControl2
			// 
			this.groupControl2.Caption = "Authenticatie";
			this.groupControl2.Controls.Add( this.label3 );
			this.groupControl2.Controls.Add( this.label1 );
			this.groupControl2.Controls.Add( this.passwordTextBox );
			this.groupControl2.Controls.Add( this.nameTextBox );
			this.groupControl2.Controls.Add( this.sqlAuthenticationRadioButton );
			this.groupControl2.Controls.Add( this.windowsAuthenticationRadioButton );
			this.groupControl2.Location = new System.Drawing.Point( 13 , 118 );
			this.groupControl2.Name = "groupControl2";
			this.groupControl2.Renderer = groupRenderer1;
			groupScheme1.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			groupScheme1.BorderWidth = 1;
			groupScheme1.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			groupScheme1.CaptionFont = new System.Drawing.Font( "Copperplate Gothic Light" , 10F );
			this.groupControl2.Scheme = groupScheme1;
			this.groupControl2.Size = new System.Drawing.Size( 366 , 168 );
			this.groupControl2.TabIndex = 18;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.label3.Location = new System.Drawing.Point( 67 , 115 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 91 , 16 );
			this.label3.TabIndex = 17;
			this.label3.Text = "Wachtwoord";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.label1.Location = new System.Drawing.Point( 68 , 72 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 44 , 16 );
			this.label1.TabIndex = 16;
			this.label1.Text = "Naam";
			// 
			// passwordTextBox
			// 
			this.passwordTextBox.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.passwordTextBox.BorderColorFocused = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 160 ) ) ) ) , ( (int)( ( (byte)( 17 ) ) ) ) );
			this.passwordTextBox.BorderColorHovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 153 ) ) ) ) , ( (int)( ( (byte)( 207 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			this.passwordTextBox.BorderColorNormal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 125 ) ) ) ) , ( (int)( ( (byte)( 170 ) ) ) ) , ( (int)( ( (byte)( 210 ) ) ) ) );
			// 
			// 
			// 
			this.passwordTextBox.Client.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.passwordTextBox.Client.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.passwordTextBox.Client.Location = new System.Drawing.Point( 4 , 2 );
			this.passwordTextBox.Client.Margin = new System.Windows.Forms.Padding( 28 , 17 , 28 , 17 );
			this.passwordTextBox.Client.Name = "textbox";
			this.passwordTextBox.Client.PasswordChar = '●';
			this.passwordTextBox.Client.Size = new System.Drawing.Size( 218 , 16 );
			this.passwordTextBox.Client.TabIndex = 0;
			this.passwordTextBox.Client.UseSystemPasswordChar = true;
			this.passwordTextBox.ContentsDisableColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) );
			this.passwordTextBox.ContentsErrorColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 232 ) ) ) ) );
			this.passwordTextBox.ContentsOkColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.passwordTextBox.Font = new System.Drawing.Font( "Verdana" , 9.75F );
			this.passwordTextBox.Location = new System.Drawing.Point( 72 , 135 );
			this.passwordTextBox.Margin = new System.Windows.Forms.Padding( 4 , 4 , 4 , 4 );
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.Size = new System.Drawing.Size( 227 , 22 );
			this.passwordTextBox.TabIndex = 3;
			this.passwordTextBox.TextChanged += new System.EventHandler<System.EventArgs>( this.passwordTextBox_TextChanged );
			// 
			// nameTextBox
			// 
			this.nameTextBox.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.nameTextBox.BorderColorFocused = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 160 ) ) ) ) , ( (int)( ( (byte)( 17 ) ) ) ) );
			this.nameTextBox.BorderColorHovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 153 ) ) ) ) , ( (int)( ( (byte)( 207 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			this.nameTextBox.BorderColorNormal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 125 ) ) ) ) , ( (int)( ( (byte)( 170 ) ) ) ) , ( (int)( ( (byte)( 210 ) ) ) ) );
			// 
			// 
			// 
			this.nameTextBox.Client.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.nameTextBox.Client.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.nameTextBox.Client.Location = new System.Drawing.Point( 4 , 2 );
			this.nameTextBox.Client.Margin = new System.Windows.Forms.Padding( 28 , 17 , 28 , 17 );
			this.nameTextBox.Client.Name = "textbox";
			this.nameTextBox.Client.Size = new System.Drawing.Size( 219 , 16 );
			this.nameTextBox.Client.TabIndex = 0;
			this.nameTextBox.ContentsDisableColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) );
			this.nameTextBox.ContentsErrorColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 232 ) ) ) ) );
			this.nameTextBox.ContentsOkColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.nameTextBox.Font = new System.Drawing.Font( "Verdana" , 9.75F );
			this.nameTextBox.Location = new System.Drawing.Point( 71 , 92 );
			this.nameTextBox.Margin = new System.Windows.Forms.Padding( 4 , 4 , 4 , 4 );
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size( 228 , 22 );
			this.nameTextBox.TabIndex = 2;
			this.nameTextBox.TextChanged += new System.EventHandler<System.EventArgs>( this.nameTextBox_TextChanged );
			// 
			// sqlAuthenticationRadioButton
			// 
			this.sqlAuthenticationRadioButton.AutoSize = true;
			this.sqlAuthenticationRadioButton.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.sqlAuthenticationRadioButton.Location = new System.Drawing.Point( 23 , 49 );
			this.sqlAuthenticationRadioButton.Name = "sqlAuthenticationRadioButton";
			this.sqlAuthenticationRadioButton.Size = new System.Drawing.Size( 188 , 20 );
			this.sqlAuthenticationRadioButton.TabIndex = 1;
			this.sqlAuthenticationRadioButton.TabStop = true;
			this.sqlAuthenticationRadioButton.Text = "Sql Server Authenticatie";
			this.sqlAuthenticationRadioButton.UseVisualStyleBackColor = true;
			this.sqlAuthenticationRadioButton.CheckedChanged += new System.EventHandler( this.sqlAuthenticationRadioButton_CheckedChanged );
			// 
			// windowsAuthenticationRadioButton
			// 
			this.windowsAuthenticationRadioButton.AutoSize = true;
			this.windowsAuthenticationRadioButton.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.windowsAuthenticationRadioButton.Location = new System.Drawing.Point( 23 , 23 );
			this.windowsAuthenticationRadioButton.Name = "windowsAuthenticationRadioButton";
			this.windowsAuthenticationRadioButton.Size = new System.Drawing.Size( 178 , 20 );
			this.windowsAuthenticationRadioButton.TabIndex = 0;
			this.windowsAuthenticationRadioButton.TabStop = true;
			this.windowsAuthenticationRadioButton.Text = "Windows Authenticatie";
			this.windowsAuthenticationRadioButton.UseVisualStyleBackColor = true;
			this.windowsAuthenticationRadioButton.CheckedChanged += new System.EventHandler( this.windowsAuthenticationRadioButton_CheckedChanged );
			// 
			// groupControl1
			// 
			this.groupControl1.Caption = "gevonden databases";
			this.groupControl1.Controls.Add( this.circularProgressControl );
			this.groupControl1.Controls.Add( this.databasesRadioGroup );
			this.groupControl1.Location = new System.Drawing.Point( 12 , 320 );
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Renderer = groupRenderer2;
			groupScheme2.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			groupScheme2.BorderWidth = 1;
			groupScheme2.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			groupScheme2.CaptionFont = new System.Drawing.Font( "Copperplate Gothic Light" , 10F );
			this.groupControl1.Scheme = groupScheme2;
			this.groupControl1.Size = new System.Drawing.Size( 369 , 117 );
			this.groupControl1.TabIndex = 17;
			// 
			// circularProgressControl
			// 
			this.circularProgressControl.ActiveSegmentColour = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 35 ) ) ) ) , ( (int)( ( (byte)( 146 ) ) ) ) , ( (int)( ( (byte)( 33 ) ) ) ) );
			this.circularProgressControl.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.circularProgressControl.InactiveSegmentColour = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 218 ) ) ) ) , ( (int)( ( (byte)( 218 ) ) ) ) , ( (int)( ( (byte)( 218 ) ) ) ) );
			this.circularProgressControl.Location = new System.Drawing.Point( 159 , 30 );
			this.circularProgressControl.Name = "circularProgressControl";
			this.circularProgressControl.Size = new System.Drawing.Size( 50 , 50 );
			this.circularProgressControl.TabIndex = 1;
			this.circularProgressControl.TransistionSegmentColour = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 129 ) ) ) ) , ( (int)( ( (byte)( 242 ) ) ) ) , ( (int)( ( (byte)( 121 ) ) ) ) );
			this.circularProgressControl.Visible = false;
			// 
			// databasesRadioGroup
			// 
			this.databasesRadioGroup.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.databasesRadioGroup.AutoScroll = true;
			this.databasesRadioGroup.BackColor = System.Drawing.Color.Transparent;
			this.databasesRadioGroup.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.databasesRadioGroup.Location = new System.Drawing.Point( 26 , 24 );
			this.databasesRadioGroup.Margin = new System.Windows.Forms.Padding( 4 , 4 , 4 , 4 );
			this.databasesRadioGroup.Name = "databasesRadioGroup";
			this.databasesRadioGroup.Size = new System.Drawing.Size( 317 , 79 );
			this.databasesRadioGroup.TabIndex = 0;
			this.databasesRadioGroup.SelectionChanged += new System.EventHandler<SwmSuite.Presentation.Common.RadioGroup.RadioGroupSelectionChangedEventArgs>( this.databasesRadioGroup_SelectionChanged );
			// 
			// serverTextBox
			// 
			this.serverTextBox.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.serverTextBox.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.serverTextBox.BorderColorFocused = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 160 ) ) ) ) , ( (int)( ( (byte)( 17 ) ) ) ) );
			this.serverTextBox.BorderColorHovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 153 ) ) ) ) , ( (int)( ( (byte)( 207 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			this.serverTextBox.BorderColorNormal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 125 ) ) ) ) , ( (int)( ( (byte)( 170 ) ) ) ) , ( (int)( ( (byte)( 210 ) ) ) ) );
			// 
			// 
			// 
			this.serverTextBox.Client.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.serverTextBox.Client.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.serverTextBox.Client.Location = new System.Drawing.Point( 4 , 2 );
			this.serverTextBox.Client.Margin = new System.Windows.Forms.Padding( 28 , 17 , 28 , 17 );
			this.serverTextBox.Client.Name = "textbox";
			this.serverTextBox.Client.Size = new System.Drawing.Size( 308 , 16 );
			this.serverTextBox.Client.TabIndex = 0;
			this.serverTextBox.ContentsDisableColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) );
			this.serverTextBox.ContentsErrorColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 232 ) ) ) ) );
			this.serverTextBox.ContentsOkColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.serverTextBox.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.serverTextBox.Location = new System.Drawing.Point( 38 , 90 );
			this.serverTextBox.Margin = new System.Windows.Forms.Padding( 4 , 4 , 4 , 4 );
			this.serverTextBox.Name = "serverTextBox";
			this.serverTextBox.Size = new System.Drawing.Size( 317 , 22 );
			this.serverTextBox.TabIndex = 14;
			this.serverTextBox.TextChanged += new System.EventHandler<System.EventArgs>( this.serverTextBox_TextChanged );
			// 
			// dialogHeaderControl1
			// 
			this.dialogHeaderControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.dialogHeaderControl1.Location = new System.Drawing.Point( 0 , 0 );
			this.dialogHeaderControl1.MainText = "  Sql Server Connectie";
			this.dialogHeaderControl1.Name = "dialogHeaderControl1";
			this.dialogHeaderControl1.OnlyMainText = false;
			this.dialogHeaderControl1.Renderer = dialogHeaderRenderer1;
			dialogHeaderScheme1.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 10 ) ) ) ) , ( (int)( ( (byte)( 75 ) ) ) ) , ( (int)( ( (byte)( 115 ) ) ) ) );
			dialogHeaderScheme1.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 50 ) ) ) ) , ( (int)( ( (byte)( 175 ) ) ) ) , ( (int)( ( (byte)( 175 ) ) ) ) );
			dialogHeaderScheme1.SubTitleColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			dialogHeaderScheme1.SubTitleFont = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Italic , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			dialogHeaderScheme1.SubTitleRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			dialogHeaderScheme1.TitleColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			dialogHeaderScheme1.TitleFont = new System.Drawing.Font( "Verdana" , 12F , System.Drawing.FontStyle.Bold );
			dialogHeaderScheme1.TitleRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			this.dialogHeaderControl1.Scheme = dialogHeaderScheme1;
			this.dialogHeaderControl1.Size = new System.Drawing.Size( 393 , 59 );
			this.dialogHeaderControl1.SubText = "   Sql Server connectie maken";
			this.dialogHeaderControl1.TabIndex = 13;
			// 
			// SqlServerConnectionStringDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size( 393 , 516 );
			this.ControlBox = false;
			this.Controls.Add( this.cancelButton );
			this.Controls.Add( this.okButton );
			this.Controls.Add( this.resultTextBox );
			this.Controls.Add( this.testButton );
			this.Controls.Add( this.groupControl2 );
			this.Controls.Add( this.groupControl1 );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.serverTextBox );
			this.Controls.Add( this.dialogHeaderControl1 );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SqlServerConnectionStringDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Simple Workfloor Management Suite";
			this.Load += new System.EventHandler( this.SqlServerConnectionStringDialog_Load );
			this.groupControl2.ResumeLayout( false );
			this.groupControl2.PerformLayout();
			this.groupControl1.ResumeLayout( false );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private SwmSuite.Presentation.Common.DialogHeader.DialogHeaderControl dialogHeaderControl1;
		private System.Windows.Forms.Label label2;
		private SwmSuite.Presentation.Common.NiceTextBox.NiceTextBoxControl serverTextBox;
		private SwmSuite.Presentation.Common.Group.GroupControl groupControl1;
		private SwmSuite.Presentation.Common.RadioGroup.RadioGroupControl databasesRadioGroup;
		private System.ComponentModel.BackgroundWorker backgroundWorker;
		private SwmSuite.Presentation.Common.UserControls.CircularProgressControl circularProgressControl;
		private SwmSuite.Presentation.Common.Group.GroupControl groupControl2;
		private System.Windows.Forms.RadioButton sqlAuthenticationRadioButton;
		private System.Windows.Forms.RadioButton windowsAuthenticationRadioButton;
		private SwmSuite.Presentation.Common.NiceTextBox.NiceTextBoxControl nameTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private SwmSuite.Presentation.Common.NiceTextBox.NiceTextBoxControl passwordTextBox;
		private SwmSuite.Presentation.Common.ButtonControl testButton;
		private SwmSuite.Presentation.Common.NiceTextBox.NiceTextBoxControl resultTextBox;
		private SwmSuite.Presentation.Common.ButtonControl okButton;
		private SwmSuite.Presentation.Common.ButtonControl cancelButton;
	}
}