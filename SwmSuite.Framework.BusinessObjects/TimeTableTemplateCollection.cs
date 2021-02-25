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
	/// Class defining a collection of timetable templates.
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class TimeTableTemplateCollection : BusinessObjectCollectionBase<TimeTableTemplate> {

		/// <summary>
		/// Get a collection for a single country.
		/// </summary>
		/// <param name="country">The country to store into the collection.</param>
		/// <returns>A new TimeTableTemplateCollection containing the given country.</returns>
		public static TimeTableTemplateCollection FromSingleTimeTableTemplate( TimeTableTemplate country ) {
			TimeTableTemplateCollection countries = new TimeTableTemplateCollection();
			countries.Add( country );
			return countries;
		}

		/// <summary>
		/// Deserializes the XML representation of an countrycollection to a new countrycollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an countrycollection.</param>
		/// <returns>A new TimeTableTemplateCollection deserialized from the given XML string.</returns>
		public static TimeTableTemplateCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( TimeTableTemplateCollection ) );
			TimeTableTemplateCollection toReturn = (TimeTableTemplateCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
