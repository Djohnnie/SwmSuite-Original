using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;

namespace SwmSuite.Presentation.Common.AnalogClock {

	public class AnalogClockScheme {

		#region -_ Private Members _-

		private Color _hourHandColor;
		private float _hourHandWidth;
		private Color _minuteHandColor;
		private float _minuteHandWidth;
		private Color _secondHandColor;
		private float _secondHandWidth;
		private Color _hourIndicatorColor;
		private float _hourIndicatorWidth;
		private Color _borderColor;
		private float _borderWidth;
		private Color _backgroundColor;
		private Color _timeColor;
		private Font _timeFont;
		private Color _countDownFillColor;

		#endregion

		#region -_ Public Properties _-

		public event EventHandler<EventArgs> NeedsRedraw;

		public Color HourHandColor {
			get {
				return _hourHandColor;
			}
			set {
				_hourHandColor = value;
				RaiseNeedsRedraw();
			}
		}

		public float HourHandWidth {
			get {
				return _hourHandWidth;
			}
			set {
				_hourHandWidth = value;
				RaiseNeedsRedraw();
			}
		}

		public Color MinuteHandColor {
			get {
				return _minuteHandColor;
			}
			set {
				_minuteHandColor = value;
				RaiseNeedsRedraw();
			}
		}

		public float MinuteHandWidth {
			get {
				return _minuteHandWidth;
			}
			set {
				_minuteHandWidth = value;
				RaiseNeedsRedraw();
			}
		}

		public Color SecondHandColor {
			get {
				return _secondHandColor;
			}
			set {
				_secondHandColor = value;
				RaiseNeedsRedraw();
			}
		}

		public float SecondHandWidth {
			get {
				return _secondHandWidth;
			}
			set {
				_secondHandWidth = value;
				RaiseNeedsRedraw();
			}
		}

		public Color HourIndicatorColor {
			get {
				return _hourIndicatorColor;
			}
			set {
				_hourIndicatorColor = value;
				RaiseNeedsRedraw();
			}
		}

		public float HourIndicatorWidth {
			get {
				return _hourIndicatorWidth;
			}
			set {
				_hourIndicatorWidth = value;
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

		public float BorderWidth {
			get {
				return _borderWidth;
			}
			set {
				_borderWidth = value;
				RaiseNeedsRedraw();
			}
		}

		public Color BackgroundColor {
			get {
				return _backgroundColor;
			}
			set {
				_backgroundColor = value;
				RaiseNeedsRedraw();
			}
		}

		public Color TimeColor {
			get {
				return _timeColor;
			}
			set {
				_timeColor = value;
				RaiseNeedsRedraw();
			}
		}

		public Font TimeFont {
			get {
				return _timeFont;
			}
			set {
				_timeFont = value;
				RaiseNeedsRedraw();
			}
		}

		public Color CountDownFillColor {
			get {
				return _countDownFillColor;
			}
			set {
				_countDownFillColor = value;
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public AnalogClockScheme() {
			this.HourHandColor = Color.White;
			this.HourHandWidth = 2.0f;
			this.MinuteHandColor = Color.White;
			this.MinuteHandWidth = 2.0f;
			this.SecondHandColor = Color.Red;
			this.SecondHandWidth = 1.0f;
			this.HourIndicatorColor = Color.White;
			this.HourIndicatorWidth = 2.0f;
			this.BorderColor = Color.White;
			this.BorderWidth = 2.0f;
			this.BackgroundColor = Color.Transparent;
			this.TimeColor = Color.White;
			this.TimeFont = new Font( "Verdana" , 10.0f , FontStyle.Regular );
			this.CountDownFillColor = Color.FromArgb( 128 , 255 , 100 , 100 );
		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="hourHandColor"></param>
		/// <param name="hourHandWidth"></param>
		/// <param name="minuteHandColor"></param>
		/// <param name="minuteHandWidth"></param>
		/// <param name="secondHandColor"></param>
		/// <param name="secondHandWidth"></param>
		/// <param name="hourIndicatorColor"></param>
		/// <param name="hourIndicatorWidth"></param>
		/// <param name="borderColor"></param>
		/// <param name="borderWidth"></param>
		/// <param name="backgroundColor"></param>
		/// <param name="timeColor"></param>
		/// <param name="timeFont"></param>
		public AnalogClockScheme( Color hourHandColor , float hourHandWidth , Color minuteHandColor , float minuteHandWidth , Color secondHandColor , float secondHandWidth , Color hourIndicatorColor , float hourIndicatorWidth , Color borderColor , float borderWidth , Color backgroundColor , Color timeColor , Font timeFont ) {
			this.HourHandColor = hourHandColor;
			this.HourHandWidth = hourHandWidth;
			this.MinuteHandColor = minuteHandColor;
			this.MinuteHandWidth = minuteHandWidth;
			this.SecondHandColor = secondHandColor;
			this.SecondHandWidth = secondHandWidth;
			this.HourIndicatorColor = hourIndicatorColor;
			this.HourIndicatorWidth = hourIndicatorWidth;
			this.BorderColor = borderColor;
			this.BorderWidth = borderWidth;
			this.BackgroundColor = backgroundColor;
			this.TimeColor = timeColor;
			this.TimeFont = timeFont;
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
