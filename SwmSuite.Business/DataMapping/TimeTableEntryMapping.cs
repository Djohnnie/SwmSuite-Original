using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.Business.DataMapping {

	public class TimeTableEntryMapping : Mapping {

		public static TimeTableEntry FromDataObject( TimeTableEntryData timeTableEntryData ) {
			Mapping mapping = new TimeTableEntryMapping();
			return mapping.FromDataObject( timeTableEntryData ) as TimeTableEntry;
		}

		public static TimeTableEntryData FromBusinessObject( TimeTableEntry timeTableEntry ) {
			Mapping mapping = new TimeTableEntryMapping();
			return mapping.FromBusinessObject( timeTableEntry ) as TimeTableEntryData;
		}

		public static TimeTableEntryCollection FromDataObjectCollection( TimeTableEntryDataCollection timeTableEntryDataCollection ) {
			Mapping mapping = new TimeTableEntryMapping();
			TimeTableEntryCollection timeTableEntryCollectionToReturn = new TimeTableEntryCollection();
			foreach( TimeTableEntryData timeTableEntryData in timeTableEntryDataCollection ) {
				timeTableEntryCollectionToReturn.Add( FromDataObject( timeTableEntryData ) );
			}
			return timeTableEntryCollectionToReturn;
		}

		public static TimeTableEntryDataCollection FromBusinessObjectCollection( TimeTableEntryCollection timeTableEntryCollection ) {
			Mapping mapping = new TimeTableEntryMapping();
			TimeTableEntryDataCollection timeTableEntryDataCollectionToReturn = new TimeTableEntryDataCollection();
			foreach( TimeTableEntry timeTableEntry in timeTableEntryCollection ) {
				timeTableEntryDataCollectionToReturn.Add( FromBusinessObject( timeTableEntry ) );
			}
			return timeTableEntryDataCollectionToReturn;
		}

		#region IMapping Members

		public override BusinessObjectBase FromDataObject( DataObjectBase dataObject ) {
			TimeTableEntryData timeTableEntryData = dataObject as TimeTableEntryData;
			TimeTableEntry timeTableEntryToReturn = new TimeTableEntry();
			timeTableEntryToReturn.SysId = timeTableEntryData.SysId;
			timeTableEntryToReturn.RowVersion = timeTableEntryData.RowVersion;
			timeTableEntryToReturn.Date = timeTableEntryData.Date;
			timeTableEntryToReturn.From = timeTableEntryData.From;
			timeTableEntryToReturn.To = timeTableEntryData.To;
			timeTableEntryToReturn.Employee = new EmployeeBll().GetEmployeeDetail( timeTableEntryData.EmployeeSysId );
			timeTableEntryToReturn.TimeTablePurpose = new TimeTablePurposeBll().GetTimeTablePurpose( timeTableEntryData.TimeTablePurposeSysId );
			return timeTableEntryToReturn;
		}

		public override DataObjectBase FromBusinessObject( BusinessObjectBase businessObject ) {
			TimeTableEntry timeTableEntry = businessObject as TimeTableEntry;
			TimeTableEntryData timeTableEntryDataToReturn = new TimeTableEntryData();
			timeTableEntryDataToReturn.SysId = timeTableEntry.SysId;
			timeTableEntryDataToReturn.RowVersion = timeTableEntry.RowVersion;
			timeTableEntryDataToReturn.Date = timeTableEntry.Date;
			timeTableEntryDataToReturn.From = timeTableEntry.From;
			timeTableEntryDataToReturn.To = timeTableEntry.To;
			timeTableEntryDataToReturn.EmployeeSysId = timeTableEntry.Employee.SysId;
			timeTableEntryDataToReturn.TimeTablePurposeSysId = timeTableEntry.TimeTablePurpose.SysId;
			return timeTableEntryDataToReturn;
		}

		#endregion

	}
}
