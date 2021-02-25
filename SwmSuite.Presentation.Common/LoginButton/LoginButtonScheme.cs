using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;

namespace SwmSuite.Presentation.Common.LoginButton {
	
	public class LoginButtonScheme {

		#region -_ Private Members _-

		private Color _outerBorderColor;
		private Color _borderColor;
		private Color _innerBorderColor;

		private Color _backgroundColor1;
		private Color _backgroundColor2;
		private Color _backgroundColor3;
		private Color _backgroundColor4;

		private Color _backgroundGlowColor;

		private Color _avatarBackgroundColor1;
		private Color _avatarBackgroundColor2;
		private Color _avatarBackgroundColor3;
		private Color _avatarBackgroundColor4;
		private int _avatarAreaWidth;

		private Color _captionColor;
		private Font _captionFont;

		#endregion

		#region -_ Public Properties _-

		public event EventHandler<EventArgs> NeedsRedraw;

		public Color OuterBorderColor {
			get {
				return _outerBorderColor;
			}
			set {
				_outerBorderColor = value;
				RaiseNeedsRedraw();
			}
		}

		public Color BorderColor {
			get {
				return _borderColor;
			}
			set {
				_borderColor = value;
				RaiseNeedsRedraw();
			}
		}

		public Color InnerBorderColor {
			get {
				return _innerBorderColor;
			}
			set {
				_innerBorderColor = value;
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

		public Color BackgroundGlowColor {
			get {
				return _backgroundGlowColor;
			}
			set {
				_backgroundGlowColor = value;
				RaiseNeedsRedraw();
			}
		}

		public Color AvatarBackgroundColor1 {
			get {
				return _avatarBackgroundColor1;
			}
			set {
				_avatarBackgroundColor1 = value;
				RaiseNeedsRedraw();
			}
		}

		public Color AvatarBackgroundColor2 {
			get {
				return _avatarBackgroundColor2;
			}
			set {
				_avatarBackgroundColor2 = value;
				RaiseNeedsRedraw();
			}
		}

		public Color AvatarBackgroundColor3 {
			get {
				return _avatarBackgroundColor3;
			}
			set {
				_avatarBackgroundColor3 = value;
				RaiseNeedsRedraw();
			}
		}

		public Color AvatarBackgroundColor4 {
			get {
				return _avatarBackgroundColor4;
			}
			set {
				_avatarBackgroundColor4 = value;
				RaiseNeedsRedraw();
			}
		}

		public int AvatarAreaWidth {
			get {
				return _avatarAreaWidth;
			}
			set {
				_avatarAreaWidth = value;
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
		public LoginButtonScheme() {
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
