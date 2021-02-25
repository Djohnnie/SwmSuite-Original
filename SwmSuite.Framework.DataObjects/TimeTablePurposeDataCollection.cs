using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	public class TimeTablePurposeDataCollection : DataObjectCollectionBase<TimeTablePurposeData> {

		/// <summary>
		/// Get a collection for a single timeTablePurpose.
		/// </summary>
		/// <param name="timeTablePurpose">The timeTablePurpose to store into the collection.</param>
		/// <returns>A new TimeTablePurposeCollection containing the given timeTablePurpose.</returns>
		public static TimeTablePurposeDataCollection FromSingleTimeTablePurpose( TimeTablePurposeData timeTablePurpose ) {
			TimeTablePurposeDataCollection timeTablePurposes = new TimeTablePurposeDataCollection();
			timeTablePurposes.Add( timeTablePurpose );
			return timeTablePurposes;
		}

		/// <summary>
		/// Deserializes the XML representation of an timeTablePurposecollection to a new timeTablePurposecollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an timeTablePurposecollection.</param>
		/// <returns>A new TimeTablePurposeCollection deserialized from the given XML string.</returns>
		public static TimeTablePurposeDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( TimeTablePurposeDataCollection ) );
			TimeTablePurposeDataCollection toReturn = (TimeTablePurposeDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
