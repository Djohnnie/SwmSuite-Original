using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace SwmSuite.Presentation.Common.EmployeeGroupTab {
	
	public partial class EmployeeGroupTabControl : UserControl {

		#region -_ Private Members _-

		private EmployeeGroupTabRenderer _renderer = new EmployeeGroupTabRenderer();
		private EmployeeGroupTabScheme _scheme = new EmployeeGroupTabScheme();
		private Collection<EmployeeGroupTabItem> _items = new Collection<EmployeeGroupTabItem>();

		#endregion

		#region -_ Public Properties _-

		public event EventHandler<EmployeeGroupTabSelectionEventArgs> SelectionChanged;

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public EmployeeGroupTabScheme Scheme {
			get {
				return _scheme;
			}
			set {
				_scheme = value;
			}
		}

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public EmployeeGroupTabRenderer Renderer {
			get {
				return _renderer;
			}
			set {
				_renderer = value;
			}
		}

		[DesignerSerializationVisibility( DesignerSerializationVisibility.Content )]
		public Collection<EmployeeGroupTabItem> Items {
			get {
				return _items;
			}
			set {
				_items = value;
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public EmployeeGroupTabControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );
			this.BackColor = Color.Transparent;
		}

		#endregion

		private void EmployeeGroupTabControl_Paint( object sender , PaintEventArgs e ) {
			this.Renderer.RenderBackground( e.Graphics , this.ClientRectangle , this.Scheme );

			if( Items.Count > 0 ) {
				int itemWidth = ( this.ClientRectangle.Width - 20 ) / this.Items.Count;
				foreach( EmployeeGroupTabItem item in this.Items ) {
					Rectangle itemRectangle = new Rectangle( this.ClientRectangle.Left + 10 + this.Items.IndexOf( item ) * itemWidth , this.ClientRectangle.Top + 5 , itemWidth , this.ClientRectangle.Height - 10 );
					this.Renderer.RenderItem( e.Graphics , itemRectangle , this.Scheme , item );
				}
			}
		}

		private void EmployeeGroupTabControl_SizeChanged( object sender , EventArgs e ) {
			this.Renderer.Invalidate();
			this.Invalidate();
		}

		private void EmployeeGroupTabControl_MouseMove( object sender , MouseEventArgs e ) {
			if( Items.Count > 0 ) {
				int itemWidth = ( this.ClientRectangle.Width - 20 ) / this.Items.Count;
				foreach( EmployeeGroupTabItem item in this.Items ) {
					Rectangle itemRectangle = new Rectangle( this.ClientRectangle.Left + 10 + this.Items.IndexOf( item ) * itemWidth , this.ClientRectangle.Top + 5 , itemWidth , this.ClientRectangle.Height - 10 );
					if( itemRectangle.Contains( e.Location ) && !item.Hovered && !item.Selected ) {
						item.Hovered = true;
						this.Renderer.Invalidate();
						this.Invalidate();
					} else {
						item.Hovered = false;
					}
				}
			}
		}

		private void EmployeeGroupTabControl_MouseLeave( object sender , EventArgs e ) {
			foreach( EmployeeGroupTabItem item in this.Items ) {
				item.Hovered = false;
			}
			this.Renderer.Invalidate();
				this.Invalidate();
		}

		private void EmployeeGroupTabControl_MouseDown( object sender , MouseEventArgs e ) {
			if( Items.Count > 0 ) {
				int itemWidth = ( this.ClientRectangle.Width - 20 ) / this.Items.Count;
				foreach( EmployeeGroupTabItem item in this.Items ) {
					Rectangle itemRectangle = new Rectangle( this.ClientRectangle.Left + 10 + this.Items.IndexOf( item ) * itemWidth , this.ClientRectangle.Top + 5 , itemWidth , this.ClientRectangle.Height - 10 );
					if( itemRectangle.Contains( e.Location ) ) {
						item.Selected = true;
						RaiseSelectionChanged( item );
						this.Renderer.Invalidate();
						this.Invalidate();
					} else {
						item.Selected = false;
					}
				}
			}
		}

		private void RaiseSelectionChanged( EmployeeGroupTabItem item ) {
			if( this.SelectionChanged != null ) {
				SelectionChanged( this , new EmployeeGroupTabSelectionEventArgs( item ) );
			}
		}

	}

}
