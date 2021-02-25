using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;

namespace SimpleWorkfloorManagementSuite.Controls {
	
	public class AgendaSelectorScheme {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		public int ButtonHeight { get; set; }
		public int BorderRoundedCornerRadius { get; set; }
		public int ButtonRoundedCornerRadius { get; set; }
		
		public Color BackgroundColor { get; set; }
		public Color BorderColor { get; set; }

		public Color ButtonFillColor1 { get; set; }
		public Color ButtonFillColorHovered1 { get; set; }
		public Color ButtonBorderColor1 { get; set; }

		public Color ButtonFillColor2 { get; set; }
		public Color ButtonFillColorHovered2 { get; set; }
		public Color ButtonBorderColor2 { get; set; }

		public Color ButtonFillColor3 { get; set; }
		public Color ButtonFillColorHovered3 { get; set; }
		public Color ButtonBorderColor3 { get; set; }

		public Color ButtonFillColor4 { get; set; }
		public Color ButtonFillColorHovered4 { get; set; }
		public Color ButtonBorderColor4 { get; set; }

		public Color ButtonFillColor5 { get; set; }
		public Color ButtonFillColorHovered5 { get; set; }
		public Color ButtonBorderColor5 { get; set; }

		public Color ButtonFillColor6 { get; set; }
		public Color ButtonFillColorHovered6 { get; set; }
		public Color ButtonBorderColor6 { get; set; }

		public Color ButtonFillColor7 { get; set; }
		public Color ButtonFillColorHovered7 { get; set; }
		public Color ButtonBorderColor7 { get; set; }

		public Color ButtonFillColor8 { get; set; }
		public Color ButtonFillColorHovered8 { get; set; }
		public Color ButtonBorderColor8 { get; set; }

		public Color ButtonFillColor9 { get; set; }
		public Color ButtonFillColorHovered9 { get; set; }
		public Color ButtonBorderColor9 { get; set; }

		#endregion

		#region -_ Construction _-

		public AgendaSelectorScheme() {
			this.ButtonHeight = 30;
			this.BorderRoundedCornerRadius = 10;
			this.ButtonRoundedCornerRadius = 5;

			this.BackgroundColor = Color.FromArgb( 231 , 240 , 249 );
			this.BorderColor = Color.FromArgb( 100 , 113 , 126 );

			this.ButtonFillColor1 = Color.FromArgb( 255 , 127 , 182 );
			this.ButtonFillColorHovered1 = Color.FromArgb( 255 , 127 , 182 );
			this.ButtonBorderColor1 = Color.FromArgb( 127 , 0 , 55 );

			this.ButtonFillColor2 = Color.FromArgb( 255 , 178 , 127 );
			this.ButtonFillColorHovered2 = Color.FromArgb( 255 , 178 , 127 );
			this.ButtonBorderColor2 = Color.FromArgb( 127 , 51 , 0 );

			this.ButtonFillColor3 = Color.FromArgb( 255 , 127 , 237 );
			this.ButtonFillColorHovered3 = Color.FromArgb( 255 , 127 , 237 );
			this.ButtonBorderColor3 = Color.FromArgb( 127 , 0 , 110 );

			this.ButtonFillColor4 = Color.FromArgb( 255 , 233 , 127 );
			this.ButtonFillColorHovered4 = Color.FromArgb( 255 , 233 , 127 );
			this.ButtonBorderColor4 = Color.FromArgb( 127 , 106 , 0 );

			this.ButtonFillColor5 = Color.FromArgb( 214 , 127 , 255 );
			this.ButtonFillColorHovered5 = Color.FromArgb( 214 , 127 , 255 );
			this.ButtonBorderColor5 = Color.FromArgb( 97 , 0 , 127 );

			this.ButtonFillColor6 = Color.FromArgb( 165 , 255 , 127 );
			this.ButtonFillColorHovered6 = Color.FromArgb( 165 , 255 , 127 );
			this.ButtonBorderColor6 = Color.FromArgb( 38 , 127 , 0 );

			this.ButtonFillColor7 = Color.FromArgb( 161 , 127 , 255 );
			this.ButtonFillColorHovered7 = Color.FromArgb( 161 , 127 , 255 );
			this.ButtonBorderColor7 = Color.FromArgb( 33 , 0 , 127 );

			this.ButtonFillColor8 = Color.FromArgb( 127 , 255 , 142 );
			this.ButtonFillColorHovered8 = Color.FromArgb( 127 , 255 , 142 );
			this.ButtonBorderColor8 = Color.FromArgb( 0 , 127 , 14 );

			this.ButtonFillColor9 = Color.FromArgb( 127 , 255 , 142 );
			this.ButtonFillColorHovered9 = Color.FromArgb( 127 , 255 , 142 );
			this.ButtonBorderColor9 = Color.FromArgb( 0 , 127 , 14 );
		}

		#endregion

	}

}
