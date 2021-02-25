using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SwmSuite.Presentation.Common.AvatarBrowser {

	/// <summary>
	/// 
	/// </summary>
	public class AvatarBrowserImageObject {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the image.
		/// </summary>
		/// <value>The image.</value>
		public Image Image { get; set; }

		/// <summary>
		/// Gets or sets the tag.
		/// </summary>
		/// <value>The tag.</value>
		public Object Tag { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="AvatarBrowserImageObject"/> class.
		/// </summary>
		public AvatarBrowserImageObject() {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="AvatarBrowserImageObject"/> class.
		/// </summary>
		/// <param name="image">The image.</param>
		/// <param name="tag">The tag.</param>
		public AvatarBrowserImageObject( Image image , Object tag ) {
			this.Image = image;
			this.Tag = tag;
		}

		#endregion

	}

}
