using System;
using System.Collections.Generic;

using System.Text;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace SwmSuite.Presentation.Common.ModuleWindow {

	public class ModuleWindowRenderer {

		#region -_ Private Members _-

		private ModuleWindowColorScheme _colorScheme;

		private int _topPaneHeight = 100;
		private int _bottomPaneHeight = 50;
		private int _leftPaneWidth = 250;

		#endregion

		#region -_ Public Properties _-

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public ModuleWindowColorScheme ColorScheme {
			get {
				return _colorScheme;
			}
			set {
				_colorScheme = value;
			}
		}

		public int TopPaneHeight { get { return _topPaneHeight; } set { _topPaneHeight = value; } }
		public int BottomPaneHeight { get { return _bottomPaneHeight; } set { _bottomPaneHeight = value; } }
		public int LeftPaneWidth { get { return _leftPaneWidth; } set { _leftPaneWidth = value; } }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ModuleWindowRenderer() {
			this.ColorScheme = new ModuleWindowColorScheme( Color.FromArgb( 96 , 138 , 193 ) , Color.FromArgb( 101 , 145 , 204 ) , Color.FromArgb( 96 , 138 , 193 ) , Color.FromArgb( 101 , 145 , 204 ) , Color.FromArgb( 255 , 245 , 200 ) , Color.FromArgb( 255 , 212 , 84 ) );
		}

		#endregion

		#region -_ Public Methods _-

		public void Render( Graphics graphics , Rectangle drawRect ) {
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			Rectangle leftPaneRect = new Rectangle( drawRect.Left , drawRect.Top , this.LeftPaneWidth , drawRect.Height );
			Rectangle topPaneRect = new Rectangle( drawRect.Left , drawRect.Top , drawRect.Width , this.TopPaneHeight );
			Rectangle bottomPaneRect = new Rectangle( drawRect.Left , drawRect.Bottom - this.BottomPaneHeight , drawRect.Width , this.BottomPaneHeight );
			
			RenderLeftPane( graphics , leftPaneRect );
			RenderTopPane( graphics , topPaneRect );
			RenderBottomPane( graphics , bottomPaneRect );
			graphics.SmoothingMode = SmoothingMode.Default;
		}

		#endregion

		#region -_ Private Methods _-

		private void RenderTopPane( Graphics g , Rectangle drawRect ) {
			// Draw an arc from bottom-left to mid-mid to bottom-right.
			// We should calculate the circle through these 3 points
			// and only use the arc from the first point to the third point.
			Point firstPoint = new Point( drawRect.Left , drawRect.Bottom );
			Point secondPoint = new Point( drawRect.Left + drawRect.Width / 2 , drawRect.Top + (int)((float)drawRect.Height / 6.0f * 5.0f) );
			Point thirdPoint = new Point( drawRect.Right , drawRect.Bottom );

			GraphicsPath path = GetTopArcPath( ref drawRect , ref firstPoint , ref secondPoint , ref thirdPoint );

			LinearGradientBrush fillBrush = new LinearGradientBrush( drawRect , Color.FromArgb( 221 , 234 , 252 ) , Color.FromArgb( 107 , 144 , 192 ) , LinearGradientMode.ForwardDiagonal );
			fillBrush.WrapMode = WrapMode.TileFlipXY;
			g.FillPath( fillBrush , path );

			fillBrush.Dispose();
			path.Dispose();
		}

		private void RenderLeftPane( Graphics g , Rectangle drawRect ) {
			LinearGradientBrush fillBrush = new LinearGradientBrush( drawRect , this.ColorScheme.LeftPanelFlood1Color , this.ColorScheme.LeftPanelFlood2Color , LinearGradientMode.ForwardDiagonal );
			g.FillRectangle( fillBrush , drawRect );
			fillBrush.Dispose();			
		}

		private void RenderBottomPane( Graphics g , Rectangle drawRect ) {
			// Draw an arc from top-left to mid-mid to top-right.
			// We should calculate the circle through these 3 points
			// and only use the arc from the first point to the third point.
			Point firstPoint = new Point( drawRect.Left , drawRect.Top );
			Point secondPoint = new Point( drawRect.Left + drawRect.Width / 2 , drawRect.Top + drawRect.Height / 2 );
			Point thirdPoint = new Point( drawRect.Left + drawRect.Width , drawRect.Top );

			GraphicsPath path = GetBottomArcPath( ref drawRect , ref firstPoint , ref secondPoint , ref thirdPoint );

			LinearGradientBrush fillBrush = new LinearGradientBrush( drawRect , Color.FromArgb( 221 , 234 , 252 ) , Color.FromArgb( 107 , 144 , 192 ) , LinearGradientMode.ForwardDiagonal );
			fillBrush.WrapMode = WrapMode.TileFlipXY;
			g.FillPath( fillBrush , path );

			fillBrush.Dispose();
			path.Dispose();

			Rectangle textRect = new Rectangle( drawRect.Left + 5 , drawRect.Bottom - 25 , drawRect.Width - 10 , 20 );
			Rectangle textRectShadow = new Rectangle( drawRect.Left + 4 , drawRect.Bottom - 24 , drawRect.Width - 10 , 20 );
			Font textFont = new Font( "Verdana" , 10.0f , FontStyle.Italic );
			StringFormat leftFormat = new StringFormat() { Alignment = StringAlignment.Near , LineAlignment = StringAlignment.Center };
			StringFormat rightFormat = new StringFormat() { Alignment = StringAlignment.Far , LineAlignment = StringAlignment.Center };
			g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			g.DrawString( "Ingelogde gebruiker: Johnny" , textFont , Brushes.Gainsboro , textRectShadow , leftFormat );
			g.DrawString( "Simple Workfloor Management Suite v0.1.0.1000" , textFont , Brushes.Gainsboro , textRectShadow , rightFormat );
			g.DrawString( "Ingelogde gebruiker: Johnny" , textFont , Brushes.Black , textRect , leftFormat );
			g.DrawString( "Simple Workfloor Management Suite v0.1.0.1000" , textFont , Brushes.Black , textRect , rightFormat );
			g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			leftFormat.Dispose();
			leftFormat.Dispose();
			textFont.Dispose();
		}

		private GraphicsPath GetTopArcPath( ref Rectangle drawRect , ref Point firstPoint , ref Point secondPoint , ref Point thirdPoint ) {
			Point centerPoint;
			int radius = CalculateCircle( new Point[] { firstPoint , secondPoint , thirdPoint } , out centerPoint );

			Rectangle circleRect = new Rectangle( secondPoint.X - radius , secondPoint.Y , radius * 2 , radius * 2 );

			// Calculate the angle between the line from the center to first point
			// and the line from the center to the second point.
			double leg1 = (double)secondPoint.X - (double)firstPoint.X;
			double leg2 = (double)secondPoint.Y - (double)centerPoint.Y;
			double hypotenuse = Math.Sqrt( leg1 * leg1 + leg2 * leg2 );
			double angle = Math.Sinh( leg1 / hypotenuse ) * 180 / Math.PI;
			angle += 1.0f;
			double startingAngle = 270 + angle;
			double sweepAngle = -angle * 2.0f;

			GraphicsPath path = new GraphicsPath();
			path.AddArc( circleRect , (float)startingAngle , (float)sweepAngle );
			path.AddLine( drawRect.Left , drawRect.Top , drawRect.Right , drawRect.Top );
			path.CloseAllFigures();
			//path.AddEllipse( circleRect );
			return path;
		}

		private GraphicsPath GetBottomArcPath( ref Rectangle drawRect , ref Point firstPoint , ref Point secondPoint , ref Point thirdPoint ) {
			Point centerPoint;
			int radius = CalculateCircle( new Point[] { firstPoint , secondPoint , thirdPoint } , out centerPoint );

			Rectangle circleRect = new Rectangle( secondPoint.X - radius , secondPoint.Y - radius * 2 , radius * 2 , radius * 2 );

			// Calculate the angle between the line from the center to first point
			// and the line from the center to the second point.
			double leg1 = (double)secondPoint.X - (double)firstPoint.X;
			double leg2 = (double)secondPoint.Y - (double)centerPoint.Y;
			double hypotenuse = Math.Sqrt( leg1 * leg1 + leg2 * leg2 );
			double angle = Math.Sinh( leg1 / hypotenuse ) * 180 / Math.PI;
			angle += 1.0f;
			double startingAngle = 90 - angle;
			double sweepAngle = angle * 2.0f;

			GraphicsPath path = new GraphicsPath();
			path.AddArc( circleRect , (float)startingAngle , (float)sweepAngle );
			path.AddLine( drawRect.Left , drawRect.Bottom , drawRect.Right , drawRect.Bottom );
			path.CloseAllFigures();
			return path;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="p1"></param>
		/// <param name="p2"></param>
		/// <param name="p3"></param>
		/// <returns></returns>
		/// <remarks>http://home.att.net/~srschmitt/circle3pts.html</remarks>
		private int CalculateCircle( Point[] p , out Point centerPoint ) {
			double[][] matrix = new double[3][];
			for( int i = 0 ; i < 3 ; i++ ) {
				matrix[i] = new double[3];
			}

			// find minor 11
			for( int i=0 ; i< 3 ; i++ ){
				matrix[i][0] = (double)p[i].X;
				matrix[i][1] = (double)p[i].Y;
				matrix[i][2] = 1.0f;
			}
			double minor11 = GetDeterminant( matrix );
			// find minor12
			for( int i=0 ; i<3 ; i++ ){
				matrix[i][0] = Math.Pow( (double)p[i].X , (double)2 ) + Math.Pow( (double)p[i].Y , (double)2);
				matrix[i][1] = (double)p[i].Y;
				matrix[i][2] = 1.0f;
			}
			double minor12 = GetDeterminant( matrix );
		// find minor 13
			for( int i = 0 ; i < 3 ; i++ ) {
				matrix[i][0] = Math.Pow( (double)p[i].X , (double)2 ) + Math.Pow( (double)p[i].Y , (double)2 );
				matrix[i][1] = (double)p[i].X;
				matrix[i][2] = 1.0f;
			}
			double minor13 = GetDeterminant( matrix );
			// find minor 14
			for( int i = 0 ; i < 3 ; i++ ) {
				matrix[i][0] = Math.Pow( (double)p[i].X , (double)2 ) + Math.Pow( (double)p[i].Y , (double)2 );
				matrix[i][1] = (double)p[i].X;
				matrix[i][2] = (double)p[i].Y;
			}
			double minor14 = GetDeterminant( matrix );

			if( minor11 == 0 ) {
				centerPoint = p[1];
				return 0;
			} else {
				PointF center = new PointF( 0.5f * (float)minor12 / (float)minor11 , -0.5f * (float)minor13 / (float)minor11 );
				centerPoint = new Point( (int)center.X , (int)center.Y );
				return (int)Math.Sqrt( center.X * center.X + center.Y * center.Y + minor14 / minor11 );
			}
		}

		private double GetDeterminant( double[][] matrix ) {
			// | a b c |
			// | d e f |
			// | g h i |
			// a(ei-hf) - d(bi-hc) + g(bf-ec)

			double a = matrix[0][0];
			double b = matrix[0][1];
			double c = matrix[0][2];
			double d = matrix[1][0];
			double e = matrix[1][1];
			double f = matrix[1][2];
			double g = matrix[2][0];
			double h = matrix[2][1];
			double i = matrix[2][2];

			return a * (e * i - h * f) - d * (b * i - h * c) + g * (b * f - e * c);
		}

//    %
//%  Calculate determinate using recursive 
//%  expansion by minors.
//%
//function det( var a : matrix, n : int ) : real

//    var i, j, j1, j2 : int
//    var d : real := 0
//    var m : matrix

//    assert n > 1

//    if n = 2 then
//        d := a[1,1]*a[2,2] - a[2,1]*a[1,2]
//    else 
//        d := 0
//        for j1 := 1...n do
//            % create minor
//            for i := 2...n do
//                j2 := 1
//                for j := 1...n do
//                    continue when j = j1
//                    m[i-1,j2] := a[i,j]
//                    incr j2
//                end for
//            end for
//            % calculate determinant
//            d := d + ( -1.0 )^(1 + j1 ) * a[1,j1] * det( m, n-1 )
//        end for
//    end if
    
//    return d

//end function


		#endregion

	}

}