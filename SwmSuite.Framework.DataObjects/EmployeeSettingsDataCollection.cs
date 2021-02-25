using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace SwmSuite.Data.DataObjects {

	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class EmployeeSettingsDataCollection : DataObjectCollectionBase<EmployeeSettingsData> {

		/// <summary>
		/// Get a collection for a single employeegroup.
		/// </summary>
		/// <param name="employee">The employeegroup to store into the collection.</param>
		/// <returns>A new EmployeeSettingsCollection containing the given employeegroup.</returns>
		public static EmployeeSettingsDataCollection FromSingleEmployeeSettings( EmployeeSettingsData employeeSettings ) {
			EmployeeSettingsDataCollection employeeSettingss = new EmployeeSettingsDataCollection();
			employeeSettingss.Add( employeeSettings );
			return employeeSettingss;
		}

		/// <summary>
		/// Deserializes the XML representation of an employeegroupcollection to a new employeegroupcollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an employeegroupcollection.</param>
		/// <returns>A new EmployeeSettingsCollection deserialized from the given XML string.</returns>
		public static EmployeeSettingsDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( EmployeeSettingsDataCollection ) );
			EmployeeSettingsDataCollection toReturn = (EmployeeSettingsDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
