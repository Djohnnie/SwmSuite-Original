using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Drawing.Text;

namespace SwmSuite.Presentation.Common.ModuleWindowMenu {

	public class ModuleWindowMenuScheme {

		#region -_ Private Members _-

		private Color _backgroundColor;
		private Color _backgroundFlood1Color;
		private Color _backgroundFlood2Color;

		private Color _itemCaptionColor;
		private Font _itemCaptionFont;

		private Color _itemOuterBorderColor;
		private Color _itemInnerBorderColor;
		private Color _itemGlowColor;

		private Color _itemOuterBorderColorSelected;
		private Color _itemInnerBorderColorSelected;
		private Color _itemGlowColorSelected;

		private int _menuTopOffset;
		private int _menuItemHeight;
		private int _menuItemRoundedCornerRadius;

		#endregion

		#region -_ Public Properties _-

		public Color BackgroundColor { get { return _backgroundColor; } set { _backgroundColor = value; } }
		public Color BackgroundFlood1Color { get { return _backgroundFlood1Color; } set { _backgroundFlood1Color = value; } }
		public Color BackgroundFlood2Color { get { return _backgroundFlood2Color; } set { _backgroundFlood2Color = value; } }

		public Color ItemCaptionColor { get; set; }
		public Font ItemCaptionFont { get; set; }
		public Color ItemOuterBorderColor { get; set; }
		public Color ItemInnerBorderColor { get; set; }
		public Color ItemGlowColor { get; set; }
		public Color ItemOuterBorderColorSelected { get; set; }
		public Color ItemInnerBorderColorSelected { get; set; }
		public Color ItemGlowColorSelected { get; set; }

		public int MenuTopOffset { get { return _menuTopOffset; } set { _menuTopOffset = value; } }
		public int MenuItemHeight { get { return _menuItemHeight; } set { _menuItemHeight = value; } }
		public int MenuItemRoundedCornerRadius { get { return _menuItemRoundedCornerRadius; } set { _menuItemRoundedCornerRadius = value; } }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ModuleWindowMenuScheme() {
			this.BackgroundColor = Color.FromArgb( 255 , 255 , 255 );
			this.BackgroundFlood1Color = Color.FromArgb( 65 , 110 , 165 );
			this.BackgroundFlood2Color = Color.FromArgb( 110 , 185 , 110 );

			this.ItemCaptionColor = Color.FromArgb( 255 , 255 , 255 );
			this.ItemCaptionFont = new Font( "Verdana" , 10.0f , FontStyle.Regular );

			this.ItemOuterBorderColor = Color.FromArgb( 84 , 115 , 131 );
			this.ItemInnerBorderColor = Color.FromArgb( 217 , 229 , 236 );
			this.ItemGlowColor = Color.FromArgb( 100 , 255 , 255 , 255 );

			this.ItemOuterBorderColorSelected = Color.FromArgb( 42 , 58 , 65 );
			this.ItemInnerBorderColorSelected = Color.FromArgb( 87 , 112 , 125 );
			this.ItemGlowColorSelected = Color.FromArgb( 100 , 100 , 100 , 100 );

			this.MenuItemHeight = 50;
			this.MenuTopOffset = 100;
			this.MenuItemRoundedCornerRadius = 20;
		}

		#endregion

	}

}
