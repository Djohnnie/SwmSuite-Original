using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;

namespace SwmSuite.Data.BusinessObjects {

  /// <summary>
  /// Class defining an alert.
  /// </summary>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class Alert : BusinessObjectBase {

		#region -_ Public Properties _-

		public String Message { get; set; }

		public bool Visible { get; set; }

		public EmployeeCollection Employees { get; set; }

		public EmployeeGroupCollection EmployeeGroups { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public Alert() {
			this.Employees = new EmployeeCollection();
			this.EmployeeGroups = new EmployeeGroupCollection();
		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="message">The message represented by this alert.</param>
		public Alert( String message )
			: this() {
			this.Message = message;
		}

		#endregion

		#region -_ Validation _-

		/// <summary>
		/// Validates this instance.
		/// </summary>
		/// <returns></returns>
		public override bool Validate() {
			bool valid = true;
			this.ValidationErrors.Clear();
			// Validate message.
			if( String.IsNullOrEmpty( this.Message ) ) {
				valid = false;
				this.ValidationErrors.Add( "Mededeling is verplicht in te vullen." );
			}
			return valid;
		}

		#endregion

	}

}