using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.BusinessObjects {

  /// <summary>
  /// Class defining a collection of employeegroups.
  /// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class EmployeeGroupCollection : BusinessObjectCollectionBase<EmployeeGroup> {

		/// <summary>
		/// Get a collection for a single employeeGroup.
		/// </summary>
		/// <param name="employeeGroup">The employeeGroup to store into the collection.</param>
		/// <returns>A new EmployeeGroupCollection containing the given employeeGroup.</returns>
		public static EmployeeGroupCollection FromSingleEmployeeGroup( EmployeeGroup employeeGroup ) {
			EmployeeGroupCollection employeeGroups = new EmployeeGroupCollection();
			employeeGroups.Add( employeeGroup );
			return employeeGroups;
		}

		/// <summary>
		/// Deserializes the XML representation of an employeeGroupcollection to a new employeeGroupcollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an employeeGroupcollection.</param>
		/// <returns>A new EmployeeGroupCollection deserialized from the given XML string.</returns>
		public static EmployeeGroupCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( EmployeeGroupCollection ) );
			EmployeeGroupCollection toReturn = (EmployeeGroupCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

		/// <summary>
		/// Gets the employees.
		/// </summary>
		/// <returns></returns>
		public EmployeeCollection GetEmployees() {
			EmployeeCollection employeeCollectionToReturn = new EmployeeCollection();
			foreach( EmployeeGroup employeeGroup in this ) {
				employeeCollectionToReturn.Add( employeeGroup.Employees );
			}
			return employeeCollectionToReturn;
		}

	}

}
