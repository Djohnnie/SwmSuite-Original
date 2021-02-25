using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;
using SwmSuite.Data.Common;

namespace SwmSuite.Data.BusinessObjects {

	/// <summary>
	/// Class defining a message.
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class Message : BusinessObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the date and time this message has been sent.
		/// </summary>
		public DateTime Date { get; set; }

		/// <summary>
		/// Gets or sets the subject of this message.
		/// </summary>
		public String Subject { get; set; }

		/// <summary>
		/// Gets or sets the content of this message.
		/// </summary>
		public String Contents { get; set; }

		/// <summary>
		/// Gets or sets the sender of this message.
		/// </summary>
		public Employee Sender { get; set; }

		/// <summary>
		/// Gets nor sets the recipients of this message.
		/// </summary>
		public EmployeeCollection Recipients { get; set; }

		/// <summary>
		/// Gets or sets the priority of this message.
		/// </summary>
		public MessagePriority Priority { get; set; }

		/// <summary>
		/// Gets or sets the visibility of this message.
		/// </summary>
		public bool Visible { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this message is read.
		/// </summary>
		/// <value><c>true</c> if this message is read; otherwise, <c>false</c>.</value>
		public bool IsRead { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this message is new.
		/// </summary>
		/// <value><c>true</c> if this message is new; otherwise, <c>false</c>.</value>
		public bool IsNew { get; set; }

		/// <summary>
		/// Gets or sets the parent folder.
		/// </summary>
		/// <value>The parent folder.</value>
		public MessageFolder ParentFolder { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public Message() {
			this.Recipients = new EmployeeCollection();
		}

		#endregion

		#region -_ Public Methods _-

		public void CreateMessageContentsForSwmSuiteAlert( String title , String contents ) {
			this.Subject = "SwmSuite notificatie: " + title;
			this.Contents =
				"{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang2067{\\fonttbl{\\f0\\fnil\\fcharset0 Calibri;}}" +
				"{\\colortbl ;\\red79\\green129\\blue189;}" +
				"{\\*\\generator Msftedit 5.41.21.2509;}\\viewkind4\\uc1\\pard\\sa200\\sl276\\slmult1\\cf1\\lang19\\b\\f0\\fs32 Simple Workfloor Management Suite\\par" +
				"\\cf0\\i\\fs28 " + title + "\\i0\\par" +
				"\\b0\\fs22 " + contents + "\\par}";
		}

		#endregion

		#region -_ Public Methods _-

		public bool MoveMessageAllowed( MessageFolder destinationFolder ) {
			bool allowed = true;
			if( GetRootFolder().SysId != destinationFolder.GetRootFolder().SysId ) {
				allowed = false;
			}
			return allowed;
		}

		public MessageFolder GetRootFolder() {
			return this.ParentFolder.GetRootFolder();
		}

		#endregion

		#region -_ ToString _-

		/// <summary>
		/// Converts this message to its string representation.
		/// </summary>
		/// <returns>The subject of this message.</returns>
		public override string ToString() {
			return this.Subject;
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
			// Validate subject.
			if( String.IsNullOrEmpty( this.Subject ) ) {
				valid = false;
				this.ValidationErrors.Add( "Onderwerp is verplicht in te vullen." );
			}
			// Validate contents.
			if( String.IsNullOrEmpty( this.Contents ) ) {
				valid = false;
				this.ValidationErrors.Add( "Bericht is verplicht in te vullen." );
			}
			// Validate sender.
			if( this.Sender == null ) {
				valid = false;
				this.ValidationErrors.Add( "Ontvanger is verplicht in te vullen." );
			}
			return valid;
		}

		#endregion

	}

}
