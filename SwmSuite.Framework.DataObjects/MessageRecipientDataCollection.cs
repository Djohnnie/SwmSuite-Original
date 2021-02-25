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
	public class MessageRecipientDataCollection : DataObjectCollectionBase<MessageRecipientData> {

		/// <summary>
		/// Get a collection for a single MessageRecipient.
		/// </summary>
		/// <param name="messageRecipient">The MessageRecipient to store into the collection.</param>
		/// <returns>A new MessageCollection containing the given MessageRecipient.</returns>
		public static MessageRecipientDataCollection FromSingleMessageRecipient( MessageRecipientData messageRecipient ) {
			MessageRecipientDataCollection messageRecipients = new MessageRecipientDataCollection();
			messageRecipients.Add( messageRecipient );
			return messageRecipients;
		}

		/// <summary>
		/// Deserializes the XML representation of an messagerecipientcollection to a new messagerecipientcollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an messagerecipientcollection.</param>
		/// <returns>A new MessageRecipientCollection deserialized from the given XML string.</returns>
		public static MessageRecipientDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( MessageRecipientDataCollection ) );
			MessageRecipientDataCollection toReturn = (MessageRecipientDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}
}
