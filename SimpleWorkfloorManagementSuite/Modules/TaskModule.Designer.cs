namespace SimpleWorkfloorManagementSuite.Modules {
	partial class TaskModule {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( TaskModule ) );
			SimpleWorkfloorManagementSuite.Controls.TaskContentsRenderer taskContentsRenderer3 = new SimpleWorkfloorManagementSuite.Controls.TaskContentsRenderer();
			SimpleWorkfloorManagementSuite.Controls.TaskContentsScheme taskContentsScheme3 = new SimpleWorkfloorManagementSuite.Controls.TaskContentsScheme();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.pendingTasksToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.finishedTasksToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.dueTasksToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.allTasksToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.endTasksToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.taskBrowserViewControl = new SimpleWorkfloorManagementSuite.Controls.TaskBrowserViewControl();
			this.taskDetailControl = new SimpleWorkfloorManagementSuite.Controls.TaskDetailControl();
			this.taskContentsControl = new SimpleWorkfloorManagementSuite.Controls.TaskContentsControl();
			this.previousYearToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.yearToolStripLabel = new System.Windows.Forms.ToolStripLabel();
			this.nextYearToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStrip.SuspendLayout();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.AutoSize = false;
			this.toolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.pendingTasksToolStripButton,
            this.finishedTasksToolStripButton,
            this.dueTasksToolStripButton,
            this.allTasksToolStripButton,
            this.toolStripSeparator1,
            this.endTasksToolStripButton,
            this.nextYearToolStripButton,
            this.yearToolStripLabel,
            this.previousYearToolStripButton} );
			this.toolStrip.Location = new System.Drawing.Point( 0 , 0 );
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size( 822 , 35 );
			this.toolStrip.TabIndex = 34;
			this.toolStrip.Text = "toolStrip1";
			// 
			// pendingTasksToolStripButton
			// 
			this.pendingTasksToolStripButton.Checked = true;
			this.pendingTasksToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
			this.pendingTasksToolStripButton.Image = ( (System.Drawing.Image)( resources.GetObject( "pendingTasksToolStripButton.Image" ) ) );
			this.pendingTasksToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.pendingTasksToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.pendingTasksToolStripButton.Name = "pendingTasksToolStripButton";
			this.pendingTasksToolStripButton.Size = new System.Drawing.Size( 113 , 32 );
			this.pendingTasksToolStripButton.Text = "Lopende taken";
			this.pendingTasksToolStripButton.Click += new System.EventHandler( this.pendingTasksToolStripButton_Click );
			// 
			// finishedTasksToolStripButton
			// 
			this.finishedTasksToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.tasks_finished;
			this.finishedTasksToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.finishedTasksToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.finishedTasksToolStripButton.Name = "finishedTasksToolStripButton";
			this.finishedTasksToolStripButton.Size = new System.Drawing.Size( 127 , 32 );
			this.finishedTasksToolStripButton.Text = "Afgewerkte taken";
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
			this.allTasksToolStripButton.Click += new System.EventHandler( this.allTasksToolStripButton_Click );
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size( 6 , 35 );
			// 
			// endTasksToolStripButton
			// 
			this.endTasksToolStripButton.Enabled = false;
			this.endTasksToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.task_check;
			this.endTasksToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.endTasksToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.endTasksToolStripButton.Name = "endTasksToolStripButton";
			this.endTasksToolStripButton.Size = new System.Drawing.Size( 188 , 32 );
			this.endTasksToolStripButton.Text = "Geselecteerde taak afpuntent";
			this.endTasksToolStripButton.Click += new System.EventHandler( this.endTasksToolStripButton_Click );
			// 
			// splitContainer
			// 
			this.splitContainer.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.splitContainer.IsSplitterFixed = true;
			this.splitContainer.Location = new System.Drawing.Point( 3 , 38 );
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add( this.taskBrowserViewControl );
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add( this.taskDetailControl );
			this.splitContainer.Panel2.Controls.Add( this.taskContentsControl );
			this.splitContainer.Size = new System.Drawing.Size( 816 , 542 );
			this.splitContainer.SplitterDistance = 300;
			this.splitContainer.TabIndex = 36;
			// 
			// taskBrowserViewControl
			// 
			this.taskBrowserViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.taskBrowserViewControl.Location = new System.Drawing.Point( 0 , 0 );
			this.taskBrowserViewControl.Name = "taskBrowserViewControl";
			this.taskBrowserViewControl.Size = new System.Drawing.Size( 816 , 300 );
			this.taskBrowserViewControl.TabIndex = 0;
			this.taskBrowserViewControl.SelectedTaskChanged += new System.EventHandler<SimpleWorkfloorManagementSuite.Controls.SelectedTaskChangedEventArgs>( this.taskBrowserViewControl_SelectedTaskChanged );
			// 
			// taskDetailControl
			// 
			this.taskDetailControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.taskDetailControl.Location = new System.Drawing.Point( 0 , 0 );
			this.taskDetailControl.Name = "taskDetailControl";
			this.taskDetailControl.Size = new System.Drawing.Size( 816 , 238 );
			this.taskDetailControl.TabIndex = 37;
			this.taskDetailControl.Task = null;
			// 
			// taskContentsControl
			// 
			this.taskContentsControl.BackColor = System.Drawing.Color.White;
			this.taskContentsControl.Deadline = null;
			this.taskContentsControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.taskContentsControl.From = null;
			this.taskContentsControl.Location = new System.Drawing.Point( 0 , 0 );
			this.taskContentsControl.Name = "taskContentsControl";
			this.taskContentsControl.Renderer = taskContentsRenderer3;
			taskContentsScheme3.BigFont = new System.Drawing.Font( "Verdana" , 11F , System.Drawing.FontStyle.Bold );
			taskContentsScheme3.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			taskContentsScheme3.SmallFont = new System.Drawing.Font( "Verdana" , 10F );
			taskContentsScheme3.TextColor = System.Drawing.Color.White;
			taskContentsScheme3.TitleBackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 10 ) ) ) ) , ( (int)( ( (byte)( 75 ) ) ) ) , ( (int)( ( (byte)( 115 ) ) ) ) );
			taskContentsScheme3.TitleBackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 50 ) ) ) ) , ( (int)( ( (byte)( 175 ) ) ) ) , ( (int)( ( (byte)( 175 ) ) ) ) );
			this.taskContentsControl.Scheme = taskContentsScheme3;
			this.taskContentsControl.Size = new System.Drawing.Size( 816 , 238 );
			this.taskContentsControl.TabIndex = 36;
			this.taskContentsControl.Title = null;
			this.taskContentsControl.TitleHeight = 75;
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
			// yearToolStripLabel
			// 
			this.yearToolStripLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.yearToolStripLabel.Name = "yearToolStripLabel";
			this.yearToolStripLabel.Size = new System.Drawing.Size( 31 , 32 );
			this.yearToolStripLabel.Text = "2009";
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
			// TaskModule
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add( this.splitContainer );
			this.Controls.Add( this.toolStrip );
			this.Name = "TaskModule";
			this.Size = new System.Drawing.Size( 822 , 583 );
			this.Load += new System.EventHandler( this.TaskModule_Load );
			this.toolStrip.ResumeLayout( false );
			this.toolStrip.PerformLayout();
			this.splitContainer.Panel1.ResumeLayout( false );
			this.splitContainer.Panel2.ResumeLayout( false );
			this.splitContainer.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton pendingTasksToolStripButton;
		private System.Windows.Forms.ToolStripButton finishedTasksToolStripButton;
		private System.Windows.Forms.ToolStripButton dueTasksToolStripButton;
		private System.Windows.Forms.ToolStripButton allTasksToolStripButton;
		private System.Windows.Forms.SplitContainer splitContainer;
		private SimpleWorkfloorManagementSuite.Controls.TaskContentsControl taskContentsControl;
		private SimpleWorkfloorManagementSuite.Controls.TaskBrowserViewControl taskBrowserViewControl;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton endTasksToolStripButton;
		private SimpleWorkfloorManagementSuite.Controls.TaskDetailControl taskDetailControl;
		private System.Windows.Forms.ToolStripButton previousYearToolStripButton;
		private System.Windows.Forms.ToolStripLabel yearToolStripLabel;
		private System.Windows.Forms.ToolStripButton nextYearToolStripButton;
	}
}
