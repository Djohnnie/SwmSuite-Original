using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SwmSuite.Presentation.Common.StatusGroup {
	
	public class StatusGroupRenderer : IDisposable {

		#region -_ Private Members _-

		private Pen _borderPen;
		private LinearGradientBrush _statusGoodBrush;
		private LinearGradientBrush _statusWarnBrush;
		private LinearGradientBrush _statusBadBrush;
		private LinearGradientBrush _statusInvalidBrush;
		private SolidBrush _backgroundBrush;

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="StatusGroupRenderer"/> class.
		/// </summary>
		public StatusGroupRenderer() {

		}

		#endregion

		#region -_ Public Methods _-

		public void Render( Graphics graphics , Rectangle drawRectangle , StatusGroupStatus status , StatusGroupScheme scheme ) {
			// Render background.
			graphics.FillRectangle( GetBackgroundBrush( scheme ) , drawRectangle );
			// Render status.
			Rectangle statusRectangle = drawRectangle;
			switch( scheme.StatusAlignment ) {
				case StatusGroupAlignment.Left: {
						statusRectangle = new Rectangle(
							drawRectangle.Left + 1 , drawRectangle.Top + 1 , scheme.StatusSize , drawRectangle.Height - 1 );
						break;
					}
				case StatusGroupAlignment.Top: {
						statusRectangle = new Rectangle(
							drawRectangle.Left + 1 , drawRectangle.Top + 1 , drawRectangle.Width - 1 , scheme.StatusSize );
						break;
					}
				case StatusGroupAlignment.Right: {
						statusRectangle = new Rectangle(
							drawRectangle.Right - scheme.StatusSize , drawRectangle.Top + 1 , scheme.StatusSize , drawRectangle.Height - 1 );
						break;
					}
				case StatusGroupAlignment.Bottom: {
						statusRectangle = new Rectangle(
							drawRectangle.Left + 1 , drawRectangle.Bottom - scheme.StatusSize , drawRectangle.Width - 1 , scheme.StatusSize );
						break;
					}
			}
			switch( status ){
				case StatusGroupStatus.Good:{
						graphics.FillRectangle( GetStatusGoodBrush( statusRectangle , scheme ) , statusRectangle );
					break;
				}
				case StatusGroupStatus.Warn:{
						graphics.FillRectangle( GetStatusWarnBrush( statusRectangle , scheme ) , statusRectangle );
					break;
				}
				case StatusGroupStatus.Bad:{
						graphics.FillRectangle( GetStatusBadBrush( statusRectangle , scheme ) , statusRectangle );
					break;
				}
				case StatusGroupStatus.Invalid: {
						graphics.FillRectangle( GetStatusInvalidBrush( statusRectangle , scheme ) , statusRectangle );
						break;
					}
			}
			// Render border.
			graphics.DrawRectangle( GetBorderPen( scheme ) , drawRectangle );
		}

		/// <summary>
		/// Invalidates this instance.
		/// </summary>
		public void Invalidate() {
			if( _borderPen != null ) {
				_borderPen.Dispose();
				_borderPen = null;
			}
			if( _statusGoodBrush != null ) {
				_statusGoodBrush.Dispose();
				_statusGoodBrush = null;
			}
			if( _statusWarnBrush != null ) {
				_statusWarnBrush.Dispose();
				_statusWarnBrush = null;
			}
			if( _statusBadBrush != null ) {
				_statusBadBrush.Dispose();
				_statusBadBrush = null;
			}
			if( _statusInvalidBrush != null ) {
				_statusInvalidBrush.Dispose();
				_statusInvalidBrush = null;
			}
			if( _backgroundBrush != null ) {
				_backgroundBrush.Dispose();
				_backgroundBrush = null;
			}
		}

		#endregion

		#region -_ Private Methods _-

		private Pen GetBorderPen( StatusGroupScheme scheme ) {
			if( _borderPen == null ) {
				_borderPen = new Pen( scheme.BorderColor );
			}
			return _borderPen;
		}

		private LinearGradientBrush GetStatusGoodBrush( Rectangle bounds , StatusGroupScheme scheme ) {
			if( _statusGoodBrush == null ) {
				_statusGoodBrush = new LinearGradientBrush( bounds , scheme.GoodColor1 , scheme.GoodColor2 , LinearGradientMode.Vertical );
			}
			return _statusGoodBrush;
		}

		private LinearGradientBrush GetStatusWarnBrush( Rectangle bounds , StatusGroupScheme scheme ) {
			if( _statusWarnBrush == null ) {
				_statusWarnBrush = new LinearGradientBrush( bounds , scheme.WarnColor1 , scheme.WarnColor2 , LinearGradientMode.Vertical );
			}
			return _statusWarnBrush;
		}

		private LinearGradientBrush GetStatusBadBrush( Rectangle bounds , StatusGroupScheme scheme ) {
			if( _statusBadBrush == null ) {
				_statusBadBrush = new LinearGradientBrush( bounds , scheme.BadColor1 , scheme.BadColor2 , LinearGradientMode.Vertical );
			}
			return _statusBadBrush;
		}

		private LinearGradientBrush GetStatusInvalidBrush( Rectangle bounds , StatusGroupScheme scheme ) {
			if( _statusInvalidBrush == null ) {
				_statusInvalidBrush = new LinearGradientBrush( bounds , scheme.InvalidColor1 , scheme.InvalidColor2 , LinearGradientMode.Vertical );
			}
			return _statusInvalidBrush;
		}

		private SolidBrush GetBackgroundBrush( StatusGroupScheme scheme ) {
			if( _backgroundBrush == null ) {
				_backgroundBrush = new SolidBrush( scheme.BackgroundColor );
			}
			return _backgroundBrush;
		}

		#endregion

		#region -_ IDisposable Members _-

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		public void Dispose() {
			GC.SuppressFinalize( this );
			Dispose( true );
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="dispose"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected void Dispose( bool dispose ) {
			if( dispose ) {
				Invalidate();
			}
		}

		#endregion

	}

}
