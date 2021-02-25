namespace SimpleWorkfloorManagementSuite.Modules {
	partial class TaskManagementModule {
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
			SimpleWorkfloorManagementSuite.Controls.TaskContentsRenderer taskContentsRenderer1 = new SimpleWorkfloorManagementSuite.Controls.TaskContentsRenderer();
			SimpleWorkfloorManagementSuite.Controls.TaskContentsScheme taskContentsScheme1 = new SimpleWorkfloorManagementSuite.Controls.TaskContentsScheme();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( TaskManagementModule ) );
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.pendingTasksToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.finishedTasksToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.dueTasksToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.allTasksToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.newTaskToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.nextYearToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.yearToolStripLabel = new System.Windows.Forms.ToolStripLabel();
			this.previousYearToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.taskBrowserViewControl = new SimpleWorkfloorManagementSuite.Controls.TaskBrowserViewControl();
			this.taskDetailControl1 = new SimpleWorkfloorManagementSuite.Controls.TaskDetailControl();
			this.taskContentsControl = new SimpleWorkfloorManagementSuite.Controls.TaskContentsControl();
			this.ImageList = new System.Windows.Forms.ImageList( this.components );
			this.employeeTreeView = new SwmSuite.Presentation.Common.BrowserTreeView.BrowserTreeViewControl();
			this.toolStrip.SuspendLayout();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.toolStrip.AutoSize = false;
			this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.pendingTasksToolStripButton,
            this.finishedTasksToolStripButton,
            this.dueTasksToolStripButton,
            this.allTasksToolStripButton,
            this.toolStripSeparator1,
            this.newTaskToolStripButton,
            this.nextYearToolStripButton,
            this.yearToolStripLabel,
            this.previousYearToolStripButton} );
			this.toolStrip.Location = new System.Drawing.Point( 0 , 0 );
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size( 848 , 35 );
			this.toolStrip.TabIndex = 34;
			this.toolStrip.Text = "toolStrip1";
			// 
			// pendingTasksToolStripButton
			// 
			this.pendingTasksToolStripButton.Checked = true;
			this.pendingTasksToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
			this.pendingTasksToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.task_pending;
			this.pendingTasksToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.pendingTasksToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.pendingTasksToolStripButton.Name = "pendingTasksToolStripButton";
			this.pendingTasksToolStripButton.Size = new System.Drawing.Size( 113 , 32 );
			this.pendingTasksToolStripButton.Text = "Lopende taken";
			this.pendingTasksToolStripButton.ToolTipText = "Alle lopende taken bekijken";
			this.pendingTasksToolStripButton.Click += new System.EventHandler( this.pendingTasksToolStripButton_Click );
			// 
			// finishedTasksToolStripButton
			// 
			this.finishedTasksToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.tasks_finished1;
			this.finishedTasksToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.finishedTasksToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.finishedTasksToolStripButton.Name = "finishedTasksToolStripButton";
			this.finishedTasksToolStripButton.Size = new System.Drawing.Size( 127 , 32 );
			this.finishedTasksToolStripButton.Text = "Afgewerkte taken";
			this.finishedTasksToolStripButton.ToolTipText = "Alle afgewerkte taken bekijken";
			this.finishedTasksToolStripButton.Click += new System.EventHandler( this.finishedTasksToolStripButton_Click );
			// 
			// dueTasksToolStripButton
			// 
			this.dueTasksToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.tasks_overdue;
			this.dueTasksToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.dueTasksToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.dueTasksToolStripButton.Name = "dueTasksToolStripButton";
			this.dueTasksToolStripButton.Size = new System.Drawing.Size( 152 , 32 );
			this.dueTasksToolStripButton.Text = "Taken buiten deadline";
			this.dueTasksToolStripButton.ToolTipText = "Alle taken buiten deadline bekijken";
			this.dueTasksToolStripButton.Click += new System.EventHandler( this.dueTasksToolStripButton_Click );
			// 
			// allTasksToolStripButton
			// 
			this.allTasksToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.tasks_all;
			this.allTasksToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.allTasksToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.allTasksToolStripButton.Name = "allTasksToolStripButton";
			this.allTasksToolStripButton.Size = new System.Drawing.Size( 87 , 32 );
			this.allTasksToolStripButton.Text = "Alle taken";
			this.allTasksToolStripButton.ToolTipText = "Alle taken bekijken";
			this.allTasksToolStripButton.Click += new System.EventHandler( this.allTasksToolStripButton_Click );
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size( 6 , 35 );
			// 
			// newTaskToolStripButton
			// 
			this.newTaskToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.tasks_add;
			this.newTaskToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.newTaskToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newTaskToolStripButton.Name = "newTaskToolStripButton";
			this.newTaskToolStripButton.Size = new System.Drawing.Size( 158 , 32 );
			this.newTaskToolStripButton.Text = "Nieuwe taak aanmaken";
			this.newTaskToolStripButton.Click += new System.EventHandler( this.newTaskToolStripButton_Click );
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
			// splitContainer
			// 
			this.splitContainer.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.splitContainer.Location = new System.Drawing.Point( 255 , 38 );
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add( this.taskBrowserViewControl );
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add( this.taskDetailControl1 );
			this.splitContainer.Panel2.Controls.Add( this.taskContentsControl );
			this.splitContainer.Size = new System.Drawing.Size( 588 , 573 );
			this.splitContainer.SplitterDistance = 317;
			this.splitContainer.TabIndex = 37;
			// 
			// taskBrowserViewControl
			// 
			this.taskBrowserViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.taskBrowserViewControl.Location = new System.Drawing.Point( 0 , 0 );
			this.taskBrowserViewControl.Name = "taskBrowserViewControl";
			this.taskBrowserViewControl.Size = new System.Drawing.Size( 588 , 317 );
			this.taskBrowserViewControl.TabIndex = 0;
			this.taskBrowserViewControl.SelectedTaskChanged += new System.EventHandler<SimpleWorkfloorManagementSuite.Controls.SelectedTaskChangedEventArgs>( this.taskBrowserViewControl_SelectedTaskChanged );
			// 
			// taskDetailControl1
			// 
			this.taskDetailControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.taskDetailControl1.Location = new System.Drawing.Point( 0 , 0 );
			this.taskDetailControl1.Name = "taskDetailControl1";
			this.taskDetailControl1.Size = new System.Drawing.Size( 588 , 252 );
			this.taskDetailControl1.TabIndex = 2;
			this.taskDetailControl1.Task = null;
			// 
			// taskContentsControl
			// 
			this.taskContentsControl.BackColor = System.Drawing.Color.White;
			this.taskContentsControl.Deadline = null;
			this.taskContentsControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.taskContentsControl.From = null;
			this.taskContentsControl.Location = new System.Drawing.Point( 0 , 0 );
			this.taskContentsControl.Name = "taskContentsControl";
			this.taskContentsControl.Renderer = taskContentsRenderer1;
			taskContentsScheme1.BigFont = new System.Drawing.Font( "Verdana" , 11F , System.Drawing.FontStyle.Bold );
			taskContentsScheme1.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			taskContentsScheme1.SmallFont = new System.Drawing.Font( "Verdana" , 9F );
			taskContentsScheme1.TextColor = System.Drawing.Color.White;
			taskContentsScheme1.TitleBackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 10 ) ) ) ) , ( (int)( ( (byte)( 75 ) ) ) ) , ( (int)( ( (byte)( 115 ) ) ) ) );
			taskContentsScheme1.TitleBackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 50 ) ) ) ) , ( (int)( ( (byte)( 175 ) ) ) ) , ( (int)( ( (byte)( 175 ) ) ) ) );
			this.taskContentsControl.Scheme = taskContentsScheme1;
			this.taskContentsControl.Size = new System.Drawing.Size( 588 , 252 );
			this.taskContentsControl.TabIndex = 1;
			this.taskContentsControl.Title = null;
			this.taskContentsControl.TitleHeight = 75;
			// 
			// ImageList
			// 
			this.ImageList.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "ImageList.ImageStream" ) ) );
			this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.ImageList.Images.SetKeyName( 0 , "everyone.png" );
			this.ImageList.Images.SetKeyName( 1 , "employeegroup.png" );
			this.ImageList.Images.SetKeyName( 2 , "employee.png" );
			// 
			// employeeTreeView
			// 
			this.employeeTreeView.AllowDrop = true;
			this.employeeTreeView.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Left ) ) );
			this.employeeTreeView.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.employeeTreeView.FullRowSelect = true;
			this.employeeTreeView.HideSelection = false;
			this.employeeTreeView.ImageIndex = 2;
			this.employeeTreeView.ImageList = this.ImageList;
			this.employeeTreeView.Location = new System.Drawing.Point( 3 , 38 );
			this.employeeTreeView.Name = "employeeTreeView";
			this.employeeTreeView.SelectedImageIndex = 2;
			this.employeeTreeView.Size = new System.Drawing.Size( 249 , 573 );
			this.employeeTreeView.TabIndex = 38;
			this.employeeTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.employeeTreeView_AfterSelect );
			// 
			// TaskManagementModule
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add( this.employeeTreeView );
			this.Controls.Add( this.splitContainer );
			this.Controls.Add( this.toolStrip );
			this.Name = "TaskManagementModule";
			this.Size = new System.Drawing.Size( 846 , 614 );
			this.Load += new System.EventHandler( this.TaskManagementModule_Load );
			this.toolStrip.ResumeLayout( false );
			this.toolStrip.PerformLayout();
			this.splitContainer.Panel1.ResumeLayout( false );
			this.splitContainer.Panel2.ResumeLayout( false );
			this.splitContainer.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton newTaskToolStripButton;
		private System.Windows.Forms.ToolStripButton pendingTasksToolStripButton;
		private System.Windows.Forms.ToolStripButton finishedTasksToolStripButton;
		private System.Windows.Forms.ToolStripButton dueTasksToolStripButton;
		private System.Windows.Forms.ToolStripButton allTasksToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.SplitContainer splitContainer;
		private SimpleWorkfloorManagementSuite.Controls.TaskBrowserViewControl taskBrowserViewControl;
		private SwmSuite.Presentation.Common.BrowserTreeView.BrowserTreeViewControl employeeTreeView;
		private System.Windows.Forms.ImageList ImageList;
		private SimpleWorkfloorManagementSuite.Controls.TaskContentsControl taskContentsControl;
		private SimpleWorkfloorManagementSuite.Controls.TaskDetailControl taskDetailControl1;
		private System.Windows.Forms.ToolStripButton nextYearToolStripButton;
		private System.Windows.Forms.ToolStripLabel yearToolStripLabel;
		private System.Windows.Forms.ToolStripButton previousYearToolStripButton;
	}
}
