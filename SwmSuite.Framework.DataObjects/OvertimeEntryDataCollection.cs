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
	public class OvertimeEntryDataCollection : DataObjectCollectionBase<OvertimeEntryData> {

		/// <summary>
		/// Get a collection for a single overtimeEntry.
		/// </summary>
		/// <param name="alert">The overtimeEntry to store into the collection.</param>
		/// <returns>A new OvertimeEntryCollection containing the given alert.</returns>
		public static OvertimeEntryDataCollection FromSingleOvertimeEntry( OvertimeEntryData overtimeEntry ) {
			OvertimeEntryDataCollection overtimeEntrys = new OvertimeEntryDataCollection();
			overtimeEntrys.Add( overtimeEntry );
			return overtimeEntrys;
		}

		/// <summary>
		/// Deserializes the XML representation of an overtimeEntrycollection to a new overtimeEntrycollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an overtimeEntrycollection.</param>
		/// <returns>A new OvertimeEntryCollection deserialized from the given XML string.</returns>
		public static OvertimeEntryDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( OvertimeEntryDataCollection ) );
			OvertimeEntryDataCollection toReturn = (OvertimeEntryDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
