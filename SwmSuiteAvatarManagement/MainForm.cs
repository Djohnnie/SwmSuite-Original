using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Presentation.Common.AvatarBrowser;

namespace SwmSuiteAvatarManagement {

	public partial class MainForm : Form {

		private IAvatarFacade _avatarService = ServiceBroker.CreateBroker().CreateAvatarFacade();

		public MainForm() {
			InitializeComponent();
		}

		private void MainForm_Load( object sender , EventArgs e ) {
			statusControl.LeftCaption = "Simple Workfloor Management Suite Avatar Management " + Application.ProductVersion;
			statusControl.RightCaption = DateTime.Today.ToLongDateString();

			circularProgressControl.Visible = true;
			avatarBrowserControl1.Visible = false;
			getBackgroundWorker.RunWorkerAsync();


		}

		private void addButton_Click( object sender , EventArgs e ) {
			OpenFileDialog opendialog = new OpenFileDialog();
			opendialog.Multiselect = true;
			if( opendialog.ShowDialog() == DialogResult.OK ) {
				List<Image> images = new List<Image>();
				foreach( String fileName in opendialog.FileNames ) {
					Image image = Image.FromFile( fileName );
					images.Add( image );
					avatarBrowserControl1.AddImage( image , null , true );
				}
				circularProgressControl.Visible = true;
				avatarBrowserControl1.Visible = false;
				insertBackgroundWorker.RunWorkerAsync( images );
			}
		}

		private void removeButton_Click( object sender , EventArgs e ) {
			SwmSuiteFacade.AvatarFacade.RemoveAvatars( AvatarCollection.FromSingleAvatar( (Avatar)avatarBrowserControl1.SelectedImage.Tag ) );
			circularProgressControl.Visible = true;
			avatarBrowserControl1.Visible = false;
			getBackgroundWorker.RunWorkerAsync();
		}

		private void getBackgroundWorker_DoWork( object sender , DoWorkEventArgs e ) {
			AvatarCollection avatars = _avatarService.GetAvatars();
			e.Result = avatars;
		}

		private void getBackgroundWorker_RunWorkerCompleted( object sender , RunWorkerCompletedEventArgs e ) {
			avatarBrowserControl1.ClearImages();
			AvatarCollection avatars = (AvatarCollection)e.Result;
			foreach( Avatar avatar in avatars ) {
				avatar.Image.Tag = avatar;
				avatarBrowserControl1.AddImage( avatar.Image , avatar , true );
			}
			circularProgressControl.Visible = false;
			avatarBrowserControl1.Visible = true;
		}

		private void insertBackgroundWorker_DoWork( object sender , DoWorkEventArgs e ) {
			List<Image> images = (List<Image>)e.Argument;
			List<AvatarBrowserImageObject> avatars = new List<AvatarBrowserImageObject>();
			foreach( Image image in images ) {
				Avatar newAvatar = new Avatar( image );
				avatars.Add( new AvatarBrowserImageObject( image ,
					_avatarService.CreateAvatar( newAvatar ) ) );
			}
			e.Result = avatars;
		}

		private void insertBackgroundWorker_RunWorkerCompleted( object sender , RunWorkerCompletedEventArgs e ) {
			circularProgressControl.Visible = false;
			avatarBrowserControl1.Visible = true;
			List<AvatarBrowserImageObject> avatars = (List<AvatarBrowserImageObject>)e.Result;
			avatarBrowserControl1.AddImages( avatars );
		}

		private void removeBackgroundWorker_DoWork( object sender , DoWorkEventArgs e ) {

		}

		private void removeBackgroundWorker_RunWorkerCompleted( object sender , RunWorkerCompletedEventArgs e ) {

		}

	}

}