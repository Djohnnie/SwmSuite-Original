using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.DataAccess.Sql.SqlHelper;
using System.Globalization;
using SwmSuite.DataAccess.Sql.SqlHelper.Main;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {

	public sealed class AlertUnitTestHelper {

		public static void AreEqual( AlertDataCollection expected , AlertDataCollection actual ){
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString( CultureInfo.InvariantCulture ) + " alerts expected, " + actual.Count.ToString( CultureInfo.InvariantCulture ) + " alerts actual!" );
			// Test individual alerts.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].Visible , actual[i].Visible , "UT: expected Alert.Enabled (" + expected[i].Visible.ToString( CultureInfo.InvariantCulture ) + ") <> actual Alert.Enabled (" + actual[i].Visible.ToString( CultureInfo.InvariantCulture ) + ")!" );
				Assert.AreEqual( expected[i].Message , actual[i].Message , "UT: expected Alert.Message (" + expected[i].Message + ") <> actual Alert.Message (" + actual[i].Message + ")!" );
			}
		}

		public static void AreInLogDeletes( AlertDataCollection alerts ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , alerts.Count , "UT: " + alerts.Count.ToString( CultureInfo.InvariantCulture ) + " alerts expected in LogDeletes, " + logDeletes.Count.ToString( CultureInfo.InvariantCulture ) + " alerts found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new AlertSqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( alerts[logDeletes.IndexOf( ld )].Message , ld.Info );
			}
		}

		public static void UpdateAlerts( AlertDataCollection alerts ) {
			foreach( AlertData alert in alerts ) {
				alert.Visible = !alert.Visible;
				alert.Message = alert.Message + " -> EDITED!";
			}
		}

		public static AlertDataCollection GetAlertsTestData() {
			AlertBll bll = new AlertBll();
			AlertDataCollection alerts = new AlertDataCollection();
			alerts.Add( new AlertData( true , "Alert 1" ) );
			alerts.Add( new AlertData( true , "Alert 2" ) );
			alerts.Add( new AlertData( true , "Alert 3" ) );
			AlertDataCollection alertsResult =
				bll.InsertAlertData( alerts );
			return alertsResult;
		}

		public static AlertData GetAlertTestData(){
			AlertBll bll = new AlertBll();
			AlertData alert = new AlertData( true , "Alert" );
			AlertDataCollection alerts = AlertDataCollection.FromSingleAlert( alert );
			AlertDataCollection alertsResult =
				bll.InsertAlertData( alerts );
			return alertsResult[0];
		}

		private AlertUnitTestHelper() {
		}

	}

}
