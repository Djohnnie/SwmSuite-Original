using System;
using System.Collections.Generic;

using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.DataAccess.NHibernate;

namespace SwmSuite.DataAccess.NHibernate {

	/// <summary>
	/// Factory class for other Dal classes.
	/// </summary>
	public class DalFactory : IDalFactory {

		/// <summary>
		/// Create a DAL class that implements the IConnectionTestDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IConnectionTestDal.</returns>
		public IConnectionTestDal CreateConnectionTestDal() {
			//return new ConnectionTestDal();
			return null;
		}

		/// <summary>
		/// Create a DAL class that implements the IUserDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IUserDal.</returns>
		public IUserDal CreateUserDal() {
			return null;
		}

		/// <summary>
		/// Create a class of type IEmployeeDal.
		/// </summary>
		/// <returns>A class of type IEmployeeDal.</returns>
		public IEmployeeDal CreateEmployeeDal() {
			//return new EmployeeDal();
			return null;
		}

		/// <summary>
		/// Create a DAL class that implements the IEmployeeSettingsDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IEmployeeSettingsDal.</returns>
		public IEmployeeSettingsDal CreateEmployeeSettingsDal() {
			//return new EmployeeSettingsDal();
			return null;
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
			//return new LogDeleteDal();
			return null;
		}

		/// <summary>
		/// Create a DAL class that implements the IAlertDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IAlertDal.</returns>
		public IAlertDal CreateAlertDal() {
			//return new AlertDal();
			return null;
		}

		/// <summary>
		/// Create a DAL class that implements the IEmployeeAlertDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IEmployeeAlertDal.</returns>
		public IEmployeeAlertDal CreateEmployeeAlertDal() {
			//return new EmployeeAlertDal();
			return null;
		}

		/// <summary>
		/// Create a DAL class that implements the IEmployeeGroupAlertDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IEmployeeGroupAlertDal.</returns>
		public IEmployeeGroupAlertDal CreateEmployeeGroupAlertDal() {
			//return new EmployeeGroupAlertDal();
			return null;
		}

		/// <summary>
		/// Create a DAL class that implements the ICountryDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ICountryDal.</returns>
		public ICountryDal CreateCountryDal() {
			//return new CountryDal();
			return null;
		}

		/// <summary>
		/// Create a DAL class that implements the IImageDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IImageDal.</returns>
		public IAvatarDal CreateImageDal() {
			//return new ImageDal();
			return null;
		}

		/// <summary>
		/// Create a DAL class that implements the IZipCodeDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IZipCodeDal.</returns>
		public IZipCodeDal CreateZipCodeDal() {
			// return new ZipCodeDal();
			return null;
		}

		/// <summary>
		/// Create a DAL class that implements the IRecurrenceDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IRecurrenceDal.</returns>
		public IRecurrenceDal CreateRecurrenceDal() {
			// return new RecurrenceDal();
			return null;
		}

		#region -_ MessageModule _-

		/// <summary>
		/// Create a DAL class that implements the IMessageDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IMessageDal.</returns>
		public IMessageDal CreateMessageDal() {
			return null;
		}

		/// <summary>
		/// Create a DAL class that implements the IMessageFolderDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IMessageFolderDal.</returns>
		public IMessageFolderDal CreateMessageFolderDal() {
			return null;
		}

		/// <summary>
		/// Create a DAL class that implements the IMessageRecipientDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IMessageRecipientDal.</returns>
		public IMessageRecipientDal CreateMessageRecipientDal() {
			return null;
		}

		/// <summary>
		/// Create a DAL class that implements the IMessageStorageDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IMessageStorageDal.</returns>
		public IMessageStorageDal CreateMessageStorageDal() {
			return null;
		}

		#endregion

		#region -_ AgendaModule _-

		/// <summary>
		/// Create a DAL class that implements the IAgendaDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IAgendaDal.</returns>
		public IAgendaDal CreateAgendaDal() {
			return null;
		}

		/// <summary>
		/// Create a DAL class that implements the IAppointmentDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IAppointmentDal.</returns>
		public IAppointmentDal CreateAppointmentDal() {
			return null;
		}

		/// <summary>
		/// Create a DAL class that implements the IAppointmentGuestDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IAppointmentGuestDal.</returns>
		public IAppointmentGuestDal CreateAppointmentGuestDal() {
			return null;
		}

		/// <summary>
		/// Create a DAL class that implements the IAppointmentRecurrenceDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IAppointmentRecurrenceDal.</returns>
		public IAppointmentRecurrenceDal CreateAppointmentRecurrenceDal() {
			//return new AppointmentRecurrenceDal();
			return null;
		}

		#endregion

		#region -_ TaskModule _-

		/// <summary>
		/// Create a DAL class that implements the ITaskDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ITaskDal.</returns>
		public ITaskDal CreateTaskDal() {
			return null;
		}

		/// <summary>
		/// Create a DAL class that implements the ITaskDescriptionDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ITaskDescriptionDal.</returns>
		public ITaskDescriptionDal CreateTaskDescriptionDal() {
			return null;
		}

		/// <summary>
		/// Create a DAL class that implements the ITaskRunDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ITaskRunDal.</returns>
		public ITaskRunDal CreateTaskRunDal() {
			return null;
		}

		/// <summary>
		/// Create a DAL class that implements the ITaskRecurrenceDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ITaskRecurrenceDal.</returns>
		public ITaskRecurrenceDal CreateTaskRecurrenceDal() {
			//return new TaskRecurrenceDal();
			return null;
		}

		#endregion

		#region -_ TimeTableModule _-

		/// <summary>
		/// Create a DAL class that implements the ITimeTablePurposeDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ITimeTablePurposeDal.</returns>
		public ITimeTablePurposeDal CreateTimeTablePurposeDal() {
			//return new TimeTablePurposeDal();
			return null;
		}

		/// <summary>
		/// Create a DAL class that implements the ITimeTableEntryDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ITimeTableEntryDal.</returns>
		public ITimeTableEntryDal CreateTimeTableEntryDal() {
			//return new TimeTableEntryDal();
			return null;
		}

		/// <summary>
		/// Create a DAL class that implements the IHolidayDefinitionDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IHolidayDefinitionDal.</returns>
		public IHolidayDefinitionDal CreateHolidayDefinitionDal() {
			//return new HolidayDefinitionDal();
			return null;
		}

		/// <summary>
		/// Create a DAL class that implements the ITimeTableTemplateDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ITimeTableTemplateDal.</returns>
		public ITimeTableTemplateDal CreateTimeTableTemplateDal() {
			//return new TimeTableTemplateDal();
			return null;
		}

		/// <summary>
		/// Create a DAL class that implements the ITimeTableTemplateEntryDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ITimeTableTemplateEntryDal.</returns>
		public ITimeTableTemplateEntryDal CreateTimeTableTemplateEntryDal() {
			//return new TimeTableTemplateEntryDal();
			return null;
		}

		#endregion

		#region -_ Holiday Module _-

		/// <summary>
		/// Create a DAL class that implements the IOvertimeEntryDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IOvertimeEntryDal.</returns>
		public IOvertimeEntryDal CreateOvertimeEntryDal() {
			//return new OvertimeEntryDal();
			return null;
		}

		#endregion

		/// <summary>
		/// Create a DAL class that implements the IConnectionLogDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type IConnectionLogDal.</returns>
		public IConnectionLogDal CreateConnectionLogDal() {
			//return new ConnectionLogDal();
			return null;
		}

		/// <summary>
		/// Create a DAL class that implements the ILoginLogDataDal interface for access to the database.
		/// </summary>
		/// <returns>A class of type ILoginLogDataDal.</returns>
		public ILoginLogDataDal CreateLoginLogDal() {
			//return new LoginLogDataDal();
			return null;
		}

	}

}
