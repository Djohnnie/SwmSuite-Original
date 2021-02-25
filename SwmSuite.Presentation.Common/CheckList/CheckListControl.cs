using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwmSuite.Presentation.Common.CheckList {

	/// <summary>
	/// Usercontrol defining a checklist.
	/// </summary>
	public partial class CheckListControl : UserControl {

		#region -_ Private Members _-

		private CheckListRenderer _renderer = new CheckListRenderer();
		private CheckListScheme _scheme = new CheckListScheme();
		private CheckListItemCollection _items = new CheckListItemCollection();

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the scheme.
		/// </summary>
		/// <value>The scheme.</value>
		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public CheckListScheme Scheme {
			get {
				return _scheme;
			}
			set {
				_scheme = value;
			}
		}

		/// <summary>
		/// Gets or sets the renderer.
		/// </summary>
		/// <value>The renderer.</value>
		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public CheckListRenderer Renderer {
			get {
				return _renderer;
			}
			set {
				_renderer = value;
			}
		}

		/// <summary>
		/// Gets or sets the items.
		/// </summary>
		/// <value>The items.</value>
		[DesignerSerializationVisibility( DesignerSerializationVisibility.Content )]
		public CheckListItemCollection Items {
			get {
				return _items;
			}
			set {
				_items = value;
			}
		}

		#endregion

		#region -_ Public Events _-

		/// <summary>
		/// Occurs when the check list selection has changed.
		/// </summary>
		public event EventHandler<EventArgs> CheckListSelectionChanged;

		/// <summary>
		/// Raises the check list selection changed event.
		/// </summary>
		private void RaiseCheckListSelectionChanged() {
			if( this.CheckListSelectionChanged != null ) {
				CheckListSelectionChanged( this , EventArgs.Empty );
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="CheckListControl"/> class.
		/// </summary>
		public CheckListControl() {
			InitializeComponent();
			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );
			this.BackColor = Color.Transparent;
		}

		#endregion

		/// <summary>
		/// Handles the Paint event of the CheckListControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
		private void CheckListControl_Paint( object sender , PaintEventArgs e ) {
			this.Renderer.RenderBackground( e.Graphics , this.ClientRectangle , this.Scheme );

			if( Items.Count > 0 ) {
				int itemWidth = ( this.ClientRectangle.Width - 6 ) / this.Items.Count;
				foreach( CheckListItem item in this.Items ) {
					Rectangle itemRectangle = new Rectangle( this.ClientRectangle.Left + 3 + this.Items.IndexOf( item ) * itemWidth , this.ClientRectangle.Top + 3 , itemWidth , this.ClientRectangle.Height - 6 );
					this.Renderer.RenderItem( e.Graphics , itemRectangle , this.Scheme , item );
				}
			}
		}

		/// <summary>
		/// Handles the SizeChanged event of the CheckListControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void CheckListControl_SizeChanged( object sender , EventArgs e ) {

		}

		/// <summary>
		/// Handles the MouseDown event of the CheckListControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
		private void CheckListControl_MouseDown( object sender , MouseEventArgs e ) {
			if( Items.Count > 0 ) {
				int itemWidth = ( this.ClientRectangle.Width - 6 ) / this.Items.Count;
				foreach( CheckListItem item in this.Items ) {
					Rectangle itemRectangle = new Rectangle( this.ClientRectangle.Left + 3 + this.Items.IndexOf( item ) * itemWidth , this.ClientRectangle.Top + 3 , itemWidth , this.ClientRectangle.Height - 6 );
					if( itemRectangle.Contains( e.Location ) ) {
						item.Checked = !item.Checked;
						RaiseCheckListSelectionChanged();
					}
				}
				this.Invalidate();
			}
		}

	}

}
