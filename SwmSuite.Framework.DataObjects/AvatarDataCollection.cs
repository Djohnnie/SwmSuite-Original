using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.Data.DataObjects {

	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class AvatarDataCollection : DataObjectCollectionBase<AvatarData> {

		/// <summary>
		/// Get a collection for a single avatar.
		/// </summary>
		/// <param name="alert">The avatar to store into the collection.</param>
		/// <returns>A new AvatarCollection containing the given alert.</returns>
		public static AvatarDataCollection FromSingleAvatar( AvatarData avatar ) {
			AvatarDataCollection avatars = new AvatarDataCollection();
			avatars.Add( avatar );
			return avatars;
		}

		/// <summary>
		/// Deserializes the XML representation of an avatarcollection to a new avatarcollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an avatarcollection.</param>
		/// <returns>A new AvatarCollection deserialized from the given XML string.</returns>
		public static AvatarDataCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( AvatarDataCollection ) );
			AvatarDataCollection toReturn = (AvatarDataCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}

	}

}