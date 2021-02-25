using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using SwmSuite.Presentation.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace SwmSuite.Presentation.Common.LoginButton {
	
	public class LoginButtonRenderer : IDisposable {

		#region -_ Private Members _-

		private Pen _outerBorderPen;
		private Pen _borderPen;
		private Pen _innerBorderPen;

		private LinearGradientBrush _backgroundBrush1;
		private LinearGradientBrush _backgroundBrush2;
		private LinearGradientBrush _avatarAreaBrush1;
		private LinearGradientBrush _avatarAreaBrush2;

		#endregion

		#region -_ Public properties _-



		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public LoginButtonRenderer() {
		}

		#endregion

		#region -_ Public Methods _-

		public void Render( Graphics graphics , Rectangle drawRectangle , LoginButtonScheme scheme , bool avatarArea ) {
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			
			
			
			Rectangle outerBorderRectangle = new Rectangle( drawRectangle.Left , drawRectangle.Top , drawRectangle.Width - 1 , drawRectangle.Height - 1 );
			Rectangle borderRectangle = new Rectangle( drawRectangle.Left+1 , drawRectangle.Top+1 , drawRectangle.Width-3 , drawRectangle.Height-3 );
			Rectangle innerBorderRectangle = new Rectangle( drawRectangle.Left+2 , drawRectangle.Top+2 , drawRectangle.Width - 5 , drawRectangle.Height - 5 );

			// render background
			Rectangle topRectangle = new Rectangle( outerBorderRectangle.Left , outerBorderRectangle.Top , outerBorderRectangle.Width , outerBorderRectangle.Height / 2 + 1 );
			Rectangle bottomRectangle = new Rectangle( outerBorderRectangle.Left , outerBorderRectangle.Top + outerBorderRectangle.Height / 2-1 , outerBorderRectangle.Width , outerBorderRectangle.Height / 2 );
			GraphicsPath topPath = DrawingTools.GetRoundedRect( topRectangle , true , true , false , false , 20 );
			GraphicsPath bottomPath = DrawingTools.GetRoundedRect( bottomRectangle , false , false , true , true , 20 );
			graphics.FillPath( GetBackgroundBrush1( scheme , topRectangle ) , topPath );
			graphics.FillPath( GetBackgroundBrush2( scheme , bottomRectangle ) , bottomPath );
			topPath.Dispose();
			bottomPath.Dispose();

			// render avatar area.
			if( avatarArea ) {
				Rectangle avatarTopAreaRectangle = new Rectangle( outerBorderRectangle.Left , outerBorderRectangle.Top , scheme.AvatarAreaWidth , outerBorderRectangle.Height / 2 + 1 );
				Rectangle avatarBottomAreaRectangle = new Rectangle( outerBorderRectangle.Left , outerBorderRectangle.Top + outerBorderRectangle.Height / 2 - 1 , scheme.AvatarAreaWidth , outerBorderRectangle.Height / 2 );
				GraphicsPath avatarTopAreaPath = DrawingTools.GetRoundedRect( avatarTopAreaRectangle , true , false , false , false , 19 );
				GraphicsPath avatarBottomAreaPath = DrawingTools.GetRoundedRect( avatarBottomAreaRectangle , false , false , true , false , 19 );
				//GraphicsPath avatarClipPath = DrawingTools.GetRoundedRect( new Rectangle( outerBorderRectangle.Left , outerBorderRectangle.Top , scheme.AvatarAreaWidth - 20 , outerBorderRectangle.Height ) , true , false , true , false , 20 );
				//avatarClipPath.AddEllipse( new Rectangle( outerBorderRectangle.Left + scheme.AvatarAreaWidth - 40 , outerBorderRectangle.Top , 40 , outerBorderRectangle.Height ) );
				//avatarClipPath.FillMode = FillMode.Winding;
				//graphics.SetClip( avatarClipPath );
				graphics.FillPath( GetAvatarAreaBrush1( scheme , avatarTopAreaRectangle ) , avatarTopAreaPath );
				graphics.FillPath( GetAvatarAreaBrush2( scheme , avatarBottomAreaRectangle ) , avatarBottomAreaPath );
				//graphics.ResetClip();
				//avatarClipPath.Dispose();
				avatarBottomAreaPath.Dispose();
				avatarTopAreaPath.Dispose();
			}

			// render borders
			GraphicsPath outerBorderPath = DrawingTools.GetRoundedRect( outerBorderRectangle , 20 );
			GraphicsPath borderPath = DrawingTools.GetRoundedRect( borderRectangle , 19 );
			GraphicsPath innerBorderPath = DrawingTools.GetRoundedRect( innerBorderRectangle , 18 );
			graphics.DrawPath( GetOuterBorderPen( scheme ) , outerBorderPath );
			graphics.DrawPath( GetBorderPen( scheme ) , borderPath );
			graphics.DrawPath( GetInnerBorderPen( scheme ) , innerBorderPath );
			borderPath.Dispose();
			outerBorderPath.Dispose();
			graphics.SmoothingMode = SmoothingMode.Default;

			// render glow.
			if( scheme.BackgroundGlowColor != Color.Transparent ) {
				graphics.SetClip( innerBorderPath );
				Rectangle glow = Rectangle.FromLTRB( outerBorderRectangle.Left ,
					outerBorderRectangle.Top + (int)( (float)outerBorderRectangle.Height * .5f ) ,
					outerBorderRectangle.Right , outerBorderRectangle.Bottom );
				GraphicsPath glowPath = DrawingTools.CreateRadialPath( glow );
				PathGradientBrush brush = new PathGradientBrush( glowPath );

				RectangleF bounds = glowPath.GetBounds();
				brush.CenterPoint = new PointF( ( bounds.Left + bounds.Right ) / 2f , ( bounds.Top + bounds.Bottom ) / 2f );
				brush.CenterColor = Color.FromArgb( 255 , scheme.BackgroundGlowColor );
				brush.SurroundColors = new Color[] { Color.FromArgb( 0 , scheme.BackgroundGlowColor ) };
				graphics.FillPath( brush , glowPath );
				graphics.ResetClip();
			}
			innerBorderPath.Dispose();
		}

		public void DrawAvatar( Graphics graphics , Rectangle drawRectangle , Image avatar ) {
			int avatarWidth = drawRectangle.Height - 10;
			int avatarHeight = avatarWidth;
			if( avatar != null ) {
				Rectangle avatarPlacement = new Rectangle( drawRectangle.Left + drawRectangle.Width / 2 - avatarWidth / 2 , drawRectangle.Top + drawRectangle.Height / 2 - avatarHeight / 2 , avatarWidth , avatarHeight );
				graphics.DrawImage( avatar , avatarPlacement );
			}
		}

		public void RenderCaption( Graphics graphics , Rectangle drawRectangle , LoginButtonScheme scheme,String caption ) {
			graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			TextRenderer.DrawText( graphics , caption , scheme.CaptionFont , drawRectangle , scheme.CaptionColor , TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter );
			graphics.TextRenderingHint = TextRenderingHint.SystemDefault;
		}

		public void Invalidate() {
			if( _outerBorderPen != null ) {
				_outerBorderPen.Dispose();
				_outerBorderPen = null;
			}
			if( _borderPen != null ) {
				_borderPen.Dispose();
				_borderPen = null;
			}
			if( _innerBorderPen != null ) {
				_innerBorderPen.Dispose();
				_innerBorderPen = null;
			}
			if( _backgroundBrush1 != null ) {
				_backgroundBrush1.Dispose();
				_backgroundBrush1 = null;
			}
			if( _backgroundBrush2 != null ) {
				_backgroundBrush2.Dispose();
				_backgroundBrush2 = null;
			}
			if( _avatarAreaBrush1 != null ) {
				_avatarAreaBrush1.Dispose();
				_avatarAreaBrush1 = null;
			}
			if( _avatarAreaBrush2 != null ) {
				_avatarAreaBrush2.Dispose();
				_avatarAreaBrush2 = null;
			}
		}

		#endregion

		#region -_ Private Methods _-

		private Pen GetOuterBorderPen( LoginButtonScheme scheme ) {
			if( _outerBorderPen == null ) {
				_outerBorderPen = new Pen( scheme.OuterBorderColor );
			}
			return _outerBorderPen;
		}

		private Pen GetBorderPen( LoginButtonScheme scheme ) {
			if( _borderPen == null ) {
				_borderPen = new Pen( scheme.BorderColor );
			}
			return _borderPen;
		}

		private Pen GetInnerBorderPen( LoginButtonScheme scheme ) {
			if( _innerBorderPen == null ) {
				_innerBorderPen = new Pen( scheme.InnerBorderColor );
			}
			return _innerBorderPen;
		}

		private LinearGradientBrush GetBackgroundBrush1( LoginButtonScheme scheme , Rectangle bounds ) {
			if( _backgroundBrush1 == null ) {
				_backgroundBrush1 = new LinearGradientBrush( bounds , scheme.BackgroundColor1 , scheme.BackgroundColor2 , LinearGradientMode.Vertical );
			}
			return _backgroundBrush1;
		}

		private LinearGradientBrush GetBackgroundBrush2( LoginButtonScheme scheme , Rectangle bounds ) {
			if( _backgroundBrush2 == null ) {
				_backgroundBrush2 = new LinearGradientBrush( bounds , scheme.BackgroundColor3 , scheme.BackgroundColor4 , LinearGradientMode.Vertical );
			}
			return _backgroundBrush2;
		}

		private LinearGradientBrush GetAvatarAreaBrush1( LoginButtonScheme scheme , Rectangle bounds ) {
			if( _avatarAreaBrush1 == null ) {
				_avatarAreaBrush1 = new LinearGradientBrush( bounds , scheme.AvatarBackgroundColor1 , scheme.AvatarBackgroundColor2 , LinearGradientMode.Vertical );
			}
			return _avatarAreaBrush1;
		}

		private LinearGradientBrush GetAvatarAreaBrush2( LoginButtonScheme scheme , Rectangle bounds ) {
			if( _avatarAreaBrush2 == null ) {
				_avatarAreaBrush2 = new LinearGradientBrush( bounds , scheme.AvatarBackgroundColor3 , scheme.AvatarBackgroundColor4 , LinearGradientMode.Vertical );
			}
			return _avatarAreaBrush2;
		}

		#endregion

		#region -_ IDisposable Members _-

		public void Dispose() {
			GC.SuppressFinalize( this );
			Dispose( true );
		}

		protected void Dispose( bool dispose ) {
			if( dispose ) {
				Invalidate();
			}
		}

		#endregion

	}

}
