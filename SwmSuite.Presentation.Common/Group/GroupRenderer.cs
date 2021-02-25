using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Drawing.Text;

namespace SwmSuite.Presentation.Common.Group {
	
	public class GroupRenderer : IDisposable {

		#region -_ Private members _-

		private SolidBrush _captionBrush;
		private StringFormat _captionFormat;
		private Pen _borderPen;

		#endregion

		#region -_ Public Properties _-

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public GroupRenderer() {
		}

		#endregion

		#region -_ Public methods _-

		public void Render( Graphics graphics , Rectangle drawRectangle , String caption , GroupScheme scheme ) {
			graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			Rectangle captionRectangle = new Rectangle( drawRectangle.Left , drawRectangle.Top , drawRectangle.Width , GetCaptionHeight( graphics , caption , scheme ) );
			graphics.DrawLine( GetBorderPen( scheme ) , captionRectangle.Left + GetCaptionWidth(graphics,caption,scheme) , captionRectangle.Top + captionRectangle.Height / 2 , captionRectangle.Right , captionRectangle.Top + captionRectangle.Height / 2 );
			graphics.DrawString( caption , scheme.CaptionFont , GetCaptionBrush( scheme ) , captionRectangle , GetCaptionFormat() );
			graphics.TextRenderingHint = TextRenderingHint.SystemDefault;
		}

		public int GetCaptionHeight( Graphics graphics , String caption , GroupScheme scheme ) {
			return (int)graphics.MeasureString( caption , scheme.CaptionFont ).Height;
		}

		public int GetCaptionWidth( Graphics graphics , String caption , GroupScheme scheme ) {
			return (int)graphics.MeasureString( caption , scheme.CaptionFont ).Width + 1;
		}

		public void Invalidate() {
			if( _captionBrush != null ) {
				_captionBrush.Dispose();
				_captionBrush = null;
			}
			if( _captionFormat != null ) {
				_captionFormat.Dispose();
				_captionFormat = null;
			}
			if( _borderPen != null ) {
				_borderPen.Dispose();
				_borderPen = null;
			}
		}

		#endregion

		#region -_ Private Methods _-

		public SolidBrush GetCaptionBrush( GroupScheme scheme ) {
			if( _captionBrush == null ) {
				_captionBrush = new SolidBrush( scheme.CaptionColor );
			}
			return _captionBrush;
		}

		public StringFormat GetCaptionFormat() {
			if( _captionFormat == null ) {
				_captionFormat = new StringFormat() { Alignment = StringAlignment.Near , LineAlignment = StringAlignment.Center };
			}
			return _captionFormat;
		}

		public Pen GetBorderPen(GroupScheme scheme) {
			if( _borderPen == null ) {
				_borderPen = new Pen( scheme.BorderColor , (float)scheme.BorderWidth );
			}
			return _borderPen;
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
