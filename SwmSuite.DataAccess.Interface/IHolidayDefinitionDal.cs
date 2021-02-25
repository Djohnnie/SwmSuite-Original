using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.DataObjects;

namespace SwmSuite.DataAccess.Interface {
	
	public interface IHolidayDefinitionDal {

		/// <summary>
		/// Get all holidaydefinitions from the database.
		/// </summary>
		/// <returns>A HolidayDefinitionCollection containing all holidaydefinitions.</returns>
		HolidayDefinitionDataCollection GetHolidayDefinitionData();

		/// <summary>
		/// Get all holidaydefinitions from the database for a given year.
		/// </summary>
		/// <returns>An HolidayDefinitionCollection containing all requested holidaydefinitions.</returns>
		HolidayDefinitionDataCollection GetHolidayDefinitionDataByYear( int year );

		/// <summary>
		/// Get a single holidaydefinition from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the holidaydefinition to retrieve.</param>
		/// <returns>An HolidayDefinitionCollection containing the requested holidaydefinition.</returns>
		HolidayDefinitionDataCollection GetHolidayDefinitionDataBySysId( int sysId );

		/// <summary>
		/// Get multiple holidaydefinitions from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the holidaydefinitions to retrieve.</param>
		/// <returns>An HolidayDefinitionCollection containing the requested holidaydefinitions.</returns>
		HolidayDefinitionDataCollection GetHolidayDefinitionDataBySysIds( int[] sysIds );

		/// <summary>
		/// Insert one or more holidaydefinitions to the database.
		/// </summary>
		/// <param name="holidaydefinitions">An HolidayDefinitionCollection containing the holidaydefinitions to insert.</param>
		/// <returns>An HolidayDefinitionCollection containing the inserted holidaydefinitions.</returns>
		HolidayDefinitionDataCollection InsertHolidayDefinitionData( HolidayDefinitionDataCollection holidaydefinitions );

		/// <summary>
		/// Update one or more holidaydefinitions in the database.
		/// </summary>
		/// <param name="holidaydefinitions">An HolidayDefinitionCollection containing the holidaydefinitions to update.</param>
		/// <returns>An HolidayDefinitionCollection containing the updated holidaydefinitions.</returns>
		HolidayDefinitionDataCollection UpdateHolidayDefinitionData( HolidayDefinitionDataCollection holidaydefinitions );

		/// <summary>
		/// Remove one or more holidaydefinitions from the database.
		/// </summary>
		/// <param name="holidaydefinitions">An HolidayDefinitionCollection containing the holidaydefinitions to remove.</param>
		void RemoveHolidayDefinitionData( HolidayDefinitionDataCollection holidaydefinitions );

		/// <summary>
		/// Remove all holidaydefinitions from the database.
		/// </summary>
		void RemoveAllHolidayDefinitionData();

	}

}
