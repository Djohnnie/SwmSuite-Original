using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class EmployeeAlertDataCollection : DataObjectCollectionBase<EmployeeAlertData> {

		/// <summary>
		/// Get a collection for a single EmployeeAlert.
		/// </summary>
		/// <param name="employeeAlert">The EmployeeAlert to store into the collection.</param>
		/// <returns>A new EmployeeAlertCollection containing the given EmployeeAlert.</returns>
		public static EmployeeAlertDataCollection FromSingleAlert( EmployeeAlertData employeeAlert ) {
			EmployeeAlertDataCollection employeeAlerts = new EmployeeAlertDataCollection();
			employeeAlerts.Add( employeeAlert );
			return employeeAlerts;
		}

		/// <summary>
		/// Deserializes the XML representation of an employeeGroupAlertcollection to a new employeeGroupAlertcollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an employeeGroupAlertcollection.</param>
		/// <returns>A new EmployeeAlertCollection deserialized from the given XML string.</returns>
		public static EmployeeAlertDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( EmployeeAlertDataCollection ) );
			EmployeeAlertDataCollection toReturn = (EmployeeAlertDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
