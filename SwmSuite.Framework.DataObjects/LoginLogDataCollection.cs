using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace SwmSuite.Data.DataObjects {

	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class LoginLogDataCollection : DataObjectCollectionBase<LoginLogData>{

		/// <summary>
		/// Get a collection for a single loginLog.
		/// </summary>
		/// <param name="loginLog">The loginLog to store into the collection.</param>
		/// <returns>A new LoginLogCollection containing the given loginLog.</returns>
		public static LoginLogDataCollection FromSingleLoginLog( LoginLogData loginLog ) {
			LoginLogDataCollection loginLogs = new LoginLogDataCollection();
			loginLogs.Add( loginLog );
			return loginLogs;
		}

		/// <summary>
		/// Deserializes the XML representation of an loginLogcollection to a new loginLogcollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an loginLogcollection.</param>
		/// <returns>A new LoginLogCollection deserialized from the given XML string.</returns>
		public static LoginLogDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( LoginLogDataCollection ) );
			LoginLogDataCollection toReturn = (LoginLogDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}
