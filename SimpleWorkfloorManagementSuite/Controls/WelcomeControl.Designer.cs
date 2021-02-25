namespace SimpleWorkfloorManagementSuite.Controls {
	partial class WelcomeControl {
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
			System.Drawing.Region region4 = new System.Drawing.Region();
			this.splashControl1 = new SwmSuite.Presentation.Common.UserControls.SplashControl();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// splashControl1
			// 
			this.splashControl1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
									| System.Windows.Forms.AnchorStyles.Left )
									| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.splashControl1.Copyright = null;
			this.splashControl1.CopyrightColor = System.Drawing.Color.Empty;
			this.splashControl1.CopyrightFont = null;
			this.splashControl1.CornerRadius = 75;
			this.splashControl1.EditionTitle = null;
			this.splashControl1.EditionTitleColor = System.Drawing.Color.Empty;
			this.splashControl1.EditionTitleFont = null;
			this.splashControl1.Location = new System.Drawing.Point( 3 , 3 );
			this.splashControl1.Name = "splashControl1";
			this.splashControl1.Size = new System.Drawing.Size( 785 , 362 );
			this.splashControl1.SplashRegion = region4;
			this.splashControl1.SubTitle = "Simple Workfloor Management Suite";
			this.splashControl1.SubTitleColor = System.Drawing.Color.White;
			this.splashControl1.SubTitleFont = new System.Drawing.Font( "Copperplate Gothic Light" , 20F );
			this.splashControl1.TabIndex = 0;
			this.splashControl1.Title = "SWMS";
			this.splashControl1.TitleColor = System.Drawing.Color.White;
			this.splashControl1.TitleFont = new System.Drawing.Font( "Copperplate Gothic Bold" , 100F , System.Drawing.FontStyle.Bold );
			this.splashControl1.Version = null;
			this.splashControl1.VersionColor = System.Drawing.Color.Empty;
			this.splashControl1.VersionFont = null;
			// 
			// label1
			// 
			this.label1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left )
									| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.label1.Font = new System.Drawing.Font( "Copperplate Gothic Bold" , 20.25F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.label1.Location = new System.Drawing.Point( 3 , 368 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 785 , 61 );
			this.label1.TabIndex = 1;
			this.label1.Text = "Welkom";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// label2
			// 
			this.label2.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left )
									| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.label2.Font = new System.Drawing.Font( "Copperplate Gothic Light" , 16.25F );
			this.label2.Location = new System.Drawing.Point( 3 , 428 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 785 , 61 );
			this.label2.TabIndex = 2;
			this.label2.Text = "Klik op één van de personeelsgroepen bovenaan om in te loggen";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// WelcomeControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.splashControl1 );
			this.Name = "WelcomeControl";
			this.Size = new System.Drawing.Size( 791 , 489 );
			this.ResumeLayout( false );

		}

		#endregion

		private SwmSuite.Presentation.Common.UserControls.SplashControl splashControl1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;

	}
}
