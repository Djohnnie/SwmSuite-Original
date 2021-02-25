using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Drawing.Text;

namespace SwmSuite.Presentation.Common.AgendaControl {

	public class AgendaScheme {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		public int HeaderHeight { get; set; }

		public Color HeaderBackColor1 { get; set; }
		public Color HeaderBackColor2 { get; set; }
		public Color HeaderBackColor3 { get; set; }
		public Color HeaderBackColor4 { get; set; }
		public Color HeaderCaptionColor { get; set; }
		public Font HeaderCaptionFont { get; set; }
		public TextRenderingHint HeaderCaptionRendering { get; set; }

		public int TimeRulerWidth { get; set; }
		public Color TimeRulerBackgroundColor1 { get; set; }
		public Color TimeRulerBackgroundColor2 { get; set; }
		public Color TimeRulerCaptionColor { get; set; }
		public Font TimeRulerCaptionFont { get; set; }

		public Color BorderColor { get; set; }

		public Color BackgroundColor { get; set; }
		public Color GridColor { get; set; }

		public Color SelectionColor { get; set; }

		public Color AppointmentTitleColor { get; set; }
		public Font AppointmentTitleFont { get; set; }
		public Color AppointmentPlaceColor { get; set; }
		public Font AppointmentPlaceFont { get; set; }
		public Color AppointmentContentsColor { get; set; }
		public Font AppointmentContentsFont { get; set; }
		public Color AppointmentTimeColor { get; set; }
		public Font AppointmentTimeFont { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public AgendaScheme() {
			this.HeaderHeight = 30;

			this.HeaderBackColor1 = Color.FromArgb( 136 , 180 , 192 );
			this.HeaderBackColor2 = Color.FromArgb( 71 , 139 , 158 );
			this.HeaderBackColor3 = Color.FromArgb( 19 , 97 , 119 );
			this.HeaderBackColor4 = Color.FromArgb( 83 , 159 , 171 );
			this.HeaderCaptionColor = Color.FromArgb( 255 , 255 , 255 );
			this.HeaderCaptionFont = new Font( "Verdana" , 10.0f , FontStyle.Bold );
			this.HeaderCaptionRendering = TextRenderingHint.ClearTypeGridFit;

			this.TimeRulerWidth = 50;
			this.TimeRulerBackgroundColor1 = Color.FromArgb( 49 , 92 , 137 );
			this.TimeRulerBackgroundColor2 = Color.FromArgb( 121 , 194 , 211 );
			this.TimeRulerCaptionColor = Color.FromArgb( 255 , 255 , 255 );
			this.TimeRulerCaptionFont = new Font( "Verdana" , 8.0f , FontStyle.Regular );

			this.BorderColor = Color.FromArgb( 0 , 0 , 0 );

			this.BackgroundColor = Color.FromArgb( 255 , 255 , 255 );
			this.GridColor = Color.FromArgb( 200 , 200 , 200 );

			this.SelectionColor = Color.FromArgb( 172 , 0 , 0 , 255 );

			this.AppointmentTitleColor = Color.FromArgb( 0 , 0 , 0 );
			this.AppointmentTitleFont = new Font( "Verdana" , 8.0f , FontStyle.Bold );
			this.AppointmentPlaceColor = Color.FromArgb( 0 , 0 , 0 );
			this.AppointmentPlaceFont = new Font( "Verdana" , 8.0f , FontStyle.Regular );
			this.AppointmentContentsColor = Color.FromArgb( 0 , 0 , 0 );
			this.AppointmentContentsFont = new Font( "Verdana" , 7.0f , FontStyle.Regular );
			this.AppointmentTimeColor = Color.FromArgb( 0 , 0 , 0 );
			this.AppointmentTimeFont = new Font( "Verdana" , 8.0f , FontStyle.Regular );
		}

		#endregion

	}

}
