using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	public class HolidayDefinitionDataCollection : DataObjectCollectionBase<HolidayDefinitionData> {

		/// <summary>
		/// Get a collection for a single employeegroup.
		/// </summary>
		/// <param name="employee">The employeegroup to store into the collection.</param>
		/// <returns>A new HolidayDefinitionCollection containing the given employeegroup.</returns>
		public static HolidayDefinitionDataCollection FromSingleHolidayDefinition( HolidayDefinitionData holidayDefinition ) {
			HolidayDefinitionDataCollection holidayDefinitions = new HolidayDefinitionDataCollection();
			holidayDefinitions.Add( holidayDefinition );
			return holidayDefinitions;
		}

		/// <summary>
		/// Deserializes the XML representation of an employeegroupcollection to a new employeegroupcollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an employeegroupcollection.</param>
		/// <returns>A new HolidayDefinitionCollection deserialized from the given XML string.</returns>
		public static HolidayDefinitionDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( HolidayDefinitionDataCollection ) );
			HolidayDefinitionDataCollection toReturn = (HolidayDefinitionDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}
	}

}
