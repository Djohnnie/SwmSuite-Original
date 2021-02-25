namespace SwmSuiteNotification {
	partial class MainForm {
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			SwmSuite.Presentation.Common.DialogHeader.DialogHeaderRenderer dialogHeaderRenderer2 = new SwmSuite.Presentation.Common.DialogHeader.DialogHeaderRenderer();
			SwmSuite.Presentation.Common.DialogHeader.DialogHeaderScheme dialogHeaderScheme2 = new SwmSuite.Presentation.Common.DialogHeader.DialogHeaderScheme();
			SwmSuite.Presentation.Common.EmployeeGroupTab.EmployeeGroupTabItem employeeGroupTabItem3 = new SwmSuite.Presentation.Common.EmployeeGroupTab.EmployeeGroupTabItem();
			SwmSuite.Presentation.Common.EmployeeGroupTab.EmployeeGroupTabItem employeeGroupTabItem4 = new SwmSuite.Presentation.Common.EmployeeGroupTab.EmployeeGroupTabItem();
			SwmSuite.Presentation.Common.EmployeeGroupTab.EmployeeGroupTabRenderer employeeGroupTabRenderer2 = new SwmSuite.Presentation.Common.EmployeeGroupTab.EmployeeGroupTabRenderer();
			SwmSuite.Presentation.Common.EmployeeGroupTab.EmployeeGroupTabScheme employeeGroupTabScheme2 = new SwmSuite.Presentation.Common.EmployeeGroupTab.EmployeeGroupTabScheme();
			this.dialogHeaderControl = new SwmSuite.Presentation.Common.DialogHeader.DialogHeaderControl();
			this.employeeGroupTabControl = new SwmSuite.Presentation.Common.EmployeeGroupTab.EmployeeGroupTabControl();
			this.SuspendLayout();
			// 
			// dialogHeaderControl
			// 
			this.dialogHeaderControl.Dock = System.Windows.Forms.DockStyle.Top;
			this.dialogHeaderControl.Location = new System.Drawing.Point( 0 , 0 );
			this.dialogHeaderControl.MainText = "Simple Workfloor Management Suite Meldingen";
			this.dialogHeaderControl.Name = "dialogHeaderControl";
			this.dialogHeaderControl.OnlyMainText = false;
			this.dialogHeaderControl.Renderer = dialogHeaderRenderer2;
			dialogHeaderScheme2.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 10 ) ) ) ) , ( (int)( ( (byte)( 75 ) ) ) ) , ( (int)( ( (byte)( 115 ) ) ) ) );
			dialogHeaderScheme2.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 50 ) ) ) ) , ( (int)( ( (byte)( 175 ) ) ) ) , ( (int)( ( (byte)( 175 ) ) ) ) );
			dialogHeaderScheme2.SubTitleColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			dialogHeaderScheme2.SubTitleFont = new System.Drawing.Font( "Verdana" , 10F );
			dialogHeaderScheme2.SubTitleRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			dialogHeaderScheme2.TitleColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			dialogHeaderScheme2.TitleFont = new System.Drawing.Font( "Verdana" , 12F , System.Drawing.FontStyle.Bold );
			dialogHeaderScheme2.TitleRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			this.dialogHeaderControl.Scheme = dialogHeaderScheme2;
			this.dialogHeaderControl.Size = new System.Drawing.Size( 516 , 60 );
			this.dialogHeaderControl.SubText = "Agent die meldingen i.v.m. uw berichten en taken weergeeft.";
			this.dialogHeaderControl.TabIndex = 0;
			// 
			// employeeGroupTabControl
			// 
			this.employeeGroupTabControl.BackColor = System.Drawing.Color.Transparent;
			this.employeeGroupTabControl.Dock = System.Windows.Forms.DockStyle.Top;
			employeeGroupTabItem3.Description = null;
			employeeGroupTabItem3.Enabled = true;
			employeeGroupTabItem3.Hovered = false;
			employeeGroupTabItem3.Selected = false;
			employeeGroupTabItem3.Tag = null;
			employeeGroupTabItem3.Title = "Algemene Instellingen";
			employeeGroupTabItem4.Description = null;
			employeeGroupTabItem4.Enabled = true;
			employeeGroupTabItem4.Hovered = false;
			employeeGroupTabItem4.Selected = false;
			employeeGroupTabItem4.Tag = null;
			employeeGroupTabItem4.Title = "Login Gegegevens";
			this.employeeGroupTabControl.Items.Add( employeeGroupTabItem3 );
			this.employeeGroupTabControl.Items.Add( employeeGroupTabItem4 );
			this.employeeGroupTabControl.Location = new System.Drawing.Point( 0 , 60 );
			this.employeeGroupTabControl.Name = "employeeGroupTabControl";
			this.employeeGroupTabControl.Renderer = employeeGroupTabRenderer2;
			employeeGroupTabScheme2.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 136 ) ) ) ) , ( (int)( ( (byte)( 180 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
			employeeGroupTabScheme2.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 71 ) ) ) ) , ( (int)( ( (byte)( 139 ) ) ) ) , ( (int)( ( (byte)( 158 ) ) ) ) );
			employeeGroupTabScheme2.BackgroundColor3 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 19 ) ) ) ) , ( (int)( ( (byte)( 97 ) ) ) ) , ( (int)( ( (byte)( 119 ) ) ) ) );
			employeeGroupTabScheme2.BackgroundColor4 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 83 ) ) ) ) , ( (int)( ( (byte)( 159 ) ) ) ) , ( (int)( ( (byte)( 171 ) ) ) ) );
			employeeGroupTabScheme2.ItemCaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			employeeGroupTabScheme2.ItemCaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			employeeGroupTabScheme2.ItemGlowColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 100 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			employeeGroupTabScheme2.ItemGlowColorSelected = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 100 ) ) ) ) , ( (int)( ( (byte)( 100 ) ) ) ) , ( (int)( ( (byte)( 100 ) ) ) ) , ( (int)( ( (byte)( 100 ) ) ) ) );
			employeeGroupTabScheme2.ItemInnerBorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 217 ) ) ) ) , ( (int)( ( (byte)( 229 ) ) ) ) , ( (int)( ( (byte)( 236 ) ) ) ) );
			employeeGroupTabScheme2.ItemInnerBorderColorSelected = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 87 ) ) ) ) , ( (int)( ( (byte)( 112 ) ) ) ) , ( (int)( ( (byte)( 125 ) ) ) ) );
			employeeGroupTabScheme2.ItemOuterBorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 84 ) ) ) ) , ( (int)( ( (byte)( 115 ) ) ) ) , ( (int)( ( (byte)( 131 ) ) ) ) );
			employeeGroupTabScheme2.ItemOuterBorderColorSelected = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 42 ) ) ) ) , ( (int)( ( (byte)( 58 ) ) ) ) , ( (int)( ( (byte)( 65 ) ) ) ) );
			this.employeeGroupTabControl.Scheme = employeeGroupTabScheme2;
			this.employeeGroupTabControl.Size = new System.Drawing.Size( 516 , 35 );
			this.employeeGroupTabControl.TabIndex = 1;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size( 516 , 378 );
			this.Controls.Add( this.employeeGroupTabControl );
			this.Controls.Add( this.dialogHeaderControl );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout( false );

		}

		#endregion

		private SwmSuite.Presentation.Common.DialogHeader.DialogHeaderControl dialogHeaderControl;
		private SwmSuite.Presentation.Common.EmployeeGroupTab.EmployeeGroupTabControl employeeGroupTabControl;
	}
}

