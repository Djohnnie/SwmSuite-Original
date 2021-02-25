using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class ConnectionLogDataCollection : DataObjectCollectionBase<ConnectionLogData> {

		/// <summary>
		/// Get a collection for a single connectionLog.
		/// </summary>
		/// <param name="alert">The connectionLog to store into the collection.</param>
		/// <returns>A new ConnectionLogCollection containing the given alert.</returns>
		public static ConnectionLogDataCollection FromSingleConnectionLog( ConnectionLogData connectionLog ) {
			ConnectionLogDataCollection connectionLogs = new ConnectionLogDataCollection();
			connectionLogs.Add( connectionLog );
			return connectionLogs;
		}

		/// <summary>
		/// Deserializes the XML representation of an connectionLogcollection to a new connectionLogcollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an connectionLogcollection.</param>
		/// <returns>A new ConnectionLogCollection deserialized from the given XML string.</returns>
		public static ConnectionLogDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( ConnectionLogDataCollection ) );
			ConnectionLogDataCollection toReturn = (ConnectionLogDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
