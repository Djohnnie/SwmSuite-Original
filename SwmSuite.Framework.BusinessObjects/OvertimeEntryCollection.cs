using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace SwmSuite.Data.BusinessObjects {

	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class OvertimeEntryCollection : BusinessObjectCollectionBase<OvertimeEntry> {

		/// <summary>
		/// Get a collection for a single overtimeEntry.
		/// </summary>
		/// <param name="overtimeEntry">The overtimeEntry to store into the collection.</param>
		/// <returns>A new OvertimeEntryCollection containing the given overtimeEntry.</returns>
		public static OvertimeEntryCollection FromSingleOvertimeEntry( OvertimeEntry overtimeEntry ) {
			OvertimeEntryCollection overtimeEntrys = new OvertimeEntryCollection();
			overtimeEntrys.Add( overtimeEntry );
			return overtimeEntrys;
		}

		/// <summary>
		/// Deserializes the XML representation of an overtimeEntrycollection to a new overtimeEntrycollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an overtimeEntrycollection.</param>
		/// <returns>A new OvertimeEntryCollection deserialized from the given XML string.</returns>
		public static OvertimeEntryCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( OvertimeEntryCollection ) );
			OvertimeEntryCollection toReturn = (OvertimeEntryCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

		/// <summary>
		/// Gets the overtime entries.
		/// </summary>
		/// <param name="employee">The employee.</param>
		/// <returns></returns>
		public OvertimeEntryCollection GetOvertimeEntries( Employee employee ) {
			return GetOvertimeEntries( EmployeeCollection.FromSingleEmployee( employee ) );
		}

		/// <summary>
		/// Gets the overtime entries.
		/// </summary>
		/// <param name="employees">The employees.</param>
		/// <returns></returns>
		public OvertimeEntryCollection GetOvertimeEntries( EmployeeCollection employees ) {
			OvertimeEntryCollection overtimeEntryCollectionToReturn = new OvertimeEntryCollection();
			foreach( Employee employee in employees ) {
				foreach( OvertimeEntry overtimeEntry in this ) {
					if( overtimeEntry.Employee.SysId == employee.SysId ) {
						overtimeEntryCollectionToReturn.Add( overtimeEntry );
					}
				}
			}
			return overtimeEntryCollectionToReturn;
		}

	}

}
