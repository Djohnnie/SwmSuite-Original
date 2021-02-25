using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;

namespace SimpleWorkfloorManagementSuite.Modules.Notification {
	
	/// <summary>
	/// Class representing the layout scheme for a notification control.
	/// </summary>
	public class NotificationScheme {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the color of the border.
		/// </summary>
		/// <value>The border color.</value>
		public Color BorderColorNormal { get; set; }

		/// <summary>
		/// Gets or sets the color of the border when hovered.
		/// </summary>
		/// <value>The border color when hovered.</value>
		public Color BorderColorHovered { get; set; }

		/// <summary>
		/// Gets or sets the color of the title.
		/// </summary>
		/// <value>The title color.</value>
		public Color TitleColor { get; set; }

		/// <summary>
		/// Gets or sets the font for the title.
		/// </summary>
		/// <value>The title font.</value>
		public Font TitleFont { get; set; }

		/// <summary>
		/// Gets or sets the color of the main text.
		/// </summary>
		/// <value>The main text color.</value>
		public Color MainTextColor { get; set; }

		/// <summary>
		/// Gets or sets the font for the main text.
		/// </summary>
		/// <value>The main text font.</value>
		public Font MainTextFont { get; set; }

		/// <summary>
		/// Gets or sets the font for the main text.
		/// </summary>
		/// <value>The main text font.</value>
		public Font MainText2Font { get; set; }

		/// <summary>
		/// Gets or sets the first color of the background.
		/// </summary>
		/// <value>The first background color.</value>
		public Color BackgroundColor1Normal { get; set; }

		/// <summary>
		/// Gets or sets the second color of the background.
		/// </summary>
		/// <value>The second background color.</value>
		public Color BackgroundColor2Normal { get; set; }

		/// <summary>
		/// Gets or sets the third color of the background.
		/// </summary>
		/// <value>The third background color.</value>
		public Color BackgroundColor3Normal { get; set; }

		/// <summary>
		/// Gets or sets the fourth color of the background.
		/// </summary>
		/// <value>The fourth background color.</value>
		public Color BackgroundColor4Normal { get; set; }

		/// <summary>
		/// Gets or sets the first color of the background when hovered.
		/// </summary>
		/// <value>The first background color when hovered.</value>
		public Color BackgroundColor1Hovered { get; set; }

		/// <summary>
		/// Gets or sets the second color of the background when hovered.
		/// </summary>
		/// <value>The second background color when hovered.</value>
		public Color BackgroundColor2Hovered { get; set; }

		/// <summary>
		/// Gets or sets the third color of the background when hovered.
		/// </summary>
		/// <value>The third background color when hovered.</value>
		public Color BackgroundColor3Hovered { get; set; }

		/// <summary>
		/// Gets or sets the fourth color of the background when hovered.
		/// </summary>
		/// <value>The fourth background color when hovered.</value>
		public Color BackgroundColor4Hovered { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="NotificationScheme"/> class.
		/// </summary>
		public NotificationScheme() {
			this.BorderColorNormal = Color.FromArgb( 189 , 189 , 189 );
			this.BorderColorHovered = Color.FromArgb( 150 , 150 , 150 );
			this.TitleColor = Color.FromArgb( 0 , 0 , 128 );
			this.TitleFont = new Font( "Verdana" , 14.0f , FontStyle.Bold );
			this.MainTextColor = Color.FromArgb( 0 , 0 , 0 );
			this.MainTextFont = new Font( "Verdana" , 11.0f , FontStyle.Regular );
			this.MainText2Font = new Font( "Verdana" , 10.0f , FontStyle.Regular );
			this.BackgroundColor1Normal = Color.FromArgb( 255 , 255 , 255 );
			this.BackgroundColor2Normal = Color.FromArgb( 246 , 246 , 246 );
			this.BackgroundColor3Normal = Color.FromArgb( 246 , 246 , 246 );
			this.BackgroundColor4Normal = Color.FromArgb( 237 , 237 , 237 );
			this.BackgroundColor1Hovered = Color.FromArgb( 255 , 234 , 194 );
			this.BackgroundColor2Hovered = Color.FromArgb( 255 , 211 , 125 );
			this.BackgroundColor3Hovered = Color.FromArgb( 255 , 192 , 71 );
			this.BackgroundColor4Hovered = Color.FromArgb( 255 , 231 , 185 );
		}

		#endregion

	}

}
