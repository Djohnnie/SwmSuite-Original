using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.BusinessObjects;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.BusinessObjects {

	/// <summary>
	/// Class defining a collection of countries.
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class TimeTableTemplateEntryCollection : BusinessObjectCollectionBase<TimeTableTemplateEntry> {

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

	}

}
