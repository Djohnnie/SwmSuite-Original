using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using SwmSuite.Data.BusinessObjects;
using System.Drawing;

namespace SwmSuite.Data.BusinessObjects {

	/// <summary>
	/// Class defining a timetable purpose.
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class TimeTablePurpose : BusinessObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the description for this timetable purpose.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the legenda color.
		/// </summary>
		public int LegendaColor1 { get; set; }

		/// <summary>
		/// Gets or sets the legenda color.
		/// </summary>
		public int LegendaColor2 { get; set; }

		/// <summary>
		/// Gets or sets the legenda color.
		/// </summary>
		public int LegendaColor3 { get; set; }

		/// <summary>
		/// Gets or sets the legenda color.
		/// </summary>
		[XmlIgnore]
		public Color Color1 {
			get {
				return Color.FromArgb( this.LegendaColor1 );
			}
			set {
				this.LegendaColor1 = value.ToArgb();
			}
		}

		/// <summary>
		/// Gets or sets the legenda color.
		/// </summary>
		[XmlIgnore]
		public Color Color2 {
			get {
				return Color.FromArgb( this.LegendaColor2 );
			}
			set {
				this.LegendaColor2 = value.ToArgb();
			}
		}

		/// <summary>
		/// Gets or sets the legenda color.
		/// </summary>
		[XmlIgnore]
		public Color Color3 {
			get {
				return Color.FromArgb( this.LegendaColor3 );
			}
			set {
				this.LegendaColor3 = value.ToArgb();
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTablePurpose"/> class.
		/// </summary>
		public TimeTablePurpose() {
			this.Color1 = Color.Black;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTablePurpose"/> class.
		/// </summary>
		/// <param name="description">The description.</param>
		/// <param name="color1">The legenda color.</param>
		/// <param name="color2">The legenda color.</param>
		/// <param name="color3">The legenda color.</param>
		public TimeTablePurpose( string description , int color1 , int color2 , int color3 )
			: this() {
			this.Description = description;
			this.LegendaColor1 = color1;
			this.LegendaColor2 = color2;
			this.LegendaColor3 = color3;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTablePurpose"/> class.
		/// </summary>
		/// <param name="description">The description.</param>
		/// <param name="color1">The legenda color.</param>
		/// <param name="color2">The legenda color.</param>
		/// <param name="color3">The legenda color.</param>
		public TimeTablePurpose( string description , Color color1 , Color color2 , Color color3 )
			: this() {
			this.Description = description;
			this.Color1 = color1;
			this.Color2 = color2;
			this.Color3 = color3;
		}

		#endregion

	}

}
