using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SwmSuite.Data.BusinessObjects {

  /// <summary>
  /// Class defining a collection of avatars.
  /// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class AvatarCollection : BusinessObjectCollectionBase<Avatar> {

		/// <summary>
		/// Get a collection for a single avatar.
		/// </summary>
		/// <param name="avatar">The avatar to store into the collection.</param>
		/// <returns>A new AvatarCollection containing the given avatar.</returns>
		public static AvatarCollection FromSingleAvatar( Avatar avatar ) {
			AvatarCollection avatars = new AvatarCollection();
			avatars.Add( avatar );
			return avatars;
		}

		/// <summary>
		/// Deserializes the XML representation of an AvatarCollection to a new AvatarCollection.
		/// </summary>
		/// <param name="serialized">The XML representation of an avatarcollection.</param>
		/// <returns>A new AvatarCollection deserialized from the given XML string.</returns>
		public static AvatarCollection Deserialize( string serialized ) {
			StringReader stringReader = new StringReader( serialized );
			XmlReader reader = XmlReader.Create( stringReader );
			XmlSerializer serializer = new XmlSerializer( typeof( AvatarCollection ) );
			AvatarCollection toReturn = (AvatarCollection)serializer.Deserialize( reader );
			reader.Close();
			stringReader.Close();
			stringReader.Dispose();
			return toReturn;
		}
	}
}
