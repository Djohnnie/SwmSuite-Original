namespace SwmSuite.Presentation.Common.MirrorText {
	partial class MirrorTextControl {
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
			// MirrorTextControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "MirrorTextControl";
			this.Size = new System.Drawing.Size( 538 , 66 );
			this.Paint += new System.Windows.Forms.PaintEventHandler( this.MirrorTextControl_Paint );
			this.SizeChanged += new System.EventHandler( this.MirrorTextControl_SizeChanged );
			this.ResumeLayout( false );

		}

		#endregion
	}
}
