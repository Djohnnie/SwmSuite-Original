using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;

namespace SwmSuite.Presentation.Common.Marquee {
	
	public class MarqueeScheme {

		#region -_ Private Members _-

		private Color _textColor;
		private Font _textFont;

		private Color _backgroundColor1;
		private Color _backgroundColor2;
		private Color _backgroundColor3;
		private Color _backgroundColor4;

		#endregion

		#region -_ Public Properties _-

		public event EventHandler<EventArgs> NeedsRedraw;

		public Color TextColor {
			get {
				return _textColor;
			}
			set {
				_textColor = value;
				RaiseNeedsRedraw();
			}
		}

		public Font TextFont {
			get {
				return _textFont;
			}
			set {
				_textFont = value;
				RaiseNeedsRedraw();
			}
		}

		public Color BackgroundColor1 {
			get {
				return _backgroundColor1;
			}
			set {
				_backgroundColor1 = value;
				RaiseNeedsRedraw();
			}
		}

		public Color BackgroundColor2 {
			get {
				return _backgroundColor2;
			}
			set {
				_backgroundColor2 = value;
				RaiseNeedsRedraw();
			}
		}

		public Color BackgroundColor3 {
			get {
				return _backgroundColor3;
			}
			set {
				_backgroundColor3 = value;
				RaiseNeedsRedraw();
			}
		}

		public Color BackgroundColor4 {
			get {
				return _backgroundColor4;
			}
			set {
				_backgroundColor4 = value;
				RaiseNeedsRedraw();
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public MarqueeScheme() {
			this.TextColor = Color.FromArgb( 0 , 0 , 0 );
			this.TextFont = new Font( "Copperplate Gothic Light" , 10.0f , FontStyle.Regular );

			this.BackgroundColor1 = Color.FromArgb( 136 , 180 , 192 );
			this.BackgroundColor2 = Color.FromArgb( 71 , 139 , 158 );
			this.BackgroundColor3 = Color.FromArgb( 19 , 97 , 119 );
			this.BackgroundColor4 = Color.FromArgb( 83 , 159 , 171 );
		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="textColor"></param>
		/// <param name="textFont"></param>
		/// <param name="backgroundColor"></param>
		public MarqueeScheme( Color textColor , Font textFont , Color backgroundColor ) {
			this.TextColor = textColor;
			this.TextFont = textFont;
		}

		#endregion

		#region -_ Private Methods _-

		/// <summary>
		/// Raise the 'NeedsRedraw' event.
		/// </summary>
		private void RaiseNeedsRedraw() {
			if( this.NeedsRedraw != null ) {
				this.NeedsRedraw( this , EventArgs.Empty );
			}
		}

		#endregion

	}

}
