namespace SwmSuite.Presentation.Common.PopUpButton {
	partial class PopUpButtonControl {
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
			// PopUpButtonControl
			// 
			this.MouseLeave += new System.EventHandler( this.PopUpButtonControl_MouseLeave );
			this.Paint += new System.Windows.Forms.PaintEventHandler( this.PopUpButtonControl_Paint );
			this.MouseDown += new System.Windows.Forms.MouseEventHandler( this.PopUpButtonControl_MouseDown );
			this.MouseUp += new System.Windows.Forms.MouseEventHandler( this.PopUpButtonControl_MouseUp );
			this.EnabledChanged += new System.EventHandler( this.PopUpButtonControl_EnabledChanged );
			this.MouseEnter += new System.EventHandler( this.PopUpButtonControl_MouseEnter );
			this.ResumeLayout( false );

		}

		#endregion
	}
}
