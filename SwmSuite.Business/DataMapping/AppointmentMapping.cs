using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.Business.DataMapping {
	
	public class AppointmentMapping : Mapping {

		public static Appointment FromDataObject( AppointmentData appointmentData ) {
			Mapping mapping = new AppointmentMapping();
			return mapping.FromDataObject( appointmentData ) as Appointment;
		}

		public static AppointmentData FromBusinessObject( Appointment appointment ) {
			Mapping mapping = new AppointmentMapping();
			return mapping.FromBusinessObject( appointment ) as AppointmentData;
		}

		public static AppointmentCollection FromDataObjectCollection( AppointmentDataCollection appointmentDataCollection ) {
			Mapping mapping = new AppointmentMapping();
			AppointmentCollection appointmentCollectionToReturn = new AppointmentCollection();
			foreach( AppointmentData appointmentData in appointmentDataCollection ) {
				appointmentCollectionToReturn.Add( FromDataObject( appointmentData ) );
			}
			return appointmentCollectionToReturn;
		}

		public static AppointmentDataCollection FromBusinessObjectCollection( AppointmentCollection appointmentCollection ) {
			Mapping mapping = new AppointmentMapping();
			AppointmentDataCollection appointmentDataCollectionToReturn = new AppointmentDataCollection();
			foreach( Appointment appointment in appointmentCollection ) {
				appointmentDataCollectionToReturn.Add( FromBusinessObject( appointment ) );
			}
			return appointmentDataCollectionToReturn;
		}

		#region IMapping Members

		public override BusinessObjectBase FromDataObject( DataObjectBase dataObject ) {
			AppointmentData appointmentData = dataObject as AppointmentData;
			Appointment appointmentToReturn = new Appointment();
			appointmentToReturn.SysId = appointmentData.SysId;
			appointmentToReturn.RowVersion = appointmentData.RowVersion;
			appointmentToReturn.Title = appointmentData.Title;
			appointmentToReturn.DateTimeStart = appointmentData.DateTimeStart;
			appointmentToReturn.DateTimeEnd = appointmentData.DateTimeEnd;
			appointmentToReturn.Place = appointmentData.Place;
			appointmentToReturn.OwnerEmployee = new EmployeeBll().GetEmployeeDetail( appointmentData.OwnerEmployeeSysId );
			appointmentToReturn.Contents = appointmentData.Contents;
			appointmentToReturn.Agenda = new AgendaBll().GetAgenda( appointmentData.AgendaSysId );
			appointmentToReturn.Visibility = appointmentData.Visibility;
			appointmentToReturn.Guests = new AppointmentBll().GetAppointmentGuests( appointmentToReturn );
			return appointmentToReturn;
		}

		public override DataObjectBase FromBusinessObject( BusinessObjectBase businessObject ) {
			Appointment appointment = businessObject as Appointment;
			AppointmentData appointmentDataToReturn = new AppointmentData();
			appointmentDataToReturn.SysId = appointment.SysId;
			appointmentDataToReturn.RowVersion = appointment.RowVersion;
			appointmentDataToReturn.Title = appointment.Title;
			appointmentDataToReturn.DateTimeStart = appointment.DateTimeStart;
			appointmentDataToReturn.DateTimeEnd = appointment.DateTimeEnd;
			appointmentDataToReturn.Place = appointment.Place;
			appointmentDataToReturn.OwnerEmployeeSysId = appointment.OwnerEmployee.SysId;
			appointmentDataToReturn.Contents = appointment.Contents;
			appointmentDataToReturn.AgendaSysId = appointment.Agenda.SysId;
			appointmentDataToReturn.Visibility = appointment.Visibility;
			return appointmentDataToReturn;
		}

		#endregion

	}
}
