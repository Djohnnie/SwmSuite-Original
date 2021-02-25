using System;
using System.Collections.Generic;

using System.Text;
using System.Collections;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace SwmSuite.Data.DataObjects {
	
	/// <summary>
	/// 
	/// </summary>
	public class AppointmentGuestDataCollection : DataObjectCollectionBase<AppointmentGuestData> {

		/// <summary>
		/// Get a collection for a single AppointmentGuest.
		/// </summary>
		/// <param name="appointmentGuest">The AppointmentGuest to store into the collection.</param>
		/// <returns>A new MessageCollection containing the given AppointmentGuest.</returns>
		public static AppointmentGuestDataCollection FromSingleAppointmentGuest( AppointmentGuestData appointmentGuest ) {
			AppointmentGuestDataCollection appointmentGuests = new AppointmentGuestDataCollection();
			appointmentGuests.Add( appointmentGuest );
			return appointmentGuests;
		}

		/// <summary>
		/// Deserializes the XML representation of an appointmentguestcollection to a new appointmentguestcollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an appointmentguestcollection.</param>
		/// <returns>A new AppointmentGuestCollection deserialized from the given XML string.</returns>
		public static AppointmentGuestDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( AppointmentGuestDataCollection ) );
			AppointmentGuestDataCollection toReturn = (AppointmentGuestDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
