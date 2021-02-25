using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace SwmSuite.Presentation.Common.UserControls {
	
	public partial class WizardTopPaneControl : ContainerControl {
		
		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		public Color FillColor1 { get; set; }
		public Color FillColor2 { get; set; }

		public string Title { get; set; }

		public Font TitleFont { get; set; }

		public Color TitleColor { get; set; }

		#endregion

		#region -_ Construction _-

		public WizardTopPaneControl() {
			InitializeComponent();
			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );

			FillColor1 = Color.FromArgb( 240 , 240 , 240 );
			FillColor2 = Color.FromArgb( 220 , 220 , 220 );

			this.Title = "Simple Workfloor Management Suite";

			this.TitleColor = Color.White;

			this.TitleFont = new Font( "Copperplate Gothic Light" , 16.0f , FontStyle.Regular );
		}

		#endregion

		private void WizardTopPaneControl_Paint( object sender , PaintEventArgs e ) {
			LinearGradientBrush backgroundFillBrush = new LinearGradientBrush( this.ClientRectangle , this.FillColor1 , this.FillColor2 , LinearGradientMode.Vertical );
			e.Graphics.FillRectangle( backgroundFillBrush , this.ClientRectangle );
			backgroundFillBrush.Dispose();

			e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
			DrawTitle( e.Graphics , this.ClientRectangle );
			e.Graphics.TextRenderingHint = TextRenderingHint.SystemDefault;
		}

		private void DrawTitle( Graphics g , Rectangle drawRect ) {
			StringFormat titleFormat = new StringFormat() { Alignment = StringAlignment.Center , LineAlignment = StringAlignment.Far };
			StringFormat shadowFormat = new StringFormat() { Alignment = StringAlignment.Center , LineAlignment = StringAlignment.Far };
			Rectangle titleRect = new Rectangle( drawRect.Left , drawRect.Top , drawRect.Width , drawRect.Height / 2 + 5 );
			Rectangle shadowRect = new Rectangle( drawRect.Left , drawRect.Top + drawRect.Height / 2 - 5 , drawRect.Width , drawRect.Height / 2 );
			SolidBrush titleBrush = new SolidBrush( this.TitleColor );
			g.DrawString( this.Title , this.TitleFont , titleBrush , titleRect , titleFormat );

			Bitmap temp = new Bitmap( shadowRect.Width , shadowRect.Height );
			Graphics tempGraphics = Graphics.FromImage( temp );
			tempGraphics.TextRenderingHint = g.TextRenderingHint;
			LinearGradientBrush shadowBrush = new LinearGradientBrush( new Rectangle(0,0,shadowRect.Width,shadowRect.Height) , Color.Transparent , Color.FromArgb( 150 , Color.White ) , LinearGradientMode.Vertical );
			//tempGraphics.FillRectangle( Brushes.Red , new Rectangle( 0 , 0 , shadowRect.Width , shadowRect.Height ) );
			tempGraphics.DrawString( this.Title , this.TitleFont , shadowBrush , new Rectangle( 0 , 0 , shadowRect.Width , shadowRect.Height ) , shadowFormat );
			shadowBrush.Dispose();
			tempGraphics.Dispose();
			temp.RotateFlip( RotateFlipType.RotateNoneFlipY );
			g.DrawImageUnscaled( temp , shadowRect.Left , shadowRect.Top );
			temp.Dispose();
			titleBrush.Dispose();
			shadowFormat.Dispose();
			titleFormat.Dispose();
		}

	}
}
