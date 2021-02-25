using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwmSuite.Presentation.Common.AnalogClock {

	public partial class NiceAnalogClockControl : UserControl {

		#region -_ Private Members _-

		private NiceAnalogClockRenderer _renderer = new NiceAnalogClockRenderer();
		private NiceAnalogClockScheme _scheme = new NiceAnalogClockScheme();

		#endregion

		#region -_ Public Properties _-

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public NiceAnalogClockScheme Scheme {
			get {
				return _scheme;
			}
			set {
				_scheme = value;
			}
		}

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public NiceAnalogClockRenderer Renderer {
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
		/// Default constructor.
		/// </summary>
		public NiceAnalogClockControl() {
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
		/// Handles the Paint event of the NiceAnalogClockControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
		private void NiceAnalogClockControl_Paint( object sender , PaintEventArgs e ) {
			Rectangle correctedClientRectangle = new Rectangle(
				this.ClientRectangle.Left , this.ClientRectangle.Top , this.ClientRectangle.Width - 1 , this.ClientRectangle.Height - 1 );
			this.Renderer.Render( e.Graphics , correctedClientRectangle , this.Scheme );
		}

		/// <summary>
		/// Handles the Resize event of the NiceAnalogClockControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void NiceAnalogClockControl_Resize( object sender , EventArgs e ) {
			this.Renderer.Invalidate();
			this.Invalidate();
		}
	}
}
