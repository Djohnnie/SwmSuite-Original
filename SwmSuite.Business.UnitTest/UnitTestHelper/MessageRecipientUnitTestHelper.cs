using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.Framework;
using SwmSuite.DataAccess.Sql.SqlHelper.MessageModule;
using System.Globalization;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {
	
	public class MessageRecipientUnitTestHelper {

		public static void AreEqual( MessageRecipientDataCollection expected , MessageRecipientDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString( CultureInfo.InvariantCulture ) + " messageRecipients expected, " + actual.Count.ToString( CultureInfo.InvariantCulture ) + " messageRecipients actual!" );
			// Test individual messageRecipients.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].MessageSysId , actual[i].MessageSysId , "UT: expected MessageRecipient.MessageSysId (" + expected[i].MessageSysId.ToString( CultureInfo.InvariantCulture ) + ") <> actual MessageRecipient.MessageSysId (" + actual[i].MessageSysId.ToString( CultureInfo.InvariantCulture ) + ")!" );
				Assert.AreEqual( expected[i].EmployeeSysId , actual[i].EmployeeSysId , "UT: expected MessageRecipient.EmployeeSysId (" + expected[i].EmployeeSysId.ToString( CultureInfo.InvariantCulture ) + ") <> actual MessageRecipient.EmployeeSysId (" + actual[i].EmployeeSysId.ToString( CultureInfo.InvariantCulture ) + ")!" );
			}
		}

		public static void AreInLogDeletes( MessageRecipientDataCollection messageRecipients ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , messageRecipients.Count , "UT: " + messageRecipients.Count.ToString( CultureInfo.InvariantCulture ) + " messageRecipients expected in LogDeletes, " + logDeletes.Count.ToString( CultureInfo.InvariantCulture ) + " messageRecipients found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new MessageRecipientSqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( messageRecipients[logDeletes.IndexOf( ld )].ToString( ) , ld.Info );
			}
		}

	}

}
