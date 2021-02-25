using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.Utils;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Framework.Application;

namespace SwmSuite.DataAccess.Interface {
	/// <summary>
	/// Interface for a factory class that creates Dal classes.
	/// </summary>
	public interface IDalFactory {

		#region -_ Main _-

		/// <summary>
		/// Create a DAL class that implements the IUserDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IUserDal.</returns>
		IUserDal CreateUserDal();

		/// <summary>
		/// Create a DAL class that implements the IConnectionTestDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IConnectionTestDal.</returns>
		IConnectionTestDal CreateConnectionTestDal();

		/// <summary>
		/// Create a DAL class that implements the IEmployeeDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IEmployeeDal.</returns>
		IEmployeeDal CreateEmployeeDal();

		/// <summary>
		/// Create a DAL class that implements the IEmployeeSettingsDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IEmployeeSettingsDal.</returns>
		IEmployeeSettingsDal CreateEmployeeSettingsDal();

		/// <summary>
		/// Create a DAL class that implements the IEmployeeGroupDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IEmployeeGroupDal.</returns>
		IEmployeeGroupDal CreateEmployeeGroupDal();

		/// <summary>
		/// Create a DAL class that implements the ILogDeleteDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ILogDeleteDal.</returns>
		ILogDeleteDal CreateLogDeleteDal();

		/// <summary>
		/// Create a DAL class that implements the IAlertDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IAlertDal.</returns>
		IAlertDal CreateAlertDal();

		/// <summary>
		/// Create a DAL class that implements the IEmployeeAlertDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IEmployeeAlertDal.</returns>
		IEmployeeAlertDal CreateEmployeeAlertDal();

		/// <summary>
		/// Create a DAL class that implements the IEmployeeGroupAlertDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IEmployeeGroupAlertDal.</returns>
		IEmployeeGroupAlertDal CreateEmployeeGroupAlertDal();

		/// <summary>
		/// Create a DAL class that implements the ICountryDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ICountryDal.</returns>
		ICountryDal CreateCountryDal();

		/// <summary>
		/// Create a DAL class that implements the IImageDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IImageDal.</returns>
		IAvatarDal CreateImageDal();

		/// <summary>
		/// Create a DAL class that implements the IZipCodeDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IZipCodeDal.</returns>
		IZipCodeDal CreateZipCodeDal();

		/// <summary>
		/// Create a DAL class that implements the IRecurrenceDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IRecurrenceDal.</returns>
		IRecurrenceDal CreateRecurrenceDal();

		#endregion

		#region -_ MessageModule _-

		/// <summary>
		/// Create a DAL class that implements the IMessageDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IMessageDal.</returns>
		IMessageDal CreateMessageDal();

		/// <summary>
		/// Create a DAL class that implements the IMessageFolderDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IMessageFolderDal.</returns>
		IMessageFolderDal CreateMessageFolderDal();

		/// <summary>
		/// Create a DAL class that implements the IMessageRecipientDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IMessageRecipientDal.</returns>
		IMessageRecipientDal CreateMessageRecipientDal();

		/// <summary>
		/// Create a DAL class that implements the IMessageStorageDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IMessageStorageDal.</returns>
		IMessageStorageDal CreateMessageStorageDal();

		#endregion

		#region -_ AgendaModule _-

		/// <summary>
		/// Create a DAL class that implements the IAgendaDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IAgendaDal.</returns>
		IAgendaDal CreateAgendaDal();

		/// <summary>
		/// Create a DAL class that implements the IAppointmentDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IAppointmentDal.</returns>
		IAppointmentDal CreateAppointmentDal();

		/// <summary>
		/// Create a DAL class that implements the IAppointmentGuestDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IAppointmentGuestDal.</returns>
		IAppointmentGuestDal CreateAppointmentGuestDal();

		/// <summary>
		/// Create a DAL class that implements the IAppointmentRecurrenceDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IAppointmentRecurrenceDal.</returns>
		IAppointmentRecurrenceDal CreateAppointmentRecurrenceDal();

		#endregion

		#region -_ TaskModule _-

		/// <summary>
		/// Create a DAL class that implements the ITaskDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ITaskDal.</returns>
		ITaskDal CreateTaskDal();

		/// <summary>
		/// Create a DAL class that implements the ITaskDescriptionDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ITaskDescriptionDal.</returns>
		ITaskDescriptionDal CreateTaskDescriptionDal();

		/// <summary>
		/// Create a DAL class that implements the ITaskRunDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ITaskRunDal.</returns>
		ITaskRunDal CreateTaskRunDal();

		/// <summary>
		/// Create a DAL class that implements the ITaskRecurrenceDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ITaskRecurrenceDal.</returns>
		ITaskRecurrenceDal CreateTaskRecurrenceDal();

		#endregion

		#region -_ TimeTableModule _-

		/// <summary>
		/// Create a DAL class that implements the ITimeTablePurposeDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ITimeTablePurposeDal.</returns>
		ITimeTablePurposeDal CreateTimeTablePurposeDal();

		/// <summary>
		/// Create a DAL class that implements the ITimeTableEntryDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ITimeTableEntryDal.</returns>
		ITimeTableEntryDal CreateTimeTableEntryDal();

		/// <summary>
		/// Create a DAL class that implements the IHolidayDefinitionDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IHolidayDefinitionDal.</returns>
		IHolidayDefinitionDal CreateHolidayDefinitionDal();

		/// <summary>
		/// Create a DAL class that implements the ITimeTableTemplateDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ITimeTableTemplateDal.</returns>
		ITimeTableTemplateDal CreateTimeTableTemplateDal();

		/// <summary>
		/// Create a DAL class that implements the ITimeTableTemplateEntryDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ITimeTableTemplateEntryDal.</returns>
		ITimeTableTemplateEntryDal CreateTimeTableTemplateEntryDal();

		#endregion

		#region -_ Holiday Module _-

		/// <summary>
		/// Create a DAL class that implements the IOvertimeEntryDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IOvertimeEntryDal.</returns>
		IOvertimeEntryDal CreateOvertimeEntryDal();

		#endregion

		/// <summary>
		/// Create a DAL class that implements the IConnectionLogDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IConnectionLogDal.</returns>
		IConnectionLogDal CreateConnectionLogDal();

		/// <summary>
		/// Create a DAL class that implements the ILoginLogDataDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ILoginLogDataDal.</returns>
		ILoginLogDataDal CreateLoginLogDal();

	}

	/// <summary>
	/// Unified broker access to Dal.
	/// </summary>
	public static class DalFactory {

		/// <summary>
		/// A Factory method that creates a class of type IDalFactory.
		/// </summary>
		/// <returns>A class of type IDalFactory.</returns>
		public static IDalFactory CreateDalFactory( Guid employeeId ) {
			// Get Dalfactory setting from ConnectionSettings or web.config.
			String dalFactory;
			if( SwmSuiteSettings.ConnectionSettings != null ) {
				dalFactory = SwmSuiteSettings.ConnectionSettings.DalFactory;
			} else {
				dalFactory = "SwmSuite.DataAccess.Sql.DalFactory,SwmSuite.DataAccess.Sql";
			}
			SwmSuiteDalPrincipal.EmployeeId = employeeId;
			return ObjectFactory.CreateObject<IDalFactory>( dalFactory );
		}
	}
}