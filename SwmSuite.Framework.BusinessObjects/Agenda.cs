using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;
using SwmSuite.Data.Common;
using System.Drawing;

namespace SwmSuite.Data.BusinessObjects {

	/// <summary>
	/// Class defining an agenda.
	/// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class Agenda : BusinessObjectBase {

		#region -_ Private Members _-

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the title for this agenda.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the description for this agenda.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the employee owning this agenda.
		/// </summary>
		public Employee OwnerEmployee { get; set; }

		/// <summary>
		/// Gets or sets the visibility for this appointment.
		/// </summary>
		public AppointmentVisibility Visibility { get; set; }

		/// <summary>
		/// Gets or sets the first color.
		/// </summary>
		[System.Xml.Serialization.XmlIgnore()]
		public Color Color1 {
			get {
				return Color.FromArgb( this.ColorValue1 );
			}
			set {
				this.ColorValue1 = value.ToArgb();
			}
		}

		public int ColorValue1 { get; set; }

		/// <summary>
		/// Gets or sets the second color.
		/// </summary>
		[System.Xml.Serialization.XmlIgnore()]
		public Color Color2 {
			get {
				return Color.FromArgb( this.ColorValue2 );
			}
			set {
				this.ColorValue2 = value.ToArgb();
			}
		}

		public int ColorValue2 { get; set; }

		/// <summary>
		/// Gets or sets the third color.
		/// </summary>
		[System.Xml.Serialization.XmlIgnore()]
		public Color Color3 {
			get {
				return Color.FromArgb( this.ColorValue3 );
			}
			set {
				this.ColorValue3 = value.ToArgb();
			}
		}

		public int ColorValue3 { get; set; }

		/// <summary>
		/// Gets or sets the special agenda type.
		/// </summary>
		/// <value>The special agenda type.</value>
		public SpecialAgenda Special { get; set; }

		#endregion

		#region -_ Construction _-

		public Agenda() {
			this.Color1 = Color.Black;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Agenda"/> class.
		/// </summary>
		/// <param name="title">The title for this agenda.</param>
		/// <param name="description">The description for this agenda.</param>
		/// <param name="owner">The internal id of the employee owning this agenda.</param>
		/// <param name="visibility">The visibility for this appointment.</param>
		public Agenda( string title , string description , Employee owner , AppointmentVisibility visibility )
			: this() {
			this.Title = title;
			this.Description = description;
			this.OwnerEmployee = owner;
			this.Visibility = visibility;
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
			// Validate title.
			if( String.IsNullOrEmpty( this.Title ) ) {
				valid = false;
				this.ValidationErrors.Add( "Titel is verplicht in te vullen." );
			}
			// Validate description.
			if( String.IsNullOrEmpty( this.Description ) ) {
				valid = false;
				this.ValidationErrors.Add( "Omschrijving is verplicht in te vullen." );
			}
			// Validate owner employee.
			if( this.OwnerEmployee == null ) {
				valid = false;
				this.ValidationErrors.Add( "Eigenaar is verplicht in te vullen." );
			}
			return valid;
		}

		#endregion


		/// <summary>
		/// Gets the guest agenda.
		/// </summary>
		/// <returns></returns>
		public static Agenda GetGuestAgenda() {
			Agenda agenda = new Agenda();
			agenda.Title = "Gast";
			agenda.Special = SpecialAgenda.GuestAgenda;
			agenda.Color1 = Color.FromArgb( 0 , 0 , 0 );
			agenda.Color2 = Color.FromArgb( 200 , 200 , 200 );
			agenda.Color3 = Color.FromArgb( 150 , 150 , 150 );
			return agenda;
		}

		/// <summary>
		/// Gets the time table agenda.
		/// </summary>
		/// <returns></returns>
		public static Agenda GetTimeTableAgenda() {
			Agenda agenda = new Agenda();
			agenda.Title = "Uurrooster";
			agenda.Special = SpecialAgenda.TimeTableAgenda;
			agenda.Color1 = Color.FromArgb( 0 , 0 , 0 );
			agenda.Color2 = Color.FromArgb( 200 , 200 , 200 );
			agenda.Color3 = Color.FromArgb( 150 , 150 , 150 );
			return agenda;
		}
	}

}
