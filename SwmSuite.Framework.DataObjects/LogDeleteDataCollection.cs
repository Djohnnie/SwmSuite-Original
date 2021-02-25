/***********
 * LogDeleteCollection.cs
 * 
 * 13/08/2008 - Created
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

	public class LogDeleteDataCollection : DataObjectCollectionBase<LogDeleteData> {

		/// <summary>
		/// Get a collection for a single logdelete.
		/// </summary>
		/// <param name="employee">The logdelete to store into the collection.</param>
		/// <returns>A new LogDeleteCollection containing the given logdelete.</returns>
		public static LogDeleteDataCollection FromSingleLogDelete( LogDeleteData logDelete ) {
			LogDeleteDataCollection employeeGroups = new LogDeleteDataCollection();
			employeeGroups.Add( logDelete );
			return employeeGroups;
		}

		/// <summary>
		/// Deserializes the XML representation of an logdeletecollection to a new logdeletecollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an logdeletecollection.</param>
		/// <returns>A new LogDeleteCollection deserialized from the given XML string.</returns>
		public static LogDeleteDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( LogDeleteDataCollection ) );
			LogDeleteDataCollection toReturn = (LogDeleteDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}
}