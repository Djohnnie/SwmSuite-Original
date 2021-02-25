using SwmSuite.Data.DataObjects;

/// <summary>
/// DAL Interface for the EmployeeSettingsService methods.
/// </summary>
public interface IEmployeeSettingsDal {

	/// <summary>
	/// Get all employeesettings from the database.
	/// </summary>
	/// <returns>A EmployeeSettingsCollection containing all employeesettings.</returns>
	EmployeeSettingsDataCollection GetEmployeeSettingsData();

	/// <summary>
	/// Get employee settings for a specific employee.
	/// </summary>
	/// <param name="employeeSysId">The internal id of the employee to get the settings for.</param>
	/// <returns>An EmployeeSettingsDataCollection containing the requested settings.</returns>
	EmployeeSettingsDataCollection GetEmployeeSettingsDataForEmployee( int employeeSysId );

	/// <summary>
	/// Get a single employeesettings from the database.
	/// </summary>
	/// <param name="sysId">The internal sysid of the employeesettings to retrieve.</param>
	/// <returns>An EmployeeSettingsCollection containing the requested employeesettings.</returns>
	EmployeeSettingsDataCollection GetEmployeeSettingsDataBySysId( int sysId );

	/// <summary>
	/// Get multiple employeesettings from the database.
	/// </summary>
	/// <param name="sysIds">The internal sysids of the employeesettings to retrieve.</param>
	/// <returns>An EmployeeSettingsCollection containing the requested employeesettings.</returns>
	EmployeeSettingsDataCollection GetEmployeeSettingsDataBySysIds( int[] sysIds );

	/// <summary>
	/// Insert one or more employeesettings to the database.
	/// </summary>
	/// <param name="employeeSettingsData">An EmployeeSettingsCollection containing the employeesettings to insert.</param>
	/// <returns>An EmployeeSettingsCollection containing the inserted employeesettings.</returns>
	EmployeeSettingsDataCollection InsertEmployeeSettingsData( EmployeeSettingsDataCollection employeeSettingsData );

	/// <summary>
	/// Update one or more employeesettings in the database.
	/// </summary>
	/// <param name="employeeSettingsData">An EmployeeSettingsCollection containing the employeesettings to update.</param>
	/// <returns>An EmployeeSettingsCollection containing the updated employeesettings.</returns>
	EmployeeSettingsDataCollection UpdateEmployeeSettingsData( EmployeeSettingsDataCollection employeeSettingsData );

	/// <summary>
	/// Remove one or more employeesettings from the database.
	/// </summary>
	/// <param name="employeeSettingsData">An EmployeeSettingsCollection containing the employeesettings to remove.</param>
	void RemoveEmployeeSettingsData( EmployeeSettingsDataCollection employeeSettingsData );

	/// <summary>
	/// Remove all employeesettings from the database.
	/// </summary>
	void RemoveAllEmployeeSettingsData();

}