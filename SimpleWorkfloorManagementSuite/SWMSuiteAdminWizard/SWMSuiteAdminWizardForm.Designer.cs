namespace SimpleWorkfloorManagementSuite.SwmSuiteAdminWizard {

	partial class SwmSuiteAdminWizardForm {
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
			SwmSuite.Presentation.Common.DialogHeader.DialogHeaderRenderer dialogHeaderRenderer2 = new SwmSuite.Presentation.Common.DialogHeader.DialogHeaderRenderer();
			SwmSuite.Presentation.Common.DialogHeader.DialogHeaderScheme dialogHeaderScheme2 = new SwmSuite.Presentation.Common.DialogHeader.DialogHeaderScheme();
			SwmSuite.Presentation.Common.MirrorText.MirrorTextRenderer mirrorTextRenderer2 = new SwmSuite.Presentation.Common.MirrorText.MirrorTextRenderer();
			SwmSuite.Presentation.Common.MirrorText.MirrorTextScheme mirrorTextScheme2 = new SwmSuite.Presentation.Common.MirrorText.MirrorTextScheme();
			this.wizardBottomPaneControl = new SwmSuite.Presentation.Common.UserControls.WizardBottomPaneControl();
			this.helpButton = new System.Windows.Forms.Button();
			this.previousButton = new System.Windows.Forms.Button();
			this.nextButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.swmSuiteAdminWizardContent5 = new SimpleWorkfloorManagementSuite.SwmSuiteAdminWizard.SwmSuiteAdminWizardContent5();
			this.swmSuiteAdminWizardContent4 = new SimpleWorkfloorManagementSuite.SwmSuiteAdminWizard.SwmSuiteAdminWizardContent4();
			this.swmSuiteAdminWizardContent3 = new SimpleWorkfloorManagementSuite.SwmSuiteAdminWizard.SwmSuiteAdminWizardContent3();
			this.swmSuiteAdminWizardContent2 = new SimpleWorkfloorManagementSuite.SwmSuiteAdminWizard.SwmSuiteAdminWizardContent2();
			this.swmSuiteAdminWizardContent1 = new SimpleWorkfloorManagementSuite.SwmSuiteAdminWizard.SwmSuiteAdminWizardContent1();
			this.dialogHeaderControl1 = new SwmSuite.Presentation.Common.DialogHeader.DialogHeaderControl();
			this.mirrorTextControl1 = new SwmSuite.Presentation.Common.MirrorText.MirrorTextControl();
			this.wizardBottomPaneControl.SuspendLayout();
			this.dialogHeaderControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// wizardBottomPaneControl
			// 
			this.wizardBottomPaneControl.Controls.Add( this.helpButton );
			this.wizardBottomPaneControl.Controls.Add( this.previousButton );
			this.wizardBottomPaneControl.Controls.Add( this.nextButton );
			this.wizardBottomPaneControl.Controls.Add( this.cancelButton );
			this.wizardBottomPaneControl.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.wizardBottomPaneControl.FillColor1 = System.Drawing.Color.Gainsboro;
			this.wizardBottomPaneControl.FillColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) );
			this.wizardBottomPaneControl.Location = new System.Drawing.Point( 0 , 404 );
			this.wizardBottomPaneControl.Name = "wizardBottomPaneControl";
			this.wizardBottomPaneControl.Size = new System.Drawing.Size( 634 , 50 );
			this.wizardBottomPaneControl.TabIndex = 0;
			this.wizardBottomPaneControl.Text = "wizardBottomPaneControl1";
			// 
			// helpButton
			// 
			this.helpButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
			this.helpButton.Location = new System.Drawing.Point( 12 , 12 );
			this.helpButton.Name = "helpButton";
			this.helpButton.Size = new System.Drawing.Size( 100 , 26 );
			this.helpButton.TabIndex = 3;
			this.helpButton.Text = "&Hulp";
			this.helpButton.UseVisualStyleBackColor = true;
			this.helpButton.Click += new System.EventHandler( this.helpButton_Click );
			// 
			// previousButton
			// 
			this.previousButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.previousButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.wizard_left;
			this.previousButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.previousButton.Location = new System.Drawing.Point( 310 , 12 );
			this.previousButton.Name = "previousButton";
			this.previousButton.Size = new System.Drawing.Size( 100 , 26 );
			this.previousButton.TabIndex = 2;
			this.previousButton.Text = "&Vorige";
			this.previousButton.UseVisualStyleBackColor = true;
			this.previousButton.Click += new System.EventHandler( this.previousButton_Click );
			// 
			// nextButton
			// 
			this.nextButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.nextButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.wizard_right;
			this.nextButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.nextButton.Location = new System.Drawing.Point( 416 , 12 );
			this.nextButton.Name = "nextButton";
			this.nextButton.Size = new System.Drawing.Size( 100 , 26 );
			this.nextButton.TabIndex = 1;
			this.nextButton.Text = "&Volgende";
			this.nextButton.UseVisualStyleBackColor = true;
			this.nextButton.Click += new System.EventHandler( this.nextButton_Click );
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cancelButton.Location = new System.Drawing.Point( 522 , 12 );
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size( 100 , 26 );
			this.cancelButton.TabIndex = 0;
			this.cancelButton.Text = "&Annuleren";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler( this.cancelButton_Click );
			// 
			// swmSuiteAdminWizardContent5
			// 
			this.swmSuiteAdminWizardContent5.Administrator = null;
			this.swmSuiteAdminWizardContent5.BackColor = System.Drawing.Color.White;
			this.swmSuiteAdminWizardContent5.Location = new System.Drawing.Point( 12 , 56 );
			this.swmSuiteAdminWizardContent5.Name = "swmSuiteAdminWizardContent5";
			this.swmSuiteAdminWizardContent5.Size = new System.Drawing.Size( 610 , 342 );
			this.swmSuiteAdminWizardContent5.TabIndex = 6;
			this.swmSuiteAdminWizardContent5.Visible = false;
			this.swmSuiteAdminWizardContent5.Completed += new System.EventHandler<System.EventArgs>( this.swmSuiteAdminWizardContent5_Completed );
			// 
			// swmSuiteAdminWizardContent4
			// 
			this.swmSuiteAdminWizardContent4.BackColor = System.Drawing.Color.White;
			this.swmSuiteAdminWizardContent4.Location = new System.Drawing.Point( 12 , 56 );
			this.swmSuiteAdminWizardContent4.Name = "swmSuiteAdminWizardContent4";
			this.swmSuiteAdminWizardContent4.Size = new System.Drawing.Size( 610 , 342 );
			this.swmSuiteAdminWizardContent4.TabIndex = 5;
			this.swmSuiteAdminWizardContent4.Visible = false;
			// 
			// swmSuiteAdminWizardContent3
			// 
			this.swmSuiteAdminWizardContent3.BackColor = System.Drawing.Color.White;
			this.swmSuiteAdminWizardContent3.Location = new System.Drawing.Point( 12 , 56 );
			this.swmSuiteAdminWizardContent3.Name = "swmSuiteAdminWizardContent3";
			this.swmSuiteAdminWizardContent3.Size = new System.Drawing.Size( 610 , 342 );
			this.swmSuiteAdminWizardContent3.TabIndex = 4;
			this.swmSuiteAdminWizardContent3.Visible = false;
			// 
			// swmSuiteAdminWizardContent2
			// 
			this.swmSuiteAdminWizardContent2.BackColor = System.Drawing.Color.White;
			this.swmSuiteAdminWizardContent2.Location = new System.Drawing.Point( 12 , 56 );
			this.swmSuiteAdminWizardContent2.Name = "swmSuiteAdminWizardContent2";
			this.swmSuiteAdminWizardContent2.Size = new System.Drawing.Size( 610 , 342 );
			this.swmSuiteAdminWizardContent2.TabIndex = 3;
			this.swmSuiteAdminWizardContent2.Visible = false;
			// 
			// swmSuiteAdminWizardContent1
			// 
			this.swmSuiteAdminWizardContent1.BackColor = System.Drawing.Color.White;
			this.swmSuiteAdminWizardContent1.CurrentSelection = SimpleWorkfloorManagementSuite.SwmSuiteAdminWizard.SwmSuiteAdminWizardContent1.Selection.None;
			this.swmSuiteAdminWizardContent1.Location = new System.Drawing.Point( 12 , 56 );
			this.swmSuiteAdminWizardContent1.Name = "swmSuiteAdminWizardContent1";
			this.swmSuiteAdminWizardContent1.Size = new System.Drawing.Size( 610 , 342 );
			this.swmSuiteAdminWizardContent1.TabIndex = 2;
			this.swmSuiteAdminWizardContent1.Visible = false;
			// 
			// dialogHeaderControl1
			// 
			this.dialogHeaderControl1.Controls.Add( this.mirrorTextControl1 );
			this.dialogHeaderControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.dialogHeaderControl1.Location = new System.Drawing.Point( 0 , 0 );
			this.dialogHeaderControl1.MainText = null;
			this.dialogHeaderControl1.Name = "dialogHeaderControl1";
			this.dialogHeaderControl1.OnlyMainText = false;
			this.dialogHeaderControl1.Renderer = dialogHeaderRenderer2;
			dialogHeaderScheme2.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 10 ) ) ) ) , ( (int)( ( (byte)( 75 ) ) ) ) , ( (int)( ( (byte)( 115 ) ) ) ) );
			dialogHeaderScheme2.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 50 ) ) ) ) , ( (int)( ( (byte)( 175 ) ) ) ) , ( (int)( ( (byte)( 175 ) ) ) ) );
			dialogHeaderScheme2.SubTitleColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			dialogHeaderScheme2.SubTitleFont = new System.Drawing.Font( "Verdana" , 10F );
			dialogHeaderScheme2.SubTitleRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			dialogHeaderScheme2.TitleColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			dialogHeaderScheme2.TitleFont = new System.Drawing.Font( "Verdana" , 12F , System.Drawing.FontStyle.Bold );
			dialogHeaderScheme2.TitleRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			this.dialogHeaderControl1.Scheme = dialogHeaderScheme2;
			this.dialogHeaderControl1.Size = new System.Drawing.Size( 634 , 50 );
			this.dialogHeaderControl1.SubText = null;
			this.dialogHeaderControl1.TabIndex = 7;
			// 
			// mirrorTextControl1
			// 
			this.mirrorTextControl1.BackColor = System.Drawing.Color.Transparent;
			this.mirrorTextControl1.Caption = "S i m p l e   W o r k f l o o r   M a n a g e m e n t   S u i t e";
			this.mirrorTextControl1.Location = new System.Drawing.Point( 3 , 3 );
			this.mirrorTextControl1.Name = "mirrorTextControl1";
			this.mirrorTextControl1.Renderer = mirrorTextRenderer2;
			mirrorTextScheme2.Correction = 6;
			mirrorTextScheme2.TextColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			mirrorTextScheme2.TextFont = new System.Drawing.Font( "Copperplate Gothic Light" , 15F );
			this.mirrorTextControl1.Scheme = mirrorTextScheme2;
			this.mirrorTextControl1.Size = new System.Drawing.Size( 628 , 44 );
			this.mirrorTextControl1.TabIndex = 0;
			// 
			// SwmSuiteAdminWizardForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size( 634 , 454 );
			this.Controls.Add( this.dialogHeaderControl1 );
			this.Controls.Add( this.swmSuiteAdminWizardContent5 );
			this.Controls.Add( this.swmSuiteAdminWizardContent4 );
			this.Controls.Add( this.swmSuiteAdminWizardContent3 );
			this.Controls.Add( this.swmSuiteAdminWizardContent2 );
			this.Controls.Add( this.swmSuiteAdminWizardContent1 );
			this.Controls.Add( this.wizardBottomPaneControl );
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size( 640 , 480 );
			this.Name = "SwmSuiteAdminWizardForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SwmSuite Administrator Wizard";
			this.Load += new System.EventHandler( this.SwmSuiteAdminWizardForm_Load );
			this.wizardBottomPaneControl.ResumeLayout( false );
			this.dialogHeaderControl1.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		private SwmSuite.Presentation.Common.UserControls.WizardBottomPaneControl wizardBottomPaneControl;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button previousButton;
		private System.Windows.Forms.Button nextButton;
		private System.Windows.Forms.Button helpButton;
		private SwmSuiteAdminWizardContent1 swmSuiteAdminWizardContent1;
		private SwmSuiteAdminWizardContent2 swmSuiteAdminWizardContent2;
		private SwmSuiteAdminWizardContent3 swmSuiteAdminWizardContent3;
		private SwmSuiteAdminWizardContent4 swmSuiteAdminWizardContent4;
		private SwmSuiteAdminWizardContent5 swmSuiteAdminWizardContent5;
		private SwmSuite.Presentation.Common.DialogHeader.DialogHeaderControl dialogHeaderControl1;
		private SwmSuite.Presentation.Common.MirrorText.MirrorTextControl mirrorTextControl1;
	}
}