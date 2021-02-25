using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.Business.DataMapping {
	
	public class MessageFolderMapping : Mapping {

		public static MessageFolder FromDataObject( MessageFolderData messageFolderData ) {
			Mapping mapping = new MessageFolderMapping();
			return mapping.FromDataObject( messageFolderData ) as MessageFolder;
		}

		public static MessageFolderData FromBusinessObject( MessageFolder messageFolder ) {
			Mapping mapping = new MessageFolderMapping();
			return mapping.FromBusinessObject( messageFolder ) as MessageFolderData;
		}

		public static MessageFolderCollection FromDataObjectCollection( MessageFolderDataCollection messageFolderDataCollection ) {
			Mapping mapping = new MessageFolderMapping();
			MessageFolderCollection messageFolderCollectionToReturn = new MessageFolderCollection();
			foreach( MessageFolderData messageFolderData in messageFolderDataCollection ) {
				messageFolderCollectionToReturn.Add( FromDataObject( messageFolderData ) );
			}
			return messageFolderCollectionToReturn;
		}

		public static MessageFolderDataCollection FromBusinessObjectCollection( MessageFolderCollection messageFolderCollection ) {
			Mapping mapping = new MessageFolderMapping();
			MessageFolderDataCollection messageFolderDataCollectionToReturn = new MessageFolderDataCollection();
			foreach( MessageFolder messageFolder in messageFolderCollection ) {
				messageFolderDataCollectionToReturn.Add( FromBusinessObject( messageFolder ) );
			}
			return messageFolderDataCollectionToReturn;
		}

		#region IMapping Members

		public override BusinessObjectBase FromDataObject( DataObjectBase dataObject ) {
			MessageFolderData messageFolderData = dataObject as MessageFolderData;
			MessageFolder messageFolderToReturn = new MessageFolder();
			messageFolderToReturn.SysId = messageFolderData.SysId;
			messageFolderToReturn.RowVersion = messageFolderData.RowVersion;
			messageFolderToReturn.Name = messageFolderData.Name;
			messageFolderToReturn.SpecialFolder = messageFolderData.SpecialFolder;
			messageFolderToReturn.Visible = messageFolderData.Visible;
			return messageFolderToReturn;
		}

		public override DataObjectBase FromBusinessObject( BusinessObjectBase businessObject ) {
			MessageFolder messageFolder = businessObject as MessageFolder;
			MessageFolderData messageFolderDataToReturn = new MessageFolderData();
			messageFolderDataToReturn.SysId = messageFolder.SysId;
			messageFolderDataToReturn.RowVersion = messageFolder.RowVersion;
			messageFolderDataToReturn.Name = messageFolder.Name;
			messageFolderDataToReturn.SpecialFolder = messageFolder.SpecialFolder;
			messageFolderDataToReturn.Visible = messageFolder.Visible;
			return messageFolderDataToReturn;
		}

		#endregion

	}

}
