using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SwmSuite.Presentation.Common.UserControls {
	
	public partial class WizardBottomPaneControl : ContainerControl {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		public Color FillColor1 { get; set; }
		public Color FillColor2 { get; set; }

		#endregion

		#region -_ Construction _-

		public WizardBottomPaneControl() {
			InitializeComponent();
			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );

			FillColor1 = Color.FromArgb( 240 , 240 , 240 );
			FillColor2 = Color.FromArgb( 220 , 220 , 220 );
		}

		#endregion

		private void WizardBottomPaneControl_Paint( object sender , PaintEventArgs e ) {
			LinearGradientBrush backgroundFillBrush = new LinearGradientBrush( this.ClientRectangle , this.FillColor1 , this.FillColor2 , LinearGradientMode.Vertical );
			e.Graphics.FillRectangle( backgroundFillBrush , this.ClientRectangle );
			backgroundFillBrush.Dispose();

		}

	}

}
