using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.Business.DataMapping {
	
	public class HolidayDefinitionMapping : Mapping {

		public static HolidayDefinition FromDataObject( HolidayDefinitionData holidayDefinitionData ) {
			Mapping mapping = new HolidayDefinitionMapping();
			return mapping.FromDataObject( holidayDefinitionData ) as HolidayDefinition;
		}

		public static HolidayDefinitionData FromBusinessObject( HolidayDefinition holidayDefinition ) {
			Mapping mapping = new HolidayDefinitionMapping();
			return mapping.FromBusinessObject( holidayDefinition ) as HolidayDefinitionData;
		}

		public static HolidayDefinitionCollection FromDataObjectCollection( HolidayDefinitionDataCollection holidayDefinitionDataCollection ) {
			Mapping mapping = new HolidayDefinitionMapping();
			HolidayDefinitionCollection holidayDefinitionCollectionToReturn = new HolidayDefinitionCollection();
			foreach( HolidayDefinitionData holidayDefinitionData in holidayDefinitionDataCollection ) {
				holidayDefinitionCollectionToReturn.Add( FromDataObject( holidayDefinitionData ) );
			}
			return holidayDefinitionCollectionToReturn;
		}

		public static HolidayDefinitionDataCollection FromBusinessObjectCollection( HolidayDefinitionCollection holidayDefinitionCollection ) {
			Mapping mapping = new HolidayDefinitionMapping();
			HolidayDefinitionDataCollection holidayDefinitionDataCollectionToReturn = new HolidayDefinitionDataCollection();
			foreach( HolidayDefinition holidayDefinition in holidayDefinitionCollection ) {
				holidayDefinitionDataCollectionToReturn.Add( FromBusinessObject( holidayDefinition ) );
			}
			return holidayDefinitionDataCollectionToReturn;
		}

		#region IMapping Members

		public override BusinessObjectBase FromDataObject( DataObjectBase dataObject ) {
			HolidayDefinitionData holidayDefinitionData = dataObject as HolidayDefinitionData;
			HolidayDefinition holidayDefinitionToReturn = new HolidayDefinition();
			holidayDefinitionToReturn.SysId = holidayDefinitionData.SysId;
			holidayDefinitionToReturn.RowVersion = holidayDefinitionData.RowVersion;
			holidayDefinitionToReturn.Name = holidayDefinitionData.Name;
			holidayDefinitionToReturn.RecurringHoliday = holidayDefinitionData.RecurringHoliday;
			holidayDefinitionToReturn.DateStart = holidayDefinitionData.DateStart;
			holidayDefinitionToReturn.DateEnd = holidayDefinitionData.DateEnd;
			return holidayDefinitionToReturn;
		}

		public override DataObjectBase FromBusinessObject( BusinessObjectBase businessObject ) {
			HolidayDefinition holidayDefinition = businessObject as HolidayDefinition;
			HolidayDefinitionData holidayDefinitionDataToReturn = new HolidayDefinitionData();
			holidayDefinitionDataToReturn.SysId = holidayDefinition.SysId;
			holidayDefinitionDataToReturn.RowVersion = holidayDefinition.RowVersion;
			holidayDefinitionDataToReturn.Name = holidayDefinition.Name;
			holidayDefinitionDataToReturn.RecurringHoliday = holidayDefinition.RecurringHoliday;
			holidayDefinitionDataToReturn.DateStart = holidayDefinition.DateStart;
			holidayDefinitionDataToReturn.DateEnd = holidayDefinition.DateEnd;
			return holidayDefinitionDataToReturn;
		}

		#endregion

	}

}
