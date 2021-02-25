using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.Framework;
using SwmSuite.DataAccess.Sql.SqlHelper.Main;
using SwmSuite.Business;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {

	public class ZipCodeUnitTestHelper {

		public static void AreEqual( ZipCodeDataCollection expected , ZipCodeDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString() + " zipcodes expected, " + actual.Count.ToString() + " zipcodes actual!" );
			// Test individual zipcodes.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].Code , actual[i].Code , "UT: expected ZipCode.Code (" + expected[i].Code + ") <> actual ZipCode.Code (" + actual[i].Code + ")!" );
				Assert.AreEqual( expected[i].City , actual[i].City , "UT: expected ZipCode.City (" + expected[i].City + ") <> actual ZipCode.City (" + actual[i].City + ")!" );
				Assert.AreEqual( expected[i].CountrySysId , actual[i].CountrySysId , "UT: expected ZipCode.CountrySysId (" + expected[i].CountrySysId.ToString() + ") <> actual ZipCode.CountrySysId (" + actual[i].CountrySysId.ToString() + ")!" );
			}
		}

		public static void AreInLogDeletes( ZipCodeDataCollection zipcodes ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , zipcodes.Count , "UT: " + zipcodes.Count.ToString() + " zipcodes expected in LogDeletes, " + logDeletes.Count.ToString() + " zipcodes found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new ZipCodeSqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( zipcodes[logDeletes.IndexOf( ld )].ToString() , ld.Info );
			}
		}

		public static void UpdateZipCodes( ZipCodeDataCollection zipcodes ) {
			foreach( ZipCodeData zipcode in zipcodes ) {
				zipcode.City += " -> EDITED!";
				zipcode.Code += " -> EDITED!";
			}
		}

		public static ZipCodeData GetZipCodeTestData() {
			ZipCodeBll zipcodeBll = new ZipCodeBll();

			CountryData countryTestData = CountryUnitTestHelper.GetCountryTestData();
			ZipCodeDataCollection zipCodes =
				ZipCodeDataCollection.FromSingleZipCode( new ZipCodeData( "2850" , "Boom" , countryTestData.SysId ) );
			zipcodeBll.InsertZipCodeData( zipCodes );
			ZipCodeDataCollection zipCodesResult = zipcodeBll.GetZipCodeData();
			return zipCodesResult[0];
		}

		public static ZipCodeDataCollection GetZipCodesTestData() {
			ZipCodeBll zipcodeBll = new ZipCodeBll();
			 
			CountryData countryTestData = CountryUnitTestHelper.GetCountryTestData();
			ZipCodeDataCollection zipCodes = new ZipCodeDataCollection();
			zipCodes.Add( new ZipCodeData( "2850" , "Boom" , countryTestData.SysId ) );
			zipCodes.Add( new ZipCodeData( "2845" , "Niel" , countryTestData.SysId ) );
			zipCodes.Add( new ZipCodeData( "2650" , "Edegem" , countryTestData.SysId ) );
			zipcodeBll.InsertZipCodeData( zipCodes );
			ZipCodeDataCollection zipCodesResult = zipcodeBll.GetZipCodeData();
			return zipCodesResult;
		}

	}
}
