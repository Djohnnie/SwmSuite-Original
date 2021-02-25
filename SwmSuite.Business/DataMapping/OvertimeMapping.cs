using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.Business.DataMapping {
	
	public class OvertimeEntryMapping : Mapping {

		public static OvertimeEntry FromDataObject( OvertimeEntryData overtimeEntryData ) {
			Mapping mapping = new OvertimeEntryMapping();
			return mapping.FromDataObject( overtimeEntryData ) as OvertimeEntry;
		}

		public static OvertimeEntryData FromBusinessObject( OvertimeEntry overtimeEntry ) {
			Mapping mapping = new OvertimeEntryMapping();
			return mapping.FromBusinessObject( overtimeEntry ) as OvertimeEntryData;
		}

		public static OvertimeEntryCollection FromDataObjectCollection( OvertimeEntryDataCollection overtimeEntryDataCollection ) {
			Mapping mapping = new OvertimeEntryMapping();
			OvertimeEntryCollection overtimeEntryCollectionToReturn = new OvertimeEntryCollection();
			foreach( OvertimeEntryData overtimeEntryData in overtimeEntryDataCollection ) {
				overtimeEntryCollectionToReturn.Add( FromDataObject( overtimeEntryData ) );
			}
			return overtimeEntryCollectionToReturn;
		}

		public static OvertimeEntryDataCollection FromBusinessObjectCollection( OvertimeEntryCollection overtimeEntryCollection ) {
			Mapping mapping = new OvertimeEntryMapping();
			OvertimeEntryDataCollection overtimeEntryDataCollectionToReturn = new OvertimeEntryDataCollection();
			foreach( OvertimeEntry overtimeEntry in overtimeEntryCollection ) {
				overtimeEntryDataCollectionToReturn.Add( FromBusinessObject( overtimeEntry ) );
			}
			return overtimeEntryDataCollectionToReturn;
		}

		#region IMapping Members

		public override BusinessObjectBase FromDataObject( DataObjectBase dataObject ) {
			OvertimeEntryData overtimeEntryData = dataObject as OvertimeEntryData;
			OvertimeEntry overtimeEntryToReturn = new OvertimeEntry();
			overtimeEntryToReturn.SysId = overtimeEntryData.SysId;
			overtimeEntryToReturn.RowVersion = overtimeEntryData.RowVersion;
			overtimeEntryToReturn.Description = overtimeEntryData.Description;
			overtimeEntryToReturn.DateTimeStart = overtimeEntryData.DateTimeStart;
			overtimeEntryToReturn.DateTimeEnd = overtimeEntryData.DateTimeEnd;
			overtimeEntryToReturn.Employee = new EmployeeBll().GetEmployeeDetail( overtimeEntryData.EmployeeSysId );
			overtimeEntryToReturn.OvertimeStatus = overtimeEntryData.OvertimeStatus;
			overtimeEntryToReturn.Commissioner = new EmployeeBll().GetEmployeeDetail( overtimeEntryData.CommissionerSysId );
			return overtimeEntryToReturn;
		}

		public override DataObjectBase FromBusinessObject( BusinessObjectBase businessObject ) {
			OvertimeEntry overtimeEntry = businessObject as OvertimeEntry;
			OvertimeEntryData overtimeEntryDataToReturn = new OvertimeEntryData();
			overtimeEntryDataToReturn.SysId = overtimeEntry.SysId;
			overtimeEntryDataToReturn.RowVersion = overtimeEntry.RowVersion;
			overtimeEntryDataToReturn.Description = overtimeEntry.Description;
			overtimeEntryDataToReturn.DateTimeStart = overtimeEntry.DateTimeStart;
			overtimeEntryDataToReturn.DateTimeEnd = overtimeEntry.DateTimeEnd;
			overtimeEntryDataToReturn.EmployeeSysId = overtimeEntry.Employee.SysId;
			overtimeEntryDataToReturn.OvertimeStatus = overtimeEntry.OvertimeStatus;
			overtimeEntryDataToReturn.CommissionerSysId = overtimeEntry.Commissioner.SysId;
			return overtimeEntryDataToReturn;
		}

		#endregion

	}

}
