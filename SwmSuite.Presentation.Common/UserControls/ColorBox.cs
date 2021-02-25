using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SwmSuite.Presentation.Common.UserControls {
	
	/// <summary>
	/// UserControl defining a color box.
	/// </summary>
	public partial class ColorBox : UserControl {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the first background color.
		/// </summary>
		public Color BackgroundColor1 { get; set; }

		/// <summary>
		/// Gets or sets the second background color.
		/// </summary>
		public Color BackgroundColor2 { get; set; }

		/// <summary>
		/// Gets or sets the border color.
		/// </summary>
		public Color BorderColor { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="ColorBox"/> class.
		/// </summary>
		public ColorBox() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Paint event of the ColorBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
		private void ColorBox_Paint( object sender , PaintEventArgs e ) {
			Rectangle correctedClientRectangle = new Rectangle( 
				this.ClientRectangle.Left , 
				this.ClientRectangle.Top , 
				this.ClientRectangle.Width - 1 , 
				this.ClientRectangle.Height - 1 );
			LinearGradientBrush backgroundBrush = new LinearGradientBrush(
				correctedClientRectangle , 
				this.BackgroundColor1 , 
				this.BackgroundColor2 , 
				LinearGradientMode.ForwardDiagonal );
			Pen borderPen = new Pen( this.BorderColor );
			e.Graphics.FillRectangle( backgroundBrush , correctedClientRectangle );
			e.Graphics.DrawRectangle( borderPen , correctedClientRectangle );
			borderPen.Dispose();
			backgroundBrush.Dispose();
		}

		#endregion

	}

}