namespace SimpleWorkfloorManagementSuite.Dialogs {
	partial class ExceptionSendDialog {
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
			this.dialogHeaderControl = new SwmSuite.Presentation.Common.DialogHeader.DialogHeaderControl();
			this.circularProgressControl1 = new SwmSuite.Presentation.Common.UserControls.CircularProgressControl();
			this.SuspendLayout();
			// 
			// dialogHeaderControl
			// 
			this.dialogHeaderControl.Dock = System.Windows.Forms.DockStyle.Top;
			this.dialogHeaderControl.Location = new System.Drawing.Point( 0 , 0 );
			this.dialogHeaderControl.MainText = " SwmSuite foutrapport wordt verzonden";
			this.dialogHeaderControl.Name = "dialogHeaderControl";
			this.dialogHeaderControl.OnlyMainText = true;
			this.dialogHeaderControl.Renderer = dialogHeaderRenderer2;
			dialogHeaderScheme2.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 115 ) ) ) ) , ( (int)( ( (byte)( 10 ) ) ) ) , ( (int)( ( (byte)( 10 ) ) ) ) );
			dialogHeaderScheme2.BackgroundColor2 = System.Drawing.Color.Red;
			dialogHeaderScheme2.SubTitleColor = System.Drawing.Color.White;
			dialogHeaderScheme2.SubTitleFont = new System.Drawing.Font( "Verdana" , 10F );
			dialogHeaderScheme2.SubTitleRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			dialogHeaderScheme2.TitleColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			dialogHeaderScheme2.TitleFont = new System.Drawing.Font( "Verdana" , 12F , System.Drawing.FontStyle.Bold );
			dialogHeaderScheme2.TitleRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			this.dialogHeaderControl.Scheme = dialogHeaderScheme2;
			this.dialogHeaderControl.Size = new System.Drawing.Size( 385 , 50 );
			this.dialogHeaderControl.SubText = "  Er heeft zich een onverwachte fout voorgedaan.";
			this.dialogHeaderControl.TabIndex = 11;
			this.dialogHeaderControl.TabStop = false;
			// 
			// circularProgressControl1
			// 
			this.circularProgressControl1.ActiveSegmentColour = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 35 ) ) ) ) , ( (int)( ( (byte)( 146 ) ) ) ) , ( (int)( ( (byte)( 33 ) ) ) ) );
			this.circularProgressControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.circularProgressControl1.InactiveSegmentColour = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 218 ) ) ) ) , ( (int)( ( (byte)( 218 ) ) ) ) , ( (int)( ( (byte)( 218 ) ) ) ) );
			this.circularProgressControl1.Location = new System.Drawing.Point( 167 , 56 );
			this.circularProgressControl1.Name = "circularProgressControl1";
			this.circularProgressControl1.Size = new System.Drawing.Size( 50 , 50 );
			this.circularProgressControl1.TabIndex = 12;
			this.circularProgressControl1.TransistionSegmentColour = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 129 ) ) ) ) , ( (int)( ( (byte)( 242 ) ) ) ) , ( (int)( ( (byte)( 121 ) ) ) ) );
			// 
			// ExceptionSendDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size( 385 , 113 );
			this.ControlBox = false;
			this.Controls.Add( this.circularProgressControl1 );
			this.Controls.Add( this.dialogHeaderControl );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ExceptionSendDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Simple Workfloor Management Suite";
			this.Load += new System.EventHandler( this.ExceptionSendDialog_Load );
			this.ResumeLayout( false );

		}

		#endregion

		private SwmSuite.Presentation.Common.DialogHeader.DialogHeaderControl dialogHeaderControl;
		private SwmSuite.Presentation.Common.UserControls.CircularProgressControl circularProgressControl1;
	}
}