using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.Framework;
using SwmSuite.DataAccess.Sql.SqlHelper;
using System.Globalization;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {

	public class MessageStorageUnitTestHelper {

		public static void AreEqual( MessageStorageDataCollection expected , MessageStorageDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString( CultureInfo.InvariantCulture ) + " messageStorages expected, " + actual.Count.ToString( CultureInfo.InvariantCulture ) + " messageStorages actual!" );
			// Test individual messageStorages.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].MessageSysId , actual[i].MessageSysId , "UT: expected MessageStorage.MessageSysId (" + expected[i].MessageSysId.ToString( CultureInfo.InvariantCulture ) + ") <> actual MessageStorage.MessageSysId (" + actual[i].MessageSysId.ToString( CultureInfo.InvariantCulture ) + ")!" );
				Assert.AreEqual( expected[i].MessageFolderSysId , actual[i].MessageFolderSysId , "UT: expected MessageStorage.MessageFolderSysId (" + expected[i].MessageFolderSysId.ToString( CultureInfo.InvariantCulture ) + ") <> actual MessageStorage.MessageFolderSysId (" + actual[i].MessageFolderSysId.ToString( CultureInfo.InvariantCulture ) + ")!" );
			}
		}

		public static void AreInLogDeletes( MessageStorageDataCollection messageStorages ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , messageStorages.Count , "UT: " + messageStorages.Count.ToString( CultureInfo.InvariantCulture ) + " messageStorages expected in LogDeletes, " + logDeletes.Count.ToString( CultureInfo.InvariantCulture ) + " messageStorages found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new MessageStorageSqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( messageStorages[logDeletes.IndexOf( ld )].ToString() , ld.Info );
			}
		}

	}

}
