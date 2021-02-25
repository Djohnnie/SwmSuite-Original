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
	/// Unittestclass to test the CountryBll methods.
	/// </summary>
	[TestClass()]
	public class CountryBllTest : IDisposable {

		#region -_ Private Members _-

		private TestContext testContextInstance;

		private TransactionScope mainScope;

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
		public void Business_GetCountriesTest() {
			Country countryToCreate1 = new Country( "Belgium" );
			Country countryToCreate2 = new Country( "Germany" );
			Country countryToCreate3 = new Country( "France" );
			countryBll.CreateCountry( countryToCreate1 );
			countryBll.CreateCountry( countryToCreate2 );
			countryBll.CreateCountry( countryToCreate3 );
			CountryCollection countriesResult = countryBll.GetCountries();
			Assert.AreEqual( 3 , countriesResult.Count );
			Assert.AreEqual( "Belgium" , countriesResult[0].Name );
			Assert.AreEqual( "Germany" , countriesResult[1].Name );
			Assert.AreEqual( "France" , countriesResult[2].Name );
		}

		[TestMethod]
		public void Business_GetCountryTest() {
			Country countryToCreate1 = new Country( "Belgium" );
			Country countryToCreate2 = new Country( "Germany" );
			Country countryToCreate3 = new Country( "France" );
			countryToCreate1 = countryBll.CreateCountry( countryToCreate1 );
			countryToCreate2 = countryBll.CreateCountry( countryToCreate2 );
			countryToCreate3 = countryBll.CreateCountry( countryToCreate3 );
			CountryCollection countriesResult = countryBll.GetCountries();
			Country countryResult = countryBll.GetCountry( countryToCreate2.SysId );
			Assert.AreEqual( "Germany" , countryResult.Name );
		}

		[TestMethod]
		public void Business_CreateCountryTest() {
			Country countryToCreate = new Country( "Belgium" );
			countryBll.CreateCountry( countryToCreate );
			CountryCollection countriesResult = countryBll.GetCountries();
			Assert.AreEqual( 1 , countriesResult.Count );
			Assert.AreEqual( "Belgium" , countriesResult[0].Name );
		}

		[TestMethod]
		public void Business_UpdateCountryTest() {
			Country countryToCreate = new Country( "Belgium" );
			Country countryCreated = 
				countryBll.CreateCountry( countryToCreate );
			Country countryToUpdate = countryBll.GetCountry( countryCreated.SysId );
			countryToUpdate.Name = "Holland";
			Country countryUpdated =
				countryBll.UpdateCountry( countryToUpdate );
			Assert.AreEqual( "Holland" , countryUpdated.Name );
			Assert.AreEqual( countryToUpdate.RowVersion + 1 , countryUpdated.RowVersion );
		}

		[TestMethod]
		public void Business_RemoveCountriesTest() {
			Country countryToCreate1 = new Country( "Belgium" );
			Country countryToCreate2 = new Country( "Holland" );
			countryBll.CreateCountry( countryToCreate1 );
			countryBll.CreateCountry( countryToCreate2 );
			CountryCollection countriesToRemove = countryBll.GetCountries();
			countryBll.RemoveCountries( countriesToRemove );
			CountryCollection countriesResult = countryBll.GetCountries();
			Assert.AreEqual( 0 , countriesResult.Count );
		}

		#endregion

		#region -_ Crud Test Methods _-

		/// <summary>
		/// A test for InsertCountries (insert a single country).
		/// </summary>
		[TestMethod]
		public void Crud_InsertCountryTest() {
			CountryDataCollection countries = 
				CountryDataCollection.FromSingleCountry( new CountryData( "België" ) );
			countryBll.InsertCountryData( countries );
			CountryDataCollection countriesResult = countryBll.GetCountryData();
			CountryUnitTestHelper.AreEqual( countries , countriesResult );
		}

		/// <summary>
		/// A test for InsertCountries (insert multiple countries).
		/// </summary>
		[TestMethod]
		public void Crud_InsertCountriesTest() {
			CountryDataCollection countries = new CountryDataCollection();
			countries.Add( new CountryData( "België" ) );
			countries.Add( new CountryData( "Nederland" ) );
			countries.Add( new CountryData( "Frankrijk" ) );
			countryBll.InsertCountryData( countries );
			CountryDataCollection countriesResult = countryBll.GetCountryData();
			CountryUnitTestHelper.AreEqual( countries , countriesResult );
		}

		/// <summary>
		/// A test for UpdateCountries (update a single country).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateCountryTest() {
			CountryDataCollection countries =
				CountryDataCollection.FromSingleCountry( new CountryData( "België" ) );
			countryBll.InsertCountryData( countries );
			CountryDataCollection countriesToUpdate = countryBll.GetCountryData();
			CountryUnitTestHelper.UpdateCountries( countriesToUpdate );
			countryBll.UpdateCountryData( countriesToUpdate );
			CountryDataCollection countriesResult = countryBll.GetCountryData();
			CountryUnitTestHelper.AreEqual( countriesToUpdate , countriesResult );
		}

		/// <summary>
		/// A test for UpdateCountries (update multiple countries).
		/// </summary>
		[TestMethod]
		public void Crud_UpdateCountriesTest() {
			CountryDataCollection countries = new CountryDataCollection();
			countries.Add( new CountryData( "België" ) );
			countries.Add( new CountryData( "Nederland" ) );
			countries.Add( new CountryData( "Frankrijk" ) );
			countryBll.InsertCountryData( countries );
			CountryDataCollection countriesToUpdate = countryBll.GetCountryData();
			CountryUnitTestHelper.UpdateCountries( countriesToUpdate );
			countryBll.UpdateCountryData( countriesToUpdate );
			CountryDataCollection countriesResult = countryBll.GetCountryData();
			CountryUnitTestHelper.AreEqual( countriesToUpdate , countriesResult );
		}

		/// <summary>
		/// A test for RemoveCountries (remove a single country).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveCountryTest() {
			CountryDataCollection countries =
				CountryDataCollection.FromSingleCountry( new CountryData( "België" ) );
			countryBll.InsertCountryData( countries );
			CountryDataCollection countriesToRemove = countryBll.GetCountryData();
			countryBll.RemoveCountryData( countriesToRemove );
			CountryDataCollection countriesResult = countryBll.GetCountryData();
			Assert.AreEqual( 0 , countriesResult.Count , "The countries should be removed!" );
			CountryUnitTestHelper.AreInLogDeletes( countriesToRemove );
		}

		/// <summary>
		/// A test for RemoveCountries (remove multiple countries).
		/// </summary>
		[TestMethod]
		public void Crud_RemoveCountriesTest() {
			CountryDataCollection countries = new CountryDataCollection();
			countries.Add( new CountryData( "België" ) );
			countries.Add( new CountryData( "Nederland" ) );
			countries.Add( new CountryData( "Frankrijk" ) );
			countryBll.InsertCountryData( countries );
			CountryDataCollection countriesToRemove = countryBll.GetCountryData();
			countryBll.RemoveCountryData( countriesToRemove );
			CountryDataCollection countriesResult = countryBll.GetCountryData();
			Assert.AreEqual( 0 , countriesResult.Count , "The countries should be removed!" );
			CountryUnitTestHelper.AreInLogDeletes( countriesToRemove );
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
