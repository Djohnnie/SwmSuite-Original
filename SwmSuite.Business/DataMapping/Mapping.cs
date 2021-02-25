using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.Business.DataMapping {

	public abstract class Mapping {

		public abstract BusinessObjectBase FromDataObject( DataObjectBase dataObject );

		public abstract DataObjectBase FromBusinessObject( BusinessObjectBase businessObject );

		public BusinessObjectCollectionBase<BusinessObjectBase> FromDataObjectCollection( DataObjectCollectionBase<DataObjectBase> dataObjectCollection ) {
			BusinessObjectCollectionBase<BusinessObjectBase> collectionToReturn = new BusinessObjectCollectionBase<BusinessObjectBase>();
			foreach( DataObjectBase dataObject in dataObjectCollection ) {
				collectionToReturn.Add( FromDataObject( dataObject ) );
			}
			return collectionToReturn;
		}

		public DataObjectCollectionBase<DataObjectBase> FromBusinessObjectCollection( BusinessObjectCollectionBase<BusinessObjectBase> businessObjectCollection ) {
			DataObjectCollectionBase<DataObjectBase> collectionToReturn = new DataObjectCollectionBase<DataObjectBase>();
			foreach( BusinessObjectBase businessObject in businessObjectCollection ) {
				collectionToReturn.Add( FromBusinessObject( businessObject ) );
			}
			return collectionToReturn;
		}

	}
}
