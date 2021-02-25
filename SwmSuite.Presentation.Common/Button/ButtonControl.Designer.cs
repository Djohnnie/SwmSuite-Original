namespace SwmSuite.Presentation.Common {
	partial class ButtonControl {
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
			// ButtonControl
			// 
			this.Name = "ButtonControl";
			this.Size = new System.Drawing.Size( 167 , 49 );
			this.MouseLeave += new System.EventHandler( this.ButtonControl_MouseLeave );
			this.Paint += new System.Windows.Forms.PaintEventHandler( this.ButtonControl_Paint );
			this.MouseDown += new System.Windows.Forms.MouseEventHandler( this.ButtonControl_MouseDown );
			this.MouseUp += new System.Windows.Forms.MouseEventHandler( this.ButtonControl_MouseUp );
			this.EnabledChanged += new System.EventHandler( this.ButtonControl_EnabledChanged );
			this.MouseEnter += new System.EventHandler( this.ButtonControl_MouseEnter );
			this.ResumeLayout( false );

		}

		#endregion
	}
}
