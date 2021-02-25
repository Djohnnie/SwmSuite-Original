/***********
 * EmployeeGroupCollection.cs
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
	public class EmployeeGroupDataCollection : DataObjectCollectionBase<EmployeeGroupData> {

		/// <summary>
		/// Get a collection for a single employeegroup.
		/// </summary>
		/// <param name="employee">The employeegroup to store into the collection.</param>
		/// <returns>A new EmployeeGroupCollection containing the given employeegroup.</returns>
		public static EmployeeGroupDataCollection FromSingleEmployeeGroup( EmployeeGroupData employeeGroup ) {
			EmployeeGroupDataCollection employeeGroups = new EmployeeGroupDataCollection();
			employeeGroups.Add( employeeGroup );
			return employeeGroups;
		}

		/// <summary>
		/// Deserializes the XML representation of an employeegroupcollection to a new employeegroupcollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an employeegroupcollection.</param>
		/// <returns>A new EmployeeGroupCollection deserialized from the given XML string.</returns>
		public static EmployeeGroupDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( EmployeeGroupDataCollection ) );
			EmployeeGroupDataCollection toReturn = (EmployeeGroupDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}
	}

}
