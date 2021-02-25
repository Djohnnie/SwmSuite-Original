namespace SwmSuite.Presentation.Common.Marquee {
	partial class MarqueeControl {
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
			this.timer = new System.Windows.Forms.Timer( this.components );
			this.SuspendLayout();
			// 
			// timer
			// 
			this.timer.Enabled = true;
			this.timer.Interval = 25;
			this.timer.Tick += new System.EventHandler( this.timer_Tick );
			// 
			// MarqueeControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "MarqueeControl";
			this.Size = new System.Drawing.Size( 364 , 44 );
			this.Paint += new System.Windows.Forms.PaintEventHandler( this.MarqueeControl_Paint );
			this.SizeChanged += new System.EventHandler( this.MarqueeControl_SizeChanged );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.Timer timer;
	}
}
