using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using SwmSuite.Presentation.Drawing;

namespace SwmSuite.Presentation.Common.NiceComboBox {
	
	public partial class NiceComboBoxControl : UserControl {

		private Color currentBorderColor;

		public Color BorderColorNormal { get; set; }
		public Color BorderColorHovered { get; set; }
		public Color BorderColorFocused { get; set; }

		[Browsable( true )]
		public new event EventHandler<EventArgs> TextChanged;

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		[DesignerSerializationVisibility( DesignerSerializationVisibility.Content )]
		public ComboBox Client {
			get {
				return comboBox;
			}
			set {
				comboBox = value;
			}
		}
		
		/// <summary>
		/// Default constructor.
		/// </summary>
		public NiceComboBoxControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );

			this.BorderColorNormal = Color.FromArgb( 125 , 170 , 210 );
			this.BorderColorHovered = Color.FromArgb( 153 , 207 , 255 );
			this.BorderColorFocused = Color.FromArgb( 255 , 160 , 17 );
		}

		private void NiceComboBoxControl_Resize( object sender , EventArgs e ) {
			comboBox.Bounds = new Rectangle( this.ClientRectangle.Left + 2 , this.ClientRectangle.Top + 1 , this.ClientRectangle.Width - 5 , this.ClientRectangle.Height - 3 );
			Invalidate();
		}

		private void NiceComboBoxControl_Paint( object sender , PaintEventArgs e ) {
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			GraphicsPath borderPath = DrawingTools.GetRoundedRect( new Rectangle( this.ClientRectangle.Left , this.ClientRectangle.Top , this.ClientRectangle.Width - 1 , this.ClientRectangle.Height - 1 ) , 3 );
			Pen borderPen = new Pen( currentBorderColor );
			e.Graphics.DrawPath( borderPen , borderPath );
			borderPen.Dispose();
			borderPath.Dispose();
			e.Graphics.SmoothingMode = SmoothingMode.Default;
		}

		private void comboBox_Enter( object sender , EventArgs e ) {
			currentBorderColor = this.BorderColorFocused;
			Invalidate();
		}

		private void comboBox_Leave( object sender , EventArgs e ) {
			currentBorderColor = this.BorderColorNormal;
			Invalidate();
		}

		private void comboBox_MouseEnter( object sender , EventArgs e ) {
			if( currentBorderColor != this.BorderColorFocused ) {
				currentBorderColor = this.BorderColorHovered;
				Invalidate();
			}
		}

		private void comboBox_MouseLeave( object sender , EventArgs e ) {
			if( currentBorderColor != this.BorderColorFocused ) {
				currentBorderColor = this.BorderColorNormal;
				Invalidate();
			}
		}

		private void NiceComboBoxControl_Load( object sender , EventArgs e ) {
			this.currentBorderColor = this.BorderColorNormal;
			Invalidate();
		}

		private void NiceComboBoxControl_BackColorChanged( object sender , EventArgs e ) {
			comboBox.BackColor = this.BackColor;
		}
	}
}
