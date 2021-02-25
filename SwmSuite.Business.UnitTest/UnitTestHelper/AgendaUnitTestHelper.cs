using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.Framework;
using SwmSuite.DataAccess.Sql.SqlHelper;
using System.Globalization;
using SwmSuite.Business;
using SwmSuite.Data.Common;

namespace SwmSuite.Business.UnitTest.UnitTestHelper {

	public class AgendaUnitTestHelper {

		public static void AreEqual( AgendaDataCollection expected , AgendaDataCollection actual ) {
			// Test collection size.
			Assert.AreEqual( expected.Count , actual.Count , "UT: " + expected.Count.ToString( CultureInfo.InvariantCulture ) + " agendas expected, " + actual.Count.ToString( CultureInfo.InvariantCulture ) + " agendas actual!" );
			// Test individual agendas.
			for( int i = 0 ; i < expected.Count ; i++ ) {
				Assert.AreEqual( expected[i].Title , actual[i].Title , "UT: expected Agenda.Title (" + expected[i].Title + ") <> actual Agenda.Title (" + actual[i].Title + ")!" );
				Assert.AreEqual( expected[i].Description , actual[i].Description , "UT: expected Agenda.Description (" + expected[i].Description + ") <> actual Agenda.Description (" + actual[i].Description + ")!" );
				Assert.AreEqual( expected[i].OwnerEmployeeSysId , actual[i].OwnerEmployeeSysId , "UT: expected Agenda.OwnerEmployeeSysId (" + expected[i].OwnerEmployeeSysId.ToString( CultureInfo.InvariantCulture ) + ") <> actual Agenda.OwnerEmployeeSysId (" + actual[i].OwnerEmployeeSysId.ToString( CultureInfo.InvariantCulture ) + ")!" );
				Assert.AreEqual( expected[i].Visibility , actual[i].Visibility , "UT: expected Appointment.Visibility (" + expected[i].Visibility.ToString() + ") <> actual Appointment.Visibility (" + actual[i].Visibility.ToString() + ")!" );
			}
		}

		public static void AreInLogDeletes( AgendaDataCollection agendas ) {
			LogDeleteDataCollection logDeletes = new LogDeleteBll().GetLogDeleteData();
			Assert.AreEqual( logDeletes.Count , agendas.Count , "UT: " + agendas.Count.ToString( CultureInfo.InvariantCulture ) + " agendas expected in LogDeletes, " + logDeletes.Count.ToString( CultureInfo.InvariantCulture ) + " agendas found in LogDeletes!" );
			foreach( LogDeleteData ld in logDeletes ) {
				Assert.AreEqual( new AgendaSqlHelper().DBTableName , ld.TableName );
				Assert.AreEqual( agendas[logDeletes.IndexOf( ld )].ToString() , ld.Info );
			}
		}

		public static void UpdateAgendas( AgendaDataCollection agendas ) {
			foreach( AgendaData agenda in agendas ) {
				agenda.Title += " -> EDITED!";
				agenda.Description += " -> EDITED!";
				agenda.Visibility = AppointmentVisibility.Invisible;
			}
		}

		public static AgendaData GetAgendaTestData() {
			AgendaBll bll = new AgendaBll();
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			AgendaDataCollection agendas = new AgendaDataCollection();
			agendas.Add( new AgendaData( "Title" , "Description" , testEmployee.SysId , AppointmentVisibility.Public , 0 ) );
			AgendaDataCollection agendasResult = bll.InsertAgendaData( agendas );
			return agendasResult[0];
		}

		public static AgendaDataCollection GetAgendasTestData() {
			AgendaBll bll = new AgendaBll();
			EmployeeData testEmployee = EmployeeUnitTestHelper.GetEmployeeTestData();
			AgendaDataCollection agendas = new AgendaDataCollection();
			agendas.Add( new AgendaData( "Title 1" , "Description 1" , testEmployee.SysId , AppointmentVisibility.Public , 0 ) );
			agendas.Add( new AgendaData( "Title 2" , "Description 2" , testEmployee.SysId , AppointmentVisibility.Public , 0 ) );
			agendas.Add( new AgendaData( "Title 3" , "Description 3" , testEmployee.SysId , AppointmentVisibility.Public , 0 ) );
			AgendaDataCollection agendasResult = bll.InsertAgendaData( agendas );
			return agendasResult;
		}

	}

}
