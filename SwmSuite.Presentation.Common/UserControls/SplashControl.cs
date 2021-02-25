using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using SwmSuite.Presentation.Drawing;
using System.Drawing.Text;

namespace SwmSuite.Presentation.Common.UserControls {
	
	public partial class SplashControl : UserControl {

		#region -_ Private Members _-

		#endregion

		#region -_ Private Members _-

		public string Title { get; set; }
		public string SubTitle { get; set; }
		public string EditionTitle { get; set; }
		public string Copyright { get; set; }
		public string Version { get; set; }

		public Font TitleFont { get; set; }
		public Font SubTitleFont { get; set; }
		public Font EditionTitleFont { get; set; }
		public Font CopyrightFont { get; set; }
		public Font VersionFont { get; set; }

		public Color TitleColor { get; set; }
		public Color SubTitleColor { get; set; }
		public Color EditionTitleColor { get; set; }
		public Color CopyrightColor { get; set; }
		public Color VersionColor { get; set; }

		public Region SplashRegion { get; set; }

		public int CornerRadius { get; set; }

		#endregion

		#region -_ Construction _-

		public SplashControl() {
			InitializeComponent();
			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );

			this.Title = "SWMS";
			this.SubTitle = "Simple Workfloor Management Suite";

			this.TitleColor = Color.White;
			this.SubTitleColor = Color.White;

			this.TitleFont = new Font( "Copperplate Gothic Bold" , 100.0f , FontStyle.Bold );
			this.SubTitleFont = new Font( "Copperplate Gothic Light" , 20.0f , FontStyle.Regular );

			this.CornerRadius = 75;
		}

		#endregion

		#region -_ UserControl Events _-

		private void SplashControl_Paint( object sender , PaintEventArgs e ) {
			
			GraphicsPath controlPath = DrawBackGround( e.Graphics , this.ClientRectangle );
			e.Graphics.SetClip( controlPath );
			e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			DrawBottomPaneFirst( e.Graphics , this.ClientRectangle );
			DrawTitle( e.Graphics , new Rectangle( this.ClientRectangle.Left , this.ClientRectangle.Top + this.ClientRectangle.Height / 2 - (int)this.TitleFont.Size , this.ClientRectangle.Width , (int)(this.TitleFont.Size * 2.0f) ) );
			DrawBottomPaneSecond( e.Graphics , this.ClientRectangle );
			DrawSubTitle( e.Graphics , new Rectangle( this.ClientRectangle.Left , this.ClientRectangle.Top + this.ClientRectangle.Height / 2 + (int)this.TitleFont.Size , this.ClientRectangle.Width , (int)( this.SubTitleFont.Size * 2.0f ) ) );
			DrawVersion( e.Graphics , this.ClientRectangle );
			DrawCopyright( e.Graphics , this.ClientRectangle );
			e.Graphics.TextRenderingHint = TextRenderingHint.SystemDefault;
			e.Graphics.ResetClip();
			e.Graphics.SmoothingMode = SmoothingMode.Default;
			controlPath.Dispose();
		}

		private GraphicsPath DrawBackGround( Graphics g , Rectangle drawRect ) {
			g.SmoothingMode = SmoothingMode.AntiAlias;
			GraphicsPath path = DrawingTools.GetRoundedRect( drawRect , true , false , false , true , this.CornerRadius );
			LinearGradientBrush backgroundBrush = new LinearGradientBrush( drawRect , Color.LightGray , Color.Black , LinearGradientMode.Vertical );
			g.FillPath( backgroundBrush , path );
			g.DrawPath( Pens.Black , path );
			backgroundBrush.Dispose();
			g.SmoothingMode = SmoothingMode.Default;
			this.SplashRegion = new Region( path );
			return path;
		}

		private void DrawBottomPaneFirst( Graphics g , Rectangle drawRect ) {
			Rectangle bottomPane = new Rectangle( drawRect.Left , drawRect.Top + drawRect.Height / 2 , drawRect.Width , drawRect.Height / 2 );
			LinearGradientBrush bottomPaneBrush = new LinearGradientBrush( bottomPane , Color.Gray , Color.Black , LinearGradientMode.Vertical );
			bottomPaneBrush.WrapMode = WrapMode.TileFlipXY;

			Point bottomPanePoint1 = new Point( bottomPane.Left , bottomPane.Top + 25 );
			Point bottomPanePoint2 = new Point( bottomPane.Left + bottomPane.Width / 2 , bottomPane.Top );
			Point bottomPanePoint3 = new Point( bottomPane.Right , bottomPane.Top + 25 );
			GraphicsPath bottomPanePath = DrawingTools.GetTopArcPath( new Point[] { bottomPanePoint1 , bottomPanePoint2 , bottomPanePoint3 } );
			bottomPanePath.AddLine( bottomPane.Left , bottomPane.Bottom , bottomPane.Right , bottomPane.Bottom );
			bottomPanePath.CloseAllFigures();

			g.FillPath( bottomPaneBrush , bottomPanePath );

			bottomPanePath.Dispose();

			bottomPaneBrush.Dispose();
		}

		private void DrawBottomPaneSecond( Graphics g , Rectangle drawRect ) {
			Rectangle bottomPane = new Rectangle( drawRect.Left , drawRect.Top + drawRect.Height / 2 , drawRect.Width , drawRect.Height / 2 );
			LinearGradientBrush bottomPaneBrush = new LinearGradientBrush( bottomPane , Color.FromArgb( 200 , Color.Gray ) , Color.FromArgb( 200 , Color.Black ) , LinearGradientMode.Vertical );
			bottomPaneBrush.WrapMode = WrapMode.TileFlipXY;

			Point bottomPanePoint1 = new Point( bottomPane.Left , bottomPane.Top + 25 );
			Point bottomPanePoint2 = new Point( bottomPane.Left + bottomPane.Width / 2 , bottomPane.Top );
			Point bottomPanePoint3 = new Point( bottomPane.Right , bottomPane.Top + 25 );
			GraphicsPath bottomPanePath = DrawingTools.GetTopArcPath( new Point[] { bottomPanePoint1 , bottomPanePoint2 , bottomPanePoint3 } );
			bottomPanePath.AddLine( bottomPane.Left , bottomPane.Bottom , bottomPane.Right , bottomPane.Bottom );
			bottomPanePath.CloseAllFigures();

			g.FillPath( bottomPaneBrush , bottomPanePath );

			bottomPanePath.Dispose();

			bottomPaneBrush.Dispose();
		}

		private void DrawTitle( Graphics g , Rectangle drawRect ) {
			StringFormat stringFormat = new StringFormat() { Alignment = StringAlignment.Center , LineAlignment = StringAlignment.Center };
			SolidBrush titleBrush = new SolidBrush( this.TitleColor );
			g.DrawString( this.Title , this.TitleFont , titleBrush , drawRect , stringFormat );
			titleBrush.Dispose();
			stringFormat.Dispose();
		}

		private void DrawSubTitle( Graphics g , Rectangle drawRect ) {
			StringFormat stringFormat = new StringFormat() { Alignment = StringAlignment.Center , LineAlignment = StringAlignment.Far };
			SolidBrush titleBrush = new SolidBrush( this.SubTitleColor );
			SizeF subTitleSize = g.MeasureString( this.SubTitle , this.SubTitleFont );
			//SizeF subTitleSize = new SizeF( (float)drawRect.Width , this.SubTitleFont.Size );
			g.DrawString( this.SubTitle , this.SubTitleFont , titleBrush , drawRect , stringFormat );
			Bitmap temp = new Bitmap( drawRect.Width , (int)subTitleSize.Height + 1 );
			Graphics tempGraphics = Graphics.FromImage( temp );
			tempGraphics.TextRenderingHint = g.TextRenderingHint;
			LinearGradientBrush titleShadowBrush = new LinearGradientBrush( new Rectangle( 0 , 0 , drawRect.Width , (int)subTitleSize.Height + 1 ) , Color.Transparent , Color.FromArgb( 150,Color.White) , LinearGradientMode.Vertical );
			tempGraphics.DrawString( this.SubTitle , this.SubTitleFont , titleShadowBrush , new Rectangle( 0 , 0 , drawRect.Width , (int)subTitleSize.Height + 1 ) , stringFormat );
			//tempGraphics.DrawRectangle( Pens.White , new Rectangle( 0 , 0 , drawRect.Width , (int)subTitleSize.Height + 1 ) );
			titleShadowBrush.Dispose();
			//tempGraphics.Clear( Color.White );
			tempGraphics.Dispose();
			temp.RotateFlip( RotateFlipType.RotateNoneFlipY );
			g.DrawImageUnscaled( temp , drawRect.Left , drawRect.Top + (int)subTitleSize.Height );
			temp.Dispose();
			titleBrush.Dispose();
			stringFormat.Dispose();
		}

		private void DrawVersion( Graphics g , Rectangle drawRect ) {
			StringFormat stringFormat = new StringFormat() { Alignment = StringAlignment.Near , LineAlignment = StringAlignment.Far };
			SolidBrush versionBrush = new SolidBrush( this.VersionColor );
			g.DrawString( this.Version , this.VersionFont , versionBrush , drawRect , stringFormat );
			versionBrush.Dispose();
			stringFormat.Dispose();
		}

		private void DrawCopyright( Graphics g , Rectangle drawRect ) {
			StringFormat stringFormat = new StringFormat() { Alignment = StringAlignment.Far , LineAlignment = StringAlignment.Far };
			SolidBrush copyrightBrush = new SolidBrush( this.CopyrightColor );
			g.DrawString( this.Copyright , this.CopyrightFont , copyrightBrush , drawRect , stringFormat );
			copyrightBrush.Dispose();
			stringFormat.Dispose();
		}



		#endregion
	}
}
