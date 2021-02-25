using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.Business.DataMapping {
	
	public class LoginLogMapping : Mapping {

		private Dictionary<int , Employee> _employeeCache = new Dictionary<int , Employee>();

		public static LoginLog FromDataObject( LoginLogData loginLogData ) {
			Mapping mapping = new LoginLogMapping();
			return mapping.FromDataObject( loginLogData ) as LoginLog;
		}

		public static LoginLogData FromBusinessObject( LoginLog loginLog ) {
			Mapping mapping = new LoginLogMapping();
			return mapping.FromBusinessObject( loginLog ) as LoginLogData;
		}

		public static LoginLogCollection FromDataObjectCollection( LoginLogDataCollection loginLogDataCollection ) {
			Mapping mapping = new LoginLogMapping();
			LoginLogCollection loginLogCollectionToReturn = new LoginLogCollection();
			foreach( LoginLogData loginLogData in loginLogDataCollection ) {
				loginLogCollectionToReturn.Add( mapping.FromDataObject( loginLogData ) as LoginLog );
			}
			return loginLogCollectionToReturn;
		}

		public static LoginLogDataCollection FromBusinessObjectCollection( LoginLogCollection loginLogCollection ) {
			Mapping mapping = new LoginLogMapping();
			LoginLogDataCollection loginLogDataCollectionToReturn = new LoginLogDataCollection();
			foreach( LoginLog loginLog in loginLogCollection ) {
				loginLogDataCollectionToReturn.Add( FromBusinessObject( loginLog ) );
			}
			return loginLogDataCollectionToReturn;
		}

		#region IMapping Members

		public override BusinessObjectBase FromDataObject( DataObjectBase dataObject ) {
			LoginLogData loginLogData = dataObject as LoginLogData;
			LoginLog loginLogToReturn = new LoginLog();
			loginLogToReturn.SysId = loginLogData.SysId;
			loginLogToReturn.RowVersion = loginLogData.RowVersion;
			loginLogToReturn.DateTime = loginLogData.DateTime;
			if( _employeeCache.ContainsKey( loginLogData.EmployeeSysId ) ) {
				loginLogToReturn.Employee = _employeeCache[loginLogData.EmployeeSysId];
			} else {
				loginLogToReturn.Employee = new EmployeeBll().GetEmployeeDetail( loginLogData.EmployeeSysId );
				_employeeCache.Add( loginLogData.EmployeeSysId , loginLogToReturn.Employee );
			}
			
			return loginLogToReturn;
		}

		public override DataObjectBase FromBusinessObject( BusinessObjectBase businessObject ) {
			LoginLog loginLog = businessObject as LoginLog;
			LoginLogData loginLogDataToReturn = new LoginLogData();
			loginLogDataToReturn.SysId = loginLog.SysId;
			loginLogDataToReturn.RowVersion = loginLog.RowVersion;
			loginLogDataToReturn.DateTime = loginLog.DateTime;
			loginLogDataToReturn.EmployeeSysId = loginLog.Employee.SysId;
			return loginLogDataToReturn;
		}

		#endregion

	}

}
