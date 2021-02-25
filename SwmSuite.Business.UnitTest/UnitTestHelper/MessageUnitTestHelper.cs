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
	
	public class MessageUnitTestHelper {

		public static void AreEqual( MessageDataCollection expected , MessageDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString( CultureInfo.InvariantCulture ) + " messages expected, " + actual.Count.ToString( CultureInfo.InvariantCulture ) + " messages actual!" );
			// Test individual messages.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].FromEmployeeSysId , actual[i].FromEmployeeSysId , "UT: expected Message.FromEmployeeSysId (" + expected[i].FromEmployeeSysId.ToString( CultureInfo.InvariantCulture ) + ") <> actual Message.FromEmployeeSysId (" + actual[i].FromEmployeeSysId.ToString( CultureInfo.InvariantCulture ) + ")!" );
				Assert.AreEqual( expected[i].Date , actual[i].Date , "UT: expected Message.Date (" + expected[i].Date.ToString( CultureInfo.InvariantCulture ) + ") <> actual Message.Date (" + actual[i].Date.ToString( CultureInfo.InvariantCulture ) + ")!" );
				Assert.AreEqual( expected[i].Subject , actual[i].Subject , "UT: expected Message.Subject (" + expected[i].Subject + ") <> actual Message.Subject (" + actual[i].Subject + ")!" );
				Assert.AreEqual( expected[i].Content , actual[i].Content , "UT: expected Message.Content (" + expected[i].Content + ") <> actual Message.Content (" + actual[i].Content + ")!" );
				Assert.AreEqual( expected[i].Priority , actual[i].Priority , "UT: expected Message.Priority (" + expected[i].Priority.ToString( ) + ") <> actual Message.Priority (" + actual[i].Priority.ToString() + ")!" );
				Assert.AreEqual( expected[i].Visible , actual[i].Visible , "UT: expected Message.Visible (" + expected[i].Visible.ToString( CultureInfo.InvariantCulture ) + ") <> actual Message.Visible (" + actual[i].Visible.ToString( CultureInfo.InvariantCulture ) + ")!" );
			}
		}

		public static void AreInLogDeletes( MessageDataCollection messages ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , messages.Count , "UT: " + messages.Count.ToString( CultureInfo.InvariantCulture ) + " messages expected in LogDeletes, " + logDeletes.Count.ToString( CultureInfo.InvariantCulture ) + " messages found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new MessageSqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( messages[logDeletes.IndexOf( ld )].ToString( ) , ld.Info );
			}
		}

		public static void UpdateMessages( MessageDataCollection messages ) {
			foreach( MessageData message in messages ) {
				message.Date = message.Date.AddDays( 1.0f );
				message.Subject = message.Subject + " -> EDITED!";
				message.Content = message.Content + " -> EDITED!";
				message.Priority = MessagePriority.High;
				message.Visible = !message.Visible;
			}
		}

		public static MessageData GetMessageTestData() {
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			MessageData message = new MessageData( testEmployee.SysId , DateTime.Today , "Subject" , "Content" , MessagePriority.Normal , true );
			MessageDataCollection messagesToReturn =
				new MessageBll().InsertMessageData( MessageDataCollection.FromSingleMessage( message ) );
			return messagesToReturn[0];
		}

	}

}