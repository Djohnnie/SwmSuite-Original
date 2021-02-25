using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Proxy.Interface;


namespace SimpleWorkfloorManagementSuite.Modules {

	public partial class HomeModule : UserControl {

		#region -_ Public Events _-

		/// <summary>
		/// Event raised when the user clicks the message notification area.
		/// </summary>
		public event EventHandler<EventArgs> MessageNotificationClicked;

		/// <summary>
		/// Event raised when the user clicks the agenda notification area.
		/// </summary>
		public event EventHandler<EventArgs> AgendaNotificationClicked;

		/// <summary>
		/// Event raised when the user clicks the timetable notification area.
		/// </summary>
		public event EventHandler<EventArgs> TimeTableNotificationClicked;

		/// <summary>
		/// Event raised when the user clicks the holiday notification area.
		/// </summary>
		public event EventHandler<EventArgs> HolidayNotificationClicked;

		/// <summary>
		/// Event raised when the user clicks the task notification area.
		/// </summary>
		public event EventHandler<EventArgs> TaskNotificationClicked;

		#endregion

		#region -_ Construction _-

		public HomeModule() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );
		}

		#endregion

		/// <summary>
		/// Handles the Load event of the HomeModule control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void HomeModule_Load( object sender , EventArgs e ) {

		}

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Click event of the messageNotification control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void messageNotification_Click( object sender , EventArgs e ) {
			if( this.MessageNotificationClicked != null ) {
				MessageNotificationClicked( this , EventArgs.Empty );
			}
		}

		/// <summary>
		/// Handles the Click event of the agendaNotification control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void agendaNotification_Click( object sender , EventArgs e ) {
			if( this.AgendaNotificationClicked != null ) {
				AgendaNotificationClicked( this , EventArgs.Empty );
			}
		}

		/// <summary>
		/// Handles the Click event of the timeTableNotification control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void timeTableNotification_Click( object sender , EventArgs e ) {
			if( this.TimeTableNotificationClicked != null ) {
				TimeTableNotificationClicked( this , EventArgs.Empty );
			}
		}

		/// <summary>
		/// Handles the Click event of the holidayNotification control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void holidayNotification_Click( object sender , EventArgs e ) {
			if( this.HolidayNotificationClicked != null ) {
				HolidayNotificationClicked( this , EventArgs.Empty );
			}
		}

		/// <summary>
		/// Handles the Click event of the taskNotification control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void taskNotification_Click( object sender , EventArgs e ) {
			if( this.TaskNotificationClicked != null ) {
				TaskNotificationClicked( this , EventArgs.Empty );
			}
		}

		/// <summary>
		/// Handles the Resize event of the HomeModule control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void HomeModule_Resize( object sender , EventArgs e ) {
			int horizontalGap = (int)( (float)this.ClientRectangle.Width * 0.03f );
			int verticalGap = (int)( (float)this.ClientRectangle.Height * 0.03f );
			int height = ( this.ClientRectangle.Height - verticalGap ) / 5;
			int top = verticalGap;
			messageNotification.Bounds = new Rectangle( this.ClientRectangle.Left + horizontalGap , this.ClientRectangle.Top + top , this.ClientRectangle.Width - 2 * horizontalGap , height - verticalGap );
			top += height;
			agendaNotification.Bounds = new Rectangle( this.ClientRectangle.Left + horizontalGap , this.ClientRectangle.Top + top , this.ClientRectangle.Width - 2 * horizontalGap , height - verticalGap );
			top += height;
			timeTableNotification.Bounds = new Rectangle( this.ClientRectangle.Left + horizontalGap , this.ClientRectangle.Top + top , this.ClientRectangle.Width - 2 * horizontalGap , height - verticalGap );
			top += height;
			holidayNotification.Bounds = new Rectangle( this.ClientRectangle.Left + horizontalGap , this.ClientRectangle.Top + top , this.ClientRectangle.Width - 2 * horizontalGap , height - verticalGap );
			top += height;
			taskNotification.Bounds = new Rectangle( this.ClientRectangle.Left + horizontalGap , this.ClientRectangle.Top + top , this.ClientRectangle.Width - 2 * horizontalGap , height - verticalGap );
		}

		#endregion

		#region -_ Public methods _-

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		public void Initialize() {
			messageNotification.Initialize();
			agendaNotification.Initialize();
			timeTableNotification.Initialize();
			holidayNotification.Initialize();
			taskNotification.Initialize();
		}

		#endregion

	}

}
