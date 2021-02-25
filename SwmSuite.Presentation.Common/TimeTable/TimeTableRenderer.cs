using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Threading;
using SwmSuite.Framework;

namespace SwmSuite.Presentation.Common.TimeTable {

	public class TimeTableRenderer : IDisposable {

		#region -_ Private Members _-

		private LinearGradientBrush _columnHeaderBackgroundBrush1 = null;
		private LinearGradientBrush _columnHeaderBackgroundBrush2 = null;
		private LinearGradientBrush _dayColumnBackgroundBrush = null;
		private LinearGradientBrush _summaryRowBackgroundBrush1 = null;
		private LinearGradientBrush _summaryRowBackgroundBrush2 = null;
		private Pen _borderPen = null;

		private Rectangle? _selection;

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the hovered date.
		/// </summary>
		/// <value>The hovered date.</value>
		public DateTime? HoveredDate { get; set; }

		/// <summary>
		/// Gets or sets the hovered column.
		/// </summary>
		/// <value>The hovered column.</value>
		public TimeTableColumn HoveredColumn { get; set; }

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Renders the specified graphics.
		/// </summary>
		/// <param name="graphics">The graphics.</param>
		/// <param name="drawRectangle">The draw rectangle.</param>
		/// <param name="selection">The selection.</param>
		/// <param name="columns">The columns.</param>
		/// <param name="scheme">The scheme.</param>
		/// <param name="templateDesign">if set to <c>true</c> [template design].</param>
		/// <param name="templateColumn">The template column.</param>
		/// <param name="templateApply">if set to <c>true</c> [template apply].</param>
		/// <param name="hoveredColumn">The hovered column.</param>
		public void Render( Graphics graphics , Rectangle drawRectangle , DateTime selection , TimeTableColumnCollection columns , TimeTableScheme scheme , bool templateDesign , TimeTableColumn templateColumn , bool templateApply , TimeTableColumn hoveredColumn ) {
			if( !templateApply || hoveredColumn == null ) {
				_selection = null;
			}
			if( columns.Count > 0 ) {
				// Draw header.
				Rectangle headerRectangle = new Rectangle(
					drawRectangle.Left ,
					drawRectangle.Top ,
					drawRectangle.Width ,
					scheme.ColumnHeaderHeight );
				DrawColumnHeader( graphics , headerRectangle , scheme );
				// Draw day column.
				Rectangle dayColumnRectangle = new Rectangle(
					drawRectangle.Left , scheme.ColumnHeaderHeight , scheme.DayColumnWidth , drawRectangle.Height - scheme.ColumnHeaderHeight - scheme.SummaryRowHeight );
				DrawDayColumn( graphics , dayColumnRectangle , selection , scheme , templateDesign );
				// Draw summary row.
				Rectangle summaryRectangle = new Rectangle(
					drawRectangle.Left , drawRectangle.Bottom - scheme.SummaryRowHeight , drawRectangle.Width , scheme.SummaryRowHeight );
				DrawSummaryRow( graphics , summaryRectangle , scheme );
				graphics.DrawLine( GetBorderPen( scheme ) , summaryRectangle.Left , summaryRectangle.Top , summaryRectangle.Right , summaryRectangle.Top );
				foreach( TimeTableColumn column in columns ) {
					int columnWidth = ( drawRectangle.Width - scheme.DayColumnWidth ) / columns.Count;
					Rectangle columnRectangle = new Rectangle( drawRectangle.Left + scheme.DayColumnWidth + columnWidth * columns.IndexOf( column ) , drawRectangle.Top + scheme.ColumnHeaderHeight , columnWidth , drawRectangle.Height - scheme.ColumnHeaderHeight - scheme.SummaryRowHeight );
					Rectangle columnHeaderRectangle = new Rectangle( drawRectangle.Left + scheme.DayColumnWidth + columnWidth * columns.IndexOf( column ) , drawRectangle.Top , columnWidth , scheme.ColumnHeaderHeight );
					Rectangle columnSummaryRectangle = new Rectangle( drawRectangle.Left + scheme.DayColumnWidth + columnWidth * columns.IndexOf( column ) , drawRectangle.Bottom - scheme.SummaryRowHeight , columnWidth , scheme.SummaryRowHeight );
					DrawColumnCaption( graphics , columnHeaderRectangle , column , scheme );
					if( templateApply && column == hoveredColumn ) {
						_selection = columnRectangle;
						DrawColumn( graphics , columnRectangle , (DateTime)templateColumn.Tag , templateColumn , scheme );
					} else {
						DrawColumn( graphics , columnRectangle , selection , column , scheme );
					}
					if( templateApply && column == hoveredColumn ) {
						DrawColumnSummary( graphics , columnSummaryRectangle , templateColumn , scheme );
					} else {
						DrawColumnSummary( graphics , columnSummaryRectangle , column , scheme );
					}
				}
			}
			// Draw border.
			graphics.DrawRectangle( GetBorderPen( scheme ) , drawRectangle );
			for( int i = 0 ; i < 7 ; i++ ) {
				int top = scheme.ColumnHeaderHeight + ( ( drawRectangle.Height - scheme.ColumnHeaderHeight - scheme.SummaryRowHeight ) / 7 ) * i;
				graphics.DrawLine( GetBorderPen( scheme ) , drawRectangle.Left , top , drawRectangle.Right , top );
			}
			for( int i = 0 ; i < columns.Count ; i++ ) {
				int left = scheme.DayColumnWidth + ( ( drawRectangle.Width - scheme.DayColumnWidth ) / columns.Count ) * i;
				graphics.DrawLine( GetBorderPen( scheme ) , left , drawRectangle.Top , left , drawRectangle.Bottom );
				left = scheme.DayColumnWidth + ( ( drawRectangle.Width - scheme.DayColumnWidth ) / columns.Count ) * ( i + 1 ) - scheme.SummaryBoxWidth;
				graphics.DrawLine( GetBorderPen( scheme ) , left , drawRectangle.Top + scheme.ColumnHeaderHeight , left , drawRectangle.Bottom );
			}
			if( _selection.HasValue ) {
				if( templateApply ) {
					Pen borderPen = new Pen( Color.FromArgb( 255 , 0 , 0 ) , 3.0f );
					graphics.DrawRectangle( borderPen , _selection.Value );
					borderPen.Dispose();
				} else {
					Pen borderPen = new Pen( Color.FromArgb( 0 , 0 , 0 ) , 3.0f );
					graphics.DrawRectangle( borderPen , _selection.Value );
					borderPen.Dispose();
				}
			}
		}

		/// <summary>
		/// Invalidates this instance.
		/// </summary>
		public void Invalidate() {
			if( _columnHeaderBackgroundBrush1 != null ) {
				_columnHeaderBackgroundBrush1.Dispose();
				_columnHeaderBackgroundBrush1 = null;
			}
			if( _columnHeaderBackgroundBrush2 != null ) {
				_columnHeaderBackgroundBrush2.Dispose();
				_columnHeaderBackgroundBrush2 = null;
			}
			if( _dayColumnBackgroundBrush != null ) {
				_dayColumnBackgroundBrush.Dispose();
				_dayColumnBackgroundBrush = null;
			}
			if( _summaryRowBackgroundBrush1 != null ) {
				_summaryRowBackgroundBrush1.Dispose();
				_summaryRowBackgroundBrush1 = null;
			}
			if( _summaryRowBackgroundBrush2 != null ) {
				_summaryRowBackgroundBrush2.Dispose();
				_summaryRowBackgroundBrush2 = null;
			}
			if( _borderPen != null ) {
				_borderPen.Dispose();
				_borderPen = null;
			}
		}

		#endregion

		#region -_ Private Methods _-

		private void DrawColumnCaption( Graphics graphics , Rectangle drawRectangle , TimeTableColumn column , TimeTableScheme scheme ) {
			TextRenderer.DrawText( graphics , column.Caption , scheme.ColumnHeaderCaptionFont , drawRectangle , scheme.ColumnHeaderCaptionColor , TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter );
		}

		private void DrawColumnSummary( Graphics graphics , Rectangle drawRectangle , TimeTableColumn column , TimeTableScheme scheme ) {
			TimeSpan totalTimeSpan = new TimeSpan( 0 , 0 , 0 );
			foreach( TimeTableControlEntry entry in column.TimeTableEntries ) {
				totalTimeSpan = totalTimeSpan.Add( entry.End - entry.Begin );
			}
			Rectangle summaryBoxRectangle = new Rectangle( drawRectangle.Right - scheme.SummaryBoxWidth , drawRectangle.Top , scheme.SummaryBoxWidth , drawRectangle.Height );
			TextRenderer.DrawText( graphics , totalTimeSpan.TotalHours.ToString() + "h" , scheme.CaptionBoldFont , summaryBoxRectangle , scheme.CaptionColor , TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter );
		}

		private void DrawDayColumn( Graphics graphics , Rectangle drawRectangle , DateTime selection , TimeTableScheme scheme , bool templateDesign ) {
			// draw background.
			graphics.FillRectangle( GetDayColumnBackgroundBrush( drawRectangle , scheme ) , drawRectangle );
			// draw caption
			int dayHeight = drawRectangle.Height / 7;
			for( int i = 0 ; i < 7 ; i++ ) {
				Rectangle dayRectangle = new Rectangle(
					drawRectangle.Left ,
					drawRectangle.Top + dayHeight * i ,
					drawRectangle.Width ,
					dayHeight );
				String caption = templateDesign ? selection.AddDays( i ).ToString( "ddd" ) : selection.AddDays( i ).ToString( "ddd dd/MM (yyyy)" );
				TextRenderer.DrawText( graphics , caption , scheme.DayColumnCaptionFont , dayRectangle , scheme.DayColumnCaptionColor , TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak );
			}
		}

		private void DrawColumn( Graphics graphics , Rectangle drawRectangle , DateTime selection , TimeTableColumn column , TimeTableScheme scheme ) {
			DateTime currentDay = selection.StartOfWeek();
			for( int i = 0 ; i < 7 ; i++ ) {
				Rectangle timeTableBoxRectangle = new Rectangle( drawRectangle.Left , drawRectangle.Top + i * ( drawRectangle.Height / 7 ) , drawRectangle.Width - scheme.SummaryBoxWidth , ( drawRectangle.Height / 7 ) );
				Rectangle summaryBox = new Rectangle( timeTableBoxRectangle.Right , timeTableBoxRectangle.Top , scheme.SummaryBoxWidth , timeTableBoxRectangle.Height );
				TimeTableControlEntryCollection entries = new TimeTableControlEntryCollection();
				if( column.TimeTableEntries != null ) {
					foreach( TimeTableControlEntry entry in column.TimeTableEntries ) {
						if( entry.Begin.Date == currentDay ) {
							entries.Add( entry );
						}
					}
				}
				int numberOfEntries = entries.Count;
				for( int j = 0 ; j < numberOfEntries ; j++ ) {
					Rectangle timeTableEntryBoxRectangle = new Rectangle( timeTableBoxRectangle.Left , timeTableBoxRectangle.Top + ( j * ( timeTableBoxRectangle.Height / numberOfEntries ) ) , timeTableBoxRectangle.Width , timeTableBoxRectangle.Height / numberOfEntries );
					LinearGradientBrush timeTableEntryBackgroundBrush = new LinearGradientBrush( timeTableEntryBoxRectangle , entries[j].BackColor1 , entries[j].BackColor2 , LinearGradientMode.Vertical );
					graphics.FillRectangle( timeTableEntryBackgroundBrush , timeTableEntryBoxRectangle );
					TextRenderer.DrawText( graphics , entries[j].ToString() , scheme.CaptionFont , timeTableEntryBoxRectangle , scheme.CaptionColor , TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter );
					timeTableEntryBackgroundBrush.Dispose();
					//if( entries[j].Hovered ) {
					//   Pen borderPen = new Pen( Color.FromArgb( 0 , 0 , 0 ) , 3.0f );
					//   graphics.DrawRectangle( borderPen , timeTableEntryBoxRectangle );
					//   borderPen.Dispose();
					//}
				}
				if( numberOfEntries > 0 ) {
					TimeSpan totalTimeSpan = new TimeSpan( 0 , 0 , 0 );
					foreach( TimeTableControlEntry entry in entries ) {
						TimeSpan entryTimeSpan = entry.End - entry.Begin;
						totalTimeSpan = totalTimeSpan.Add( entryTimeSpan );
					}
					TextRenderer.DrawText( graphics , totalTimeSpan.TotalHours.ToString() + "h"/* + "\n(" + totalTimeSpan.Hours.ToString( "D2" ) + ":" + totalTimeSpan.Minutes.ToString( "D2" ) + ")"*/ , scheme.CaptionBoldFont , summaryBox , scheme.CaptionColor , TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter );
				}
				if( column == this.HoveredColumn && currentDay == this.HoveredDate ) {
					_selection = timeTableBoxRectangle;
				}
				currentDay = currentDay.AddDays( 1 );
			}
		}

		private void DrawColumnHeader( Graphics graphics , Rectangle drawRectangle , TimeTableScheme scheme ) {
			Rectangle topRectangle = new Rectangle( drawRectangle.Left , drawRectangle.Top , drawRectangle.Width , drawRectangle.Height / 2 );
			Rectangle bottomRectangle = new Rectangle( drawRectangle.Left , topRectangle.Bottom , drawRectangle.Width , drawRectangle.Height / 2 );
			graphics.FillRectangle( GetColumnHeaderBackgroundBrush1( topRectangle , scheme ) , topRectangle );
			graphics.FillRectangle( GetColumnHeaderBackgroundBrush2( bottomRectangle , scheme ) , bottomRectangle );
		}

		private void DrawSummaryRow( Graphics graphics , Rectangle drawRectangle , TimeTableScheme scheme ) {
			Rectangle topRectangle = new Rectangle( drawRectangle.Left , drawRectangle.Top , drawRectangle.Width , drawRectangle.Height / 2 );
			Rectangle bottomRectangle = new Rectangle( drawRectangle.Left , topRectangle.Bottom , drawRectangle.Width , drawRectangle.Height / 2 );
			graphics.FillRectangle( GetSummaryRowBackgroundBrush1( topRectangle , scheme ) , topRectangle );
			graphics.FillRectangle( GetSummaryRowBackgroundBrush2( bottomRectangle , scheme ) , bottomRectangle );
		}

		private void RenderColumn( Graphics graphics , Rectangle drawRectangle , DateTime selection , TimeTableColumnCollection columns , TimeTableScheme scheme ) {

		}

		private int GetColumnWidth( int totalWidth , int numberOfColumns , int offset ) {
			return ( totalWidth - offset ) / numberOfColumns;
		}

		private LinearGradientBrush GetColumnHeaderBackgroundBrush1( Rectangle bounds , TimeTableScheme scheme ) {
			if( _columnHeaderBackgroundBrush1 == null ) {
				_columnHeaderBackgroundBrush1 = new LinearGradientBrush( bounds , scheme.ColumnHeaderBackgroundColor1 , scheme.ColumnHeaderBackgroundColor2 , LinearGradientMode.Vertical );
			}
			return _columnHeaderBackgroundBrush1;
		}

		private LinearGradientBrush GetColumnHeaderBackgroundBrush2( Rectangle bounds , TimeTableScheme scheme ) {
			if( _columnHeaderBackgroundBrush2 == null ) {
				_columnHeaderBackgroundBrush2 = new LinearGradientBrush( bounds , scheme.ColumnHeaderBackgroundColor3 , scheme.ColumnHeaderBackgroundColor4 , LinearGradientMode.Vertical );
			}
			return _columnHeaderBackgroundBrush2;
		}

		private LinearGradientBrush GetDayColumnBackgroundBrush( Rectangle bounds , TimeTableScheme scheme ) {
			if( _dayColumnBackgroundBrush == null ) {
				_dayColumnBackgroundBrush = new LinearGradientBrush( bounds , scheme.DayColumnBackgroundColor1 , scheme.DayColumnBackgroundColor2 , LinearGradientMode.Horizontal );
			}
			return _dayColumnBackgroundBrush;
		}

		private LinearGradientBrush GetSummaryRowBackgroundBrush1( Rectangle bounds , TimeTableScheme scheme ) {
			if( _summaryRowBackgroundBrush1 == null ) {
				_summaryRowBackgroundBrush1 = new LinearGradientBrush( bounds , scheme.SummaryRowBackgroundColor1 , scheme.SummaryRowBackgroundColor2 , LinearGradientMode.Vertical );
			}
			return _summaryRowBackgroundBrush1;
		}

		private LinearGradientBrush GetSummaryRowBackgroundBrush2( Rectangle bounds , TimeTableScheme scheme ) {
			if( _summaryRowBackgroundBrush2 == null ) {
				_summaryRowBackgroundBrush2 = new LinearGradientBrush( bounds , scheme.SummaryRowBackgroundColor3 , scheme.SummaryRowBackgroundColor4 , LinearGradientMode.Vertical );
			}
			return _summaryRowBackgroundBrush2;
		}

		private Pen GetBorderPen( TimeTableScheme scheme ) {
			if( _borderPen == null ) {
				_borderPen = new Pen( scheme.BorderColor );
			}
			return _borderPen;
		}

		#endregion

		#region -_ IDisposable Members _-

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose() {
			GC.SuppressFinalize( this );
			Dispose( true );
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="dispose"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected void Dispose( bool dispose ) {
			if( dispose ) {
				Invalidate();
			}
		}

		#endregion

	}

}
