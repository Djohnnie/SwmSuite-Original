using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace SwmSuite.Data.BusinessObjects {

	/// <summary>
	/// Class defining an employee.
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class ConnectionLogCollection : BusinessObjectCollectionBase<ConnectionLog> {

		/// <summary>
		/// Get a collection for a single connectionLog.
		/// </summary>
		/// <param name="connectionLog">The connectionLog to store into the collection.</param>
		/// <returns>A new ConnectionLogCollection containing the given connectionLog.</returns>
		public static ConnectionLogCollection FromSingleConnectionLog( ConnectionLog connectionLog ) {
			ConnectionLogCollection connectionLogs = new ConnectionLogCollection();
			connectionLogs.Add( connectionLog );
			return connectionLogs;
		}

		/// <summary>
		/// Deserializes the XML representation of an ConnectionLogCollection to a new ConnectionLogCollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an connectionLogcollection.</param>
		/// <returns>A new ConnectionLogCollection deserialized from the given XML string.</returns>
		public static ConnectionLogCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( ConnectionLogCollection ) );
			ConnectionLogCollection toReturn = (ConnectionLogCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
