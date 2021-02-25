using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace SwmSuite.Presentation.Common.BrowserView {

	public class BrowserViewControl : ListView {

		#region -_ Private Members _-

		private BrowserViewScheme _scheme = new BrowserViewScheme();
		private BrowserViewRenderer _renderer = new BrowserViewRenderer();

		private Dictionary<ListViewItem , bool> _listViewItemHoveredDictionary = new Dictionary<ListViewItem , bool>();

		#endregion

		#region -_ Public Properties _-

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public BrowserViewScheme Scheme {
			get {
				return _scheme;
			}
			set {
				_scheme = value;
			}
		}

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public BrowserViewRenderer Renderer {
			get {
				return _renderer;
			}
			set {
				_renderer = value;
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="BrowserViewControl"/> class.
		/// </summary>
		public BrowserViewControl() {
			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			//this.SetStyle( ControlStyles.UserPaint , true );
			this.OwnerDraw = true;
		}

		#endregion

		private void CheckListViewItems() {
			if( _listViewItemHoveredDictionary.Count != this.Items.Count ) {
				_listViewItemHoveredDictionary.Clear();
				foreach( ListViewItem lvi in this.Items ) {
					_listViewItemHoveredDictionary.Add( lvi , false );
				}
			} else {
				foreach( ListViewItem lvi in this.Items ) {
					if( !_listViewItemHoveredDictionary.Keys.Contains( lvi ) ) {
						_listViewItemHoveredDictionary.Clear();
						CheckListViewItems();
					}
				}
			}
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.ListView.DrawItem"/> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.DrawListViewItemEventArgs"/> that contains the event data.</param>
		protected override void OnDrawItem( DrawListViewItemEventArgs e ) {
			//if( e.Item.Tag != null ) {
			//    if( (bool)e.Item.Tag ) {
			//        e.Graphics.FillRectangle( Brushes.Red , e.Bounds );
			//        e.DrawText( TextFormatFlags.VerticalCenter );
			//        e.Item.Tag = null;
			//    }
			//} else {
			//    if( e.ItemIndex % 2 == 0 ) {
			//        e.Graphics.FillRectangle( Brushes.WhiteSmoke , e.Bounds );
			//        e.DrawText( TextFormatFlags.VerticalCenter );
			//    } else {
			//        e.Graphics.FillRectangle( Brushes.White , e.Bounds );
			//        e.DrawText( TextFormatFlags.VerticalCenter );
			//    }
			//}
			//e.DrawDefault = false;
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.ListView.DrawColumnHeader"/> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.DrawListViewColumnHeaderEventArgs"/> that contains the event data.</param>
		protected override void OnDrawColumnHeader( DrawListViewColumnHeaderEventArgs e ) {
			this.Renderer.DrawColumnHeader( e.Graphics , e.Bounds , e.Header.Text , this.Scheme );
			e.DrawDefault = false;
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.ListView.DrawSubItem"/> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.DrawListViewSubItemEventArgs"/> that contains the event data.</param>
		protected override void OnDrawSubItem( DrawListViewSubItemEventArgs e ) {
			CheckListViewItems();
			if( e.Item.Selected ) {
				this.Renderer.DrawRowSelected( e.Graphics , e.Bounds , e.SubItem.Text , this.Scheme );
			} else {
				if( _listViewItemHoveredDictionary[e.Item] ) {
					this.Renderer.DrawRowHovered( e.Graphics , e.Bounds , e.SubItem.Text , this.Scheme );
				} else {
					if( e.SubItem.Tag != null ) {
						this.Renderer.DrawRowNormal( e.Graphics , e.Bounds , e.SubItem.Text , this.Scheme , e.ItemIndex % 2 == 0 , e.SubItem.BackColor , (Color)e.SubItem.Tag );
					} else {
						this.Renderer.DrawRowNormal( e.Graphics , e.Bounds , e.SubItem.Text , this.Scheme , e.ItemIndex % 2 == 0 );
					}
				}
				//if( e.Item.Tag != null ) {
				//    if( (bool)e.Item.Tag ) {
				//        this.Renderer.DrawRowHovered( e.Graphics , e.Bounds , e.SubItem.Text , this.Scheme );
				//    }
				//} else {
				//    this.Renderer.DrawRowNormal( e.Graphics , e.Bounds , e.SubItem.Text , this.Scheme , e.ItemIndex % 2 == 0 );
				//}
			}
			if( e.ColumnIndex == 0 ) {
				if( e.Item.ImageList != null ) {
					Image imageToDraw = e.Item.ImageList.Images[e.Item.ImageIndex];
					if( imageToDraw != null ) {
						e.Graphics.DrawImage( imageToDraw , e.Bounds.Left + e.Bounds.Width / 2 - imageToDraw.Width / 2 , e.Bounds.Top + e.Bounds.Height / 2 - imageToDraw.Height / 2 );
					}
				}
			}
			e.DrawDefault = false;
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove"/> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
		protected override void OnMouseMove( MouseEventArgs e ) {
			CheckListViewItems();

			ListViewHitTestInfo hitTestInfo = this.HitTest( e.X , e.Y );
			foreach( ListViewItem lvi in this.Items ) {
				if( _listViewItemHoveredDictionary[lvi] ) {
					_listViewItemHoveredDictionary[lvi] = false;
					this.Invalidate( lvi.Bounds );
				}

				//if( lvi.Tag != null ) {
				//    if( (bool)lvi.Tag ) {
				//        lvi.Tag = null;
				//        this.Invalidate( lvi.Bounds );
				//    }
				//}
			}
			if( hitTestInfo.SubItem != null ) {
				_listViewItemHoveredDictionary[hitTestInfo.Item] = true;
				this.Invalidate( hitTestInfo.Item.Bounds );
			}

			//if( hitTestInfo.SubItem != null ) {
			//    hitTestInfo.Item.Tag = true;
			//    Invalidate( hitTestInfo.Item.Bounds );
			//}
		}

		/// <summary>
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
		protected override void OnMouseLeave( EventArgs e ) {
			foreach( ListViewItem lvi in this.Items ) {
				if( _listViewItemHoveredDictionary.ContainsKey( lvi ) ) {
					if( _listViewItemHoveredDictionary[lvi] ) {
						_listViewItemHoveredDictionary[lvi] = false;
						this.Invalidate( lvi.Bounds );
					}
				}
				//if( lvi.Tag != null ) {
				//    if( (bool)lvi.Tag ) {
				//        lvi.Tag = null;
				//        this.Invalidate( lvi.Bounds );
				//    }
				//}
			}
		}

		/// <summary>
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
		protected override void OnResize( EventArgs e ) {
			// resize the columns to fit the total width.
			float[] columnWidth = new float[this.Columns.Count];
			int totalColumnWidth = 0;
			foreach( ColumnHeader column in this.Columns ) {
				totalColumnWidth += column.Width;
			}
			foreach( ColumnHeader column in this.Columns ) {
				columnWidth[this.Columns.IndexOf( column )] = (float)column.Width / (float)totalColumnWidth;
			}
			foreach( ColumnHeader column in this.Columns ) {
				int newColumnWidth = (int)( columnWidth[this.Columns.IndexOf( column )] * (float)this.ClientRectangle.Width );
				//if( column.Name.Equals( "iconColumnHeader" ) ) {
				if( String.IsNullOrEmpty( column.Text ) ) {
					newColumnWidth = 20;
				}
				if( newColumnWidth > 1 ) {
					column.Width = newColumnWidth;
				} else {
					column.Width = 2;
				}
			}
		}

	}

}
