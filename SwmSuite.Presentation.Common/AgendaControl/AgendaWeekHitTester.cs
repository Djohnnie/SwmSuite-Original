using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;

namespace SwmSuite.Presentation.Common.AgendaControl {

	public class AgendaWeekHitTester : AgendaHitTester {

		#region -_ Private Methods _-

		protected override void HitTestContents( Point hit , Rectangle bounds , AgendaScheme scheme , AgendaSettings settings , DateTime selection ) {
			DateTime selected = selection;
			//
			// Calculate selected day.
			//
			int dayWidth = bounds.Width / 7;
			for( int i = 0 ; i < 7 ; i++ ) {
				Rectangle dayBounds = new Rectangle( bounds.Left + i * dayWidth , bounds.Top , dayWidth , bounds.Height );
				if( dayBounds.Contains( hit ) ) {
					selected = selection.AddDays( i );
				}
			}
			//
			// Calculate selected hour.
			//
			
			// Calculate the number of rows.
			int numberOfRows = ( settings.DefaultEndHour - settings.DefaultBeginHour ) * 2;
			// Calculate the height of each row.
			float rowHeight = (float)bounds.Height / (float)numberOfRows;
			// Spread rowheights.
			int[] rowHeights = new int[numberOfRows];
			int heightSum = 0;
			for( int i = 0 ; i < numberOfRows ; i++ ) {
				if( i % 2 == 0 ) {
					rowHeights[i] = (int)rowHeight;
				} else {
					rowHeights[i] = (int)rowHeight + 1;
				}
				if( i == numberOfRows - 1 ) {
					rowHeights[i] = bounds.Height - heightSum;
				}
				heightSum += rowHeights[i];
			}
			// Draw rows.
			heightSum = 0;
			float currentHour = (float)settings.CurrentBeginPosition;
			for( int i = 0 ; i < numberOfRows ; i++ ) {
				Rectangle rowBounds = new Rectangle( bounds.Left , bounds.Top + heightSum , bounds.Width , rowHeights[i] );
				if( rowBounds.Contains( hit ) ) {
					if( currentHour - (int)currentHour > 0 ) {
						this.Selection = new DateTime( selected.Year , selected.Month , selected.Day , (int)currentHour , 30 , 0 );
					} else {
						this.Selection = new DateTime( selected.Year , selected.Month , selected.Day , (int)currentHour , 0 , 0 );
					}
				}
				currentHour += 0.5f;
				heightSum += rowHeights[i];
			}
		}

		#endregion

	}

}
