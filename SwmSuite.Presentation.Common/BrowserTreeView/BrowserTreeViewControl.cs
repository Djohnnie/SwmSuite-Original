using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SwmSuite.Presentation.Common.BrowserTreeView {
	
	public class BrowserTreeViewControl : TreeView {

		#region -_ Construction _-

		public BrowserTreeViewControl() {
			InitializeComponent();
			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			//this.SetStyle( ControlStyles.UserPaint , true );
		}

		#endregion

		protected override void OnDrawNode( DrawTreeNodeEventArgs e ) {
			base.OnDrawNode( e );
		}

		private void InitializeComponent() {
			this.SuspendLayout();
			// 
			// BrowserTreeViewControl
			// 
			this.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler( this.BrowserTreeViewControl_DrawNode );
			this.ResumeLayout( false );

		}

		private void BrowserTreeViewControl_DrawNode( object sender , DrawTreeNodeEventArgs e ) {
			e.DrawDefault = true;
		}

		protected override void DefWndProc( ref Message m ) {
			if( m.Msg == 515 ) {
				// do nothing on WM_LBUTTONDBLCLK / &H203
			} else {
				base.DefWndProc( ref m );
			}
		}

	}
}
