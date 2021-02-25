using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace SwmSuite.Presentation.Common.Status {
	
	public partial class StatusControl : UserControl {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public StatusScheme Scheme { get; set; }

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public StatusRenderer Renderer { get; set; }

		public String LeftCaption { get; set; }

		public String MiddleCaption { get; set; }

		public String RightCaption { get; set; }

		#endregion

		#region -_ Construction _-

		public StatusControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );

			this.Renderer = new StatusRenderer();
			this.Scheme = new StatusScheme();
			this.Scheme.NeedsRedraw += new EventHandler<EventArgs>( Scheme_NeedsRedraw );
		}

		void Scheme_NeedsRedraw( object sender , EventArgs e ) {
			this.Renderer.Invalidate();
			this.Invalidate();
		}

		#endregion



		private void StatusControl_Paint( object sender , PaintEventArgs e ) {
			this.Renderer.RenderBackground( e.Graphics , this.ClientRectangle , this.Scheme );
			this.Renderer.RenderText( e.Graphics , this.ClientRectangle , this.LeftCaption , this.MiddleCaption , this.RightCaption , this.Scheme );
		}

		private void StatusControl_SizeChanged( object sender , EventArgs e ) {
			this.Renderer.Invalidate();
			this.Invalidate();
		}
	}
}
