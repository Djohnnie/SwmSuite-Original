using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace SwmSuite.Presentation.Common.Clock {
	
	public partial class ClockControl : UserControl {

		#region -_ Private Members _-

		private ClockScheme _scheme = new ClockScheme();
		private ClockRenderer _renderer = new ClockRenderer();

		#endregion

		#region -_ Public Properties _-

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public ClockScheme Scheme {
			get {
				return _scheme;
			}
			set {
				_scheme = value;
			}
		}

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public ClockRenderer Renderer {
			get {
				return _renderer;
			}
			set {
				_renderer = value;
			}
		}

		#endregion

		#region -_ Construction _-

		public ClockControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );
			this.BackColor = Color.Transparent;
		}

		#endregion

		#region -_ Event Handlers _-

		private void ClockControl_Paint( object sender , PaintEventArgs e ) {
			this.Renderer.DrawTimeAndDate( e.Graphics , this.ClientRectangle , DateTime.Now.ToShortTimeString() , DateTime.Now.ToLongDateString() , this.Scheme );
		}

		#endregion

		private void clockTimer_Tick( object sender , EventArgs e ) {
			this.Invalidate();
		}

	}

}
