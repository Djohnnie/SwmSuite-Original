using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SwmSuite.Presentation.Common.UserControls {
	
	public partial class CircularProgressControl : UserControl {

		#region -_ Private Members _-

		private GraphicsPath[] _segmentPaths = new GraphicsPath[12];
		private Rectangle _innerRect;

		private int _transitionSegment;
		private bool _behindIsActive = false;

		#endregion

		#region -_ Public Properties _-

		public Color InactiveSegmentColour { get; set; }

		public Color ActiveSegmentColour { get; set; }

		public Color TransistionSegmentColour { get; set; }

		#endregion

		#region -_ Construction _-

		public CircularProgressControl() {
			InitializeComponent();
			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );
			CalculateSegments();
			this.InactiveSegmentColour = Color.FromArgb(218, 218, 218);
			this.ActiveSegmentColour = Color.FromArgb(35, 146, 33);
			this.TransistionSegmentColour = Color.FromArgb(129, 242, 121);
		}

		#endregion

		#region -_ Private Methods _-

		private void CalculateSegments() {
			Rectangle outerRect = new Rectangle( 0 , 0 , this.ClientRectangle.Width , this.ClientRectangle.Height );
			_innerRect = new Rectangle( ( ( this.ClientRectangle.Width * 7 ) / 30 ) ,
												( ( this.ClientRectangle.Height * 7 ) / 30 ) ,
												( this.ClientRectangle.Width - ( ( this.ClientRectangle.Width * 14 ) / 30 ) ) ,
												( this.ClientRectangle.Height - ( ( this.ClientRectangle.Height * 14 ) / 30 ) ) );
			// Create 12 segment pieces.
			for( int i = 0 ; i < 12 ; i++ ) {
				_segmentPaths[i] = new GraphicsPath();

				// We subtract 90 so that the starting segment is at 12 o'clock.
				_segmentPaths[i].AddPie( outerRect , ( i * 30 ) - 90 , 25 );
			}
		}

		#endregion

		private void CircularProgressControl_Paint( object sender , PaintEventArgs e ) {
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			//e.Graphics.ExcludeClip( _innerBackgroundRegion );

			for( int i = 0 ; i < 12 ; i++ ) {
				if( this.Enabled ) {
					if( i == _transitionSegment ) {
						// If this segment is the transistion segment, colour it differently
						e.Graphics.FillPath( new SolidBrush( this.TransistionSegmentColour ) , _segmentPaths[i] );
					} else if( i < _transitionSegment ) {
						// This segment is behind the transistion segment
						if( _behindIsActive ) {
							// If behind the transistion should be active, 
							// colour it with the active colour
							e.Graphics.FillPath( new SolidBrush( this.ActiveSegmentColour ) , _segmentPaths[i] );
						} else {
							// If behind the transistion should be in-active, 
							// colour it with the in-active colour
							e.Graphics.FillPath( new SolidBrush( this.InactiveSegmentColour ) , _segmentPaths[i] );
						}
					} else {
						// This segment is ahead of the transistion segment
						if( _behindIsActive ) {
							// If behind the the transistion should be active, 
							// colour it with the in-active colour
							e.Graphics.FillPath( new SolidBrush( this.InactiveSegmentColour ) , _segmentPaths[i] );
						} else {
							// If behind the the transistion should be in-active, 
							// colour it with the active colour
							e.Graphics.FillPath( new SolidBrush( this.ActiveSegmentColour ) , _segmentPaths[i] );
						}
					}
				} else {
					// Draw all segments in in-active colour if not enabled
					e.Graphics.FillPath( new SolidBrush( this.InactiveSegmentColour ) , _segmentPaths[i] );
				}
			}
			e.Graphics.FillEllipse( Brushes.White , _innerRect );
			e.Graphics.SmoothingMode = SmoothingMode.Default;
		}

		private void CircularProgressControl_Resize( object sender , EventArgs e ) {
			CalculateSegments();
		}

		private void animationTimer_Tick( object sender , EventArgs e ) {
			_transitionSegment++;
			if( _transitionSegment > 11 ) {
				_transitionSegment = 0;
				_behindIsActive = !( _behindIsActive ); 
			}
			Invalidate();
		}

	}
}
