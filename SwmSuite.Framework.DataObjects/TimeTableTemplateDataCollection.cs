using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	public class TimeTableTemplateDataCollection : DataObjectCollectionBase<TimeTableTemplateData> {

		/// <summary>
		/// Get a collection for a single timeTableTemplate.
		/// </summary>
		/// <param name="timeTableTemplate">The timeTableTemplate to store into the collection.</param>
		/// <returns>A new TimeTableTemplateCollection containing the given timeTableTemplate.</returns>
		public static TimeTableTemplateDataCollection FromSingleTimeTableTemplate( TimeTableTemplateData timeTableTemplate ) {
			TimeTableTemplateDataCollection timeTableTemplates = new TimeTableTemplateDataCollection();
			timeTableTemplates.Add( timeTableTemplate );
			return timeTableTemplates;
		}

		/// <summary>
		/// Deserializes the XML representation of an timeTableTemplatecollection to a new timeTableTemplatecollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an timeTableTemplatecollection.</param>
		/// <returns>A new TimeTableTemplateCollection deserialized from the given XML string.</returns>
		public static TimeTableTemplateDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( TimeTableTemplateDataCollection ) );
			TimeTableTemplateDataCollection toReturn = (TimeTableTemplateDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
