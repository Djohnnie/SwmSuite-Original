using System;
using System.Collections.Generic;

using System.Text;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace SwmSuite.Data.DataObjects {

	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class AlertDataCollection : DataObjectCollectionBase<AlertData> {

		/// <summary>
		/// Get a collection for a single alert.
		/// </summary>
		/// <param name="alert">The alert to store into the collection.</param>
		/// <returns>A new AlertCollection containing the given alert.</returns>
		public static AlertDataCollection FromSingleAlert( AlertData alert ) {
			AlertDataCollection alerts = new AlertDataCollection();
			alerts.Add( alert );
			return alerts;
		}

		/// <summary>
		/// Deserializes the XML representation of an alertcollection to a new alertcollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an alertcollection.</param>
		/// <returns>A new AlertCollection deserialized from the given XML string.</returns>
		public static AlertDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( AlertDataCollection ) );
			AlertDataCollection toReturn = (AlertDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
