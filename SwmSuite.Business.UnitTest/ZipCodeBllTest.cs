using System;
using System.Collections.Generic;

using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using SwmSuite.Business;
using SwmSuite.Data.DataObjects;
using SwmSuite.Business.UnitTest.UnitTestHelper;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Business.UnitTest {

	/// <summary>
	/// Unittestclass to test the ZipCodeBll methods.
	/// </summary>
	[TestClass()]
	public class ZipCodeBllTest : IDisposable {

		#region -_ Private Members _-

		private TestContext testContextInstance;

		private TransactionScope mainScope;

		private ZipCodeBll zipcodeBll = new ZipCodeBll();
		private CountryBll countryBll = new CountryBll();

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

		[ClassInitialize()]
		public static void MyClassInitialize( TestContext testContext ) {
		}

		[ClassCleanup()]
		public static void MyClassCleanup() {
		}

		[TestInitialize()]
		public void MyTestInitialize() {
			mainScope = new TransactionScope( TransactionScopeOption.Required );
			UnitTestUtils.ClearDatabase();
		}

		[TestCleanup()]
		public void MyTestCleanup() {
			//mainScope.Complete();
			mainScope.Dispose();
		}

		#endregion

		#region -_ Business Test Methods _-

		[TestMethod]
		public void Business_GetZipCodesTest() {
			// Country test data.
			Country testCountry1 = countryBll.CreateCountry( new Country( "Belgium" ) );

			ZipCode zipcodeCreated1 = new ZipCode( "2850" , "Boom" );
			ZipCode zipcodeCreated2 = new ZipCode( "1880" , "Kapelle-op-den-Bos" );
			ZipCode zipcodeCreated3 = new ZipCode( "1000" , "Brussel" );
			zipcodeBll.CreateZipCode( zipcodeCreated1 , testCountry1 );
			zipcodeBll.CreateZipCode( zipcodeCreated2 , testCountry1 );
			zipcodeBll.CreateZipCode( zipcodeCreated3 , testCountry1 );

			ZipCodeCollection zipcodesResult = zipcodeBll.GetZipCodes( );
			Assert.AreEqual( 3 , zipcodesResult.Count );
			Assert.AreEqual( "2850" , zipcodesResult[0].Code );
			Assert.AreEqual( "Boom" , zipcodesResult[0].City );
			Assert.AreEqual( "Belgium" , zipcodesResult[0].Country );
			Assert.AreEqual( "1880" , zipcodesResult[1].Code );
			Assert.AreEqual( "Kapelle-op-den-Bos" , zipcodesResult[1].City );
			Assert.AreEqual( "Belgium" , zipcodesResult[1].Country );
			Assert.AreEqual( "1000" , zipcodesResult[2].Code );
			Assert.AreEqual( "Brussel" , zipcodesResult[2].City );
			Assert.AreEqual( "Belgium" , zipcodesResult[2].Country );
		}

		[TestMethod]
		public void Business_GetZipCodesByCountryTest() {
			// Country test data.
			Country testCountry1 = countryBll.CreateCountry( new Country( "Belgium" ) );
			Country testCountry2 = countryBll.CreateCountry( new Country( "France" ) );

			ZipCode zipcodeCreated1 = new ZipCode( "2850" , "Boom" );
			ZipCode zipcodeCreated2 = new ZipCode( "1880" , "Kapelle-op-den-Bos" );
			ZipCode zipcodeCreated3 = new ZipCode( "1000" , "Brussel" );
			ZipCode zipcodeCreated4 = new ZipCode( "04120" , "Castellane" );
			zipcodeBll.CreateZipCode( zipcodeCreated1 , testCountry1 );
			zipcodeBll.CreateZipCode( zipcodeCreated2 , testCountry1 );
			zipcodeBll.CreateZipCode( zipcodeCreated3 , testCountry1 );
			zipcodeBll.CreateZipCode( zipcodeCreated4 , testCountry2 );

			ZipCodeCollection zipcodesResult = zipcodeBll.GetZipCodesByCountry( testCountry1 );
			Assert.AreEqual( 3 , zipcodesResult.Count );
			Assert.AreEqual( "2850" , zipcodesResult[0].Code );
			Assert.AreEqual( "Boom" , zipcodesResult[0].City );
			Assert.AreEqual( "Belgium" , zipcodesResult[0].Country );
			Assert.AreEqual( "1880" , zipcodesResult[1].Code );
			Assert.AreEqual( "Kapelle-op-den-Bos" , zipcodesResult[1].City );
			Assert.AreEqual( "Belgium" , zipcodesResult[1].Country );
			Assert.AreEqual( "1000" , zipcodesResult[2].Code );
			Assert.AreEqual( "Brussel" , zipcodesResult[2].City );
			Assert.AreEqual( "Belgium" , zipcodesResult[2].Country );
		}

		[TestMethod]
		public void Business_GetZipCodeTest() {
			// Country test data.
			Country testCountry = countryBll.CreateCountry( new Country( "Belgium" ) );

			ZipCode zipcodeCreated1 = new ZipCode( "2850" , "Boom" );
			ZipCode zipcodeCreated2 = new ZipCode( "1880" , "Kapelle-op-den-Bos" );
			ZipCode zipcodeCreated3 = new ZipCode( "1000" , "Brussel" );
			zipcodeBll.CreateZipCode( zipcodeCreated1 , testCountry );
			zipcodeBll.CreateZipCode( zipcodeCreated2 , testCountry );
			zipcodeBll.CreateZipCode( zipcodeCreated3 , testCountry );

			ZipCodeCollection zipcodesResult = zipcodeBll.GetZipCodes();
			ZipCode zipcodeResult = zipcodeBll.GetZipCode( zipcodesResult[1].SysId );

			Assert.AreEqual( "1880" , zipcodeResult.Code );
			Assert.AreEqual( "Kapelle-op-den-Bos" , zipcodeResult.City );
			Assert.AreEqual( "Belgium" , zipcodeResult.Country );
		}

		[TestMethod]
		public void Business_CreateZipCodeTest() {
			// Country test data.
			Country testCountry = countryBll.CreateCountry( new Country( "Belgium" ) );

			ZipCode zipcodeToCreate = new ZipCode( "2850" , "Boom" );
			zipcodeBll.CreateZipCode( zipcodeToCreate , testCountry );

			ZipCodeCollection zipcodesResult = zipcodeBll.GetZipCodes();
			Assert.AreEqual( 1 , zipcodesResult.Count );
			Assert.AreEqual( "2850" , zipcodesResult[0].Code );
			Assert.AreEqual( "Boom" , zipcodesResult[0].City );
			Assert.AreEqual( "Belgium" , zipcodesResult[0].Country );
		}

		[TestMethod]
		public void Business_UpdateZipCodeTest() {
			// Country test data.
			Country testCountry = countryBll.CreateCountry( new Country( "Belgium" ) );

			ZipCode zipcodeCreated = zipcodeBll.CreateZipCode( new ZipCode( "2850" , "Boom" ) , testCountry );
			zipcodeCreated.Code = "1000";
			zipcodeCreated.City = "Brussel";
			ZipCode zipcodeUpdated = zipcodeBll.UpdateZipCode( zipcodeCreated , testCountry );

			Assert.AreEqual( zipcodeCreated.SysId , zipcodeUpdated.SysId );
			Assert.AreEqual( zipcodeCreated.City , zipcodeUpdated.City );
			Assert.AreEqual( zipcodeCreated.Code , zipcodeUpdated.Code );
			Assert.AreEqual( zipcodeCreated.Country , zipcodeUpdated.Country );
		}

		[TestMethod]
		public void Business_RemoveZipCodesTest() {
			// Country test data.
			Country testCountry = countryBll.CreateCountry( new Country( "Belgium" ) );

			ZipCode zipcodeCreated1 = new ZipCode( "2850" , "Boom" );
			ZipCode zipcodeCreated2 = new ZipCode( "1880" , "Kapelle-op-den-Bos" );
			ZipCode zipcodeCreated3 = new ZipCode( "1000" , "Brussel" );
			zipcodeBll.CreateZipCode( zipcodeCreated1 , testCountry );
			zipcodeBll.CreateZipCode( zipcodeCreated2 , testCountry );
			zipcodeBll.CreateZipCode( zipcodeCreated3 , testCountry );

			ZipCodeCollection zipcodesToRemove = zipcodeBll.GetZipCodes();

			zipcodeBll.RemoveZipCodes( zipcodesToRemove );

			ZipCodeCollection zipcodesResult = zipcodeBll.GetZipCodes();
			Assert.AreEqual( 0 , zipcodesResult.Count );
		}

		#endregion

		#region -_ Crud Test Methods _-

		/// <summary>
		/// A test for InsertZipCodes (insert a single zipcode).
		/// </summary>
		[TestMethod]
		public void Crud_InsertZipCodeTest() {
			CountryData countryTestData = CountryUnitTestHelper.GetCountryTestData();

			ZipCodeDataCollection zipCodes =
				ZipCodeDataCollection.FromSingleZipCode( new ZipCodeData( "2850" , "Boom" , countryTestData.SysId ) );
			zipcodeBll.InsertZipCodeData( zipCodes );
			ZipCodeDataCollection zipCodesResult = zipcodeBll.GetZipCodeData();
			ZipCodeUnitTestHelper.AreEqual( zipCodes , zipCodesResult );
		}

		/// <summary>
		/// A test for InsertZipCodes (insert multiple zipCodes).
		/// </summary>
		[TestMethod]
		public void Crud_InsertZipCodesTest() {
			CountryData countryTestData = CountryUnitTestHelper.GetCountryTestData();

			ZipCodeDataCollection zipCodes = new ZipCodeDataCollection();
			zipCodes.Add( new ZipCodeData( "2850" , "Boom" , countryTestData.SysId ) );
			zipCodes.Add( new ZipCodeData( "2845" , "Niel" , countryTestData.SysId ) );
			zipCodes.Add( new ZipCodeData( "2650" , "Edegem" , countryTestData.SysId ) );
			zipcodeBll.InsertZipCodeData( zipCodes );
			ZipCodeDataCollection zipCodesResult = zipcodeBll.GetZipCodeData();
			ZipCodeUnitTestHelper.AreEqual( zipCodes , zipCodesResult );
		}

		/// <summary>
		/// A test for UpdateZipCodes (update a single zipcode).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateZipCodeTest() {
			CountryData countryTestData = CountryUnitTestHelper.GetCountryTestData();

			ZipCodeDataCollection zipCodes =
				ZipCodeDataCollection.FromSingleZipCode( new ZipCodeData( "2850" , "Boom" , countryTestData.SysId ) );
			zipcodeBll.InsertZipCodeData( zipCodes );
			ZipCodeDataCollection zipCodesToUpdate = zipcodeBll.GetZipCodeData();
			ZipCodeUnitTestHelper.UpdateZipCodes( zipCodesToUpdate );
			zipcodeBll.UpdateZipCodeData( zipCodesToUpdate );
			ZipCodeDataCollection zipCodesResult = zipcodeBll.GetZipCodeData();
			ZipCodeUnitTestHelper.AreEqual( zipCodesToUpdate , zipCodesResult );
		}

		/// <summary>
		/// A test for UpdateZipCodes (update multiple zipCodes).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateZipCodesTest() {
			CountryData countryTestData = CountryUnitTestHelper.GetCountryTestData();

			ZipCodeDataCollection zipCodes = new ZipCodeDataCollection();
			zipCodes.Add( new ZipCodeData( "2850" , "Boom" , countryTestData.SysId ) );
			zipCodes.Add( new ZipCodeData( "2845" , "Niel" , countryTestData.SysId ) );
			zipCodes.Add( new ZipCodeData( "2650" , "Edegem" , countryTestData.SysId ) );
			zipcodeBll.InsertZipCodeData( zipCodes );
			ZipCodeDataCollection zipCodesToUpdate = zipcodeBll.GetZipCodeData();
			ZipCodeUnitTestHelper.UpdateZipCodes( zipCodesToUpdate );
			zipcodeBll.UpdateZipCodeData( zipCodesToUpdate );
			ZipCodeDataCollection zipCodesResult = zipcodeBll.GetZipCodeData();
			ZipCodeUnitTestHelper.AreEqual( zipCodesToUpdate , zipCodesResult );
		}

		/// <summary>
		/// A test for RemoveZipCodes (remove a single zipcode).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveZipCodeTest() {
			CountryData countryTestData = CountryUnitTestHelper.GetCountryTestData();

			ZipCodeDataCollection zipCodes =
				ZipCodeDataCollection.FromSingleZipCode( new ZipCodeData( "2850" , "Boom" , countryTestData.SysId ) );
			zipcodeBll.InsertZipCodeData( zipCodes );
			ZipCodeDataCollection zipCodesToRemove = zipcodeBll.GetZipCodeData();
			zipcodeBll.RemoveZipCodeData( zipCodesToRemove );
			ZipCodeDataCollection zipCodesResult = zipcodeBll.GetZipCodeData();
			Assert.AreEqual( 0 , zipCodesResult.Count , "The zipCodes should be removed!" );
			ZipCodeUnitTestHelper.AreInLogDeletes( zipCodesToRemove );
		}

		/// <summary>
		/// A test for RemoveZipCodes (remove multiple zipCodes).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveZipCodesTest() {
			CountryData countryTestData = CountryUnitTestHelper.GetCountryTestData();

			ZipCodeDataCollection zipCodes = new ZipCodeDataCollection();
			zipCodes.Add( new ZipCodeData( "2850" , "Boom" , countryTestData.SysId ) );
			zipCodes.Add( new ZipCodeData( "2845" , "Niel" , countryTestData.SysId ) );
			zipCodes.Add( new ZipCodeData( "2650" , "Edegem" , countryTestData.SysId ) );
			zipcodeBll.InsertZipCodeData( zipCodes );
			ZipCodeDataCollection zipCodesToRemove = zipcodeBll.GetZipCodeData();
			zipcodeBll.RemoveZipCodeData( zipCodesToRemove );
			ZipCodeDataCollection zipCodesResult = zipcodeBll.GetZipCodeData();
			Assert.AreEqual( 0 , zipCodesResult.Count , "The zipCodes should be removed!" );
			ZipCodeUnitTestHelper.AreInLogDeletes( zipCodesToRemove );
		}

		#endregion

		#region -_ IDisposable Members _-

		public void Dispose() {
			Dispose( true );
			GC.SuppressFinalize( this );
		}

		/// <summary>
		/// Corrected implementation
		/// </summary>
		/// <param name="disposing"></param>
		protected virtual void Dispose( bool disposing ) {
			if( disposing ) {
				// free managed resources
				if( mainScope != null ) {
					mainScope.Dispose();
					mainScope = null;
				}
			}
		}

		#endregion

	}

}