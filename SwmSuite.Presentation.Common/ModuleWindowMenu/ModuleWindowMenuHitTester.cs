using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;

namespace SwmSuite.Presentation.Common.ModuleWindowMenu {

	public class ModuleWindowMenuHitTester {

		public ModuleWindowMenuItem HitTest( Rectangle bounds , Point position , ModuleWindowMenuScheme scheme , ModuleWindowMenuItemCollection menuItems ) {
			ModuleWindowMenuItem itemToReturn = null;
			if( position.X > bounds.Left && position.X < bounds.Right ) {
				int totalHeight = menuItems.List.Count * scheme.MenuItemHeight;
				int baseY = bounds.Top + scheme.MenuTopOffset;
				if( position.Y > baseY && position.Y < baseY + totalHeight ) {
					int relativeY = position.Y - baseY;
					int itemIndex = relativeY / scheme.MenuItemHeight;
					itemToReturn = menuItems.List[itemIndex];
				}
			}
			return itemToReturn;
		}

	}
}
