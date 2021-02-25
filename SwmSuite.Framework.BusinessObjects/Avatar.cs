using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace SwmSuite.Data.BusinessObjects {

  /// <summary>
  /// Class defining an avatar.
  /// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class Avatar : BusinessObjectBase {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the picture representing this avatar.
		/// </summary>
		[System.Xml.Serialization.XmlIgnore()]
		public Image Image {
			get {
				MemoryStream memoryStream = new MemoryStream( this.Picture );
				Image imageToReturn = Image.FromStream( memoryStream );
				memoryStream.Close();
				memoryStream.Dispose();
				return imageToReturn;
			}
			set {
				MemoryStream memoryStream = new MemoryStream();
				value.Save( memoryStream , System.Drawing.Imaging.ImageFormat.Png );
				this.Picture = memoryStream.ToArray();
				memoryStream.Close();
				memoryStream.Dispose();
			}
		}


		public Byte[] Picture { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public Avatar() {
			this.Picture = new Byte[] { };
		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="image">The picture representing this avatar.</param>
		public Avatar( Image image ){
			MemoryStream memoryStream = new MemoryStream();
			image.Save( memoryStream , System.Drawing.Imaging.ImageFormat.Png );
			this.Picture = memoryStream.ToArray();
			memoryStream.Close();
			memoryStream.Dispose();
		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="picture">The picture representing this avatar.</param>
		public Avatar( byte[] picture ) {
			this.Picture = picture;
		}

		#endregion

	}

}
