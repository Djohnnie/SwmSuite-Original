using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace SwmSuite.Data.DataObjects {

	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class AvatarData : DataObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the image.
		/// </summary>
		public byte[] Picture { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public AvatarData() {

		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="picture">The image to set.</param>
		public AvatarData( byte[] picture ) {
			this.Picture = picture;
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Convert this image to its string representation.
		/// </summary>
		/// <returns>An empty string.</returns>
		public override string ToString() {
			return String.Empty;
		}

		#endregion

	}

}
