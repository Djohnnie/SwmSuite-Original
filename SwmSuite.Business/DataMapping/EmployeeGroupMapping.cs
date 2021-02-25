using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.Business.DataMapping {
	
	public class EmployeeGroupMapping : Mapping {

		public static EmployeeGroup FromDataObject( EmployeeGroupData employeeGroupData ) {
			Mapping mapping = new EmployeeGroupMapping();
			return mapping.FromDataObject( employeeGroupData ) as EmployeeGroup;
		}

		public static EmployeeGroupData FromBusinessObject( EmployeeGroup employeeGroup ) {
			Mapping mapping = new EmployeeGroupMapping();
			return mapping.FromBusinessObject( employeeGroup ) as EmployeeGroupData;
		}

		public static EmployeeGroupCollection FromDataObjectCollection( EmployeeGroupDataCollection employeeGroupDataCollection ) {
			Mapping mapping = new EmployeeGroupMapping();
			EmployeeGroupCollection employeeGroupCollectionToReturn = new EmployeeGroupCollection();
			foreach( EmployeeGroupData employeeGroupData in employeeGroupDataCollection ) {
				employeeGroupCollectionToReturn.Add( FromDataObject( employeeGroupData ) );
			}
			return employeeGroupCollectionToReturn;
		}

		public static EmployeeGroupDataCollection FromBusinessObjectCollection( EmployeeGroupCollection employeeGroupCollection ) {
			Mapping mapping = new EmployeeGroupMapping();
			EmployeeGroupDataCollection employeeGroupDataCollectionToReturn = new EmployeeGroupDataCollection();
			foreach( EmployeeGroup employeeGroup in employeeGroupCollection ) {
				employeeGroupDataCollectionToReturn.Add( FromBusinessObject( employeeGroup ) );
			}
			return employeeGroupDataCollectionToReturn;
		}

		#region IMapping Members

		public override BusinessObjectBase FromDataObject( DataObjectBase dataObject ) {
			EmployeeGroupData employeeGroupData = dataObject as EmployeeGroupData;
			EmployeeGroup employeeGroupToReturn = new EmployeeGroup();
			employeeGroupToReturn.SysId = employeeGroupData.SysId;
			employeeGroupToReturn.RowVersion = employeeGroupData.RowVersion;
			employeeGroupToReturn.Name = employeeGroupData.Name;
			employeeGroupToReturn.Description = employeeGroupData.Description;
			return employeeGroupToReturn;
		}

		public override DataObjectBase FromBusinessObject( BusinessObjectBase businessObject ) {
			EmployeeGroup employeeGroup = businessObject as EmployeeGroup;
			EmployeeGroupData employeeGroupDataToReturn = new EmployeeGroupData();
			employeeGroupDataToReturn.SysId = employeeGroup.SysId;
			employeeGroupDataToReturn.RowVersion = employeeGroup.RowVersion;
			employeeGroupDataToReturn.Name = employeeGroup.Name;
			employeeGroupDataToReturn.Description = employeeGroup.Description;
			return employeeGroupDataToReturn;
		}

		#endregion

	}
}
