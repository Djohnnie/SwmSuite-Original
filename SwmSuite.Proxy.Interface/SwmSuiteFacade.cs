using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Proxy.Interface;

namespace SwmSuite.Proxy.Interface {

	/// <summary>
	/// 
	/// </summary>
	public class SwmSuiteFacade {

		#region -_ Private Members _-

		private static IEmployeeFacade _employeeFacade;
		private static IAlertFacade _alertFacade;
		private static IMessageFacade _messageFacade;
		private static IAgendaFacade _agendaFacade;
		private static ITimeTableFacade _timeTableFacade;
		private static ITaskFacade _taskFacade;
		private static ILoggingFacade _loggingFacade;
		private static IConnectionTestFacade _connectionTestFacade;
		private static IAvatarFacade _avatarFacade;
		private static IHolidayFacade _holidayFacade;
		private static IUserFacade _userFacade;
		private static ICountryFacade _countryFacade;
		private static IZipCodeFacade _zipcodeFacade;

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets the employee facade.
		/// </summary>
		/// <value>The employee facade.</value>
		public static IEmployeeFacade EmployeeFacade {
			get {
				if( _employeeFacade == null ) {
					_employeeFacade = ServiceBroker.CreateBroker().CreateEmployeeFacade();
				}
				return _employeeFacade;
			}
		}

		/// <summary>
		/// Gets the alert facade.
		/// </summary>
		/// <value>The alert facade.</value>
		public static IAlertFacade Alert {
			get {
				if( _alertFacade == null ) {
					_alertFacade = ServiceBroker.CreateBroker().CreateAlertFacade();
				}
				return _alertFacade;
			}
		}

		/// <summary>
		/// Gets the message facade.
		/// </summary>
		/// <value>The message facade.</value>
		public static IMessageFacade MessageFacade {
			get {
				if( _messageFacade == null ) {
					_messageFacade = ServiceBroker.CreateBroker().CreateMessageFacade();
				}
				return _messageFacade;
			}
		}

		/// <summary>
		/// Gets the agenda facade.
		/// </summary>
		/// <value>The agenda facade.</value>
		public static IAgendaFacade AgendaFacade {
			get {
				if( _agendaFacade == null ) {
					_agendaFacade = ServiceBroker.CreateBroker().CreateAgendaFacade();
				}
				return _agendaFacade;
			}
		}

		/// <summary>
		/// Gets the time table facade.
		/// </summary>
		/// <value>The time table facade.</value>
		public static ITimeTableFacade TimeTableFacade {
			get {
				if( _timeTableFacade == null ) {
					_timeTableFacade = ServiceBroker.CreateBroker().CreateTimeTableFacade();
				}
				return _timeTableFacade;
			}
		}

		/// <summary>
		/// Gets the task facade.
		/// </summary>
		/// <value>The task facade.</value>
		public static ITaskFacade TaskFacade {
			get {
				if( _taskFacade == null ) {
					_taskFacade = ServiceBroker.CreateBroker().CreateTaskFacade();
				}
				return _taskFacade;
			}
		}

		/// <summary>
		/// Gets the logging facade.
		/// </summary>
		/// <value>The logging facade.</value>
		public static ILoggingFacade LoggingFacade {
			get {
				if( _loggingFacade == null ) {
					_loggingFacade = ServiceBroker.CreateBroker().CreateLoggingFacade();
				}
				return _loggingFacade;
			}
		}

		/// <summary>
		/// Gets the connection test facade.
		/// </summary>
		/// <value>The connection test facade.</value>
		public static IConnectionTestFacade ConnectionTestFacade {
			get {
				if( _connectionTestFacade == null ) {
					_connectionTestFacade = ServiceBroker.CreateBroker().CreateConnectionTestFacade();
				}
				return _connectionTestFacade;
			}
		}

		/// <summary>
		/// Gets the avatar facade.
		/// </summary>
		/// <value>The avatar facade.</value>
		public static IAvatarFacade AvatarFacade {
			get {
				if( _avatarFacade == null ) {
					_avatarFacade = ServiceBroker.CreateBroker().CreateAvatarFacade();
				}
				return _avatarFacade;
			}
		}

		/// <summary>
		/// Gets the holiday facade.
		/// </summary>
		/// <value>The holiday facade.</value>
		public static IHolidayFacade HolidayFacade {
			get {
				if( _holidayFacade == null ) {
					_holidayFacade = ServiceBroker.CreateBroker().CreateHolidayFacade();
				}
				return _holidayFacade;
			}
		}

		/// <summary>
		/// Gets the user facade.
		/// </summary>
		/// <value>The user facade.</value>
		public static IUserFacade UserFacade {
			get {
				if( _userFacade == null ) {
					_userFacade = ServiceBroker.CreateBroker().CreateUserFacade();
				}
				return _userFacade;
			}
		}

		/// <summary>
		/// Gets the country facade.
		/// </summary>
		/// <value>The country facade.</value>
		public static ICountryFacade CountryFacade {
			get {
				if( _countryFacade == null ) {
					_countryFacade = ServiceBroker.CreateBroker().CreateCountryFacade();
				}
				return _countryFacade;
			}
		}

		/// <summary>
		/// Gets the zip code facade.
		/// </summary>
		/// <value>The zip code facade.</value>
		public static IZipCodeFacade ZipCodeFacade {
			get {
				if( _zipcodeFacade == null ) {
					_zipcodeFacade = ServiceBroker.CreateBroker().CreateZipCodeFacade();
				}
				return _zipcodeFacade;
			}
		}


		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Disable the construction of this <see cref="SwmSuiteFacade"/>
		/// class by defining a private constructor.
		/// </summary>
		private SwmSuiteFacade() {
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Clears the facade.
		/// </summary>
		public static void ClearFacade() {
			_employeeFacade = null;
			_alertFacade = null;
			_messageFacade = null;
			_agendaFacade = null;
			_timeTableFacade = null;
			_taskFacade = null;
			_loggingFacade = null;
			_connectionTestFacade = null;
			_avatarFacade = null;
			_holidayFacade = null;
			_countryFacade = null;
			_zipcodeFacade = null;
		}

		#endregion

	}

}
