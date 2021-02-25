using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.DataAccess.Interface;
using SwmSuite.Data.DataObjects;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business.DataMapping;

namespace SwmSuite.Business {

	public class HolidayDefinitionBll {

		#region -_ Private Members _-

		private IHolidayDefinitionDal dal = DalFactory.CreateDalFactory( SwmSuitePrincipal.GetUserId() ).CreateHolidayDefinitionDal();

		#endregion

		#region -_ Business Methods _-

		public HolidayDefinitionCollection GetHolidayDefinitions( int year ) {
			return new HolidayDefinitionCollection();
		}

		/// <summary>
		/// Create a new holiday definition.
		/// </summary>
		/// <param name="holidayDefinition">The holiday definition to create.</param>
		/// <returns>The created holiday definition.</returns>
		public HolidayDefinition CreateHolidayDefinition( HolidayDefinition holidayDefinition ) {
			HolidayDefinitionData holidayDefinitionDataToCreate =
				HolidayDefinitionMapping.FromBusinessObject( holidayDefinition );
			HolidayDefinitionDataCollection holidayDefinitionDataResult =
				this.InsertHolidayDefinitionData( HolidayDefinitionDataCollection.FromSingleHolidayDefinition( holidayDefinitionDataToCreate ) );
			return HolidayDefinitionMapping.FromDataObject( holidayDefinitionDataResult[0] );
		}

		/// <summary>
		/// Update an existing holiday definition.
		/// </summary>
		/// <param name="holidayDefinition">The holiday definition to update.</param>
		/// <returns>The updated holiday definition.</returns>
		public HolidayDefinition UpdateHolidayDefinition( HolidayDefinition holidayDefinition ) {
			HolidayDefinitionData holidayDefinitionDataToCreate =
				HolidayDefinitionMapping.FromBusinessObject( holidayDefinition );
			HolidayDefinitionDataCollection holidayDefinitionDataResult =
				this.UpdateHolidayDefinitionData( HolidayDefinitionDataCollection.FromSingleHolidayDefinition( holidayDefinitionDataToCreate ) );
			return HolidayDefinitionMapping.FromDataObject( holidayDefinitionDataResult[0] );
		}

		#endregion

		#region -_ CRUD Methods _-

		/// <summary>
		/// Get all holidaydefinitions from the database.
		/// </summary>
		/// <returns>An HolidayDefinitionCollection containing all holidaydefinitions.</returns>
		public HolidayDefinitionDataCollection GetHolidayDefinitionData() {
			return dal.GetHolidayDefinitionData();
		}

		/// <summary>
		/// Get all holidaydefinitions from the database for a given year.
		/// </summary>
		/// <returns>An HolidayDefinitionCollection containing all requested holidaydefinitions.</returns>
		public HolidayDefinitionDataCollection GetHolidayDefinitionDataByYear( int year ) {
			return dal.GetHolidayDefinitionDataByYear( year );
		}

		/// <summary>
		/// Get a single holidaydefinition from the database.
		/// </summary>
		/// <param name="sysId">The internal sysid of the holidaydefinition to retrieve.</param>
		/// <returns>An HolidayDefinitionCollection containing the requested holidaydefinition.</returns>
		public HolidayDefinitionDataCollection GetHolidayDefinitionDataBySysId( int sysId ) {
			return dal.GetHolidayDefinitionDataBySysId( sysId );
		}

		/// <summary>
		/// Get multiple holidaydefinitions from the database.
		/// </summary>
		/// <param name="sysIds">The internal sysids of the holidaydefinitions to retrieve.</param>
		/// <returns>An HolidayDefinitionCollection containing the requested holidaydefinitions.</returns>
		public HolidayDefinitionDataCollection GetHolidayDefinitionDataBySysIds( int[] sysIds ) {
			return dal.GetHolidayDefinitionDataBySysIds( sysIds );
		}

		/// <summary>
		/// Insert one or more holidaydefinitions to the database.
		/// </summary>
		/// <param name="holidaydefinitions">An HolidayDefinitionCollection containing the holidaydefinitions to insert.</param>
		/// <returns>An HolidayDefinitionCollection containing the inserted holidaydefinitions.</returns>
		public HolidayDefinitionDataCollection InsertHolidayDefinitionData( HolidayDefinitionDataCollection holidayDefinitionData ) {
			return dal.InsertHolidayDefinitionData( holidayDefinitionData );
		}

		/// <summary>
		/// Update one or more holidaydefinitions in the database.
		/// </summary>
		/// <param name="holidaydefinitions">An HolidayDefinitionCollection containing the holidaydefinitions to update.</param>
		/// <returns>An HolidayDefinitionCollection containing the updated holidaydefinitions.</returns>
		public HolidayDefinitionDataCollection UpdateHolidayDefinitionData( HolidayDefinitionDataCollection holidayDefinitionData ) {
			return dal.UpdateHolidayDefinitionData( holidayDefinitionData );
		}

		/// <summary>
		/// Remove one or more holidaydefinitions from the database.
		/// </summary>
		/// <param name="holidaydefinitions">An HolidayDefinitionCollection containing the holidaydefinitions to remove.</param>
		public void RemoveHolidayDefinitionData( HolidayDefinitionDataCollection holidayDefinitionData ) {
			dal.RemoveHolidayDefinitionData( holidayDefinitionData );
		}

		/// <summary>
		/// Remove all holidaydefinitions from the database.
		/// </summary>
		public void RemoveAllHolidayDefinitionData() {
			dal.RemoveAllHolidayDefinitionData();
		}

		#endregion

	}

}
