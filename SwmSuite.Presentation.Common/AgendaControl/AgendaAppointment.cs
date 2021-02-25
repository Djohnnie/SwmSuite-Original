using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;

namespace SwmSuite.Presentation.Common.AgendaControl {

	/// <summary>
	/// Data container for an appointment in the agenda control.
	/// </summary>
	[Serializable]
	public class AgendaAppointment {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the first color.
		/// </summary>
		/// <value>The color.</value>
		public Color Color1 { get; set; }

		/// <summary>
		/// Gets or sets the second color.
		/// </summary>
		/// <value>The color.</value>
		public Color Color2 { get; set; }

		/// <summary>
		/// Gets or sets the third color.
		/// </summary>
		/// <value>The color.</value>
		public Color Color3 { get; set; }

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		public String Title { get; set; }

		/// <summary>
		/// Gets or sets the contents.
		/// </summary>
		/// <value>The contents.</value>
		public String Contents { get; set; }

		/// <summary>
		/// Gets or sets the place.
		/// </summary>
		/// <value>The place.</value>
		public String Place { get; set; }

		/// <summary>
		/// Gets or sets the begin date.
		/// </summary>
		/// <value>The begin.</value>
		public DateTime Begin { get; set; }

		/// <summary>
		/// Gets or sets the end date.
		/// </summary>
		/// <value>The end.</value>
		public DateTime End { get; set; }

		/// <summary>
		/// Gets or sets the tag.
		/// </summary>
		/// <value>The tag.</value>
		public Object Tag { get; set; }

		/// <summary>
		/// Gets or sets the drawing bounds.
		/// </summary>
		public Rectangle? Bounds { get; set; }

		/// <summary>
		/// Gets or sets number of appointment overlaps.
		/// </summary>
		public int Overlaps { get; set; }

		/// <summary>
		/// Gets or sets the overlap offset.
		/// </summary>
		public int OverlapOffset { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="AgendaAppointment"/> is selected.
		/// </summary>
		/// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
		public bool Selected { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="AgendaAppointment"/> is hovered.
		/// </summary>
		/// <value><c>true</c> if hovered; otherwise, <c>false</c>.</value>
		public bool Hovered { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="AgendaAppointment"/> class.
		/// </summary>
		public AgendaAppointment() {
			this.Overlaps = 1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="AgendaAppointment"/> class.
		/// </summary>
		/// <param name="title">The title.</param>
		/// <param name="contents">The contents.</param>
		/// <param name="place">The place.</param>
		/// <param name="begin">The begin.</param>
		/// <param name="end">The end.</param>
		public AgendaAppointment( String title , String contents , String place , DateTime begin , DateTime end )
			: this() {
			this.Title = title;
			this.Contents = contents;
			this.Place = place;
			this.Begin = begin;
			this.End = end;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="AgendaAppointment"/> class.
		/// </summary>
		/// <param name="title">The title.</param>
		/// <param name="contents">The contents.</param>
		/// <param name="place">The place.</param>
		/// <param name="begin">The begin.</param>
		/// <param name="end">The end.</param>
		/// <param name="color">The color.</param>
		/// <param name="tag">The tag.</param>
		public AgendaAppointment( String title , String contents , String place , DateTime begin , DateTime end , Color color , Object tag )
			: this( title , contents , place , begin , end ) {
			this.Color1 = color;
			this.Tag = tag;
			this.Bounds = null;
		}

		#endregion

	}

}
