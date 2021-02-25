using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SwmSuite.Presentation.Common.SelectorControl {
	
	public class SelectorScheme {

		#region -_ Public Properties _-

		public Color BackgroundColor1 { get; set; }
		public Color BackgroundColor2 { get; set; }
		public Color BorderColor { get; set; }
		public int RoundedCornerRadius { get; set; }

		public Color ButtonBorderColor { get; set; }
		public Color ButtonBackgroundColor1 { get; set; }
		public Color ButtonBackgroundColor2 { get; set; }
		public Color ButtonBackgroundColor1Hovered { get; set; }
		public Color ButtonBackgroundColor2Hovered { get; set; }
		public int ButtonRoundedCornerRadius { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="SelectorScheme"/> class.
		/// </summary>
		public SelectorScheme() {
			this.BackgroundColor1 = Color.FromArgb( 241 , 246 , 251 );
			this.BackgroundColor2 = Color.FromArgb( 255 , 255 , 255 );
			this.BorderColor = Color.FromArgb( 165 , 185 , 221 );
			this.RoundedCornerRadius = 10;

			this.ButtonBorderColor = Color.FromArgb( 125 , 162 , 206 );
			this.ButtonBackgroundColor1 = Color.FromArgb( 238 , 245 , 254 );
			this.ButtonBackgroundColor2 = Color.FromArgb( 225 , 238 , 254 );
			this.ButtonBackgroundColor1Hovered = Color.FromArgb( 220 , 235 , 253 );
			this.ButtonBackgroundColor2Hovered = Color.FromArgb( 194 , 220 , 253 );
			this.ButtonRoundedCornerRadius = 5;
		}

		#endregion

	}

}
