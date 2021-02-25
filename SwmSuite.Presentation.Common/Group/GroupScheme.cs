using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;

namespace SwmSuite.Presentation.Common.Group {

	public class GroupScheme {

		#region -_ Private Members _-

		private Color _borderColor;
		private int _borderWidth;
		private Color _captionColor;
		private Font _captionFont;

		#endregion

		#region -_ Public Properties _-

		public event EventHandler<EventArgs> NeedsRedraw;

		public Color BorderColor {
			get {
				return _borderColor;
			}
			set {
				_borderColor = value;
				RaiseNeedsRedraw();
			}
		}

		public int BorderWidth {
			get {
				return _borderWidth;
			}
			set {
				_borderWidth = value;
				RaiseNeedsRedraw();
			}
		}

		public Color CaptionColor {
			get {
				return _captionColor;
			}
			set {
				_captionColor = value;
				RaiseNeedsRedraw();
			}
		}

		public Font CaptionFont {
			get {
				return _captionFont;
			}
			set {
				_captionFont = value;
				RaiseNeedsRedraw();
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public GroupScheme() {
			this.BorderColor = Color.FromArgb( 200 , 200 , 200 );
			this.BorderWidth = 1;
			this.CaptionColor = Color.FromArgb( 0 , 0 , 0 );
			this.CaptionFont = new Font( "Copperplate Gothic Light" , 10.0f , FontStyle.Regular );
		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="borderColor"></param>
		/// <param name="borderWidth"></param>
		/// <param name="captionColor"></param>
		/// <param name="captionFont"></param>
		public GroupScheme( Color borderColor , int borderWidth , Color captionColor , Font captionFont ) {
			this.BorderColor = borderColor;
			this.BorderWidth = borderWidth;
			this.CaptionColor = captionColor;
			this.CaptionFont = captionFont;
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