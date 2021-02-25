using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;
using SwmSuite.Data.Common;

namespace SwmSuite.Data.BusinessObjects {

	/// <summary>
	/// Class defining a recurrence.
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class Recurrence : BusinessObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets a recurrencemode.
		/// </summary>
		public RecurrenceMode RecurrenceMode { get; set; }

		/// <summary>
		/// Gets or sets an interval for this recurrence.
		/// </summary>
		/// <remarks>
		/// Usable for the following recurrence modes:
		/// - Daily
		/// - Weekly
		/// - Monthly
		/// </remarks>
		public int Every { get; set; }

		/// <summary>
		/// Gets or sets wether this recurrence should occur every weekday.
		/// </summary>
		/// <remarks>
		/// Usable for the following recurrence modes:
		/// - Daily
		/// </remarks>
		public bool EveryWeekDay { get; set; }

		/// <summary>
		/// Gets or sets a selection of days for this recurrence.
		/// </summary>
		/// <remarks>
		/// Usable for the following recurrence modes:
		/// - Weekly
		/// </remarks>
		/// <example>Every 2 weeks on mondays and wednesdays.</example>
		public DaySelection Days { get; set; }

		/// <summary>
		/// Gets or sets the day of the month this recurrence should occur.
		/// </summary>
		/// <remarks>
		/// Usable for the following recurrence modes:
		/// - Monthly
		/// - Yearly
		/// Possible values in interval [1 - 31].
		/// </remarks>
		/// <example>
		/// - Day 7 of every 2 months.
		/// - Every 7th of July.
		/// </example>
		public int DayOfMonth { get; set; }

		/// <summary>
		/// Gets or sets the occurence.
		/// </summary>
		/// <remarks>
		/// Usable for the following recurrence modes:
		/// - Monthly
		/// - Yearly
		/// </remarks>
		/// <example>The first moday of every 2 months.</example>
		public Occurrence Occurrence { get; set; }

		/// <summary>
		/// Gets or sets the day for the recurrence.
		/// </summary>
		/// <remarks>
		/// Usable for the following recurrence modes:
		/// - Monthly
		/// - Yearly
		/// </remarks>
		/// <example>The first moday of every 2 months.</example>
		public Days Day { get; set; }

		/// <summary>
		/// Gets or sets the month for the recurrence.
		/// </summary>
		/// <remarks>
		/// Usable for the following recurrence modes:
		/// - Yearly
		/// </remarks>
		/// <example>
		/// - The first monday of every July.
		/// - Every 7th of July.
		/// </example>
		public Months Month { get; set; }

		public bool Choice { get; set; }

		/// <summary>
		/// Gets or sets the startdate for this recurrence.
		/// </summary>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// Gets or sets the end mode for this recurrence.
		/// </summary>
		public RecurrenceEndMode EndMode { get; set; }

		/// <summary>
		/// Gets or sets the number of occurences for this recurrence.
		/// </summary>
		public int Occurrences { get; set; }

		/// <summary>
		/// Gets or sets the enddate for this recurrence.
		/// </summary>
		public DateTime EndDate { get; set; }

		/// <summary>
		/// Gets or sets a description.
		/// </summary>
		public String Description { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public Recurrence() {
			this.Days = new DaySelection();
			this.StartDate = DateTime.Today;
			this.EndDate = DateTime.Today;
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Initialize this recurrence to be a daily recurrence.
		/// </summary>
		/// <param name="everyNumberOfDays">A number of days to pass between every occurrence.</param>
		/// <example>Every 2 days.</example>
		public void InitializeDailyRecurrence( int everyNumberOfDays ) {
			this.RecurrenceMode = RecurrenceMode.Daily;
			this.Every = everyNumberOfDays;
			this.EveryWeekDay = false;
		}

		/// <summary>
		/// Get a new recurrence as daily recurrence.
		/// </summary>
		/// <param name="everyNumberOfDays">A number of days to pass between every occurrence.</param>
		/// <returns>A new Recurrence</returns>
		/// <example>Every 2 days.</example>
		public static Recurrence GetDailyRecurrence( int everyNumberOfDays ) {
			Recurrence recurrenceToReturn = new Recurrence();
			recurrenceToReturn.InitializeDailyRecurrence( everyNumberOfDays );
			return recurrenceToReturn;
		}

		/// <summary>
		/// Initialize this recurrence to be a daily recurrence.
		/// </summary>
		/// <example>Every weekday.</example>
		public void InitializeDailyRecurrence() {
			this.RecurrenceMode = RecurrenceMode.Daily;
			this.EveryWeekDay = true;
		}

		/// <summary>
		/// Get a new recurrence as daily recurrence.
		/// </summary>
		/// <example>Every weekday.</example>
		public static Recurrence GetDailyRecurrence() {
			Recurrence recurrenceToReturn = new Recurrence();
			recurrenceToReturn.InitializeDailyRecurrence();
			return recurrenceToReturn;
		}

		/// <summary>
		/// Initialize this recurrence to be a weekly recurrence.
		/// </summary>
		/// <param name="everyNumberOfWeeks">A number of weeks to pass between every occurrence.</param>
		/// <param name="daySelection">A selection of days for the occurrence.</param>
		/// <example>Every 2 weeks on mondays and wednesdays.</example>
		public void InitializeWeeklyRecurrence( int everyNumberOfWeeks , DaySelection daySelection ) {
			this.RecurrenceMode = RecurrenceMode.Weekly;
			this.Every = everyNumberOfWeeks;
			this.Days = daySelection;
		}

		/// <summary>
		/// Get a new recurrence as weekly recurrence.
		/// </summary>
		/// <param name="everyNumberOfWeeks">A number of weeks to pass between every occurrence.</param>
		/// <param name="daySelection">A selection of days for the occurrence.</param>
		/// <example>Every 2 weeks on mondays and wednesdays.</example>
		public static Recurrence GetWeeklyRecurrence( int everyNumberOfWeeks , DaySelection daySelection ) {
			Recurrence recurrenceToReturn = new Recurrence();
			recurrenceToReturn.InitializeWeeklyRecurrence( everyNumberOfWeeks , daySelection );
			return recurrenceToReturn;
		}

		/// <summary>
		/// Initialize this recurrence to be a monthly recurrence.
		/// </summary>
		/// <param name="dayOfMonth">The day of month on wich the recurrence will occur.</param>
		/// <param name="every">A number of months to pass between occurrences.</param>
		/// <example>The 7th of every 3 months.</example>
		public void InitializeMonthlyRecurrence( int dayOfMonth , int every ) {
			this.RecurrenceMode = RecurrenceMode.Monthly;
			this.DayOfMonth = dayOfMonth;
			this.Every = every;
		}

		/// <summary>
		/// Get a new recurrence as monthly recurrence.
		/// </summary>
		/// <param name="dayOfMonth">The day of month on wich the recurrence will occur.</param>
		/// <param name="every">A number of months to pass between occurrences.</param>
		/// <example>The 7th of every 3 months.</example>
		public static Recurrence GetMonthlyRecurrence( int dayOfMonth , int every ) {
			Recurrence recurrenceToReturn = new Recurrence();
			recurrenceToReturn.InitializeMonthlyRecurrence( dayOfMonth , every );
			return recurrenceToReturn;
		}

		/// <summary>
		/// Initialize this recurrence to be a monthly recurrence.
		/// </summary>
		/// <param name="occurrence">An occurrence this recurrence will occur.</param>
		/// <param name="day">A day of week this recurrence will occur.</param>
		/// <param name="every">A number of months to pass between occurrences.</param>
		/// <example>The first monday of every 5 months.</example>
		public void InitializeMonthlyRecurrence( Occurrence occurrence , Days day , int every ) {
			this.RecurrenceMode = RecurrenceMode.Monthly;
			this.Occurrence = occurrence;
			this.Day = day;
			this.Every = every;
		}

		/// <summary>
		/// Get a new recurrence as monthly recurrence.
		/// </summary>
		/// <param name="occurrence">An occurrence this recurrence will occur.</param>
		/// <param name="day">A day of week this recurrence will occur.</param>
		/// <param name="every">A number of months to pass between occurrences.</param>
		/// <example>The first monday of every 5 months.</example>
		public static Recurrence GetMonthlyRecurrence( Occurrence occurrence , Days day , int every ) {
			Recurrence recurrenceToReturn = new Recurrence();
			recurrenceToReturn.InitializeMonthlyRecurrence( occurrence , day , every );
			return recurrenceToReturn;
		}

		/// <summary>
		/// Initialize this recurrence to be a yearly recurrence.
		/// </summary>
		/// <param name="month">A month this recurrence will occur.</param>
		/// <param name="dayOfMonth">The day of month on wich the recurrence will occur.</param>
		/// <example>Every 4th of July.</example>
		public void InitializeYearlyRecurrence( Months month , int dayOfMonth ) {
			this.RecurrenceMode = RecurrenceMode.Yearly;
			this.Month = month;
			this.DayOfMonth = dayOfMonth;
		}

		/// <summary>
		/// Get a new recurrence as yearly recurrence.
		/// </summary>
		/// <param name="month">A month this recurrence will occur.</param>
		/// <param name="dayOfMonth">The day of month on wich the recurrence will occur.</param>
		/// <example>Every 4th of July.</example>
		public static Recurrence GetYearlyRecurrence( Months month , int dayOfMonth ) {
			Recurrence recurrenceToReturn = new Recurrence();
			recurrenceToReturn.InitializeYearlyRecurrence( month , dayOfMonth );
			return recurrenceToReturn;
		}


		/// <summary>
		/// Initialize this recurrence to be a yearly recurrence.
		/// </summary>
		/// <param name="occurrence">An occurrence this recurrence will occur.</param>
		/// <param name="day">A day of week this recurrence will occur.</param>
		/// <param name="month"A month this recurrence will occur.</param>
		/// <example>The first monday of July.</example>
		public void InitializeYearlyRecurrence( Occurrence occurrence , Days day , Months month ) {
			this.RecurrenceMode = RecurrenceMode.Monthly;
			this.Occurrence = occurrence;
			this.Day = day;
			this.Month = month;
		}

		/// <summary>
		/// Get a new recurrence as yearly recurrence.
		/// </summary>
		/// <param name="occurrence">An occurrence this recurrence will occur.</param>
		/// <param name="day">A day of week this recurrence will occur.</param>
		/// <param name="month"A month this recurrence will occur.</param>
		/// <example>The first monday of July.</example>
		public static Recurrence GetYearlyRecurrence( Occurrence occurrence , Days day , Months month ) {
			Recurrence recurrenceToReturn = new Recurrence();
			recurrenceToReturn.InitializeYearlyRecurrence( occurrence , day , month );
			return recurrenceToReturn;
		}

		#endregion

	}

}
