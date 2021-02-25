using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.Common;
using System.Diagnostics;

namespace SwmSuite.Business.UnitTest {

	[TestClass()]
	public class RecurrenceCoreTest {

		#region -_ Private Members _-

		private TestContext testContextInstance;

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the test context which provides
		/// information about and functionality for the current test run.
		/// </summary>
		public TestContext TestContext {
			get {
				return testContextInstance;
			}
			set {
				testContextInstance = value;
			}
		}

		#endregion

		#region -_ Additional test attributes _-

		[ClassInitialize()]
		public static void MyClassInitialize( TestContext testContext ) {
		}

		[ClassCleanup()]
		public static void MyClassCleanup() {
		}

		[TestInitialize()]
		public void MyTestInitialize() {
		}

		[TestCleanup()]
		public void MyTestCleanup() {
		}

		#endregion

		#region -_ RecurrenceCore Test Methods _-

		#region -_ Daily _-

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_EveryDay() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 1 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Daily;
			recurrence.Every = 1;

			Assert.AreEqual( new DateTime( 2000 , 1 , 10 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_Every2Days() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 1 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Daily;
			recurrence.Every = 2;

			Assert.AreEqual( new DateTime( 2000 , 1 , 19 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_Every3Days() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 1 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Daily;
			recurrence.Every = 3;

			Assert.AreEqual( new DateTime( 2000 , 1 , 28 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_EveryWeekDay() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 1 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Daily;
			recurrence.EveryWeekDay = true;

			Assert.AreEqual( new DateTime( 2000 , 1 , 14 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		#endregion

		#region -_ Weekly _-

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_Weekly_1() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 1 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Weekly;
			recurrence.Days = new DaySelection() {
				Monday = true ,
				Tuesday = true ,
				Wednesday = true ,
				Thursday = true ,
				Friday = true ,
				Saturday = true ,
				Sunday = true
			};
			recurrence.Every = 1;

			Assert.AreEqual( new DateTime( 2000 , 1 , 10 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_Weekly_2() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 1 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Weekly;
			recurrence.Days = new DaySelection() {
				Monday = true ,
				Tuesday = true ,
				Wednesday = true ,
				Thursday = true ,
				Friday = true ,
				Saturday = true ,
				Sunday = true
			};
			recurrence.Every = 2;

			Assert.AreEqual( new DateTime( 2000 , 1 , 24 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_Weekly_3() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 3 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Weekly;
			recurrence.Days = new DaySelection() {
				Monday = true ,
				Tuesday = true ,
				Wednesday = true ,
				Thursday = true ,
				Friday = true ,
				Saturday = true ,
				Sunday = true
			};
			recurrence.Every = 1;

			Assert.AreEqual( new DateTime( 2000 , 1 , 12 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_Weekly_4() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 3 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Weekly;
			recurrence.Days = new DaySelection() {
				Monday = true ,
				Tuesday = true ,
				Wednesday = true ,
				Thursday = true ,
				Friday = true ,
				Saturday = true ,
				Sunday = true
			};
			recurrence.Every = 2;

			Assert.AreEqual( new DateTime( 2000 , 1 , 19 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_Weekly_5() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 1 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Weekly;
			recurrence.Days = new DaySelection() {
				Monday = false ,
				Tuesday = true ,
				Wednesday = false ,
				Thursday = false ,
				Friday = false ,
				Saturday = true ,
				Sunday = false
			};
			recurrence.Every = 1;

			Assert.AreEqual( new DateTime( 2000 , 2 , 1 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_Weekly_6() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 1 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Weekly;
			recurrence.Days = new DaySelection() {
				Monday = false ,
				Tuesday = true ,
				Wednesday = false ,
				Thursday = false ,
				Friday = false ,
				Saturday = true ,
				Sunday = false
			};
			recurrence.Every = 2;

			Assert.AreEqual( new DateTime( 2000 , 3 , 7 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		#endregion

		#region -_ Monthly _-

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_Day1EveryMonth_1() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 1 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Monthly;
			recurrence.Choice = true;
			recurrence.DayOfMonth = 1;
			recurrence.Every = 1;

			Assert.AreEqual( new DateTime( 2000 , 10 , 1 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_Day1EveryMonth_2() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 2 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Monthly;
			recurrence.Choice = true;
			recurrence.DayOfMonth = 1;
			recurrence.Every = 1;

			Assert.AreEqual( new DateTime( 2000 , 11 , 1 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_Day1EveryMonth_3() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 1999 , 12 , 31 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Monthly;
			recurrence.Choice = true;
			recurrence.DayOfMonth = 1;
			recurrence.Every = 1;

			Assert.AreEqual( new DateTime( 2000 , 10 , 1 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_Day1Every2Month_1() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 1 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Monthly;
			recurrence.Choice = true;
			recurrence.DayOfMonth = 1;
			recurrence.Every = 2;

			Assert.AreEqual( new DateTime( 2001 , 7 , 1 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_Day1Every2Month_2() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 2 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Monthly;
			recurrence.Choice = true;
			recurrence.DayOfMonth = 1;
			recurrence.Every = 2;

			Assert.AreEqual( new DateTime( 2001 , 8 , 1 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_Day1Every2Month_3() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 1999 , 12 , 31 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Monthly;
			recurrence.Choice = true;
			recurrence.DayOfMonth = 1;
			recurrence.Every = 2;

			Assert.AreEqual( new DateTime( 2001 , 7 , 1 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_Day31EveryMonth_1() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 1 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Monthly;
			recurrence.Choice = true;
			recurrence.DayOfMonth = 31;
			recurrence.Every = 1;

			Assert.AreEqual( new DateTime( 2000 , 10 , 31 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_Day31EveryMonth_2() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 2 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Monthly;
			recurrence.Choice = true;
			recurrence.DayOfMonth = 31;
			recurrence.Every = 1;

			Assert.AreEqual( new DateTime( 2000 , 10 , 31 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_Day31EveryMonth_3() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 31 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Monthly;
			recurrence.Choice = true;
			recurrence.DayOfMonth = 31;
			recurrence.Every = 1;

			Assert.AreEqual( new DateTime( 2000 , 10 , 31 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_FirstMondayEveryMonth_1() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 3 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Monthly;
			recurrence.Choice = false;
			recurrence.Occurrence = Occurrence.First;
			recurrence.Day = Days.Monday;
			recurrence.Every = 1;

			Assert.AreEqual( new DateTime( 2000 , 10 , 2 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_FirstMondayEveryMonth_2() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 4 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Monthly;
			recurrence.Choice = false;
			recurrence.Occurrence = Occurrence.First;
			recurrence.Day = Days.Monday;
			recurrence.Every = 1;

			Assert.AreEqual( new DateTime( 2000 , 11 , 6 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_FirstMondayEveryMonth_3() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 1 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Monthly;
			recurrence.Choice = false;
			recurrence.Occurrence = Occurrence.First;
			recurrence.Day = Days.Monday;
			recurrence.Every = 1;

			Assert.AreEqual( new DateTime( 2000 , 10 , 2 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_SecondTuesdayEvery2Months() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 11 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Monthly;
			recurrence.Choice = false;
			recurrence.Occurrence = Occurrence.Second;
			recurrence.Day = Days.Tuesday;
			recurrence.Every = 2;

			Assert.AreEqual( new DateTime( 2001 , 7 , 10 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_ThirdWednesdayEvery2Months() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 19 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Monthly;
			recurrence.Choice = false;
			recurrence.Occurrence = Occurrence.Third;
			recurrence.Day = Days.Wednesday;
			recurrence.Every = 2;

			Assert.AreEqual( new DateTime( 2001 , 7 , 18 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_FourthThirsdayEvery2Months() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 27 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Monthly;
			recurrence.Choice = false;
			recurrence.Occurrence = Occurrence.Fourth;
			recurrence.Day = Days.Thursday;
			recurrence.Every = 2;

			Assert.AreEqual( new DateTime( 2001 , 7 , 26 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_LastFridayEvery2Months() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 28 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Monthly;
			recurrence.Choice = false;
			recurrence.Occurrence = Occurrence.Last;
			recurrence.Day = Days.Friday;
			recurrence.Every = 2;

			Assert.AreEqual( new DateTime( 2001 , 7 , 27 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		#endregion

		#region -_ Yearly _-

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_EveryMonthDay_1() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 1 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Yearly;
			recurrence.Choice = true;
			recurrence.Month = SwmSuite.Data.BusinessObjects.Months.July;
			recurrence.DayOfMonth = 7;

			Assert.AreEqual( new DateTime( 2009 , 7 , 7 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_EveryMonthDay_2() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 7 , 7 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Yearly;
			recurrence.Choice = true;
			recurrence.Month = SwmSuite.Data.BusinessObjects.Months.July;
			recurrence.DayOfMonth = 7;

			Assert.AreEqual( new DateTime( 2009 , 7 , 7 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_EveryMonthDay_3() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 7 , 8 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Yearly;
			recurrence.Choice = true;
			recurrence.Month = SwmSuite.Data.BusinessObjects.Months.July;
			recurrence.DayOfMonth = 7;

			Assert.AreEqual( new DateTime( 2010 , 7 , 7 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_EveryNumberDayOfMonth_1() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 1 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Yearly;
			recurrence.Choice = false;
			recurrence.Occurrence = Occurrence.First;
			recurrence.Day = Days.Monday;
			recurrence.Month = SwmSuite.Data.BusinessObjects.Months.July;

			Assert.AreEqual( new DateTime( 2009 , 7 , 6 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_EveryNumberDayOfMonth_2() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 7 , 3 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Yearly;
			recurrence.Choice = false;
			recurrence.Occurrence = Occurrence.First;
			recurrence.Day = Days.Monday;
			recurrence.Month = SwmSuite.Data.BusinessObjects.Months.July;

			Assert.AreEqual( new DateTime( 2009 , 7 , 6 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		[TestMethod]
		public void CalculateRecurrenceEndDateTest_EveryNumberDayOfMonth_3() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 7 , 4 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 10;

			recurrence.RecurrenceMode = RecurrenceMode.Yearly;
			recurrence.Choice = false;
			recurrence.Occurrence = Occurrence.First;
			recurrence.Day = Days.Monday;
			recurrence.Month = SwmSuite.Data.BusinessObjects.Months.July;

			Assert.AreEqual( new DateTime( 2010 , 7 , 5 ) ,
				RecurrenceCore.CalculateRecurrenceEndDate( recurrence ) );
		}

		#endregion

		#region -_ IsValid TestMethods _-

		[TestMethod]
		public void IsValidTest_01() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 1 );
			recurrence.EndMode = RecurrenceEndMode.Infinite;

			Assert.IsFalse( RecurrenceCore.IsValid( recurrence , new DateTime( 1999 , 12 , 31 ) ) );
			Assert.IsTrue( RecurrenceCore.IsValid( recurrence , new DateTime( 2000 , 1 , 1 ) ) );
			Assert.IsTrue( RecurrenceCore.IsValid( recurrence , new DateTime( 2010 , 1 , 1 ) ) );
		}

		[TestMethod]
		public void IsValidTest_02() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 1 );
			recurrence.EndMode = RecurrenceEndMode.ByDate;
			recurrence.EndDate = new DateTime( 2000 , 1 , 31 );

			Assert.IsFalse( RecurrenceCore.IsValid( recurrence , new DateTime( 1999 , 12 , 31 ) ) );
			Assert.IsTrue( RecurrenceCore.IsValid( recurrence , new DateTime( 2000 , 1 , 1 ) ) );
			Assert.IsFalse( RecurrenceCore.IsValid( recurrence , new DateTime( 2000 , 2 , 1 ) ) );
		}

		[TestMethod]
		public void IsValidTest_03() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 1 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 31;

			recurrence.RecurrenceMode = RecurrenceMode.Daily;
			recurrence.Every = 1;
			recurrence.EveryWeekDay = false;

			Assert.IsFalse( RecurrenceCore.IsValid( recurrence , new DateTime( 1999 , 12 , 31 ) ) );
			Assert.IsTrue( RecurrenceCore.IsValid( recurrence , new DateTime( 2000 , 1 , 1 ) ) );
			Assert.IsFalse( RecurrenceCore.IsValid( recurrence , new DateTime( 2000 , 2 , 1 ) ) );
		}

		#endregion

		#region IsInRecurrence TestMethods _-

		[TestMethod]
		public void IsInRecurrenceTest_01() {
			Recurrence recurrence = new Recurrence();
			recurrence.StartDate = new DateTime( 2000 , 1 , 1 );
			recurrence.EndMode = RecurrenceEndMode.ByNumber;
			recurrence.Occurrences = 31;

			recurrence.RecurrenceMode = RecurrenceMode.Daily;
			recurrence.Every = 1;
			recurrence.EveryWeekDay = false;

			DateTime[] validDateTimes = new DateTime[]{
				new DateTime( 2000 , 1 ,  1 ), new DateTime( 2000 , 1 ,  2 ),
				new DateTime( 2000 , 1 ,  3 ), new DateTime( 2000 , 1 ,  4 ),
				new DateTime( 2000 , 1 ,  5 ), new DateTime( 2000 , 1 ,  6 ),
				new DateTime( 2000 , 1 ,  7 ), new DateTime( 2000 , 1 ,  8 ),
				new DateTime( 2000 , 1 ,  9 ), new DateTime( 2000 , 1 , 10 ),
				new DateTime( 2000 , 1 , 11 ), new DateTime( 2000 , 1 , 12 ),
				new DateTime( 2000 , 1 , 13 ), new DateTime( 2000 , 1 , 14 ),
				new DateTime( 2000 , 1 , 15 ), new DateTime( 2000 , 1 , 16 ),
				new DateTime( 2000 , 1 , 17 ), new DateTime( 2000 , 1 , 18 ),
				new DateTime( 2000 , 1 , 19 ), new DateTime( 2000 , 1 , 20 ),
				new DateTime( 2000 , 1 , 21 ), new DateTime( 2000 , 1 , 22 ),
				new DateTime( 2000 , 1 , 23 ), new DateTime( 2000 , 1 , 24 ),
				new DateTime( 2000 , 1 , 25 ), new DateTime( 2000 , 1 , 26 ),
				new DateTime( 2000 , 1 , 27 ), new DateTime( 2000 , 1 , 28 ),
				new DateTime( 2000 , 1 , 29 ), new DateTime( 2000 , 1 , 30 ),
				new DateTime( 2000 , 1 , 31 ) 
			};
			DateTime dateTimeToTest = new DateTime( 1999 , 1 , 1 );
			while( dateTimeToTest < new DateTime( 2001 , 1 , 1 ) ) {
				Stopwatch stopwatch = Stopwatch.StartNew();
				if( validDateTimes.Contains( dateTimeToTest ) ) {
					Assert.IsTrue( RecurrenceCore.IsInRecurrence( recurrence , dateTimeToTest ) );
				} else {
					Assert.IsFalse( RecurrenceCore.IsInRecurrence( recurrence , dateTimeToTest ) );
				}
				stopwatch.Stop();
				Debug.WriteLine( "IsInRecurrence took " + stopwatch.ElapsedMilliseconds.ToString() + " ms. [" + stopwatch.ElapsedTicks.ToString() + " ticks]" );
				dateTimeToTest = dateTimeToTest.AddDays( 1 );
			}
		}

		#endregion

		#endregion

	}

}
