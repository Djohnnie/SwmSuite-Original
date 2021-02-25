using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;

namespace SwmSuite.Presentation.Common.MirrorText {
	
	public class MirrorTextScheme {

		#region -_ Private Members _-

		private Color _textColor;
		private Font _textFont;
		private int _correction;

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

		public int Correction {
			get {
				return _correction;
			}
			set {
				_correction = value;
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public MirrorTextScheme() {
			this.TextColor = Color.FromArgb( 255 , 255 , 255 );
			this.TextFont = new Font( "Copperplate Gothic Light" , 14.0f , FontStyle.Regular );
			this.Correction = 5;
		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="textColor"></param>
		/// <param name="textFont"></param>
		/// <param name="correction"></param>
		public MirrorTextScheme( Color textColor , Font textFont , int correction ) {
			this.TextColor = textColor;
			this.TextFont = textFont;
			this.Correction = correction;
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
