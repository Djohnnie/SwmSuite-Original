using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.Common {

	/// <summary>
	/// Enumerator to define the different special folders a messagefolder can be.
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public enum MessageSpecialFolder {

		/// <summary>
		/// No special folder.
		/// </summary>
		None,
		/// <summary>
		/// Inbox special folder.
		/// </summary>
		Inbox,
		/// <summary>
		/// Outbox special folder.
		/// </summary>
		Outbox,
		/// <summary>
		/// Archive special folder.
		/// </summary>
		Archive

	}

}
