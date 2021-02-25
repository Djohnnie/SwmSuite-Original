using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.DataAccess.Sql.SqlHelper;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {

	public class ConnectionLogUnitTestHelper {

		public static void AreEqual( ConnectionLogDataCollection expected , ConnectionLogDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString() + " connectionlogs expected, " + actual.Count.ToString() + " connectionlogs actual!" );
			// Test individual connectionlogs.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].DateTime , actual[i].DateTime , "UT: expected ConnectionLog.DateTime (" + expected[i].DateTime.ToString() + ") <> actual ConnectionLog.DateTime (" + actual[i].DateTime.ToString() + ")!" );
				Assert.AreEqual( expected[i].Client , actual[i].Client , "UT: expected ConnectionLog.Client (" + expected[i].Client + ") <> actual ConnectionLog.Client (" + actual[i].Client + ")!" );
			}
		}

		public static void AreInLogDeletes( ConnectionLogDataCollection connectionLogData ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , connectionLogData.Count , "UT: " + connectionLogData.Count.ToString() + " connectionlogs expected in LogDeletes, " + logDeletes.Count.ToString() + " connectionlogs found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new ConnectionLogSqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( connectionLogData[logDeletes.IndexOf( ld )].ToString() , ld.Info );
			}
		}

		public static void UpdateConnectionLogs( ConnectionLogDataCollection connectionLogData ) {
			foreach( ConnectionLogData connectionLog in connectionLogData ) {
				connectionLog.DateTime = connectionLog.DateTime.AddDays( 1 );
				connectionLog.Client = connectionLog.Client += "-> EDITED";
			}
		}

	}

}
