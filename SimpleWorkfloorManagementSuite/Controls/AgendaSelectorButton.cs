using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Data.BusinessObjects;
using System.Drawing;

namespace SimpleWorkfloorManagementSuite.Controls {
	
	public class AgendaSelectorButton {

		#region -_ Private Members _-



		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="AgendaSelectorButton"/> is hovered.
		/// </summary>
		/// <value><c>true</c> if hovered; otherwise, <c>false</c>.</value>
		public bool Hovered { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="AgendaSelectorButton"/> is selected.
		/// </summary>
		/// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
		public bool Selected { get; set; }

		/// <summary>
		/// Gets or sets the agenda.
		/// </summary>
		/// <value>The agenda.</value>
		public Agenda Agenda { get; set; }

		/// <summary>
		/// Gets or sets the bounds.
		/// </summary>
		/// <value>The bounds.</value>
		public Rectangle Bounds { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="AgendaSelectorButton"/> class.
		/// </summary>
		public AgendaSelectorButton() {
			this.Hovered = false;
			this.Selected = false;
			this.Agenda = null;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="AgendaSelectorButton"/> class.
		/// </summary>
		/// <param name="agenda">The agenda.</param>
		public AgendaSelectorButton( Agenda agenda ) {
			this.Hovered = false;
			this.Selected = false;
			this.Agenda = agenda;
		}

		#endregion

	}

}
