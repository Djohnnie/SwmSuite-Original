using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.Framework;
using SwmSuite.DataAccess.Sql.SqlHelper;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {

	public class TaskRecurrenceUnitTestHelper {

		public static void AreEqual( TaskRecurrenceDataCollection expected , TaskRecurrenceDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString() + " taskrecurrences expected, " + actual.Count.ToString() + " taskrecurrences actual!" );
			// Test individual taskrecurrences.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].TaskDescriptionSysId , actual[i].TaskDescriptionSysId , "UT: expected TaskRecurrence.TaskDescriptionSysId (" + expected[i].TaskDescriptionSysId.ToString() + ") <> actual TaskRecurrence.TaskDescriptionSysId (" + actual[i].TaskDescriptionSysId.ToString() + ")!" );
				Assert.AreEqual( expected[i].RecurrenceSysId , actual[i].RecurrenceSysId , "UT: expected TaskRecurrence.RecurrenceSysId (" + expected[i].RecurrenceSysId.ToString() + ") <> actual TaskRecurrence.RecurrenceSysId (" + actual[i].RecurrenceSysId.ToString() + ")!" );
			}
		}

		public static void AreInLogDeletes( TaskRecurrenceDataCollection taskrecurrences ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , taskrecurrences.Count , "UT: " + taskrecurrences.Count.ToString() + " taskrecurrences expected in LogDeletes, " + logDeletes.Count.ToString() + " taskrecurrences found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new TaskRecurrenceSqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( taskrecurrences[logDeletes.IndexOf( ld )].ToString() , ld.Info );
			}
		}

	}

}
