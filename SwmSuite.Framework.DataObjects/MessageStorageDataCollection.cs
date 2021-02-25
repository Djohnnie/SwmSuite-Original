using System;
using System.Collections.Generic;

using System.Text;
using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	/// <summary>
	/// 
	/// </summary>
	public class MessageStorageDataCollection : DataObjectCollectionBase<MessageStorageData> {

		/// <summary>
		/// Get a collection for a single MessageStorage.
		/// </summary>
		/// <param name="messageStorage">The MessageStorage to store into the collection.</param>
		/// <returns>A new MessageCollection containing the given MessageStorage.</returns>
		public static MessageStorageDataCollection FromSingleMessageStorage( MessageStorageData messageStorage ) {
			MessageStorageDataCollection messageStorages = new MessageStorageDataCollection();
			messageStorages.Add( messageStorage );
			return messageStorages;
		}

		/// <summary>
		/// Deserializes the XML representation of an messagestoragecollection to a new messagestoragecollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an messagestoragecollection.</param>
		/// <returns>A new MessageStorageCollection deserialized from the given XML string.</returns>
		public static MessageStorageDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( MessageStorageDataCollection ) );
			MessageStorageDataCollection toReturn = (MessageStorageDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
