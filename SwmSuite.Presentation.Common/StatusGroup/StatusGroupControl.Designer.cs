namespace SwmSuite.Presentation.Common.StatusGroup {
	partial class StatusGroupControl {
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
			// StatusGroupControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "StatusGroupControl";
			this.Size = new System.Drawing.Size( 391 , 101 );
			this.Paint += new System.Windows.Forms.PaintEventHandler( this.StatusGroupControl_Paint );
			this.Resize += new System.EventHandler( this.StatusGroupControl_Resize );
			this.ResumeLayout( false );

		}

		#endregion
	}
}
