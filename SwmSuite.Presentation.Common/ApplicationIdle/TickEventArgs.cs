using System;

namespace SwmSuite.Presentation.Common.ApplicationIdle {

	/// <summary>
	/// Class that contains a bool that indicates whether the TimeRemaining is less than or equal to WarnTime.
	/// </summary>
	public class TickEventArgs : EventArgs {
		#region -_ Private Members _-

		private bool _IsWarnPeriod;

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the TickEventArgs class.
		/// </summary>
		/// <param name="isWarnPeriod">Indicates whether the TimeRemaining is less than or equal to WarnTime.</param>
		public TickEventArgs( bool isWarnPeriod ) {
			_IsWarnPeriod = isWarnPeriod;
		}

		#endregion

		#region -_ Properties _-

		/// <summary>
		/// Gets whether the TimeRemaining is less than or equal to WarnTime. 
		/// </summary>
		public bool IsWarnPeriod {
			get { return _IsWarnPeriod; }
		}

		#endregion
	}
}
