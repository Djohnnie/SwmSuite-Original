using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace SwmSuite.Presentation.Common.DialogHeader {
	
	public class DialogHeaderRenderer : IDisposable {

		#region -_ Private Members _-

		private LinearGradientBrush _backgroundBrush = null;
		private StringFormat _titleFormat = null;
		private SolidBrush _titleBrush = null;

		private StringFormat _subTitleFormat = null;
		private SolidBrush _subTitleBrush = null;

		private StringFormat _onlyTitleFormat = null;

		#endregion

		#region -_ Public Methods _-

		public void RenderBackground( Graphics graphics , Rectangle drawRect , DialogHeaderScheme scheme ) {
			graphics.FillRectangle( GetBackgroundBrush( drawRect , scheme ) , drawRect );
		}

		public void RenderTitle( Graphics graphics , Rectangle drawRect , DialogHeaderScheme scheme , string title , string subTitle , bool onlyMainText ) {
			TextRenderingHint old = graphics.TextRenderingHint;
			graphics.TextRenderingHint = scheme.TitleRendering;
			Rectangle titleRectangle = new Rectangle( drawRect.Left , drawRect.Top , drawRect.Width , drawRect.Height / 2 );
			Rectangle subTitleRectangle = new Rectangle( drawRect.Left , drawRect.Top + drawRect.Height / 2 , drawRect.Width , drawRect.Height / 2 );
			if( onlyMainText ) {
				graphics.DrawString( title , scheme.TitleFont , GetTitleBrush( scheme ) , drawRect , GetTitleFormat2() );
			} else {
				graphics.DrawString( title , scheme.TitleFont , GetTitleBrush( scheme ) , titleRectangle , GetTitleFormat() );
				graphics.DrawString( subTitle , scheme.SubTitleFont , GetSubTitleBrush( scheme ) , subTitleRectangle , GetSubTitleFormat() );
			}
			graphics.TextRenderingHint = old;
		}

		public void Invalidate() {
			if( _backgroundBrush != null ) {
				_backgroundBrush.Dispose();
				_backgroundBrush = null;
			}
			if( _titleFormat != null ) {
				_titleFormat.Dispose();
				_titleFormat = null;
			}
			if( _titleBrush != null ) {
				_titleBrush.Dispose();
				_titleBrush = null;
			}
			if( _subTitleFormat != null ) {
				_subTitleFormat.Dispose();
				_subTitleFormat = null;
			}
			if( _subTitleBrush != null ) {
				_subTitleBrush.Dispose();
				_subTitleBrush = null;
			}
			if( _onlyTitleFormat != null ) {
				_onlyTitleFormat.Dispose();
				_onlyTitleFormat = null;
			}
		}

		#endregion

		#region -_ Private Methods _-

		private LinearGradientBrush GetBackgroundBrush( Rectangle bounds , DialogHeaderScheme scheme ) {
			if( _backgroundBrush == null ) {
				_backgroundBrush = new LinearGradientBrush( bounds , scheme.BackgroundColor1 , scheme.BackgroundColor2 , LinearGradientMode.Horizontal );
			}

			return _backgroundBrush;
		}

		private StringFormat GetTitleFormat() {
			if( _titleFormat == null ) {
				_titleFormat = new StringFormat();
				_titleFormat.Alignment = StringAlignment.Near;
				_titleFormat.LineAlignment = StringAlignment.Far;
			}

			return _titleFormat;
		}

		private SolidBrush GetTitleBrush( DialogHeaderScheme scheme ) {
			if( _titleBrush == null ) {
				_titleBrush = new SolidBrush( scheme.TitleColor );
			}

			return _titleBrush;
		}

		private StringFormat GetSubTitleFormat() {
			if( _subTitleFormat == null ) {
				_subTitleFormat = new StringFormat();
				_subTitleFormat.Alignment = StringAlignment.Near;
				_subTitleFormat.LineAlignment = StringAlignment.Near;
			}

			return _subTitleFormat;
		}

		private SolidBrush GetSubTitleBrush( DialogHeaderScheme scheme ) {
			if( _subTitleBrush == null ) {
				_subTitleBrush = new SolidBrush( scheme.SubTitleColor );
			}

			return _subTitleBrush;
		}

		private StringFormat GetTitleFormat2() {
			if( _onlyTitleFormat == null ) {
				_onlyTitleFormat = new StringFormat();
				_onlyTitleFormat.Alignment = StringAlignment.Near;
				_onlyTitleFormat.LineAlignment = StringAlignment.Center;
			}

			return _onlyTitleFormat;
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
