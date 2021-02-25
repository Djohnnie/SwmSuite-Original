namespace SimpleWorkfloorManagementSuite.Dialogs {
	partial class OvertimeEntryDetailDialog {
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
			SwmSuite.Presentation.Common.DialogHeader.DialogHeaderRenderer dialogHeaderRenderer4 = new SwmSuite.Presentation.Common.DialogHeader.DialogHeaderRenderer();
			SwmSuite.Presentation.Common.DialogHeader.DialogHeaderScheme dialogHeaderScheme4 = new SwmSuite.Presentation.Common.DialogHeader.DialogHeaderScheme();
			SwmSuite.Presentation.Common.ButtonRenderer buttonRenderer10 = new SwmSuite.Presentation.Common.ButtonRenderer();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme37 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat37 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme38 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat38 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme39 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat39 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme40 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat40 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonRenderer buttonRenderer11 = new SwmSuite.Presentation.Common.ButtonRenderer();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme41 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat41 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme42 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat42 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme43 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat43 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme44 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat44 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonRenderer buttonRenderer12 = new SwmSuite.Presentation.Common.ButtonRenderer();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme45 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat45 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme46 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat46 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme47 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat47 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme48 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat48 = new System.Drawing.StringFormat();
			this.dialogHeaderControl = new SwmSuite.Presentation.Common.DialogHeader.DialogHeaderControl();
			this.cancelButton = new SwmSuite.Presentation.Common.ButtonControl();
			this.okButton = new SwmSuite.Presentation.Common.ButtonControl();
			this.label1 = new System.Windows.Forms.Label();
			this.browseForEmployeeButton = new SwmSuite.Presentation.Common.ButtonControl();
			this.commissionerTextBox = new SwmSuite.Presentation.Common.NiceTextBox.NiceTextBoxControl();
			this.label2 = new System.Windows.Forms.Label();
			this.beginTimePicker = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.endTimePicker = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.descriptionTextBox = new SwmSuite.Presentation.Common.NiceTextBox.NiceTextBoxControl();
			this.SuspendLayout();
			// 
			// dialogHeaderControl
			// 
			this.dialogHeaderControl.Dock = System.Windows.Forms.DockStyle.Top;
			this.dialogHeaderControl.Location = new System.Drawing.Point( 0 , 0 );
			this.dialogHeaderControl.MainText = "  Overuren ingeven";
			this.dialogHeaderControl.Name = "dialogHeaderControl";
			this.dialogHeaderControl.OnlyMainText = true;
			this.dialogHeaderControl.Renderer = dialogHeaderRenderer4;
			dialogHeaderScheme4.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 10 ) ) ) ) , ( (int)( ( (byte)( 75 ) ) ) ) , ( (int)( ( (byte)( 115 ) ) ) ) );
			dialogHeaderScheme4.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 50 ) ) ) ) , ( (int)( ( (byte)( 175 ) ) ) ) , ( (int)( ( (byte)( 175 ) ) ) ) );
			dialogHeaderScheme4.SubTitleColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			dialogHeaderScheme4.SubTitleFont = new System.Drawing.Font( "Verdana" , 10F );
			dialogHeaderScheme4.SubTitleRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			dialogHeaderScheme4.TitleColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			dialogHeaderScheme4.TitleFont = new System.Drawing.Font( "Verdana" , 12F , System.Drawing.FontStyle.Bold );
			dialogHeaderScheme4.TitleRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			this.dialogHeaderControl.Scheme = dialogHeaderScheme4;
			this.dialogHeaderControl.Size = new System.Drawing.Size( 580 , 50 );
			this.dialogHeaderControl.SubText = "#Details#";
			this.dialogHeaderControl.TabIndex = 21;
			this.dialogHeaderControl.TabStop = false;
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cancelButton.Caption = "Annuleren";
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point( 327 , 262 );
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Picture = null;
			this.cancelButton.Renderer = buttonRenderer10;
			buttonScheme37.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			buttonScheme37.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			buttonScheme37.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme37.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			buttonScheme37.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			buttonScheme37.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat37.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat37.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat37.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat37.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme37.CaptionFormat = stringFormat37;
			buttonScheme37.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme37.GreenButton = false;
			buttonScheme37.RedButton = false;
			this.cancelButton.SchemeDisabled = buttonScheme37;
			buttonScheme38.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 251 ) ) ) ) , ( (int)( ( (byte)( 253 ) ) ) ) );
			buttonScheme38.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 213 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) , ( (int)( ( (byte)( 252 ) ) ) ) );
			buttonScheme38.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme38.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme38.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme38.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat38.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat38.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat38.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat38.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme38.CaptionFormat = stringFormat38;
			buttonScheme38.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme38.GreenButton = false;
			buttonScheme38.RedButton = false;
			this.cancelButton.SchemeHovered = buttonScheme38;
			buttonScheme39.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			buttonScheme39.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			buttonScheme39.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme39.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme39.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme39.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat39.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat39.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat39.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat39.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme39.CaptionFormat = stringFormat39;
			buttonScheme39.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme39.GreenButton = false;
			buttonScheme39.RedButton = false;
			this.cancelButton.SchemeNormal = buttonScheme39;
			buttonScheme40.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 214 ) ) ) ) , ( (int)( ( (byte)( 214 ) ) ) ) , ( (int)( ( (byte)( 214 ) ) ) ) );
			buttonScheme40.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) );
			buttonScheme40.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme40.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme40.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme40.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat40.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat40.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat40.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat40.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme40.CaptionFormat = stringFormat40;
			buttonScheme40.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme40.GreenButton = false;
			buttonScheme40.RedButton = false;
			this.cancelButton.SchemePushed = buttonScheme40;
			this.cancelButton.Size = new System.Drawing.Size( 120 , 25 );
			this.cancelButton.State = SwmSuite.Presentation.Common.ButtonState.Normal;
			this.cancelButton.TabIndex = 30;
			// 
			// okButton
			// 
			this.okButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.okButton.Caption = "Accepteren";
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point( 453 , 262 );
			this.okButton.Name = "okButton";
			this.okButton.Picture = null;
			this.okButton.Renderer = buttonRenderer11;
			buttonScheme41.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			buttonScheme41.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			buttonScheme41.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme41.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			buttonScheme41.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			buttonScheme41.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat41.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat41.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat41.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat41.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme41.CaptionFormat = stringFormat41;
			buttonScheme41.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme41.GreenButton = false;
			buttonScheme41.RedButton = false;
			this.okButton.SchemeDisabled = buttonScheme41;
			buttonScheme42.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 251 ) ) ) ) , ( (int)( ( (byte)( 253 ) ) ) ) );
			buttonScheme42.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 213 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) , ( (int)( ( (byte)( 252 ) ) ) ) );
			buttonScheme42.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme42.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme42.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme42.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat42.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat42.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat42.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat42.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme42.CaptionFormat = stringFormat42;
			buttonScheme42.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme42.GreenButton = false;
			buttonScheme42.RedButton = false;
			this.okButton.SchemeHovered = buttonScheme42;
			buttonScheme43.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			buttonScheme43.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			buttonScheme43.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme43.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme43.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme43.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat43.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat43.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat43.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat43.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme43.CaptionFormat = stringFormat43;
			buttonScheme43.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme43.GreenButton = false;
			buttonScheme43.RedButton = false;
			this.okButton.SchemeNormal = buttonScheme43;
			buttonScheme44.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 214 ) ) ) ) , ( (int)( ( (byte)( 214 ) ) ) ) , ( (int)( ( (byte)( 214 ) ) ) ) );
			buttonScheme44.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) );
			buttonScheme44.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme44.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme44.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme44.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat44.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat44.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat44.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat44.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme44.CaptionFormat = stringFormat44;
			buttonScheme44.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme44.GreenButton = false;
			buttonScheme44.RedButton = false;
			this.okButton.SchemePushed = buttonScheme44;
			this.okButton.Size = new System.Drawing.Size( 120 , 25 );
			this.okButton.State = SwmSuite.Presentation.Common.ButtonState.Normal;
			this.okButton.TabIndex = 29;
			this.okButton.Click += new System.EventHandler( this.okButton_Click );
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.label1.Location = new System.Drawing.Point( 8 , 64 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 118 , 17 );
			this.label1.TabIndex = 33;
			this.label1.Text = "Opdrachtgever:";
			// 
			// browseForEmployeeButton
			// 
			this.browseForEmployeeButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.browseForEmployeeButton.Caption = "...";
			this.browseForEmployeeButton.Location = new System.Drawing.Point( 503 , 61 );
			this.browseForEmployeeButton.Name = "browseForEmployeeButton";
			this.browseForEmployeeButton.Picture = null;
			this.browseForEmployeeButton.Renderer = buttonRenderer12;
			buttonScheme45.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			buttonScheme45.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			buttonScheme45.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme45.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			buttonScheme45.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			buttonScheme45.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat45.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat45.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat45.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat45.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme45.CaptionFormat = stringFormat45;
			buttonScheme45.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme45.GreenButton = false;
			buttonScheme45.RedButton = false;
			this.browseForEmployeeButton.SchemeDisabled = buttonScheme45;
			buttonScheme46.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 251 ) ) ) ) , ( (int)( ( (byte)( 253 ) ) ) ) );
			buttonScheme46.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 213 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) , ( (int)( ( (byte)( 252 ) ) ) ) );
			buttonScheme46.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme46.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme46.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme46.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat46.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat46.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat46.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat46.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme46.CaptionFormat = stringFormat46;
			buttonScheme46.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme46.GreenButton = false;
			buttonScheme46.RedButton = false;
			this.browseForEmployeeButton.SchemeHovered = buttonScheme46;
			buttonScheme47.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			buttonScheme47.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			buttonScheme47.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme47.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme47.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme47.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat47.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat47.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat47.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat47.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme47.CaptionFormat = stringFormat47;
			buttonScheme47.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme47.GreenButton = false;
			buttonScheme47.RedButton = false;
			this.browseForEmployeeButton.SchemeNormal = buttonScheme47;
			buttonScheme48.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 214 ) ) ) ) , ( (int)( ( (byte)( 214 ) ) ) ) , ( (int)( ( (byte)( 214 ) ) ) ) );
			buttonScheme48.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) );
			buttonScheme48.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme48.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme48.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme48.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat48.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat48.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat48.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat48.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme48.CaptionFormat = stringFormat48;
			buttonScheme48.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme48.GreenButton = false;
			buttonScheme48.RedButton = false;
			this.browseForEmployeeButton.SchemePushed = buttonScheme48;
			this.browseForEmployeeButton.Size = new System.Drawing.Size( 65 , 22 );
			this.browseForEmployeeButton.State = SwmSuite.Presentation.Common.ButtonState.Normal;
			this.browseForEmployeeButton.TabIndex = 31;
			this.browseForEmployeeButton.Text = "...";
			this.browseForEmployeeButton.UseVisualStyleBackColor = true;
			this.browseForEmployeeButton.Click += new System.EventHandler( this.browseForEmployeeButton_Click );
			// 
			// commissionerTextBox
			// 
			this.commissionerTextBox.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.commissionerTextBox.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.commissionerTextBox.BorderColorFocused = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 160 ) ) ) ) , ( (int)( ( (byte)( 17 ) ) ) ) );
			this.commissionerTextBox.BorderColorHovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 153 ) ) ) ) , ( (int)( ( (byte)( 207 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			this.commissionerTextBox.BorderColorNormal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 125 ) ) ) ) , ( (int)( ( (byte)( 170 ) ) ) ) , ( (int)( ( (byte)( 210 ) ) ) ) );
			// 
			// 
			// 
			this.commissionerTextBox.Client.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.commissionerTextBox.Client.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.commissionerTextBox.Client.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.commissionerTextBox.Client.Location = new System.Drawing.Point( 4 , 2 );
			this.commissionerTextBox.Client.Name = "textbox";
			this.commissionerTextBox.Client.ReadOnly = true;
			this.commissionerTextBox.Client.Size = new System.Drawing.Size( 356 , 16 );
			this.commissionerTextBox.Client.TabIndex = 0;
			this.commissionerTextBox.ContentsDisableColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) );
			this.commissionerTextBox.ContentsErrorColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 232 ) ) ) ) );
			this.commissionerTextBox.ContentsOkColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.commissionerTextBox.Location = new System.Drawing.Point( 132 , 61 );
			this.commissionerTextBox.Name = "commissionerTextBox";
			this.commissionerTextBox.Size = new System.Drawing.Size( 365 , 22 );
			this.commissionerTextBox.TabIndex = 32;
			this.commissionerTextBox.TabStop = false;
			this.commissionerTextBox.TextChanged += new System.EventHandler<System.EventArgs>( this.commissionerTextBox_TextChanged );
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.label2.Location = new System.Drawing.Point( 65 , 99 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 61 , 17 );
			this.label2.TabIndex = 34;
			this.label2.Text = "Datum:";
			// 
			// beginTimePicker
			// 
			this.beginTimePicker.CalendarFont = new System.Drawing.Font( "Verdana" , 10F );
			this.beginTimePicker.CustomFormat = "HH:mm";
			this.beginTimePicker.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.beginTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.beginTimePicker.Location = new System.Drawing.Point( 132 , 134 );
			this.beginTimePicker.Name = "beginTimePicker";
			this.beginTimePicker.ShowUpDown = true;
			this.beginTimePicker.Size = new System.Drawing.Size( 80 , 24 );
			this.beginTimePicker.TabIndex = 35;
			this.beginTimePicker.ValueChanged += new System.EventHandler( this.beginTimePicker_ValueChanged );
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.label3.Location = new System.Drawing.Point( 85 , 137 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 41 , 17 );
			this.label3.TabIndex = 37;
			this.label3.Text = "Van:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.label4.Location = new System.Drawing.Point( 245 , 138 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 38 , 17 );
			this.label4.TabIndex = 39;
			this.label4.Text = "Tot:";
			// 
			// endTimePicker
			// 
			this.endTimePicker.CalendarFont = new System.Drawing.Font( "Verdana" , 10F );
			this.endTimePicker.CustomFormat = "HH:mm";
			this.endTimePicker.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.endTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.endTimePicker.Location = new System.Drawing.Point( 289 , 134 );
			this.endTimePicker.Name = "endTimePicker";
			this.endTimePicker.ShowUpDown = true;
			this.endTimePicker.Size = new System.Drawing.Size( 80 , 24 );
			this.endTimePicker.TabIndex = 38;
			this.endTimePicker.ValueChanged += new System.EventHandler( this.endTimePicker_ValueChanged );
			// 
			// dateTimePicker
			// 
			this.dateTimePicker.CalendarFont = new System.Drawing.Font( "Verdana" , 10F );
			this.dateTimePicker.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.dateTimePicker.Location = new System.Drawing.Point( 132 , 95 );
			this.dateTimePicker.Name = "dateTimePicker";
			this.dateTimePicker.Size = new System.Drawing.Size( 296 , 24 );
			this.dateTimePicker.TabIndex = 40;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.label5.Location = new System.Drawing.Point( 19 , 171 );
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size( 107 , 17 );
			this.label5.TabIndex = 42;
			this.label5.Text = "Opmerkingen:";
			// 
			// descriptionTextBox
			// 
			this.descriptionTextBox.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.descriptionTextBox.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.descriptionTextBox.BorderColorFocused = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 160 ) ) ) ) , ( (int)( ( (byte)( 17 ) ) ) ) );
			this.descriptionTextBox.BorderColorHovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 153 ) ) ) ) , ( (int)( ( (byte)( 207 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			this.descriptionTextBox.BorderColorNormal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 125 ) ) ) ) , ( (int)( ( (byte)( 170 ) ) ) ) , ( (int)( ( (byte)( 210 ) ) ) ) );
			// 
			// 
			// 
			this.descriptionTextBox.Client.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.descriptionTextBox.Client.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.descriptionTextBox.Client.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.descriptionTextBox.Client.Location = new System.Drawing.Point( 4 , 2 );
			this.descriptionTextBox.Client.Multiline = true;
			this.descriptionTextBox.Client.Name = "textbox";
			this.descriptionTextBox.Client.Size = new System.Drawing.Size( 427 , 82 );
			this.descriptionTextBox.Client.TabIndex = 0;
			this.descriptionTextBox.ContentsDisableColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) );
			this.descriptionTextBox.ContentsErrorColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 232 ) ) ) ) );
			this.descriptionTextBox.ContentsOkColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.descriptionTextBox.Location = new System.Drawing.Point( 132 , 169 );
			this.descriptionTextBox.Name = "descriptionTextBox";
			this.descriptionTextBox.Size = new System.Drawing.Size( 436 , 87 );
			this.descriptionTextBox.TabIndex = 41;
			this.descriptionTextBox.TabStop = false;
			this.descriptionTextBox.TextChanged += new System.EventHandler<System.EventArgs>( this.descriptionTextBox_TextChanged );
			// 
			// OvertimeEntryDetailDialog
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size( 580 , 294 );
			this.Controls.Add( this.label5 );
			this.Controls.Add( this.descriptionTextBox );
			this.Controls.Add( this.dateTimePicker );
			this.Controls.Add( this.label4 );
			this.Controls.Add( this.endTimePicker );
			this.Controls.Add( this.label3 );
			this.Controls.Add( this.beginTimePicker );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.browseForEmployeeButton );
			this.Controls.Add( this.commissionerTextBox );
			this.Controls.Add( this.cancelButton );
			this.Controls.Add( this.okButton );
			this.Controls.Add( this.dialogHeaderControl );
			this.Name = "OvertimeEntryDetailDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Simple Workfloor Management Suite";
			this.Load += new System.EventHandler( this.NewOvertimeEntryDialog_Load );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private SwmSuite.Presentation.Common.DialogHeader.DialogHeaderControl dialogHeaderControl;
		private SwmSuite.Presentation.Common.ButtonControl cancelButton;
		private SwmSuite.Presentation.Common.ButtonControl okButton;
		private System.Windows.Forms.Label label1;
		private SwmSuite.Presentation.Common.ButtonControl browseForEmployeeButton;
		private SwmSuite.Presentation.Common.NiceTextBox.NiceTextBoxControl commissionerTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker beginTimePicker;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker endTimePicker;
		private System.Windows.Forms.DateTimePicker dateTimePicker;
		private System.Windows.Forms.Label label5;
		private SwmSuite.Presentation.Common.NiceTextBox.NiceTextBoxControl descriptionTextBox;
	}
}