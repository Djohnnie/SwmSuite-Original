using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;
using SwmSuite.Business;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwmSuite.Framework.Application;

namespace SwmSuite.Business.UnitTest {
	
	public static class UnitTestUtils {

		#region -_ Private Members _-

		private static ConnectionLogBll _connectionLogBll = new ConnectionLogBll();
		private static LoginLogBll _loginLogBll = new LoginLogBll();

		private static TaskBll _taskBll = new TaskBll();
		private static TaskRecurrenceBll _taskRecurrenceBll = new TaskRecurrenceBll();
		private static TaskRunBll _taskRunBll = new TaskRunBll();
		private static TaskDescriptionBll _taskDescriptionBll = new TaskDescriptionBll();

		private static AppointmentGuestBll _appointmentGuestBll = new AppointmentGuestBll();
		private static AppointmentBll _appointmentBll = new AppointmentBll();
		private static AgendaBll _agendaBll = new AgendaBll();

		private static MessageStorageBll _messageStorageBll = new MessageStorageBll();
		private static MessageRecipientBll _messageRecipientBll = new MessageRecipientBll();
		private static MessageFolderBll _messageFolderBll = new MessageFolderBll();
		private static MessageBll _messageBll = new MessageBll();

		private static TimeTableEntryBll _timeTableEntryBll = new TimeTableEntryBll();
		private static TimeTableTemplateBll _timeTableTemplateBll = new TimeTableTemplateBll();
		private static TimeTableTemplateEntryBll _timeTableTemplateEntryBll = new TimeTableTemplateEntryBll();
		private static TimeTablePurposeBll _timeTablePurposeBll = new TimeTablePurposeBll();

		private static OvertimeEntryBll _overtimeEntryBll = new OvertimeEntryBll();

		private static AvatarBll _avatarBll = new AvatarBll();
		private static ZipCodeBll _zipCodeBll = new ZipCodeBll();
		private static CountryBll _countryBll = new CountryBll();
		private static EmployeeSettingsBll _employeeSettingsBll = new EmployeeSettingsBll();
		private static EmployeeAlertBll _employeeAlertBll = new EmployeeAlertBll();
		private static EmployeeGroupAlertBll _employeeGroupAlertBll = new EmployeeGroupAlertBll();
		private static AlertBll _alertBll = new AlertBll();
		private static EmployeeBll _employeeBll = new EmployeeBll();
		private static EmployeeGroupBll _employeeGroupBll = new EmployeeGroupBll();
		private static LogDeleteBll _logDeleteBll = new LogDeleteBll();

		#endregion

		#region -_ Public Methods _-

		public static Guid CreateMembershipTestData( string name , string password ) {
			return Guid.Empty;
		}

		public static void ClearDatabase() {
			_connectionLogBll.RemoveAllConnectionLogData();
			Assert.AreEqual( 0 , _connectionLogBll.GetConnectionLogData().Count , "RemoveAllConnectionLogData did not remove all rows!" );
			_loginLogBll.RemoveAllLoginLogData();
			Assert.AreEqual( 0 , _loginLogBll.GetLoginLogData().Count , "RemoveAllLoginLogData did not remove all rows!" );

			// Clear TaskModule tables.
			_taskRecurrenceBll.RemoveAllTaskRecurrenceData();
			Assert.AreEqual( 0 , _taskRecurrenceBll.GetTaskRecurrenceData().Count , "RemoveAllTaskRecurrences did not remove all rows!" );
			_taskRunBll.RemoveAllTaskRunData();
			Assert.AreEqual( 0 , _taskRunBll.GetTaskRunData().Count , "RemoveAllTaskRuns did not remove all rows!" );
			_taskBll.RemoveAllTaskData();
			Assert.AreEqual( 0 , _taskBll.GetTaskData().Count , "RemoveAllTasks did not remove all rows!" );
			_taskDescriptionBll.RemoveAllTaskDescriptionData();
			Assert.AreEqual( 0 , _taskDescriptionBll.GetTaskDescriptionData().Count , "RemoveAllTaskDescriptions did not remove all rows!" );
			
			// Clear AgendaModule tables.
			_appointmentGuestBll.RemoveAllAppointmentGuestData();
			Assert.AreEqual( 0 , _appointmentGuestBll.GetAppointmentGuestData().Count , "RemoveAllAppointmentGuests did not remove all rows!" );
			_appointmentBll.RemoveAllAppointmentData();
			Assert.AreEqual( 0 , _appointmentBll.GetAppointmentData().Count , "RemoveAllAppointments did not remove all rows!" );
			_agendaBll.RemoveAllAgendaData();
			Assert.AreEqual( 0 , _agendaBll.GetAgendaData().Count , "RemoveAllAgendas did not remove all rows!" );

			// Clear MessageModule tables.
			_messageStorageBll.RemoveAllMessageStorageData();
			Assert.AreEqual( 0 , _messageStorageBll.GetMessageStorageData().Count , "RemoveAllMessageStorages did not remove all rows!" );
			_messageRecipientBll.RemoveAllMessageRecipientData();
			Assert.AreEqual( 0 , _messageRecipientBll.GetMessageRecipientData().Count , "RemoveAllMessageRecipients did not remove all rows!" );
			_messageFolderBll.RemoveAllMessageFolderData();
			Assert.AreEqual( 0 , _messageFolderBll.GetMessageFolderData().Count , "RemoveAllMessageFolders did not remove all rows!" );
			_messageBll.RemoveAllMessageData();
			Assert.AreEqual( 0 , _messageBll.GetMessageData().Count , "RemoveAllMessages did not remove all rows!" );
			
			// Clear TimeTable tables.
			_timeTableEntryBll.RemoveAllTimeTableEntryDataCollection();
			Assert.AreEqual( 0 , _timeTableEntryBll.GetTimeTableEntryDataCollection().Count , "RemoveAllTimeTableEntryDataCollection did not remove all rows!" );
			_timeTableTemplateEntryBll.RemoveAllTimeTableTemplateEntryData();
			Assert.AreEqual( 0 , _timeTableTemplateEntryBll.GetTimeTableTemplateEntryData().Count , "RemoveAllTimeTableTemplateEntryData did not remove all rows" );
			_timeTableTemplateBll.RemoveAllTimeTableTemplateData();
			Assert.AreEqual( 0 , _timeTableTemplateBll.GetTimeTableTemplateData().Count , "RemoveAllTimeTableTemplateData did not remove all rows!" );
			_timeTablePurposeBll.RemoveAllTimeTablePurposeDataCollection();
			Assert.AreEqual( 0 , _timeTablePurposeBll.GetTimeTablePurposeDataCollection().Count , "RemoveAllTimeTablePurposeDataCollection did not remove all rows!" );

			// Clear Holiday tables.
			_overtimeEntryBll.RemoveAllOvertimeEntryData();
			Assert.AreEqual( 0 , _overtimeEntryBll.GetOvertimeEntryData().Count , "RemoveAllOvertimeEntryData did not remove all rows!" );

			// Remove Core Tables.
			_avatarBll.RemoveAllAvatarData();
			Assert.AreEqual( 0 , _avatarBll.GetAvatarData().Count , "RemoveAllAvatarData did not remove all rows!" );
			_zipCodeBll.RemoveAllZipCodeData();
			Assert.AreEqual( 0 , _zipCodeBll.GetZipCodeData().Count , "RemoveAllZipCodes did not remove all rows!" );
			_countryBll.RemoveAllCountryData();
			Assert.AreEqual( 0 , _countryBll.GetCountryData().Count , "RemoveAllCountries did not remove all rows!" );
			_employeeAlertBll.RemoveAllEmployeeAlertData();
			Assert.AreEqual( 0 , _employeeAlertBll.GetEmployeeAlertData().Count , "RemoveAllEmployeeAlerts did not remove all rows!" );
			_employeeGroupAlertBll.RemoveAllEmployeeGroupAlerts();
			Assert.AreEqual( 0 , _employeeGroupAlertBll.GetEmployeeGroupAlerts().Count , "RemoveAllEmployeeGroupAlerts did not remove all rows!" );
			_alertBll.RemoveAllAlertData();
			Assert.AreEqual( 0 , _alertBll.GetAlertData().Count , "RemoveAllAlerts did not remove all rows!" );
			_employeeSettingsBll.RemoveAllEmployeeSettingsData();
			Assert.AreEqual( 0 , _employeeSettingsBll.GetEmployeeSettingsData().Count , "RemoveAllEmployeeSettingsData did not remove all rows!" );
			_employeeBll.RemoveAllEmployeeData();
			Assert.AreEqual( 0 , _employeeBll.GetEmployeeData().Count , "RemoveAllEmployees did not remove all rows!" );
			_employeeGroupBll.RemoveAllEmployeeGroupData();
			Assert.AreEqual( 0 , _employeeGroupBll.GetEmployeeGroupData().Count , "RemoveAllEmployeeGroups did not remove all rows!" );
			_logDeleteBll.RemoveAllLogDeleteData();
			Assert.AreEqual( 0 , _logDeleteBll.GetLogDeleteData().Count , "RemoveAllLogDeletes did not remove all rows!" );
		}

		#endregion

	}

}
