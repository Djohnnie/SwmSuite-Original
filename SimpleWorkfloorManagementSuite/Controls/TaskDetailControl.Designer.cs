namespace SimpleWorkfloorManagementSuite.Controls {
	partial class TaskDetailControl {
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
			this.commissionerLabel = new System.Windows.Forms.Label();
			this.commissionerTitleLabel = new System.Windows.Forms.Label();
			this.deadlineLabel = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.subjectLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.label9 = new System.Windows.Forms.Label();
			this.descriptionTextBox = new System.Windows.Forms.TextBox();
			this.commentsLabel = new System.Windows.Forms.Label();
			this.commentsTextBox = new System.Windows.Forms.TextBox();
			this.taskRunLabel = new System.Windows.Forms.Label();
			this.taskRunTitleLabel = new System.Windows.Forms.Label();
			this.statusGroup.SuspendLayout();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusGroup
			// 
			this.statusGroup.Controls.Add( this.employeeLabel );
			this.statusGroup.Controls.Add( this.employeeTitleLabel );
			this.statusGroup.Controls.Add( this.statusLabel );
			this.statusGroup.Controls.Add( this.label10 );
			this.statusGroup.Controls.Add( this.commissionerLabel );
			this.statusGroup.Controls.Add( this.commissionerTitleLabel );
			this.statusGroup.Controls.Add( this.deadlineLabel );
			this.statusGroup.Controls.Add( this.label4 );
			this.statusGroup.Controls.Add( this.subjectLabel );
			this.statusGroup.Controls.Add( this.label1 );
			this.statusGroup.Controls.Add( this.splitContainer );
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
			this.statusGroup.Size = new System.Drawing.Size( 820 , 324 );
			this.statusGroup.Status = SwmSuite.Presentation.Common.StatusGroup.StatusGroupStatus.Invalid;
			this.statusGroup.TabIndex = 4;
			// 
			// employeeLabel
			// 
			this.employeeLabel.AutoSize = true;
			this.employeeLabel.BackColor = System.Drawing.Color.Transparent;
			this.employeeLabel.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.employeeLabel.Location = new System.Drawing.Point( 153 , 27 );
			this.employeeLabel.Name = "employeeLabel";
			this.employeeLabel.Size = new System.Drawing.Size( 152 , 16 );
			this.employeeLabel.TabIndex = 16;
			this.employeeLabel.Text = "Hooyberghs Johnny";
			// 
			// employeeTitleLabel
			// 
			this.employeeTitleLabel.AutoSize = true;
			this.employeeTitleLabel.BackColor = System.Drawing.Color.Transparent;
			this.employeeTitleLabel.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.employeeTitleLabel.Location = new System.Drawing.Point( 25 , 27 );
			this.employeeTitleLabel.Name = "employeeTitleLabel";
			this.employeeTitleLabel.Size = new System.Drawing.Size( 122 , 17 );
			this.employeeTitleLabel.TabIndex = 15;
			this.employeeTitleLabel.Text = "Uitgevoerd door";
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.BackColor = System.Drawing.Color.Transparent;
			this.statusLabel.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.statusLabel.Location = new System.Drawing.Point( 86 , 50 );
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size( 116 , 16 );
			this.statusLabel.TabIndex = 14;
			this.statusLabel.Text = "In behandeling";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.BackColor = System.Drawing.Color.Transparent;
			this.label10.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.label10.Location = new System.Drawing.Point( 25 , 49 );
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size( 55 , 17 );
			this.label10.TabIndex = 13;
			this.label10.Text = "Status";
			// 
			// commissionerLabel
			// 
			this.commissionerLabel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.commissionerLabel.AutoSize = true;
			this.commissionerLabel.BackColor = System.Drawing.Color.Transparent;
			this.commissionerLabel.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.commissionerLabel.Location = new System.Drawing.Point( 590 , 50 );
			this.commissionerLabel.Name = "commissionerLabel";
			this.commissionerLabel.Size = new System.Drawing.Size( 152 , 16 );
			this.commissionerLabel.TabIndex = 9;
			this.commissionerLabel.Text = "Hooyberghs Johnny";
			// 
			// commissionerTitleLabel
			// 
			this.commissionerTitleLabel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.commissionerTitleLabel.AutoSize = true;
			this.commissionerTitleLabel.BackColor = System.Drawing.Color.Transparent;
			this.commissionerTitleLabel.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.commissionerTitleLabel.Location = new System.Drawing.Point( 472 , 49 );
			this.commissionerTitleLabel.Name = "commissionerTitleLabel";
			this.commissionerTitleLabel.Size = new System.Drawing.Size( 112 , 17 );
			this.commissionerTitleLabel.TabIndex = 8;
			this.commissionerTitleLabel.Text = "Opdrachtgever";
			// 
			// deadlineLabel
			// 
			this.deadlineLabel.AutoSize = true;
			this.deadlineLabel.BackColor = System.Drawing.Color.Transparent;
			this.deadlineLabel.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.deadlineLabel.Location = new System.Drawing.Point( 98 , 72 );
			this.deadlineLabel.Name = "deadlineLabel";
			this.deadlineLabel.Size = new System.Drawing.Size( 46 , 16 );
			this.deadlineLabel.TabIndex = 4;
			this.deadlineLabel.Text = "GEEN";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.label4.Location = new System.Drawing.Point( 25 , 71 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 67 , 17 );
			this.label4.TabIndex = 3;
			this.label4.Text = "Deadline";
			// 
			// subjectLabel
			// 
			this.subjectLabel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.subjectLabel.BackColor = System.Drawing.Color.Transparent;
			this.subjectLabel.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.subjectLabel.Location = new System.Drawing.Point( 116 , 5 );
			this.subjectLabel.Name = "subjectLabel";
			this.subjectLabel.Size = new System.Drawing.Size( 692 , 16 );
			this.subjectLabel.TabIndex = 1;
			this.subjectLabel.Text = "ONDERWERP";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.label1.Location = new System.Drawing.Point( 25 , 5 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 85 , 17 );
			this.label1.TabIndex = 0;
			this.label1.Text = "Onderwerp";
			// 
			// splitContainer
			// 
			this.splitContainer.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.splitContainer.BackColor = System.Drawing.Color.White;
			this.splitContainer.Location = new System.Drawing.Point( 24 , 91 );
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add( this.label9 );
			this.splitContainer.Panel1.Controls.Add( this.descriptionTextBox );
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add( this.commentsLabel );
			this.splitContainer.Panel2.Controls.Add( this.commentsTextBox );
			this.splitContainer.Panel2.Controls.Add( this.taskRunTitleLabel );
			this.splitContainer.Panel2.Controls.Add( this.taskRunLabel );
			this.splitContainer.Size = new System.Drawing.Size( 793 , 230 );
			this.splitContainer.SplitterDistance = 116;
			this.splitContainer.TabIndex = 17;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.BackColor = System.Drawing.Color.Transparent;
			this.label9.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.label9.Location = new System.Drawing.Point( 1 , 0 );
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size( 99 , 17 );
			this.label9.TabIndex = 10;
			this.label9.Text = "Omschrijving";
			// 
			// descriptionTextBox
			// 
			this.descriptionTextBox.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.descriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.descriptionTextBox.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Bold );
			this.descriptionTextBox.Location = new System.Drawing.Point( 112 , 0 );
			this.descriptionTextBox.Multiline = true;
			this.descriptionTextBox.Name = "descriptionTextBox";
			this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.descriptionTextBox.Size = new System.Drawing.Size( 672 , 113 );
			this.descriptionTextBox.TabIndex = 12;
			// 
			// commentsLabel
			// 
			this.commentsLabel.AutoSize = true;
			this.commentsLabel.BackColor = System.Drawing.Color.Transparent;
			this.commentsLabel.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.commentsLabel.Location = new System.Drawing.Point( 1 , 20 );
			this.commentsLabel.Name = "commentsLabel";
			this.commentsLabel.Size = new System.Drawing.Size( 101 , 17 );
			this.commentsLabel.TabIndex = 13;
			this.commentsLabel.Text = "Opmerkingen";
			// 
			// commentsTextBox
			// 
			this.commentsTextBox.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.commentsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.commentsTextBox.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Bold );
			this.commentsTextBox.Location = new System.Drawing.Point( 106 , 20 );
			this.commentsTextBox.Multiline = true;
			this.commentsTextBox.Name = "commentsTextBox";
			this.commentsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.commentsTextBox.Size = new System.Drawing.Size( 678 , 87 );
			this.commentsTextBox.TabIndex = 14;
			// 
			// taskRunLabel
			// 
			this.taskRunLabel.AutoSize = true;
			this.taskRunLabel.BackColor = System.Drawing.Color.Transparent;
			this.taskRunLabel.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.taskRunLabel.Location = new System.Drawing.Point( 103 , 1 );
			this.taskRunLabel.Name = "taskRunLabel";
			this.taskRunLabel.Size = new System.Drawing.Size( 98 , 16 );
			this.taskRunLabel.TabIndex = 19;
			this.taskRunLabel.Text = "10/10/2000";
			// 
			// taskRunTitleLabel
			// 
			this.taskRunTitleLabel.AutoSize = true;
			this.taskRunTitleLabel.BackColor = System.Drawing.Color.Transparent;
			this.taskRunTitleLabel.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.taskRunTitleLabel.Location = new System.Drawing.Point( 1 , 0 );
			this.taskRunTitleLabel.Name = "taskRunTitleLabel";
			this.taskRunTitleLabel.Size = new System.Drawing.Size( 96 , 17 );
			this.taskRunTitleLabel.TabIndex = 18;
			this.taskRunTitleLabel.Text = "Afgepunt op";
			// 
			// TaskDetailControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.statusGroup );
			this.Name = "TaskDetailControl";
			this.Size = new System.Drawing.Size( 820 , 324 );
			this.statusGroup.ResumeLayout( false );
			this.statusGroup.PerformLayout();
			this.splitContainer.Panel1.ResumeLayout( false );
			this.splitContainer.Panel1.PerformLayout();
			this.splitContainer.Panel2.ResumeLayout( false );
			this.splitContainer.Panel2.PerformLayout();
			this.splitContainer.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		private SwmSuite.Presentation.Common.StatusGroup.StatusGroupControl statusGroup;
		private System.Windows.Forms.Label employeeLabel;
		private System.Windows.Forms.Label employeeTitleLabel;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox descriptionTextBox;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label commissionerLabel;
		private System.Windows.Forms.Label commissionerTitleLabel;
		private System.Windows.Forms.Label deadlineLabel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label subjectLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.Label commentsLabel;
		private System.Windows.Forms.TextBox commentsTextBox;
		private System.Windows.Forms.Label taskRunLabel;
		private System.Windows.Forms.Label taskRunTitleLabel;
	}
}
