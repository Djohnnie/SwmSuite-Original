using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace SwmSuite.Data.BusinessObjects {

	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class TimeTablePurposeCollection : BusinessObjectCollectionBase<TimeTablePurpose> {

		/// <summary>
		/// Get a collection for a single timeTablePurpose.
		/// </summary>
		/// <param name="timeTablePurpose">The timeTablePurpose to store into the collection.</param>
		/// <returns>A new TimeTablePurposeCollection containing the given timeTablePurpose.</returns>
		public static TimeTablePurposeCollection FromSingleTimeTablePurpose( TimeTablePurpose timeTablePurpose ) {
			TimeTablePurposeCollection timeTablePurposes = new TimeTablePurposeCollection();
			timeTablePurposes.Add( timeTablePurpose );
			return timeTablePurposes;
		}

		/// <summary>
		/// Deserializes the XML representation of an timeTablePurposecollection to a new timeTablePurposecollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an timeTablePurposecollection.</param>
		/// <returns>A new TimeTablePurposeCollection deserialized from the given XML string.</returns>
		public static TimeTablePurposeCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( TimeTablePurposeCollection ) );
			TimeTablePurposeCollection toReturn = (TimeTablePurposeCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
