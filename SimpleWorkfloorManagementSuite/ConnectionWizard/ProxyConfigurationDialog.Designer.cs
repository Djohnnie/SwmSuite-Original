namespace SwmSuite.Presentation.ConnectionWizard {
	partial class ProxyConfigurationDialog {
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
			this.dialogHeaderControl1 = new SwmSuite.Presentation.Common.DialogHeader.DialogHeaderControl();
			this.label1 = new System.Windows.Forms.Label();
			this.cancelButton = new SwmSuite.Presentation.Common.ButtonControl();
			this.okButton = new SwmSuite.Presentation.Common.ButtonControl();
			this.label3 = new System.Windows.Forms.Label();
			this.proxyAddressTextBox = new SwmSuite.Presentation.Common.NiceTextBox.NiceTextBoxControl();
			this.label2 = new System.Windows.Forms.Label();
			this.portTextBox = new SwmSuite.Presentation.Common.NiceTextBox.NiceTextBoxControl();
			this.SuspendLayout();
			// 
			// dialogHeaderControl1
			// 
			this.dialogHeaderControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.dialogHeaderControl1.Location = new System.Drawing.Point( 0 , 0 );
			this.dialogHeaderControl1.MainText = "  Proxy Server";
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
			this.dialogHeaderControl1.Size = new System.Drawing.Size( 468 , 59 );
			this.dialogHeaderControl1.SubText = "   Instellingen voor connectie via een proxy-server";
			this.dialogHeaderControl1.TabIndex = 14;
			this.dialogHeaderControl1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.label1.Location = new System.Drawing.Point( 12 , 71 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 452 , 39 );
			this.label1.TabIndex = 13;
			this.label1.Text = "Als u zich achter een proxy-sever bevindt kan u hier het IP-adres en poort voor H" +
				 "TTP verbindingen opgeven.";
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cancelButton.Caption = "Annuleren";
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point( 254 , 199 );
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
			this.cancelButton.Size = new System.Drawing.Size( 100 , 25 );
			this.cancelButton.State = SwmSuite.Presentation.Common.ButtonState.Normal;
			this.cancelButton.TabIndex = 16;
			this.cancelButton.Click += new System.EventHandler( this.cancelButton_Click );
			// 
			// okButton
			// 
			this.okButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.okButton.Caption = "Opslaan";
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point( 360 , 199 );
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
			this.okButton.Size = new System.Drawing.Size( 100 , 25 );
			this.okButton.State = SwmSuite.Presentation.Common.ButtonState.Normal;
			this.okButton.TabIndex = 15;
			this.okButton.Click += new System.EventHandler( this.okButton_Click );
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.label3.Location = new System.Drawing.Point( 26 , 121 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 133 , 16 );
			this.label3.TabIndex = 18;
			this.label3.Text = "Proxy-server adres";
			// 
			// proxyAddressTextBox
			// 
			this.proxyAddressTextBox.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.proxyAddressTextBox.BorderColorFocused = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 160 ) ) ) ) , ( (int)( ( (byte)( 17 ) ) ) ) );
			this.proxyAddressTextBox.BorderColorHovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 153 ) ) ) ) , ( (int)( ( (byte)( 207 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			this.proxyAddressTextBox.BorderColorNormal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 125 ) ) ) ) , ( (int)( ( (byte)( 170 ) ) ) ) , ( (int)( ( (byte)( 210 ) ) ) ) );
			// 
			// 
			// 
			this.proxyAddressTextBox.Client.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.proxyAddressTextBox.Client.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.proxyAddressTextBox.Client.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.proxyAddressTextBox.Client.Location = new System.Drawing.Point( 4 , 2 );
			this.proxyAddressTextBox.Client.Name = "textbox";
			this.proxyAddressTextBox.Client.Size = new System.Drawing.Size( 387 , 16 );
			this.proxyAddressTextBox.Client.TabIndex = 0;
			this.proxyAddressTextBox.ContentsDisableColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) );
			this.proxyAddressTextBox.ContentsErrorColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 232 ) ) ) ) );
			this.proxyAddressTextBox.ContentsOkColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.proxyAddressTextBox.Location = new System.Drawing.Point( 29 , 140 );
			this.proxyAddressTextBox.Name = "proxyAddressTextBox";
			this.proxyAddressTextBox.Size = new System.Drawing.Size( 396 , 22 );
			this.proxyAddressTextBox.TabIndex = 17;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.label2.Location = new System.Drawing.Point( 26 , 170 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 43 , 16 );
			this.label2.TabIndex = 20;
			this.label2.Text = "Poort";
			// 
			// portTextBox
			// 
			this.portTextBox.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.portTextBox.BorderColorFocused = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 160 ) ) ) ) , ( (int)( ( (byte)( 17 ) ) ) ) );
			this.portTextBox.BorderColorHovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 153 ) ) ) ) , ( (int)( ( (byte)( 207 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			this.portTextBox.BorderColorNormal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 125 ) ) ) ) , ( (int)( ( (byte)( 170 ) ) ) ) , ( (int)( ( (byte)( 210 ) ) ) ) );
			// 
			// 
			// 
			this.portTextBox.Client.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.portTextBox.Client.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.portTextBox.Client.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.portTextBox.Client.Location = new System.Drawing.Point( 4 , 2 );
			this.portTextBox.Client.Name = "textbox";
			this.portTextBox.Client.Size = new System.Drawing.Size( 75 , 16 );
			this.portTextBox.Client.TabIndex = 0;
			this.portTextBox.ContentsDisableColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) );
			this.portTextBox.ContentsErrorColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 232 ) ) ) ) );
			this.portTextBox.ContentsOkColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.portTextBox.Location = new System.Drawing.Point( 29 , 189 );
			this.portTextBox.Name = "portTextBox";
			this.portTextBox.Size = new System.Drawing.Size( 84 , 22 );
			this.portTextBox.TabIndex = 19;
			// 
			// ProxyConfigurationDialog
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size( 468 , 232 );
			this.ControlBox = false;
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.portTextBox );
			this.Controls.Add( this.label3 );
			this.Controls.Add( this.proxyAddressTextBox );
			this.Controls.Add( this.cancelButton );
			this.Controls.Add( this.okButton );
			this.Controls.Add( this.dialogHeaderControl1 );
			this.Controls.Add( this.label1 );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProxyConfigurationDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Simple Workfloor Management Suite";
			this.Load += new System.EventHandler( this.ProxyConfigurationDialog_Load );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private SwmSuite.Presentation.Common.DialogHeader.DialogHeaderControl dialogHeaderControl1;
		private System.Windows.Forms.Label label1;
		private SwmSuite.Presentation.Common.ButtonControl cancelButton;
		private SwmSuite.Presentation.Common.ButtonControl okButton;
		private System.Windows.Forms.Label label3;
		private SwmSuite.Presentation.Common.NiceTextBox.NiceTextBoxControl proxyAddressTextBox;
		private System.Windows.Forms.Label label2;
		private SwmSuite.Presentation.Common.NiceTextBox.NiceTextBoxControl portTextBox;
	}
}