using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SwmSuite.Framework;

namespace SwmSuite.Presentation.Common.TimeTable {

	/// <summary>
	/// Class defining the hittest functionality for the timetable control.
	/// </summary>
	public class TimeTableHitTest {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the entry if an entry was hit before.
		/// </summary>
		public TimeTableControlEntry HitTestEntry { get; set; }

		/// <summary>
		/// Gets or sets the day if an empty day was hit before.
		/// </summary>
		public DateTime HitTestDate { get; set; }

		/// <summary>
		/// Gets or sets the hit test column.
		/// </summary>
		/// <value>The hit test column.</value>
		public TimeTableColumn HitTestColumn { get; set; }

		#endregion

		#region -_ Public Methods _-

		public TimeTableHitTestInfo HitTest( Point hit , Rectangle bounds , DateTime selection , TimeTableColumnCollection columns , TimeTableScheme scheme ) {
			TimeTableHitTestInfo hitTestInfoToReturn = TimeTableHitTestInfo.Nothing;
			// check for header hit.
			if( hit.Y > bounds.Top && hit.Y < bounds.Top + scheme.ColumnHeaderHeight ) {
				if( hit.X > bounds.Left && hit.X < bounds.Right ) {
					hitTestInfoToReturn = TimeTableHitTestInfo.Header;
				}
			}
			if( hit.Y > bounds.Top + scheme.ColumnHeaderHeight && hit.Y < bounds.Bottom - scheme.SummaryRowHeight ) {
				if( hit.X > bounds.Left + scheme.DayColumnWidth && hit.X < bounds.Right ) {
					Rectangle contentRectangle = new Rectangle( bounds.Left + scheme.DayColumnWidth , bounds.Top + scheme.ColumnHeaderHeight , bounds.Width - scheme.DayColumnWidth , bounds.Height - scheme.ColumnHeaderHeight - scheme.SummaryRowHeight );
					int columnWidth = contentRectangle.Width / columns.Count;
					int rowHeight = contentRectangle.Height / 7;
					DateTime currentDay = selection.StartOfWeek();
					for( int i = 0 ; i < 7 ; i++ ) {
						foreach( TimeTableColumn column in columns ) {
							Rectangle timeTableBoxRectangle = new Rectangle( contentRectangle.Left + columnWidth * columns.IndexOf( column ) , contentRectangle.Top + i * rowHeight , columnWidth - scheme.SummaryBoxWidth , rowHeight );
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
							if( timeTableBoxRectangle.Contains( hit ) ) {
								hitTestInfoToReturn = TimeTableHitTestInfo.Day;
								this.HitTestDate = currentDay;
								this.HitTestColumn = column;
							}
							if( numberOfEntries == 0 ) {
								
							} else {
								//for( int j = 0 ; j < numberOfEntries ; j++ ) {
								//   Rectangle timeTableEntryBoxRectangle = new Rectangle( timeTableBoxRectangle.Left , timeTableBoxRectangle.Top + ( j * ( timeTableBoxRectangle.Height / numberOfEntries ) ) , timeTableBoxRectangle.Width , timeTableBoxRectangle.Height / numberOfEntries );
								//   if( timeTableEntryBoxRectangle.Contains( hit ) ) {
								//      hitTestInfoToReturn = TimeTableHitTestInfo.Entry;
								//      this.HitTestDate = currentDay;
								//      this.HitTestEntry = column.TimeTableEntries[j];
								//   }
								//}
							}
						}
						currentDay = currentDay.AddDays( 1 );
					}
				}
				if( hit.X > bounds.Left && hit.Y < bounds.Left + scheme.DayColumnWidth ) {
					hitTestInfoToReturn = TimeTableHitTestInfo.DayColumn;
				}
			}
			if( hit.Y > bounds.Bottom - scheme.SummaryRowHeight && hit.Y < bounds.Bottom ) {
				if( hit.X > bounds.Left && hit.X < bounds.Right ) {
					hitTestInfoToReturn = TimeTableHitTestInfo.Footer;
				}
			}
			return hitTestInfoToReturn;
		}

		#endregion

	}

}
