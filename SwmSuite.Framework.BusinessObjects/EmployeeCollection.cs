using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.BusinessObjects {

	/// <summary>
	/// Class defining a collection of employees.
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class EmployeeCollection : BusinessObjectCollectionBase<Employee> {

		/// <summary>
		/// Get a collection for a single employee.
		/// </summary>
		/// <param name="employee">The employee to store into the collection.</param>
		/// <returns>A new EmployeeCollection containing the given employee.</returns>
		public static EmployeeCollection FromSingleEmployee( Employee employee ) {
			EmployeeCollection employees = new EmployeeCollection();
			employees.Add( employee );
			return employees;
		}

		/// <summary>
		/// Deserializes the XML representation of an employeecollection to a new employeecollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an employeecollection.</param>
		/// <returns>A new EmployeeCollection deserialized from the given XML string.</returns>
		public static EmployeeCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( EmployeeCollection ) );
			EmployeeCollection toReturn = (EmployeeCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}
}
