using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwmSuite.Framework;

namespace SwmSuite.Presentation.Common.TimeTable {

	public partial class TimeTableControl : UserControl {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the renderer.
		/// </summary>
		/// <value>The renderer.</value>
		public TimeTableRenderer Renderer { get; set; }

		/// <summary>
		/// Gets or sets the hit tester.
		/// </summary>
		/// <value>The hit tester.</value>
		public TimeTableHitTest HitTester { get; set; }

		/// <summary>
		/// Gets or sets the scheme.
		/// </summary>
		/// <value>The scheme.</value>
		[DesignerSerializationVisibility( DesignerSerializationVisibility.Content )]
		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public TimeTableScheme Scheme { get; set; }

		/// <summary>
		/// Gets or sets the columns.
		/// </summary>
		/// <value>The columns.</value>
		[DesignerSerializationVisibility( DesignerSerializationVisibility.Content )]
		public TimeTableColumnCollection Columns { get; set; }

		/// <summary>
		/// Gets or sets the selection.
		/// </summary>
		/// <value>The selection.</value>
		public DateTime Selection { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this control is in timetable design mode.
		/// </summary>
		/// <value><c>true</c> if this control is in timetable design mode; otherwise, <c>false</c>.</value>
		public bool InDesign { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [in template design].
		/// </summary>
		/// <value><c>true</c> if [in template design]; otherwise, <c>false</c>.</value>
		public bool TemplateDesign { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [template apply].
		/// </summary>
		/// <value><c>true</c> if [template apply]; otherwise, <c>false</c>.</value>
		public bool TemplateApply { get; set; }

		/// <summary>
		/// Gets or sets the time table template column.
		/// </summary>
		/// <value>The time table template column.</value>
		public TimeTableColumn TimeTableTemplateColumn { get; set; }

		/// <summary>
		/// Gets or sets the hovered column.
		/// </summary>
		/// <value>The hovered column.</value>
		public TimeTableColumn HoveredColumn { get; set; }

		#endregion

		#region -_ Events _-

		/// <summary>
		/// Occurs when data is needed.
		/// </summary>
		public event EventHandler<EventArgs> DataNeeded;

		/// <summary>
		/// Occurs when data is clicked.
		/// </summary>
		public event EventHandler<DataClickedEventArgs> DataClicked;

		/// <summary>
		/// Raises the data clicked event.
		/// </summary>
		/// <param name="column">The column that has been clicked.</param>
		/// <param name="date">The date that has been clicked.</param>
		/// <param name="entries">The entries contained by the clicked area.</param>
		private void RaiseDataClicked( TimeTableColumn column , DateTime date , TimeTableControlEntryCollection entries ) {
			if( this.DataClicked != null ) {
				DataClicked( this , new DataClickedEventArgs( column , date , entries ) );
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTableControl"/> class.
		/// </summary>
		public TimeTableControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );

			this.Columns = new TimeTableColumnCollection();
			this.Selection = DateTime.Today;
			this.Renderer = new TimeTableRenderer();
			this.HitTester = new TimeTableHitTest();
			this.Scheme = new TimeTableScheme();
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Paint event of the TimeTableControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
		private void TimeTableControl_Paint( object sender , PaintEventArgs e ) {
			Rectangle realRectangle = new Rectangle( this.ClientRectangle.Left , this.ClientRectangle.Top , this.ClientRectangle.Width - 1 , this.ClientRectangle.Height - 1 );
			this.Renderer.Render( e.Graphics , realRectangle , this.Selection.StartOfWeek() , this.Columns , this.Scheme , this.TemplateDesign , this.TimeTableTemplateColumn , this.TemplateApply , this.HoveredColumn );
		}

		/// <summary>
		/// Handles the Resize event of the TimeTableControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void TimeTableControl_Resize( object sender , EventArgs e ) {
			this.Renderer.Invalidate();
			this.Invalidate();
		}

		/// <summary>
		/// Handles the MouseClick event of the TimeTableControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
		private void TimeTableControl_MouseClick( object sender , MouseEventArgs e ) {
			Rectangle realRectangle = new Rectangle( this.ClientRectangle.Left , this.ClientRectangle.Top , this.ClientRectangle.Width - 1 , this.ClientRectangle.Height - 1 );
			switch( this.HitTester.HitTest( e.Location , realRectangle , this.Selection , this.Columns , this.Scheme ) ) {
				case TimeTableHitTestInfo.Day: {
						if( this.InDesign ) {
							RaiseDataClicked( this.HitTester.HitTestColumn , this.HitTester.HitTestDate , this.HitTester.HitTestColumn.GetEntriesOnDate( this.HitTester.HitTestDate ) );
						}
						break;
					}
				case TimeTableHitTestInfo.Entry: {
						break;
					}
			}
		}

		/// <summary>
		/// Handles the MouseMove event of the TimeTableControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
		private void TimeTableControl_MouseMove( object sender , MouseEventArgs e ) {
			Rectangle realRectangle = new Rectangle( this.ClientRectangle.Left , this.ClientRectangle.Top , this.ClientRectangle.Width - 1 , this.ClientRectangle.Height - 1 );
			switch( this.HitTester.HitTest( e.Location , realRectangle , this.Selection , this.Columns , this.Scheme ) ) {
				case TimeTableHitTestInfo.Day: {
						if( this.InDesign && !this.TemplateApply ) {
							this.Renderer.HoveredDate = this.HitTester.HitTestDate;
							this.Renderer.HoveredColumn = this.HitTester.HitTestColumn;
							Invalidate();
						}
						if( this.TemplateApply ) {
							if( this.HoveredColumn != this.HitTester.HitTestColumn ) {
								this.HoveredColumn = this.HitTester.HitTestColumn;
								Invalidate();
							}
						} else {
							if( this.HoveredColumn != null ) {
								this.HoveredColumn = null;
								Invalidate();
							}
						}
						break;
					}
				case TimeTableHitTestInfo.Nothing: {
						if( this.HoveredColumn != null ) {
							this.HoveredColumn = null;
							Invalidate();
						}
						this.Renderer.HoveredDate = null;
						this.Renderer.HoveredColumn = null;
						Invalidate();
						break;
					}
				case TimeTableHitTestInfo.Header: {
						if( this.HoveredColumn != null ) {
							this.HoveredColumn = null;
							Invalidate();
						}
						this.Renderer.HoveredDate = null;
						this.Renderer.HoveredColumn = null;
						Invalidate();
						break;
					}
				case TimeTableHitTestInfo.Entry: {
						if( this.HoveredColumn != null ) {
							this.HoveredColumn = null;
							Invalidate();
						}
						if( this.InDesign ) {
							this.HitTester.HitTestEntry.Hovered = true;
							Invalidate();
						}
						break;
					}
			}
		}

		/// <summary>
		/// Handles the MouseLeave event of the TimeTableControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void TimeTableControl_MouseLeave( object sender , EventArgs e ) {
			this.Renderer.HoveredDate = null;
			this.Renderer.HoveredColumn = null;
			Invalidate();
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Updates the data.
		/// </summary>
		public void UpdateData() {
			if( this.DataNeeded != null ) {
				DataNeeded( this , EventArgs.Empty );
			}
			this.Renderer.Invalidate();
			this.Invalidate();
		}

		public void Move( DateTime dateTime ) {
			this.Selection = dateTime.StartOfWeek();
			UpdateData();
		}

		/// <summary>
		/// Moves the selection to next week.
		/// </summary>
		public void MoveNextWeek() {
			Move( 7 );
		}

		/// <summary>
		/// Moves the selection to previous week.
		/// </summary>
		public void MovePreviousWeek() {
			Move( -7 );
		}

		#endregion

		#region -_ Private Methods _-

		/// <summary>
		/// Move the selection by a given number of days.
		/// </summary>
		/// <param name="days">The days to move the selection.</param>
		private void Move( int days ) {
			this.Selection = this.Selection.AddDays( days );
			if( this.DataNeeded != null ) {
				DataNeeded( this , EventArgs.Empty );
			}
			this.Renderer.Invalidate();
			this.Invalidate();
		}

		#endregion

	}

}
