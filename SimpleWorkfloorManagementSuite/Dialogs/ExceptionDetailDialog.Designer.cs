namespace SimpleWorkfloorManagementSuite.Dialogs {
	partial class ExceptionDetailDialog {
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
			SwmSuite.Presentation.Common.DialogHeader.DialogHeaderRenderer dialogHeaderRenderer3 = new SwmSuite.Presentation.Common.DialogHeader.DialogHeaderRenderer();
			SwmSuite.Presentation.Common.DialogHeader.DialogHeaderScheme dialogHeaderScheme3 = new SwmSuite.Presentation.Common.DialogHeader.DialogHeaderScheme();
			SwmSuite.Presentation.Common.PopUpButton.PopUpButtonRenderer popUpButtonRenderer5 = new SwmSuite.Presentation.Common.PopUpButton.PopUpButtonRenderer();
			SwmSuite.Presentation.Common.PopUpButton.PopUpButtonScheme popUpButtonScheme17 = new SwmSuite.Presentation.Common.PopUpButton.PopUpButtonScheme();
			System.Drawing.StringFormat stringFormat17 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.PopUpButton.PopUpButtonScheme popUpButtonScheme18 = new SwmSuite.Presentation.Common.PopUpButton.PopUpButtonScheme();
			System.Drawing.StringFormat stringFormat18 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.PopUpButton.PopUpButtonScheme popUpButtonScheme19 = new SwmSuite.Presentation.Common.PopUpButton.PopUpButtonScheme();
			System.Drawing.StringFormat stringFormat19 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.PopUpButton.PopUpButtonScheme popUpButtonScheme20 = new SwmSuite.Presentation.Common.PopUpButton.PopUpButtonScheme();
			System.Drawing.StringFormat stringFormat20 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.PopUpButton.PopUpButtonRenderer popUpButtonRenderer6 = new SwmSuite.Presentation.Common.PopUpButton.PopUpButtonRenderer();
			SwmSuite.Presentation.Common.PopUpButton.PopUpButtonScheme popUpButtonScheme21 = new SwmSuite.Presentation.Common.PopUpButton.PopUpButtonScheme();
			System.Drawing.StringFormat stringFormat21 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.PopUpButton.PopUpButtonScheme popUpButtonScheme22 = new SwmSuite.Presentation.Common.PopUpButton.PopUpButtonScheme();
			System.Drawing.StringFormat stringFormat22 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.PopUpButton.PopUpButtonScheme popUpButtonScheme23 = new SwmSuite.Presentation.Common.PopUpButton.PopUpButtonScheme();
			System.Drawing.StringFormat stringFormat23 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.PopUpButton.PopUpButtonScheme popUpButtonScheme24 = new SwmSuite.Presentation.Common.PopUpButton.PopUpButtonScheme();
			System.Drawing.StringFormat stringFormat24 = new System.Drawing.StringFormat();
			this.dialogHeaderControl = new SwmSuite.Presentation.Common.DialogHeader.DialogHeaderControl();
			this.exceptionTextBox = new SwmSuite.Presentation.Common.NiceTextBox.NiceTextBoxControl();
			this.saveButton = new SwmSuite.Presentation.Common.PopUpButton.PopUpButtonControl();
			this.sendButton = new SwmSuite.Presentation.Common.PopUpButton.PopUpButtonControl();
			this.SuspendLayout();
			// 
			// dialogHeaderControl
			// 
			this.dialogHeaderControl.Dock = System.Windows.Forms.DockStyle.Top;
			this.dialogHeaderControl.Location = new System.Drawing.Point( 0 , 0 );
			this.dialogHeaderControl.MainText = " SwmSuite foutboodschap";
			this.dialogHeaderControl.Name = "dialogHeaderControl";
			this.dialogHeaderControl.OnlyMainText = false;
			this.dialogHeaderControl.Renderer = dialogHeaderRenderer3;
			dialogHeaderScheme3.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 115 ) ) ) ) , ( (int)( ( (byte)( 10 ) ) ) ) , ( (int)( ( (byte)( 10 ) ) ) ) );
			dialogHeaderScheme3.BackgroundColor2 = System.Drawing.Color.Red;
			dialogHeaderScheme3.SubTitleColor = System.Drawing.Color.White;
			dialogHeaderScheme3.SubTitleFont = new System.Drawing.Font( "Verdana" , 10F );
			dialogHeaderScheme3.SubTitleRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			dialogHeaderScheme3.TitleColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			dialogHeaderScheme3.TitleFont = new System.Drawing.Font( "Verdana" , 12F , System.Drawing.FontStyle.Bold );
			dialogHeaderScheme3.TitleRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			this.dialogHeaderControl.Scheme = dialogHeaderScheme3;
			this.dialogHeaderControl.Size = new System.Drawing.Size( 560 , 50 );
			this.dialogHeaderControl.SubText = "  Er heeft zich een onverwachte fout voorgedaan.";
			this.dialogHeaderControl.TabIndex = 11;
			this.dialogHeaderControl.TabStop = false;
			// 
			// exceptionTextBox
			// 
			this.exceptionTextBox.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
									| System.Windows.Forms.AnchorStyles.Left )
									| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.exceptionTextBox.BackColor = System.Drawing.Color.White;
			this.exceptionTextBox.BorderColorFocused = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 160 ) ) ) ) , ( (int)( ( (byte)( 17 ) ) ) ) );
			this.exceptionTextBox.BorderColorHovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 153 ) ) ) ) , ( (int)( ( (byte)( 207 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			this.exceptionTextBox.BorderColorNormal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 125 ) ) ) ) , ( (int)( ( (byte)( 170 ) ) ) ) , ( (int)( ( (byte)( 210 ) ) ) ) );
			// 
			// 
			// 
			this.exceptionTextBox.Client.AcceptsReturn = true;
			this.exceptionTextBox.Client.AcceptsTab = true;
			this.exceptionTextBox.Client.BackColor = System.Drawing.Color.White;
			this.exceptionTextBox.Client.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.exceptionTextBox.Client.Location = new System.Drawing.Point( 4 , 2 );
			this.exceptionTextBox.Client.Multiline = true;
			this.exceptionTextBox.Client.Name = "textbox";
			this.exceptionTextBox.Client.ReadOnly = true;
			this.exceptionTextBox.Client.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.exceptionTextBox.Client.Size = new System.Drawing.Size( 498 , 269 );
			this.exceptionTextBox.Client.TabIndex = 0;
			this.exceptionTextBox.Client.WordWrap = false;
			this.exceptionTextBox.ContentsErrorColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 232 ) ) ) ) );
			this.exceptionTextBox.ContentsOkColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.exceptionTextBox.Location = new System.Drawing.Point( 27 , 74 );
			this.exceptionTextBox.Name = "exceptionTextBox";
			this.exceptionTextBox.Size = new System.Drawing.Size( 507 , 274 );
			this.exceptionTextBox.TabIndex = 12;
			// 
			// saveButton
			// 
			this.saveButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left )
									| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.saveButton.Caption = "Opslaan";
			this.saveButton.Location = new System.Drawing.Point( 12 , 366 );
			this.saveButton.Name = "saveButton";
			this.saveButton.Picture = null;
			this.saveButton.Renderer = popUpButtonRenderer5;
			popUpButtonScheme17.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			popUpButtonScheme17.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			popUpButtonScheme17.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			popUpButtonScheme17.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			popUpButtonScheme17.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			popUpButtonScheme17.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat17.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat17.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat17.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat17.Trimming = System.Drawing.StringTrimming.Character;
			popUpButtonScheme17.CaptionFormat = stringFormat17;
			popUpButtonScheme17.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			popUpButtonScheme17.SubCaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			popUpButtonScheme17.SubCaptionFont = new System.Drawing.Font( "Verdana" , 8F );
			this.saveButton.SchemeDisabled = popUpButtonScheme17;
			popUpButtonScheme18.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 251 ) ) ) ) , ( (int)( ( (byte)( 253 ) ) ) ) );
			popUpButtonScheme18.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 213 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) , ( (int)( ( (byte)( 252 ) ) ) ) );
			popUpButtonScheme18.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			popUpButtonScheme18.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			popUpButtonScheme18.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			popUpButtonScheme18.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat18.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat18.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat18.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat18.Trimming = System.Drawing.StringTrimming.Character;
			popUpButtonScheme18.CaptionFormat = stringFormat18;
			popUpButtonScheme18.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			popUpButtonScheme18.SubCaptionColor = System.Drawing.Color.Gray;
			popUpButtonScheme18.SubCaptionFont = new System.Drawing.Font( "Verdana" , 8F );
			this.saveButton.SchemeHovered = popUpButtonScheme18;
			popUpButtonScheme19.BackgroundColor1 = System.Drawing.Color.White;
			popUpButtonScheme19.BackgroundColor2 = System.Drawing.Color.White;
			popUpButtonScheme19.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			popUpButtonScheme19.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 224 ) ) ) ) , ( (int)( ( (byte)( 224 ) ) ) ) , ( (int)( ( (byte)( 224 ) ) ) ) );
			popUpButtonScheme19.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			popUpButtonScheme19.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat19.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat19.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat19.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat19.Trimming = System.Drawing.StringTrimming.Character;
			popUpButtonScheme19.CaptionFormat = stringFormat19;
			popUpButtonScheme19.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			popUpButtonScheme19.SubCaptionColor = System.Drawing.Color.Gray;
			popUpButtonScheme19.SubCaptionFont = new System.Drawing.Font( "Verdana" , 8F );
			this.saveButton.SchemeNormal = popUpButtonScheme19;
			popUpButtonScheme20.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 214 ) ) ) ) , ( (int)( ( (byte)( 214 ) ) ) ) , ( (int)( ( (byte)( 214 ) ) ) ) );
			popUpButtonScheme20.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) );
			popUpButtonScheme20.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			popUpButtonScheme20.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			popUpButtonScheme20.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			popUpButtonScheme20.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat20.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat20.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat20.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat20.Trimming = System.Drawing.StringTrimming.Character;
			popUpButtonScheme20.CaptionFormat = stringFormat20;
			popUpButtonScheme20.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			popUpButtonScheme20.SubCaptionColor = System.Drawing.Color.Gray;
			popUpButtonScheme20.SubCaptionFont = new System.Drawing.Font( "Verdana" , 8F );
			this.saveButton.SchemePushed = popUpButtonScheme20;
			this.saveButton.Size = new System.Drawing.Size( 263 , 67 );
			this.saveButton.State = SwmSuite.Presentation.Common.PopUpButton.PopUpButtonState.Normal;
			this.saveButton.SubCaption = "Informatie over de fout opslaan op de schijf.";
			this.saveButton.TabIndex = 15;
			this.saveButton.Text = "popUpButtonControl1";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler( this.saveButton_Click );
			// 
			// sendButton
			// 
			this.sendButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left )
									| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.sendButton.Caption = "Opsturen";
			this.sendButton.Location = new System.Drawing.Point( 285 , 366 );
			this.sendButton.Name = "sendButton";
			this.sendButton.Picture = null;
			this.sendButton.Renderer = popUpButtonRenderer6;
			popUpButtonScheme21.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			popUpButtonScheme21.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			popUpButtonScheme21.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			popUpButtonScheme21.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			popUpButtonScheme21.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			popUpButtonScheme21.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat21.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat21.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat21.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat21.Trimming = System.Drawing.StringTrimming.Character;
			popUpButtonScheme21.CaptionFormat = stringFormat21;
			popUpButtonScheme21.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			popUpButtonScheme21.SubCaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			popUpButtonScheme21.SubCaptionFont = new System.Drawing.Font( "Verdana" , 8F );
			this.sendButton.SchemeDisabled = popUpButtonScheme21;
			popUpButtonScheme22.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 251 ) ) ) ) , ( (int)( ( (byte)( 253 ) ) ) ) );
			popUpButtonScheme22.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 213 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) , ( (int)( ( (byte)( 252 ) ) ) ) );
			popUpButtonScheme22.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			popUpButtonScheme22.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			popUpButtonScheme22.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			popUpButtonScheme22.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat22.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat22.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat22.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat22.Trimming = System.Drawing.StringTrimming.Character;
			popUpButtonScheme22.CaptionFormat = stringFormat22;
			popUpButtonScheme22.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			popUpButtonScheme22.SubCaptionColor = System.Drawing.Color.Gray;
			popUpButtonScheme22.SubCaptionFont = new System.Drawing.Font( "Verdana" , 8F );
			this.sendButton.SchemeHovered = popUpButtonScheme22;
			popUpButtonScheme23.BackgroundColor1 = System.Drawing.Color.White;
			popUpButtonScheme23.BackgroundColor2 = System.Drawing.Color.White;
			popUpButtonScheme23.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			popUpButtonScheme23.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 224 ) ) ) ) , ( (int)( ( (byte)( 224 ) ) ) ) , ( (int)( ( (byte)( 224 ) ) ) ) );
			popUpButtonScheme23.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			popUpButtonScheme23.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat23.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat23.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat23.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat23.Trimming = System.Drawing.StringTrimming.Character;
			popUpButtonScheme23.CaptionFormat = stringFormat23;
			popUpButtonScheme23.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			popUpButtonScheme23.SubCaptionColor = System.Drawing.Color.Gray;
			popUpButtonScheme23.SubCaptionFont = new System.Drawing.Font( "Verdana" , 8F );
			this.sendButton.SchemeNormal = popUpButtonScheme23;
			popUpButtonScheme24.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 214 ) ) ) ) , ( (int)( ( (byte)( 214 ) ) ) ) , ( (int)( ( (byte)( 214 ) ) ) ) );
			popUpButtonScheme24.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) );
			popUpButtonScheme24.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			popUpButtonScheme24.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			popUpButtonScheme24.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			popUpButtonScheme24.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat24.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat24.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat24.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat24.Trimming = System.Drawing.StringTrimming.Character;
			popUpButtonScheme24.CaptionFormat = stringFormat24;
			popUpButtonScheme24.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			popUpButtonScheme24.SubCaptionColor = System.Drawing.Color.Gray;
			popUpButtonScheme24.SubCaptionFont = new System.Drawing.Font( "Verdana" , 8F );
			this.sendButton.SchemePushed = popUpButtonScheme24;
			this.sendButton.Size = new System.Drawing.Size( 263 , 67 );
			this.sendButton.State = SwmSuite.Presentation.Common.PopUpButton.PopUpButtonState.Normal;
			this.sendButton.SubCaption = "Informatie over de fout opsturen naar de ontwikkelaar.";
			this.sendButton.TabIndex = 16;
			this.sendButton.Text = "popUpButtonControl1";
			this.sendButton.UseVisualStyleBackColor = true;
			this.sendButton.Click += new System.EventHandler( this.sendButton_Click );
			// 
			// ExceptionDetailDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size( 560 , 445 );
			this.ControlBox = false;
			this.Controls.Add( this.sendButton );
			this.Controls.Add( this.saveButton );
			this.Controls.Add( this.exceptionTextBox );
			this.Controls.Add( this.dialogHeaderControl );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ExceptionDetailDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Simple Workfloor Management Suite";
			this.Load += new System.EventHandler( this.ExceptionDetailDialog_Load );
			this.ResumeLayout( false );

		}

		#endregion

		private SwmSuite.Presentation.Common.DialogHeader.DialogHeaderControl dialogHeaderControl;
		private SwmSuite.Presentation.Common.NiceTextBox.NiceTextBoxControl exceptionTextBox;
		private SwmSuite.Presentation.Common.PopUpButton.PopUpButtonControl saveButton;
		private SwmSuite.Presentation.Common.PopUpButton.PopUpButtonControl sendButton;
	}
}