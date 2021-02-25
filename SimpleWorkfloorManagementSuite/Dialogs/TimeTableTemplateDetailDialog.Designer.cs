namespace SimpleWorkfloorManagementSuite.Dialogs {
	partial class TimeTableTemplateDetailDialog {
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
			SwmSuite.Presentation.Common.DialogHeader.DialogHeaderRenderer dialogHeaderRenderer1 = new SwmSuite.Presentation.Common.DialogHeader.DialogHeaderRenderer();
			SwmSuite.Presentation.Common.DialogHeader.DialogHeaderScheme dialogHeaderScheme1 = new SwmSuite.Presentation.Common.DialogHeader.DialogHeaderScheme();
			SwmSuite.Presentation.Common.TimeTable.TimeTableColumn timeTableColumn1 = new SwmSuite.Presentation.Common.TimeTable.TimeTableColumn();
			SwmSuite.Presentation.Common.TimeTable.TimeTableHitTest timeTableHitTest1 = new SwmSuite.Presentation.Common.TimeTable.TimeTableHitTest();
			SwmSuite.Presentation.Common.TimeTable.TimeTableRenderer timeTableRenderer1 = new SwmSuite.Presentation.Common.TimeTable.TimeTableRenderer();
			SwmSuite.Presentation.Common.ButtonRenderer buttonRenderer1 = new SwmSuite.Presentation.Common.ButtonRenderer();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme1 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat1 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme2 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat2 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme3 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat3 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme4 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat4 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonRenderer buttonRenderer2 = new SwmSuite.Presentation.Common.ButtonRenderer();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme5 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat5 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme6 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat6 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme7 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat7 = new System.Drawing.StringFormat();
			SwmSuite.Presentation.Common.ButtonScheme buttonScheme8 = new SwmSuite.Presentation.Common.ButtonScheme();
			System.Drawing.StringFormat stringFormat8 = new System.Drawing.StringFormat();
			this.dialogHeaderControl = new SwmSuite.Presentation.Common.DialogHeader.DialogHeaderControl();
			this.timeTableControl = new SwmSuite.Presentation.Common.TimeTable.TimeTableControl();
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip( this.components );
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.detailsToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.timeTableToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cancelButton = new SwmSuite.Presentation.Common.ButtonControl();
			this.okButton = new SwmSuite.Presentation.Common.ButtonControl();
			this.timeTablePanel = new System.Windows.Forms.Panel();
			this.detailsPanel = new System.Windows.Forms.Panel();
			this.descriptionTextBox = new SwmSuite.Presentation.Common.NiceTextBox.NiceTextBoxControl();
			this.label1 = new System.Windows.Forms.Label();
			this.nameTextBox = new SwmSuite.Presentation.Common.NiceTextBox.NiceTextBoxControl();
			this.label3 = new System.Windows.Forms.Label();
			addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.panel1.SuspendLayout();
			this.timeTablePanel.SuspendLayout();
			this.detailsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// addToolStripMenuItem
			// 
			addToolStripMenuItem.Name = "addToolStripMenuItem";
			addToolStripMenuItem.Size = new System.Drawing.Size( 136 , 22 );
			addToolStripMenuItem.Text = "Toevoegen";
			// 
			// dialogHeaderControl
			// 
			this.dialogHeaderControl.Dock = System.Windows.Forms.DockStyle.Top;
			this.dialogHeaderControl.Location = new System.Drawing.Point( 0 , 0 );
			this.dialogHeaderControl.MainText = " Detail uurrooster sjabloon";
			this.dialogHeaderControl.Name = "dialogHeaderControl";
			this.dialogHeaderControl.OnlyMainText = true;
			this.dialogHeaderControl.Renderer = dialogHeaderRenderer1;
			dialogHeaderScheme1.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 10 ) ) ) ) , ( (int)( ( (byte)( 75 ) ) ) ) , ( (int)( ( (byte)( 115 ) ) ) ) );
			dialogHeaderScheme1.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 50 ) ) ) ) , ( (int)( ( (byte)( 175 ) ) ) ) , ( (int)( ( (byte)( 175 ) ) ) ) );
			dialogHeaderScheme1.SubTitleColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			dialogHeaderScheme1.SubTitleFont = new System.Drawing.Font( "Verdana" , 10F );
			dialogHeaderScheme1.SubTitleRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			dialogHeaderScheme1.TitleColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			dialogHeaderScheme1.TitleFont = new System.Drawing.Font( "Verdana" , 12F , System.Drawing.FontStyle.Bold );
			dialogHeaderScheme1.TitleRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			this.dialogHeaderControl.Scheme = dialogHeaderScheme1;
			this.dialogHeaderControl.Size = new System.Drawing.Size( 406 , 50 );
			this.dialogHeaderControl.SubText = "#Details#";
			this.dialogHeaderControl.TabIndex = 14;
			this.dialogHeaderControl.TabStop = false;
			// 
			// timeTableControl
			// 
			timeTableColumn1.Caption = null;
			timeTableColumn1.Tag = null;
			this.timeTableControl.Columns.Add( timeTableColumn1 );
			this.timeTableControl.Dock = System.Windows.Forms.DockStyle.Fill;
			timeTableHitTest1.HitTestColumn = null;
			timeTableHitTest1.HitTestDate = new System.DateTime( ( (long)( 0 ) ) );
			timeTableHitTest1.HitTestEntry = null;
			this.timeTableControl.HitTester = timeTableHitTest1;
			this.timeTableControl.HoveredColumn = null;
			this.timeTableControl.InDesign = true;
			this.timeTableControl.Location = new System.Drawing.Point( 5 , 5 );
			this.timeTableControl.Name = "timeTableControl";
			timeTableRenderer1.HoveredColumn = null;
			timeTableRenderer1.HoveredDate = null;
			this.timeTableControl.Renderer = timeTableRenderer1;
			this.timeTableControl.Scheme.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			this.timeTableControl.Scheme.CaptionBoldFont = new System.Drawing.Font( "Verdana" , 8F , System.Drawing.FontStyle.Bold );
			this.timeTableControl.Scheme.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			this.timeTableControl.Scheme.CaptionFont = new System.Drawing.Font( "Verdana" , 8F );
			this.timeTableControl.Scheme.ColumnHeaderBackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 136 ) ) ) ) , ( (int)( ( (byte)( 180 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
			this.timeTableControl.Scheme.ColumnHeaderBackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 71 ) ) ) ) , ( (int)( ( (byte)( 139 ) ) ) ) , ( (int)( ( (byte)( 158 ) ) ) ) );
			this.timeTableControl.Scheme.ColumnHeaderBackgroundColor3 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 19 ) ) ) ) , ( (int)( ( (byte)( 97 ) ) ) ) , ( (int)( ( (byte)( 119 ) ) ) ) );
			this.timeTableControl.Scheme.ColumnHeaderBackgroundColor4 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 83 ) ) ) ) , ( (int)( ( (byte)( 159 ) ) ) ) , ( (int)( ( (byte)( 171 ) ) ) ) );
			this.timeTableControl.Scheme.ColumnHeaderCaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			this.timeTableControl.Scheme.ColumnHeaderCaptionFont = new System.Drawing.Font( "Verdana" , 10F , System.Drawing.FontStyle.Bold );
			this.timeTableControl.Scheme.ColumnHeaderCaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			this.timeTableControl.Scheme.ColumnHeaderHeight = 30;
			this.timeTableControl.Scheme.DayColumnBackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			this.timeTableControl.Scheme.DayColumnBackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) );
			this.timeTableControl.Scheme.DayColumnCaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			this.timeTableControl.Scheme.DayColumnCaptionFont = new System.Drawing.Font( "Verdana" , 8F );
			this.timeTableControl.Scheme.DayColumnCaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			this.timeTableControl.Scheme.DayColumnWidth = 50;
			this.timeTableControl.Scheme.SummaryBoxWidth = 50;
			this.timeTableControl.Scheme.SummaryRowBackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			this.timeTableControl.Scheme.SummaryRowBackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 215 ) ) ) ) , ( (int)( ( (byte)( 215 ) ) ) ) , ( (int)( ( (byte)( 215 ) ) ) ) );
			this.timeTableControl.Scheme.SummaryRowBackgroundColor3 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 171 ) ) ) ) , ( (int)( ( (byte)( 171 ) ) ) ) , ( (int)( ( (byte)( 171 ) ) ) ) );
			this.timeTableControl.Scheme.SummaryRowBackgroundColor4 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) , ( (int)( ( (byte)( 222 ) ) ) ) );
			this.timeTableControl.Scheme.SummaryRowCaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			this.timeTableControl.Scheme.SummaryRowCaptionFont = new System.Drawing.Font( "Verdana" , 8F , System.Drawing.FontStyle.Bold );
			this.timeTableControl.Scheme.SummaryRowHeight = 30;
			this.timeTableControl.Selection = new System.DateTime( 2009 , 3 , 24 , 0 , 0 , 0 , 0 );
			this.timeTableControl.Size = new System.Drawing.Size( 396 , 445 );
			this.timeTableControl.TabIndex = 15;
			this.timeTableControl.TemplateApply = false;
			this.timeTableControl.TemplateDesign = true;
			this.timeTableControl.TimeTableTemplateColumn = null;
			this.timeTableControl.DataNeeded += new System.EventHandler<System.EventArgs>( this.timeTableControl_DataNeeded );
			this.timeTableControl.DataClicked += new System.EventHandler<SwmSuite.Presentation.Common.TimeTable.DataClickedEventArgs>( this.timeTableControl_DataClicked );
			// 
			// contextMenuStrip
			// 
			this.contextMenuStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem} );
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new System.Drawing.Size( 137 , 70 );
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size( 136 , 22 );
			this.editToolStripMenuItem.Text = "Bewerken";
			// 
			// removeToolStripMenuItem
			// 
			this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
			this.removeToolStripMenuItem.Size = new System.Drawing.Size( 136 , 22 );
			this.removeToolStripMenuItem.Text = "Verwijderen";
			// 
			// toolStrip
			// 
			this.toolStrip.AutoSize = false;
			this.toolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.detailsToolStripButton,
            this.timeTableToolStripButton} );
			this.toolStrip.Location = new System.Drawing.Point( 0 , 50 );
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size( 406 , 35 );
			this.toolStrip.TabIndex = 38;
			this.toolStrip.Text = "toolStrip1";
			// 
			// detailsToolStripButton
			// 
			this.detailsToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.edit_24px;
			this.detailsToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.detailsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.detailsToolStripButton.Name = "detailsToolStripButton";
			this.detailsToolStripButton.Size = new System.Drawing.Size( 70 , 32 );
			this.detailsToolStripButton.Text = "Details";
			this.detailsToolStripButton.Click += new System.EventHandler( this.detailsToolStripButton_Click );
			// 
			// timeTableToolStripButton
			// 
			this.timeTableToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.uurrooster_24;
			this.timeTableToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.timeTableToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.timeTableToolStripButton.Name = "timeTableToolStripButton";
			this.timeTableToolStripButton.Size = new System.Drawing.Size( 91 , 32 );
			this.timeTableToolStripButton.Text = "Uurrooster";
			this.timeTableToolStripButton.Click += new System.EventHandler( this.timeTableToolStripButton_Click );
			// 
			// panel1
			// 
			this.panel1.Controls.Add( this.cancelButton );
			this.panel1.Controls.Add( this.okButton );
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point( 0 , 540 );
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size( 406 , 32 );
			this.panel1.TabIndex = 39;
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cancelButton.Caption = "Annuleren";
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point( 157 , 4 );
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Picture = null;
			this.cancelButton.Renderer = buttonRenderer1;
			buttonScheme1.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			buttonScheme1.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			buttonScheme1.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme1.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			buttonScheme1.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			buttonScheme1.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat1.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat1.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat1.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme1.CaptionFormat = stringFormat1;
			buttonScheme1.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme1.GreenButton = false;
			buttonScheme1.RedButton = false;
			this.cancelButton.SchemeDisabled = buttonScheme1;
			buttonScheme2.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 251 ) ) ) ) , ( (int)( ( (byte)( 253 ) ) ) ) );
			buttonScheme2.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 213 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) , ( (int)( ( (byte)( 252 ) ) ) ) );
			buttonScheme2.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme2.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme2.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme2.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat2.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat2.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat2.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat2.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme2.CaptionFormat = stringFormat2;
			buttonScheme2.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme2.GreenButton = false;
			buttonScheme2.RedButton = false;
			this.cancelButton.SchemeHovered = buttonScheme2;
			buttonScheme3.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			buttonScheme3.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			buttonScheme3.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme3.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme3.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme3.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat3.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat3.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat3.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat3.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme3.CaptionFormat = stringFormat3;
			buttonScheme3.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme3.GreenButton = false;
			buttonScheme3.RedButton = false;
			this.cancelButton.SchemeNormal = buttonScheme3;
			buttonScheme4.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 214 ) ) ) ) , ( (int)( ( (byte)( 214 ) ) ) ) , ( (int)( ( (byte)( 214 ) ) ) ) );
			buttonScheme4.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) );
			buttonScheme4.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme4.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme4.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme4.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat4.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat4.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat4.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat4.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme4.CaptionFormat = stringFormat4;
			buttonScheme4.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme4.GreenButton = false;
			buttonScheme4.RedButton = false;
			this.cancelButton.SchemePushed = buttonScheme4;
			this.cancelButton.Size = new System.Drawing.Size( 120 , 25 );
			this.cancelButton.State = SwmSuite.Presentation.Common.ButtonState.Normal;
			this.cancelButton.TabIndex = 19;
			// 
			// okButton
			// 
			this.okButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.okButton.Caption = "Accepteren";
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point( 283 , 4 );
			this.okButton.Name = "okButton";
			this.okButton.Picture = null;
			this.okButton.Renderer = buttonRenderer2;
			buttonScheme5.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			buttonScheme5.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			buttonScheme5.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme5.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			buttonScheme5.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) , ( (int)( ( (byte)( 200 ) ) ) ) );
			buttonScheme5.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat5.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat5.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat5.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat5.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme5.CaptionFormat = stringFormat5;
			buttonScheme5.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme5.GreenButton = false;
			buttonScheme5.RedButton = false;
			this.okButton.SchemeDisabled = buttonScheme5;
			buttonScheme6.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 246 ) ) ) ) , ( (int)( ( (byte)( 251 ) ) ) ) , ( (int)( ( (byte)( 253 ) ) ) ) );
			buttonScheme6.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 213 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) , ( (int)( ( (byte)( 252 ) ) ) ) );
			buttonScheme6.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme6.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme6.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme6.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat6.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat6.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat6.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat6.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme6.CaptionFormat = stringFormat6;
			buttonScheme6.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme6.GreenButton = false;
			buttonScheme6.RedButton = false;
			this.okButton.SchemeHovered = buttonScheme6;
			buttonScheme7.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			buttonScheme7.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) , ( (int)( ( (byte)( 237 ) ) ) ) );
			buttonScheme7.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme7.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme7.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme7.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat7.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat7.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat7.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat7.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme7.CaptionFormat = stringFormat7;
			buttonScheme7.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme7.GreenButton = false;
			buttonScheme7.RedButton = false;
			this.okButton.SchemeNormal = buttonScheme7;
			buttonScheme8.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 214 ) ) ) ) , ( (int)( ( (byte)( 214 ) ) ) ) , ( (int)( ( (byte)( 214 ) ) ) ) );
			buttonScheme8.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) );
			buttonScheme8.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			buttonScheme8.BorderColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) , ( (int)( ( (byte)( 64 ) ) ) ) );
			buttonScheme8.CaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			buttonScheme8.CaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			stringFormat8.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat8.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat8.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat8.Trimming = System.Drawing.StringTrimming.Character;
			buttonScheme8.CaptionFormat = stringFormat8;
			buttonScheme8.CaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			buttonScheme8.GreenButton = false;
			buttonScheme8.RedButton = false;
			this.okButton.SchemePushed = buttonScheme8;
			this.okButton.Size = new System.Drawing.Size( 120 , 25 );
			this.okButton.State = SwmSuite.Presentation.Common.ButtonState.Normal;
			this.okButton.TabIndex = 18;
			this.okButton.Click += new System.EventHandler( this.okButton_Click );
			// 
			// timeTablePanel
			// 
			this.timeTablePanel.Controls.Add( this.timeTableControl );
			this.timeTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.timeTablePanel.Location = new System.Drawing.Point( 0 , 85 );
			this.timeTablePanel.Name = "timeTablePanel";
			this.timeTablePanel.Padding = new System.Windows.Forms.Padding( 5 );
			this.timeTablePanel.Size = new System.Drawing.Size( 406 , 455 );
			this.timeTablePanel.TabIndex = 40;
			// 
			// detailsPanel
			// 
			this.detailsPanel.Controls.Add( this.descriptionTextBox );
			this.detailsPanel.Controls.Add( this.label1 );
			this.detailsPanel.Controls.Add( this.nameTextBox );
			this.detailsPanel.Controls.Add( this.label3 );
			this.detailsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.detailsPanel.Location = new System.Drawing.Point( 0 , 85 );
			this.detailsPanel.Name = "detailsPanel";
			this.detailsPanel.Padding = new System.Windows.Forms.Padding( 5 );
			this.detailsPanel.Size = new System.Drawing.Size( 406 , 455 );
			this.detailsPanel.TabIndex = 42;
			// 
			// descriptionTextBox
			// 
			this.descriptionTextBox.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.descriptionTextBox.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.descriptionTextBox.BorderColorFocused = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 160 ) ) ) ) , ( (int)( ( (byte)( 17 ) ) ) ) );
			this.descriptionTextBox.BorderColorHovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 153 ) ) ) ) , ( (int)( ( (byte)( 207 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			this.descriptionTextBox.BorderColorNormal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 125 ) ) ) ) , ( (int)( ( (byte)( 170 ) ) ) ) , ( (int)( ( (byte)( 210 ) ) ) ) );
			// 
			// 
			// 
			this.descriptionTextBox.Client.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.descriptionTextBox.Client.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.descriptionTextBox.Client.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.descriptionTextBox.Client.Location = new System.Drawing.Point( 4 , 2 );
			this.descriptionTextBox.Client.Multiline = true;
			this.descriptionTextBox.Client.Name = "textbox";
			this.descriptionTextBox.Client.Size = new System.Drawing.Size( 378 , 366 );
			this.descriptionTextBox.Client.TabIndex = 0;
			this.descriptionTextBox.ContentsDisableColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) );
			this.descriptionTextBox.ContentsErrorColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 232 ) ) ) ) );
			this.descriptionTextBox.ContentsOkColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.descriptionTextBox.Location = new System.Drawing.Point( 11 , 76 );
			this.descriptionTextBox.Name = "descriptionTextBox";
			this.descriptionTextBox.Size = new System.Drawing.Size( 387 , 371 );
			this.descriptionTextBox.TabIndex = 10;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.label1.Location = new System.Drawing.Point( 8 , 57 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 91 , 16 );
			this.label1.TabIndex = 9;
			this.label1.Text = "Omschrijving";
			// 
			// nameTextBox
			// 
			this.nameTextBox.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.nameTextBox.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.nameTextBox.BorderColorFocused = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 160 ) ) ) ) , ( (int)( ( (byte)( 17 ) ) ) ) );
			this.nameTextBox.BorderColorHovered = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 153 ) ) ) ) , ( (int)( ( (byte)( 207 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			this.nameTextBox.BorderColorNormal = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 125 ) ) ) ) , ( (int)( ( (byte)( 170 ) ) ) ) , ( (int)( ( (byte)( 210 ) ) ) ) );
			// 
			// 
			// 
			this.nameTextBox.Client.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.nameTextBox.Client.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.nameTextBox.Client.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.nameTextBox.Client.Location = new System.Drawing.Point( 4 , 2 );
			this.nameTextBox.Client.Name = "textbox";
			this.nameTextBox.Client.Size = new System.Drawing.Size( 378 , 16 );
			this.nameTextBox.Client.TabIndex = 0;
			this.nameTextBox.ContentsDisableColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 240 ) ) ) ) );
			this.nameTextBox.ContentsErrorColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 232 ) ) ) ) );
			this.nameTextBox.ContentsOkColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 239 ) ) ) ) );
			this.nameTextBox.Location = new System.Drawing.Point( 11 , 27 );
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size( 387 , 22 );
			this.nameTextBox.TabIndex = 6;
			this.nameTextBox.TextChanged += new System.EventHandler<System.EventArgs>( this.nameTextBox_TextChanged );
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font( "Verdana" , 9.75F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.label3.Location = new System.Drawing.Point( 8 , 8 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 44 , 16 );
			this.label3.TabIndex = 7;
			this.label3.Text = "Naam";
			// 
			// TimeTableTemplateDetailDialog
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size( 406 , 572 );
			this.Controls.Add( this.detailsPanel );
			this.Controls.Add( this.timeTablePanel );
			this.Controls.Add( this.panel1 );
			this.Controls.Add( this.toolStrip );
			this.Controls.Add( this.dialogHeaderControl );
			this.Name = "TimeTableTemplateDetailDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Simple Workfloor Management Suite";
			this.Load += new System.EventHandler( this.TimeTableTemplateDetailDialog_Load );
			this.contextMenuStrip.ResumeLayout( false );
			this.toolStrip.ResumeLayout( false );
			this.toolStrip.PerformLayout();
			this.panel1.ResumeLayout( false );
			this.timeTablePanel.ResumeLayout( false );
			this.detailsPanel.ResumeLayout( false );
			this.detailsPanel.PerformLayout();
			this.ResumeLayout( false );

		}

		#endregion

		private SwmSuite.Presentation.Common.DialogHeader.DialogHeaderControl dialogHeaderControl;
		private SwmSuite.Presentation.Common.TimeTable.TimeTableControl timeTableControl;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton timeTableToolStripButton;
		private System.Windows.Forms.ToolStripButton detailsToolStripButton;
		private System.Windows.Forms.Panel panel1;
		private SwmSuite.Presentation.Common.ButtonControl cancelButton;
		private SwmSuite.Presentation.Common.ButtonControl okButton;
		private System.Windows.Forms.Panel timeTablePanel;
		private System.Windows.Forms.Panel detailsPanel;
		private System.Windows.Forms.Label label1;
		private SwmSuite.Presentation.Common.NiceTextBox.NiceTextBoxControl nameTextBox;
		private System.Windows.Forms.Label label3;
		private SwmSuite.Presentation.Common.NiceTextBox.NiceTextBoxControl descriptionTextBox;
	}
}