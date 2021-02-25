namespace SwmSuite.Presentation.Common.NiceTextBox {
	partial class NiceTextBoxControl {
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
			this.textbox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textbox
			// 
			this.textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textbox.Location = new System.Drawing.Point( 52 , 37 );
			this.textbox.Name = "textbox";
			this.textbox.Size = new System.Drawing.Size( 100 , 13 );
			this.textbox.TabIndex = 0;
			this.textbox.TextChanged += new System.EventHandler( this.textbox_TextChanged );
			this.textbox.MouseLeave += new System.EventHandler( this.textbox_MouseLeave );
			this.textbox.Leave += new System.EventHandler( this.textbox_Leave );
			this.textbox.Enter += new System.EventHandler( this.textbox_Enter );
			this.textbox.MouseEnter += new System.EventHandler( this.textbox_MouseEnter );
			// 
			// NiceTextBoxControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.textbox );
			this.Name = "NiceTextBoxControl";
			this.Size = new System.Drawing.Size( 217 , 82 );
			this.Load += new System.EventHandler( this.NiceTextBoxControl_Load );
			this.Paint += new System.Windows.Forms.PaintEventHandler( this.NiceTextBoxControl_Paint );
			this.BackColorChanged += new System.EventHandler( this.NiceTextBoxControl_BackColorChanged );
			this.Resize += new System.EventHandler( this.NiceTextBoxControl_Resize );
			this.EnabledChanged += new System.EventHandler( this.NiceTextBoxControl_EnabledChanged );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textbox;
	}
}
