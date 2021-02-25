namespace SwmSuite.Presentation.Common.EmployeeGroupTab {
	partial class EmployeeGroupTabControl {
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
			// EmployeeGroupTabControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "EmployeeGroupTabControl";
			this.Size = new System.Drawing.Size( 824 , 58 );
			this.MouseLeave += new System.EventHandler( this.EmployeeGroupTabControl_MouseLeave );
			this.Paint += new System.Windows.Forms.PaintEventHandler( this.EmployeeGroupTabControl_Paint );
			this.MouseMove += new System.Windows.Forms.MouseEventHandler( this.EmployeeGroupTabControl_MouseMove );
			this.MouseDown += new System.Windows.Forms.MouseEventHandler( this.EmployeeGroupTabControl_MouseDown );
			this.SizeChanged += new System.EventHandler( this.EmployeeGroupTabControl_SizeChanged );
			this.ResumeLayout( false );

		}

		#endregion
	}
}
