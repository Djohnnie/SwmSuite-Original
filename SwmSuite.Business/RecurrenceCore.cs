using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.Common;
using System.Globalization;
using SwmSuite.Framework;

namespace SwmSuite.Business {

	public class RecurrenceCore {

		public static bool IsInRecurrence( Recurrence recurrence , DateTime onDate ) {
			bool isInRecurrence = true;
			isInRecurrence = IsValid( recurrence , onDate );
			DateTime startDate = GetValidStartDate( recurrence );
			while( startDate < onDate ) {
				startDate = AddOneOccurence( recurrence , startDate );
			}
			if( startDate > onDate ) {
				isInRecurrence = false;
			}
			return isInRecurrence;
		}

		public static bool IsValid( Recurrence recurrence , DateTime onDate ) {
			bool valid = true;
			if( onDate < recurrence.StartDate ) {
				valid = false;
			}
			switch( recurrence.EndMode ) {
				case RecurrenceEndMode.Infinite: {
						break;
					}
				case RecurrenceEndMode.ByDate: {
						if( onDate > recurrence.EndDate ) {
							valid = false;
						}
						break;
					}
				case RecurrenceEndMode.ByNumber: {
						DateTime endDate = GetValidStartDate( recurrence );
						for( int i = 1 ; i < recurrence.Occurrences ; i++ ) {
							endDate = AddOneOccurence( recurrence , endDate );
						}
						if( onDate > endDate ) {
							valid = false;
						}
						break;
					}
			}

			return valid;
		}

		public static DateTime GetValidStartDate( Recurrence recurrence ) {
			DateTime endDateTime = recurrence.StartDate;
			switch( recurrence.RecurrenceMode ) {
				case RecurrenceMode.Daily: {
						if( recurrence.EveryWeekDay ) {
							while( endDateTime.DayOfWeek == DayOfWeek.Saturday || endDateTime.DayOfWeek == DayOfWeek.Sunday ) {
								endDateTime = endDateTime.AddDays( 1 );
							}
						}
						//for( int i = 1 ; i < recurrence.Occurrences ; i++ ) {
						//  endDateTime = AddOneOccurence( recurrence , endDateTime );
						//}
						break;
					}
				case RecurrenceMode.Weekly: {
						while( ( endDateTime.DayOfWeek != DayOfWeek.Monday || !recurrence.Days.Monday ) &&
							( endDateTime.DayOfWeek != DayOfWeek.Tuesday || !recurrence.Days.Tuesday ) &&
							( endDateTime.DayOfWeek != DayOfWeek.Wednesday || !recurrence.Days.Wednesday ) &&
							( endDateTime.DayOfWeek != DayOfWeek.Thursday || !recurrence.Days.Thursday ) &&
							( endDateTime.DayOfWeek != DayOfWeek.Friday || !recurrence.Days.Friday ) &&
							( endDateTime.DayOfWeek != DayOfWeek.Saturday || !recurrence.Days.Saturday ) &&
							( endDateTime.DayOfWeek != DayOfWeek.Sunday || !recurrence.Days.Sunday ) ) {
							endDateTime = endDateTime.AddDays( 1 );
						}
						//for( int i = 1 ; i < recurrence.Occurrences ; i++ ) {
						//  endDateTime = AddOneOccurence( recurrence , endDateTime );
						//}
						break;
					}
				case RecurrenceMode.Monthly: {
						if( recurrence.Choice ) {
							//
							// Day 7 of every 2 months.
							//
							DateTime startDate = new DateTime( endDateTime.Year , endDateTime.Month , recurrence.DayOfMonth > DateTime.DaysInMonth( endDateTime.Year , endDateTime.Month ) ? DateTime.DaysInMonth( endDateTime.Year , endDateTime.Month ) : recurrence.DayOfMonth );
							if( endDateTime < startDate ) {
								endDateTime = startDate;
							}
							if( endDateTime > startDate ) {
								endDateTime = startDate.AddMonths( 1 );
							}
							//for( int i = 1 ; i < recurrence.Occurrences ; i++ ) {
							//  endDateTime = AddOneOccurence( recurrence , endDateTime );
							//}
						} else {
							//
							// The first monday of every 2 months.
							//
							DateTime startDate = GetExactDate( recurrence , endDateTime );
							if( endDateTime < startDate ) {
								endDateTime = startDate;
							}
							if( endDateTime > startDate ) {
								endDateTime = GetExactDate( recurrence , endDateTime.AddMonths( 1 ) );
							}
							//for( int i = 1 ; i < recurrence.Occurrences ; i++ ) {
							//  endDateTime = AddOneOccurence( recurrence , endDateTime );
							//}
						}
						break;
					}
				case RecurrenceMode.Yearly: {
						if( recurrence.Choice ) {
							//
							// Every July 7.
							//
							DateTime startDate = new DateTime( endDateTime.Year , (int)recurrence.Month + 1 , recurrence.DayOfMonth );
							if( endDateTime < startDate ) {
								endDateTime = startDate;
							}
							if( endDateTime > startDate ) {
								endDateTime = new DateTime( endDateTime.Year + 1 , (int)recurrence.Month + 1 , recurrence.DayOfMonth );
							}
							//for( int i = 1 ; i < recurrence.Occurrences ; i++ ) {
							//  endDateTime = AddOneOccurence( recurrence , endDateTime );
							//}
						} else {
							//
							// Every first monday of july.
							//
							DateTime startDate = GetExactDate( recurrence , endDateTime );
							if( endDateTime < startDate ) {
								endDateTime = startDate;
							}
							if( endDateTime > startDate ) {
								endDateTime = GetExactDate( recurrence , endDateTime.AddYears( 1 ) );
							}
							//for( int i = 1 ; i < recurrence.Occurrences ; i++ ) {
							//  endDateTime = AddOneOccurence( recurrence , endDateTime );
							//}
						}
						break;
					}
			}
			return endDateTime;
		}

		public static DateTime CalculateRecurrenceEndDate( Recurrence recurrence ) {
			DateTime endDateTime = recurrence.StartDate;
			switch( recurrence.EndMode ) {
				case RecurrenceEndMode.Infinite: {
						endDateTime = DateTime.MaxValue;
						break;
					}
				case RecurrenceEndMode.ByDate: {
						endDateTime = recurrence.EndDate;
						break;
					}
				case RecurrenceEndMode.ByNumber: {
						endDateTime = GetValidStartDate( recurrence );
						for( int i = 1 ; i < recurrence.Occurrences ; i++ ) {
							endDateTime = AddOneOccurence( recurrence , endDateTime );
						}
						break;
					}
			}
			return endDateTime;
		}

		private static DateTime AddOneOccurence( Recurrence recurrence , DateTime date ) {
			switch( recurrence.RecurrenceMode ) {
				case RecurrenceMode.Daily: {
						if( recurrence.EveryWeekDay ) {
							//
							// Every weekday.
							//
							date = date.AddDays( 1 );
							while( date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday ) {
								date = date.AddDays( 1 );
							}
						} else {
							//
							// Every 2 days.
							//
							date = date.AddDays( recurrence.Every );
						}
						break;
					}
				case RecurrenceMode.Weekly: {
						date = date.AddDays( 1 );
						while( ( ( date.DayOfWeek != DayOfWeek.Monday || !recurrence.Days.Monday ) &&
											( date.DayOfWeek != DayOfWeek.Tuesday || !recurrence.Days.Tuesday ) &&
											( date.DayOfWeek != DayOfWeek.Wednesday || !recurrence.Days.Wednesday ) &&
											( date.DayOfWeek != DayOfWeek.Thursday || !recurrence.Days.Thursday ) &&
											( date.DayOfWeek != DayOfWeek.Friday || !recurrence.Days.Friday ) &&
											( date.DayOfWeek != DayOfWeek.Saturday || !recurrence.Days.Saturday ) &&
											( date.DayOfWeek != DayOfWeek.Sunday || !recurrence.Days.Sunday ) ) ||
											!ValidWeek(recurrence,date) ) {
							date = date.AddDays( 1 );
						}
						break;
					}
				case RecurrenceMode.Monthly: {
						if( recurrence.Choice ) {
							//
							// Day 7 of every 2 months.
							//
							date = date.AddMonths( recurrence.Every );
							date = new DateTime( date.Year , date.Month , recurrence.DayOfMonth > DateTime.DaysInMonth( date.Year , date.Month ) ? DateTime.DaysInMonth( date.Year , date.Month ) : recurrence.DayOfMonth );
						} else {
							//
							// The first monday of every 2 months.
							//
							date = date.AddMonths( recurrence.Every );
							date = GetExactDate( recurrence , date );
						}
						break;
					}
				case RecurrenceMode.Yearly: {
						if( recurrence.Choice ) {
							//
							// Every July 7.
							//
							date = new DateTime( date.Year + 1 , (int)recurrence.Month + 1 , recurrence.DayOfMonth > DateTime.DaysInMonth( date.Year , (int)recurrence.Month + 1 ) ? DateTime.DaysInMonth( date.Year , (int)recurrence.Month + 1 ) : recurrence.DayOfMonth );
						} else {
							//
							// Every first monday of july.
							//
							date = date.AddYears( 1 );
							date = GetExactDate( recurrence , date );
						}
						break;
					}
			}
			return date;
		}

		private static bool ValidWeek( Recurrence recurrence , DateTime inWeek ) {
			DateTime start = recurrence.StartDate;
			while( start.StartOfWeek() < inWeek.StartOfWeek() ) {
				start = start.AddDays( 7 * recurrence.Every );
			}
			return ( inWeek.StartOfWeek() == start.StartOfWeek() );
		}

		

		private static DateTime GetExactDate( Recurrence recurrence , DateTime date ) {
			DateTime occurenceThisMonth = date;
			List<int> mondays = new List<int>();
			List<int> tuesdays = new List<int>();
			List<int> wednesdays = new List<int>();
			List<int> thursdays = new List<int>();
			List<int> fridays = new List<int>();
			List<int> saturdays = new List<int>();
			List<int> sundays = new List<int>();

			int month = 0;
			switch( recurrence.RecurrenceMode ) {
				case RecurrenceMode.Monthly: {
						month = date.Month;
						break;
					}
				case RecurrenceMode.Yearly: {
						month = (int)recurrence.Month + 1;
						break;
					}
			}

			for( int i = 1 ; i <= DateTime.DaysInMonth( date.Year , month ) ; i++ ) {
				switch( new DateTime( date.Year , month , i ).DayOfWeek ) {
					case DayOfWeek.Monday: {
							mondays.Add( i );
							break;
						}
					case DayOfWeek.Tuesday: {
							tuesdays.Add( i );
							break;
						}
					case DayOfWeek.Wednesday: {
							wednesdays.Add( i );
							break;
						}
					case DayOfWeek.Thursday: {
							thursdays.Add( i );
							break;
						}
					case DayOfWeek.Friday: {
							fridays.Add( i );
							break;
						}
					case DayOfWeek.Saturday: {
							saturdays.Add( i );
							break;
						}
					case DayOfWeek.Sunday: {
							sundays.Add( i );
							break;
						}
				}
			}
			switch( recurrence.Occurrence ) {
				case Occurrence.First: {
						switch( recurrence.Day ) {
							case Days.Monday: {
									occurenceThisMonth = new DateTime( date.Year , month , mondays[0] );
									break;
								}
							case Days.Tuesday: {
									occurenceThisMonth = new DateTime( date.Year , month , tuesdays[0] );
									break;
								}
							case Days.Wednesday: {
									occurenceThisMonth = new DateTime( date.Year , month , wednesdays[0] );
									break;
								}
							case Days.Thursday: {
									occurenceThisMonth = new DateTime( date.Year , month , thursdays[0] );
									break;
								}
							case Days.Friday: {
									occurenceThisMonth = new DateTime( date.Year , month , fridays[0] );
									break;
								}
							case Days.Saturday: {
									occurenceThisMonth = new DateTime( date.Year , month , saturdays[0] );
									break;
								}
							case Days.Sunday: {
									occurenceThisMonth = new DateTime( date.Year , month , sundays[0] );
									break;
								}
						}
						break;
					}
				case Occurrence.Second: {
						switch( recurrence.Day ) {
							case Days.Monday: {
									occurenceThisMonth = new DateTime( date.Year , month , mondays[1] );
									break;
								}
							case Days.Tuesday: {
									occurenceThisMonth = new DateTime( date.Year , month , tuesdays[1] );
									break;
								}
							case Days.Wednesday: {
									occurenceThisMonth = new DateTime( date.Year , month , wednesdays[1] );
									break;
								}
							case Days.Thursday: {
									occurenceThisMonth = new DateTime( date.Year , month , thursdays[1] );
									break;
								}
							case Days.Friday: {
									occurenceThisMonth = new DateTime( date.Year , month , fridays[1] );
									break;
								}
							case Days.Saturday: {
									occurenceThisMonth = new DateTime( date.Year , month , saturdays[1] );
									break;
								}
							case Days.Sunday: {
									occurenceThisMonth = new DateTime( date.Year , month , sundays[1] );
									break;
								}
						}
						break;
					}
				case Occurrence.Third: {
						switch( recurrence.Day ) {
							case Days.Monday: {
									occurenceThisMonth = new DateTime( date.Year , month , mondays[2] );
									break;
								}
							case Days.Tuesday: {
									occurenceThisMonth = new DateTime( date.Year , month , tuesdays[2] );
									break;
								}
							case Days.Wednesday: {
									occurenceThisMonth = new DateTime( date.Year , month , wednesdays[2] );
									break;
								}
							case Days.Thursday: {
									occurenceThisMonth = new DateTime( date.Year , month , thursdays[2] );
									break;
								}
							case Days.Friday: {
									occurenceThisMonth = new DateTime( date.Year , month , fridays[2] );
									break;
								}
							case Days.Saturday: {
									occurenceThisMonth = new DateTime( date.Year , month , saturdays[2] );
									break;
								}
							case Days.Sunday: {
									occurenceThisMonth = new DateTime( date.Year , month , sundays[2] );
									break;
								}
						}
						break;
					}
				case Occurrence.Fourth: {
						switch( recurrence.Day ) {
							case Days.Monday: {
									occurenceThisMonth = new DateTime( date.Year , month , mondays[3] );
									break;
								}
							case Days.Tuesday: {
									occurenceThisMonth = new DateTime( date.Year , month , tuesdays[3] );
									break;
								}
							case Days.Wednesday: {
									occurenceThisMonth = new DateTime( date.Year , month , wednesdays[3] );
									break;
								}
							case Days.Thursday: {
									occurenceThisMonth = new DateTime( date.Year , month , thursdays[3] );
									break;
								}
							case Days.Friday: {
									occurenceThisMonth = new DateTime( date.Year , month , fridays[3] );
									break;
								}
							case Days.Saturday: {
									occurenceThisMonth = new DateTime( date.Year , month , saturdays[3] );
									break;
								}
							case Days.Sunday: {
									occurenceThisMonth = new DateTime( date.Year , month , sundays[3] );
									break;
								}
						}
						break;
					}
				case Occurrence.Last: {
						switch( recurrence.Day ) {
							case Days.Monday: {
									occurenceThisMonth = new DateTime( date.Year , month , mondays[mondays.Count - 1] );
									break;
								}
							case Days.Tuesday: {
									occurenceThisMonth = new DateTime( date.Year , month , tuesdays[tuesdays.Count - 1] );
									break;
								}
							case Days.Wednesday: {
									occurenceThisMonth = new DateTime( date.Year , month , wednesdays[wednesdays.Count - 1] );
									break;
								}
							case Days.Thursday: {
									occurenceThisMonth = new DateTime( date.Year , month , thursdays[thursdays.Count - 1] );
									break;
								}
							case Days.Friday: {
									occurenceThisMonth = new DateTime( date.Year , month , fridays[fridays.Count - 1] );
									break;
								}
							case Days.Saturday: {
									occurenceThisMonth = new DateTime( date.Year , month , saturdays[saturdays.Count - 1] );
									break;
								}
							case Days.Sunday: {
									occurenceThisMonth = new DateTime( date.Year , month , sundays[sundays.Count - 1] );
									break;
								}
						}
						break;
					}
			}
			return occurenceThisMonth;
		}

	}

}
