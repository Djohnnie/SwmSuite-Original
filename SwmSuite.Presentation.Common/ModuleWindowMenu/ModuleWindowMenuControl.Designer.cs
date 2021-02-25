namespace SwmSuite.Presentation.Common.ModuleWindowMenu {
	partial class ModuleWindowMenuControl {
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
			// ModuleWindowMenuControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "ModuleWindowMenuControl";
			this.Size = new System.Drawing.Size( 164 , 540 );
			this.MouseLeave += new System.EventHandler( this.ModuleWindowMenuControl_MouseLeave );
			this.Paint += new System.Windows.Forms.PaintEventHandler( this.ModuleWindowMenuControl_Paint );
			this.MouseMove += new System.Windows.Forms.MouseEventHandler( this.ModuleWindowMenuControl_MouseMove );
			this.MouseUp += new System.Windows.Forms.MouseEventHandler( this.ModuleWindowMenuControl_MouseUp );
			this.SizeChanged += new System.EventHandler( this.ModuleWindowMenuControl_SizeChanged );
			this.ResumeLayout( false );

		}

		#endregion
	}
}
