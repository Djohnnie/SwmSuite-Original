using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.BusinessObjects {
 
  /// <summary>
  /// Class representing a selection of weekdays.
  /// </summary>
  [Serializable]
  [XmlType( Namespace = "SwmSuite_v1" )]
  public class DaySelection {

    #region -_ Public Properties _-

    /// <summary>
    /// Gets or sets the selected state for monday.
    /// </summary>
    public bool Monday { get; set; }

    /// <summary>
    /// Gets or sets the selected state for tuesday.
    /// </summary>
    public bool Tuesday { get; set; }

    /// <summary>
    /// Gets or sets the selected state for wednesday.
    /// </summary>
    public bool Wednesday { get; set; }

    /// <summary>
    /// Gets or sets the selected state for thursday.
    /// </summary>
    public bool Thursday { get; set; }

    /// <summary>
    /// Gets or sets the selected state for friday.
    /// </summary>
    public bool Friday { get; set; }

    /// <summary>
    /// Gets or sets the selected state for saturday.
    /// </summary>
    public bool Saturday { get; set; }

    /// <summary>
    /// Gets or sets the selected state for sunday.
    /// </summary>
    public bool Sunday { get; set; }

    #endregion

    #region -_ Construction _-

    /// <summary>
    /// Default constructor.
    /// </summary>
    public DaySelection( ) {
      this.Monday = false;
      this.Tuesday = false;
      this.Wednesday = false;
      this.Thursday = false;
      this.Friday = false;
      this.Saturday = false;
      this.Sunday = false;
    }

    /// <summary>
    /// Custom constructor.
    /// </summary>
    /// <param name="monday">The selected state for monday.</param>
    /// <param name="tuesday">The selected state for tuesday.</param>
    /// <param name="wednesday">The selected state for wednesday.</param>
    /// <param name="thursday">The selected state for thursday.</param>
    /// <param name="friday">The selected state for friday.</param>
    /// <param name="saturday">The selected state for saturday.</param>
    /// <param name="sunday">The selected state for sunday.</param>
    public DaySelection( bool monday, bool tuesday, bool wednesday, bool thursday, bool friday, bool saturday, bool sunday ) {
      this.Monday = monday;
      this.Tuesday = tuesday;
      this.Wednesday = wednesday;
      this.Thursday = thursday;
      this.Friday = friday;
      this.Saturday = saturday;
      this.Sunday = sunday;
    }

    #endregion

  }
}
