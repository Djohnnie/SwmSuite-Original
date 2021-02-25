using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	public class RecurrenceDataCollection : DataObjectCollectionBase<RecurrenceData> {

		/// <summary>
		/// Get a collection for a single Recurrence.
		/// </summary>
		/// <param name="recurrence">The Recurrence to store into the collection.</param>
		/// <returns>A new MessageCollection containing the given Recurrence.</returns>
		public static RecurrenceDataCollection FromSingleRecurrence( RecurrenceData recurrence ) {
			RecurrenceDataCollection recurrences = new RecurrenceDataCollection();
			recurrences.Add( recurrence );
			return recurrences;
		}

		/// <summary>
		/// Deserializes the XML representation of an appointmentrepeatcollection to a new appointmentrepeatcollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an appointmentrepeatcollection.</param>
		/// <returns>A new AppointmentGuestCollection deserialized from the given XML string.</returns>
		public static RecurrenceDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( RecurrenceDataCollection ) );
			RecurrenceDataCollection toReturn = (RecurrenceDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
