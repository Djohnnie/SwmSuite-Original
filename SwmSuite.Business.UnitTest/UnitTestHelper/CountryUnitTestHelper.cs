using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.Framework;
using SwmSuite.DataAccess.Sql.SqlHelper.Main;
using SwmSuite.Business;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {

	public class CountryUnitTestHelper {

		public static void AreEqual( CountryDataCollection expected , CountryDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString() + " countries expected, " + actual.Count.ToString() + " countries actual!" );
			// Test individual countries.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].CountryName , actual[i].CountryName , "UT: expected Country.CountryName (" + expected[i].CountryName + ") <> actual Country.CountryName (" + actual[i].CountryName + ")!" );
			}
		}

		public static void AreInLogDeletes( CountryDataCollection countries ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , countries.Count , "UT: " + countries.Count.ToString() + " countries expected in LogDeletes, " + logDeletes.Count.ToString() + " countries found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new CountrySqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( countries[logDeletes.IndexOf( ld )].ToString() , ld.Info );
			}
		}

		public static void UpdateCountries( CountryDataCollection countries ) {
			foreach( CountryData country in countries ) {
				country.CountryName += " -> EDITED!";
			}
		}


		public static CountryData GetCountryTestData() {
			CountryBll countryBll = new CountryBll();
			CountryDataCollection countries =
				CountryDataCollection.FromSingleCountry( new CountryData( "België" ) );
			countryBll.InsertCountryData( countries );
			CountryDataCollection countriesResult = countryBll.GetCountryData();
			return countriesResult[0];
		}

		public static CountryDataCollection GetCountriesTestData() {
			CountryBll countryBll = new CountryBll();
			CountryDataCollection countries = new CountryDataCollection();
			countries.Add( new CountryData( "België" ) );
			countries.Add( new CountryData( "Nederland" ) );
			countries.Add( new CountryData( "Frankrijk" ) );
			countryBll.InsertCountryData( countries );
			CountryDataCollection countriesResult = countryBll.GetCountryData();
			return countriesResult;

		}
	}

}
