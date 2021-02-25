using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using SwmSuite.Presentation.Drawing;

namespace SimpleWorkfloorManagementSuite.Controls {

	public class AgendaSelectorRenderer : IDisposable {

		#region -_ Private Members _-

		private SolidBrush _backgroundFillBrush;
		private Pen _borderPen;

		private SolidBrush _button1FillBrush;
		private SolidBrush _button1FillBrushHovered;
		private Pen _button1BorderPen;

		private SolidBrush _button2FillBrush;
		private SolidBrush _button2FillBrushHovered;
		private Pen _button2BorderPen;

		private SolidBrush _button3FillBrush;
		private SolidBrush _button3FillBrushHovered;
		private Pen _button3BorderPen;

		private SolidBrush _button4FillBrush;
		private SolidBrush _button4FillBrushHovered;
		private Pen _button4BorderPen;

		private SolidBrush _button5FillBrush;
		private SolidBrush _button5FillBrushHovered;
		private Pen _button5BorderPen;

		private SolidBrush _button6FillBrush;
		private SolidBrush _button6FillBrushHovered;
		private Pen _button6BorderPen;

		private SolidBrush _button7FillBrush;
		private SolidBrush _button7FillBrushHovered;
		private Pen _button7BorderPen;

		private SolidBrush _button8FillBrush;
		private SolidBrush _button8FillBrushHovered;
		private Pen _button8BorderPen;

		private SolidBrush _button9FillBrush;
		private SolidBrush _button9FillBrushHovered;
		private Pen _button9BorderPen;

		#endregion

		#region -_ Public Properties _-



		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="AgendaSelectorRenderer"/> class.
		/// </summary>
		public AgendaSelectorRenderer() {
		}

		#endregion

		#region -_ Public Methods _-

		public void RenderBackground( Graphics graphics , Rectangle bounds , AgendaSelectorScheme scheme ) {
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			GraphicsPath borderPath = DrawingTools.GetRoundedRect( bounds , scheme.BorderRoundedCornerRadius );
			graphics.FillPath( GetBackgroundFillBrush( scheme ) , borderPath );
			graphics.DrawPath( GetBorderPen( scheme ) , borderPath );
			borderPath.Dispose();
		}

		public void DrawButton( Graphics graphics , Rectangle bounds , AgendaSelectorScheme scheme , AgendaSelectorButton button , int buttonIndex ) {
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			GraphicsPath borderPath = DrawingTools.GetRoundedRect( bounds , scheme.ButtonRoundedCornerRadius );
			int colorIndex = buttonIndex % 9 + 1;
			graphics.FillPath( button.Hovered ? GetButtonFillBrushHovered( colorIndex , scheme ) : GetButtonFillBrush( colorIndex , scheme ) , borderPath );
			graphics.DrawPath( GetButtonBorderPen( colorIndex , scheme ) , borderPath );
			borderPath.Dispose();
		}

		public void Invalidate() {
			if( _backgroundFillBrush != null ) {
				_backgroundFillBrush.Dispose();
				_backgroundFillBrush = null;
			}
			if( _borderPen != null ) {
				_borderPen.Dispose();
				_borderPen = null;
			}
			if( _button1FillBrush != null ) {
				_button1FillBrush.Dispose();
				_button1FillBrush = null;
			}
			if( _button1FillBrushHovered != null ) {
				_button1FillBrushHovered.Dispose();
				_button1FillBrushHovered = null;
			}
			if( _button1BorderPen != null ) {
				_button1BorderPen.Dispose();
				_button1BorderPen = null;
			}
			if( _button2FillBrush != null ) {
				_button2FillBrush.Dispose();
				_button2FillBrush = null;
			}
			if( _button2FillBrushHovered != null ) {
				_button2FillBrushHovered.Dispose();
				_button2FillBrushHovered = null;
			}
			if( _button2BorderPen != null ) {
				_button2BorderPen.Dispose();
				_button2BorderPen = null;
			}
			if( _button3FillBrush != null ) {
				_button3FillBrush.Dispose();
				_button3FillBrush = null;
			}
			if( _button3FillBrushHovered != null ) {
				_button3FillBrushHovered.Dispose();
				_button3FillBrushHovered = null;
			}
			if( _button3BorderPen != null ) {
				_button3BorderPen.Dispose();
				_button3BorderPen = null;
			}
			if( _button4FillBrush != null ) {
				_button4FillBrush.Dispose();
				_button4FillBrush = null;
			}
			if( _button4FillBrushHovered != null ) {
				_button4FillBrushHovered.Dispose();
				_button4FillBrushHovered = null;
			}
			if( _button4BorderPen != null ) {
				_button4BorderPen.Dispose();
				_button4BorderPen = null;
			}
			if( _button5FillBrush != null ) {
				_button5FillBrush.Dispose();
				_button5FillBrush = null;
			}
			if( _button6FillBrushHovered != null ) {
				_button6FillBrushHovered.Dispose();
				_button6FillBrushHovered = null;
			}
			if( _button5BorderPen != null ) {
				_button5BorderPen.Dispose();
				_button5BorderPen = null;
			}
			if( _button6FillBrush != null ) {
				_button6FillBrush.Dispose();
				_button6FillBrush = null;
			}
			if( _button6FillBrushHovered != null ) {
				_button6FillBrushHovered.Dispose();
				_button6FillBrushHovered = null;
			}
			if( _button6BorderPen != null ) {
				_button6BorderPen.Dispose();
				_button6BorderPen = null;
			}
			if( _button7FillBrush != null ) {
				_button7FillBrush.Dispose();
				_button7FillBrush = null;
			}
			if( _button7FillBrushHovered != null ) {
				_button7FillBrushHovered.Dispose();
				_button7FillBrushHovered = null;
			}
			if( _button7BorderPen != null ) {
				_button7BorderPen.Dispose();
				_button7BorderPen = null;
			}
			if( _button8FillBrush != null ) {
				_button8FillBrush.Dispose();
				_button8FillBrush = null;
			}
			if( _button8FillBrushHovered != null ) {
				_button8FillBrushHovered.Dispose();
				_button8FillBrushHovered = null;
			}
			if( _button8BorderPen != null ) {
				_button8BorderPen.Dispose();
				_button8BorderPen = null;
			}
			if( _button9FillBrush != null ) {
				_button9FillBrush.Dispose();
				_button9FillBrush = null;
			}
			if( _button9FillBrushHovered != null ) {
				_button9FillBrushHovered.Dispose();
				_button9FillBrushHovered = null;
			}
			if( _button9BorderPen != null ) {
				_button9BorderPen.Dispose();
				_button9BorderPen = null;
			}
		}

		#endregion

		#region -_ Private Methods _-

		private SolidBrush GetButtonFillBrush( int number , AgendaSelectorScheme scheme ) {
			SolidBrush brushToReturn = null;
			switch( number ) {
				case 1: {
						brushToReturn = GetButton1FillBrush( scheme );
						break;
					}
				case 2: {
						brushToReturn = GetButton2FillBrush( scheme );
						break;
					}
				case 3: {
						brushToReturn = GetButton3FillBrush( scheme );
						break;
					}
				case 4: {
						brushToReturn = GetButton4FillBrush( scheme );
						break;
					}
				case 5: {
						brushToReturn = GetButton5FillBrush( scheme );
						break;
					}
				case 6: {
						brushToReturn = GetButton6FillBrush( scheme );
						break;
					}
				case 7: {
						brushToReturn = GetButton7FillBrush( scheme );
						break;
					}
				case 8: {
						brushToReturn = GetButton8FillBrush( scheme );
						break;
					}
				case 9: {
						brushToReturn = GetButton9FillBrush( scheme );
						break;
					}
			}
			return brushToReturn;
		}

		private SolidBrush GetButtonFillBrushHovered( int number , AgendaSelectorScheme scheme ) {
			SolidBrush brushToReturn = null;
			switch( number ) {
				case 1: {
						brushToReturn = GetButton1FillBrushHovered( scheme );
						break;
					}
				case 2: {
						brushToReturn = GetButton2FillBrushHovered( scheme );
						break;
					}
				case 3: {
						brushToReturn = GetButton3FillBrushHovered( scheme );
						break;
					}
				case 4: {
						brushToReturn = GetButton4FillBrushHovered( scheme );
						break;
					}
				case 5: {
						brushToReturn = GetButton5FillBrushHovered( scheme );
						break;
					}
				case 6: {
						brushToReturn = GetButton6FillBrushHovered( scheme );
						break;
					}
				case 7: {
						brushToReturn = GetButton7FillBrushHovered( scheme );
						break;
					}
				case 8: {
						brushToReturn = GetButton8FillBrushHovered( scheme );
						break;
					}
				case 9: {
						brushToReturn = GetButton9FillBrushHovered( scheme );
						break;
					}
			}
			return brushToReturn;
		}

		private Pen GetButtonBorderPen( int number , AgendaSelectorScheme scheme ) {
			Pen penToReturn = null;
			switch( number ) {
				case 1: {
						penToReturn = GetButton1BorderPen( scheme );
						break;
					}
				case 2: {
						penToReturn = GetButton2BorderPen( scheme );
						break;
					}
				case 3: {
						penToReturn = GetButton3BorderPen( scheme );
						break;
					}
				case 4: {
						penToReturn = GetButton4BorderPen( scheme );
						break;
					}
				case 5: {
						penToReturn = GetButton5BorderPen( scheme );
						break;
					}
				case 6: {
						penToReturn = GetButton6BorderPen( scheme );
						break;
					}
				case 7: {
						penToReturn = GetButton7BorderPen( scheme );
						break;
					}
				case 8: {
						penToReturn = GetButton8BorderPen( scheme );
						break;
					}
				case 9: {
						penToReturn = GetButton9BorderPen( scheme );
						break;
					}
			}
			return penToReturn;
		}

		private SolidBrush GetBackgroundFillBrush( AgendaSelectorScheme scheme ) {
			if( _backgroundFillBrush == null ) {
				_backgroundFillBrush = new SolidBrush( scheme.BackgroundColor );
			}
			return _backgroundFillBrush;
		}

		private Pen GetBorderPen( AgendaSelectorScheme scheme ) {
			if( _borderPen == null ) {
				_borderPen = new Pen( scheme.BorderColor );
			}
			return _borderPen;
		}

		private SolidBrush GetButton1FillBrush( AgendaSelectorScheme scheme ) {
			if( _button1FillBrush == null ) {
				_button1FillBrush = new SolidBrush( scheme.ButtonFillColor1 );
			}
			return _button1FillBrush;
		}

		private SolidBrush GetButton1FillBrushHovered( AgendaSelectorScheme scheme ) {
			if( _button1FillBrushHovered == null ) {
				_button1FillBrushHovered = new SolidBrush( scheme.ButtonFillColorHovered1 );
			}
			return _button1FillBrushHovered;
		}

		private Pen GetButton1BorderPen( AgendaSelectorScheme scheme ) {
			if( _button1BorderPen == null ) {
				_button1BorderPen = new Pen( scheme.ButtonBorderColor1 );
			}
			return _button1BorderPen;
		}

		private SolidBrush GetButton2FillBrush( AgendaSelectorScheme scheme ) {
			if( _button2FillBrush == null ) {
				_button2FillBrush = new SolidBrush( scheme.ButtonFillColor2 );
			}
			return _button2FillBrush;
		}

		private SolidBrush GetButton2FillBrushHovered( AgendaSelectorScheme scheme ) {
			if( _button2FillBrushHovered == null ) {
				_button2FillBrushHovered = new SolidBrush( scheme.ButtonFillColorHovered2 );
			}
			return _button2FillBrushHovered;
		}

		private Pen GetButton2BorderPen( AgendaSelectorScheme scheme ) {
			if( _button2BorderPen == null ) {
				_button2BorderPen = new Pen( scheme.ButtonBorderColor2 );
			}
			return _button2BorderPen;
		}

		private SolidBrush GetButton3FillBrush( AgendaSelectorScheme scheme ) {
			if( _button3FillBrush == null ) {
				_button3FillBrush = new SolidBrush( scheme.ButtonFillColor3 );
			}
			return _button3FillBrush;
		}

		private SolidBrush GetButton3FillBrushHovered( AgendaSelectorScheme scheme ) {
			if( _button3FillBrushHovered == null ) {
				_button3FillBrushHovered = new SolidBrush( scheme.ButtonFillColorHovered3 );
			}
			return _button3FillBrushHovered;
		}

		private Pen GetButton3BorderPen( AgendaSelectorScheme scheme ) {
			if( _button3BorderPen == null ) {
				_button3BorderPen = new Pen( scheme.ButtonBorderColor3 );
			}
			return _button3BorderPen;
		}

		private SolidBrush GetButton4FillBrush( AgendaSelectorScheme scheme ) {
			if( _button4FillBrush == null ) {
				_button4FillBrush = new SolidBrush( scheme.ButtonFillColor4 );
			}
			return _button4FillBrush;
		}

		private SolidBrush GetButton4FillBrushHovered( AgendaSelectorScheme scheme ) {
			if( _button4FillBrushHovered == null ) {
				_button4FillBrushHovered = new SolidBrush( scheme.ButtonFillColorHovered4 );
			}
			return _button4FillBrushHovered;
		}

		private Pen GetButton4BorderPen( AgendaSelectorScheme scheme ) {
			if( _button4BorderPen == null ) {
				_button4BorderPen = new Pen( scheme.ButtonBorderColor4 );
			}
			return _button4BorderPen;
		}

		private SolidBrush GetButton5FillBrush( AgendaSelectorScheme scheme ) {
			if( _button5FillBrush == null ) {
				_button5FillBrush = new SolidBrush( scheme.ButtonFillColor5 );
			}
			return _button5FillBrush;
		}

		private SolidBrush GetButton5FillBrushHovered( AgendaSelectorScheme scheme ) {
			if( _button5FillBrushHovered == null ) {
				_button5FillBrushHovered = new SolidBrush( scheme.ButtonFillColorHovered5 );
			}
			return _button5FillBrushHovered;
		}

		private Pen GetButton5BorderPen( AgendaSelectorScheme scheme ) {
			if( _button5BorderPen == null ) {
				_button5BorderPen = new Pen( scheme.ButtonBorderColor5 );
			}
			return _button5BorderPen;
		}

		private SolidBrush GetButton6FillBrush( AgendaSelectorScheme scheme ) {
			if( _button6FillBrush == null ) {
				_button6FillBrush = new SolidBrush( scheme.ButtonFillColor6 );
			}
			return _button6FillBrush;
		}

		private SolidBrush GetButton6FillBrushHovered( AgendaSelectorScheme scheme ) {
			if( _button6FillBrushHovered == null ) {
				_button6FillBrushHovered = new SolidBrush( scheme.ButtonFillColorHovered6 );
			}
			return _button6FillBrushHovered;
		}

		private Pen GetButton6BorderPen( AgendaSelectorScheme scheme ) {
			if( _button6BorderPen == null ) {
				_button6BorderPen = new Pen( scheme.ButtonBorderColor6 );
			}
			return _button6BorderPen;
		}

		private SolidBrush GetButton7FillBrush( AgendaSelectorScheme scheme ) {
			if( _button7FillBrush == null ) {
				_button7FillBrush = new SolidBrush( scheme.ButtonFillColor7 );
			}
			return _button7FillBrush;
		}

		private SolidBrush GetButton7FillBrushHovered( AgendaSelectorScheme scheme ) {
			if( _button7FillBrushHovered == null ) {
				_button7FillBrushHovered = new SolidBrush( scheme.ButtonFillColorHovered7 );
			}
			return _button7FillBrushHovered;
		}

		private Pen GetButton7BorderPen( AgendaSelectorScheme scheme ) {
			if( _button7BorderPen == null ) {
				_button7BorderPen = new Pen( scheme.ButtonBorderColor7 );
			}
			return _button7BorderPen;
		}

		private SolidBrush GetButton8FillBrush( AgendaSelectorScheme scheme ) {
			if( _button8FillBrush == null ) {
				_button8FillBrush = new SolidBrush( scheme.ButtonFillColor8 );
			}
			return _button8FillBrush;
		}

		private SolidBrush GetButton8FillBrushHovered( AgendaSelectorScheme scheme ) {
			if( _button8FillBrushHovered == null ) {
				_button8FillBrushHovered = new SolidBrush( scheme.ButtonFillColorHovered8 );
			}
			return _button8FillBrushHovered;
		}

		private Pen GetButton8BorderPen( AgendaSelectorScheme scheme ) {
			if( _button8BorderPen == null ) {
				_button8BorderPen = new Pen( scheme.ButtonBorderColor8 );
			}
			return _button8BorderPen;
		}

		private SolidBrush GetButton9FillBrush( AgendaSelectorScheme scheme ) {
			if( _button9FillBrush == null ) {
				_button9FillBrush = new SolidBrush( scheme.ButtonFillColor9 );
			}
			return _button9FillBrush;
		}

		private SolidBrush GetButton9FillBrushHovered( AgendaSelectorScheme scheme ) {
			if( _button9FillBrushHovered == null ) {
				_button9FillBrushHovered = new SolidBrush( scheme.ButtonFillColorHovered9 );
			}
			return _button9FillBrushHovered;
		}

		private Pen GetButton9BorderPen( AgendaSelectorScheme scheme ) {
			if( _button9BorderPen == null ) {
				_button9BorderPen = new Pen( scheme.ButtonBorderColor9 );
			}
			return _button9BorderPen;
		}

		#endregion

		#region -_ IDisposable Members _-

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
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
