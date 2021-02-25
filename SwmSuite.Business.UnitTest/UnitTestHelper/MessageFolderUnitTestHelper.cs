using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.Framework;
using SwmSuite.DataAccess.Sql.SqlHelper.MessageModule;
using SwmSuite.Business;
using System.Globalization;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.Common;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {
	
	public class MessageFolderUnitTestHelper {

		public static void AreEqual( MessageFolderDataCollection expected , MessageFolderDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString( CultureInfo.InvariantCulture ) + " messageFolders expected, " + actual.Count.ToString( CultureInfo.InvariantCulture ) + " messageFolders actual!" );
			// Test individual messageFolders.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].OwnerEmployeeSysId , actual[i].OwnerEmployeeSysId , "UT: expected MessageFolder.OwnerEmployeeSysId (" + expected[i].OwnerEmployeeSysId.ToString( CultureInfo.InvariantCulture ) + ") <> actual MessageFolder.OwnerEmployeeSysId (" + actual[i].OwnerEmployeeSysId.ToString( CultureInfo.InvariantCulture ) + ")!" );
				Assert.AreEqual( expected[i].ParentMessageFolderSysId , actual[i].ParentMessageFolderSysId , "UT: expected MessageFolder.ParentMessageFolderSysId (" + expected[i].ParentMessageFolderSysId.ToString(  ) + ") <> actual MessageFolder.ParentMessageFolderSysId (" + actual[i].ParentMessageFolderSysId.ToString(  ) + ")!" );
				Assert.AreEqual( expected[i].SpecialFolder , actual[i].SpecialFolder , "UT: expected MessageFolder.SpecialFolder (" + expected[i].SpecialFolder.ToString(  ) + ") <> actual MessageFolder.SpecialFolder (" + actual[i].SpecialFolder.ToString( ) + ")!" );
				Assert.AreEqual( expected[i].Name , actual[i].Name , "UT: expected MessageFolder.Name (" + expected[i].Name + ") <> actual MessageFolder.Name (" + actual[i].Name + ")!" );
				Assert.AreEqual( expected[i].Visible , actual[i].Visible , "UT: expected MessageFolder.Visible (" + expected[i].Visible.ToString( CultureInfo.InvariantCulture ) + ") <> actual MessageFolder.Visible (" + actual[i].Visible.ToString( CultureInfo.InvariantCulture ) + ")!" );
			}
		}

		public static void AreInLogDeletes( MessageFolderDataCollection messageFolders ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , messageFolders.Count , "UT: " + messageFolders.Count.ToString( CultureInfo.InvariantCulture ) + " messageFolders expected in LogDeletes, " + logDeletes.Count.ToString( CultureInfo.InvariantCulture ) + " messageFolders found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new MessageFolderSqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( messageFolders[logDeletes.IndexOf( ld )].ToString( ) , ld.Info );
			}
		}

		public static void UpdateMessageFolders( MessageFolderDataCollection messageFolders ) {
			foreach( MessageFolderData messageFolder in messageFolders ) {
				messageFolder.Name = messageFolder.Name + " -> EDITED!";
				messageFolder.Visible = !messageFolder.Visible;
			}
		}

		public static MessageFolderData GetRootMessageFolderTestData( MessageSpecialFolder specialFolder ) {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			MessageFolderData messageFolderToInsert = new MessageFolderData( testEmployee.SysId , null , specialFolder , specialFolder.ToString( ) , false );
			MessageFolderDataCollection insertedMessageFolders = 
				new MessageFolderBll().InsertMessageFolderData( MessageFolderDataCollection.FromSingleMessageFolder( messageFolderToInsert ) );
			return insertedMessageFolders[0];
		}

	}

}