using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace SwmSuite.Presentation.Common.AnalogClock {
	
	public partial class AnalogClockControl : UserControl {

		#region -_ Private Members _-

		private AnalogClockRenderer _renderer = new AnalogClockRenderer();
		private AnalogClockScheme _scheme = new AnalogClockScheme();

		private bool _countDown;
		private int _countDownStart;
		private int _countDownLenght;

		#endregion

		#region -_ Public Properties _-

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public AnalogClockScheme Scheme {
			get {
				return _scheme;
			}
			set {
				_scheme = value;
			}
		}

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public AnalogClockRenderer Renderer {
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
		public AnalogClockControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );
			this.BackColor = Color.Transparent;
		}

		#endregion

		#region -_ Control EventHandlers _-

		/// <summary>
		/// Handles the Paint event of the AnalogClockControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
		private void AnalogClockControl_Paint( object sender , PaintEventArgs e ) {
			Rectangle realRectangle = new Rectangle( this.ClientRectangle.Left+1 , this.ClientRectangle.Top+1 , this.ClientRectangle.Width - 3 , this.ClientRectangle.Height - 3 );
			if( _countDown ) {
				this.Renderer.RenderCountDown( e.Graphics , realRectangle , _countDownStart , _countDownLenght , this.Scheme );
			}
			this.Renderer.Render( e.Graphics , realRectangle , DateTime.Now , this.Scheme );
		}

		/// <summary>
		/// Handles the SizeChanged event of the AnalogClockControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void AnalogClockControl_SizeChanged( object sender , EventArgs e ) {
			this.Renderer.Invalidate();
			this.Invalidate();
		}

		/// <summary>
		/// Handles the Tick event of the timer control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void timer_Tick( object sender , EventArgs e ) {
			this.Invalidate();
		}

		#endregion

		#region -_ Public Methods _-

		public void SetCountDown( int start , int length ) {
			if( length > 0 ) {
				_countDown = true;
				_countDownStart = start;
				_countDownLenght = length;
			} else {
				_countDown = false;
				_countDownStart = 0;
				_countDownLenght = 0;
			}
			this.Invalidate();
		}

		#endregion

	}

}
