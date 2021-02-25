namespace SimpleWorkfloorManagementSuite.Dialogs {
	partial class AboutDialog {
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
			System.Drawing.Region region1 = new System.Drawing.Region();
			this.splashControl1 = new SwmSuite.Presentation.Common.UserControls.SplashControl();
			this.SuspendLayout();
			// 
			// splashControl1
			// 
			this.splashControl1.BackColor = System.Drawing.Color.Transparent;
			this.splashControl1.Copyright = "";
			this.splashControl1.CopyrightColor = System.Drawing.Color.White;
			this.splashControl1.CopyrightFont = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.splashControl1.CornerRadius = 1;
			this.splashControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splashControl1.EditionTitle = null;
			this.splashControl1.EditionTitleColor = System.Drawing.Color.White;
			this.splashControl1.EditionTitleFont = new System.Drawing.Font( "Verdana" , 9.75F );
			this.splashControl1.Location = new System.Drawing.Point( 0 , 0 );
			this.splashControl1.Name = "splashControl1";
			this.splashControl1.Size = new System.Drawing.Size( 827 , 360 );
			this.splashControl1.SplashRegion = region1;
			this.splashControl1.SubTitle = "S  i  m  p  l  e     W  o  r  k  f  l  o  o  r     M  a  n  a  g  e  m  e  n  t  " +
				 "   S  u  i  t  e";
			this.splashControl1.SubTitleColor = System.Drawing.Color.White;
			this.splashControl1.SubTitleFont = new System.Drawing.Font( "Copperplate Gothic Light" , 14.25F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.splashControl1.TabIndex = 2;
			this.splashControl1.Title = "SWMS";
			this.splashControl1.TitleColor = System.Drawing.Color.White;
			this.splashControl1.TitleFont = new System.Drawing.Font( "Copperplate Gothic Bold" , 100F , System.Drawing.FontStyle.Bold );
			this.splashControl1.Version = null;
			this.splashControl1.VersionColor = System.Drawing.Color.White;
			this.splashControl1.VersionFont = new System.Drawing.Font( "Verdana" , 9.75F );
			this.splashControl1.Click += new System.EventHandler( this.splashControl_Click );
			// 
			// AboutDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 827 , 360 );
			this.ControlBox = false;
			this.Controls.Add( this.splashControl1 );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Simple Workfloor Management Suite";
			this.ResumeLayout( false );

		}

		#endregion

		private SwmSuite.Presentation.Common.UserControls.SplashControl splashControl1;
	}
}