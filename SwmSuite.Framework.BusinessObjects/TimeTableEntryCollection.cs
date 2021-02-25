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
	/// Class defining a collection of countries.
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class TimeTableEntryCollection : BusinessObjectCollectionBase<TimeTableEntry> {

		/// <summary>
		/// Get a collection for a single timeTableEntry.
		/// </summary>
		/// <param name="timeTableEntry">The timeTableEntry to store into the collection.</param>
		/// <returns>A new TimeTableEntryCollection containing the given timeTableEntry.</returns>
		public static TimeTableEntryCollection FromSingleTimeTableEntry( TimeTableEntry timeTableEntry ) {
			TimeTableEntryCollection countries = new TimeTableEntryCollection();
			countries.Add( timeTableEntry );
			return countries;
		}

		/// <summary>
		/// Deserializes the XML representation of an timeTableEntrycollection to a new timeTableEntrycollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an timeTableEntrycollection.</param>
		/// <returns>A new TimeTableEntryCollection deserialized from the given XML string.</returns>
		public static TimeTableEntryCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( TimeTableEntryCollection ) );
			TimeTableEntryCollection toReturn = (TimeTableEntryCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

		/// <summary>
		/// Creates the appointment collection.
		/// </summary>
		/// <returns></returns>
		public AppointmentCollection CreateAppointmentCollection() {
			AppointmentCollection appointmentsToReturn = new AppointmentCollection();
			foreach( TimeTableEntry entry in this ) {
				appointmentsToReturn.Add( entry.CreateAppointment() );
			}
			return appointmentsToReturn;
		}

	}

}
