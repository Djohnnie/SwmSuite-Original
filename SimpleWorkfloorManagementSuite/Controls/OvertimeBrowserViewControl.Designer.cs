﻿namespace SimpleWorkfloorManagementSuite.Controls {
	partial class OvertimeBrowserViewControl {
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
			SwmSuite.Presentation.Common.BrowserView.BrowserViewRenderer browserViewRenderer1 = new SwmSuite.Presentation.Common.BrowserView.BrowserViewRenderer();
			SwmSuite.Presentation.Common.BrowserView.BrowserViewScheme browserViewScheme1 = new SwmSuite.Presentation.Common.BrowserView.BrowserViewScheme();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( OvertimeBrowserViewControl ) );
			this.browserViewControl = new SwmSuite.Presentation.Common.BrowserView.BrowserViewControl();
			this.iconColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.dateColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.overtimeColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.commissionerColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.imageList = new System.Windows.Forms.ImageList( this.components );
			this.SuspendLayout();
			// 
			// browserViewControl
			// 
			this.browserViewControl.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.iconColumnHeader,
            this.dateColumnHeader,
            this.overtimeColumnHeader,
            this.commissionerColumnHeader} );
			this.browserViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.browserViewControl.Font = new System.Drawing.Font( "Verdana" , 10F );
			this.browserViewControl.FullRowSelect = true;
			this.browserViewControl.GridLines = true;
			this.browserViewControl.Location = new System.Drawing.Point( 0 , 0 );
			this.browserViewControl.MultiSelect = false;
			this.browserViewControl.Name = "browserViewControl";
			this.browserViewControl.OwnerDraw = true;
			this.browserViewControl.Renderer = browserViewRenderer1;
			browserViewScheme1.ColumnHeaderBackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 136 ) ) ) ) , ( (int)( ( (byte)( 180 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
			browserViewScheme1.ColumnHeaderBackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 71 ) ) ) ) , ( (int)( ( (byte)( 139 ) ) ) ) , ( (int)( ( (byte)( 158 ) ) ) ) );
			browserViewScheme1.ColumnHeaderBackgroundColor3 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 19 ) ) ) ) , ( (int)( ( (byte)( 97 ) ) ) ) , ( (int)( ( (byte)( 119 ) ) ) ) );
			browserViewScheme1.ColumnHeaderBackgroundColor4 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 83 ) ) ) ) , ( (int)( ( (byte)( 159 ) ) ) ) , ( (int)( ( (byte)( 171 ) ) ) ) );
			browserViewScheme1.ColumnHeaderCaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			browserViewScheme1.ColumnHeaderCaptionFont = new System.Drawing.Font( "Verdana" , 10F , System.Drawing.FontStyle.Bold );
			browserViewScheme1.ColumnHeaderCaptionRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			browserViewScheme1.RowCaptionColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			browserViewScheme1.RowCaptionFont = new System.Drawing.Font( "Verdana" , 10F );
			browserViewScheme1.RowCaptionRendering = System.Drawing.Text.TextRenderingHint.SystemDefault;
			browserViewScheme1.RowHoveredBackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 248 ) ) ) ) , ( (int)( ( (byte)( 252 ) ) ) ) , ( (int)( ( (byte)( 254 ) ) ) ) );
			browserViewScheme1.RowHoveredBackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 232 ) ) ) ) , ( (int)( ( (byte)( 245 ) ) ) ) , ( (int)( ( (byte)( 253 ) ) ) ) );
			browserViewScheme1.RowNormalBackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			browserViewScheme1.RowNormalBackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
			browserViewScheme1.RowSelectedBackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 220 ) ) ) ) , ( (int)( ( (byte)( 235 ) ) ) ) , ( (int)( ( (byte)( 252 ) ) ) ) );
			browserViewScheme1.RowSelectedBackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 193 ) ) ) ) , ( (int)( ( (byte)( 219 ) ) ) ) , ( (int)( ( (byte)( 252 ) ) ) ) );
			this.browserViewControl.Scheme = browserViewScheme1;
			this.browserViewControl.Size = new System.Drawing.Size( 565 , 288 );
			this.browserViewControl.SmallImageList = this.imageList;
			this.browserViewControl.TabIndex = 1;
			this.browserViewControl.UseCompatibleStateImageBehavior = false;
			this.browserViewControl.View = System.Windows.Forms.View.Details;
			this.browserViewControl.SelectedIndexChanged += new System.EventHandler( this.browserViewControl_SelectedIndexChanged );
			// 
			// iconColumnHeader
			// 
			this.iconColumnHeader.Text = "";
			this.iconColumnHeader.Width = 20;
			// 
			// dateColumnHeader
			// 
			this.dateColumnHeader.Text = "Datum";
			this.dateColumnHeader.Width = 180;
			// 
			// overtimeColumnHeader
			// 
			this.overtimeColumnHeader.Text = "Van - Tot";
			this.overtimeColumnHeader.Width = 180;
			// 
			// commissionerColumnHeader
			// 
			this.commissionerColumnHeader.Text = "Opdrachtgever";
			this.commissionerColumnHeader.Width = 180;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "imageList.ImageStream" ) ) );
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName( 0 , "pending.png" );
			this.imageList.Images.SetKeyName( 1 , "accepted.png" );
			this.imageList.Images.SetKeyName( 2 , "denied.png" );
			// 
			// OvertimeBrowserViewControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.browserViewControl );
			this.Name = "OvertimeBrowserViewControl";
			this.Size = new System.Drawing.Size( 565 , 288 );
			this.ResumeLayout( false );

		}

		#endregion

		private SwmSuite.Presentation.Common.BrowserView.BrowserViewControl browserViewControl;
		private System.Windows.Forms.ColumnHeader dateColumnHeader;
		private System.Windows.Forms.ColumnHeader overtimeColumnHeader;
		private System.Windows.Forms.ColumnHeader commissionerColumnHeader;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ColumnHeader iconColumnHeader;
	}
}
