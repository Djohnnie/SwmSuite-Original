using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using SwmSuite.Presentation.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace SwmSuite.Presentation.Common.PopUpButton {
	
	public class PopUpButtonRenderer : IDisposable  {

		#region -_ Private Members _-

		private SolidBrush _captionBrush;
		private StringFormat _captionFormat;

		#endregion

		#region -_ Public Properties _-

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public PopUpButtonRenderer() {

		}

		#endregion

		#region -_ Public Methods _-

		public void RenderImage( Graphics g , Rectangle drawRectangle , Image image ) {
			int xPos = drawRectangle.Width / 2 - image.Width / 2;
			int yPos = drawRectangle.Height / 2 - image.Height / 2;
			g.DrawImageUnscaled( image , xPos , yPos );
		}

		public void RenderBackground( Graphics g , Rectangle drawRectangle , PopUpButtonScheme scheme ) {
			GraphicsPath borderPath = DrawingTools.GetRoundedRect( drawRectangle , 5 );
			LinearGradientBrush backgroundBrush = new LinearGradientBrush( drawRectangle , scheme.BackgroundColor1 , scheme.BackgroundColor2 , scheme.BackgroundGradientMode );
			g.FillPath( backgroundBrush , borderPath );
			backgroundBrush.Dispose();
			borderPath.Dispose();
		}

		public void RenderBorder( Graphics g , Rectangle drawRectangle , PopUpButtonScheme scheme ) {
			g.SmoothingMode = SmoothingMode.AntiAlias;
			GraphicsPath borderPath = DrawingTools.GetRoundedRect( drawRectangle , 5 );
			Pen borderPen = new Pen( scheme.BorderColor );
			g.DrawPath( borderPen , borderPath );
			borderPen.Dispose();
			borderPath.Dispose();
			g.SmoothingMode = SmoothingMode.Default;
		}

		public void RenderCaption( Graphics g , Rectangle drawRectangle , String caption , PopUpButtonScheme scheme ) {
			g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			TextRenderer.DrawText( g , caption , scheme.CaptionFont , drawRectangle , scheme.CaptionColor , TextFormatFlags.Left | TextFormatFlags.Top );
			g.TextRenderingHint = TextRenderingHint.SystemDefault;
		}

		public void RenderSubCaption( Graphics g , Rectangle drawRectangle , String caption , PopUpButtonScheme scheme ) {
			g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			TextRenderer.DrawText( g , caption , scheme.SubCaptionFont , drawRectangle , scheme.SubCaptionColor , TextFormatFlags.Left | TextFormatFlags.Top | TextFormatFlags.WordBreak );
			g.TextRenderingHint = TextRenderingHint.SystemDefault;
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
		}

		#endregion

		#region -_ Private Methods _-

		private SolidBrush GetCaptionBrush( PopUpButtonScheme scheme ) {
			if( _captionBrush == null ) {
				_captionBrush = new SolidBrush( scheme.CaptionColor );
			}
			return _captionBrush;
		}

		private StringFormat GetCaptionFormat() {
			if( _captionFormat == null ) {
				_captionFormat = new StringFormat() { Alignment = StringAlignment.Center , LineAlignment = StringAlignment.Center };
			}
			return _captionFormat;
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
