using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	public class TimeTableTemplateEntryDataCollection : DataObjectCollectionBase<TimeTableTemplateEntryData> {

		/// <summary>
		/// Get a collection for a single timeTableTemplateEntry.
		/// </summary>
		/// <param name="alert">The timeTableTemplateEntry to store into the collection.</param>
		/// <returns>A new TimeTableTemplateEntryCollection containing the given alert.</returns>
		public static TimeTableTemplateEntryDataCollection FromSingleTimeTableTemplateEntry( TimeTableTemplateEntryData timeTableTemplateEntry ) {
			TimeTableTemplateEntryDataCollection countries = new TimeTableTemplateEntryDataCollection();
			countries.Add( timeTableTemplateEntry );
			return countries;
		}

		/// <summary>
		/// Deserializes the XML representation of an timeTableTemplateEntrycollection to a new timeTableTemplateEntrycollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an timeTableTemplateEntrycollection.</param>
		/// <returns>A new TimeTableTemplateEntryCollection deserialized from the given XML string.</returns>
		public static TimeTableTemplateEntryDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( TimeTableTemplateEntryDataCollection ) );
			TimeTableTemplateEntryDataCollection toReturn = (TimeTableTemplateEntryDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
