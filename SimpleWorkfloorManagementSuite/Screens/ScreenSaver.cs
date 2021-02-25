using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace SimpleWorkfloorManagementSuite.Screens {
	public partial class ScreenSaver : UserControl {

		private int _color;
		private int _direction;
		
		public ScreenSaver() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );
		}

		/// <summary>
		/// Handles the Tick event of the timer control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void timer_Tick( object sender , EventArgs e ) {
			if( _direction == 0 ) {
				_color++;
				if( _color > 255 ) {
					_direction = 1;
					_color = 255;
				}
			} else {
				_color--;
				if( _color < 0 ) {
					_direction = 0;
					_color = 0;
				}
			}

			this.Invalidate();
		}

		/// <summary>
		/// Handles the Paint event of the ScreenSaver control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
		private void ScreenSaver_Paint( object sender , PaintEventArgs e ) {
			e.Graphics.Clear( Color.FromArgb( _color , _color , _color ) );
		}
	}
}
