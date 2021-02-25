using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;

namespace SwmSuite.Presentation.Common.Status {
	
	public class StatusScheme {

		#region -_ Private Members _-

		private Color _backgroundColor1;
		private Color _backgroundColor2;
		private Color _captionColor;
		private Font _captionFont;

		#endregion

		#region -_ Public Properties _-

		public event EventHandler<EventArgs> NeedsRedraw;

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
		public StatusScheme() {
			this.BackgroundColor1 = Color.FromArgb( 67 , 71 , 82 );
			this.BackgroundColor2 = Color.FromArgb( 48 , 48 , 48 );
			this.CaptionColor = Color.FromArgb( 255 , 255 , 255 );
			this.CaptionFont = new Font( "Copperplate Gothic Light" , 10.0f , FontStyle.Regular );
		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		public StatusScheme( Color backgroundColor1 , Color backgroundColor2 , Color captionColor , Font captionFont ) {
			this.BackgroundColor1 = backgroundColor1;
			this.BackgroundColor2 = backgroundColor2;
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
