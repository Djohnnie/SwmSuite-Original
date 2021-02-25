using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;
using SwmSuite.Data.Common;

namespace SwmSuite.Data.DataObjects {

	[Serializable]
	[XmlType( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	public class MessageFolderData : DataObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the internal id for the employee that has sent this message.
		/// </summary>
		public int OwnerEmployeeSysId { get; set; }

		/// <summary>
		/// Gets or sets the internal id for the parent messagefolder this messagefolder is a child of.
		/// <remarks>Can be null if this messagefolder is on root.</remarks>
		/// </summary>
		public int? ParentMessageFolderSysId { get; set; }

		/// <summary>
		/// Gets or sets the type of special folder for this messagefolder.
		/// </summary>
		public MessageSpecialFolder SpecialFolder { get; set; }

		/// <summary>
		/// Gets or sets the name for this messagefolder.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the visibility for this messagefolder.
		/// </summary>
		public bool Visible { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public MessageFolderData() {

		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="ownerEmployeeSysId">The internal id for the employee that has sent this message.</param>
		/// <param name="parentFolderSysId">The internal id for the parent messagefolder this messagefolder is a child of.</param>
		/// <param name="specialFolder">The type of special folder for this messagefolder.</param>
		/// <param name="name">The name for this messagefolder.</param>
		/// <param name="visible">The visibility for this messagefolder.</param>
		public MessageFolderData( int ownerEmployeeSysId , int? parentFolderSysId , MessageSpecialFolder specialFolder , string name , bool visible ) {
			this.OwnerEmployeeSysId = ownerEmployeeSysId;
			this.ParentMessageFolderSysId = parentFolderSysId;
			this.SpecialFolder = specialFolder;
			this.Name = name;
			this.Visible = visible;
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Convert this messagefolder to its string representation.
		/// </summary>
		/// <returns>The name of this messagefolder.</returns>
		public override string ToString() {
			return this.Name;
		}

		#endregion

	}

}
