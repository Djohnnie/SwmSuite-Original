namespace SimpleWorkfloorManagementSuite.SwmSuiteAdminWizard {
	partial class SwmSuiteAdminWizardContent4 {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SwmSuiteAdminWizardContent4 ) );
			this.employeeGroupValidationControl = new SwmSuite.Presentation.Common.Validation.ValidationControl();
			this.employeeGroupTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// userNameValidationControl
			// 
			this.employeeGroupValidationControl.BackColor = System.Drawing.Color.Transparent;
			this.employeeGroupValidationControl.BackgroundImage = ( (System.Drawing.Image)( resources.GetObject( "userNameValidationControl.BackgroundImage" ) ) );
			this.employeeGroupValidationControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.employeeGroupValidationControl.Location = new System.Drawing.Point( 458 , 148 );
			this.employeeGroupValidationControl.Name = "userNameValidationControl";
			this.employeeGroupValidationControl.Size = new System.Drawing.Size( 24 , 24 );
			this.employeeGroupValidationControl.TabIndex = 24;
			this.employeeGroupValidationControl.Valid = false;
			// 
			// employeeGroupTextBox
			// 
			this.employeeGroupTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.employeeGroupTextBox.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.employeeGroupTextBox.Location = new System.Drawing.Point( 52 , 148 );
			this.employeeGroupTextBox.Name = "employeeGroupTextBox";
			this.employeeGroupTextBox.Size = new System.Drawing.Size( 400 , 24 );
			this.employeeGroupTextBox.TabIndex = 21;
			this.employeeGroupTextBox.TextChanged += new System.EventHandler( this.employeeGroupTextBox_TextChanged );
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font( "Copperplate Gothic Light" , 12F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.label6.Location = new System.Drawing.Point( 5 , 5 );
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size( 234 , 17 );
			this.label6.TabIndex = 23;
			this.label6.Text = "Beheerder Registreren";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.label2.Location = new System.Drawing.Point( 49 , 128 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 130 , 17 );
			this.label2.TabIndex = 22;
			this.label2.Text = "Personeelsgroep:";
			// 
			// label3
			// 
			this.label3.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.label3.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.label3.Location = new System.Drawing.Point( 5 , 89 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 620 , 39 );
			this.label3.TabIndex = 20;
			this.label3.Text = "Geef een naam aan de personeelsgroep waartoe de beheerder zal behoren:";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.label1.Location = new System.Drawing.Point( 5 , 50 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 620 , 39 );
			this.label1.TabIndex = 19;
			this.label1.Text = "Als beheerder kunt u het volledige systeem beheren. Als de registratie succesvol " +
				"is verlopen zal u SwmSuite kunnen configureren.";
			// 
			// SwmSuiteAdminWizardContent4
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add( this.employeeGroupValidationControl );
			this.Controls.Add( this.employeeGroupTextBox );
			this.Controls.Add( this.label6 );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.label3 );
			this.Controls.Add( this.label1 );
			this.Name = "SwmSuiteAdminWizardContent4";
			this.Size = new System.Drawing.Size( 640 , 480 );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private SwmSuite.Presentation.Common.Validation.ValidationControl employeeGroupValidationControl;
		private System.Windows.Forms.TextBox employeeGroupTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;

	}
}
