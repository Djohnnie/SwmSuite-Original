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
	public class EmployeeSettingsCollection : BusinessObjectCollectionBase<EmployeeSettings> {

		/// <summary>
		/// Get a collection for a single employeeSettings.
		/// </summary>
		/// <param name="employeeSettings">The employeeSettings to store into the collection.</param>
		/// <returns>A new EmployeeSettingsCollection containing the given employeeSettings.</returns>
		public static EmployeeSettingsCollection FromSingleEmployeeSettings( EmployeeSettings employeeSettings ) {
			EmployeeSettingsCollection countries = new EmployeeSettingsCollection();
			countries.Add( employeeSettings );
			return countries;
		}

		/// <summary>
		/// Deserializes the XML representation of an employeeSettingscollection to a new employeeSettingscollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an employeeSettingscollection.</param>
		/// <returns>A new EmployeeSettingsCollection deserialized from the given XML string.</returns>
		public static EmployeeSettingsCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( EmployeeSettingsCollection ) );
			EmployeeSettingsCollection toReturn = (EmployeeSettingsCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}
}
