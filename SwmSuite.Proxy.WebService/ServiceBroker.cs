using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Proxy.Interface;

namespace SwmSuite.Proxy.WebService
{
	public sealed class ServiceBroker : IServiceBroker {

		/// <summary>
		/// Create a class that implements the IUserFacade interface for access to UserBll.
		/// </summary>
		/// <returns>A class of type IUserFacade.</returns>
		IUserFacade IServiceBroker.CreateUserFacade() {
			return new UserFacade();
		}

		/// <summary>
		/// Create a class that implements the IEmployeeFacade interface for access to EmployeeBll.
		/// </summary>
		/// <returns>A class of type IEmployeeFacade.</returns>
		IEmployeeFacade IServiceBroker.CreateEmployeeFacade() {
			return new EmployeeFacade();
		}

		/// <summary>
		/// Create a class that implements the IConnectionTestFacade interface for access to ConnectionTestBll.
		/// </summary>
		/// <returns>A class of type IConnectionTestFacade.</returns>
		IConnectionTestFacade IServiceBroker.CreateConnectionTestFacade() {
			return new ConnectionTestFacade();
		}

		/// <summary>
		/// Create a class that implements the IZipCodeFacade interface for access to ZipCodeBll.
		/// </summary>
		/// <returns>A class of type IZipCodeFacade.</returns>
		IZipCodeFacade IServiceBroker.CreateZipCodeFacade() {
			return new ZipCodeFacade();
		}

		/// <summary>
		/// Create a class that implements the ICountryFacade interface for access to CountryBll.
		/// </summary>
		/// <returns>A class of type ICountryFacade.</returns>
		ICountryFacade IServiceBroker.CreateCountryFacade() {
			return new CountryFacade();
		}

		/// <summary>
		/// Create a class that implements the IAvatarFacade interface for access to AvatarBll.
		/// </summary>
		/// <returns>A class of type IAvatarFacade.</returns>
		IAvatarFacade IServiceBroker.CreateAvatarFacade() {
			return new AvatarFacade();
		}

		/// <summary>
		/// Create a class that implements the IAlertFacade interface for access to AlertBll.
		/// </summary>
		/// <returns>A class of type IAlertFacade.</returns>
		IAlertFacade IServiceBroker.CreateAlertFacade() {
			return new AlertFacade();
		}

		/// <summary>
		/// Create a class that implements the IMessageFacade interface for access to MessageBll.
		/// </summary>
		/// <returns>A class of type IMessageFacade.</returns>
		IMessageFacade IServiceBroker.CreateMessageFacade() {
			return new MessageFacade();
		}

		/// <summary>
		/// Create a class that implements the IAgendaFacade interface for access to AgendaBll.
		/// </summary>
		/// <returns>>A class of type IAgendaFacade.</returns>
		IAgendaFacade IServiceBroker.CreateAgendaFacade() {
			return new AgendaFacade();
		}

		/// <summary>
		/// Create a class that implements the ITimeTableFacade interface for access to TimeTableBll.
		/// </summary>
		/// <returns>>A class of type ITimeTableFacade.</returns>
		ITimeTableFacade IServiceBroker.CreateTimeTableFacade() {
			return new TimeTableFacade();
		}

		/// <summary>
		/// Create a class that implements the ITaskFacade interface for access to TaskBll.
		/// </summary>
		/// <returns>>A class of type ITaskFacade.</returns>
		ITaskFacade IServiceBroker.CreateTaskFacade() {
			return new TaskFacade();
		}

		/// <summary>
		/// Create a class that implements the ILoggingFacade interface for access to LoggingBll.
		/// </summary>
		/// <returns>>A class of type ILoggingFacade.</returns>
		ILoggingFacade IServiceBroker.CreateLoggingFacade() {
			return new LoggingFacade();
		}

		/// <summary>
		/// Create a class that implements the IHolidayFacade interface for access to HolidayBll.
		/// </summary>
		/// <returns>A class of type IHolidayFacade.</returns>
		IHolidayFacade IServiceBroker.CreateHolidayFacade() {
			return new HolidayFacade();
		}

	}

}