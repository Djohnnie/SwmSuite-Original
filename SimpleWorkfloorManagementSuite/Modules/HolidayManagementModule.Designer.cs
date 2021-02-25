namespace SimpleWorkfloorManagementSuite.Modules {
	partial class HolidayManagementModule {
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( HolidayManagementModule ) );
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.overtimeToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.holidayToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.nextYearToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.yearToolStripLabel = new System.Windows.Forms.ToolStripLabel();
			this.previousYearToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.saldiToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.denyToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.acceptToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.employeeTreeView = new SwmSuite.Presentation.Common.BrowserTreeView.BrowserTreeViewControl();
			this.ImageList = new System.Windows.Forms.ImageList( this.components );
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.overtimeBrowserView = new SimpleWorkfloorManagementSuite.Controls.OvertimeBrowserViewControl();
			this.overtimeDetail = new SimpleWorkfloorManagementSuite.Controls.OvertimeDetailControl();
			this.toolStrip.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
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
            this.acceptToolStripButton,
            this.denyToolStripButton} );
			this.toolStrip.Location = new System.Drawing.Point( 0 , 0 );
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size( 864 , 35 );
			this.toolStrip.TabIndex = 38;
			this.toolStrip.Text = "toolStrip1";
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
			// yearToolStripLabel
			// 
			this.yearToolStripLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.yearToolStripLabel.Name = "yearToolStripLabel";
			this.yearToolStripLabel.Size = new System.Drawing.Size( 31 , 32 );
			this.yearToolStripLabel.Text = "2009";
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
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size( 6 , 35 );
			// 
			// denyToolStripButton
			// 
			this.denyToolStripButton.Enabled = false;
			this.denyToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.overtime_deny;
			this.denyToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.denyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.denyToolStripButton.Name = "denyToolStripButton";
			this.denyToolStripButton.Size = new System.Drawing.Size( 205 , 32 );
			this.denyToolStripButton.Text = "Gepresteerde overuren weigeren";
			this.denyToolStripButton.Click += new System.EventHandler( this.denyToolStripButton_Click );
			// 
			// acceptToolStripButton
			// 
			this.acceptToolStripButton.Enabled = false;
			this.acceptToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.overtime_accept;
			this.acceptToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.acceptToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.acceptToolStripButton.Name = "acceptToolStripButton";
			this.acceptToolStripButton.Size = new System.Drawing.Size( 218 , 32 );
			this.acceptToolStripButton.Text = "Gepresteerde overuren aanvaarden";
			this.acceptToolStripButton.Click += new System.EventHandler( this.acceptToolStripButton_Click );
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point( 0 , 35 );
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add( this.employeeTreeView );
			this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding( 5 , 5 , 0 , 5 );
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add( this.splitContainer2 );
			this.splitContainer1.Size = new System.Drawing.Size( 864 , 575 );
			this.splitContainer1.SplitterDistance = 288;
			this.splitContainer1.TabIndex = 39;
			// 
			// employeeTreeView
			// 
			this.employeeTreeView.AllowDrop = true;
			this.employeeTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.employeeTreeView.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.employeeTreeView.FullRowSelect = true;
			this.employeeTreeView.HideSelection = false;
			this.employeeTreeView.ImageIndex = 2;
			this.employeeTreeView.ImageList = this.ImageList;
			this.employeeTreeView.Location = new System.Drawing.Point( 5 , 5 );
			this.employeeTreeView.Name = "employeeTreeView";
			this.employeeTreeView.SelectedImageIndex = 2;
			this.employeeTreeView.Size = new System.Drawing.Size( 283 , 565 );
			this.employeeTreeView.TabIndex = 39;
			this.employeeTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.employeeTreeView_AfterSelect );
			// 
			// ImageList
			// 
			this.ImageList.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "ImageList.ImageStream" ) ) );
			this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.ImageList.Images.SetKeyName( 0 , "everyone.png" );
			this.ImageList.Images.SetKeyName( 1 , "employeegroup.png" );
			this.ImageList.Images.SetKeyName( 2 , "employee.png" );
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point( 0 , 0 );
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add( this.overtimeBrowserView );
			this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding( 0 , 5 , 5 , 0 );
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add( this.overtimeDetail );
			this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding( 0 , 0 , 5 , 5 );
			this.splitContainer2.Size = new System.Drawing.Size( 572 , 575 );
			this.splitContainer2.SplitterDistance = 307;
			this.splitContainer2.TabIndex = 40;
			// 
			// overtimeBrowserView
			// 
			this.overtimeBrowserView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.overtimeBrowserView.Location = new System.Drawing.Point( 0 , 5 );
			this.overtimeBrowserView.Name = "overtimeBrowserView";
			this.overtimeBrowserView.Size = new System.Drawing.Size( 567 , 302 );
			this.overtimeBrowserView.TabIndex = 0;
			this.overtimeBrowserView.SelectedOvertimeEntryChanged += new System.EventHandler<SimpleWorkfloorManagementSuite.Controls.SelectedOvertimeEntryChangedEventArgs>( this.overtimeBrowserView_SelectedOvertimeEntryChanged );
			// 
			// overtimeDetail
			// 
			this.overtimeDetail.DisplayEmployee = true;
			this.overtimeDetail.Dock = System.Windows.Forms.DockStyle.Fill;
			this.overtimeDetail.Location = new System.Drawing.Point( 0 , 0 );
			this.overtimeDetail.Name = "overtimeDetail";
			this.overtimeDetail.OvertimeEntry = null;
			this.overtimeDetail.Size = new System.Drawing.Size( 567 , 259 );
			this.overtimeDetail.TabIndex = 0;
			// 
			// HolidayManagementModule
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add( this.splitContainer1 );
			this.Controls.Add( this.toolStrip );
			this.Name = "HolidayManagementModule";
			this.Size = new System.Drawing.Size( 864 , 610 );
			this.Load += new System.EventHandler( this.HolidayManagementModule_Load );
			this.toolStrip.ResumeLayout( false );
			this.toolStrip.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout( false );
			this.splitContainer1.Panel2.ResumeLayout( false );
			this.splitContainer1.ResumeLayout( false );
			this.splitContainer2.Panel1.ResumeLayout( false );
			this.splitContainer2.Panel2.ResumeLayout( false );
			this.splitContainer2.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton overtimeToolStripButton;
		private System.Windows.Forms.ToolStripButton holidayToolStripButton;
		private System.Windows.Forms.ToolStripButton nextYearToolStripButton;
		private System.Windows.Forms.ToolStripLabel yearToolStripLabel;
		private System.Windows.Forms.ToolStripButton previousYearToolStripButton;
		private System.Windows.Forms.ToolStripButton saldiToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private SimpleWorkfloorManagementSuite.Controls.OvertimeBrowserViewControl overtimeBrowserView;
		private SimpleWorkfloorManagementSuite.Controls.OvertimeDetailControl overtimeDetail;
		private SwmSuite.Presentation.Common.BrowserTreeView.BrowserTreeViewControl employeeTreeView;
		private System.Windows.Forms.ImageList ImageList;
		private System.Windows.Forms.ToolStripButton denyToolStripButton;
		private System.Windows.Forms.ToolStripButton acceptToolStripButton;
	}
}
