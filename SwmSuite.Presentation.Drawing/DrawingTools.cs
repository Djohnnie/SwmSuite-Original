using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SwmSuite.Presentation.Drawing {
	
	public class DrawingTools {

		public static void DrawShadow( Graphics graphics , Rectangle bounds ) {
			// Initialize images.
			Image rightTopCorner = SwmSuite.Presentation.Drawing.Properties.Resources.shadow_corner;
			Image leftTopCorner = SwmSuite.Presentation.Drawing.Properties.Resources.shadow_corner;
			leftTopCorner.RotateFlip( RotateFlipType.Rotate270FlipNone );
			Image rightBottomCorner = SwmSuite.Presentation.Drawing.Properties.Resources.shadow_corner;
			rightBottomCorner.RotateFlip( RotateFlipType.Rotate90FlipNone );
			Image leftBottomCorner = SwmSuite.Presentation.Drawing.Properties.Resources.shadow_corner;
			leftBottomCorner.RotateFlip( RotateFlipType.Rotate180FlipNone );
			Image bottomSide = SwmSuite.Presentation.Drawing.Properties.Resources.shadow_side;
			Image topSide = SwmSuite.Presentation.Drawing.Properties.Resources.shadow_side;
			topSide.RotateFlip( RotateFlipType.Rotate180FlipNone );
			Image leftSide = SwmSuite.Presentation.Drawing.Properties.Resources.shadow_side;
			leftSide.RotateFlip( RotateFlipType.Rotate90FlipNone );
			Image rightSide = SwmSuite.Presentation.Drawing.Properties.Resources.shadow_side;
			rightSide.RotateFlip( RotateFlipType.Rotate270FlipNone );

			// calculate rectangles.
			Rectangle rightTopRectangle = new Rectangle( bounds.Right , bounds.Top - 10 , 10 , 10 );
			Rectangle leftTopRectangle = new Rectangle( bounds.Left - 10 , bounds.Top - 10 , 10 , 10 );
			Rectangle rightBottomRectangle = new Rectangle( bounds.Right , bounds.Bottom , 10 , 10 );
			Rectangle leftBottomRectangle = new Rectangle( bounds.Left - 10 , bounds.Bottom , 10 , 10 );
			Rectangle bottomRectangle = new Rectangle( bounds.Left , bounds.Bottom , bounds.Width , 10 );
			Rectangle topRectangle = new Rectangle( bounds.Left , bounds.Top - 10 , bounds.Width , 10 );
			Rectangle leftRectangle = new Rectangle( bounds.Left - 10 , bounds.Top , 10 , bounds.Height );
			Rectangle rightRectangle = new Rectangle( bounds.Right , bounds.Top , 10 , bounds.Height );

			// draw shadow.
			graphics.DrawImageUnscaled( rightTopCorner , rightTopRectangle );
			graphics.DrawImageUnscaled( leftTopCorner , leftTopRectangle );
			graphics.DrawImageUnscaled( rightBottomCorner , rightBottomRectangle );
			graphics.DrawImageUnscaled( leftBottomCorner , leftBottomRectangle );
			for( int i = bottomRectangle.Left ; i < bottomRectangle.Right ; i++ ) {
				graphics.DrawImageUnscaled( bottomSide , i , bottomRectangle.Top );
			}
			for( int i = topRectangle.Left ; i < topRectangle.Right ; i++ ) {
				graphics.DrawImageUnscaled( topSide , i , topRectangle.Top );
			}
			for( int i = leftRectangle.Top ; i < leftRectangle.Bottom ; i++ ) {
				graphics.DrawImageUnscaled( leftSide , leftRectangle.Left , i );
			}
			for( int i = rightRectangle.Top ; i < rightRectangle.Bottom ; i++ ) {
				graphics.DrawImageUnscaled( rightSide , rightRectangle.Left , i );
			}

			//graphics.FillRectangle( Brushes.Red , rightTopRectangle );


			// dispose images from memory.
			rightTopCorner.Dispose();
			leftTopCorner.Dispose();
			rightBottomCorner.Dispose();
			leftBottomCorner.Dispose();
			bottomSide.Dispose();
			topSide.Dispose();
			leftSide.Dispose();
			rightSide.Dispose();
		}

		/// <summary>
		/// Get a rounded rect with a given rounded-corner-radius.
		/// </summary>
		/// <param name="bounds">The rectangle to round.</param>
		/// <param name="radius">The radius for rounded corners.</param>
		/// <returns>A GraphicsPath describing the rounded rectangle path.</returns>
		public static GraphicsPath GetRoundedRect( Rectangle bounds , int radius ){
			return GetRoundedRect( bounds , true , true , true , true , radius );
		}

		/// <summary>
		/// Get a rounded rect with a given rounded-corner-radius.
		/// </summary>
		/// <param name="bounds">The rectangle to round.</param>
		/// <param name="leftTop">Should the left-top corner be rounded?</param>
		/// <param name="rightTop">Should the right-top corner be rounded?</param>
		/// <param name="leftBottom">Should the left-bottom corner be rounded?</param>
		/// <param name="rightBottom">Should the right-bottom corner be rounded?</param>
		/// <param name="radius">The radius for rounded corners.</param>
		/// <returns>A GraphicsPath describing the rounded rectangle path.</returns>
		public static GraphicsPath GetRoundedRect( Rectangle bounds , bool leftTop , bool rightTop , bool leftBottom , bool rightBottom , int radius ){
			GraphicsPath pathToReturn = new GraphicsPath();
			Rectangle topLeftRect = new Rectangle( bounds.Left , bounds.Top , radius * 2 , radius * 2 );
			Rectangle topRightRect = new Rectangle( bounds.Right - radius * 2 - 1 , bounds.Top , radius * 2 , radius * 2 );
			Rectangle bottomLeftRect = new Rectangle( bounds.Left , bounds.Bottom - radius * 2 - 1 , radius * 2 , radius * 2 );
			Rectangle bottomRightRect = new Rectangle( bounds.Right - radius * 2 - 1 , bounds.Bottom - radius * 2 - 1 , radius * 2 , radius * 2 );
			if( leftTop ) {
				pathToReturn.AddArc( topLeftRect , 180 , 90 );
			} else {
				pathToReturn.AddLine( topLeftRect.Left , topLeftRect.Bottom , topLeftRect.Left , topLeftRect.Top );
				pathToReturn.AddLine( topLeftRect.Left , topLeftRect.Top , topLeftRect.Right , topLeftRect.Top );
			}
			if( rightTop ) {
				pathToReturn.AddArc( topRightRect , 270 , 90 );
			} else {
				pathToReturn.AddLine( topRightRect.Left , topRightRect.Top , topRightRect.Right , topRightRect.Top );
				pathToReturn.AddLine( topRightRect.Right , topRightRect.Top , topRightRect.Right , topRightRect.Bottom );
			}
			if( rightBottom ) {
				pathToReturn.AddArc( bottomRightRect , 0 , 90 );
			} else {
				pathToReturn.AddLine( bottomRightRect.Right , bottomRightRect.Top , bottomRightRect.Right , bottomRightRect.Bottom );
				pathToReturn.AddLine( bottomRightRect.Right , bottomRightRect.Bottom , bottomRightRect.Left , bottomRightRect.Bottom );
			}
			if( leftBottom ) {
				pathToReturn.AddArc( bottomLeftRect , 90 , 90 );
			} else {
				pathToReturn.AddLine( bottomLeftRect.Right , bottomLeftRect.Bottom , bottomLeftRect.Left , bottomLeftRect.Bottom );
				pathToReturn.AddLine( bottomLeftRect.Left , bottomLeftRect.Bottom , bottomLeftRect.Left , bottomLeftRect.Top );
			}
			pathToReturn.CloseAllFigures();
			return pathToReturn;
		}

		/// <summary>
		/// Calculate the circle through 3 given points.
		/// </summary>
		/// <param name="p">An array of points containing 3 points to calculate the circle through.</param>
		/// <param name="centerPoint">A point to store the centerpoint of the calculated circle.</param>
		/// <returns>The radius of the calculated circle.</returns>
		/// <remarks>http://home.att.net/~srschmitt/circle3pts.html</remarks>
		public static int CalculateCircle( Point[] points , out Point centerPoint ) {
			double[][] matrix = new double[3][];
			for( int i = 0 ; i < 3 ; i++ ) {
				matrix[i] = new double[3];
			}

			// find minor 11
			for( int i = 0 ; i < 3 ; i++ ) {
				matrix[i][0] = (double)points[i].X;
				matrix[i][1] = (double)points[i].Y;
				matrix[i][2] = 1.0f;
			}
			double minor11 = GetDeterminant( matrix );
			// find minor12
			for( int i = 0 ; i < 3 ; i++ ) {
				matrix[i][0] = Math.Pow( (double)points[i].X , (double)2 ) + Math.Pow( (double)points[i].Y , (double)2 );
				matrix[i][1] = (double)points[i].Y;
				matrix[i][2] = 1.0f;
			}
			double minor12 = GetDeterminant( matrix );
			// find minor 13
			for( int i = 0 ; i < 3 ; i++ ) {
				matrix[i][0] = Math.Pow( (double)points[i].X , (double)2 ) + Math.Pow( (double)points[i].Y , (double)2 );
				matrix[i][1] = (double)points[i].X;
				matrix[i][2] = 1.0f;
			}
			double minor13 = GetDeterminant( matrix );
			// find minor 14
			for( int i = 0 ; i < 3 ; i++ ) {
				matrix[i][0] = Math.Pow( (double)points[i].X , (double)2 ) + Math.Pow( (double)points[i].Y , (double)2 );
				matrix[i][1] = (double)points[i].X;
				matrix[i][2] = (double)points[i].Y;
			}
			double minor14 = GetDeterminant( matrix );

			if( minor11 == 0 ) {
				centerPoint = points[1];
				return 0;
			} else {
				PointF center = new PointF( 0.5f * (float)minor12 / (float)minor11 , -0.5f * (float)minor13 / (float)minor11 );
				centerPoint = new Point( (int)center.X , (int)center.Y );
				return (int)Math.Sqrt( center.X * center.X + center.Y * center.Y + minor14 / minor11 );
			}
		}

		/// <summary>
		/// Calculte the determinant for a given 3x3 matrix.
		/// </summary>
		/// <param name="matrix">A 3x3 matrix.</param>
		/// <returns>The value of the determinant for the given 3x3 matrix.</returns>
		public static double GetDeterminant( double[][] matrix ) {
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

			return a * ( e * i - h * f ) - d * ( b * i - h * c ) + g * ( b * f - e * c );
		}

		public static GraphicsPath GetTopArcPath( Point[] points ) {
			Point centerPoint;
			int radius = CalculateCircle( points , out centerPoint );

			Rectangle circleRect = new Rectangle( points[1].X - radius , points[1].Y , radius * 2 , radius * 2 );

			// Calculate the angle between the line from the center to first point
			// and the line from the center to the second point.
			double leg1 = (double)points[1].X - (double)points[0].X;
			double leg2 = (double)points[1].Y - (double)centerPoint.Y;
			double hypotenuse = Math.Sqrt( leg1 * leg1 + leg2 * leg2 );
			double angle = Math.Sinh( leg1 / hypotenuse ) * 180 / Math.PI;
			angle += 1.0f;
			double startingAngle = 270 + angle;
			double sweepAngle = -angle * 2.0f;

			GraphicsPath path = new GraphicsPath();
			path.AddArc( circleRect , (float)startingAngle , (float)sweepAngle );
			return path;
		}

		/// <summary>
		/// Get an arc from a circle defined by 3 given points describing the path from the first point to the third point.
		/// The arc has its centerpoint below the 3 given points.
		/// </summary>
		/// <param name="drawRect">The rectangle containing the 3 points.</param>
		/// <param name="firstPoint">The first point to draw the arc through.</param>
		/// <param name="secondPoint">The second point to draw the arc through.</param>
		/// <param name="thirdPoint">The third point to draw the arc through.</param>
		/// <returns>The GraphicsPath through the 3 given points.</returns>
		public static GraphicsPath GetTopArcPath( Rectangle drawRect , Point firstPoint , Point secondPoint , Point thirdPoint ) {
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

		/// <summary>
		/// Get an arc from a circle defined by 3 given points describing the path from the first point to the third point.
		/// The arc has its centerpoint above the 3 given points.
		/// </summary>
		/// <param name="drawRect">The rectangle containing the 3 points.</param>
		/// <param name="firstPoint">The first point to draw the arc through.</param>
		/// <param name="secondPoint">The second point to draw the arc through.</param>
		/// <param name="thirdPoint">The third point to draw the arc through.</param>
		/// <returns>The GraphicsPath through the 3 given points.</returns>
		public static GraphicsPath GetBottomArcPath( Rectangle drawRect , Point firstPoint , Point secondPoint , Point thirdPoint ) {
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
		/// <param name="rectangle"></param>
		/// <returns></returns>
		public static GraphicsPath CreateRadialPath( Rectangle rectangle ) {
			GraphicsPath path = new GraphicsPath();
			RectangleF rect = rectangle;
			rect.X -= rect.Width * .35f;
			rect.Y -= rect.Height * .15f;
			rect.Width *= 1.7f;
			rect.Height *= 2.3f;
			path.AddEllipse( rect );
			path.CloseFigure();
			return path;
		}

	}

}
