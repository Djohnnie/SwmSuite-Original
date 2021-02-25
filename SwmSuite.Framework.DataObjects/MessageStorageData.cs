using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class MessageStorageData : DataObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the internal id for the message.
		/// </summary>
		public int MessageSysId { get; set; }

		/// <summary>
		/// Gets or sets the internal id for the messagefolder.
		/// </summary>
		public int MessageFolderSysId { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the message represented by this instance is read.
		/// </summary>
		public bool IsRead { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the message represented by this instance is new.
		/// </summary>
		public bool IsNew { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public MessageStorageData() {

		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="messageSysId">The internal id for the message.</param>
		/// <param name="messageFolderSysId">The internal id for the messagefolder.</param>
		/// <param name="isRead">Value indicating whether the message represented by this instance is read.</param>
		/// <param name="isNew">Value indicating whether the message represented by this instance is new.</param>
		public MessageStorageData( int messageSysId , int messageFolderSysId , bool isRead , bool isNew ) {
			this.MessageSysId = messageSysId;
			this.MessageFolderSysId = messageFolderSysId;
			this.IsRead = isRead;
			this.IsNew = isNew;
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Convert this messagestorage to its string representation.
		/// </summary>
		/// <returns></returns>
		public override string ToString( ) {
			return "";
		}

		#endregion

	}

}
