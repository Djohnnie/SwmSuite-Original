namespace SimpleWorkfloorManagementSuite.Dialogs {
	partial class LogoutNotificationDialog {
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
			this.timer = new System.Windows.Forms.Timer( this.components );
			this.dialogHeaderControl = new SwmSuite.Presentation.Common.DialogHeader.DialogHeaderControl();
			this.cancelButton = new SwmSuite.Presentation.Common.ButtonControl();
			this.okButton = new SwmSuite.Presentation.Common.ButtonControl();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// timer
			// 
			this.timer.Interval = 1000;
			this.timer.Tick += new System.EventHandler( this.timer_Tick );
			// 
			// dialogHeaderControl
			// 
			this.dialogHeaderControl.Dock = System.Windows.Forms.DockStyle.Top;
			this.dialogHeaderControl.Location = new System.Drawing.Point( 0 , 0 );
			this.dialogHeaderControl.MainText = "Afmelden";
			this.dialogHeaderControl.Name = "dialogHeaderControl";
			this.dialogHeaderControl.OnlyMainText = true;
			this.dialogHeaderControl.Renderer = dialogHeaderRenderer1;
			dialogHeaderScheme1.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 10 ) ) ) ) , ( (int)( ( (byte)( 75 ) ) ) ) , ( (int)( ( (byte)( 115 ) ) ) ) );
			dialogHeaderScheme1.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 50 ) ) ) ) , ( (int)( ( (byte)( 175 ) ) ) ) , ( (int)( ( (byte)( 175 ) ) ) ) );
			dialogHeaderScheme1.SubTitleColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			dialogHeaderScheme1.SubTitleFont = new System.Drawing.Font( "Verdana" , 10F );
			dialogHeaderScheme1.SubTitleRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			dialogHeaderScheme1.TitleColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			dialogHeaderScheme1.TitleFont = new System.Drawing.Font( "Verdana" , 12F , System.Drawing.FontStyle.Bold );
			dialogHeaderScheme1.TitleRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			this.dialogHeaderControl.Scheme = dialogHeaderScheme1;
			this.dialogHeaderControl.Size = new System.Drawing.Size( 423 , 30 );
			this.dialogHeaderControl.SubText = "#Details#";
			this.dialogHeaderControl.TabIndex = 1;
			this.dialogHeaderControl.TabStop = false;
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cancelButton.Caption = "Annuleren";
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point( 210 , 109 );
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Picture = null;
			this.cancelButton.Renderer = buttonRenderer1;
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
			this.cancelButton.SchemeDisabled = buttonScheme1;
			buttonScheme2.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 235 ) ) ) ) , ( (int)( ( (byte)( 235 ) ) ) ) );
			buttonScheme2.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 215 ) ) ) ) , ( (int)( ( (byte)( 215 ) ) ) ) );
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
			this.cancelButton.SchemeHovered = buttonScheme2;
			buttonScheme3.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			buttonScheme3.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 235 ) ) ) ) , ( (int)( ( (byte)( 235 ) ) ) ) );
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
			this.cancelButton.SchemePushed = buttonScheme4;
			this.cancelButton.Size = new System.Drawing.Size( 100 , 25 );
			this.cancelButton.State = SwmSuite.Presentation.Common.ButtonState.Normal;
			this.cancelButton.TabIndex = 7;
			// 
			// okButton
			// 
			this.okButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.okButton.Caption = "Afmelden";
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point( 316 , 109 );
			this.okButton.Name = "okButton";
			this.okButton.Picture = null;
			this.okButton.Renderer = buttonRenderer2;
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
			this.okButton.SchemeDisabled = buttonScheme5;
			buttonScheme6.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 235 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 235 ) ) ) ) );
			buttonScheme6.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 215 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 215 ) ) ) ) );
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
			this.okButton.SchemeHovered = buttonScheme6;
			buttonScheme7.BackgroundColor1 = System.Drawing.Color.White;
			buttonScheme7.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 235 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 235 ) ) ) ) );
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
			this.okButton.SchemePushed = buttonScheme8;
			this.okButton.Size = new System.Drawing.Size( 100 , 25 );
			this.okButton.State = SwmSuite.Presentation.Common.ButtonState.Normal;
			this.okButton.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
									| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.label1.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.label1.Location = new System.Drawing.Point( 12 , 39 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 404 , 25 );
			this.label1.TabIndex = 8;
			this.label1.Text = "Bent u zeker dat u wens af te melden?";
			// 
			// label2
			// 
			this.label2.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
									| System.Windows.Forms.AnchorStyles.Left )
									| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.label2.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.label2.Location = new System.Drawing.Point( 12 , 64 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 404 , 42 );
			this.label2.TabIndex = 9;
			// 
			// LogoutNotificationDialog
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size( 423 , 141 );
			this.ControlBox = false;
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.cancelButton );
			this.Controls.Add( this.okButton );
			this.Controls.Add( this.dialogHeaderControl );
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LogoutNotificationDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Simple Workfloor Management Suite";
			this.Load += new System.EventHandler( this.LogoutNotificationDialog_Load );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.Timer timer;
		private SwmSuite.Presentation.Common.DialogHeader.DialogHeaderControl dialogHeaderControl;
		private SwmSuite.Presentation.Common.ButtonControl cancelButton;
		private SwmSuite.Presentation.Common.ButtonControl okButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}