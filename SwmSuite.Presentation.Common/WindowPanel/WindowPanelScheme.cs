using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;

namespace SwmSuite.Presentation.Common.WindowPanel {
	
	public class WindowPanelScheme {

		#region -_ Private Members _-

		private Color _backgroundColor1;
		private Color _backgroundColor2;
		private Color _borderColor;

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

		public Color BorderColor {
			get {
				return _borderColor;
			}
			set {
				_borderColor = value;
				RaiseNeedsRedraw();
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public WindowPanelScheme() {
			this.BackgroundColor1 = Color.FromArgb( 10 , 75 , 115 );
			this.BackgroundColor2 = Color.FromArgb( 50 , 175 , 175 );
			this.BorderColor = Color.FromArgb( 0 , 0 , 255 );
		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="backgroundColor1"></param>
		/// <param name="backgroundColor2"></param>
		/// <param name="borderColor"></param>
		public WindowPanelScheme( Color backgroundColor1 , Color backgroundColor2 , Color borderColor) {
			this.BackgroundColor1 = backgroundColor1;
			this.BackgroundColor2 = backgroundColor2;
			this.BorderColor = borderColor;
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
