using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;
using SwmSuite.Presentation.Drawing;

namespace SwmSuite.Presentation.Common.WindowPanel {
	
	public class WindowPanelRenderer : IDisposable {

		#region -_ Private Methods _-

		private LinearGradientBrush _backgroundBrush;
		private Pen _borderPen;

		#endregion

		#region -_ Public Properties _-

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public WindowPanelRenderer() {
		}

		#endregion

		#region -_ Public Methods _-

		public void Render( Graphics graphics , Rectangle drawRectangle , WindowPanelScheme scheme ) {
			Rectangle innerBounds = new Rectangle( drawRectangle.Left + 10 , drawRectangle.Top + 10 , drawRectangle.Width - 21 , drawRectangle.Height - 21 );
			DrawingTools.DrawShadow( graphics , innerBounds );
			graphics.FillRectangle( GetBackgroundBrush( innerBounds , scheme ) , innerBounds );
			graphics.DrawRectangle( GetBorderPen( scheme ) , innerBounds );
		}

		public void Invalidate() {
			if( _backgroundBrush != null ) {
				_backgroundBrush.Dispose();
				_backgroundBrush = null;
			}
			if( _borderPen != null ) {
				_borderPen.Dispose();
				_borderPen = null;
			}
		}

		#endregion

		#region -_ Private Methods _-

		private LinearGradientBrush GetBackgroundBrush( Rectangle bounds , WindowPanelScheme scheme ){
			if( _backgroundBrush == null ){
				_backgroundBrush = new LinearGradientBrush( bounds , scheme.BackgroundColor1,scheme.BackgroundColor2 ,  LinearGradientMode.ForwardDiagonal );
			}
			return _backgroundBrush;
		}

		private Pen GetBorderPen( WindowPanelScheme scheme ) {
			if( _borderPen == null ) {
				_borderPen = new Pen( scheme.BorderColor );
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
