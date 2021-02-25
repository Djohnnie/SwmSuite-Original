using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwmSuite.Presentation.Common.AgendaControl {
	
	/// <summary>
	/// Enumerator defining an area that can be hit on the agenda control.
	/// </summary>
	public enum AgendaHitTestArea {

		/// <summary>
		/// The header.
		/// </summary>
		Header,

		/// <summary>
		/// The time ruler.
		/// </summary>
		TimeRuler,

		/// <summary>
		/// The contents.
		/// </summary>
		Content,

		/// <summary>
		/// An appointment.
		/// </summary>
		Appointment,

	}

}
