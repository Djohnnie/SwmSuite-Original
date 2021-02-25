using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;

namespace SwmSuite.Presentation.Common.MirrorText {
	
	public class MirrorTextRenderer : IDisposable {

		#region -_ Private Members _-

		private SolidBrush _textBrush;
		private StringFormat _textFormat;
		private Bitmap _mirror;

		#endregion

		#region -_ Public Properties _-

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public MirrorTextRenderer() {
		}

		#endregion

		#region -_ Public Methods _-

		public void Render( Graphics graphics , Rectangle drawRectangle , String text , MirrorTextScheme scheme ) {
			graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
			Rectangle textRectangle = new Rectangle( drawRectangle.Left , drawRectangle.Top + scheme.Correction , drawRectangle.Width , drawRectangle.Height / 2 );
			Rectangle mirrorRectangle = new Rectangle( drawRectangle.Left , drawRectangle.Top + drawRectangle.Height / 2 , drawRectangle.Width , drawRectangle.Height / 2 );
			graphics.DrawString( text , scheme.TextFont , GetTextBrush( scheme ) , textRectangle , GetTextFormat() );
			graphics.DrawImageUnscaled( GetMirrorImage( mirrorRectangle , text , scheme ) , mirrorRectangle.Left , mirrorRectangle.Top - scheme.Correction );
			graphics.TextRenderingHint = TextRenderingHint.SystemDefault;
		}

		public void Invalidate() {
			if( _textBrush != null ) {
				_textBrush.Dispose();
				_textBrush = null;
			}
			if( _textFormat != null ) {
				_textFormat.Dispose();
				_textFormat = null;
			}
			if( _mirror != null ) {
				_mirror.Dispose();
				_mirror = null;
			}
		}

		#endregion

		#region -_ Private Methods _-

		private SolidBrush GetTextBrush( MirrorTextScheme scheme ) {
			if( _textBrush == null ) {
				_textBrush = new SolidBrush( scheme.TextColor );
			}
			return _textBrush;
		}

		private StringFormat GetTextFormat() {
			if( _textFormat == null ) {
				_textFormat = new StringFormat() { Alignment = StringAlignment.Center , LineAlignment = StringAlignment.Far };
			}
			return _textFormat;
		}

		private Image GetMirrorImage( Rectangle bounds , String text , MirrorTextScheme scheme ) {
			if( _mirror == null ) {
				LinearGradientBrush textBrush = new LinearGradientBrush( bounds , Color.Transparent , Color.FromArgb( 255 , scheme.TextColor ) , LinearGradientMode.Vertical );
				textBrush.Blend.Positions = new float[] { 0.0f , 0.25f , 1.0f };
				_mirror = new Bitmap( bounds.Width , bounds.Height );
				Graphics graphics = Graphics.FromImage( _mirror );
				graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
				//graphics.Clear( Color.Black );
				graphics.DrawString( text , scheme.TextFont , textBrush , new Rectangle( 0 , 0 , bounds.Width , bounds.Height ) , GetTextFormat() );
				graphics.Dispose();
				_mirror.RotateFlip( RotateFlipType.RotateNoneFlipY );
				textBrush.Dispose();
			}
			return _mirror;
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
