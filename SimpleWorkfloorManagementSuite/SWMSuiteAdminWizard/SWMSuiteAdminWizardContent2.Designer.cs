namespace SimpleWorkfloorManagementSuite.SwmSuiteAdminWizard {
	partial class SwmSuiteAdminWizardContent2 {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SwmSuiteAdminWizardContent2 ) );
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.firstNameTextBox = new System.Windows.Forms.TextBox();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.nameValidationControl = new SwmSuite.Presentation.Common.Validation.ValidationControl();
			this.firstNameValidationControl = new SwmSuite.Presentation.Common.Validation.ValidationControl();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.label1.Location = new System.Drawing.Point( 5 , 50 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 620 , 39 );
			this.label1.TabIndex = 0;
			this.label1.Text = "Als beheerder kunt u het volledige systeem beheren. Als de registratie succesvol " +
				"is verlopen zal u SwmSuite kunnen configureren.";
			// 
			// label3
			// 
			this.label3.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.label3.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.label3.Location = new System.Drawing.Point( 5 , 89 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 620 , 20 );
			this.label3.TabIndex = 2;
			this.label3.Text = "Geef uw naam en voornaam:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font( "Copperplate Gothic Light" , 12F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.label6.Location = new System.Drawing.Point( 5 , 5 );
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size( 234 , 17 );
			this.label6.TabIndex = 8;
			this.label6.Text = "Beheerder Registreren";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.label5.Location = new System.Drawing.Point( 50 , 162 );
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size( 86 , 17 );
			this.label5.TabIndex = 13;
			this.label5.Text = "Voornaam:";
			// 
			// firstNameTextBox
			// 
			this.firstNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.firstNameTextBox.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.firstNameTextBox.Location = new System.Drawing.Point( 53 , 182 );
			this.firstNameTextBox.Name = "firstNameTextBox";
			this.firstNameTextBox.Size = new System.Drawing.Size( 400 , 24 );
			this.firstNameTextBox.TabIndex = 1;
			this.firstNameTextBox.TextChanged += new System.EventHandler( this.firstNameTextBox_TextChanged );
			// 
			// nameTextBox
			// 
			this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.nameTextBox.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.nameTextBox.Location = new System.Drawing.Point( 53 , 135 );
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size( 400 , 24 );
			this.nameTextBox.TabIndex = 0;
			this.nameTextBox.TextChanged += new System.EventHandler( this.nameTextBox_TextChanged );
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.label8.Location = new System.Drawing.Point( 50 , 115 );
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size( 53 , 17 );
			this.label8.TabIndex = 15;
			this.label8.Text = "Naam:";
			// 
			// nameValidationControl
			// 
			this.nameValidationControl.BackColor = System.Drawing.Color.Transparent;
			this.nameValidationControl.BackgroundImage = ( (System.Drawing.Image)( resources.GetObject( "nameValidationControl.BackgroundImage" ) ) );
			this.nameValidationControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.nameValidationControl.Location = new System.Drawing.Point( 459 , 135 );
			this.nameValidationControl.Name = "nameValidationControl";
			this.nameValidationControl.Size = new System.Drawing.Size( 24 , 24 );
			this.nameValidationControl.TabIndex = 16;
			this.nameValidationControl.Valid = false;
			// 
			// firstNameValidationControl
			// 
			this.firstNameValidationControl.BackColor = System.Drawing.Color.Transparent;
			this.firstNameValidationControl.BackgroundImage = ( (System.Drawing.Image)( resources.GetObject( "firstNameValidationControl.BackgroundImage" ) ) );
			this.firstNameValidationControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.firstNameValidationControl.Location = new System.Drawing.Point( 459 , 182 );
			this.firstNameValidationControl.Name = "firstNameValidationControl";
			this.firstNameValidationControl.Size = new System.Drawing.Size( 24 , 24 );
			this.firstNameValidationControl.TabIndex = 17;
			this.firstNameValidationControl.Valid = false;
			// 
			// SwmSuiteAdminWizardContent2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add( this.firstNameValidationControl );
			this.Controls.Add( this.nameValidationControl );
			this.Controls.Add( this.nameTextBox );
			this.Controls.Add( this.label8 );
			this.Controls.Add( this.firstNameTextBox );
			this.Controls.Add( this.label5 );
			this.Controls.Add( this.label6 );
			this.Controls.Add( this.label3 );
			this.Controls.Add( this.label1 );
			this.Name = "SwmSuiteAdminWizardContent2";
			this.Size = new System.Drawing.Size( 640 , 480 );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox firstNameTextBox;
		private System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.Label label8;
		private SwmSuite.Presentation.Common.Validation.ValidationControl nameValidationControl;
		private SwmSuite.Presentation.Common.Validation.ValidationControl firstNameValidationControl;
	}
}
