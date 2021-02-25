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
	public class AppointmentDataCollection : DataObjectCollectionBase<AppointmentData> {

		/// <summary>
		/// Get a collection for a single appointment.
		/// </summary>
		/// <param name="appointment">The appointment to store into the collection.</param>
		/// <returns>A new AppointmentCollection containing the given appointment.</returns>
		public static AppointmentDataCollection FromSingleAppointment( AppointmentData appointment ) {
			AppointmentDataCollection appointments = new AppointmentDataCollection();
			appointments.Add( appointment );
			return appointments;
		}

		/// <summary>
		/// Deserializes the XML representation of an appointmentcollection to a new appointmentcollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an appointmentcollection.</param>
		/// <returns>A new AppointmentCollection deserialized from the given XML string.</returns>
		public static AppointmentDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( AppointmentDataCollection ) );
			AppointmentDataCollection toReturn = (AppointmentDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}
}
