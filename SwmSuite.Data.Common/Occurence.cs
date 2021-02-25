using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.Common {
  
  /// <summary>
  /// Enumerator defining occurences.
  /// </summary>
  [Serializable]
  [XmlType( Namespace = "SwmSuite_v1" )]
  public enum Occurrence {

    /// <summary>
    /// The first occurence.
    /// </summary>
    First,

    /// <summary>
    /// The second occurence.
    /// </summary>
    Second,

    /// <summary>
    /// The third occurence.
    /// </summary>
    Third,

    /// <summary>
    /// The fourth occurence.
    /// </summary>
    Fourth,

    /// <summary>
    /// The last occurence.
    /// </summary>
    Last

  }

}
