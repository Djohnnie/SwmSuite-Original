using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.BusinessObjects {

	/// <summary>
	/// Class defining a collection of alerts.
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class AlertCollection : BusinessObjectCollectionBase<Alert> {

		/// <summary>
		/// Get a collection for a single alert.
		/// </summary>
		/// <param name="alert">The alert to store into the collection.</param>
		/// <returns>A new AlertCollection containing the given alert.</returns>
		public static AlertCollection FromSingleAlert( Alert alert ) {
			AlertCollection alerts = new AlertCollection();
			alerts.Add( alert );
			return alerts;
		}

		/// <summary>
		/// Deserializes the XML representation of an alertcollection to a new alertcollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an alertcollection.</param>
		/// <returns>A new AlertCollection deserialized from the given XML string.</returns>
		public static AlertCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( AlertCollection ) );
			AlertCollection toReturn = (AlertCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

		/// <summary>
		/// Convert this AlertCollection to its string representation.
		/// </summary>
		/// <returns>A string containing all alert messages seperated by a dash.</returns>
		public override string ToString() {
			String toReturn = String.Empty;
			if( this.Count > 0 ) {
				toReturn = "   -   ";
				foreach( Alert alert in this ) {
					toReturn += alert.Message + "   -   ";
				}
			}
			return toReturn;
		}

	}

}
