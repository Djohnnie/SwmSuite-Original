using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {
	
	public class EmployeeGroupAlertDataCollection : DataObjectCollectionBase<EmployeeGroupAlertData> {

		/// <summary>
		/// Get a collection for a single EmployeeGroupAlert.
		/// </summary>
		/// <param name="employeeGroupAlert">The EmployeeGroupAlert to store into the collection.</param>
		/// <returns>A new EmployeeGroupAlertCollection containing the given EmployeeGroupAlert.</returns>
		public static EmployeeGroupAlertDataCollection FromSingleEmployeeGroupAlert( EmployeeGroupAlertData employeeGroupAlert ) {
			EmployeeGroupAlertDataCollection employeeGroupAlerts = new EmployeeGroupAlertDataCollection();
			employeeGroupAlerts.Add( employeeGroupAlert );
			return employeeGroupAlerts;
		}

		/// <summary>
		/// Deserializes the XML representation of an employeeGroupAlertcollection to a new employeeGroupAlertcollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an employeeGroupAlertcollection.</param>
		/// <returns>A new EmployeeGroupAlertCollection deserialized from the given XML string.</returns>
		public static EmployeeGroupAlertDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( EmployeeGroupAlertDataCollection ) );
			EmployeeGroupAlertDataCollection toReturn = (EmployeeGroupAlertDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
