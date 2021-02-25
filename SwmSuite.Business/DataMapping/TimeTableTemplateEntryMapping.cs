using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.Business.DataMapping {

	public class TimeTableTemplateEntryMapping : Mapping {

		public static TimeTableTemplateEntry FromDataObject( TimeTableTemplateEntryData timeTableEntryData ) {
			Mapping mapping = new TimeTableTemplateEntryMapping();
			return mapping.FromDataObject( timeTableEntryData ) as TimeTableTemplateEntry;
		}

		public static TimeTableTemplateEntryData FromBusinessObject( TimeTableTemplateEntry timeTableEntry ) {
			Mapping mapping = new TimeTableTemplateEntryMapping();
			return mapping.FromBusinessObject( timeTableEntry ) as TimeTableTemplateEntryData;
		}

		public static TimeTableTemplateEntryCollection FromDataObjectCollection( TimeTableTemplateEntryDataCollection timeTableEntryDataCollection ) {
			Mapping mapping = new TimeTableTemplateEntryMapping();
			TimeTableTemplateEntryCollection timeTableEntryCollectionToReturn = new TimeTableTemplateEntryCollection();
			foreach( TimeTableTemplateEntryData timeTableEntryData in timeTableEntryDataCollection ) {
				timeTableEntryCollectionToReturn.Add( FromDataObject( timeTableEntryData ) );
			}
			return timeTableEntryCollectionToReturn;
		}

		public static TimeTableTemplateEntryDataCollection FromBusinessObjectCollection( TimeTableTemplateEntryCollection timeTableEntryCollection ) {
			Mapping mapping = new TimeTableTemplateEntryMapping();
			TimeTableTemplateEntryDataCollection timeTableEntryDataCollectionToReturn = new TimeTableTemplateEntryDataCollection();
			foreach( TimeTableTemplateEntry timeTableEntry in timeTableEntryCollection ) {
				timeTableEntryDataCollectionToReturn.Add( FromBusinessObject( timeTableEntry ) );
			}
			return timeTableEntryDataCollectionToReturn;
		}

		#region IMapping Members

		public override BusinessObjectBase FromDataObject( DataObjectBase dataObject ) {
			TimeTableTemplateEntryData timeTableEntryData = dataObject as TimeTableTemplateEntryData;
			TimeTableTemplateEntry timeTableEntryToReturn = new TimeTableTemplateEntry();
			timeTableEntryToReturn.SysId = timeTableEntryData.SysId;
			timeTableEntryToReturn.RowVersion = timeTableEntryData.RowVersion;
			timeTableEntryToReturn.Date = timeTableEntryData.Date;
			timeTableEntryToReturn.From = timeTableEntryData.From;
			timeTableEntryToReturn.To = timeTableEntryData.To;
			timeTableEntryToReturn.TimeTablePurpose = new TimeTablePurposeBll().GetTimeTablePurpose( timeTableEntryData.TimeTablePurposeSysId );
			return timeTableEntryToReturn;
		}

		public override DataObjectBase FromBusinessObject( BusinessObjectBase businessObject ) {
			TimeTableTemplateEntry timeTableEntry = businessObject as TimeTableTemplateEntry;
			TimeTableTemplateEntryData timeTableEntryDataToReturn = new TimeTableTemplateEntryData();
			timeTableEntryDataToReturn.SysId = timeTableEntry.SysId;
			timeTableEntryDataToReturn.RowVersion = timeTableEntry.RowVersion;
			timeTableEntryDataToReturn.Date = timeTableEntry.Date;
			timeTableEntryDataToReturn.From = timeTableEntry.From;
			timeTableEntryDataToReturn.To = timeTableEntry.To;
			timeTableEntryDataToReturn.TimeTablePurposeSysId = timeTableEntry.TimeTablePurpose.SysId;
			return timeTableEntryDataToReturn;
		}

		#endregion

	}

}
