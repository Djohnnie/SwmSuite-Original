using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;
using System.Collections.Specialized;

namespace SwmSuite.Data.BusinessObjects {

	/// <summary>
	/// BusinessObjectBase is the base class for every SWMS businessobject.
	/// </summary>
	/// <remarks>
	/// Every SWMS businessobject has the following common fields:
	///  - SysId
	/// </remarks>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class BusinessObjectBase {

		#region -_ Private Members _-

		private StringCollection _validationErrors = new StringCollection();

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the internal unique id for this businessobject.
		/// </summary>
		public int SysId { get; set; }

		/// <summary>
		/// Gets or sets the rowversion for this businessobject.
		/// </summary>
		public int RowVersion { get; set; }

		/// <summary>
		/// Gets the validation errors.
		/// </summary>
		/// <value>The validation errors.</value>
		public StringCollection ValidationErrors {
			get {
				return _validationErrors;
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public BusinessObjectBase() {
		}

		/// <summary>
		/// Custom constructor.
		/// </summary>
		/// <param name="sysId">The internal unique id for this businessobject.</param>
		/// <param name="rowVersion">The rowversion for this businessobject.</param>
		public BusinessObjectBase( int sysId , int rowVersion )
			: this() {
			this.SysId = sysId;
			this.RowVersion = rowVersion;
		}

		#endregion

		#region -_ Validation _-

		/// <summary>
		/// Validates this instance.
		/// </summary>
		/// <returns>Returns true if valid, false otherwise.</returns>
		public virtual bool Validate() {
			this.ValidationErrors.Clear();
			return true;
		}

		/// <summary>
		/// Gets the validation error.
		/// </summary>
		/// <returns></returns>
		public String GetValidationError() {
			String validationError = "";
			foreach( String errorDescription in this.ValidationErrors ) {
				validationError += errorDescription;
				if( this.ValidationErrors.IndexOf( errorDescription ) < this.ValidationErrors.Count - 1 ) {
					validationError += "\n";
				}
			}
			return validationError;
		}

		#endregion

	}

}
