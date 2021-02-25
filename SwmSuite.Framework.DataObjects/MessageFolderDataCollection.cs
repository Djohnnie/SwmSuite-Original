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
	public class MessageFolderDataCollection : DataObjectCollectionBase<MessageFolderData> {

		/// <summary>
		/// Get a collection for a single MessageFolder.
		/// </summary>
		/// <param name="messageFolder">The MessageFolder to store into the collection.</param>
		/// <returns>A new MessageCollection containing the given MessageFolder.</returns>
		public static MessageFolderDataCollection FromSingleMessageFolder( MessageFolderData messageFolder ) {
			MessageFolderDataCollection messageFolders = new MessageFolderDataCollection();
			messageFolders.Add( messageFolder );
			return messageFolders;
		}

		/// <summary>
		/// Deserializes the XML representation of an messagefoldercollection to a new messagefoldercollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an messagefoldercollection.</param>
		/// <returns>A new MessageFolderCollection deserialized from the given XML string.</returns>
		public static MessageFolderDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( MessageFolderDataCollection ) );
			MessageFolderDataCollection toReturn = (MessageFolderDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
