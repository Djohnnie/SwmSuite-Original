using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using SwmSuite.Data.BusinessObjects;
using System.IO;
using System.Xml;

namespace SwmSuite.Data.BusinessObjects {

	/// <summary>
	/// Class defining a collection of recurrences.
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class RecurrenceCollection : BusinessObjectCollectionBase<Recurrence> {

		/// <summary>
		/// Get a collection for a single recurrence.
		/// </summary>
		/// <param name="recurrence">The recurrence to store into the collection.</param>
		/// <returns>A new RecurrenceCollection containing the given recurrence.</returns>
		public static RecurrenceCollection FromSingleRecurrence( Recurrence recurrence ) {
			RecurrenceCollection recurrences = new RecurrenceCollection();
			recurrences.Add( recurrence );
			return recurrences;
		}

		/// <summary>
		/// Deserializes the XML representation of an recurrencecollection to a new recurrencecollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an recurrencecollection.</param>
		/// <returns>A new RecurrenceCollection deserialized from the given XML string.</returns>
		public static RecurrenceCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( RecurrenceCollection ) );
			RecurrenceCollection toReturn = (RecurrenceCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
