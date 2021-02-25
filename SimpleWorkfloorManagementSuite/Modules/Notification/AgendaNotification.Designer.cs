namespace SimpleWorkfloorManagementSuite.Modules.Notification {
	partial class AgendaNotification {
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
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.displayTimer = new System.Windows.Forms.Timer( this.components );
			this.SuspendLayout();
			// 
			// backgroundWorker
			// 
			this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler( this.backgroundWorker_DoWork );
			this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler( this.backgroundWorker_RunWorkerCompleted );
			// 
			// displayTimer
			// 
			this.displayTimer.Interval = 5000;
			this.displayTimer.Tick += new System.EventHandler( this.displayTimer_Tick );
			// 
			// AgendaNotification
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "AgendaNotification";
			this.Size = new System.Drawing.Size( 300 , 100 );
			this.MouseLeave += new System.EventHandler( this.AgendaNotification_MouseLeave );
			this.Paint += new System.Windows.Forms.PaintEventHandler( this.AgendaNotification_Paint );
			this.MouseEnter += new System.EventHandler( this.AgendaNotification_MouseEnter );
			this.ResumeLayout( false );

		}

		#endregion

		private System.ComponentModel.BackgroundWorker backgroundWorker;
		private System.Windows.Forms.Timer displayTimer;
	}
}
