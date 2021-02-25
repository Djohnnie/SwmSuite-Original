using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.BusinessObjects {

  /// <summary>
  /// Enumerator defining all months.
  /// </summary>
  [Serializable]
  [XmlType( Namespace = "SwmSuite_v1" )]
  public enum Months {

    /// <summary>
    /// January (01).
    /// </summary>
    January,

    /// <summary>
    /// February (02).
    /// </summary>
    February,

    /// <summary>
    /// March (03).
    /// </summary>
    March,

    /// <summary>
    /// April (04).
    /// </summary>
    April,

    /// <summary>
    /// May (05).
    /// </summary>
    May,

    /// <summary>
    /// June (06).
    /// </summary>
    June,

    /// <summary>
    /// July (07).
    /// </summary>
    July,

    /// <summary>
    /// August (08).
    /// </summary>
    August,

    /// <summary>
    /// September (09).
    /// </summary>
    September,

    /// <summary>
    /// October (10).
    /// </summary>
    October,

    /// <summary>
    /// November (11).
    /// </summary>
    November,

    /// <summary>
    /// December (12).
    /// </summary>
    December

  }

}