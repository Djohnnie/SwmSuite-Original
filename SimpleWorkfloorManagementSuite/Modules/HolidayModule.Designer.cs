namespace SimpleWorkfloorManagementSuite.Modules {
	partial class HolidayModule {
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
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.yearToolStripLabel = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.overtimeBrowserView = new SimpleWorkfloorManagementSuite.Controls.OvertimeBrowserViewControl();
			this.overtimeDetail = new SimpleWorkfloorManagementSuite.Controls.OvertimeDetailControl();
			this.overtimeToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.holidayToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.nextYearToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.previousYearToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.saldiToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.insertOvertimeToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStrip.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.AutoSize = false;
			this.toolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.overtimeToolStripButton,
            this.holidayToolStripButton,
            this.nextYearToolStripButton,
            this.yearToolStripLabel,
            this.previousYearToolStripButton,
            this.saldiToolStripButton,
            this.toolStripSeparator1,
            this.insertOvertimeToolStripButton} );
			this.toolStrip.Location = new System.Drawing.Point( 0 , 0 );
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size( 853 , 35 );
			this.toolStrip.TabIndex = 36;
			this.toolStrip.Text = "toolStrip1";
			// 
			// yearToolStripLabel
			// 
			this.yearToolStripLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.yearToolStripLabel.Name = "yearToolStripLabel";
			this.yearToolStripLabel.Size = new System.Drawing.Size( 31 , 32 );
			this.yearToolStripLabel.Text = "2009";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size( 6 , 35 );
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.splitContainer1.Location = new System.Drawing.Point( 3 , 38 );
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add( this.overtimeBrowserView );
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add( this.overtimeDetail );
			this.splitContainer1.Size = new System.Drawing.Size( 847 , 557 );
			this.splitContainer1.SplitterDistance = 317;
			this.splitContainer1.TabIndex = 37;
			// 
			// overtimeBrowserView
			// 
			this.overtimeBrowserView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.overtimeBrowserView.Location = new System.Drawing.Point( 0 , 0 );
			this.overtimeBrowserView.Name = "overtimeBrowserView";
			this.overtimeBrowserView.Size = new System.Drawing.Size( 847 , 317 );
			this.overtimeBrowserView.TabIndex = 0;
			this.overtimeBrowserView.SelectedOvertimeEntryChanged += new System.EventHandler<SimpleWorkfloorManagementSuite.Controls.SelectedOvertimeEntryChangedEventArgs>( this.overtimeBrowserView_SelectedOvertimeEntryChanged );
			// 
			// overtimeDetail
			// 
			this.overtimeDetail.DisplayEmployee = false;
			this.overtimeDetail.Dock = System.Windows.Forms.DockStyle.Fill;
			this.overtimeDetail.Location = new System.Drawing.Point( 0 , 0 );
			this.overtimeDetail.Name = "overtimeDetail";
			this.overtimeDetail.OvertimeEntry = null;
			this.overtimeDetail.Size = new System.Drawing.Size( 847 , 236 );
			this.overtimeDetail.TabIndex = 0;
			// 
			// overtimeToolStripButton
			// 
			this.overtimeToolStripButton.Checked = true;
			this.overtimeToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
			this.overtimeToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.overtime;
			this.overtimeToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.overtimeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.overtimeToolStripButton.Name = "overtimeToolStripButton";
			this.overtimeToolStripButton.Size = new System.Drawing.Size( 84 , 32 );
			this.overtimeToolStripButton.Text = "Overuren";
			this.overtimeToolStripButton.Click += new System.EventHandler( this.overtimeToolStripButton_Click );
			// 
			// holidayToolStripButton
			// 
			this.holidayToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.logboek;
			this.holidayToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.holidayToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.holidayToolStripButton.Name = "holidayToolStripButton";
			this.holidayToolStripButton.Size = new System.Drawing.Size( 66 , 32 );
			this.holidayToolStripButton.Text = "Verlof";
			this.holidayToolStripButton.Visible = false;
			this.holidayToolStripButton.Click += new System.EventHandler( this.holidayToolStripButton_Click );
			// 
			// nextYearToolStripButton
			// 
			this.nextYearToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.nextYearToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.nextYearToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.next_year;
			this.nextYearToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.nextYearToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.nextYearToolStripButton.Name = "nextYearToolStripButton";
			this.nextYearToolStripButton.Size = new System.Drawing.Size( 23 , 32 );
			this.nextYearToolStripButton.Text = "Verlof";
			this.nextYearToolStripButton.Click += new System.EventHandler( this.nextYearToolStripButton_Click );
			// 
			// previousYearToolStripButton
			// 
			this.previousYearToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.previousYearToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.previousYearToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.previous_year;
			this.previousYearToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.previousYearToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.previousYearToolStripButton.Name = "previousYearToolStripButton";
			this.previousYearToolStripButton.Size = new System.Drawing.Size( 23 , 32 );
			this.previousYearToolStripButton.Text = "Verlof";
			this.previousYearToolStripButton.Click += new System.EventHandler( this.previousYearToolStripButton_Click );
			// 
			// saldiToolStripButton
			// 
			this.saldiToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.logboek;
			this.saldiToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.saldiToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saldiToolStripButton.Name = "saldiToolStripButton";
			this.saldiToolStripButton.Size = new System.Drawing.Size( 60 , 32 );
			this.saldiToolStripButton.Text = "Saldi";
			this.saldiToolStripButton.Visible = false;
			this.saldiToolStripButton.Click += new System.EventHandler( this.saldiToolStripButton_Click );
			// 
			// insertOvertimeToolStripButton
			// 
			this.insertOvertimeToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.overtime_add;
			this.insertOvertimeToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.insertOvertimeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.insertOvertimeToolStripButton.Name = "insertOvertimeToolStripButton";
			this.insertOvertimeToolStripButton.Size = new System.Drawing.Size( 129 , 32 );
			this.insertOvertimeToolStripButton.Text = "Overuren ingeven";
			this.insertOvertimeToolStripButton.Click += new System.EventHandler( this.insertOvertimeToolStripButton_Click );
			// 
			// HolidayModule
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add( this.splitContainer1 );
			this.Controls.Add( this.toolStrip );
			this.Name = "HolidayModule";
			this.Size = new System.Drawing.Size( 853 , 598 );
			this.toolStrip.ResumeLayout( false );
			this.toolStrip.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout( false );
			this.splitContainer1.Panel2.ResumeLayout( false );
			this.splitContainer1.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton overtimeToolStripButton;
		private System.Windows.Forms.ToolStripButton holidayToolStripButton;
		private System.Windows.Forms.ToolStripButton previousYearToolStripButton;
		private System.Windows.Forms.ToolStripButton nextYearToolStripButton;
		private System.Windows.Forms.ToolStripLabel yearToolStripLabel;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton insertOvertimeToolStripButton;
		private System.Windows.Forms.ToolStripButton saldiToolStripButton;
		private SimpleWorkfloorManagementSuite.Controls.OvertimeBrowserViewControl overtimeBrowserView;
		private SimpleWorkfloorManagementSuite.Controls.OvertimeDetailControl overtimeDetail;
	}
}
