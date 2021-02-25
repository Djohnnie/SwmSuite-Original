using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SwmSuite.Presentation.Common.StatusGroup {
	
	public class StatusGroupScheme {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the color of the background.
		/// </summary>
		/// <value>The color of the background.</value>
		public Color BackgroundColor { get; set; }

		/// <summary>
		/// Gets or sets the color of the border.
		/// </summary>
		/// <value>The color of the border.</value>
		public Color BorderColor { get; set; }

		/// <summary>
		/// Gets or sets the first good color.
		/// </summary>
		/// <value>The first good color.</value>
		public Color GoodColor1 { get; set; }

		/// <summary>
		/// Gets or sets the second good color.
		/// </summary>
		/// <value>The second good color.</value>
		public Color GoodColor2 { get; set; }

		/// <summary>
		/// Gets or sets the first warn color.
		/// </summary>
		/// <value>The first warn color.</value>
		public Color WarnColor1 { get; set; }

		/// <summary>
		/// Gets or sets the second warn color.
		/// </summary>
		/// <value>The second warn color.</value>
		public Color WarnColor2 { get; set; }

		/// <summary>
		/// Gets or sets the first bad color.
		/// </summary>
		/// <value>The first bad color.</value>
		public Color BadColor1 { get; set; }

		/// <summary>
		/// Gets or sets the second bad color.
		/// </summary>
		/// <value>The second bad color.</value>
		public Color BadColor2 { get; set; }

		/// <summary>
		/// Gets or sets the first invalid color.
		/// </summary>
		/// <value>The first invalid color.</value>
		public Color InvalidColor1 { get; set; }

		/// <summary>
		/// Gets or sets the second invalid color.
		/// </summary>
		/// <value>The second invalid color.</value>
		public Color InvalidColor2 { get; set; }

		/// <summary>
		/// Gets or sets the status alignment.
		/// </summary>
		/// <value>The status alignment.</value>
		public StatusGroupAlignment StatusAlignment { get; set; }

		/// <summary>
		/// Gets or sets the size of the status.
		/// </summary>
		/// <value>The size of the status.</value>
		public int StatusSize { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="StatusGroupScheme"/> class.
		/// </summary>
		public StatusGroupScheme() {
			this.BackgroundColor = Color.FromArgb( 255 , 255 , 255 );
			this.BorderColor = Color.FromArgb( 204 , 204 , 204 );

			this.GoodColor1 = Color.FromArgb( 22 , 118 , 20 );
			this.GoodColor2 = Color.FromArgb( 65 , 178 , 61 );

			this.WarnColor1 = Color.FromArgb( 242 , 177 , 0 );
			this.WarnColor2 = Color.FromArgb( 254 , 205 , 72 );

			this.BadColor1 = Color.FromArgb( 172 , 1 , 0 );
			this.BadColor2 = Color.FromArgb( 221 , 1 , 0 );

			this.InvalidColor1 = Color.FromArgb( 172 , 172 , 172 );
			this.InvalidColor2 = Color.FromArgb( 221 , 221 , 221 );

			this.StatusAlignment = StatusGroupAlignment.Left;
			this.StatusSize = 20;
		}

		#endregion

	}

}
