using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;
using SwmSuite.Presentation.Drawing;

namespace SwmSuite.Presentation.Common.EmployeeGroupTab {
	
	public class EmployeeGroupTabRenderer : IDisposable {

		#region -_ Private Members _-

		private LinearGradientBrush _backgroundTopBrush;
		private LinearGradientBrush _backgroundBottomBrush;

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

		#endregion

		#region -_ Public Methods _-

		public void RenderBackground( Graphics graphics , Rectangle drawRectangle , EmployeeGroupTabScheme scheme ) {
			Rectangle topRectangle = new Rectangle( drawRectangle.Left , drawRectangle.Top , drawRectangle.Width , drawRectangle.Height / 2 );
			Rectangle bottomRectangle = new Rectangle( drawRectangle.Left , drawRectangle.Top + drawRectangle.Height / 2 , drawRectangle.Width , drawRectangle.Height / 2 );
			graphics.FillRectangle( GetBackgroundTopBrush( topRectangle , scheme ) , topRectangle );
			graphics.FillRectangle( GetBackgroundBottomBrush( bottomRectangle , scheme ) , bottomRectangle );
		}

		public void RenderItem( Graphics graphics , Rectangle drawRectangle , EmployeeGroupTabScheme scheme , EmployeeGroupTabItem item ) {
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			if( item.Selected ) {
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
				if( item.Hovered ) {
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
			graphics.DrawString( item.Title , scheme.ItemCaptionFont , GetItemCaptionBrush( scheme ) , drawRectangle , GetItemCaptionStringFormat() );
		}
 
		public void Invalidate() {
			if( _backgroundTopBrush != null ) {
				_backgroundTopBrush.Dispose();
				_backgroundTopBrush = null;
			}
			if( _backgroundBottomBrush != null ) {
				_backgroundBottomBrush.Dispose();
				_backgroundBottomBrush = null;
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

		private LinearGradientBrush GetBackgroundTopBrush( Rectangle bounds , EmployeeGroupTabScheme scheme ) {
			if( _backgroundTopBrush == null ) {
				_backgroundTopBrush = new LinearGradientBrush( bounds , scheme.BackgroundColor1 , scheme.BackgroundColor2 , LinearGradientMode.Vertical );
			}
			return _backgroundTopBrush;
		}

		private LinearGradientBrush GetBackgroundBottomBrush( Rectangle bounds , EmployeeGroupTabScheme scheme ) {
			if( _backgroundBottomBrush == null ) {
				_backgroundBottomBrush = new LinearGradientBrush( bounds , scheme.BackgroundColor3 , scheme.BackgroundColor4 , LinearGradientMode.Vertical );
			}
			return _backgroundBottomBrush;
		}

		private StringFormat GetItemCaptionStringFormat() {
			if( _itemCaptionStringFormat == null ) {
				_itemCaptionStringFormat = new StringFormat() { Alignment = StringAlignment.Center , LineAlignment = StringAlignment.Center };
			}
			return _itemCaptionStringFormat;
		}

		private SolidBrush GetItemCaptionBrush(EmployeeGroupTabScheme scheme ) {
			if( _itemCaptionBrush == null ) {
				_itemCaptionBrush = new SolidBrush( scheme.ItemCaptionColor );
			}
			return _itemCaptionBrush;
		}

		private Pen GetItemOuterBorderPen( EmployeeGroupTabScheme scheme ) {
			if( _itemOuterBorderPen == null ) {
				_itemOuterBorderPen = new Pen( scheme.ItemOuterBorderColor );
			}
			return _itemOuterBorderPen;
		}

		private Pen GetItemInnerBorderPen( EmployeeGroupTabScheme scheme ) {
			if( _itemInnerBorderPen == null ) {
				_itemInnerBorderPen = new Pen( scheme.ItemInnerBorderColor );
			}
			return _itemInnerBorderPen;
		}

		private LinearGradientBrush GetItemGlowBrush( Rectangle bounds , EmployeeGroupTabScheme scheme ) {
			if( _itemGlowBrush == null ) {
				_itemGlowBrush = new LinearGradientBrush( bounds , scheme.ItemGlowColor , Color.Transparent , LinearGradientMode.Vertical );
			}
			return _itemGlowBrush;
		}

		private Pen GetItemOuterBorderPenSelected( EmployeeGroupTabScheme scheme ) {
			if( _itemOuterBorderPenSelected == null ) {
				_itemOuterBorderPenSelected = new Pen( scheme.ItemOuterBorderColorSelected );
			}
			return _itemOuterBorderPenSelected;
		}

		private Pen GetItemInnerBorderPenSelected( EmployeeGroupTabScheme scheme ) {
			if( _itemInnerBorderPenSelected == null ) {
				_itemInnerBorderPenSelected = new Pen( scheme.ItemInnerBorderColorSelected );
			}
			return _itemInnerBorderPenSelected;
		}

		private LinearGradientBrush GetItemGlowBrushSelected( Rectangle bounds , EmployeeGroupTabScheme scheme ) {
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
