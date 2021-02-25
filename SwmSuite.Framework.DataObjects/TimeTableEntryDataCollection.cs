using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	public class TimeTableEntryDataCollection : DataObjectCollectionBase<TimeTableEntryData> {

		/// <summary>
		/// Get a collection for a single timeTableEntry.
		/// </summary>
		/// <param name="timeTableEntry">The timeTableEntry to store into the collection.</param>
		/// <returns>A new TimeTableEntryCollection containing the given timeTableEntry.</returns>
		public static TimeTableEntryDataCollection FromSingleTimeTableEntry( TimeTableEntryData timeTableEntry ) {
			TimeTableEntryDataCollection timeTableEntrys = new TimeTableEntryDataCollection();
			timeTableEntrys.Add( timeTableEntry );
			return timeTableEntrys;
		}

		/// <summary>
		/// Deserializes the XML representation of an timeTableEntrycollection to a new timeTableEntrycollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an timeTableEntrycollection.</param>
		/// <returns>A new TimeTableEntryCollection deserialized from the given XML string.</returns>
		public static TimeTableEntryDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( TimeTableEntryDataCollection ) );
			TimeTableEntryDataCollection toReturn = (TimeTableEntryDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
