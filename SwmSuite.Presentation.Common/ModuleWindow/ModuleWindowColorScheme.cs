using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;

namespace SwmSuite.Presentation.Common.ModuleWindow {
	
	public class ModuleWindowColorScheme {

		#region -_ Private Members _-

		private Color _headerFlood1Color;
		private Color _headerFlood2Color;

		private Color _footerFlood1Color;
		private Color _footerFlood2Color;

		private Color _leftPanelFlood1Color;
		private Color _leftPanelFlood2Color;

		#endregion

		#region -_ Public Properties _-

		public Color HeaderFlood1Color { get { return _headerFlood1Color; } set { _headerFlood1Color = value; } }
		public Color HeaderFlood2Color { get { return _headerFlood2Color; } set { _headerFlood2Color = value; } }

		public Color FooterFlood1Color { get { return _footerFlood1Color; } set { _footerFlood1Color = value; } }
		public Color FooterFlood2Color { get { return _footerFlood2Color; } set { _footerFlood2Color = value; } }

		public Color LeftPanelFlood1Color { get { return _leftPanelFlood1Color; } set { _leftPanelFlood1Color = value; } }
		public Color LeftPanelFlood2Color { get { return _leftPanelFlood2Color; } set { _leftPanelFlood2Color = value; } }

		#endregion

		# region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ModuleWindowColorScheme() {
		}

		/// <summary>
		/// Custom constructor expecting values.
		/// </summary>
		public ModuleWindowColorScheme( 
			Color headerFlood1Color ,
			Color headerFlood2Color,
			Color footerFlood1Color , 
			Color footerFlood2Color ,
			Color leftPanelFlood1Color,
			Color leftPanelFlood2Color ) {
			this.HeaderFlood1Color = headerFlood1Color;
			this.HeaderFlood2Color = headerFlood2Color;
			this.FooterFlood1Color = footerFlood1Color;
			this.FooterFlood2Color = footerFlood2Color;
			this.LeftPanelFlood1Color = leftPanelFlood1Color;
			this.LeftPanelFlood2Color = leftPanelFlood2Color;
		}

		#endregion

	}

}
