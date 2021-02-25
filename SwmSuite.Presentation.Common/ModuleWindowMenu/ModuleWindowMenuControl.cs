using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace SwmSuite.Presentation.Common.ModuleWindowMenu {
	
	public partial class ModuleWindowMenuControl : UserControl {

		#region -_ Private Members _-

		private ModuleWindowMenuScheme _scheme = new ModuleWindowMenuScheme();
		private ModuleWindowMenuRenderer _renderer = new ModuleWindowMenuRenderer();
		
		private ModuleWindowMenuItemCollection _menuItems = new ModuleWindowMenuItemCollection();

		#endregion

		#region -_ Public Properties _-

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public ModuleWindowMenuScheme Scheme {
			get {
				return _scheme;
			}
			set {
				_scheme = value;
			}
		}

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public ModuleWindowMenuRenderer Renderer {
			get {
				return _renderer;
			}
			set {
				_renderer = value;
			}
		}

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content )]
		public ModuleWindowMenuItemCollection MenuItems {
			get {
				return _menuItems;
			}
		}

		#endregion

		#region -_ Public Events _-

		/// <summary>
		/// Occurs when a menu item has been clicked.
		/// </summary>
		public event EventHandler<ModuleWindowMenuEventArgs> MenuItemClicked;

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ModuleWindowMenuControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );
		}

		#endregion

		private void ModuleWindowMenuControl_Paint( object sender , PaintEventArgs e ) {
			//_renderer.Render( e.Graphics , this.ClientRectangle , this.MenuItems );
			this.Renderer.RenderBackground( e.Graphics , this.ClientRectangle , this.Scheme );
			this.Renderer.RenderMenu( e.Graphics , this.ClientRectangle , this.Scheme , this.MenuItems );
		}

		private void ModuleWindowMenuControl_MouseMove( object sender , MouseEventArgs e ) {
			ModuleWindowMenuItem itemHovered = new ModuleWindowMenuHitTester().HitTest(
				this.ClientRectangle , e.Location , this.Scheme , this.MenuItems );
			if( itemHovered != null ) {
				foreach( ModuleWindowMenuItem item in this.MenuItems.List ) {
					item.Hovered = false;
				}
				itemHovered.Hovered = true;
				Invalidate();
			}
		}

		private void ModuleWindowMenuControl_MouseUp( object sender , MouseEventArgs e ) {
			ModuleWindowMenuItem itemHovered = new ModuleWindowMenuHitTester().HitTest(
				this.ClientRectangle , e.Location , this.Scheme , this.MenuItems );
			if( itemHovered != null ) {
				foreach( ModuleWindowMenuItem item in this.MenuItems.List ) {
					item.Selected = false;
				}
				itemHovered.Selected = true;
				if( this.MenuItemClicked != null ) {
					MenuItemClicked( this , new ModuleWindowMenuEventArgs( itemHovered ) );
				}
				Invalidate();
			}
		}

		private void ModuleWindowMenuControl_SizeChanged( object sender , EventArgs e ) {
			this.Renderer.Invalidate();
			this.Invalidate();
		}

		private void ModuleWindowMenuControl_MouseLeave( object sender , EventArgs e ) {
			foreach( ModuleWindowMenuItem item in this.MenuItems.List ) {
				item.Hovered = false;
			}
			Invalidate();
		}

	}

}
