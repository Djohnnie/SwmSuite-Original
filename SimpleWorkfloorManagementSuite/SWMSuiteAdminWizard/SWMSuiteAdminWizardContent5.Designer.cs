namespace SimpleWorkfloorManagementSuite.SwmSuiteAdminWizard {

	partial class SwmSuiteAdminWizardContent5 {
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
			this.label6 = new System.Windows.Forms.Label();
			this.circularProgressControl = new SwmSuite.Presentation.Common.UserControls.CircularProgressControl();
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font( "Copperplate Gothic Light" , 12F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.label6.Location = new System.Drawing.Point( 5 , 5 );
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size( 237 , 17 );
			this.label6.TabIndex = 8;
			this.label6.Text = "Gegevens registreren...";
			// 
			// circularProgressControl
			// 
			this.circularProgressControl.ActiveSegmentColour = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 35 ) ) ) ) , ( (int)( ( (byte)( 146 ) ) ) ) , ( (int)( ( (byte)( 33 ) ) ) ) );
			this.circularProgressControl.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.circularProgressControl.InactiveSegmentColour = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 218 ) ) ) ) , ( (int)( ( (byte)( 218 ) ) ) ) , ( (int)( ( (byte)( 218 ) ) ) ) );
			this.circularProgressControl.Location = new System.Drawing.Point( 295 , 215 );
			this.circularProgressControl.Name = "circularProgressControl";
			this.circularProgressControl.Size = new System.Drawing.Size( 50 , 50 );
			this.circularProgressControl.TabIndex = 9;
			this.circularProgressControl.TransistionSegmentColour = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 129 ) ) ) ) , ( (int)( ( (byte)( 242 ) ) ) ) , ( (int)( ( (byte)( 121 ) ) ) ) );
			// 
			// backgroundWorker
			// 
			this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler( this.backgroundWorker_DoWork );
			this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler( this.backgroundWorker_RunWorkerCompleted );
			// 
			// SwmSuiteAdminWizardContent4
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add( this.circularProgressControl );
			this.Controls.Add( this.label6 );
			this.Name = "SwmSuiteAdminWizardContent4";
			this.Size = new System.Drawing.Size( 640 , 480 );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label6;
		private SwmSuite.Presentation.Common.UserControls.CircularProgressControl circularProgressControl;
		private System.ComponentModel.BackgroundWorker backgroundWorker;
	}
}
