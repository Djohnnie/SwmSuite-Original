using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;

namespace SwmSuite.Presentation.Common.AvatarBrowser {
	
	public class AvatarBrowserScheme {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the width of the navigation button.
		/// </summary>
		/// <value>The width of the navigation button.</value>
		public int NavigationButtonWidth { get; set; }


		/// <summary>
		/// Gets or sets the avatar spacing.
		/// </summary>
		/// <value>The avatar spacing.</value>
		public int AvatarSpacing { get; set; }


		/// <summary>
		/// Gets or sets the first color of the selected background.
		/// </summary>
		/// <value>The color of the first selected background.</value>
		public Color SelectedBackgroundColor1 { get; set; }


		/// <summary>
		/// Gets or sets the second color of the selected background.
		/// </summary>
		/// <value>The color of the second selected background.</value>
		public Color SelectedBackgroundColor2 { get; set; }

		/// <summary>
		/// Gets or sets the third color of the selected background.
		/// </summary>
		/// <value>The color of the third selected background.</value>
		public Color SelectedBackgroundColor3 { get; set; }


		/// <summary>
		/// Gets or sets the fourth color of the selected background.
		/// </summary>
		/// <value>The color of the fourth selected background.</value>
		public Color SelectedBackgroundColor4 { get; set; }

		/// <summary>
		/// Gets or sets the color of the selected border.
		/// </summary>
		/// <value>The color of the selected border.</value>
		public Color SelectedBorderColor { get; set; }

		/// <summary>
		/// Gets or sets the color of the navigation button border.
		/// </summary>
		/// <value>The color of the navigation button border.</value>
		public Color NavigationButtonBorderColor { get; set; }

		/// <summary>
		/// Gets or sets the first color of the navigation button background.
		/// </summary>
		/// <value>The first color of the navigation button background.</value>
		public Color NavigationButtonBackgroundColor1 { get; set; }

		/// <summary>
		/// Gets or sets the second color of the navigation button background.
		/// </summary>
		/// <value>The second color of the navigation button background.</value>
		public Color NavigationButtonBackgroundColor2 { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="AvatarBrowserScheme"/> class.
		/// </summary>
		public AvatarBrowserScheme() {
			this.NavigationButtonWidth = 20;
			this.AvatarSpacing = 10;
			this.SelectedBackgroundColor1 = Color.FromArgb( 255 , 234 , 194 );
			this.SelectedBackgroundColor2 = Color.FromArgb( 255 , 211 , 125 );
			this.SelectedBackgroundColor3 = Color.FromArgb( 255 , 192 , 71 );
			this.SelectedBackgroundColor4 = Color.FromArgb( 255 , 231 , 185 );
			this.SelectedBorderColor = Color.FromArgb( 153 , 222 , 253 );

			this.NavigationButtonBorderColor = Color.FromArgb( 0 , 0 , 0 );
			this.NavigationButtonBackgroundColor1 = Color.FromArgb( 170 , 170 , 170 );
			this.NavigationButtonBackgroundColor2 = Color.FromArgb( 50 , 50 , 50 );
		}

		#endregion

	}

}
