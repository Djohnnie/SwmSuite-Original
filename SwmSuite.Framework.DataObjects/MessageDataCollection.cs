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
	public class MessageDataCollection : DataObjectCollectionBase<MessageData> {

		/// <summary>
		/// Get a collection for a single message.
		/// </summary>
		/// <param name="message">The message to store into the collection.</param>
		/// <returns>A new MessageCollection containing the given message.</returns>
		public static MessageDataCollection FromSingleMessage( MessageData message ) {
			MessageDataCollection messages = new MessageDataCollection();
			messages.Add( message );
			return messages;
		}

		/// <summary>
		/// Deserializes the XML representation of an messagecollection to a new messagecollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an messagecollection.</param>
		/// <returns>A new MessageCollection deserialized from the given XML string.</returns>
		public static MessageDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( MessageDataCollection ) );
			MessageDataCollection toReturn = (MessageDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
