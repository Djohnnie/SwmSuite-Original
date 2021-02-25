using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.Business.DataMapping {
	
	public class ConnectionLogMapping : Mapping {

		public static ConnectionLog FromDataObject( ConnectionLogData connectionLogData ) {
			Mapping mapping = new ConnectionLogMapping();
			return mapping.FromDataObject( connectionLogData ) as ConnectionLog;
		}

		public static ConnectionLogData FromBusinessObject( ConnectionLog connectionLog ) {
			Mapping mapping = new ConnectionLogMapping();
			return mapping.FromBusinessObject( connectionLog ) as ConnectionLogData;
		}

		public static ConnectionLogCollection FromDataObjectCollection( ConnectionLogDataCollection connectionLogDataCollection ) {
			Mapping mapping = new ConnectionLogMapping();
			ConnectionLogCollection connectionLogCollectionToReturn = new ConnectionLogCollection();
			foreach( ConnectionLogData connectionLogData in connectionLogDataCollection ) {
				connectionLogCollectionToReturn.Add( FromDataObject( connectionLogData ) );
			}
			return connectionLogCollectionToReturn;
		}

		public static ConnectionLogDataCollection FromBusinessObjectCollection( ConnectionLogCollection connectionLogCollection ) {
			Mapping mapping = new ConnectionLogMapping();
			ConnectionLogDataCollection connectionLogDataCollectionToReturn = new ConnectionLogDataCollection();
			foreach( ConnectionLog connectionLog in connectionLogCollection ) {
				connectionLogDataCollectionToReturn.Add( FromBusinessObject( connectionLog ) );
			}
			return connectionLogDataCollectionToReturn;
		}

		#region IMapping Members

		public override BusinessObjectBase FromDataObject( DataObjectBase dataObject ) {
			ConnectionLogData connectionLogData = dataObject as ConnectionLogData;
			ConnectionLog connectionLogToReturn = new ConnectionLog();
			connectionLogToReturn.SysId = connectionLogData.SysId;
			connectionLogToReturn.RowVersion = connectionLogData.RowVersion;
			connectionLogToReturn.DateTime = connectionLogData.DateTime;
			connectionLogToReturn.Client = connectionLogData.Client;
			return connectionLogToReturn;
		}

		public override DataObjectBase FromBusinessObject( BusinessObjectBase businessObject ) {
			ConnectionLog connectionLog = businessObject as ConnectionLog;
			ConnectionLogData connectionLogDataToReturn = new ConnectionLogData();
			connectionLogDataToReturn.SysId = connectionLog.SysId;
			connectionLogDataToReturn.RowVersion = connectionLog.RowVersion;
			connectionLogDataToReturn.DateTime = connectionLog.DateTime;
			connectionLogDataToReturn.Client = connectionLog.Client;
			return connectionLogDataToReturn;
		}

		#endregion

	}

}
