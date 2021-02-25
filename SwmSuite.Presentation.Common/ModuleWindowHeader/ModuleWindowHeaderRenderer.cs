using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SwmSuite.Presentation.Common.ModuleWindowHeader {
	
	public class ModuleWindowHeaderRenderer {

		#region -_ Private Members _-

		private ModuleWindowHeaderScheme _scheme = new ModuleWindowHeaderScheme();

		#endregion

		#region -_ Public Properties _-

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public ModuleWindowHeaderScheme Scheme {
			get {
				return _scheme;
			}
			set {
				_scheme = value;
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ModuleWindowHeaderRenderer() {
			this.Scheme = new ModuleWindowHeaderScheme() {
				BackgroundFlood1Color = Color.FromArgb( 89 , 106 , 146 ) ,
				BackgroundFlood2Color = Color.FromArgb( 52 , 56 , 66 ) ,
				BackgroundFlood3Color = Color.FromArgb( 0 , 0 , 0 ) ,
				BackgroundFlood4Color = Color.FromArgb( 56 , 69 , 102 )
			};
		}

		#endregion

		#region -_ Public Methods _-

		public void Render( Graphics graphics , Rectangle drawRect ) {
			DrawBackground( graphics , drawRect );
			DrawTitle( graphics , drawRect , "B e h e e r   v a n   p e r s o n e e l" );
		}

		#endregion

		#region -_ Private Methods _-

		private void DrawBackground( Graphics graphics , Rectangle drawRect ) {
			Rectangle topRect = new Rectangle( drawRect.Left , drawRect.Top , drawRect.Width , drawRect.Height / 2 + 1 );
			Rectangle bottomRect = new Rectangle( drawRect.Left , drawRect.Top + drawRect.Height / 2 - 1 , drawRect.Width , drawRect.Height / 2 + 2 );

			LinearGradientBrush topBackgroundFillBrush = new LinearGradientBrush( topRect , this.Scheme.BackgroundFlood1Color , this.Scheme.BackgroundFlood2Color , LinearGradientMode.Vertical );
			graphics.FillRectangle( topBackgroundFillBrush , topRect );
			topBackgroundFillBrush.Dispose();

			LinearGradientBrush bottomBackgroundFillBrush = new LinearGradientBrush( bottomRect , this.Scheme.BackgroundFlood3Color , this.Scheme.BackgroundFlood4Color , LinearGradientMode.Vertical );
			graphics.FillRectangle( bottomBackgroundFillBrush , bottomRect );
			bottomBackgroundFillBrush.Dispose();
		}

		private void DrawTitle( Graphics graphics , Rectangle drawRect , string title ) {
			Rectangle topRect = new Rectangle( drawRect.Left , drawRect.Top , drawRect.Width , drawRect.Height / 2 + 1 );
			Rectangle bottomRect = new Rectangle( drawRect.Left , drawRect.Top + drawRect.Height / 2 , drawRect.Width , drawRect.Height / 2 + 1 );

			StringFormat stringFormat = new StringFormat() {
				Alignment = StringAlignment.Center ,
				LineAlignment = StringAlignment.Far
			};

			//Font x = new Font( "Copperplate Gothic Light" , 25.0f , FontStyle.Regular );
			//SizeF fontSize = graphics.MeasureString( title , x );

			//GraphicsPath path = new GraphicsPath();
			//path.AddString( title , "Copperplate Gothic Light" , FontStyle.Regular , 20.0f , new Point( 0 , 0 ) , new StringFormat() );

			//Point titlePosition = new Point( 10 , bottomRect.Top - (int)x.GetHeight(graphics.DpiY) );
			//RectangleF rect = path.GetBounds();

			////graphics.DrawString( title , x , Brushes.White , titlePosition );
			//graphics.FillPath( Brushes.White , path );

			stringFormat.Dispose();
		}

		#endregion

	}

}
