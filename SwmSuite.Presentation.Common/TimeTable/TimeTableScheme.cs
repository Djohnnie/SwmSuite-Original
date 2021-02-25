using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Text;

namespace SwmSuite.Presentation.Common.TimeTable {

	public class TimeTableScheme {

		#region -_ Public Properties _-

		public Color BorderColor { get; set; }

		public int DayColumnWidth { get; set; }

		public Color DayColumnBackgroundColor1 { get; set; }

		public Color DayColumnBackgroundColor2 { get; set; }

		public Color DayColumnCaptionColor { get; set; }

		public Font DayColumnCaptionFont { get; set; }

		public TextRenderingHint DayColumnCaptionRendering { get; set; }

		public int ColumnHeaderHeight { get; set; }

		public Color ColumnHeaderBackgroundColor1 { get; set; }

		public Color ColumnHeaderBackgroundColor2 { get; set; }

		public Color ColumnHeaderBackgroundColor3 { get; set; }

		public Color ColumnHeaderBackgroundColor4 { get; set; }

		public Color ColumnHeaderCaptionColor { get; set; }

		public Font ColumnHeaderCaptionFont { get; set; }

		public TextRenderingHint ColumnHeaderCaptionRendering { get; set; }

		public int SummaryBoxWidth { get; set; }

		public int SummaryRowHeight { get; set; }

		public Color SummaryRowBackgroundColor1 { get; set; }

		public Color SummaryRowBackgroundColor2 { get; set; }

		public Color SummaryRowBackgroundColor3 { get; set; }

		public Color SummaryRowBackgroundColor4 { get; set; }

		public Color SummaryRowCaptionColor { get; set; }

		public Font SummaryRowCaptionFont { get; set; }

		public Color CaptionColor { get; set; }

		public Font CaptionFont { get; set; }

		public Font CaptionBoldFont { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTableScheme"/> class.
		/// </summary>
		public TimeTableScheme() {
			this.BorderColor = Color.FromArgb( 0 , 0 , 0 );

			this.DayColumnWidth = 50;
			this.DayColumnBackgroundColor1 = Color.FromArgb( 200 , 200 , 200 );
			this.DayColumnBackgroundColor2 = Color.FromArgb( 240 , 240 , 240 );
			this.DayColumnCaptionColor = Color.FromArgb( 0 , 0 , 0 );
			this.DayColumnCaptionFont = new Font( "Verdana" , 8.0f , FontStyle.Regular );
			this.DayColumnCaptionRendering = TextRenderingHint.ClearTypeGridFit;

			this.ColumnHeaderHeight = 30;
			this.ColumnHeaderBackgroundColor1 = Color.FromArgb( 136 , 180 , 192 );
			this.ColumnHeaderBackgroundColor2 = Color.FromArgb( 71 , 139 , 158 );
			this.ColumnHeaderBackgroundColor3 = Color.FromArgb( 19 , 97 , 119 );
			this.ColumnHeaderBackgroundColor4 = Color.FromArgb( 83 , 159 , 171 );
			this.ColumnHeaderCaptionColor = Color.FromArgb( 255 , 255 , 255 );
			this.ColumnHeaderCaptionFont = new Font( "Verdana" , 10.0f , FontStyle.Bold );
			this.ColumnHeaderCaptionRendering = TextRenderingHint.ClearTypeGridFit;

			this.SummaryBoxWidth = 50;
			this.SummaryRowHeight = 30;
			this.SummaryRowBackgroundColor1 = Color.FromArgb( 255 , 255 , 255 );
			this.SummaryRowBackgroundColor2 = Color.FromArgb( 215 , 215 , 215 );
			this.SummaryRowBackgroundColor3 = Color.FromArgb( 171 , 171 , 171 );
			this.SummaryRowBackgroundColor4 = Color.FromArgb( 222 , 222 , 222 );
			this.SummaryRowCaptionColor = Color.FromArgb( 0 , 0 , 0 );
			this.SummaryRowCaptionFont = new Font( "Verdana" , 8.0f , FontStyle.Bold );

			this.CaptionColor = Color.FromArgb( 0 , 0 , 0 );
			this.CaptionFont = new Font( "Verdana" , 8.0f , FontStyle.Regular );
			this.CaptionBoldFont = new Font( "Verdana" , 8.0f , FontStyle.Bold );
		}

		#endregion

	}

}
