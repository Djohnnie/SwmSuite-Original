namespace SimpleWorkfloorManagementSuite.Controls {
	partial class TaskContentsControl {
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
			this.richTextBox = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// richTextBox
			// 
			this.richTextBox.BackColor = System.Drawing.Color.White;
			this.richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBox.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.richTextBox.Location = new System.Drawing.Point( 115 , 21 );
			this.richTextBox.Name = "richTextBox";
			this.richTextBox.ReadOnly = true;
			this.richTextBox.Size = new System.Drawing.Size( 100 , 96 );
			this.richTextBox.TabIndex = 1;
			this.richTextBox.Text = "";
			// 
			// TaskContentsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add( this.richTextBox );
			this.Name = "TaskContentsControl";
			this.Size = new System.Drawing.Size( 331 , 138 );
			this.Load += new System.EventHandler( this.TaskContentsControl_Load );
			this.Paint += new System.Windows.Forms.PaintEventHandler( this.MessageContentsControl_Paint );
			this.Resize += new System.EventHandler( this.MessageContentsControl_Resize );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.RichTextBox richTextBox;
	}
}
