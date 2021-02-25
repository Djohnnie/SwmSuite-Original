using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.Business.DataMapping {

	public class TimeTablePurposeMapping : Mapping {

		public static TimeTablePurpose FromDataObject( TimeTablePurposeData timeTablePurposeData ) {
			Mapping mapping = new TimeTablePurposeMapping();
			return mapping.FromDataObject( timeTablePurposeData ) as TimeTablePurpose;
		}

		public static TimeTablePurposeData FromBusinessObject( TimeTablePurpose timeTablePurpose ) {
			Mapping mapping = new TimeTablePurposeMapping();
			return mapping.FromBusinessObject( timeTablePurpose ) as TimeTablePurposeData;
		}

		public static TimeTablePurposeCollection FromDataObjectCollection( TimeTablePurposeDataCollection timeTablePurposeDataCollection ) {
			Mapping mapping = new TimeTablePurposeMapping();
			TimeTablePurposeCollection timeTablePurposeCollectionToReturn = new TimeTablePurposeCollection();
			foreach( TimeTablePurposeData timeTablePurposeData in timeTablePurposeDataCollection ) {
				timeTablePurposeCollectionToReturn.Add( FromDataObject( timeTablePurposeData ) );
			}
			return timeTablePurposeCollectionToReturn;
		}

		public static TimeTablePurposeDataCollection FromBusinessObjectCollection( TimeTablePurposeCollection timeTablePurposeCollection ) {
			Mapping mapping = new TimeTablePurposeMapping();
			TimeTablePurposeDataCollection timeTablePurposeDataCollectionToReturn = new TimeTablePurposeDataCollection();
			foreach( TimeTablePurpose timeTablePurpose in timeTablePurposeCollection ) {
				timeTablePurposeDataCollectionToReturn.Add( FromBusinessObject( timeTablePurpose ) );
			}
			return timeTablePurposeDataCollectionToReturn;
		}

		#region IMapping Members

		public override BusinessObjectBase FromDataObject( DataObjectBase dataObject ) {
			TimeTablePurposeData timeTablePurposeData = dataObject as TimeTablePurposeData;
			TimeTablePurpose timeTablePurposeToReturn = new TimeTablePurpose();
			timeTablePurposeToReturn.SysId = timeTablePurposeData.SysId;
			timeTablePurposeToReturn.RowVersion = timeTablePurposeData.RowVersion;
			timeTablePurposeToReturn.Description = timeTablePurposeData.Description;
			timeTablePurposeToReturn.LegendaColor1 = timeTablePurposeData.LegendaColor1;
			timeTablePurposeToReturn.LegendaColor2 = timeTablePurposeData.LegendaColor2;
			timeTablePurposeToReturn.LegendaColor3 = timeTablePurposeData.LegendaColor3;
			return timeTablePurposeToReturn;
		}

		public override DataObjectBase FromBusinessObject( BusinessObjectBase businessObject ) {
			TimeTablePurpose timeTablePurpose = businessObject as TimeTablePurpose;
			TimeTablePurposeData timeTablePurposeDataToReturn = new TimeTablePurposeData();
			timeTablePurposeDataToReturn.SysId = timeTablePurpose.SysId;
			timeTablePurposeDataToReturn.RowVersion = timeTablePurpose.RowVersion;
			timeTablePurposeDataToReturn.Description = timeTablePurpose.Description;
			timeTablePurposeDataToReturn.LegendaColor1 = timeTablePurpose.LegendaColor1;
			timeTablePurposeDataToReturn.LegendaColor2 = timeTablePurpose.LegendaColor2;
			timeTablePurposeDataToReturn.LegendaColor3 = timeTablePurpose.LegendaColor3;
			return timeTablePurposeDataToReturn;
		}

		#endregion

	}

}
