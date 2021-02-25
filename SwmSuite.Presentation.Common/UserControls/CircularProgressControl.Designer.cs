namespace SwmSuite.Presentation.Common.UserControls {
	partial class CircularProgressControl {
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
			this.components = new System.ComponentModel.Container();
			this.animationTimer = new System.Windows.Forms.Timer( this.components );
			this.SuspendLayout();
			// 
			// animationTimer
			// 
			this.animationTimer.Enabled = true;
			this.animationTimer.Interval = 25;
			this.animationTimer.Tick += new System.EventHandler( this.animationTimer_Tick );
			// 
			// CircularProgressControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "CircularProgressControl";
			this.Size = new System.Drawing.Size( 78 , 68 );
			this.Paint += new System.Windows.Forms.PaintEventHandler( this.CircularProgressControl_Paint );
			this.Resize += new System.EventHandler( this.CircularProgressControl_Resize );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.Timer animationTimer;
	}
}
