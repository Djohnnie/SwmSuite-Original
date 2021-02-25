namespace SimpleWorkfloorManagementSuite.Modules {
	partial class TimeTableModule {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( TimeTableModule ) );
			SwmSuite.Presentation.Common.TimeTable.OccupationRenderer occupationRenderer1 = new SwmSuite.Presentation.Common.TimeTable.OccupationRenderer();
			SwmSuite.Presentation.Common.TimeTable.OccupationSettings occupationSettings1 = new SwmSuite.Presentation.Common.TimeTable.OccupationSettings();
			SwmSuite.Presentation.Common.TimeTable.TimeTableHitTest timeTableHitTest1 = new SwmSuite.Presentation.Common.TimeTable.TimeTableHitTest();
			SwmSuite.Presentation.Common.TimeTable.TimeTableRenderer timeTableRenderer1 = new SwmSuite.Presentation.Common.TimeTable.TimeTableRenderer();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.nextToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.selectionToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.previousToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.timeTableToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.occupationToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.mondayToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.tuesdayToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.wednesdayToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.thursdayToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.fridayToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.saturdayToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.sundayToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.occupationControl = new SwmSuite.Presentation.Common.TimeTable.OccupationControl();
			this.timeTable = new SwmSuite.Presentation.Common.TimeTable.TimeTableControl();
			this.panel1 = new System.Windows.Forms.Panel();
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
            this.toolStripSeparator1,
            this.timeTableToolStripButton,
            this.occupationToolStripButton,
            this.toolStripSeparator2,
            this.mondayToolStripButton,
            this.tuesdayToolStripButton,
            this.wednesdayToolStripButton,
            this.thursdayToolStripButton,
            this.fridayToolStripButton,
            this.saturdayToolStripButton,
            this.sundayToolStripButton} );
			this.toolStrip.Location = new System.Drawing.Point( 0 , 0 );
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size( 712 , 35 );
			this.toolStrip.TabIndex = 34;
			this.toolStrip.Text = "toolStrip1";
			// 
			// nextToolStripButton
			// 
			this.nextToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.nextToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.next_year;
			this.nextToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.nextToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.nextToolStripButton.Name = "nextToolStripButton";
			this.nextToolStripButton.Size = new System.Drawing.Size( 23 , 32 );
			this.nextToolStripButton.ToolTipText = "Volgende week";
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
			this.selectionToolStripButton.Text = "01/01/2000";
			this.selectionToolStripButton.Click += new System.EventHandler( this.selectionToolStripButton_Click );
			// 
			// previousToolStripButton
			// 
			this.previousToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.previousToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.previous_year;
			this.previousToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.previousToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.previousToolStripButton.Name = "previousToolStripButton";
			this.previousToolStripButton.Size = new System.Drawing.Size( 23 , 32 );
			this.previousToolStripButton.ToolTipText = "Vorige week";
			this.previousToolStripButton.Click += new System.EventHandler( this.previousToolStripButton_Click );
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size( 6 , 35 );
			// 
			// timeTableToolStripButton
			// 
			this.timeTableToolStripButton.Checked = true;
			this.timeTableToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
			this.timeTableToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.uurrooster_241;
			this.timeTableToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.timeTableToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.timeTableToolStripButton.Name = "timeTableToolStripButton";
			this.timeTableToolStripButton.Size = new System.Drawing.Size( 91 , 32 );
			this.timeTableToolStripButton.Text = "Uurrooster";
			this.timeTableToolStripButton.ToolTipText = "Uurrooster weergave";
			this.timeTableToolStripButton.Click += new System.EventHandler( this.timeTableToolStripButton_Click );
			// 
			// occupationToolStripButton
			// 
			this.occupationToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.bezetting_241;
			this.occupationToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.occupationToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.occupationToolStripButton.Name = "occupationToolStripButton";
			this.occupationToolStripButton.Size = new System.Drawing.Size( 84 , 32 );
			this.occupationToolStripButton.Text = "Bezetting";
			this.occupationToolStripButton.ToolTipText = "Bezetting weergave";
			this.occupationToolStripButton.Click += new System.EventHandler( this.occupationToolStripButton_Click );
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size( 6 , 35 );
			// 
			// mondayToolStripButton
			// 
			this.mondayToolStripButton.AutoSize = false;
			this.mondayToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.mondayToolStripButton.Image = ( (System.Drawing.Image)( resources.GetObject( "mondayToolStripButton.Image" ) ) );
			this.mondayToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mondayToolStripButton.Name = "mondayToolStripButton";
			this.mondayToolStripButton.Size = new System.Drawing.Size( 32 , 32 );
			this.mondayToolStripButton.Text = "Ma";
			this.mondayToolStripButton.ToolTipText = "Maandag";
			this.mondayToolStripButton.Visible = false;
			this.mondayToolStripButton.Click += new System.EventHandler( this.mondayToolStripButton_Click );
			// 
			// tuesdayToolStripButton
			// 
			this.tuesdayToolStripButton.AutoSize = false;
			this.tuesdayToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tuesdayToolStripButton.Image = ( (System.Drawing.Image)( resources.GetObject( "tuesdayToolStripButton.Image" ) ) );
			this.tuesdayToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tuesdayToolStripButton.Name = "tuesdayToolStripButton";
			this.tuesdayToolStripButton.Size = new System.Drawing.Size( 32 , 32 );
			this.tuesdayToolStripButton.Text = "Di";
			this.tuesdayToolStripButton.ToolTipText = "Dinsdag";
			this.tuesdayToolStripButton.Visible = false;
			this.tuesdayToolStripButton.Click += new System.EventHandler( this.tuesdayToolStripButton_Click );
			// 
			// wednesdayToolStripButton
			// 
			this.wednesdayToolStripButton.AutoSize = false;
			this.wednesdayToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.wednesdayToolStripButton.Image = ( (System.Drawing.Image)( resources.GetObject( "wednesdayToolStripButton.Image" ) ) );
			this.wednesdayToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.wednesdayToolStripButton.Name = "wednesdayToolStripButton";
			this.wednesdayToolStripButton.Size = new System.Drawing.Size( 32 , 32 );
			this.wednesdayToolStripButton.Text = "Wo";
			this.wednesdayToolStripButton.ToolTipText = "Woensdag";
			this.wednesdayToolStripButton.Visible = false;
			this.wednesdayToolStripButton.Click += new System.EventHandler( this.wednesdayToolStripButton_Click );
			// 
			// thursdayToolStripButton
			// 
			this.thursdayToolStripButton.AutoSize = false;
			this.thursdayToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.thursdayToolStripButton.Image = ( (System.Drawing.Image)( resources.GetObject( "thursdayToolStripButton.Image" ) ) );
			this.thursdayToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.thursdayToolStripButton.Name = "thursdayToolStripButton";
			this.thursdayToolStripButton.Size = new System.Drawing.Size( 32 , 32 );
			this.thursdayToolStripButton.Text = "Do";
			this.thursdayToolStripButton.ToolTipText = "Donderdag";
			this.thursdayToolStripButton.Visible = false;
			this.thursdayToolStripButton.Click += new System.EventHandler( this.thursdayToolStripButton_Click );
			// 
			// fridayToolStripButton
			// 
			this.fridayToolStripButton.AutoSize = false;
			this.fridayToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.fridayToolStripButton.Image = ( (System.Drawing.Image)( resources.GetObject( "fridayToolStripButton.Image" ) ) );
			this.fridayToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.fridayToolStripButton.Name = "fridayToolStripButton";
			this.fridayToolStripButton.Size = new System.Drawing.Size( 32 , 32 );
			this.fridayToolStripButton.Text = "Vr";
			this.fridayToolStripButton.ToolTipText = "Vrijdag";
			this.fridayToolStripButton.Visible = false;
			this.fridayToolStripButton.Click += new System.EventHandler( this.fridayToolStripButton_Click );
			// 
			// saturdayToolStripButton
			// 
			this.saturdayToolStripButton.AutoSize = false;
			this.saturdayToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.saturdayToolStripButton.Image = ( (System.Drawing.Image)( resources.GetObject( "saturdayToolStripButton.Image" ) ) );
			this.saturdayToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saturdayToolStripButton.Name = "saturdayToolStripButton";
			this.saturdayToolStripButton.Size = new System.Drawing.Size( 32 , 32 );
			this.saturdayToolStripButton.Text = "Za";
			this.saturdayToolStripButton.ToolTipText = "Zaterdag";
			this.saturdayToolStripButton.Visible = false;
			this.saturdayToolStripButton.Click += new System.EventHandler( this.saturdayToolStripButton_Click );
			// 
			// sundayToolStripButton
			// 
			this.sundayToolStripButton.AutoSize = false;
			this.sundayToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.sundayToolStripButton.Image = ( (System.Drawing.Image)( resources.GetObject( "sundayToolStripButton.Image" ) ) );
			this.sundayToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.sundayToolStripButton.Name = "sundayToolStripButton";
			this.sundayToolStripButton.Size = new System.Drawing.Size( 32 , 32 );
			this.sundayToolStripButton.Text = "Zo";
			this.sundayToolStripButton.ToolTipText = "Zondag";
			this.sundayToolStripButton.Visible = false;
			this.sundayToolStripButton.Click += new System.EventHandler( this.sundayToolStripButton_Click );
			// 
			// occupationControl
			// 
			this.occupationControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.occupationControl.Location = new System.Drawing.Point( 5 , 5 );
			this.occupationControl.Name = "occupationControl";
			this.occupationControl.Renderer = occupationRenderer1;
			this.occupationControl.Scheme.BarGap = 5;
			this.occupationControl.Scheme.BarHeight = 30;
			this.occupationControl.Scheme.ColumnHeaderBackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 136 ) ) ) ) , ( (int)( ( (byte)( 180 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
			this.occupationControl.Scheme.ColumnHeaderBackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 71 ) ) ) ) , ( (int)( ( (byte)( 139 ) ) ) ) , ( (int)( ( (byte)( 158 ) ) ) ) );
			this.occupationControl.Scheme.ColumnHeaderBackgroundColor3 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 19 ) ) ) ) , ( (int)( ( (byte)( 97 ) ) ) ) , ( (int)( ( (byte)( 119 ) ) ) ) );
			this.occupationControl.Scheme.ColumnHeaderBackgroundColor4 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 83 ) ) ) ) , ( (int)( ( (byte)( 159 ) ) ) ) , ( (int)( ( (byte)( 171 ) ) ) ) );
			this.occupationControl.Scheme.DescriptionCaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			this.occupationControl.Scheme.DescriptionCaptionFont = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.occupationControl.Scheme.DescriptionColumnWidth = 200;
			this.occupationControl.Scheme.HeaderHeight = 30;
			this.occupationControl.Scheme.LargeRulerColor = System.Drawing.Color.Gainsboro;
			this.occupationControl.Scheme.SeperatorColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			this.occupationControl.Scheme.SmallRulerColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) );
			this.occupationControl.Scheme.SummaryCaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			this.occupationControl.Scheme.SummaryCaptionFont = new System.Drawing.Font( "Verdana" , 8.25F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.occupationControl.Scheme.SummaryColumnWidth = 50;
			this.occupationControl.Scheme.SummaryRowBackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			this.occupationControl.Scheme.SummaryRowBackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 215 ) ) ) ) , ( (int)( ( (byte)( 215 ) ) ) ) , ( (int)( ( (byte)( 215 ) ) ) ) );
			this.occupationControl.Scheme.SummaryRowBackgroundColor3 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 171 ) ) ) ) , ( (int)( ( (byte)( 171 ) ) ) ) , ( (int)( ( (byte)( 171 ) ) ) ) );
			this.occupationControl.Scheme.SummaryRowBackgroundColor4 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) );
			this.occupationControl.Scheme.TimeCaptionColor = System.Drawing.Color.White;
			this.occupationControl.Scheme.TimeCaptionFont = new System.Drawing.Font( "Verdana" , 8F );
			this.occupationControl.Selection = new System.DateTime( 2009 , 3 , 25 , 0 , 0 , 0 , 0 );
			occupationSettings1.EndHour = 23;
			occupationSettings1.StartHour = 7;
			this.occupationControl.Settings = occupationSettings1;
			this.occupationControl.Size = new System.Drawing.Size( 702 , 410 );
			this.occupationControl.TabIndex = 36;
			this.occupationControl.Visible = false;
			this.occupationControl.DataNeeded += new System.EventHandler<System.EventArgs>( this.occupationControl_DataNeeded );
			// 
			// timeTable
			// 
			this.timeTable.Dock = System.Windows.Forms.DockStyle.Fill;
			timeTableHitTest1.HitTestColumn = null;
			timeTableHitTest1.HitTestDate = new System.DateTime( ( (long)( 0 ) ) );
			timeTableHitTest1.HitTestEntry = null;
			this.timeTable.HitTester = timeTableHitTest1;
			this.timeTable.HoveredColumn = null;
			this.timeTable.InDesign = false;
			this.timeTable.Location = new System.Drawing.Point( 5 , 5 );
			this.timeTable.Name = "timeTable";
			timeTableRenderer1.HoveredColumn = null;
			timeTableRenderer1.HoveredDate = null;
			this.timeTable.Renderer = timeTableRenderer1;
			this.timeTable.Scheme.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			this.timeTable.Scheme.CaptionBoldFont = new System.Drawing.Font( "Verdana" , 8F , System.Drawing.FontStyle.Bold );
			this.timeTable.Scheme.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			this.timeTable.Scheme.CaptionFont = new System.Drawing.Font( "Verdana" , 8F );
			this.timeTable.Scheme.ColumnHeaderBackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 136 ) ) ) ) , ( (int)( ( (byte)( 180 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
			this.timeTable.Scheme.ColumnHeaderBackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 71 ) ) ) ) , ( (int)( ( (byte)( 139 ) ) ) ) , ( (int)( ( (byte)( 158 ) ) ) ) );
			this.timeTable.Scheme.ColumnHeaderBackgroundColor3 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 19 ) ) ) ) , ( (int)( ( (byte)( 97 ) ) ) ) , ( (int)( ( (byte)( 119 ) ) ) ) );
			this.timeTable.Scheme.ColumnHeaderBackgroundColor4 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 83 ) ) ) ) , ( (int)( ( (byte)( 159 ) ) ) ) , ( (int)( ( (byte)( 171 ) ) ) ) );
			this.timeTable.Scheme.ColumnHeaderCaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			this.timeTable.Scheme.ColumnHeaderCaptionFont = new System.Drawing.Font( "Verdana" , 10F , System.Drawing.FontStyle.Bold );
			this.timeTable.Scheme.ColumnHeaderCaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			this.timeTable.Scheme.ColumnHeaderHeight = 30;
			this.timeTable.Scheme.DayColumnBackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			this.timeTable.Scheme.DayColumnBackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) );
			this.timeTable.Scheme.DayColumnCaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			this.timeTable.Scheme.DayColumnCaptionFont = new System.Drawing.Font( "Verdana" , 8F );
			this.timeTable.Scheme.DayColumnCaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			this.timeTable.Scheme.DayColumnWidth = 50;
			this.timeTable.Scheme.SummaryBoxWidth = 50;
			this.timeTable.Scheme.SummaryRowBackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			this.timeTable.Scheme.SummaryRowBackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 215 ) ) ) ) , ( (int)( ( (byte)( 215 ) ) ) ) , ( (int)( ( (byte)( 215 ) ) ) ) );
			this.timeTable.Scheme.SummaryRowBackgroundColor3 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 171 ) ) ) ) , ( (int)( ( (byte)( 171 ) ) ) ) , ( (int)( ( (byte)( 171 ) ) ) ) );
			this.timeTable.Scheme.SummaryRowBackgroundColor4 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) );
			this.timeTable.Scheme.SummaryRowCaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			this.timeTable.Scheme.SummaryRowCaptionFont = new System.Drawing.Font( "Verdana" , 8F , System.Drawing.FontStyle.Bold );
			this.timeTable.Scheme.SummaryRowHeight = 30;
			this.timeTable.Selection = new System.DateTime( 2009 , 3 , 25 , 0 , 0 , 0 , 0 );
			this.timeTable.Size = new System.Drawing.Size( 702 , 410 );
			this.timeTable.TabIndex = 35;
			this.timeTable.TemplateApply = false;
			this.timeTable.TemplateDesign = false;
			this.timeTable.TimeTableTemplateColumn = null;
			this.timeTable.DataNeeded += new System.EventHandler<System.EventArgs>( this.timeTable_DataNeeded );
			// 
			// panel1
			// 
			this.panel1.Controls.Add( this.timeTable );
			this.panel1.Controls.Add( this.occupationControl );
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point( 0 , 35 );
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding( 5 );
			this.panel1.Size = new System.Drawing.Size( 712 , 420 );
			this.panel1.TabIndex = 37;
			// 
			// TimeTableModule
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add( this.panel1 );
			this.Controls.Add( this.toolStrip );
			this.Name = "TimeTableModule";
			this.Size = new System.Drawing.Size( 712 , 455 );
			this.toolStrip.ResumeLayout( false );
			this.toolStrip.PerformLayout();
			this.panel1.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton previousToolStripButton;
		private System.Windows.Forms.ToolStripButton nextToolStripButton;
		private SwmSuite.Presentation.Common.TimeTable.TimeTableControl timeTable;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton timeTableToolStripButton;
		private System.Windows.Forms.ToolStripButton occupationToolStripButton;
		private SwmSuite.Presentation.Common.TimeTable.OccupationControl occupationControl;
		private System.Windows.Forms.ToolStripButton selectionToolStripButton;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton mondayToolStripButton;
		private System.Windows.Forms.ToolStripButton tuesdayToolStripButton;
		private System.Windows.Forms.ToolStripButton wednesdayToolStripButton;
		private System.Windows.Forms.ToolStripButton thursdayToolStripButton;
		private System.Windows.Forms.ToolStripButton fridayToolStripButton;
		private System.Windows.Forms.ToolStripButton saturdayToolStripButton;
		private System.Windows.Forms.ToolStripButton sundayToolStripButton;


	}
}
