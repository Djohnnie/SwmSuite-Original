using System;
using System.Collections.Generic;
using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.DataAccess.Sql;

namespace SwmSuite.DataAccess.Sql {
	/// <summary>
	/// Factory class for other Dal classes.
	/// </summary>
	public sealed class DalFactory : IDalFactory {

		#region -_ Main _-

		/// <summary>
		/// Create a DAL class that implements the IUserDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IUserDal.</returns>
		public IUserDal CreateUserDal() {
			return new UserDal();
		}

		/// <summary>
		/// Create a DAL class that implements the IConnectionTestDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IConnectionTestDal.</returns>
		public IConnectionTestDal CreateConnectionTestDal() {
			return new ConnectionTestDal();
		}

		/// <summary>
		/// Create a class of type IEmployeeDal.
		/// </summary>
		/// <returns>A class of type IEmployeeDal.</returns>
		public IEmployeeDal CreateEmployeeDal() {
			return new EmployeeDal();
		}

		/// <summary>
		/// Create a DAL class that implements the IEmployeeSettingsDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IEmployeeSettingsDal.</returns>
		public IEmployeeSettingsDal CreateEmployeeSettingsDal() {
			return new EmployeeSettingsDal();
		}

		/// <summary>
		/// Create a DAL class that implements the IEmployeeGroupDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IEmployeeGroupDal.</returns>
		public IEmployeeGroupDal CreateEmployeeGroupDal() {
			return new EmployeeGroupDal();
		}

		/// <summary>
		/// Create a DAL class that implements the ILogDeleteDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ILogDeleteDal.</returns>
		public ILogDeleteDal CreateLogDeleteDal() {
			return new LogDeleteDal();
		}

		/// <summary>
		/// Create a DAL class that implements the IAlertDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IAlertDal.</returns>
		public IAlertDal CreateAlertDal() {
			return new AlertDal();
		}

		/// <summary>
		/// Create a DAL class that implements the IEmployeeAlertDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IEmployeeAlertDal.</returns>
		public IEmployeeAlertDal CreateEmployeeAlertDal() {
			return new EmployeeAlertDal();
		}

		/// <summary>
		/// Create a DAL class that implements the IEmployeeGroupAlertDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IEmployeeGroupAlertDal.</returns>
		public IEmployeeGroupAlertDal CreateEmployeeGroupAlertDal() {
			return new EmployeeGroupAlertDal();
		}

		/// <summary>
		/// Create a DAL class that implements the ICountryDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ICountryDal.</returns>
		public ICountryDal CreateCountryDal() {
			return new CountryDal();
		}

		/// <summary>
		/// Create a DAL class that implements the IImageDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IImageDal.</returns>
		public IAvatarDal CreateImageDal() {
			return new AvatarDal();
		}

		/// <summary>
		/// Create a DAL class that implements the IZipCodeDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IZipCodeDal.</returns>
		public IZipCodeDal CreateZipCodeDal() {
			return new ZipCodeDal();
		}

		/// <summary>
		/// Create a DAL class that implements the IRecurrenceDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IRecurrenceDal.</returns>
		public IRecurrenceDal CreateRecurrenceDal() {
			return new RecurrenceDal();
		}

		#endregion

		#region -_ MessageModule _-

		/// <summary>
		/// Create a DAL class that implements the IMessageDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IMessageDal.</returns>
		public IMessageDal CreateMessageDal() {
			return new MessageDal();
		}

		/// <summary>
		/// Create a DAL class that implements the IMessageFolderDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IMessageFolderDal.</returns>
		public IMessageFolderDal CreateMessageFolderDal() {
			return new MessageFolderDal();
		}

		/// <summary>
		/// Create a DAL class that implements the IMessageRecipientDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IMessageRecipientDal.</returns>
		public IMessageRecipientDal CreateMessageRecipientDal() {
			return new MessageRecipientDal();
		}

		/// <summary>
		/// Create a DAL class that implements the IMessageStorageDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IMessageStorageDal.</returns>
		public IMessageStorageDal CreateMessageStorageDal() {
			return new MessageStorageDal();
		}

		#endregion

		#region -_ AgendaModule _-

		/// <summary>
		/// Create a DAL class that implements the IAgendaDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IAgendaDal.</returns>
		public IAgendaDal CreateAgendaDal() {
			return new AgendaDal();
		}

		/// <summary>
		/// Create a DAL class that implements the IAppointmentDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IAppointmentDal.</returns>
		public IAppointmentDal CreateAppointmentDal() {
			return new AppointmentDal();
		}

		/// <summary>
		/// Create a DAL class that implements the IAppointmentGuestDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IAppointmentGuestDal.</returns>
		public IAppointmentGuestDal CreateAppointmentGuestDal() {
			return new AppointmentGuestDal();
		}

		/// <summary>
		/// Create a DAL class that implements the IAppointmentRecurrenceDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IAppointmentRecurrenceDal.</returns>
		public IAppointmentRecurrenceDal CreateAppointmentRecurrenceDal() {
			return new AppointmentRecurrenceDal();
		}

		#endregion

		#region -_ TaskModule _-

		/// <summary>
		/// Create a DAL class that implements the ITaskDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ITaskDal.</returns>
		public ITaskDal CreateTaskDal() {
			return new TaskDal();
		}

		/// <summary>
		/// Create a DAL class that implements the ITaskDescriptionDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ITaskDescriptionDal.</returns>
		public ITaskDescriptionDal CreateTaskDescriptionDal() {
			return new TaskDescriptionDal();
		}

		/// <summary>
		/// Create a DAL class that implements the ITaskRunDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ITaskRunDal.</returns>
		public ITaskRunDal CreateTaskRunDal() {
			return new TaskRunDal();
		}

		/// <summary>
		/// Create a DAL class that implements the ITaskRecurrenceDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ITaskRecurrenceDal.</returns>
		public ITaskRecurrenceDal CreateTaskRecurrenceDal() {
			return new TaskRecurrenceDal();
		}

		#endregion

		#region -_ TimeTableModule _-

		/// <summary>
		/// Create a DAL class that implements the ITimeTablePurposeDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ITimeTablePurposeDal.</returns>
		public ITimeTablePurposeDal CreateTimeTablePurposeDal() {
			return new TimeTablePurposeDal();
		}

		/// <summary>
		/// Create a DAL class that implements the ITimeTableEntryDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ITimeTableEntryDal.</returns>
		public ITimeTableEntryDal CreateTimeTableEntryDal() {
			return new TimeTableEntryDal();
		}

		/// <summary>
		/// Create a DAL class that implements the IHolidayDefinitionDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IHolidayDefinitionDal.</returns>
		public IHolidayDefinitionDal CreateHolidayDefinitionDal() {
			return new HolidayDefinitionDal();
		}

		/// <summary>
		/// Create a DAL class that implements the ITimeTableTemplateDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ITimeTableTemplateDal.</returns>
		public ITimeTableTemplateDal CreateTimeTableTemplateDal() {
			return new TimeTableTemplateDal();
		}

		/// <summary>
		/// Create a DAL class that implements the ITimeTableTemplateEntryDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ITimeTableTemplateEntryDal.</returns>
		public ITimeTableTemplateEntryDal CreateTimeTableTemplateEntryDal() {
			return new TimeTableTemplateEntryDal();
		}

		#endregion

		#region -_ Holiday Module _-

		/// <summary>
		/// Create a DAL class that implements the IOvertimeEntryDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IOvertimeEntryDal.</returns>
		public IOvertimeEntryDal CreateOvertimeEntryDal() {
			return new OvertimeEntryDal();
		}

		#endregion

		/// <summary>
		/// Create a DAL class that implements the IConnectionLogDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IConnectionLogDal.</returns>
		public IConnectionLogDal CreateConnectionLogDal() {
			return new ConnectionLogDal();
		}

		/// <summary>
		/// Create a DAL class that implements the ILoginLogDataDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ILoginLogDataDal.</returns>
		public ILoginLogDataDal CreateLoginLogDal() {
			return new LoginLogDataDal();
		}

	}
}