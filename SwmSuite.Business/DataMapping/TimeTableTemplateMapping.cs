using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.Business.DataMapping {

	public class TimeTableTemplateMapping : Mapping {

		public static TimeTableTemplate FromDataObject( TimeTableTemplateData timeTableTemplateData ) {
			Mapping mapping = new TimeTableTemplateMapping();
			return mapping.FromDataObject( timeTableTemplateData ) as TimeTableTemplate;
		}

		public static TimeTableTemplateData FromBusinessObject( TimeTableTemplate timeTableTemplate ) {
			Mapping mapping = new TimeTableTemplateMapping();
			return mapping.FromBusinessObject( timeTableTemplate ) as TimeTableTemplateData;
		}

		public static TimeTableTemplateCollection FromDataObjectCollection( TimeTableTemplateDataCollection timeTableTemplateDataCollection ) {
			Mapping mapping = new TimeTableTemplateMapping();
			TimeTableTemplateCollection timeTableTemplateCollectionToReturn = new TimeTableTemplateCollection();
			foreach( TimeTableTemplateData timeTableTemplateData in timeTableTemplateDataCollection ) {
				timeTableTemplateCollectionToReturn.Add( FromDataObject( timeTableTemplateData ) );
			}
			return timeTableTemplateCollectionToReturn;
		}

		public static TimeTableTemplateDataCollection FromBusinessObjectCollection( TimeTableTemplateCollection timeTableTemplateCollection ) {
			Mapping mapping = new TimeTableTemplateMapping();
			TimeTableTemplateDataCollection timeTableTemplateDataCollectionToReturn = new TimeTableTemplateDataCollection();
			foreach( TimeTableTemplate timeTableTemplate in timeTableTemplateCollection ) {
				timeTableTemplateDataCollectionToReturn.Add( FromBusinessObject( timeTableTemplate ) );
			}
			return timeTableTemplateDataCollectionToReturn;
		}

		#region IMapping Members

		public override BusinessObjectBase FromDataObject( DataObjectBase dataObject ) {
			TimeTableTemplateData timeTableTemplateData = dataObject as TimeTableTemplateData;
			TimeTableTemplate timeTableTemplateToReturn = new TimeTableTemplate();
			timeTableTemplateToReturn.SysId = timeTableTemplateData.SysId;
			timeTableTemplateToReturn.RowVersion = timeTableTemplateData.RowVersion;
			timeTableTemplateToReturn.Name = timeTableTemplateData.Name;
			timeTableTemplateToReturn.Description = timeTableTemplateData.Description;
			timeTableTemplateToReturn.EmployeeGroup = new EmployeeGroupBll().GetEmployeeGroupDetail( timeTableTemplateData.EmployeeGroupSysId );
			return timeTableTemplateToReturn;
		}

		public override DataObjectBase FromBusinessObject( BusinessObjectBase businessObject ) {
			TimeTableTemplate timeTableTemplate = businessObject as TimeTableTemplate;
			TimeTableTemplateData timeTableTemplateDataToReturn = new TimeTableTemplateData();
			timeTableTemplateDataToReturn.SysId = timeTableTemplate.SysId;
			timeTableTemplateDataToReturn.RowVersion = timeTableTemplate.RowVersion;
			timeTableTemplateDataToReturn.Name = timeTableTemplate.Name;
			timeTableTemplateDataToReturn.Description = timeTableTemplate.Description;
			if( timeTableTemplate.EmployeeGroup != null ) {
				timeTableTemplateDataToReturn.EmployeeGroupSysId = timeTableTemplate.EmployeeGroup.SysId;
			}
			return timeTableTemplateDataToReturn;
		}

		#endregion

	}

}
