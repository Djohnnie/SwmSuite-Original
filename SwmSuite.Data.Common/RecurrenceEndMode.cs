using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.Common {

  /// <summary>
  /// Enumerator defining the end of a recurrence.
  /// </summary>
  [Serializable]
  [XmlType( Namespace = "SwmSuite_v1" )]
  public enum RecurrenceEndMode {

    /// <summary>
    /// The recurrence goes on forever.
    /// </summary>
    Infinite,

    /// <summary>
    /// The recurrence is only occuring a fixed number of times.
    /// </summary>
    ByNumber,

    /// <summary>
    /// The recurrence will end on a specific date.
    /// </summary>
    ByDate

  }

}