using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.BusinessObjects {

  /// <summary>
  /// Class defining a collection of messagefolders.
  /// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class MessageFolderCollection : BusinessObjectCollectionBase<MessageFolder> {

		/// <summary>
		/// Get a collection for a single messageFolder.
		/// </summary>
		/// <param name="messageFolder">The messageFolder to store into the collection.</param>
		/// <returns>A new MessageFolderCollection containing the given messageFolder.</returns>
		public static MessageFolderCollection FromSingleMessageFolder( MessageFolder messageFolder ) {
			MessageFolderCollection messageFolders = new MessageFolderCollection();
			messageFolders.Add( messageFolder );
			return messageFolders;
		}

		/// <summary>
		/// Deserializes the XML representation of an messageFoldercollection to a new messageFoldercollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an messageFoldercollection.</param>
		/// <returns>A new MessageFolderCollection deserialized from the given XML string.</returns>
		public static MessageFolderCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( MessageFolderCollection ) );
			MessageFolderCollection toReturn = (MessageFolderCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
