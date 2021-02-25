using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using SwmSuite.Presentation.Drawing;

namespace SwmSuite.Presentation.Common.AvatarBrowser {

	public class AvatarBrowserRenderer {

		#region -_ Private Members _-

		private Bitmap _background;

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="AvatarBrowserRenderer"/> class.
		/// </summary>
		public AvatarBrowserRenderer() {
		}

		#endregion

		#region -_ Public Methods _-


		public void Render( Graphics g , Rectangle bounds , AvatarBrowserImageObject selectedImage , List<AvatarBrowserImageObject> images , AvatarBrowserScheme scheme ) {
			//if( _background == null ) {
			//    RebuildRenderer( images , selectedImage , scheme );
			//}
			if( _background != null ) {
				// Calculate the left and top offset for the background bitmap.
				int leftOffset = bounds.Left + bounds.Width / 2;
				int topOffset = bounds.Top + bounds.Height / 2 - _background.Height / 2;
				int backgroundImageOffset = scheme.AvatarSpacing;
				foreach( AvatarBrowserImageObject image in images ) {
					if( images.IndexOf( selectedImage ) > images.IndexOf( image ) ) {
						backgroundImageOffset += 48;
						backgroundImageOffset += scheme.AvatarSpacing;
					}

					if( images.IndexOf( selectedImage ) == images.IndexOf( image ) ) {
						backgroundImageOffset += 64;
					}
				}
				leftOffset = leftOffset - backgroundImageOffset;

				g.DrawImageUnscaled( _background , leftOffset , topOffset );
			}
			// Draw navigation buttons.
			Rectangle leftButtonRectangle = new Rectangle( bounds.Left , bounds.Top , scheme.NavigationButtonWidth , bounds.Height - 1 );
			Rectangle rightButtonRectangle = new Rectangle( bounds.Right - scheme.NavigationButtonWidth - 1 , bounds.Top , scheme.NavigationButtonWidth , bounds.Height - 1 );

			LinearGradientBrush leftButtonBrush = new LinearGradientBrush( leftButtonRectangle , scheme.NavigationButtonBackgroundColor1 , scheme.NavigationButtonBackgroundColor2 , LinearGradientMode.ForwardDiagonal );
			LinearGradientBrush rightButtonBrush = new LinearGradientBrush( rightButtonRectangle , scheme.NavigationButtonBackgroundColor1 , scheme.NavigationButtonBackgroundColor2 , LinearGradientMode.ForwardDiagonal );
			g.FillRectangle( leftButtonBrush , leftButtonRectangle );
			g.FillRectangle( rightButtonBrush , rightButtonRectangle );
			rightButtonBrush.Dispose();
			leftButtonBrush.Dispose();

			Pen buttonBorderPen = new Pen( scheme.NavigationButtonBorderColor );
			g.DrawRectangle( buttonBorderPen , leftButtonRectangle );
			g.DrawRectangle( buttonBorderPen , rightButtonRectangle );
			buttonBorderPen.Dispose();
		}


		/// <summary>
		/// Rebuilds the renderer.
		/// </summary>
		/// <param name="images">The images to build.</param>
		/// <param name="scheme">The scheme to use.</param>
		public void RebuildRenderer( List<AvatarBrowserImageObject> images , AvatarBrowserImageObject selectedImage , AvatarBrowserScheme scheme ) {
			int calculatedWidth = scheme.AvatarSpacing;
			int calculatedHeight = 128;

			calculatedWidth = ( images.Count - 1 ) * 48 + ( images.Count ) * scheme.AvatarSpacing + 128;

			if( _background != null ) {
				_background.Dispose();
			}

			_background = new Bitmap( calculatedWidth , calculatedHeight );
			Graphics backgroundGraphics = Graphics.FromImage( _background );
			backgroundGraphics.SmoothingMode = SmoothingMode.AntiAlias;
			int leftOffset = scheme.AvatarSpacing;
			int topOffset = 0;

			foreach( AvatarBrowserImageObject image in images ) {
				if( image == selectedImage ) {
					topOffset = calculatedHeight / 2 - 64;

					Rectangle backgroundRectangle = new Rectangle( leftOffset , topOffset , 128 , 128 );
					GraphicsPath backgroundPath = DrawingTools.GetRoundedRect( backgroundRectangle , 7 );
					Rectangle backgroundTopRectangle = new Rectangle( leftOffset , topOffset , 128 , 64 );
					GraphicsPath backgroundTopPath = DrawingTools.GetRoundedRect( backgroundTopRectangle , true , true , false , false , 7 );
					Rectangle backgroundBottomRectangle = new Rectangle( leftOffset , backgroundTopRectangle.Bottom - 1 , 128 , 64 );
					GraphicsPath backgroundBottomPath = DrawingTools.GetRoundedRect( backgroundBottomRectangle , false , false , true , true , 7 );
					LinearGradientBrush backgroundTopBrush = new LinearGradientBrush( backgroundTopRectangle , scheme.SelectedBackgroundColor1 , scheme.SelectedBackgroundColor2 , LinearGradientMode.Vertical );
					backgroundTopBrush.WrapMode = WrapMode.TileFlipY;
					LinearGradientBrush backgroundBottomBrush = new LinearGradientBrush( backgroundBottomRectangle , scheme.SelectedBackgroundColor3 , scheme.SelectedBackgroundColor4 , LinearGradientMode.Vertical );
					backgroundBottomBrush.WrapMode = WrapMode.TileFlipY;
					Pen borderPen = new Pen( scheme.SelectedBorderColor );
					backgroundGraphics.FillPath( backgroundTopBrush , backgroundTopPath );
					backgroundGraphics.FillPath( backgroundBottomBrush , backgroundBottomPath );
					backgroundGraphics.DrawPath( borderPen , backgroundPath );
					borderPen.Dispose();
					backgroundTopBrush.Dispose();
					backgroundBottomBrush.Dispose();

					backgroundPath.Dispose();
					backgroundTopPath.Dispose();
					backgroundBottomPath.Dispose();

					backgroundGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
					backgroundGraphics.DrawImage( image.Image , new Rectangle( leftOffset , topOffset , 128 , 128 ) );

					leftOffset += 128;
				} else {
					topOffset = calculatedHeight / 2 - 24;
					backgroundGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
					backgroundGraphics.DrawImage( image.Image , new Rectangle( leftOffset , topOffset , 48 , 48 ) );
					leftOffset += 48;
				}

				leftOffset += scheme.AvatarSpacing;
			}

			backgroundGraphics.Dispose();
		}

		#endregion

	}

}
