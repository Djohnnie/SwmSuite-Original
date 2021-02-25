using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Drawing.Text;

namespace SwmSuite.Presentation.Common.Clock {
	
	public class ClockScheme {

		#region -_ Private Members _-

		private Color _timeColor;
		private Font _timeFont;
		private TextRenderingHint _timeRendering;
		private Color _dateColor;
		private Font _dateFont;
		private TextRenderingHint _dateRendering;

		#endregion

		#region -_ Public Properties _-

		public Color TimeColor {
			get {
				return _timeColor;
			}
			set {
				_timeColor = value;
			}
		}

		public Font TimeFont {
			get {
				return _timeFont;
			}
			set {
				_timeFont = value;
			}
		}

		public TextRenderingHint TimeRendering {
			get {
				return _timeRendering;
			}
			set {
				_timeRendering = value;
			}
		}

		public Color DateColor {
			get {
				return _dateColor;
			}
			set {
				_dateColor = value;
			}
		}

		public Font DateFont {
			get {
				return _dateFont;
			}
			set {
				_dateFont = value;
			}
		}

		public TextRenderingHint DateRendering {
			get {
				return _dateRendering;
			}
			set {
				_dateRendering = value;
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ClockScheme() {
			this.TimeColor = Color.White;
			this.TimeFont = new Font( "Arial" , 30.0f , FontStyle.Bold );
			this.TimeRendering = TextRenderingHint.ClearTypeGridFit;
			this.DateColor = Color.White;
			this.DateFont = new Font( "Arial" , 15.0f , FontStyle.Regular );
			this.DateRendering = TextRenderingHint.ClearTypeGridFit;
		}

		#endregion

	}

}
