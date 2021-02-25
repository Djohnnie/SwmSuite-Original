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
	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class AgendaDataCollection : DataObjectCollectionBase<AgendaData> {

		/// <summary>
		/// Get a collection for a single agenda.
		/// </summary>
		/// <param name="agenda">The agenda to store into the collection.</param>
		/// <returns>A new AgendaCollection containing the given agenda.</returns>
		public static AgendaDataCollection FromSingleAgenda( AgendaData agenda ) {
			AgendaDataCollection agendas = new AgendaDataCollection();
			agendas.Add( agenda );
			return agendas;
		}

		/// <summary>
		/// Deserializes the XML representation of an agendacollection to a new agendacollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an agendacollection.</param>
		/// <returns>A new AgendaCollection deserialized from the given XML string.</returns>
		public static AgendaDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( AgendaDataCollection ) );
			AgendaDataCollection toReturn = (AgendaDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
