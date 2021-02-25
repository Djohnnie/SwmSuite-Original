using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace SwmSuite.Presentation.Common.Validation {

	public partial class ValidationControl : UserControl {

		#region -_ Private Members _-

		private bool _valid = false;

		#endregion

		#region -_ Public Properties _-

		public bool Valid {
			get {
				return _valid;
			}
			set {
				_valid = value;
				if( _valid ) {
					this.BackgroundImage = SwmSuite.Presentation.Common.Properties.Resources.ok;
				}else{
					this.BackgroundImage = SwmSuite.Presentation.Common.Properties.Resources.nok;
				}
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ValidationControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );
		}

		#endregion



	}
}