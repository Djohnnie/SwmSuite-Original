using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.Common {

	/// <summary>
	/// Enumerator to define the different levels of priority.
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public enum MessagePriority {
		
		/// <summary>
		/// High priority.
		/// </summary>
		High ,
		/// <summary>
		/// Normal priority.
		/// </summary>
		Normal ,
		/// <summary>
		/// Low priority.
		/// </summary>
		Low

	}

}
