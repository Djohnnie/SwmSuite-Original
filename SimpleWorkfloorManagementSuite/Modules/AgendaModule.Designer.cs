namespace SimpleWorkfloorManagementSuite.Modules {
	partial class AgendaModule {
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
			SwmSuite.Presentation.Common.CheckList.CheckListRenderer checkListRenderer1 = new SwmSuite.Presentation.Common.CheckList.CheckListRenderer();
			SwmSuite.Presentation.Common.CheckList.CheckListScheme checkListScheme1 = new SwmSuite.Presentation.Common.CheckList.CheckListScheme();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( AgendaModule ) );
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.panel1 = new System.Windows.Forms.Panel();
			this.agendaControl = new SwmSuite.Presentation.Common.AgendaControl.AgendaControl();
			this.agendaCheckListControl = new SwmSuite.Presentation.Common.CheckList.CheckListControl();
			this.nextToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.selectionToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.previousToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.newAppointmentToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.editToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.removeAppointmentToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.agendaManagementToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.agendaViewToolStripButton = new System.Windows.Forms.ToolStripDropDownButton();
			this.dayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.weekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.AutoSize = false;
			this.toolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.nextToolStripButton,
            this.selectionToolStripButton,
            this.previousToolStripButton,
            this.newAppointmentToolStripButton,
            this.editToolStripButton,
            this.removeAppointmentToolStripButton,
            this.agendaManagementToolStripButton,
            this.toolStripSeparator3,
            this.agendaViewToolStripButton} );
			this.toolStrip.Location = new System.Drawing.Point( 0 , 0 );
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size( 869 , 35 );
			this.toolStrip.TabIndex = 33;
			this.toolStrip.Text = "toolStrip1";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size( 6 , 35 );
			// 
			// panel1
			// 
			this.panel1.Controls.Add( this.agendaControl );
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point( 0 , 35 );
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding( 5 );
			this.panel1.Size = new System.Drawing.Size( 869 , 503 );
			this.panel1.TabIndex = 34;
			// 
			// agendaControl
			// 
			this.agendaControl.BackColor = System.Drawing.Color.White;
			this.agendaControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.agendaControl.Location = new System.Drawing.Point( 5 , 5 );
			this.agendaControl.Name = "agendaControl";
			this.agendaControl.SelectionEnd = new System.DateTime( ( (long)( 0 ) ) );
			this.agendaControl.SelectionStart = new System.DateTime( 2009 , 5 , 18 , 0 , 0 , 0 , 0 );
			this.agendaControl.Size = new System.Drawing.Size( 859 , 493 );
			this.agendaControl.TabIndex = 0;
			this.agendaControl.ViewMode = SwmSuite.Presentation.Common.AgendaControl.AgendaViewMode.Week;
			this.agendaControl.AppointmentSelectionChanged += new System.EventHandler<SwmSuite.Presentation.Common.AgendaControl.AppointmentSelectionChangedEventArgs>( this.agendaControl_AppointmentSelectionChanged );
			this.agendaControl.NeedsUpdate += new System.EventHandler<SwmSuite.Presentation.Common.AgendaControl.AgendaNeedsUpdateEventArgs>( this.agendaControl_NeedsUpdate );
			// 
			// agendaCheckListControl
			// 
			this.agendaCheckListControl.BackColor = System.Drawing.Color.Transparent;
			this.agendaCheckListControl.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.agendaCheckListControl.Location = new System.Drawing.Point( 0 , 538 );
			this.agendaCheckListControl.Name = "agendaCheckListControl";
			this.agendaCheckListControl.Renderer = checkListRenderer1;
			checkListScheme1.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 89 ) ) ) ) , ( (int)( ( (byte)( 106 ) ) ) ) , ( (int)( ( (byte)( 146 ) ) ) ) );
			checkListScheme1.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 54 ) ) ) ) , ( (int)( ( (byte)( 59 ) ) ) ) , ( (int)( ( (byte)( 71 ) ) ) ) );
			checkListScheme1.BackgroundColor3 = System.Drawing.Color.Black;
			checkListScheme1.BackgroundColor4 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 53 ) ) ) ) , ( (int)( ( (byte)( 65 ) ) ) ) , ( (int)( ( (byte)( 37 ) ) ) ) );
			checkListScheme1.ItemCaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			checkListScheme1.ItemCaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			checkListScheme1.ItemGlowColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 100 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			checkListScheme1.ItemGlowColorSelected = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			checkListScheme1.ItemInnerBorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 3 ) ) ) ) , ( (int)( ( (byte)( 7 ) ) ) ) , ( (int)( ( (byte)( 13 ) ) ) ) );
			checkListScheme1.ItemInnerBorderColorSelected = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 3 ) ) ) ) , ( (int)( ( (byte)( 7 ) ) ) ) , ( (int)( ( (byte)( 13 ) ) ) ) );
			checkListScheme1.ItemOuterBorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 84 ) ) ) ) , ( (int)( ( (byte)( 115 ) ) ) ) , ( (int)( ( (byte)( 131 ) ) ) ) );
			checkListScheme1.ItemOuterBorderColorSelected = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 84 ) ) ) ) , ( (int)( ( (byte)( 115 ) ) ) ) , ( (int)( ( (byte)( 131 ) ) ) ) );
			this.agendaCheckListControl.Scheme = checkListScheme1;
			this.agendaCheckListControl.Size = new System.Drawing.Size( 869 , 35 );
			this.agendaCheckListControl.TabIndex = 35;
			this.agendaCheckListControl.CheckListSelectionChanged += new System.EventHandler<System.EventArgs>( this.agendaCheckListControl_CheckListSelectionChanged );
			// 
			// nextToolStripButton
			// 
			this.nextToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.nextToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.next_year;
			this.nextToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.nextToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.nextToolStripButton.Name = "nextToolStripButton";
			this.nextToolStripButton.Size = new System.Drawing.Size( 23 , 32 );
			this.nextToolStripButton.Click += new System.EventHandler( this.nextToolStripButton_Click );
			// 
			// selectionToolStripButton
			// 
			this.selectionToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.selectionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.selectionToolStripButton.Image = ( (System.Drawing.Image)( resources.GetObject( "selectionToolStripButton.Image" ) ) );
			this.selectionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.selectionToolStripButton.Name = "selectionToolStripButton";
			this.selectionToolStripButton.Size = new System.Drawing.Size( 69 , 32 );
			this.selectionToolStripButton.Text = "19/05/2009";
			// 
			// previousToolStripButton
			// 
			this.previousToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.previousToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.previous_year;
			this.previousToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.previousToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.previousToolStripButton.Name = "previousToolStripButton";
			this.previousToolStripButton.Size = new System.Drawing.Size( 23 , 32 );
			this.previousToolStripButton.Click += new System.EventHandler( this.previousToolStripButton_Click );
			// 
			// newAppointmentToolStripButton
			// 
			this.newAppointmentToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.agenda_add;
			this.newAppointmentToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.newAppointmentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newAppointmentToolStripButton.Name = "newAppointmentToolStripButton";
			this.newAppointmentToolStripButton.Size = new System.Drawing.Size( 124 , 32 );
			this.newAppointmentToolStripButton.Text = "Nieuwe Afspraak";
			this.newAppointmentToolStripButton.Click += new System.EventHandler( this.newAppointmentToolStripButton_Click );
			// 
			// editToolStripButton
			// 
			this.editToolStripButton.Enabled = false;
			this.editToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.agenda_edit;
			this.editToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.editToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.editToolStripButton.Name = "editToolStripButton";
			this.editToolStripButton.Size = new System.Drawing.Size( 135 , 32 );
			this.editToolStripButton.Text = "Afspraak bewerken";
			this.editToolStripButton.Click += new System.EventHandler( this.editToolStripButton_Click );
			// 
			// removeAppointmentToolStripButton
			// 
			this.removeAppointmentToolStripButton.Enabled = false;
			this.removeAppointmentToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.agenda_delete;
			this.removeAppointmentToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.removeAppointmentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.removeAppointmentToolStripButton.Name = "removeAppointmentToolStripButton";
			this.removeAppointmentToolStripButton.Size = new System.Drawing.Size( 145 , 32 );
			this.removeAppointmentToolStripButton.Text = "Afspraak verwijderen";
			this.removeAppointmentToolStripButton.Click += new System.EventHandler( this.removeAppointmentToolStripButton_Click );
			// 
			// agendaManagementToolStripButton
			// 
			this.agendaManagementToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.agendas;
			this.agendaManagementToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.agendaManagementToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.agendaManagementToolStripButton.Name = "agendaManagementToolStripButton";
			this.agendaManagementToolStripButton.Size = new System.Drawing.Size( 81 , 32 );
			this.agendaManagementToolStripButton.Text = "Agendas";
			this.agendaManagementToolStripButton.Click += new System.EventHandler( this.agendaManagementToolStripButton_Click );
			// 
			// agendaViewToolStripButton
			// 
			this.agendaViewToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.agendaViewToolStripButton.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.dayToolStripMenuItem,
            this.weekToolStripMenuItem} );
			this.agendaViewToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.calendar_7_241;
			this.agendaViewToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.agendaViewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.agendaViewToolStripButton.Name = "agendaViewToolStripButton";
			this.agendaViewToolStripButton.Size = new System.Drawing.Size( 73 , 32 );
			this.agendaViewToolStripButton.Text = "Week";
			// 
			// dayToolStripMenuItem
			// 
			this.dayToolStripMenuItem.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.calendar_1_241;
			this.dayToolStripMenuItem.Name = "dayToolStripMenuItem";
			this.dayToolStripMenuItem.Size = new System.Drawing.Size( 152 , 22 );
			this.dayToolStripMenuItem.Text = "Dag";
			this.dayToolStripMenuItem.Click += new System.EventHandler( this.dayToolStripMenuItem_Click );
			// 
			// weekToolStripMenuItem
			// 
			this.weekToolStripMenuItem.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.calendar_7_241;
			this.weekToolStripMenuItem.Name = "weekToolStripMenuItem";
			this.weekToolStripMenuItem.Size = new System.Drawing.Size( 152 , 22 );
			this.weekToolStripMenuItem.Text = "Week";
			this.weekToolStripMenuItem.Click += new System.EventHandler( this.weekToolStripMenuItem_Click );
			// 
			// AgendaModule
			// 
			this.BackColor = System.Drawing.Color.White;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add( this.panel1 );
			this.Controls.Add( this.toolStrip );
			this.Controls.Add( this.agendaCheckListControl );
			this.Name = "AgendaModule";
			this.Size = new System.Drawing.Size( 869 , 573 );
			this.Load += new System.EventHandler( this.AgendaModule_Load );
			this.toolStrip.ResumeLayout( false );
			this.toolStrip.PerformLayout();
			this.panel1.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		private SwmSuite.Presentation.Common.AgendaControl.AgendaControl agendaControl;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton previousToolStripButton;
		private System.Windows.Forms.ToolStripButton nextToolStripButton;
		private System.Windows.Forms.ToolStripButton newAppointmentToolStripButton;
		private System.Windows.Forms.ToolStripButton editToolStripButton;
		private System.Windows.Forms.ToolStripButton removeAppointmentToolStripButton;
		private System.Windows.Forms.ToolStripButton agendaManagementToolStripButton;
		private System.Windows.Forms.ToolStripDropDownButton agendaViewToolStripButton;
		private System.Windows.Forms.ToolStripMenuItem dayToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem weekToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton selectionToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.Panel panel1;
		private SwmSuite.Presentation.Common.CheckList.CheckListControl agendaCheckListControl;

	}
}
