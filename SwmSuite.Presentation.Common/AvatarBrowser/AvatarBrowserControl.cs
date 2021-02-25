using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace SwmSuite.Presentation.Common.AvatarBrowser {

	[Designer( typeof( ParentControlDesigner ) )]
	public partial class AvatarBrowserControl : UserControl {

		#region -_ Private Members _-

		private List<AvatarBrowserImageObject> _imageList = new List<AvatarBrowserImageObject>();

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the selected image.
		/// </summary>
		/// <value>The selected image.</value>
		public AvatarBrowserImageObject SelectedImage { get; set; }

		/// <summary>
		/// Gets or sets the renderer.
		/// </summary>
		/// <value>The renderer.</value>
		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public AvatarBrowserRenderer Renderer { get; set; }

		/// <summary>
		/// Gets or sets the scheme.
		/// </summary>
		/// <value>The scheme.</value>
		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public AvatarBrowserScheme Scheme { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="AvatarBrowserControl"/> class.
		/// </summary>
		public AvatarBrowserControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );

			this.Renderer = new AvatarBrowserRenderer();
			this.Scheme = new AvatarBrowserScheme();

			this.MouseWheel += new MouseEventHandler( AvatarBrowserControl_MouseWheel );
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Adds an image.
		/// </summary>
		/// <param name="image">An image.</param>
		public void AddImage( Image image , object tag , bool selected ) {
			AvatarBrowserImageObject newImage = new AvatarBrowserImageObject( image , tag );
			_imageList.Add( newImage );
			if( selected ) {
				this.SelectedImage = newImage;
			}
			this.Renderer.RebuildRenderer( _imageList , this.SelectedImage , this.Scheme );
			Invalidate();
		}

		/// <summary>
		/// Adds images
		/// </summary>
		/// <param name="image">An image.</param>
		public void AddImages( List<AvatarBrowserImageObject> images ) {
			foreach( AvatarBrowserImageObject newImage in images ) {
				_imageList.Add( newImage );
				this.SelectedImage = newImage;
			}
			this.Renderer.RebuildRenderer( _imageList , this.SelectedImage , this.Scheme );
			Invalidate();
		}

		///// <summary>
		///// Removes an image.
		///// </summary>
		///// <param name="image">An image.</param>
		//public void RemoveImage( Image image ) {
		//   int previousImage = _imageList.IndexOf( image );
		//   this.Renderer.RebuildRenderer( _imageList , this.SelectedImage , this.Scheme );
		//   _imageList.Remove( image );
		//   if( _imageList.Count > 0 ) {
		//      if( previousImage > 0 ) {
		//         previousImage--;
		//      } else {
		//         previousImage = 0;
		//      }
		//      this.SelectedImage = _imageList[previousImage];
		//   } else {
		//      this.SelectedImage = null;
		//   }
		//   Invalidate();
		//}

		/// <summary>
		/// Clears the images.
		/// </summary>
		public void ClearImages() {
			_imageList.Clear();
			this.SelectedImage = null;
			this.Renderer.RebuildRenderer( _imageList , this.SelectedImage , this.Scheme );
			Invalidate();
		}

		/// <summary>
		/// Selects the next image.
		/// </summary>
		public void NextImage() {
			int currentSelectedIndex = _imageList.IndexOf( this.SelectedImage );
			currentSelectedIndex++;
			if( currentSelectedIndex > ( _imageList.Count - 1 ) ) {
				currentSelectedIndex = 0;
			}
			this.SelectedImage = _imageList[currentSelectedIndex];
			this.Renderer.RebuildRenderer( _imageList , this.SelectedImage , this.Scheme );
			Invalidate();
		}

		/// <summary>
		/// Selects the previous image.
		/// </summary>
		public void PreviousImage() {
			int currentSelectedIndex = _imageList.IndexOf( this.SelectedImage );
			currentSelectedIndex--;
			if( currentSelectedIndex < 0 ) {
				currentSelectedIndex = _imageList.Count - 1;
			}
			this.SelectedImage = _imageList[currentSelectedIndex];
			this.Renderer.RebuildRenderer( _imageList , this.SelectedImage , this.Scheme );
			Invalidate();
		}

		#endregion

		private void AvatarBrowserControl_Paint( object sender , PaintEventArgs e ) {
			this.Renderer.Render( e.Graphics , this.ClientRectangle , this.SelectedImage , _imageList , this.Scheme );
		}

		private void AvatarBrowserControl_MouseDown( object sender , MouseEventArgs e ) {
			Rectangle leftButton = new Rectangle( this.ClientRectangle.Left , this.ClientRectangle.Top , this.Scheme.NavigationButtonWidth , this.ClientRectangle.Height );
			Rectangle rightButton = new Rectangle( this.ClientRectangle.Right - this.Scheme.NavigationButtonWidth , this.ClientRectangle.Top , this.Scheme.NavigationButtonWidth , this.ClientRectangle.Height );
			if( leftButton.Contains( e.Location ) ) {
				PreviousImage();
			}
			if( rightButton.Contains( e.Location ) ) {
				NextImage();
			}
		}

		/// <summary>
		/// Handles the MouseWheel event of the AvatarBrowserControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
		void AvatarBrowserControl_MouseWheel( object sender , MouseEventArgs e ) {
			if( e.Delta > 0 ) {
				NextImage();
			} else {
				PreviousImage();
			}
		}

	}

}
