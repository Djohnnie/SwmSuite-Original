namespace SwmSuite.Presentation.Common.AgendaControl {
	partial class AgendaControl {
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
			this.verticalScrollBar = new System.Windows.Forms.VScrollBar();
			this.SuspendLayout();
			// 
			// verticalScrollBar
			// 
			this.verticalScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
			this.verticalScrollBar.Location = new System.Drawing.Point( 778 , 0 );
			this.verticalScrollBar.Name = "verticalScrollBar";
			this.verticalScrollBar.Size = new System.Drawing.Size( 17 , 515 );
			this.verticalScrollBar.TabIndex = 0;
			this.verticalScrollBar.ValueChanged += new System.EventHandler( this.verticalScrollBar_ValueChanged );
			this.verticalScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler( this.verticalScrollBar_Scroll );
			// 
			// AgendaControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.verticalScrollBar );
			this.Name = "AgendaControl";
			this.Size = new System.Drawing.Size( 795 , 515 );
			this.Load += new System.EventHandler( this.AgendaControl_Load );
			this.Paint += new System.Windows.Forms.PaintEventHandler( this.AgendaControl_Paint );
			this.MouseMove += new System.Windows.Forms.MouseEventHandler( this.AgendaControl_MouseMove );
			this.MouseDown += new System.Windows.Forms.MouseEventHandler( this.AgendaControl_MouseDown );
			this.Resize += new System.EventHandler( this.AgendaControl_Resize );
			this.MouseUp += new System.Windows.Forms.MouseEventHandler( this.AgendaControl_MouseUp );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.VScrollBar verticalScrollBar;
	}
}
