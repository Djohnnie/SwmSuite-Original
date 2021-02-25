using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.BusinessObjects {

  /// <summary>
  /// Class defining a collection of messages.
  /// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class MessageCollection : BusinessObjectCollectionBase<Message> {

		/// <summary>
		/// Get a collection for a single message.
		/// </summary>
		/// <param name="messages">The message to store into the collection.</param>
		/// <returns>A new MessagesCollection containing the given message.</returns>
		public static MessageCollection FromSingleMessages( Message message ) {
			MessageCollection messages = new MessageCollection();
			messages.Add( messages );
			return messages;
		}

		/// <summary>
		/// Deserializes the XML representation of an messagecollection to a new messagecollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an messagecollection.</param>
		/// <returns>A new MessageCollection deserialized from the given XML string.</returns>
		public static MessageCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( MessageCollection ) );
			MessageCollection toReturn = (MessageCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
