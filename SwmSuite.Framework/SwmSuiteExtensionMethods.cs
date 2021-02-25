using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwmSuite.Framework {

	public static class SwmSuiteExtensionMethods {

		public static DateTime FromTime( this DateTime dateTime , int hour , int minute ) {
			return new DateTime( dateTime.Year , dateTime.Month , dateTime.Day , hour , minute , 0 );
		}

		public static DateTime StartOfWeek( this DateTime onDate ) {
			int diff = onDate.DayOfWeek - DayOfWeek.Monday;
			if( diff < 0 ) {
				diff += 7;
			}
			return onDate.AddDays( -1 * diff ).Date;
		}

		public static DateTime EndOfWeek( this DateTime onDate ) {
			int diff = DayOfWeek.Sunday - onDate.DayOfWeek;
			if( diff < 0 ) {
				diff += 7;
			}
			return onDate.AddDays( 1 * diff ).Date;
		}

		public static bool InWeek( this DateTime week , DateTime test ) {
			return test >= week.StartOfWeek() && test <= week.EndOfWeek();
		}

	}

}
