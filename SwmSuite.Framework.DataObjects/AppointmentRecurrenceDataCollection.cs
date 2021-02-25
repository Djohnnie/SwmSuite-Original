using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	public class AppointmentRecurrenceDataCollection : DataObjectCollectionBase<AppointmentRecurrenceData> {

		/// <summary>
		/// Get a collection for a single AppointmentRecurrence.
		/// </summary>
		/// <param name="appointmentRecurrence">The AppointmentRecurrence to store into the collection.</param>
		/// <returns>A new MessageCollection containing the given AppointmentRecurrence.</returns>
		public static AppointmentRecurrenceDataCollection FromSingleAppointmentRecurrence( AppointmentRecurrenceData appointmentRecurrence ) {
			AppointmentRecurrenceDataCollection appointmentRecurrences = new AppointmentRecurrenceDataCollection();
			appointmentRecurrences.Add( appointmentRecurrence );
			return appointmentRecurrences;
		}

		/// <summary>
		/// Deserializes the XML representation of an appointmentrecurrencecollection to a new appointmentrecurrencecollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an appointmentrecurrencecollection.</param>
		/// <returns>A new AppointmentRecurrenceCollection deserialized from the given XML string.</returns>
		public static AppointmentRecurrenceDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( AppointmentRecurrenceDataCollection ) );
			AppointmentRecurrenceDataCollection toReturn = (AppointmentRecurrenceDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
