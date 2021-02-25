using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SwmSuite.Presentation.Common.TimeTable {
	
	public class OccupationScheme {

		#region -_ Public Properties _-

		public int BarHeight { get; set; }

		public int BarGap { get; set; }

		public int DescriptionColumnWidth { get; set; }

		public Color DescriptionCaptionColor { get; set; }

		public Font DescriptionCaptionFont { get; set; }


		public int HeaderHeight { get; set; }

		public Color SeperatorColor { get; set; }

		public Color LargeRulerColor { get; set; }

		public Color SmallRulerColor { get; set; }


		public Color TimeCaptionColor { get; set; }

		public Font TimeCaptionFont { get; set; }

		public int SummaryColumnWidth { get; set; }

		public Color SummaryCaptionColor { get; set; }

		public Font SummaryCaptionFont { get; set; }


		public Color ColumnHeaderBackgroundColor1 { get; set; }

		public Color ColumnHeaderBackgroundColor2 { get; set; }

		public Color ColumnHeaderBackgroundColor3 { get; set; }

		public Color ColumnHeaderBackgroundColor4 { get; set; }

		public Color SummaryRowBackgroundColor1 { get; set; }

		public Color SummaryRowBackgroundColor2 { get; set; }

		public Color SummaryRowBackgroundColor3 { get; set; }

		public Color SummaryRowBackgroundColor4 { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="OccupationScheme"/> class.
		/// </summary>
		public OccupationScheme() {
			this.BarHeight = 40;
			this.BarGap = 5;

			this.DescriptionColumnWidth = 100;
			this.DescriptionCaptionColor = Color.FromArgb( 0 , 0 , 0 );
			this.DescriptionCaptionFont = new Font( "Verdana" , 8.0f , FontStyle.Regular );

			this.HeaderHeight = 30;
			this.SeperatorColor = Color.FromArgb( 0 , 0 , 0 );
			this.LargeRulerColor = Color.FromArgb( 170 , 170 , 170 );
			this.SmallRulerColor = Color.FromArgb( 220 , 220 , 220 );

			this.TimeCaptionColor = Color.FromArgb( 0 , 0 , 0 );
			this.TimeCaptionFont = new Font( "Verdana" , 8.0f , FontStyle.Regular );

			this.SummaryColumnWidth = 50;
			this.SummaryCaptionColor = Color.FromArgb( 0 , 0 , 0 );
			this.SummaryCaptionFont = new Font( "Verdana" , 8.0f , FontStyle.Regular );

			this.ColumnHeaderBackgroundColor1 = Color.FromArgb( 136 , 180 , 192 );
			this.ColumnHeaderBackgroundColor2 = Color.FromArgb( 71 , 139 , 158 );
			this.ColumnHeaderBackgroundColor3 = Color.FromArgb( 19 , 97 , 119 );
			this.ColumnHeaderBackgroundColor4 = Color.FromArgb( 83 , 159 , 171 );
			this.SummaryRowBackgroundColor1 = Color.FromArgb( 255 , 255 , 255 );
			this.SummaryRowBackgroundColor2 = Color.FromArgb( 215 , 215 , 215 );
			this.SummaryRowBackgroundColor3 = Color.FromArgb( 171 , 171 , 171 );
			this.SummaryRowBackgroundColor4 = Color.FromArgb( 222 , 222 , 222 );
		}

		#endregion

	}

}
