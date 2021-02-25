namespace SimpleWorkfloorManagementSuite.Controls {
	partial class MessageRichTextEditor {
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.richTextBox = new System.Windows.Forms.RichTextBox();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.fontToolStripComboBox = new SwmSuite.Presentation.Common.UserControls.ToolStripFontComboBox();
			this.sizeToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.boldToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.italicToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.underlineToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.justifyLeftToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.justifyCenterToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.justifyRightToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.bulletsToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.textColorToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.backgroundColorToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add( this.richTextBox );
			this.panel1.Location = new System.Drawing.Point( 3 , 36 );
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding( 1 );
			this.panel1.Size = new System.Drawing.Size( 878 , 527 );
			this.panel1.TabIndex = 37;
			// 
			// richTextBox
			// 
			this.richTextBox.AcceptsTab = true;
			this.richTextBox.BackColor = System.Drawing.Color.White;
			this.richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBox.Font = new System.Drawing.Font( "Verdana" , 11F );
			this.richTextBox.HideSelection = false;
			this.richTextBox.Location = new System.Drawing.Point( 1 , 1 );
			this.richTextBox.Name = "richTextBox";
			this.richTextBox.Size = new System.Drawing.Size( 874 , 523 );
			this.richTextBox.TabIndex = 31;
			this.richTextBox.Text = "";
			this.richTextBox.SelectionChanged += new System.EventHandler( this.richTextBox_SelectionChanged );
			// 
			// toolStrip
			// 
			this.toolStrip.AutoSize = false;
			this.toolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator1,
            this.fontToolStripComboBox,
            this.sizeToolStripComboBox,
            this.toolStripSeparator2,
            this.boldToolStripButton,
            this.italicToolStripButton,
            this.underlineToolStripButton,
            this.toolStripSeparator3,
            this.justifyLeftToolStripButton,
            this.justifyCenterToolStripButton,
            this.justifyRightToolStripButton,
            this.toolStripSeparator4,
            this.bulletsToolStripButton,
            this.toolStripSeparator5,
            this.textColorToolStripButton,
            this.backgroundColorToolStripButton} );
			this.toolStrip.Location = new System.Drawing.Point( 0 , 0 );
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size( 884 , 33 );
			this.toolStrip.TabIndex = 36;
			this.toolStrip.Text = "toolStrip1";
			// 
			// cutToolStripButton
			// 
			this.cutToolStripButton.AutoSize = false;
			this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cutToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.Cut;
			this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cutToolStripButton.Name = "cutToolStripButton";
			this.cutToolStripButton.Size = new System.Drawing.Size( 30 , 30 );
			this.cutToolStripButton.Text = "Knippen";
			this.cutToolStripButton.Click += new System.EventHandler( this.cutToolStripButton_Click );
			// 
			// copyToolStripButton
			// 
			this.copyToolStripButton.AutoSize = false;
			this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.copyToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.Copy;
			this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.copyToolStripButton.Name = "copyToolStripButton";
			this.copyToolStripButton.Size = new System.Drawing.Size( 30 , 30 );
			this.copyToolStripButton.Text = "Kopiëren";
			this.copyToolStripButton.Click += new System.EventHandler( this.copyToolStripButton_Click );
			// 
			// pasteToolStripButton
			// 
			this.pasteToolStripButton.AutoSize = false;
			this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.pasteToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.Paste;
			this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.pasteToolStripButton.Name = "pasteToolStripButton";
			this.pasteToolStripButton.Size = new System.Drawing.Size( 30 , 30 );
			this.pasteToolStripButton.Text = "Plakken";
			this.pasteToolStripButton.Click += new System.EventHandler( this.pasteToolStripButton_Click );
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size( 6 , 33 );
			// 
			// fontToolStripComboBox
			// 
			this.fontToolStripComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.fontToolStripComboBox.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.fontToolStripComboBox.Items.AddRange( new object[] {
            "Algerian",
            "Andalus",
            "Angsana New",
            "AngsanaUPC",
            "Aparajita",
            "Arabic Typesetting",
            "Arial",
            "Arial Black",
            "Arial Narrow",
            "Arial Unicode MS",
            "Baskerville Old Face",
            "Batang",
            "BatangChe",
            "Bauhaus 93",
            "Bell MT",
            "Berlin Sans FB",
            "Bernard MT Condensed",
            "Bodoni MT Poster Compressed",
            "Book Antiqua",
            "Bookman Old Style",
            "Bookshelf Symbol 7",
            "Britannic Bold",
            "Broadway",
            "Browallia New",
            "BrowalliaUPC",
            "Calibri",
            "Californian FB",
            "Cambria",
            "Cambria Math",
            "Candara",
            "Centaur",
            "Century",
            "Century Gothic",
            "Chiller",
            "Colonna MT",
            "Comic Sans MS",
            "Consolas",
            "Constantia",
            "Cooper Black",
            "Copperplate Gothic Bold",
            "Copperplate Gothic Light",
            "CopprplGoth Bd BT",
            "CopprplGoth Cn BT",
            "Corbel",
            "Cordia New",
            "CordiaUPC",
            "Courier New",
            "DaunPenh",
            "David",
            "DFKai-SB",
            "DilleniaUPC",
            "DokChampa",
            "Dotum",
            "DotumChe",
            "Ebrima",
            "Estrangelo Edessa",
            "EucrosiaUPC",
            "Euphemia",
            "FangSong",
            "Footlight MT Light",
            "Franklin Gothic Medium",
            "FrankRuehl",
            "FreesiaUPC",
            "Freestyle Script",
            "Gabriola",
            "Garamond",
            "Gautami",
            "Georgia",
            "Gisha",
            "Gulim",
            "GulimChe",
            "Gungsuh",
            "GungsuhChe",
            "Harrington",
            "High Tower Text",
            "Impact",
            "Informal Roman",
            "IrisUPC",
            "Iskoola Pota",
            "JasmineUPC",
            "Jokerman",
            "Juice ITC",
            "KaiTi",
            "Kalinga",
            "Kartika",
            "Khmer UI",
            "KodchiangUPC",
            "Kokila",
            "Kristen ITC",
            "Kunstler Script",
            "Lao UI",
            "Latha",
            "Leelawadee",
            "Levenim MT",
            "LilyUPC",
            "Lucida Bright",
            "Lucida Calligraphy",
            "Lucida Console",
            "Lucida Fax",
            "Lucida Handwriting",
            "Lucida Sans Unicode",
            "Malgun Gothic",
            "Mangal",
            "Marlett",
            "Matura MT Script Capitals",
            "Meiryo",
            "Meiryo UI",
            "Microsoft Himalaya",
            "Microsoft JhengHei",
            "Microsoft New Tai Lue",
            "Microsoft PhagsPa",
            "Microsoft Sans Serif",
            "Microsoft Tai Le",
            "Microsoft Uighur",
            "Microsoft YaHei",
            "Microsoft Yi Baiti",
            "MingLiU",
            "MingLiU-ExtB",
            "MingLiU_HKSCS",
            "MingLiU_HKSCS-ExtB",
            "Miriam",
            "Miriam Fixed",
            "Mistral",
            "Modern No. 20",
            "Mongolian Baiti",
            "MoolBoran",
            "MS Gothic",
            "MS Mincho",
            "MS PGothic",
            "MS PMincho",
            "MS Reference Sans Serif",
            "MS Reference Specialty",
            "MS UI Gothic",
            "MT Extra",
            "MV Boli",
            "Narkisim",
            "Niagara Engraved",
            "Niagara Solid",
            "Nina",
            "NSimSun",
            "Nyala",
            "Old English Text MT",
            "Onyx",
            "Palatino Linotype",
            "Parchment",
            "Plantagenet Cherokee",
            "Playbill",
            "PMingLiU",
            "PMingLiU-ExtB",
            "Poor Richard",
            "Raavi",
            "Ravie",
            "Rod",
            "Sakkal Majalla",
            "Segoe Condensed",
            "Segoe Print",
            "Segoe Script",
            "Segoe UI",
            "Segoe UI Light",
            "Segoe UI Semibold",
            "Segoe UI Symbol",
            "Shonar Bangla",
            "Showcard Gothic",
            "Shruti",
            "SimHei",
            "Simplified Arabic",
            "Simplified Arabic Fixed",
            "SimSun",
            "SimSun-ExtB",
            "Snap ITC",
            "Stencil",
            "Sylfaen",
            "Symbol",
            "Tahoma",
            "Tempus Sans ITC",
            "Times New Roman",
            "Traditional Arabic",
            "Trebuchet MS",
            "Tunga",
            "Utsaah",
            "Vani",
            "Verdana",
            "Vijaya",
            "Viner Hand ITC",
            "Vladimir Script",
            "Vrinda",
            "Webdings",
            "Wide Latin",
            "Wingdings",
            "Wingdings 2",
            "Wingdings 3",
            "Algerian",
            "Andalus",
            "Angsana New",
            "AngsanaUPC",
            "Aparajita",
            "Arabic Typesetting",
            "Arial",
            "Arial Black",
            "Arial Narrow",
            "Arial Unicode MS",
            "Baskerville Old Face",
            "Batang",
            "BatangChe",
            "Bauhaus 93",
            "Bell MT",
            "Berlin Sans FB",
            "Bernard MT Condensed",
            "Bodoni MT Poster Compressed",
            "Book Antiqua",
            "Bookman Old Style",
            "Bookshelf Symbol 7",
            "Britannic Bold",
            "Broadway",
            "Browallia New",
            "BrowalliaUPC",
            "Calibri",
            "Californian FB",
            "Cambria",
            "Cambria Math",
            "Candara",
            "Centaur",
            "Century",
            "Century Gothic",
            "Chiller",
            "Colonna MT",
            "Comic Sans MS",
            "Consolas",
            "Constantia",
            "Cooper Black",
            "Copperplate Gothic Bold",
            "Copperplate Gothic Light",
            "CopprplGoth Bd BT",
            "CopprplGoth Cn BT",
            "Corbel",
            "Cordia New",
            "CordiaUPC",
            "Courier New",
            "DaunPenh",
            "David",
            "DFKai-SB",
            "DilleniaUPC",
            "DokChampa",
            "Dotum",
            "DotumChe",
            "Ebrima",
            "Estrangelo Edessa",
            "EucrosiaUPC",
            "Euphemia",
            "FangSong",
            "Footlight MT Light",
            "Franklin Gothic Medium",
            "FrankRuehl",
            "FreesiaUPC",
            "Freestyle Script",
            "Gabriola",
            "Garamond",
            "Gautami",
            "Georgia",
            "Gisha",
            "Gulim",
            "GulimChe",
            "Gungsuh",
            "GungsuhChe",
            "Harrington",
            "High Tower Text",
            "Impact",
            "Informal Roman",
            "IrisUPC",
            "Iskoola Pota",
            "JasmineUPC",
            "Jokerman",
            "Juice ITC",
            "KaiTi",
            "Kalinga",
            "Kartika",
            "Khmer UI",
            "KodchiangUPC",
            "Kokila",
            "Kristen ITC",
            "Kunstler Script",
            "Lao UI",
            "Latha",
            "Leelawadee",
            "Levenim MT",
            "LilyUPC",
            "Lucida Bright",
            "Lucida Calligraphy",
            "Lucida Console",
            "Lucida Fax",
            "Lucida Handwriting",
            "Lucida Sans Unicode",
            "Malgun Gothic",
            "Mangal",
            "Marlett",
            "Matura MT Script Capitals",
            "Meiryo",
            "Meiryo UI",
            "Microsoft Himalaya",
            "Microsoft JhengHei",
            "Microsoft New Tai Lue",
            "Microsoft PhagsPa",
            "Microsoft Sans Serif",
            "Microsoft Tai Le",
            "Microsoft Uighur",
            "Microsoft YaHei",
            "Microsoft Yi Baiti",
            "MingLiU",
            "MingLiU-ExtB",
            "MingLiU_HKSCS",
            "MingLiU_HKSCS-ExtB",
            "Miriam",
            "Miriam Fixed",
            "Mistral",
            "Modern No. 20",
            "Mongolian Baiti",
            "MoolBoran",
            "MS Gothic",
            "MS Mincho",
            "MS PGothic",
            "MS PMincho",
            "MS Reference Sans Serif",
            "MS Reference Specialty",
            "MS UI Gothic",
            "MT Extra",
            "MV Boli",
            "Narkisim",
            "Niagara Engraved",
            "Niagara Solid",
            "Nina",
            "NSimSun",
            "Nyala",
            "Old English Text MT",
            "Onyx",
            "Palatino Linotype",
            "Parchment",
            "Plantagenet Cherokee",
            "Playbill",
            "PMingLiU",
            "PMingLiU-ExtB",
            "Poor Richard",
            "Raavi",
            "Ravie",
            "Rod",
            "Sakkal Majalla",
            "Segoe Condensed",
            "Segoe Print",
            "Segoe Script",
            "Segoe UI",
            "Segoe UI Light",
            "Segoe UI Semibold",
            "Segoe UI Symbol",
            "Shonar Bangla",
            "Showcard Gothic",
            "Shruti",
            "SimHei",
            "Simplified Arabic",
            "Simplified Arabic Fixed",
            "SimSun",
            "SimSun-ExtB",
            "Snap ITC",
            "Stencil",
            "Sylfaen",
            "Symbol",
            "Tahoma",
            "Tempus Sans ITC",
            "Times New Roman",
            "Traditional Arabic",
            "Trebuchet MS",
            "Tunga",
            "Utsaah",
            "Vani",
            "Verdana",
            "Vijaya",
            "Viner Hand ITC",
            "Vladimir Script",
            "Vrinda",
            "Webdings",
            "Wide Latin",
            "Wingdings",
            "Wingdings 2",
            "Wingdings 3",
            "Algerian",
            "Andalus",
            "Angsana New",
            "AngsanaUPC",
            "Aparajita",
            "Arabic Typesetting",
            "Arial",
            "Arial Black",
            "Arial Narrow",
            "Arial Unicode MS",
            "Baskerville Old Face",
            "Batang",
            "BatangChe",
            "Bauhaus 93",
            "Bell MT",
            "Berlin Sans FB",
            "Bernard MT Condensed",
            "Bodoni MT Poster Compressed",
            "Book Antiqua",
            "Bookman Old Style",
            "Bookshelf Symbol 7",
            "Britannic Bold",
            "Broadway",
            "Browallia New",
            "BrowalliaUPC",
            "Calibri",
            "Californian FB",
            "Cambria",
            "Cambria Math",
            "Candara",
            "Centaur",
            "Century",
            "Century Gothic",
            "Chiller",
            "Colonna MT",
            "Comic Sans MS",
            "Consolas",
            "Constantia",
            "Cooper Black",
            "Copperplate Gothic Bold",
            "Copperplate Gothic Light",
            "CopprplGoth Bd BT",
            "CopprplGoth Cn BT",
            "Corbel",
            "Cordia New",
            "CordiaUPC",
            "Courier New",
            "DaunPenh",
            "David",
            "DFKai-SB",
            "DilleniaUPC",
            "DokChampa",
            "Dotum",
            "DotumChe",
            "Ebrima",
            "Estrangelo Edessa",
            "EucrosiaUPC",
            "Euphemia",
            "FangSong",
            "Footlight MT Light",
            "Franklin Gothic Medium",
            "FrankRuehl",
            "FreesiaUPC",
            "Freestyle Script",
            "Gabriola",
            "Garamond",
            "Gautami",
            "Georgia",
            "Gisha",
            "Gulim",
            "GulimChe",
            "Gungsuh",
            "GungsuhChe",
            "Harrington",
            "High Tower Text",
            "Impact",
            "Informal Roman",
            "IrisUPC",
            "Iskoola Pota",
            "JasmineUPC",
            "Jokerman",
            "Juice ITC",
            "KaiTi",
            "Kalinga",
            "Kartika",
            "Khmer UI",
            "KodchiangUPC",
            "Kokila",
            "Kristen ITC",
            "Kunstler Script",
            "Lao UI",
            "Latha",
            "Leelawadee",
            "Levenim MT",
            "LilyUPC",
            "Lucida Bright",
            "Lucida Calligraphy",
            "Lucida Console",
            "Lucida Fax",
            "Lucida Handwriting",
            "Lucida Sans Unicode",
            "Malgun Gothic",
            "Mangal",
            "Marlett",
            "Matura MT Script Capitals",
            "Meiryo",
            "Meiryo UI",
            "Microsoft Himalaya",
            "Microsoft JhengHei",
            "Microsoft New Tai Lue",
            "Microsoft PhagsPa",
            "Microsoft Sans Serif",
            "Microsoft Tai Le",
            "Microsoft Uighur",
            "Microsoft YaHei",
            "Microsoft Yi Baiti",
            "MingLiU",
            "MingLiU-ExtB",
            "MingLiU_HKSCS",
            "MingLiU_HKSCS-ExtB",
            "Miriam",
            "Miriam Fixed",
            "Mistral",
            "Modern No. 20",
            "Mongolian Baiti",
            "MoolBoran",
            "MS Gothic",
            "MS Mincho",
            "MS PGothic",
            "MS PMincho",
            "MS Reference Sans Serif",
            "MS Reference Specialty",
            "MS UI Gothic",
            "MT Extra",
            "MV Boli",
            "Narkisim",
            "Niagara Engraved",
            "Niagara Solid",
            "Nina",
            "NSimSun",
            "Nyala",
            "Old English Text MT",
            "Onyx",
            "Palatino Linotype",
            "Parchment",
            "Plantagenet Cherokee",
            "Playbill",
            "PMingLiU",
            "PMingLiU-ExtB",
            "Poor Richard",
            "Raavi",
            "Ravie",
            "Rod",
            "Sakkal Majalla",
            "Segoe Condensed",
            "Segoe Print",
            "Segoe Script",
            "Segoe UI",
            "Segoe UI Light",
            "Segoe UI Semibold",
            "Segoe UI Symbol",
            "Shonar Bangla",
            "Showcard Gothic",
            "Shruti",
            "SimHei",
            "Simplified Arabic",
            "Simplified Arabic Fixed",
            "SimSun",
            "SimSun-ExtB",
            "Snap ITC",
            "Stencil",
            "Sylfaen",
            "Symbol",
            "Tahoma",
            "Tempus Sans ITC",
            "Times New Roman",
            "Traditional Arabic",
            "Trebuchet MS",
            "Tunga",
            "Utsaah",
            "Vani",
            "Verdana",
            "Vijaya",
            "Viner Hand ITC",
            "Vladimir Script",
            "Vrinda",
            "Webdings",
            "Wide Latin",
            "Wingdings",
            "Wingdings 2",
            "Wingdings 3",
            "Algerian",
            "Andalus",
            "Angsana New",
            "AngsanaUPC",
            "Aparajita",
            "Arabic Typesetting",
            "Arial",
            "Arial Black",
            "Arial Narrow",
            "Arial Unicode MS",
            "Baskerville Old Face",
            "Batang",
            "BatangChe",
            "Bauhaus 93",
            "Bell MT",
            "Berlin Sans FB",
            "Bernard MT Condensed",
            "Bodoni MT Poster Compressed",
            "Book Antiqua",
            "Bookman Old Style",
            "Bookshelf Symbol 7",
            "Britannic Bold",
            "Broadway",
            "Browallia New",
            "BrowalliaUPC",
            "Calibri",
            "Californian FB",
            "Cambria",
            "Cambria Math",
            "Candara",
            "Centaur",
            "Century",
            "Century Gothic",
            "Chiller",
            "Colonna MT",
            "Comic Sans MS",
            "Consolas",
            "Constantia",
            "Cooper Black",
            "Copperplate Gothic Bold",
            "Copperplate Gothic Light",
            "CopprplGoth Bd BT",
            "CopprplGoth Cn BT",
            "Corbel",
            "Cordia New",
            "CordiaUPC",
            "Courier New",
            "DaunPenh",
            "David",
            "DFKai-SB",
            "DilleniaUPC",
            "DokChampa",
            "Dotum",
            "DotumChe",
            "Ebrima",
            "Estrangelo Edessa",
            "EucrosiaUPC",
            "Euphemia",
            "FangSong",
            "Footlight MT Light",
            "Franklin Gothic Medium",
            "FrankRuehl",
            "FreesiaUPC",
            "Freestyle Script",
            "Gabriola",
            "Garamond",
            "Gautami",
            "Georgia",
            "Gisha",
            "Gulim",
            "GulimChe",
            "Gungsuh",
            "GungsuhChe",
            "Harrington",
            "High Tower Text",
            "Impact",
            "Informal Roman",
            "IrisUPC",
            "Iskoola Pota",
            "JasmineUPC",
            "Jokerman",
            "Juice ITC",
            "KaiTi",
            "Kalinga",
            "Kartika",
            "Khmer UI",
            "KodchiangUPC",
            "Kokila",
            "Kristen ITC",
            "Kunstler Script",
            "Lao UI",
            "Latha",
            "Leelawadee",
            "Levenim MT",
            "LilyUPC",
            "Lucida Bright",
            "Lucida Calligraphy",
            "Lucida Console",
            "Lucida Fax",
            "Lucida Handwriting",
            "Lucida Sans Unicode",
            "Malgun Gothic",
            "Mangal",
            "Marlett",
            "Matura MT Script Capitals",
            "Meiryo",
            "Meiryo UI",
            "Microsoft Himalaya",
            "Microsoft JhengHei",
            "Microsoft New Tai Lue",
            "Microsoft PhagsPa",
            "Microsoft Sans Serif",
            "Microsoft Tai Le",
            "Microsoft Uighur",
            "Microsoft YaHei",
            "Microsoft Yi Baiti",
            "MingLiU",
            "MingLiU-ExtB",
            "MingLiU_HKSCS",
            "MingLiU_HKSCS-ExtB",
            "Miriam",
            "Miriam Fixed",
            "Mistral",
            "Modern No. 20",
            "Mongolian Baiti",
            "MoolBoran",
            "MS Gothic",
            "MS Mincho",
            "MS PGothic",
            "MS PMincho",
            "MS Reference Sans Serif",
            "MS Reference Specialty",
            "MS UI Gothic",
            "MT Extra",
            "MV Boli",
            "Narkisim",
            "Niagara Engraved",
            "Niagara Solid",
            "Nina",
            "NSimSun",
            "Nyala",
            "Old English Text MT",
            "Onyx",
            "Palatino Linotype",
            "Parchment",
            "Plantagenet Cherokee",
            "Playbill",
            "PMingLiU",
            "PMingLiU-ExtB",
            "Poor Richard",
            "Raavi",
            "Ravie",
            "Rod",
            "Sakkal Majalla",
            "Segoe Condensed",
            "Segoe Print",
            "Segoe Script",
            "Segoe UI",
            "Segoe UI Light",
            "Segoe UI Semibold",
            "Segoe UI Symbol",
            "Shonar Bangla",
            "Showcard Gothic",
            "Shruti",
            "SimHei",
            "Simplified Arabic",
            "Simplified Arabic Fixed",
            "SimSun",
            "SimSun-ExtB",
            "Snap ITC",
            "Stencil",
            "Sylfaen",
            "Symbol",
            "Tahoma",
            "Tempus Sans ITC",
            "Times New Roman",
            "Traditional Arabic",
            "Trebuchet MS",
            "Tunga",
            "Utsaah",
            "Vani",
            "Verdana",
            "Vijaya",
            "Viner Hand ITC",
            "Vladimir Script",
            "Vrinda",
            "Webdings",
            "Wide Latin",
            "Wingdings",
            "Wingdings 2",
            "Wingdings 3"} );
			this.fontToolStripComboBox.Name = "fontToolStripComboBox";
			this.fontToolStripComboBox.Size = new System.Drawing.Size( 200 , 33 );
			this.fontToolStripComboBox.Text = "Times New Roman";
			this.fontToolStripComboBox.SelectedIndexChanged += new System.EventHandler( this.fontToolStripComboBox_SelectedIndexChanged );
			// 
			// sizeToolStripComboBox
			// 
			this.sizeToolStripComboBox.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.sizeToolStripComboBox.Name = "sizeToolStripComboBox";
			this.sizeToolStripComboBox.Size = new System.Drawing.Size( 75 , 33 );
			this.sizeToolStripComboBox.SelectedIndexChanged += new System.EventHandler( this.sizeToolStripComboBox_SelectedIndexChanged );
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size( 6 , 33 );
			// 
			// boldToolStripButton
			// 
			this.boldToolStripButton.AutoSize = false;
			this.boldToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.boldToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.Bold;
			this.boldToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.boldToolStripButton.Name = "boldToolStripButton";
			this.boldToolStripButton.Size = new System.Drawing.Size( 30 , 30 );
			this.boldToolStripButton.Text = "toolStripButton4";
			this.boldToolStripButton.Click += new System.EventHandler( this.boldToolStripButton_Click );
			// 
			// italicToolStripButton
			// 
			this.italicToolStripButton.AutoSize = false;
			this.italicToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.italicToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.Italic;
			this.italicToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.italicToolStripButton.Name = "italicToolStripButton";
			this.italicToolStripButton.Size = new System.Drawing.Size( 30 , 30 );
			this.italicToolStripButton.Text = "toolStripButton5";
			this.italicToolStripButton.Click += new System.EventHandler( this.italicToolStripButton_Click );
			// 
			// underlineToolStripButton
			// 
			this.underlineToolStripButton.AutoSize = false;
			this.underlineToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.underlineToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.underline;
			this.underlineToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.underlineToolStripButton.Name = "underlineToolStripButton";
			this.underlineToolStripButton.Size = new System.Drawing.Size( 30 , 30 );
			this.underlineToolStripButton.Text = "toolStripButton6";
			this.underlineToolStripButton.Click += new System.EventHandler( this.underlineToolStripButton_Click );
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size( 6 , 33 );
			// 
			// justifyLeftToolStripButton
			// 
			this.justifyLeftToolStripButton.AutoSize = false;
			this.justifyLeftToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.justifyLeftToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.AlignTableCellMiddleLeftJust;
			this.justifyLeftToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.justifyLeftToolStripButton.Name = "justifyLeftToolStripButton";
			this.justifyLeftToolStripButton.Size = new System.Drawing.Size( 30 , 30 );
			this.justifyLeftToolStripButton.Text = "toolStripButton7";
			this.justifyLeftToolStripButton.Click += new System.EventHandler( this.justifyLeftToolStripButton_Click );
			// 
			// justifyCenterToolStripButton
			// 
			this.justifyCenterToolStripButton.AutoSize = false;
			this.justifyCenterToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.justifyCenterToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.AlignTableCellMiddleCenter;
			this.justifyCenterToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.justifyCenterToolStripButton.Name = "justifyCenterToolStripButton";
			this.justifyCenterToolStripButton.Size = new System.Drawing.Size( 30 , 30 );
			this.justifyCenterToolStripButton.Text = "toolStripButton8";
			this.justifyCenterToolStripButton.Click += new System.EventHandler( this.justifyCenterToolStripButton_Click );
			// 
			// justifyRightToolStripButton
			// 
			this.justifyRightToolStripButton.AutoSize = false;
			this.justifyRightToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.justifyRightToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.AlignTableCellMiddleRight;
			this.justifyRightToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.justifyRightToolStripButton.Name = "justifyRightToolStripButton";
			this.justifyRightToolStripButton.Size = new System.Drawing.Size( 30 , 30 );
			this.justifyRightToolStripButton.Text = "toolStripButton9";
			this.justifyRightToolStripButton.Click += new System.EventHandler( this.justifyRightToolStripButton_Click );
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size( 6 , 33 );
			// 
			// bulletsToolStripButton
			// 
			this.bulletsToolStripButton.AutoSize = false;
			this.bulletsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bulletsToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.List_Bullets;
			this.bulletsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bulletsToolStripButton.Name = "bulletsToolStripButton";
			this.bulletsToolStripButton.Size = new System.Drawing.Size( 30 , 30 );
			this.bulletsToolStripButton.Text = "toolStripButton10";
			this.bulletsToolStripButton.Click += new System.EventHandler( this.bulletsToolStripButton_Click );
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size( 6 , 33 );
			// 
			// textColorToolStripButton
			// 
			this.textColorToolStripButton.AutoSize = false;
			this.textColorToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.textColorToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.Color_font;
			this.textColorToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.textColorToolStripButton.Name = "textColorToolStripButton";
			this.textColorToolStripButton.Size = new System.Drawing.Size( 30 , 30 );
			this.textColorToolStripButton.Text = "toolStripButton11";
			this.textColorToolStripButton.Click += new System.EventHandler( this.textColorToolStripButton_Click );
			// 
			// backgroundColorToolStripButton
			// 
			this.backgroundColorToolStripButton.AutoSize = false;
			this.backgroundColorToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.backgroundColorToolStripButton.Image = global::SimpleWorkfloorManagementSuite.Properties.Resources.LineColor;
			this.backgroundColorToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.backgroundColorToolStripButton.Name = "backgroundColorToolStripButton";
			this.backgroundColorToolStripButton.Size = new System.Drawing.Size( 30 , 30 );
			this.backgroundColorToolStripButton.Text = "toolStripButton12";
			this.backgroundColorToolStripButton.Click += new System.EventHandler( this.backgroundColorToolStripButton_Click );
			// 
			// panel2
			// 
			this.panel2.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
							| System.Windows.Forms.AnchorStyles.Left )
							| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.panel2.BackColor = System.Drawing.Color.Black;
			this.panel2.Location = new System.Drawing.Point( 8 , 41 );
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size( 876 , 525 );
			this.panel2.TabIndex = 38;
			// 
			// MessageRichTextEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.panel1 );
			this.Controls.Add( this.toolStrip );
			this.Controls.Add( this.panel2 );
			this.Name = "MessageRichTextEditor";
			this.Size = new System.Drawing.Size( 884 , 566 );
			this.Load += new System.EventHandler( this.MessageRichTextEditor_Load );
			this.panel1.ResumeLayout( false );
			this.toolStrip.ResumeLayout( false );
			this.toolStrip.PerformLayout();
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RichTextBox richTextBox;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton cutToolStripButton;
		private System.Windows.Forms.ToolStripButton copyToolStripButton;
		private System.Windows.Forms.ToolStripButton pasteToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private SwmSuite.Presentation.Common.UserControls.ToolStripFontComboBox fontToolStripComboBox;
		private System.Windows.Forms.ToolStripComboBox sizeToolStripComboBox;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton boldToolStripButton;
		private System.Windows.Forms.ToolStripButton italicToolStripButton;
		private System.Windows.Forms.ToolStripButton underlineToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton justifyLeftToolStripButton;
		private System.Windows.Forms.ToolStripButton justifyCenterToolStripButton;
		private System.Windows.Forms.ToolStripButton justifyRightToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton bulletsToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton textColorToolStripButton;
		private System.Windows.Forms.ToolStripButton backgroundColorToolStripButton;
		private System.Windows.Forms.Panel panel2;
	}
}
