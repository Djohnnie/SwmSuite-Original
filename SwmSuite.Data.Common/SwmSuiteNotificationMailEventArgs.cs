using System;
using System.Collections.Generic;
using System.Text;

namespace SwmSuite.Data.Common {
	
	public class SwmSuiteNotificationMailEventArgs : EventArgs {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets a value indicating whether the notification message was sent successfully.
		/// </summary>
		/// <value><c>true</c> if the notification message was sent successfully; otherwise, <c>false</c>.</value>
		public bool Successful { get; set; }

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>The message.</value>
		public String Message { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="SwmSuiteNotificationMailEventArgs"/> class.
		/// </summary>
		public SwmSuiteNotificationMailEventArgs() {
			this.Successful = true;
			this.Message = String.Empty;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SwmSuiteNotificationMailEventArgs"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		public SwmSuiteNotificationMailEventArgs( String message ) {
			this.Successful = false;
			this.Message = message;
		}

		#endregion

	}

}
