namespace SimpleWorkfloorManagementSuite.Controls {
	partial class OvertimeDetailControl {
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
			SwmSuite.Presentation.Common.StatusGroup.StatusGroupRenderer statusGroupRenderer1 = new SwmSuite.Presentation.Common.StatusGroup.StatusGroupRenderer();
			SwmSuite.Presentation.Common.StatusGroup.StatusGroupScheme statusGroupScheme1 = new SwmSuite.Presentation.Common.StatusGroup.StatusGroupScheme();
			this.statusGroup = new SwmSuite.Presentation.Common.StatusGroup.StatusGroupControl();
			this.employeeLabel = new System.Windows.Forms.Label();
			this.employeeTitleLabel = new System.Windows.Forms.Label();
			this.statusLabel = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.descriptionTextBox = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.commissionerLabel = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.toLabel = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.fromLabel = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.dateLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.statusGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusGroup
			// 
			this.statusGroup.Controls.Add( this.employeeLabel );
			this.statusGroup.Controls.Add( this.employeeTitleLabel );
			this.statusGroup.Controls.Add( this.statusLabel );
			this.statusGroup.Controls.Add( this.label10 );
			this.statusGroup.Controls.Add( this.descriptionTextBox );
			this.statusGroup.Controls.Add( this.label9 );
			this.statusGroup.Controls.Add( this.commissionerLabel );
			this.statusGroup.Controls.Add( this.label3 );
			this.statusGroup.Controls.Add( this.toLabel );
			this.statusGroup.Controls.Add( this.label6 );
			this.statusGroup.Controls.Add( this.fromLabel );
			this.statusGroup.Controls.Add( this.label4 );
			this.statusGroup.Controls.Add( this.dateLabel );
			this.statusGroup.Controls.Add( this.label1 );
			this.statusGroup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.statusGroup.Location = new System.Drawing.Point( 0 , 0 );
			this.statusGroup.Name = "statusGroup";
			this.statusGroup.Renderer = statusGroupRenderer1;
			statusGroupScheme1.BackgroundColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			statusGroupScheme1.BadColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 1 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			statusGroupScheme1.BadColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 221 ) ) ) ) , ( (int)( ( (byte)( 1 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			statusGroupScheme1.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 204 ) ) ) ) , ( (int)( ( (byte)( 204 ) ) ) ) , ( (int)( ( (byte)( 204 ) ) ) ) );
			statusGroupScheme1.GoodColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 22 ) ) ) ) , ( (int)( ( (byte)( 118 ) ) ) ) , ( (int)( ( (byte)( 20 ) ) ) ) );
			statusGroupScheme1.GoodColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 65 ) ) ) ) , ( (int)( ( (byte)( 178 ) ) ) ) , ( (int)( ( (byte)( 61 ) ) ) ) );
			statusGroupScheme1.InvalidColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 172 ) ) ) ) , ( (int)( ( (byte)( 172 ) ) ) ) );
			statusGroupScheme1.InvalidColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 221 ) ) ) ) , ( (int)( ( (byte)( 221 ) ) ) ) , ( (int)( ( (byte)( 221 ) ) ) ) );
			statusGroupScheme1.StatusAlignment = SwmSuite.Presentation.Common.StatusGroup.StatusGroupAlignment.Left;
			statusGroupScheme1.StatusSize = 20;
			statusGroupScheme1.WarnColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 242 ) ) ) ) , ( (int)( ( (byte)( 177 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			statusGroupScheme1.WarnColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 254 ) ) ) ) , ( (int)( ( (byte)( 205 ) ) ) ) , ( (int)( ( (byte)( 72 ) ) ) ) );
			this.statusGroup.Scheme = statusGroupScheme1;
			this.statusGroup.Size = new System.Drawing.Size( 763 , 264 );
			this.statusGroup.Status = SwmSuite.Presentation.Common.StatusGroup.StatusGroupStatus.Invalid;
			this.statusGroup.TabIndex = 3;
			// 
			// employeeLabel
			// 
			this.employeeLabel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.employeeLabel.AutoSize = true;
			this.employeeLabel.BackColor = System.Drawing.Color.Transparent;
			this.employeeLabel.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.employeeLabel.Location = new System.Drawing.Point( 549 , 49 );
			this.employeeLabel.Name = "employeeLabel";
			this.employeeLabel.Size = new System.Drawing.Size( 152 , 16 );
			this.employeeLabel.TabIndex = 16;
			this.employeeLabel.Text = "Hooyberghs Johnny";
			// 
			// employeeTitleLabel
			// 
			this.employeeTitleLabel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.employeeTitleLabel.AutoSize = true;
			this.employeeTitleLabel.BackColor = System.Drawing.Color.Transparent;
			this.employeeTitleLabel.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.employeeTitleLabel.Location = new System.Drawing.Point( 429 , 48 );
			this.employeeTitleLabel.Name = "employeeTitleLabel";
			this.employeeTitleLabel.Size = new System.Drawing.Size( 114 , 17 );
			this.employeeTitleLabel.TabIndex = 15;
			this.employeeTitleLabel.Text = "Uitgvoerd door";
			// 
			// statusLabel
			// 
			this.statusLabel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.statusLabel.AutoSize = true;
			this.statusLabel.BackColor = System.Drawing.Color.Transparent;
			this.statusLabel.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.statusLabel.Location = new System.Drawing.Point( 549 , 84 );
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size( 116 , 16 );
			this.statusLabel.TabIndex = 14;
			this.statusLabel.Text = "In behandeling";
			// 
			// label10
			// 
			this.label10.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.label10.AutoSize = true;
			this.label10.BackColor = System.Drawing.Color.Transparent;
			this.label10.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.label10.Location = new System.Drawing.Point( 488 , 83 );
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size( 55 , 17 );
			this.label10.TabIndex = 13;
			this.label10.Text = "Status";
			// 
			// descriptionTextBox
			// 
			this.descriptionTextBox.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.descriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.descriptionTextBox.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Bold );
			this.descriptionTextBox.Location = new System.Drawing.Point( 139 , 135 );
			this.descriptionTextBox.Multiline = true;
			this.descriptionTextBox.Name = "descriptionTextBox";
			this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.descriptionTextBox.Size = new System.Drawing.Size( 601 , 104 );
			this.descriptionTextBox.TabIndex = 12;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.BackColor = System.Drawing.Color.Transparent;
			this.label9.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.label9.Location = new System.Drawing.Point( 31 , 135 );
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size( 99 , 17 );
			this.label9.TabIndex = 10;
			this.label9.Text = "Omschrijving";
			// 
			// commissionerLabel
			// 
			this.commissionerLabel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.commissionerLabel.AutoSize = true;
			this.commissionerLabel.BackColor = System.Drawing.Color.Transparent;
			this.commissionerLabel.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.commissionerLabel.Location = new System.Drawing.Point( 549 , 16 );
			this.commissionerLabel.Name = "commissionerLabel";
			this.commissionerLabel.Size = new System.Drawing.Size( 152 , 16 );
			this.commissionerLabel.TabIndex = 9;
			this.commissionerLabel.Text = "Hooyberghs Johnny";
			// 
			// label3
			// 
			this.label3.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.label3.Location = new System.Drawing.Point( 431 , 14 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 112 , 17 );
			this.label3.TabIndex = 8;
			this.label3.Text = "Opdrachtgever";
			// 
			// toLabel
			// 
			this.toLabel.AutoSize = true;
			this.toLabel.BackColor = System.Drawing.Color.Transparent;
			this.toLabel.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.toLabel.Location = new System.Drawing.Point( 136 , 83 );
			this.toLabel.Name = "toLabel";
			this.toLabel.Size = new System.Drawing.Size( 49 , 16 );
			this.toLabel.TabIndex = 7;
			this.toLabel.Text = "23:30";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.label6.Location = new System.Drawing.Point( 98 , 82 );
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size( 32 , 17 );
			this.label6.TabIndex = 6;
			this.label6.Text = "Tot";
			// 
			// fromLabel
			// 
			this.fromLabel.AutoSize = true;
			this.fromLabel.BackColor = System.Drawing.Color.Transparent;
			this.fromLabel.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.fromLabel.Location = new System.Drawing.Point( 136 , 49 );
			this.fromLabel.Name = "fromLabel";
			this.fromLabel.Size = new System.Drawing.Size( 49 , 16 );
			this.fromLabel.TabIndex = 4;
			this.fromLabel.Text = "23:00";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.label4.Location = new System.Drawing.Point( 95 , 48 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 35 , 17 );
			this.label4.TabIndex = 3;
			this.label4.Text = "Van";
			// 
			// dateLabel
			// 
			this.dateLabel.AutoSize = true;
			this.dateLabel.BackColor = System.Drawing.Color.Transparent;
			this.dateLabel.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.dateLabel.Location = new System.Drawing.Point( 136 , 15 );
			this.dateLabel.Name = "dateLabel";
			this.dateLabel.Size = new System.Drawing.Size( 186 , 16 );
			this.dateLabel.TabIndex = 1;
			this.dateLabel.Text = "maandag 30 maart 2009";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.label1.Location = new System.Drawing.Point( 34 , 14 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 96 , 17 );
			this.label1.TabIndex = 0;
			this.label1.Text = "Overuren op";
			// 
			// OvertimeDetailControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.statusGroup );
			this.Name = "OvertimeDetailControl";
			this.Size = new System.Drawing.Size( 763 , 264 );
			this.statusGroup.ResumeLayout( false );
			this.statusGroup.PerformLayout();
			this.ResumeLayout( false );

		}

		#endregion

		private SwmSuite.Presentation.Common.StatusGroup.StatusGroupControl statusGroup;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox descriptionTextBox;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label commissionerLabel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label toLabel;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label fromLabel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label dateLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label employeeLabel;
		private System.Windows.Forms.Label employeeTitleLabel;
	}
}
