namespace SwmSuite.Presentation.Common.LoginButton {
	partial class LoginButtonControl {
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
			this.SuspendLayout();
			// 
			// LoginButtonControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "LoginButtonControl";
			this.Size = new System.Drawing.Size( 466 , 230 );
			this.MouseLeave += new System.EventHandler( this.LoginButtonControl_MouseLeave );
			this.Paint += new System.Windows.Forms.PaintEventHandler( this.LoginButtonControl_Paint );
			this.MouseDown += new System.Windows.Forms.MouseEventHandler( this.LoginButtonControl_MouseDown );
			this.MouseUp += new System.Windows.Forms.MouseEventHandler( this.LoginButtonControl_MouseUp );
			this.SizeChanged += new System.EventHandler( this.LoginButtonControl_SizeChanged );
			this.MouseEnter += new System.EventHandler( this.LoginButtonControl_MouseEnter );
			this.ResumeLayout( false );

		}

		#endregion

	}
}
