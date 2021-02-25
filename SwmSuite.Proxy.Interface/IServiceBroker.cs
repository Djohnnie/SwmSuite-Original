using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Utils;
using SwmSuite.Framework.Application;

namespace SwmSuite.Proxy.Interface
{
	/// <summary>
	/// Interface for the servicebroker.
	/// </summary>
	public interface IServiceBroker {

		/// <summary>
		/// Create a class that implements the IUserFacade interface for access to UserBll.
		/// </summary>
		/// <returns>A class of type IUserFacade.</returns>
		IUserFacade CreateUserFacade();

		/// <summary>
		/// Create a class that implements the IEmployeeFacade interface for access to EmployeeBll.
		/// </summary>
		/// <returns>A class of type IEmployeeFacade.</returns>
		IEmployeeFacade CreateEmployeeFacade();

		/// <summary>
		/// Create a class that implements the IConnectionTestFacade interface for access to ConnectionTestBll.
		/// </summary>
		/// <returns>A class of type IConnectionTestFacade.</returns>
		IConnectionTestFacade CreateConnectionTestFacade();

		/// <summary>
		/// Create a class that implements the IZipCodeFacade interface for access to ZipCodeBll.
		/// </summary>
		/// <returns>A class of type IZipCodeFacade.</returns>
		IZipCodeFacade CreateZipCodeFacade();

		/// <summary>
		/// Create a class that implements the ICountryFacade interface for access to CountryBll.
		/// </summary>
		/// <returns>A class of type ICountryFacade.</returns>
		ICountryFacade CreateCountryFacade();

		/// <summary>
		/// Create a class that implements the IAvatarFacade interface for access to AvatarBll.
		/// </summary>
		/// <returns>A class of type IAvatarFacade.</returns>
		IAvatarFacade CreateAvatarFacade();

		/// <summary>
		/// Create a class that implements the IAlertFacade interface for access to AlertBll.
		/// </summary>
		/// <returns>A class of type IAlertFacade.</returns>
		IAlertFacade CreateAlertFacade();

		/// <summary>
		/// Create a class that implements the IMessageFacade interface for access to MessageBll.
		/// </summary>
		/// <returns>A class of type IMessageFacade.</returns>
		IMessageFacade CreateMessageFacade();

		/// <summary>
		/// Create a class that implements the IAgendaFacade interface for access to AgendaBll.
		/// </summary>
		/// <returns>A class of type IAgendaFacade.</returns>
		IAgendaFacade CreateAgendaFacade();

		/// <summary>
		/// Create a class that implements the ITimeTableFacade interface for access to TimeTableBll.
		/// </summary>
		/// <returns>A class of type ITimeTableFacade.</returns>
		ITimeTableFacade CreateTimeTableFacade();

		/// <summary>
		/// Create a class that implements the ITaskFacade interface for access to TaskBll.
		/// </summary>
		/// <returns>A class of type ITaskFacade.</returns>
		ITaskFacade CreateTaskFacade();

		/// <summary>
		/// Create a class that implements the ILoggingFacade interface for access to LoggingBll.
		/// </summary>
		/// <returns>A class of type ILoggingFacade.</returns>
		ILoggingFacade CreateLoggingFacade();

		/// <summary>
		/// Create a class that implements the IHolidayFacade interface for access to HolidayBll.
		/// </summary>
		/// <returns>A class of type IHolidayFacade.</returns>
		IHolidayFacade CreateHolidayFacade();

	}

	/// <summary>
	/// Unified broker access to services.
	/// </summary>
	public static class ServiceBroker {

		/// <summary>
		/// A Factory method that creates a class of type IServiceBroker.
		/// </summary>
		/// <returns>A class of type IServiceBroker.</returns>
		public static IServiceBroker CreateBroker() {
			return ObjectFactory.CreateObject<IServiceBroker>( SwmSuiteSettings.ConnectionSettings.ConnectionModeString );
		}

		public static IServiceBroker CreateInprocBroker() {
			return ObjectFactory.CreateObject<IServiceBroker>( "SwmSuite.Proxy.Inproc.ServiceBroker,SwmSuite.Proxy.Inproc" );
		}

		public static IServiceBroker CreateWebserviceBroker() {
			return ObjectFactory.CreateObject<IServiceBroker>( "SwmSuite.Proxy.WebService.ServiceBroker,SwmSuite.Proxy.WebService" );
		}

	}
}
