namespace SimpleWorkfloorManagementSuite {
	partial class SplashForm {
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
			System.Drawing.Region region1 = new System.Drawing.Region();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SplashForm ) );
			this.closeSplashTimer = new System.Windows.Forms.Timer( this.components );
			this.splashControl1 = new SwmSuite.Presentation.Common.UserControls.SplashControl();
			this.SuspendLayout();
			// 
			// closeSplashTimer
			// 
			this.closeSplashTimer.Interval = 1000;
			this.closeSplashTimer.Tick += new System.EventHandler( this.closeSplashTimer_Tick );
			// 
			// splashControl1
			// 
			this.splashControl1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.splashControl1.BackColor = System.Drawing.Color.Transparent;
			this.splashControl1.Copyright = null;
			this.splashControl1.CopyrightColor = System.Drawing.Color.Empty;
			this.splashControl1.CopyrightFont = null;
			this.splashControl1.CornerRadius = 75;
			this.splashControl1.EditionTitle = null;
			this.splashControl1.EditionTitleColor = System.Drawing.Color.Empty;
			this.splashControl1.EditionTitleFont = null;
			this.splashControl1.Location = new System.Drawing.Point( 12 , 12 );
			this.splashControl1.Name = "splashControl1";
			this.splashControl1.Size = new System.Drawing.Size( 803 , 374 );
			this.splashControl1.SplashRegion = region1;
			this.splashControl1.SubTitle = "S  i  m  p  l  e     W  o  r  k  f  l  o  o  r     M  a  n  a  g  e  m  e  n  t  " +
				 "   S  u  i  t  e";
			this.splashControl1.SubTitleColor = System.Drawing.Color.White;
			this.splashControl1.SubTitleFont = new System.Drawing.Font( "Copperplate Gothic Light" , 14.25F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.splashControl1.TabIndex = 1;
			this.splashControl1.Title = "SWMS";
			this.splashControl1.TitleColor = System.Drawing.Color.White;
			this.splashControl1.TitleFont = new System.Drawing.Font( "Copperplate Gothic Bold" , 100F , System.Drawing.FontStyle.Bold );
			this.splashControl1.Version = null;
			this.splashControl1.VersionColor = System.Drawing.Color.Empty;
			this.splashControl1.VersionFont = null;
			// 
			// SplashForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 254 ) ) ) ) , ( (int)( ( (byte)( 254 ) ) ) ) , ( (int)( ( (byte)( 254 ) ) ) ) );
			this.ClientSize = new System.Drawing.Size( 827 , 398 );
			this.Controls.Add( this.splashControl1 );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.Name = "SplashForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SwmSuite";
			this.TransparencyKey = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 254 ) ) ) ) , ( (int)( ( (byte)( 254 ) ) ) ) , ( (int)( ( (byte)( 254 ) ) ) ) );
			this.Load += new System.EventHandler( this.SplashForm_Load );
			this.ResumeLayout( false );

		}

		#endregion

		private SwmSuite.Presentation.Common.UserControls.SplashControl splashControl1;
		private System.Windows.Forms.Timer closeSplashTimer;
	}
}