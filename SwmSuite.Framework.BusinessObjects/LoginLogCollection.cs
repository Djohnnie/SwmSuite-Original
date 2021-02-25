using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace SwmSuite.Data.BusinessObjects {

	/// <summary>
	/// Class defining an employee.
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class LoginLogCollection : BusinessObjectCollectionBase<LoginLog> {

		/// <summary>
		/// Get a collection for a single loginLog.
		/// </summary>
		/// <param name="loginLog">The loginLog to store into the collection.</param>
		/// <returns>A new LoginLogCollection containing the given loginLog.</returns>
		public static LoginLogCollection FromSingleLoginLog( LoginLog loginLog ) {
			LoginLogCollection loginLogs = new LoginLogCollection();
			loginLogs.Add( loginLog );
			return loginLogs;
		}

		/// <summary>
		/// Deserializes the XML representation of an LoginLogCollection to a new LoginLogCollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an loginLogcollection.</param>
		/// <returns>A new LoginLogCollection deserialized from the given XML string.</returns>
		public static LoginLogCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( LoginLogCollection ) );
			LoginLogCollection toReturn = (LoginLogCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
