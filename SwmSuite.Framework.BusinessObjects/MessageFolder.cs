using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;
using SwmSuite.Data.Common;

namespace SwmSuite.Data.BusinessObjects {

	/// <summary>
	/// Class defining a folder that contains messages and subfolders.
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class MessageFolder : BusinessObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the name of this messagefolder.
		/// </summary>
		public String Name { get; set; }

		/// <summary>
		/// Gets or sets the visibility of this messagefolder.
		/// </summary>
		public bool Visible { get; set; }

		/// <summary>
		/// Gets or sets the special folder status of this messagefolder.
		/// </summary>
		public MessageSpecialFolder SpecialFolder { get; set; }

		/// <summary>
		/// Gets or sets the child folders of this messagefolder.
		/// </summary>
		public MessageFolderCollection ChildFolders { get; set; }

		/// <summary>
		/// Gets or sets the messages of this messagefolder.
		/// </summary>
		public MessageCollection Messages { get; set; }

		/// <summary>
		/// Gets or sets the parent folder of this messagefolder.
		/// </summary>
		[XmlIgnore]
		public MessageFolder ParentFolder { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public MessageFolder() {
		}

		#endregion

		#region -_ ToString _-

		/// <summary>
		/// Convert this messagefolder to its string representation.
		/// </summary>
		/// <returns>The name of this messagefolder.</returns>
		public override string ToString() {
			return this.Name;
		}

		#endregion

		#region -_ Public Methods _-

		public bool MoveFolderAllowed( MessageFolder destinationFolder ) {
			bool allowed = true;
			// Cannot move a folder to itself.
			if( this.SysId == destinationFolder.SysId ) {
				allowed = false;
			}
			// Cannot move a folder to a child folder of itself (recursive).
			if( FolderIsChildOf( destinationFolder ) ) {
				allowed = false;
			}
			// Cannot move a folder to an a folder within another root folder.
			if( HasDifferentRootFolder( destinationFolder ) ) {
				allowed = false;
			}
			return allowed;
		}

		public MessageFolder GetRootFolder() {
			return GetParentFolder( this );
		}

		#endregion

		#region -_ Private Methods _-

		private bool FolderIsChildOf( MessageFolder folderToCheck ) {
			bool isChild = false;
			if( this.ChildFolders != null ) {
				foreach( MessageFolder messageFolder in this.ChildFolders ) {
					if( messageFolder.SysId == folderToCheck.SysId ) {
						isChild = true;
					}
				}
			}
			return isChild;
		}

		private bool HasDifferentRootFolder( MessageFolder folderToCheck ) {
			bool hasDifferentRootFolder = false;
			if( this.GetRootFolder().SysId != folderToCheck.GetRootFolder().SysId ) {
				hasDifferentRootFolder = true;
			}
			return hasDifferentRootFolder;
		}

		private MessageFolder GetParentFolder( MessageFolder folder ) {
			if( folder.ParentFolder == null ) {
				return folder;
			} else {
				return GetParentFolder( folder.ParentFolder );
			}
		}

		#endregion

		#region -_ Validation _-

		/// <summary>
		/// Validates this instance.
		/// </summary>
		/// <returns></returns>
		public bool Validate() {
			bool valid = true;
			this.ValidationErrors.Clear();
			// Validate name.
			if( String.IsNullOrEmpty( this.Name ) ) {
				valid = false;
				this.ValidationErrors.Add( "Naam is verplicht in te vullen." );
			}
			// Validate parent folder.
			if( this.SpecialFolder == MessageSpecialFolder.None ) {
				if( this.ParentFolder == null ) {
					valid = false;
					this.ValidationErrors.Add( "Deze map moet een bovenliggende map hebben, of moet een top-niveau map zijn." );
				}
			} else {
				if( this.ParentFolder != null ) {
					valid = false;
					this.ValidationErrors.Add( "Een top-niveau map kan geen bovenliggende map hebben." );
				}
			}			
			return valid;
		}

		#endregion

	}

}
