using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.Common {

  /// <summary>
  /// Enumerator defining all weekdays.
  /// </summary>
  [Serializable]
  [XmlType( Namespace = "SwmSuite_v1" )]
  public enum Days {

    /// <summary>
    /// Monday (1).
    /// </summary>
    Monday,

    /// <summary>
    /// Tuesday (2).
    /// </summary>
    Tuesday,

    /// <summary>
    /// Wednesday (3).
    /// </summary>
    Wednesday,

    /// <summary>
    /// Thursday (4).
    /// </summary>
    Thursday,

    /// <summary>
    /// Friday (5).
    /// </summary>
    Friday,

    /// <summary>
    /// Saturday (6).
    /// </summary>
    Saturday,

    /// <summary>
    /// Sunday (7).
    /// </summary>
    Sunday

  }

}
