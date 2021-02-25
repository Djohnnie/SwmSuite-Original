using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SwmSuite.Presentation.Common.AgendaControl {
	
	public class AgendaTools {

		#region -_ Public Methods _-

		public static int GetNumberOfRows( AgendaSettings settings ) {
			return ( settings.DefaultEndHour - settings.DefaultBeginHour ) * 2;
		}

		public static int[] GetRowHeights( AgendaSettings settings , Rectangle bounds ) {
			float rowHeight = (float)bounds.Height / (float)GetNumberOfRows( settings );
			// Spread rowheights.
			int[] rowHeights = new int[GetNumberOfRows( settings )];
			int heightSum = 0;
			for( int i = 0 ; i < GetNumberOfRows( settings ) ; i++ ) {
				if( i % 2 == 0 ) {
					rowHeights[i] = (int)rowHeight;
				} else {
					rowHeights[i] = (int)rowHeight + 1;
				}
				if( i == GetNumberOfRows( settings ) - 1 ) {
					rowHeights[i] = bounds.Height - heightSum;
				}
				heightSum += rowHeights[i];
			}
			return rowHeights;
		}

		#endregion

	}

}
