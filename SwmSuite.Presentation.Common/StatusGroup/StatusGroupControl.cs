using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace SwmSuite.Presentation.Common.StatusGroup {

	[Designer( typeof( ParentControlDesigner ) )]
	public partial class StatusGroupControl : UserControl {

		#region -_ Private Members _-

		private StatusGroupStatus _status;

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the scheme.
		/// </summary>
		/// <value>The scheme.</value>
		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public StatusGroupScheme Scheme { get; set; }

		/// <summary>
		/// Gets or sets the renderer.
		/// </summary>
		/// <value>The renderer.</value>
		public StatusGroupRenderer Renderer { get; set; }

		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		/// <value>The status.</value>
		public StatusGroupStatus Status {
			get {
				return _status;
			}
			set {
				_status = value;
				Invalidate();
			}
		}

		#endregion

		#region -_ Contruction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="StatusGroupControl"/> class.
		/// </summary>
		public StatusGroupControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );

			this.Scheme = new StatusGroupScheme();
			this.Renderer = new StatusGroupRenderer();
			this.Status = StatusGroupStatus.Good;
		}

		#endregion

		/// <summary>
		/// Handles the Paint event of the StatusGroupControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
		private void StatusGroupControl_Paint( object sender , PaintEventArgs e ) {
			Rectangle realClientRectangle = new Rectangle( this.ClientRectangle.Left , this.ClientRectangle.Top , this.ClientRectangle.Width - 1 , this.ClientRectangle.Height - 1 );
			this.Renderer.Render( e.Graphics , realClientRectangle , this.Status , this.Scheme );
		}

		/// <summary>
		/// Handles the Resize event of the StatusGroupControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void StatusGroupControl_Resize( object sender , EventArgs e ) {
			this.Renderer.Invalidate();
			this.Invalidate();
		}

	}

}
