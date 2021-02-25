namespace SimpleWorkfloorManagementSuite.Dialogs {
	partial class TaskRunDetailDialog {
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
			SwmSuite.Presentation.Common.ButtonRenderer buttonRenderer7 = new SwmSuite.Presentation.Common.ButtonRenderer();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme25 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat25 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme26 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat26 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme27 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat27 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme28 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat28 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonRenderer buttonRenderer8 = new SwmSuite.Presentation.Common.ButtonRenderer();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme29 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat29 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme30 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat30 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme31 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat31 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme32 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat32 = new System.Drawing.StringFormat();
			this.dialogHeaderControl = new SwmSuite.Presentation.Common.DialogHeader.DialogHeaderControl();
			this.timePicker = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.monthCalendar = new System.Windows.Forms.MonthCalendar();
			this.remarksTextBox = new SwmSuite.Presentation.Common.NiceTextBox.NiceTextBoxControl();
			this.cancelButton = new SwmSuite.Presentation.Common.ButtonControl();
			this.okButton = new SwmSuite.Presentation.Common.ButtonControl();
			this.taskSuccesfullRadioButton = new System.Windows.Forms.RadioButton();
			this.taskFailedRadioButton = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// dialogHeaderControl
			// 
			this.dialogHeaderControl.Dock = System.Windows.Forms.DockStyle.Top;
			this.dialogHeaderControl.Location = new System.Drawing.Point( 0 , 0 );
			this.dialogHeaderControl.MainText = "  Taak afpunten";
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
			this.dialogHeaderControl.Size = new System.Drawing.Size( 746 , 50 );
			this.dialogHeaderControl.SubText = "#Details#";
			this.dialogHeaderControl.TabIndex = 30;
			this.dialogHeaderControl.TabStop = false;
			// 
			// timePicker
			// 
			this.timePicker.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.timePicker.Location = new System.Drawing.Point( 18 , 241 );
			this.timePicker.Name = "timePicker";
			this.timePicker.ShowUpDown = true;
			this.timePicker.Size = new System.Drawing.Size( 193 , 24 );
			this.timePicker.TabIndex = 46;
			this.timePicker.Value = new System.DateTime( 2009 , 3 , 27 , 0 , 0 , 0 , 0 );
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.label3.Location = new System.Drawing.Point( 223 , 67 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 101 , 17 );
			this.label3.TabIndex = 45;
			this.label3.Text = "Opmerkingen";
			// 
			// monthCalendar
			// 
			this.monthCalendar.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.monthCalendar.Location = new System.Drawing.Point( 18 , 67 );
			this.monthCalendar.MaxSelectionCount = 1;
			this.monthCalendar.Name = "monthCalendar";
			this.monthCalendar.ShowWeekNumbers = true;
			this.monthCalendar.TabIndex = 44;
			// 
			// remarksTextBox
			// 
			this.remarksTextBox.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.remarksTextBox.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.remarksTextBox.BorderColorFocused = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 160 ) ) ) ) , ( (int)( ( (byte)( 17 ) ) ) ) );
			this.remarksTextBox.BorderColorHovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 153 ) ) ) ) , ( (int)( ( (byte)( 207 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			this.remarksTextBox.BorderColorNormal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 125 ) ) ) ) , ( (int)( ( (byte)( 170 ) ) ) ) , ( (int)( ( (byte)( 210 ) ) ) ) );
			// 
			// 
			// 
			this.remarksTextBox.Client.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.remarksTextBox.Client.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.remarksTextBox.Client.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.remarksTextBox.Client.Location = new System.Drawing.Point( 4 , 2 );
			this.remarksTextBox.Client.Multiline = true;
			this.remarksTextBox.Client.Name = "textbox";
			this.remarksTextBox.Client.Size = new System.Drawing.Size( 489 , 106 );
			this.remarksTextBox.Client.TabIndex = 0;
			this.remarksTextBox.ContentsDisableColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) );
			this.remarksTextBox.ContentsErrorColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 232 ) ) ) ) );
			this.remarksTextBox.ContentsOkColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.remarksTextBox.Location = new System.Drawing.Point( 226 , 87 );
			this.remarksTextBox.Name = "remarksTextBox";
			this.remarksTextBox.Size = new System.Drawing.Size( 498 , 111 );
			this.remarksTextBox.TabIndex = 43;
			this.remarksTextBox.TextChanged += new System.EventHandler<System.EventArgs>( this.remarksTextBox_TextChanged );
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cancelButton.Caption = "Annuleren";
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point( 488 , 239 );
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Picture = null;
			this.cancelButton.Renderer = buttonRenderer7;
			buttonScheme25.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			buttonScheme25.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			buttonScheme25.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme25.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			buttonScheme25.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			buttonScheme25.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat25.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat25.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat25.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat25.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme25.CaptionFormat = stringFormat25;
			buttonScheme25.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme25.GreenButton = false;
			buttonScheme25.RedButton = false;
			this.cancelButton.SchemeDisabled = buttonScheme25;
			buttonScheme26.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 251 ) ) ) ) , ( (int)( ( (byte)( 253 ) ) ) ) );
			buttonScheme26.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 213 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) , ( (int)( ( (byte)( 252 ) ) ) ) );
			buttonScheme26.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme26.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme26.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme26.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat26.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat26.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat26.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat26.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme26.CaptionFormat = stringFormat26;
			buttonScheme26.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme26.GreenButton = false;
			buttonScheme26.RedButton = false;
			this.cancelButton.SchemeHovered = buttonScheme26;
			buttonScheme27.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			buttonScheme27.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			buttonScheme27.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme27.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme27.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme27.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat27.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat27.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat27.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat27.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme27.CaptionFormat = stringFormat27;
			buttonScheme27.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme27.GreenButton = false;
			buttonScheme27.RedButton = false;
			this.cancelButton.SchemeNormal = buttonScheme27;
			buttonScheme28.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 214 ) ) ) ) , ( (int)( ( (byte)( 214 ) ) ) ) , ( (int)( ( (byte)( 214 ) ) ) ) );
			buttonScheme28.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) );
			buttonScheme28.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme28.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme28.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme28.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat28.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat28.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat28.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat28.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme28.CaptionFormat = stringFormat28;
			buttonScheme28.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme28.GreenButton = false;
			buttonScheme28.RedButton = false;
			this.cancelButton.SchemePushed = buttonScheme28;
			this.cancelButton.Size = new System.Drawing.Size( 120 , 25 );
			this.cancelButton.State = SwmSuite.Presentation.Common.ButtonState.Normal;
			this.cancelButton.TabIndex = 42;
			// 
			// okButton
			// 
			this.okButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.okButton.Caption = "Accepteren";
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point( 614 , 239 );
			this.okButton.Name = "okButton";
			this.okButton.Picture = null;
			this.okButton.Renderer = buttonRenderer8;
			buttonScheme29.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			buttonScheme29.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			buttonScheme29.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme29.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			buttonScheme29.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			buttonScheme29.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat29.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat29.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat29.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat29.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme29.CaptionFormat = stringFormat29;
			buttonScheme29.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme29.GreenButton = false;
			buttonScheme29.RedButton = false;
			this.okButton.SchemeDisabled = buttonScheme29;
			buttonScheme30.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 251 ) ) ) ) , ( (int)( ( (byte)( 253 ) ) ) ) );
			buttonScheme30.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 213 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) , ( (int)( ( (byte)( 252 ) ) ) ) );
			buttonScheme30.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme30.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme30.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme30.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat30.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat30.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat30.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat30.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme30.CaptionFormat = stringFormat30;
			buttonScheme30.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme30.GreenButton = false;
			buttonScheme30.RedButton = false;
			this.okButton.SchemeHovered = buttonScheme30;
			buttonScheme31.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			buttonScheme31.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			buttonScheme31.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme31.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme31.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme31.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat31.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat31.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat31.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat31.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme31.CaptionFormat = stringFormat31;
			buttonScheme31.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme31.GreenButton = false;
			buttonScheme31.RedButton = false;
			this.okButton.SchemeNormal = buttonScheme31;
			buttonScheme32.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 214 ) ) ) ) , ( (int)( ( (byte)( 214 ) ) ) ) , ( (int)( ( (byte)( 214 ) ) ) ) );
			buttonScheme32.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) );
			buttonScheme32.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme32.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme32.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme32.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat32.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat32.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat32.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat32.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme32.CaptionFormat = stringFormat32;
			buttonScheme32.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme32.GreenButton = false;
			buttonScheme32.RedButton = false;
			this.okButton.SchemePushed = buttonScheme32;
			this.okButton.Size = new System.Drawing.Size( 120 , 25 );
			this.okButton.State = SwmSuite.Presentation.Common.ButtonState.Normal;
			this.okButton.TabIndex = 41;
			this.okButton.Click += new System.EventHandler( this.okButton_Click );
			// 
			// taskSuccesfullRadioButton
			// 
			this.taskSuccesfullRadioButton.AutoSize = true;
			this.taskSuccesfullRadioButton.Checked = true;
			this.taskSuccesfullRadioButton.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.taskSuccesfullRadioButton.Location = new System.Drawing.Point( 226 , 214 );
			this.taskSuccesfullRadioButton.Name = "taskSuccesfullRadioButton";
			this.taskSuccesfullRadioButton.Size = new System.Drawing.Size( 199 , 21 );
			this.taskSuccesfullRadioButton.TabIndex = 47;
			this.taskSuccesfullRadioButton.TabStop = true;
			this.taskSuccesfullRadioButton.Text = "Taak succesvol afgerond";
			this.taskSuccesfullRadioButton.UseVisualStyleBackColor = true;
			// 
			// taskFailedRadioButton
			// 
			this.taskFailedRadioButton.AutoSize = true;
			this.taskFailedRadioButton.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.taskFailedRadioButton.Location = new System.Drawing.Point( 226 , 241 );
			this.taskFailedRadioButton.Name = "taskFailedRadioButton";
			this.taskFailedRadioButton.Size = new System.Drawing.Size( 242 , 21 );
			this.taskFailedRadioButton.TabIndex = 48;
			this.taskFailedRadioButton.Text = "Taak niet succesvol uitgevoerd";
			this.taskFailedRadioButton.UseVisualStyleBackColor = true;
			// 
			// TaskRunDetailDialog
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size( 746 , 276 );
			this.Controls.Add( this.taskFailedRadioButton );
			this.Controls.Add( this.taskSuccesfullRadioButton );
			this.Controls.Add( this.timePicker );
			this.Controls.Add( this.label3 );
			this.Controls.Add( this.monthCalendar );
			this.Controls.Add( this.remarksTextBox );
			this.Controls.Add( this.cancelButton );
			this.Controls.Add( this.okButton );
			this.Controls.Add( this.dialogHeaderControl );
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Name = "TaskRunDetailDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Simple Workfloor Management Suite";
			this.Load += new System.EventHandler( this.TaskRunDetailDialog_Load );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private SwmSuite.Presentation.Common.DialogHeader.DialogHeaderControl dialogHeaderControl;
		private System.Windows.Forms.DateTimePicker timePicker;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.MonthCalendar monthCalendar;
		private SwmSuite.Presentation.Common.NiceTextBox.NiceTextBoxControl remarksTextBox;
		private SwmSuite.Presentation.Common.ButtonControl cancelButton;
		private SwmSuite.Presentation.Common.ButtonControl okButton;
		private System.Windows.Forms.RadioButton taskSuccesfullRadioButton;
		private System.Windows.Forms.RadioButton taskFailedRadioButton;
	}
}