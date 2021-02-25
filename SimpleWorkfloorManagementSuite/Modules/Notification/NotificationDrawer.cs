using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using SwmSuite.Presentation.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace SimpleWorkfloorManagementSuite.Modules.Notification {
	
	/// <summary>
	/// Class providing helper methods for drawing the notification controls.
	/// </summary>
	public class NotificationDrawer {

		#region -_ Static Helper Methods _-

		/// <summary>
		/// Draws the background.
		/// </summary>
		/// <param name="surface">The surface to perform the drawing on.</param>
		/// <param name="bounds">The drawing bounds.</param>
		/// <param name="scheme">The scheme to use for drawing.</param>
		public static void DrawBackground( Graphics surface , Rectangle bounds , NotificationScheme scheme , bool hovered ) {
			// Calculate rounded border
			Rectangle correctedBounds = new Rectangle( bounds.Left , bounds.Top , bounds.Width - 1 , bounds.Height - 1 );
			GraphicsPath borderPath = DrawingTools.GetRoundedRect( correctedBounds , 10 );
			// Calculate background rectangles.
			Rectangle topRectangle = new Rectangle( bounds.Left , bounds.Top , correctedBounds.Width , correctedBounds.Height / 2 );
			Rectangle bottomRectangle = new Rectangle( bounds.Left , topRectangle.Bottom , correctedBounds.Width , correctedBounds.Bottom - topRectangle.Bottom );
			// Set clipping region to the rounded border path.
			surface.SetClip( borderPath );
			// Create brushes for filling the background.
			LinearGradientBrush topBrush = new LinearGradientBrush( 
				topRectangle , 
				hovered ? scheme.BackgroundColor1Hovered : scheme.BackgroundColor1Normal , 
				hovered ? scheme.BackgroundColor2Hovered : scheme.BackgroundColor2Normal , 
				LinearGradientMode.Vertical );
			LinearGradientBrush bottomBrush = new LinearGradientBrush(
				topRectangle ,
				hovered ? scheme.BackgroundColor3Hovered : scheme.BackgroundColor3Normal ,
				hovered ? scheme.BackgroundColor4Hovered : scheme.BackgroundColor4Normal ,
				LinearGradientMode.Vertical );
			// Fill background.
			surface.FillRectangle( topBrush , topRectangle );
			surface.FillRectangle( bottomBrush , bottomRectangle );
			// Reset clip to draw border.
			surface.ResetClip();
			// Set antialias to draw nicer border.
			surface.SmoothingMode = SmoothingMode.AntiAlias;
			// Create pen to draw border.
			Pen borderPen = new Pen( hovered ? scheme.BorderColorHovered : scheme.BorderColorNormal );
			// Draw border.
			surface.DrawPath( borderPen , borderPath );
			// Dispose objects.
			borderPath.Dispose();
			topBrush.Dispose();
			bottomBrush.Dispose();
			borderPen.Dispose();
		}

		public static void DrawLoadingText( Graphics surface , Rectangle bounds , String text , NotificationScheme scheme ) {
			//StringFormat loadingTextFormat = new StringFormat() { Alignment = StringAlignment.Center , LineAlignment = StringAlignment.Center };
			//SolidBrush loadingTextBrush = new SolidBrush( scheme.TitleColor );
			surface.TextRenderingHint = TextRenderingHint.AntiAlias;
			//surface.DrawString( text , scheme.TitleFont , loadingTextBrush , bounds , loadingTextFormat );
			TextRenderer.DrawText( surface , text , scheme.TitleFont , bounds , scheme.TitleColor , TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter );
			surface.TextRenderingHint = TextRenderingHint.SystemDefault;
			//loadingTextBrush.Dispose();
			//loadingTextFormat.Dispose();
		}

		#endregion

	}

}
