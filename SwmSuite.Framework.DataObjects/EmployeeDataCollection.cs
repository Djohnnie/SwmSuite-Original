/***********
 * EmployeeCollection.cs
 * 
 * 08/08/2008 - Created
 * 
 */

using System;
using System.Collections.Generic;

using System.Text;
using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.DataObjects {

	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class EmployeeDataCollection : DataObjectCollectionBase<EmployeeData> {

		/// <summary>
		/// Get a collection for a single employee.
		/// </summary>
		/// <param name="employee">The employee to store into the collection.</param>
		/// <returns>A new EmployeeCollection containing the given employee.</returns>
		public static EmployeeDataCollection FromSingleEmployee( EmployeeData employee ) {
			EmployeeDataCollection employees = new EmployeeDataCollection();
			employees.Add( employee );
			return employees;
		}

		/// <summary>
		/// Deserializes the XML representation of an employeecollection to a new employeecollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an employeecollection.</param>
		/// <returns>A new EmployeeCollection deserialized from the given XML string.</returns>
		public static EmployeeDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( EmployeeDataCollection ) );
			EmployeeDataCollection toReturn = (EmployeeDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}
}