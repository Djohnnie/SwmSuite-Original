using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SwmSuite.Presentation.Common.CheckList {

	/// <summary>
	/// Class defining the scheme for the checklist control.
	/// </summary>
	public class CheckListScheme {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the first background color.
		/// </summary>
		/// <value>The first background color.</value>
		public Color BackgroundColor1 { get; set; }
		/// <summary>
		/// Gets or sets the second background color.
		/// </summary>
		/// <value>The second background color.</value>
		public Color BackgroundColor2 { get; set; }
		/// <summary>
		/// Gets or sets the third background color.
		/// </summary>
		/// <value>The third background color.</value>
		public Color BackgroundColor3 { get; set; }
		/// <summary>
		/// Gets or sets the fourth background color.
		/// </summary>
		/// <value>The fourth background color.</value>
		public Color BackgroundColor4 { get; set; }

		/// <summary>
		/// Gets or sets the color of the item caption.
		/// </summary>
		/// <value>The color of the item caption.</value>
		public Color ItemCaptionColor { get; set; }
		/// <summary>
		/// Gets or sets the item caption font.
		/// </summary>
		/// <value>The item caption font.</value>
		public Font ItemCaptionFont { get; set; }

		/// <summary>
		/// Gets or sets the color of the item outer border.
		/// </summary>
		/// <value>The color of the item outer border.</value>
		public Color ItemOuterBorderColor { get; set; }
		/// <summary>
		/// Gets or sets the color of the item inner border.
		/// </summary>
		/// <value>The color of the item inner border.</value>
		public Color ItemInnerBorderColor { get; set; }
		/// <summary>
		/// Gets or sets the color of the item glow.
		/// </summary>
		/// <value>The color of the item glow.</value>
		public Color ItemGlowColor { get; set; }

		/// <summary>
		/// Gets or sets the item outer border color selected.
		/// </summary>
		/// <value>The item outer border color selected.</value>
		public Color ItemOuterBorderColorSelected { get; set; }
		/// <summary>
		/// Gets or sets the item inner border color selected.
		/// </summary>
		/// <value>The item inner border color selected.</value>
		public Color ItemInnerBorderColorSelected { get; set; }
		/// <summary>
		/// Gets or sets the item glow color selected.
		/// </summary>
		/// <value>The item glow color selected.</value>
		public Color ItemGlowColorSelected { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="CheckListScheme"/> class.
		/// </summary>
		public CheckListScheme() {
			this.BackgroundColor1 = Color.FromArgb( 136 , 180 , 192 );
			this.BackgroundColor2 = Color.FromArgb( 71 , 139 , 158 );
			this.BackgroundColor3 = Color.FromArgb( 19 , 97 , 119 );
			this.BackgroundColor4 = Color.FromArgb( 83 , 159 , 171 );

			this.ItemCaptionColor = Color.FromArgb( 255 , 255 , 255 );
			this.ItemCaptionFont = new Font( "Verdana" , 10.0f , FontStyle.Regular );

			this.ItemOuterBorderColor = Color.FromArgb( 84 , 115 , 131 );
			this.ItemInnerBorderColor = Color.FromArgb( 217 , 229 , 236 );
			this.ItemGlowColor = Color.FromArgb( 100 , 255 , 255 , 255 );

			this.ItemOuterBorderColorSelected = Color.FromArgb( 42 , 58 , 65 );
			this.ItemInnerBorderColorSelected = Color.FromArgb( 87 , 112 , 125 );
			this.ItemGlowColorSelected = Color.FromArgb( 100 , 100 , 100 , 100 );
		}

		#endregion

	}

}
