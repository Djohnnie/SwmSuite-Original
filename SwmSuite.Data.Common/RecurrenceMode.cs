using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.Common {

  /// <summary>
  /// Enumerator defining all modes of recurrence.
  /// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
  public enum RecurrenceMode {

		/// <summary>
		/// Every day.
		/// </summary>
		Daily ,

		/// <summary>
		/// Every week.
		/// </summary>
		Weekly ,

		/// <summary>
		/// Every month.
		/// </summary>
		Monthly ,

		/// <summary>
		/// Every year.
		/// </summary>
		Yearly

	}

}
