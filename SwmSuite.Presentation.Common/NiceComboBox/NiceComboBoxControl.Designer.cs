namespace SwmSuite.Presentation.Common.NiceComboBox {
	partial class NiceComboBoxControl {
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
			this.comboBox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// comboBox
			// 
			this.comboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.comboBox.FormattingEnabled = true;
			this.comboBox.Location = new System.Drawing.Point( 64 , 77 );
			this.comboBox.Name = "comboBox";
			this.comboBox.Size = new System.Drawing.Size( 159 , 21 );
			this.comboBox.TabIndex = 0;
			this.comboBox.Leave += new System.EventHandler( this.comboBox_Leave );
			this.comboBox.Enter += new System.EventHandler( this.comboBox_Enter );
			this.comboBox.MouseEnter += new System.EventHandler( this.comboBox_MouseEnter );
			this.comboBox.MouseLeave += new System.EventHandler( this.comboBox_MouseLeave );
			// 
			// NiceComboBoxControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.comboBox );
			this.Name = "NiceComboBoxControl";
			this.Size = new System.Drawing.Size( 501 , 314 );
			this.Load += new System.EventHandler( this.NiceComboBoxControl_Load );
			this.Paint += new System.Windows.Forms.PaintEventHandler( this.NiceComboBoxControl_Paint );
			this.BackColorChanged += new System.EventHandler( this.NiceComboBoxControl_BackColorChanged );
			this.Resize += new System.EventHandler( this.NiceComboBoxControl_Resize );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBox;
	}
}
