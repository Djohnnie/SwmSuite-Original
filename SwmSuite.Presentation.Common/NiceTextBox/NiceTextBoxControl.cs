using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using SwmSuite.Presentation.Drawing;

namespace SwmSuite.Presentation.Common.NiceTextBox {
	
	public partial class NiceTextBoxControl : UserControl {

		private Color currentBorderColor;

		private Color currentBackColor;

		public Color BorderColorNormal { get; set; }
		public Color BorderColorHovered { get; set; }
		public Color BorderColorFocused { get; set; }

		[Browsable(true)]
		public new event EventHandler<EventArgs> TextChanged;

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public TextBox Client {
			get {
				return textbox;
			}
			set {
				textbox = value;
			}
		}

		public Color ContentsOkColor { get; set; }
		public Color ContentsErrorColor { get; set; }
		public Color ContentsDisableColor { get; set; }

		public NiceTextBoxControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );

			this.BorderColorNormal = Color.FromArgb( 125 , 170 , 210 );
			this.BorderColorHovered = Color.FromArgb( 153 , 207 , 255 );
			this.BorderColorFocused = Color.FromArgb( 255 , 160 , 17 );

			this.ContentsOkColor = Color.FromArgb( 232 , 255 , 239 );
			this.ContentsErrorColor = Color.FromArgb( 255, 232, 232 );
			this.ContentsDisableColor = Color.FromArgb( 240 , 240 , 240 );
		}

		private void NiceTextBoxControl_Resize( object sender , EventArgs e ) {
			textbox.Bounds = new Rectangle( this.ClientRectangle.Left + 4 , this.ClientRectangle.Top + 2 , this.ClientRectangle.Width - 9 , this.ClientRectangle.Height - 5 );
			Invalidate();
		}

		private void NiceTextBoxControl_Paint( object sender , PaintEventArgs e ) {
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			GraphicsPath borderPath = DrawingTools.GetRoundedRect( new Rectangle( this.ClientRectangle.Left , this.ClientRectangle.Top , this.ClientRectangle.Width - 1 , this.ClientRectangle.Height - 1 ) , 3 );
			Pen borderPen = new Pen( currentBorderColor );
			e.Graphics.DrawPath( borderPen , borderPath );
			borderPen.Dispose();
			borderPath.Dispose();
			e.Graphics.SmoothingMode = SmoothingMode.Default;
		}

		private void textbox_Enter( object sender , EventArgs e ) {
			currentBorderColor = this.BorderColorFocused;
			Invalidate();
		}

		private void textbox_Leave( object sender , EventArgs e ) {
			currentBorderColor = this.BorderColorNormal;
			Invalidate();
		}

		private void textbox_MouseEnter( object sender , EventArgs e ) {
			if( currentBorderColor != this.BorderColorFocused ) {
				currentBorderColor = this.BorderColorHovered;
				Invalidate();
			}
		}

		private void textbox_MouseLeave( object sender , EventArgs e ) {
			if( currentBorderColor != this.BorderColorFocused ) {
				currentBorderColor = this.BorderColorNormal;
				Invalidate();
			}
		}

		private void NiceTextBoxControl_Load( object sender , EventArgs e ) {
			this.currentBorderColor = this.BorderColorNormal;
			DoError( false );
			Invalidate();
		}

		private void NiceTextBoxControl_BackColorChanged( object sender , EventArgs e ) {
			textbox.BackColor = this.BackColor;
		}

		private void NiceTextBoxControl_EnabledChanged( object sender , EventArgs e ) {
			textbox.BackColor = this.Enabled ? this.ContentsOkColor : this.ContentsDisableColor;
			this.BackColor = this.Enabled ? this.ContentsOkColor : this.ContentsDisableColor;
			this.Client.Enabled = this.Enabled;
		}

		private void textbox_TextChanged(object sender, EventArgs e)
		{
			if( this.TextChanged != null ){
				TextChanged( this , e );
			}
		}

		
		public void DoError( bool error ){
			this.BackColor = error ? this.ContentsErrorColor : this.ContentsOkColor;
			this.Client.BackColor = error ? this.ContentsErrorColor : this.ContentsOkColor;
		}

	}

}
