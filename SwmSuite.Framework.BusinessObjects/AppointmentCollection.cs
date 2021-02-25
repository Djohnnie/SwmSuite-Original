using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.BusinessObjects;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.BusinessObjects {

	/// <summary>
	/// Class defining a collection of alerts.
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class AppointmentCollection : BusinessObjectCollectionBase<Appointment> {

		/// <summary>
		/// Get a collection for a single appointment.
		/// </summary>
		/// <param name="appointment">The appointment to store into the collection.</param>
		/// <returns>A new AppointmentCollection containing the given appointment.</returns>
		public static AppointmentCollection FromSingleAppointment( Appointment appointment ) {
			AppointmentCollection appointments = new AppointmentCollection();
			appointments.Add( appointment );
			return appointments;
		}

		/// <summary>
		/// Deserializes the XML representation of an appointmentcollection to a new appointmentcollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an appointmentcollection.</param>
		/// <returns>A new AppointmentCollection deserialized from the given XML string.</returns>
		public static AppointmentCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( AppointmentCollection ) );
			AppointmentCollection toReturn = (AppointmentCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
