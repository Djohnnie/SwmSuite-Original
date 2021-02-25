using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace SwmSuite.Data.BusinessObjects {

	/// <summary>
	/// Class defining a collection of countries.
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class HolidayDefinitionCollection : BusinessObjectCollectionBase<HolidayDefinition> {

		/// <summary>
		/// Get a collection for a single holidayDefinition.
		/// </summary>
		/// <param name="holidayDefinition">The holidayDefinition to store into the collection.</param>
		/// <returns>A new HolidayDefinitionCollection containing the given holidayDefinition.</returns>
		public static HolidayDefinitionCollection FromSingleHolidayDefinition( HolidayDefinition holidayDefinition ) {
			HolidayDefinitionCollection countries = new HolidayDefinitionCollection();
			countries.Add( holidayDefinition );
			return countries;
		}

		/// <summary>
		/// Deserializes the XML representation of an holidayDefinitioncollection to a new holidayDefinitioncollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an holidayDefinitioncollection.</param>
		/// <returns>A new HolidayDefinitionCollection deserialized from the given XML string.</returns>
		public static HolidayDefinitionCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( HolidayDefinitionCollection ) );
			HolidayDefinitionCollection toReturn = (HolidayDefinitionCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
