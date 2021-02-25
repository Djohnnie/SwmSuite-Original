using SwmSuite.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SwmSuite.Framework.UnitTest
{
    
    /// <summary>
    ///This is a test class for ExtensionMethodsTest and is intended
    ///to contain all ExtensionMethodsTest Unit Tests
    ///</summary>
	[TestClass()]
	public class ExtensionMethodsTest {

		#region -_ Private Members _-

		private TestContext testContextInstance;

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext {
			get {
				return testContextInstance;
			}
			set {
				testContextInstance = value;
			}
		}

		#endregion

		#region -_ Additional Test Attributes _-
		// 
		//You can use the following additional attributes as you write your tests:
		//
		//Use ClassInitialize to run code before running the first test in the class
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//Use ClassCleanup to run code after all tests in a class have run
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//Use TestInitialize to run code before running each test
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//Use TestCleanup to run code after each test has run
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion

		/// <summary>
		/// A test for StartOfWeek
		/// </summary>
		[TestMethod]
		public void StartOfWeekTest() {
			Assert.AreEqual( new DateTime( 2009 , 2 , 16 ) , 
				new DateTime( 2009 , 2 , 16 ).StartOfWeek() );
			Assert.AreEqual( new DateTime( 2009 , 2 , 16 ) ,
				new DateTime( 2009 , 2 , 17 ).StartOfWeek() );
			Assert.AreEqual( new DateTime( 2009 , 2 , 16 ) ,
				new DateTime( 2009 , 2 , 18 ).StartOfWeek() );
			Assert.AreEqual( new DateTime( 2009 , 2 , 16 ) ,
				new DateTime( 2009 , 2 , 19 ).StartOfWeek() );
			Assert.AreEqual( new DateTime( 2009 , 2 , 16 ) ,
				new DateTime( 2009 , 2 , 20 ).StartOfWeek() );
			Assert.AreEqual( new DateTime( 2009 , 2 , 16 ) ,
				new DateTime( 2009 , 2 , 21 ).StartOfWeek() );
			Assert.AreEqual( new DateTime( 2009 , 2 , 16 ) ,
				new DateTime( 2009 , 2 , 22 ).StartOfWeek() );
			Assert.AreEqual( new DateTime( 2009 , 2 , 23 ) ,
				new DateTime( 2009 , 2 , 23 ).StartOfWeek() );
		}

		/// <summary>
		/// A test for EndOfWeek
		/// </summary>
		[TestMethod]
		public void EndOfWeekTest() {
			Assert.AreEqual( new DateTime( 2009 , 2 , 22 ) ,
				new DateTime( 2009 , 2 , 16 ).EndOfWeek() );
			Assert.AreEqual( new DateTime( 2009 , 2 , 22 ) ,
				new DateTime( 2009 , 2 , 17 ).EndOfWeek() );
			Assert.AreEqual( new DateTime( 2009 , 2 , 22 ) ,
				new DateTime( 2009 , 2 , 18 ).EndOfWeek() );
			Assert.AreEqual( new DateTime( 2009 , 2 , 22 ) ,
				new DateTime( 2009 , 2 , 19 ).EndOfWeek() );
			Assert.AreEqual( new DateTime( 2009 , 2 , 22 ) ,
				new DateTime( 2009 , 2 , 20 ).EndOfWeek() );
			Assert.AreEqual( new DateTime( 2009 , 2 , 22 ) ,
				new DateTime( 2009 , 2 , 21 ).EndOfWeek() );
			Assert.AreEqual( new DateTime( 2009 , 2 , 22 ) ,
				new DateTime( 2009 , 2 , 22 ).EndOfWeek() );
			Assert.AreEqual( new DateTime( 2009 , 3 , 1 ) ,
				new DateTime( 2009 , 2 , 23 ).EndOfWeek() );
		}

		/// <summary>
		/// A test for EndOfWeek
		/// </summary>
		[TestMethod]
		public void InWeekTest() {
			Assert.AreEqual( false ,
				new DateTime( 2009 , 2 , 16 ).InWeek( new DateTime( 2009 , 2 , 15 ) ) );
			Assert.AreEqual( true , 
				new DateTime( 2009 , 2 , 16 ).InWeek( new DateTime( 2009 , 2 , 16 ) ) );
			Assert.AreEqual( true ,
				new DateTime( 2009 , 2 , 16 ).InWeek( new DateTime( 2009 , 2 , 17 ) ) );
			Assert.AreEqual( true ,
				new DateTime( 2009 , 2 , 16 ).InWeek( new DateTime( 2009 , 2 , 18 ) ) );
			Assert.AreEqual( true ,
				new DateTime( 2009 , 2 , 16 ).InWeek( new DateTime( 2009 , 2 , 19 ) ) );
			Assert.AreEqual( true ,
				new DateTime( 2009 , 2 , 16 ).InWeek( new DateTime( 2009 , 2 , 20 ) ) );
			Assert.AreEqual( true ,
				new DateTime( 2009 , 2 , 16 ).InWeek( new DateTime( 2009 , 2 , 21 ) ) );
			Assert.AreEqual( true ,
				new DateTime( 2009 , 2 , 16 ).InWeek( new DateTime( 2009 , 2 , 22 ) ) );
			Assert.AreEqual( false ,
				new DateTime( 2009 , 2 , 16 ).InWeek( new DateTime( 2009 , 2 , 23 ) ) );
		}

	}

}
