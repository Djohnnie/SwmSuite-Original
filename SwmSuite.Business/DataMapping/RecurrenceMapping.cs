using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.BusinessObjects;

namespace SwmSuite.Business.DataMapping {
	
	public class RecurrenceMapping : Mapping {

		public static Recurrence FromDataObject( RecurrenceData recurrenceData ) {
			Mapping mapping = new RecurrenceMapping();
			return mapping.FromDataObject( recurrenceData ) as Recurrence;
		}

		public static RecurrenceData FromBusinessObject( Recurrence recurrence ) {
			Mapping mapping = new RecurrenceMapping();
			return mapping.FromBusinessObject( recurrence ) as RecurrenceData;
		}

		public static RecurrenceCollection FromDataObjectCollection( RecurrenceDataCollection recurrenceDataCollection ) {
			Mapping mapping = new RecurrenceMapping();
			RecurrenceCollection recurrenceCollectionToReturn = new RecurrenceCollection();
			foreach( RecurrenceData recurrenceData in recurrenceDataCollection ) {
				recurrenceCollectionToReturn.Add( FromDataObject( recurrenceData ) );
			}
			return recurrenceCollectionToReturn;
		}

		public static RecurrenceDataCollection FromBusinessObjectCollection( RecurrenceCollection recurrenceCollection ) {
			Mapping mapping = new RecurrenceMapping();
			RecurrenceDataCollection recurrenceDataCollectionToReturn = new RecurrenceDataCollection();
			foreach( Recurrence recurrence in recurrenceCollection ) {
				recurrenceDataCollectionToReturn.Add( FromBusinessObject( recurrence ) );
			}
			return recurrenceDataCollectionToReturn;
		}

		#region IMapping Members

		public override BusinessObjectBase FromDataObject( DataObjectBase dataObject ) {
			RecurrenceData recurrenceData = dataObject as RecurrenceData;
			Recurrence recurrenceToReturn = new Recurrence();
			recurrenceToReturn.SysId = recurrenceData.SysId;
			recurrenceToReturn.RowVersion = recurrenceData.RowVersion;
			recurrenceToReturn.Description = recurrenceData.Description;
			return recurrenceToReturn;
		}

		public override DataObjectBase FromBusinessObject( BusinessObjectBase businessObject ) {
			Recurrence recurrence = businessObject as Recurrence;
			RecurrenceData recurrenceDataToReturn = new RecurrenceData();
			recurrenceDataToReturn.SysId = recurrence.SysId;
			recurrenceDataToReturn.RowVersion = recurrence.RowVersion;
			recurrenceDataToReturn.Description = recurrence.Description;
			return recurrenceDataToReturn;
		}

		#endregion

	}

}
