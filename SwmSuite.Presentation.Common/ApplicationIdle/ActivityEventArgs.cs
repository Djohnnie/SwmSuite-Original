using System;

namespace SwmSuite.Presentation.Common.ApplicationIdle {

	/// <summary>
	/// Class that contains the one of the ActivityMessages that the component used to consider the application not idle.
	/// </summary>
	public class ActivityEventArgs : EventArgs {
		#region -_ Private Members _-

		private ActivityMessages _Message;

		#endregion

		#region -_ Constructors _-

		/// <summary>
		/// Initializes a new instance of the ActivityEventArgs class.
		/// </summary>
		/// <param name="message">One of the ActivityMessages.</param>
		public ActivityEventArgs( ActivityMessages message ) {
			_Message = message;
		}

		#endregion

		#region -_ Properties _-

		/// <summary>
		/// Gets the one of the ActivityMessages that the component used to consider the application not idle. 
		/// </summary>
		public ActivityMessages Message {
			get { return _Message; }
		}

		#endregion

	}

}
