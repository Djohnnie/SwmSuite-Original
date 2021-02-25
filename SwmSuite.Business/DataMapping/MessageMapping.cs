using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.Business.DataMapping {

	public class MessageMapping : Mapping {

		public static Message FromDataObject( MessageData messageData ) {
			Mapping mapping = new MessageMapping();
			return mapping.FromDataObject( messageData ) as Message;
		}

		public static MessageData FromBusinessObject( Message message ) {
			Mapping mapping = new MessageMapping();
			return mapping.FromBusinessObject( message ) as MessageData;
		}

		public static MessageCollection FromDataObjectCollection( MessageDataCollection messageDataCollection ) {
			Mapping mapping = new MessageMapping();
			MessageCollection messageCollectionToReturn = new MessageCollection();
			foreach( MessageData messageData in messageDataCollection ) {
				messageCollectionToReturn.Add( FromDataObject( messageData ) );
			}
			return messageCollectionToReturn;
		}

		public static MessageDataCollection FromBusinessObjectCollection( MessageCollection messageCollection ) {
			Mapping mapping = new MessageMapping();
			MessageDataCollection messageDataCollectionToReturn = new MessageDataCollection();
			foreach( Message message in messageCollection ) {
				messageDataCollectionToReturn.Add( FromBusinessObject( message ) );
			}
			return messageDataCollectionToReturn;
		}

		#region IMapping Members

		public override BusinessObjectBase FromDataObject( DataObjectBase dataObject ) {
			MessageData messageData = dataObject as MessageData;
			Message messageToReturn = new Message();
			messageToReturn.SysId = messageData.SysId;
			messageToReturn.RowVersion = messageData.RowVersion;
			messageToReturn.Date = messageData.Date;
			messageToReturn.Subject = messageData.Subject;
			messageToReturn.Contents = messageData.Content;
			messageToReturn.Priority = messageData.Priority;
			messageToReturn.Visible = messageData.Visible;
			messageToReturn.Sender = new EmployeeBll().GetEmployeeDetail( messageData.FromEmployeeSysId );
			return messageToReturn;
		}

		public override DataObjectBase FromBusinessObject( BusinessObjectBase businessObject ) {
			Message message = businessObject as Message;
			MessageData messageDataToReturn = new MessageData();
			messageDataToReturn.SysId = message.SysId;
			messageDataToReturn.RowVersion = message.RowVersion;
			messageDataToReturn.Date = message.Date;
			messageDataToReturn.Subject = message.Subject;
			messageDataToReturn.Content = message.Contents;
			messageDataToReturn.Priority = message.Priority;
			messageDataToReturn.Visible = message.Visible;
			messageDataToReturn.FromEmployeeSysId = message.Sender.SysId;
			return messageDataToReturn;
		}

		#endregion

	}

}
