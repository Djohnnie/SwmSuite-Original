using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;

namespace SwmSuite.Presentation.Common.EmployeeGroupTab {
	
	public class EmployeeGroupTabScheme {

		#region -_ Private Members _-

		private Color _backgroundColor1;
		private Color _backgroundColor2;
		private Color _backgroundColor3;
		private Color _backgroundColor4;

		private Color _itemCaptionColor;
		private Font _itemCaptionFont;

		private Color _itemOuterBorderColor;
		private Color _itemInnerBorderColor;
		private Color _itemGlowColor;

		private Color _itemOuterBorderColorSelected;
		private Color _itemInnerBorderColorSelected;
		private Color _itemGlowColorSelected;

		#endregion

		#region -_ Public Properties _-

		public event EventHandler<EventArgs> NeedsRedraw;

		public Color BackgroundColor1 {
			get {
				return _backgroundColor1;
			}
			set {
				_backgroundColor1 = value;
				RaiseNeedsRedraw();
			}
		}

		public Color BackgroundColor2 {
			get {
				return _backgroundColor2;
			}
			set {
				_backgroundColor2 = value;
				RaiseNeedsRedraw();
			}
		}

		public Color BackgroundColor3 {
			get {
				return _backgroundColor3;
			}
			set {
				_backgroundColor3 = value;
				RaiseNeedsRedraw();
			}
		}

		public Color BackgroundColor4 {
			get {
				return _backgroundColor4;
			}
			set {
				_backgroundColor4 = value;
				RaiseNeedsRedraw();
			}
		}

		public Color ItemCaptionColor {
			get {
				return _itemCaptionColor;
			}
			set {
				_itemCaptionColor = value;
				RaiseNeedsRedraw();
			}
		}

		public Font ItemCaptionFont {
			get {
				return _itemCaptionFont;
			}
			set {
				_itemCaptionFont = value;
				RaiseNeedsRedraw();
			}
		}

		public Color ItemOuterBorderColor {
			get {
				return _itemOuterBorderColor;
			}
			set {
				_itemOuterBorderColor = value;
				RaiseNeedsRedraw();
			}
		}

		public Color ItemInnerBorderColor {
			get {
				return _itemInnerBorderColor;
			}
			set {
				_itemInnerBorderColor = value;
				RaiseNeedsRedraw();
			}
		}

		public Color ItemGlowColor {
			get {
				return _itemGlowColor;
			}
			set {
				_itemGlowColor = value;
				RaiseNeedsRedraw();
			}
		}

		public Color ItemOuterBorderColorSelected {
			get {
				return _itemOuterBorderColorSelected;
			}
			set {
				_itemOuterBorderColorSelected = value;
				RaiseNeedsRedraw();
			}
		}

		public Color ItemInnerBorderColorSelected {
			get {
				return _itemInnerBorderColorSelected;
			}
			set {
				_itemInnerBorderColorSelected = value;
				RaiseNeedsRedraw();
			}
		}

		public Color ItemGlowColorSelected {
			get {
				return _itemGlowColorSelected;
			}
			set {
				_itemGlowColorSelected = value;
				RaiseNeedsRedraw();
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public EmployeeGroupTabScheme() {
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

		#region -_ Public Methods _-

		#endregion

		#region -_ Private Methods _-

		/// <summary>
		/// Raise the 'NeedsRedraw' event.
		/// </summary>
		private void RaiseNeedsRedraw() {
			if( this.NeedsRedraw != null ) {
				this.NeedsRedraw( this , EventArgs.Empty );
			}
		}

		#endregion

	}

}
