using System;
using System.Collections.Generic;

using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using SwmSuite.Presentation.Drawing;

namespace SwmSuite.Presentation.Common.ModuleWindowMenu {

	public class ModuleWindowMenuRenderer : IDisposable {

		#region -_ Private Members _-

		private LinearGradientBrush _backgroundBrush = null;

		private StringFormat _itemCaptionStringFormat;
		private SolidBrush _itemCaptionBrush;

		private Pen _itemOuterBorderPen;
		private Pen _itemInnerBorderPen;

		private LinearGradientBrush _itemGlowBrush;

		private Pen _itemOuterBorderPenSelected;
		private Pen _itemInnerBorderPenSelected;

		private LinearGradientBrush _itemGlowBrushSelected;

		#endregion

		#region -_ Public Properties _-

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ModuleWindowMenuRenderer() {
			
		}

		#endregion

		#region -_ Public Methods _-

		public void RenderBackground( Graphics graphics , Rectangle drawRectangle , ModuleWindowMenuScheme scheme ) {
			graphics.FillRectangle( GetBackgroundBrush( drawRectangle , scheme ) , drawRectangle );
		}

		public void RenderMenu( Graphics graphics , Rectangle drawRectangle , ModuleWindowMenuScheme scheme , ModuleWindowMenuItemCollection menuItems ) {
			Rectangle menuItemRect = new Rectangle( 10 , scheme.MenuTopOffset , drawRectangle.Width - 20 , scheme.MenuItemHeight );
			foreach( ModuleWindowMenuItem menuItem in menuItems.List ) {
				bool drawDivider = true;
				if( menuItem.Selected ) {
					drawDivider = false;
				} else {
					if( menuItems.List.IndexOf( menuItem ) == menuItems.List.Count - 1 ) {
						drawDivider = false;
					} else {
						if( menuItems.List[menuItems.List.IndexOf( menuItem ) + 1].Selected){
							drawDivider = false;
						}
					}
				}
				RenderMenuItem( graphics , menuItemRect , scheme , menuItem , drawDivider );
				menuItemRect.Offset( 0 , scheme.MenuItemHeight );
			}
		}

		private void RenderMenuItem( Graphics graphics , Rectangle drawRectangle , ModuleWindowMenuScheme scheme , ModuleWindowMenuItem menuItem , bool drawDivider ) {
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			if( menuItem.Selected ) {
				Rectangle outerRectangle = drawRectangle;
				Rectangle innerRectangle = new Rectangle( drawRectangle.Left + 1 , drawRectangle.Top + 1 , drawRectangle.Width - 2 , drawRectangle.Height - 2 );
				GraphicsPath outerPath = DrawingTools.GetRoundedRect( outerRectangle , 5 );
				GraphicsPath innerPath = DrawingTools.GetRoundedRect( innerRectangle , 4 );
				graphics.FillPath( GetItemGlowBrushSelected( outerRectangle , scheme ) , outerPath );
				graphics.DrawPath( GetItemOuterBorderPenSelected( scheme ) , outerPath );
				graphics.DrawPath( GetItemInnerBorderPenSelected( scheme ) , innerPath );
				innerPath.Dispose();
				outerPath.Dispose();
			} else {
				if( menuItem.Hovered ) {
					Rectangle outerRectangle = drawRectangle;
					Rectangle innerRectangle = new Rectangle( drawRectangle.Left + 1 , drawRectangle.Top + 1 , drawRectangle.Width - 2 , drawRectangle.Height - 2 );
					GraphicsPath outerPath = DrawingTools.GetRoundedRect( outerRectangle , 5 );
					GraphicsPath innerPath = DrawingTools.GetRoundedRect( innerRectangle , 4 );
					graphics.FillPath( GetItemGlowBrush( outerRectangle , scheme ) , outerPath );
					graphics.DrawPath( GetItemOuterBorderPen( scheme ) , outerPath );
					graphics.DrawPath( GetItemInnerBorderPen( scheme ) , innerPath );
					innerPath.Dispose();
					outerPath.Dispose();
				}
			}		

			Rectangle menuTitleRect = new Rectangle( drawRectangle.Left + 10 , drawRectangle.Top , drawRectangle.Width - 20 , drawRectangle.Height );
			StringFormat menuTitleFormat = new StringFormat() {
				Alignment = StringAlignment.Center ,
				LineAlignment = StringAlignment.Center
			};

			graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics.DrawString( menuItem.Title , scheme.ItemCaptionFont , GetItemCaptionBrush( scheme ) , menuTitleRect , GetItemCaptionStringFormat() );
			
			menuTitleFormat.Dispose();
		}

		public void Invalidate() {
			if( _backgroundBrush != null ){
				_backgroundBrush.Dispose();
				_backgroundBrush = null;
			}
			if( _itemCaptionStringFormat != null ) {
				_itemCaptionStringFormat.Dispose();
				_itemCaptionStringFormat = null;
			}
			if( _itemCaptionBrush != null ) {
				_itemCaptionBrush.Dispose();
				_itemCaptionBrush = null;
			}
			if( _itemOuterBorderPen != null ) {
				_itemOuterBorderPen.Dispose();
				_itemOuterBorderPen = null;
			}
			if( _itemInnerBorderPen != null ) {
				_itemInnerBorderPen.Dispose();
				_itemInnerBorderPen = null;
			}
			if( _itemGlowBrush != null ) {
				_itemGlowBrush.Dispose();
				_itemGlowBrush = null;
			}
			if( _itemOuterBorderPenSelected != null ) {
				_itemOuterBorderPenSelected.Dispose();
				_itemOuterBorderPenSelected = null;
			}
			if( _itemInnerBorderPenSelected != null ) {
				_itemInnerBorderPenSelected.Dispose();
				_itemInnerBorderPenSelected = null;
			}
			if( _itemGlowBrushSelected != null ) {
				_itemGlowBrushSelected.Dispose();
				_itemGlowBrushSelected = null;
			}
		}

		#endregion

		#region -_ Private Methods _-

		private LinearGradientBrush GetBackgroundBrush( Rectangle bounds , ModuleWindowMenuScheme scheme ) {
			if( _backgroundBrush == null ) {
				_backgroundBrush = new LinearGradientBrush( bounds , scheme.BackgroundFlood1Color , scheme.BackgroundFlood2Color , LinearGradientMode.Vertical );
			}
			return _backgroundBrush;
		}

		private StringFormat GetItemCaptionStringFormat() {
			if( _itemCaptionStringFormat == null ) {
				_itemCaptionStringFormat = new StringFormat() { Alignment = StringAlignment.Center , LineAlignment = StringAlignment.Center };
			}
			return _itemCaptionStringFormat;
		}

		private SolidBrush GetItemCaptionBrush( ModuleWindowMenuScheme scheme ) {
			if( _itemCaptionBrush == null ) {
				_itemCaptionBrush = new SolidBrush( scheme.ItemCaptionColor );
			}
			return _itemCaptionBrush;
		}

		private Pen GetItemOuterBorderPen( ModuleWindowMenuScheme scheme ) {
			if( _itemOuterBorderPen == null ) {
				_itemOuterBorderPen = new Pen( scheme.ItemOuterBorderColor );
			}
			return _itemOuterBorderPen;
		}

		private Pen GetItemInnerBorderPen( ModuleWindowMenuScheme scheme ) {
			if( _itemInnerBorderPen == null ) {
				_itemInnerBorderPen = new Pen( scheme.ItemInnerBorderColor );
			}
			return _itemInnerBorderPen;
		}

		private LinearGradientBrush GetItemGlowBrush( Rectangle bounds , ModuleWindowMenuScheme scheme ) {
			if( _itemGlowBrush == null ) {
				_itemGlowBrush = new LinearGradientBrush( bounds , scheme.ItemGlowColor , Color.Transparent , LinearGradientMode.Vertical );
			}
			return _itemGlowBrush;
		}

		private Pen GetItemOuterBorderPenSelected( ModuleWindowMenuScheme scheme ) {
			if( _itemOuterBorderPenSelected == null ) {
				_itemOuterBorderPenSelected = new Pen( scheme.ItemOuterBorderColorSelected );
			}
			return _itemOuterBorderPenSelected;
		}

		private Pen GetItemInnerBorderPenSelected( ModuleWindowMenuScheme scheme ) {
			if( _itemInnerBorderPenSelected == null ) {
				_itemInnerBorderPenSelected = new Pen( scheme.ItemInnerBorderColorSelected );
			}
			return _itemInnerBorderPenSelected;
		}

		private LinearGradientBrush GetItemGlowBrushSelected( Rectangle bounds , ModuleWindowMenuScheme scheme ) {
			if( _itemGlowBrushSelected == null ) {
				_itemGlowBrushSelected = new LinearGradientBrush( bounds , scheme.ItemGlowColorSelected , Color.Transparent , LinearGradientMode.Vertical );
			}
			return _itemGlowBrushSelected;
		}

		#endregion

		#region -_ IDisposable Members _-

		public void Dispose() {
			GC.SuppressFinalize( this );
			Dispose( true );
		}

		protected void Dispose( bool dispose ) {
			if( dispose ) {
				Invalidate();
			}
		}

		#endregion

	}

}