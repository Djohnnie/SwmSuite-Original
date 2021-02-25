using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SwmSuite.Presentation.Common.TimeTable {
	
	public class TimeTableControlEntry {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="TimeTableControlEntry"/> is hovered.
		/// </summary>
		/// <value><c>true</c> if hovered; otherwise, <c>false</c>.</value>
		public bool Hovered { get; set; }

		/// <summary>
		/// Gets or sets the begin.
		/// </summary>
		/// <value>The begin.</value>
		public DateTime Begin { get; set; }

		/// <summary>
		/// Gets or sets the end.
		/// </summary>
		/// <value>The end.</value>
		public DateTime End { get; set; }

		/// <summary>
		/// Gets or sets the first background color.
		/// </summary>
		/// <value>The first background color.</value>
		public Color BackColor1 { get; set; }

		/// <summary>
		/// Gets or sets the second background color.
		/// </summary>
		/// <value>The second background color.</value>
		public Color BackColor2 { get; set; }

		/// <summary>
		/// Gets or sets the color of the border.
		/// </summary>
		/// <value>The color of the border.</value>
		public Color BorderColor { get; set; }

		/// <summary>
		/// Gets or sets the tag.
		/// </summary>
		/// <value>The tag.</value>
		public Object Tag { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		public String Description { get; set; }

		#endregion

		#region -_ ToString _-

		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </returns>
		public override string ToString() {
			return this.Begin.ToShortTimeString() + " - " + this.End.ToShortTimeString() + "\n( " + this.Description + " )";
		}

		#endregion

	}

}
