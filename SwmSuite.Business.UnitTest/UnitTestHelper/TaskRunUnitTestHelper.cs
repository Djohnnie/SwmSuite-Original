using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using SwmSuite.Framework;
using SwmSuite.DataAccess.Sql.SqlHelper.TaskModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.Common;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {

	public class TaskRunUnitTestHelper {

		public static void AreEqual( TaskRunDataCollection expected , TaskRunDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString( CultureInfo.InvariantCulture ) + " taskruns expected, " + actual.Count.ToString( CultureInfo.InvariantCulture ) + " taskruns actual!" );
			// Test individual taskruns.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].TaskSysId , actual[i].TaskSysId , "UT: expected TaskRun.TaskDescriptionSysId (" + expected[i].TaskSysId.ToString( CultureInfo.InvariantCulture ) + ") <> actual TaskRun.TaskDescriptionSysId (" + actual[i].TaskSysId.ToString( CultureInfo.InvariantCulture ) + ")!" );
				Assert.AreEqual( expected[i].DateTimeFinished , actual[i].DateTimeFinished , "UT: expected TaskRun.DateTimeFinished (" + expected[i].DateTimeFinished.ToString( CultureInfo.InvariantCulture ) + ") <> actual TaskRun.DateTimeFinished (" + actual[i].DateTimeFinished.ToString( CultureInfo.InvariantCulture ) + ")!" );
				Assert.AreEqual( expected[i].Remarks , actual[i].Remarks , "UT: expected TaskRun.Remarks (" + expected[i].Remarks + ") <> actual TaskRun.Remarks (" + actual[i].Remarks + ")!" );
				Assert.AreEqual( expected[i].TaskRunMode , actual[i].TaskRunMode , "UT: expected TaskRun.TaskRunMode (" + expected[i].TaskRunMode.ToString() + ") <> actual TaskRun.TaskRunMode (" + actual[i].TaskRunMode.ToString() + ")!" );
			}
		}

		public static void AreInLogDeletes( TaskRunDataCollection taskruns ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , taskruns.Count , "UT: " + taskruns.Count.ToString( CultureInfo.InvariantCulture ) + " taskruns expected in LogDeletes, " + logDeletes.Count.ToString( CultureInfo.InvariantCulture ) + " taskruns found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new TaskRunSqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( taskruns[logDeletes.IndexOf( ld )].ToString( ) , ld.Info );
			}
		}

		public static void UpdateTaskRuns( TaskRunDataCollection taskruns ) {
			foreach( TaskRunData taskrun in taskruns ) {
				taskrun.DateTimeFinished = taskrun.DateTimeFinished.AddDays( 7 );
				taskrun.Remarks += " -> EDITED!";
				taskrun.TaskRunMode = TaskRunMode.TaskFailed;
			}
		}

	}

}