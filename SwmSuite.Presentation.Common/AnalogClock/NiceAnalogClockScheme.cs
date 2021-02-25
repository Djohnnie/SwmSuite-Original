using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SwmSuite.Presentation.Common.AnalogClock {

	/// <summary>
	/// Class representing a scheme for the analog clock control renderer.
	/// </summary>
	public class NiceAnalogClockScheme {

		#region _ Public Properties _-

		/// <summary>
		/// Gets or sets the first face color.
		/// </summary>
		/// <value>The first face color.</value>
		public Color FaceColor1 { get; set; }

		/// <summary>
		/// Gets or sets the second face color.
		/// </summary>
		/// <value>The second face color.</value>
		public Color FaceColor2 { get; set; }

		/// <summary>
		/// Gets or sets the color of the text.
		/// </summary>
		/// <value>The color of the text.</value>
		public Color TextColor { get; set; }

		/// <summary>
		/// Gets or sets the color of the second hand.
		/// </summary>
		/// <value>The color of the second hand.</value>
		public Color SecondHandColor { get; set; }

		/// <summary>
		/// Gets or sets the color of the minute hand.
		/// </summary>
		/// <value>The color of the minute hand.</value>
		public Color MinuteHandColor { get; set; }

		/// <summary>
		/// Gets or sets the color of the hour hand.
		/// </summary>
		/// <value>The color of the hour hand.</value>
		public Color HourHandColor { get; set; }

		/// <summary>
		/// Gets or sets the width of the outer ring.
		/// </summary>
		/// <value>The width of the outer ring.</value>
		public float OuterRingWidth { get; set; }

		/// <summary>
		/// Gets or sets the width of the inner ring.
		/// </summary>
		/// <value>The width of the inner ring.</value>
		public float InnerRingWidth { get; set; }

		/// <summary>
		/// Gets or sets the width of the hour indicator.
		/// </summary>
		/// <value>The width of the hour indicator.</value>
		public float HourIndicatorWidth { get; set; }

		/// <summary>
		/// Gets or sets the width of the minute indicator.
		/// </summary>
		/// <value>The width of the minute indicator.</value>
		public float MinuteIndicatorWidth { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="NiceAnalogClockScheme"/> class.
		/// </summary>
		public NiceAnalogClockScheme() {
			this.FaceColor1 = Color.FromArgb( 189 , 173 , 231 );
			this.FaceColor2 = Color.FromArgb( 57 , 49 , 74 );
			this.TextColor = Color.FromArgb( 0 , 0 , 0 );
			this.SecondHandColor = Color.FromArgb( 255 , 0 , 0 );
			this.MinuteHandColor = Color.FromArgb( 0 , 0 , 0 );
			this.HourHandColor = Color.FromArgb( 0 , 0 , 0 );
			this.OuterRingWidth = 10.0f;
			this.InnerRingWidth = 2.0f;
			this.HourIndicatorWidth = 0.50f;
			this.MinuteIndicatorWidth = 0.10f;
		}

		#endregion

	}

}
