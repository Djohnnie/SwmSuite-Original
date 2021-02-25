using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwmSuite.Presentation.Common.TimeTable {

	public partial class OccupationControl : UserControl {

		#region -_ Public Properties _-

		public OccupationSettings Settings { get; set; }

		public OccupationRenderer Renderer { get; set; }

		//public OccupationHitTest HitTester { get; set; }

		[DesignerSerializationVisibility( DesignerSerializationVisibility.Content )]
		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public OccupationScheme Scheme { get; set; }

		[DesignerSerializationVisibility( DesignerSerializationVisibility.Content )]
		public TimeTableColumnCollection Columns { get; set; }

		public DateTime Selection { get; set; }

		#endregion

		#region -_ Events _-

		public event EventHandler<EventArgs> DataNeeded;

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="OccupationControl"/> class.
		/// </summary>
		public OccupationControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );

			this.Settings = new OccupationSettings();
			this.Columns = new TimeTableColumnCollection();
			this.Selection = DateTime.Today;
			this.Renderer = new OccupationRenderer();
			//this.HitTester = new TimeTableHitTest();
			this.Scheme = new OccupationScheme();
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Paint event of the OccupationControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
		private void OccupationControl_Paint( object sender , PaintEventArgs e ) {
			Rectangle realRectangle = new Rectangle( this.ClientRectangle.Left , this.ClientRectangle.Top , this.ClientRectangle.Width - 1 , this.ClientRectangle.Height - 1 );
			this.Renderer.Render( e.Graphics , realRectangle , this.Selection , this.Columns , this.Settings , this.Scheme );
		}

		#endregion

		#region -_ Public Methods _-

		public void Move( DateTime dateTime ) {
			this.Selection = dateTime;
			if( this.DataNeeded != null ) {
				DataNeeded( this , EventArgs.Empty );
			}
			this.Invalidate();
		}

		#endregion

	}

}
