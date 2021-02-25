using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Utils;
using System.Web.Services.Protocols;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Proxy.WebService {

	public sealed class TimeTableFacade :
		ServiceFacade<TimeTableService.TimeTableService , TimeTableService.SwmSuiteSoapHeader> ,
		ITimeTableFacade {

		/// <summary>
		/// Get all timetable purposes for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to get the timetable purposes for.</param>
		/// <returns>A TimeTablePurposeCollection containing the requested timetable purposes.</returns>
		TimeTablePurposeCollection ITimeTableFacade.GetTimeTablePurposesForEmployeeGroup( EmployeeGroup employeeGroup ) {
			try {
				TimeTableService.EmployeeGroup employeeGroupParameter =
				(TimeTableService.EmployeeGroup)XmlSerialization.ConvertObject( employeeGroup , typeof( EmployeeGroup ) , typeof( TimeTableService.EmployeeGroup ) );
				TimeTablePurposeCollection timeTablePurposes = new TimeTablePurposeCollection();
				foreach( TimeTableService.TimeTablePurpose timeTablePurpose in GetService().GetTimeTablePurposesForEmployeeGroup( employeeGroupParameter ) ) {
					timeTablePurposes.Add(
						(TimeTablePurpose)XmlSerialization.ConvertObject( timeTablePurpose , typeof( TimeTableService.TimeTablePurpose ) , typeof( TimeTablePurpose ) ) );
				}
				return timeTablePurposes;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Create a new timetable purpose for a specific employeegroup.
		/// </summary>
		/// <param name="timeTablePurpose">The timetable purpose to create.</param>
		/// <param name="employeeGroup">The employeegroup to create the new timetable purpose for.</param>
		/// <returns>The created timetable purpose.</returns>
		TimeTablePurpose ITimeTableFacade.CreateTimeTablePurpose( TimeTablePurpose timeTablePurpose , EmployeeGroup employeeGroup ) {
			try {
				TimeTableService.TimeTablePurpose timeTablePurposeParameter =
				(TimeTableService.TimeTablePurpose)XmlSerialization.ConvertObject( timeTablePurpose , typeof( TimeTablePurpose ) , typeof( TimeTableService.TimeTablePurpose ) );
				TimeTableService.EmployeeGroup employeeGroupParameter =
					(TimeTableService.EmployeeGroup)XmlSerialization.ConvertObject( employeeGroup , typeof( EmployeeGroup ) , typeof( TimeTableService.EmployeeGroup ) );
				TimeTableService.TimeTablePurpose timeTablePurposeToReturn =
					GetService().CreateTimeTablePurpose( timeTablePurposeParameter , employeeGroupParameter );
				return (TimeTablePurpose)XmlSerialization.ConvertObject( timeTablePurposeToReturn , typeof( TimeTableService.TimeTablePurpose ) , typeof( TimeTablePurpose ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Update an existing timetable purpose for a specific employeegroup.
		/// </summary>
		/// <param name="timeTablePurpose">The timetable purpose to update.</param>
		/// <param name="employeeGroup">The new employeegroup to associate with the updated timetable purpose.</param>
		/// <returns>The updated timetable purpose.</returns>
		TimeTablePurpose ITimeTableFacade.UpdateTimeTablePurpose( TimeTablePurpose timeTablePurpose , EmployeeGroup employeeGroup ) {
			try {
				TimeTableService.TimeTablePurpose timeTablePurposeParameter =
				(TimeTableService.TimeTablePurpose)XmlSerialization.ConvertObject( timeTablePurpose , typeof( TimeTablePurpose ) , typeof( TimeTableService.TimeTablePurpose ) );
				TimeTableService.EmployeeGroup employeeGroupParameter =
					(TimeTableService.EmployeeGroup)XmlSerialization.ConvertObject( employeeGroup , typeof( EmployeeGroup ) , typeof( TimeTableService.EmployeeGroup ) );
				TimeTableService.TimeTablePurpose timeTablePurposeToReturn =
					GetService().UpdateTimeTablePurpose( timeTablePurposeParameter , employeeGroupParameter );
				return (TimeTablePurpose)XmlSerialization.ConvertObject( timeTablePurposeToReturn , typeof( TimeTableService.TimeTablePurpose ) , typeof( TimeTablePurpose ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Remove one or more timetable purposes.
		/// </summary>
		/// <param name="timeTablePurposes">The timetable purposes to remove.</param>
		void ITimeTableFacade.RemoveTimeTablePurposes( TimeTablePurposeCollection timeTablePurposes ) {
			try {
				TimeTableService.TimeTablePurpose[] timeTablePurposesParameter = new TimeTableService.TimeTablePurpose[timeTablePurposes.Count];
				foreach( TimeTablePurpose timeTableEntry in timeTablePurposes ) {
					timeTablePurposesParameter[timeTablePurposes.IndexOf( timeTableEntry )] =
						(TimeTableService.TimeTablePurpose)XmlSerialization.ConvertObject( timeTableEntry , typeof( TimeTablePurpose ) , typeof( TimeTableService.TimeTablePurpose ) );
				}
				GetService().RemoveTimeTablePurposes( timeTablePurposesParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get all timetable entries for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the time table entries for.</param>
		/// <param name="begin">The begindate of the period to get the timetable entries for.</param>
		/// <param name="end">The enddate of the period to get the timetable entries for.</param>
		/// <returns>A TimeTableEntryCollection containing the requested timetable entries.</returns>
		TimeTableEntryCollection ITimeTableFacade.GetTimeTableEntries( Employee employee , DateTime begin , DateTime end ) {
			try {
				TimeTableService.Employee employeeParameter =
				(TimeTableService.Employee)XmlSerialization.ConvertObject( employee , typeof( Employee ) , typeof( TimeTableService.Employee ) );
				TimeTableEntryCollection timeTableEntriesToReturn = new TimeTableEntryCollection();
				foreach( TimeTableService.TimeTableEntry timeTableEntry in GetService().GetTimeTableEntries( employeeParameter , begin , end ) ) {
					timeTableEntriesToReturn.Add(
						(TimeTableEntry)XmlSerialization.ConvertObject( timeTableEntry , typeof( TimeTableService.TimeTableEntry ) , typeof( TimeTableEntry ) ) );
				}
				return timeTableEntriesToReturn;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Create a new timetable entry.
		/// </summary>
		/// <param name="timeTableEntry">The timetable entry to create.</param>
		/// <returns>The created timetable entry.</returns>
		TimeTableEntry ITimeTableFacade.CreateTimeTableEntry( TimeTableEntry timeTableEntry ) {
			try {
				TimeTableService.TimeTableEntry timeTableEntryParameter =
				(TimeTableService.TimeTableEntry)XmlSerialization.ConvertObject( timeTableEntry , typeof( TimeTableEntry ) , typeof( TimeTableService.TimeTableEntry ) );
				TimeTableService.TimeTableEntry timeTableEntryResult =
					GetService().CreateTimeTableEntry( timeTableEntryParameter );
				return (TimeTableEntry)XmlSerialization.ConvertObject( timeTableEntryResult , typeof( TimeTableService.TimeTableEntry ) , typeof( TimeTableEntry ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Update an existing timetable entry.
		/// </summary>
		/// <param name="timeTableEntry">The timetable entry to update.</param>
		/// <returns>The updated timetable entry.</returns>
		TimeTableEntry ITimeTableFacade.UpdateTimeTableEntry( TimeTableEntry timeTableEntry ) {
			try {
				TimeTableService.TimeTableEntry timeTableEntryParameter =
				(TimeTableService.TimeTableEntry)XmlSerialization.ConvertObject( timeTableEntry , typeof( TimeTableEntry ) , typeof( TimeTableService.TimeTableEntry ) );
				TimeTableService.TimeTableEntry timeTableEntryResult =
					GetService().UpdateTimeTableEntry( timeTableEntryParameter );
				return (TimeTableEntry)XmlSerialization.ConvertObject( timeTableEntryResult , typeof( TimeTableService.TimeTableEntry ) , typeof( TimeTableEntry ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Remove one or more timetable entries.
		/// </summary>
		/// <param name="timeTableEntries">A collection of timetable entries to remove.</param>
		void ITimeTableFacade.RemoveTimeTableEntries( TimeTableEntryCollection timeTableEntries ) {
			try {
				TimeTableService.TimeTableEntry[] timeTableEntriesParameter = new TimeTableService.TimeTableEntry[timeTableEntries.Count];
				foreach( TimeTableEntry timeTableEntry in timeTableEntries ) {
					timeTableEntriesParameter[timeTableEntries.IndexOf( timeTableEntry )] =
						(TimeTableService.TimeTableEntry)XmlSerialization.ConvertObject( timeTableEntry , typeof( TimeTableEntry ) , typeof( TimeTableService.TimeTableEntry ) );
				}
				GetService().RemoveTimeTableEntries( timeTableEntriesParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Gets the time table template.
		/// </summary>
		/// <param name="timeTableTemplateSysId">The time table template sys id.</param>
		/// <returns></returns>
		TimeTableTemplate ITimeTableFacade.GetTimeTableTemplate( int timeTableTemplateSysId ) {
			try {
				return (TimeTableTemplate)XmlSerialization.ConvertObject( GetService().GetTimeTableTemplate( timeTableTemplateSysId ) , typeof( TimeTableService.TimeTableTemplate ) , typeof( TimeTableTemplate ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get all timetable purposes for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to get the timetable purposes for.</param>
		/// <returns>A TimeTableTemplateCollection containing the requested timetable purposes.</returns>
		TimeTableTemplateCollection ITimeTableFacade.GetTimeTableTemplatesForEmployeeGroup( EmployeeGroup employeeGroup ) {
			try {
				TimeTableService.EmployeeGroup employeeGroupParameter =
				(TimeTableService.EmployeeGroup)XmlSerialization.ConvertObject( employeeGroup , typeof( EmployeeGroup ) , typeof( TimeTableService.EmployeeGroup ) );
				TimeTableTemplateCollection timeTableTemplates = new TimeTableTemplateCollection();
				foreach( TimeTableService.TimeTableTemplate timeTableTemplate in GetService().GetTimeTableTemplatesForEmployeeGroup( employeeGroupParameter ) ) {
					timeTableTemplates.Add(
						(TimeTableTemplate)XmlSerialization.ConvertObject( timeTableTemplate , typeof( TimeTableService.TimeTableTemplate ) , typeof( TimeTableTemplate ) ) );
				}
				return timeTableTemplates;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Create a new timetable purpose for a specific employeegroup.
		/// </summary>
		/// <param name="timeTableTemplate">The timetable purpose to create.</param>
		/// <param name="employeeGroup">The employeegroup to create the new timetable purpose for.</param>
		/// <returns>The created timetable purpose.</returns>
		TimeTableTemplate ITimeTableFacade.CreateTimeTableTemplate( TimeTableTemplate timeTableTemplate , EmployeeGroup employeeGroup ) {
			try {
				TimeTableService.TimeTableTemplate timeTableTemplateParameter =
				(TimeTableService.TimeTableTemplate)XmlSerialization.ConvertObject( timeTableTemplate , typeof( TimeTableTemplate ) , typeof( TimeTableService.TimeTableTemplate ) );
				TimeTableService.EmployeeGroup employeeGroupParameter =
					(TimeTableService.EmployeeGroup)XmlSerialization.ConvertObject( employeeGroup , typeof( EmployeeGroup ) , typeof( TimeTableService.EmployeeGroup ) );
				TimeTableService.TimeTableTemplate timeTableTemplateToReturn =
					GetService().CreateTimeTableTemplate( timeTableTemplateParameter , employeeGroupParameter );
				return (TimeTableTemplate)XmlSerialization.ConvertObject( timeTableTemplateToReturn , typeof( TimeTableService.TimeTableTemplate ) , typeof( TimeTableTemplate ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Update an existing timetable purpose for a specific employeegroup.
		/// </summary>
		/// <param name="timeTableTemplate">The timetable purpose to update.</param>
		/// <param name="employeeGroup">The new employeegroup to associate with the updated timetable purpose.</param>
		/// <returns>The updated timetable purpose.</returns>
		TimeTableTemplate ITimeTableFacade.UpdateTimeTableTemplate( TimeTableTemplate timeTableTemplate , EmployeeGroup employeeGroup ) {
			try {
				TimeTableService.TimeTableTemplate timeTableTemplateParameter =
				(TimeTableService.TimeTableTemplate)XmlSerialization.ConvertObject( timeTableTemplate , typeof( TimeTableTemplate ) , typeof( TimeTableService.TimeTableTemplate ) );
				TimeTableService.EmployeeGroup employeeGroupParameter =
					(TimeTableService.EmployeeGroup)XmlSerialization.ConvertObject( employeeGroup , typeof( EmployeeGroup ) , typeof( TimeTableService.EmployeeGroup ) );
				TimeTableService.TimeTableTemplate timeTableTemplateToReturn =
					GetService().UpdateTimeTableTemplate( timeTableTemplateParameter , employeeGroupParameter );
				return (TimeTableTemplate)XmlSerialization.ConvertObject( timeTableTemplateToReturn , typeof( TimeTableService.TimeTableTemplate ) , typeof( TimeTableTemplate ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Remove one or more timetable purposes.
		/// </summary>
		/// <param name="timeTableTemplates">The timetable purposes to remove.</param>
		void ITimeTableFacade.RemoveTimeTableTemplates( TimeTableTemplateCollection timeTableTemplates ) {
			try {
				TimeTableService.TimeTableTemplate[] timeTableTemplatesParameter = new TimeTableService.TimeTableTemplate[timeTableTemplates.Count];
				foreach( TimeTableTemplate timeTableEntry in timeTableTemplates ) {
					timeTableTemplatesParameter[timeTableTemplates.IndexOf( timeTableEntry )] =
						(TimeTableService.TimeTableTemplate)XmlSerialization.ConvertObject( timeTableEntry , typeof( TimeTableTemplate ) , typeof( TimeTableService.TimeTableTemplate ) );
				}
				GetService().RemoveTimeTableTemplates( timeTableTemplatesParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Get all timetable entries for a specific employee.
		/// </summary>
		/// <param name="timeTableTemplate">The employee to get the time table entries for.</param>
		/// <returns>A TimeTableTemplateEntryCollection containing the requested timetable entries.</returns>
		TimeTableTemplateEntryCollection ITimeTableFacade.GetTimeTableTemplateEntries( TimeTableTemplate timeTableTemplate) {
			try {
				TimeTableService.TimeTableTemplate timeTableTemplateParameter =
				(TimeTableService.TimeTableTemplate)XmlSerialization.ConvertObject( timeTableTemplate , typeof( TimeTableTemplate ) , typeof( TimeTableService.TimeTableTemplate ) );
				TimeTableTemplateEntryCollection timeTableTemplateEntriesToReturn = new TimeTableTemplateEntryCollection();
				foreach( TimeTableService.TimeTableTemplateEntry timeTableTemplateEntry in GetService().GetTimeTableTemplateEntries( timeTableTemplateParameter ) ) {
					timeTableTemplateEntriesToReturn.Add(
						(TimeTableTemplateEntry)XmlSerialization.ConvertObject( timeTableTemplateEntry , typeof( TimeTableService.TimeTableTemplateEntry ) , typeof( TimeTableTemplateEntry ) ) );
				}
				return timeTableTemplateEntriesToReturn;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Create a new timetable entry.
		/// </summary>
		/// <param name="timeTableTemplateEntry">The timetable entry to create.</param>
		/// <param name="timeTableTemplate">The time table template to add this entry to.</param>
		/// <returns>The created timetable entry.</returns>
		TimeTableTemplateEntry ITimeTableFacade.CreateTimeTableTemplateEntry( TimeTableTemplateEntry timeTableTemplateEntry , TimeTableTemplate timeTableTemplate ) {
			try {
				TimeTableService.TimeTableTemplateEntry timeTableTemplateEntryParameter =
				(TimeTableService.TimeTableTemplateEntry)XmlSerialization.ConvertObject( timeTableTemplateEntry , typeof( TimeTableTemplateEntry ) , typeof( TimeTableService.TimeTableTemplateEntry ) );
				TimeTableService.TimeTableTemplate timeTableTemplateParameter =
				(TimeTableService.TimeTableTemplate)XmlSerialization.ConvertObject( timeTableTemplate , typeof( TimeTableTemplate ) , typeof( TimeTableService.TimeTableTemplate ) );
				TimeTableService.TimeTableTemplateEntry timeTableTemplateEntryResult =
					GetService().CreateTimeTableTemplateEntry( timeTableTemplateEntryParameter , timeTableTemplateParameter );
				return (TimeTableTemplateEntry)XmlSerialization.ConvertObject( timeTableTemplateEntryResult , typeof( TimeTableService.TimeTableTemplateEntry ) , typeof( TimeTableTemplateEntry ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Update an existing timetable entry.
		/// </summary>
		/// <param name="timeTableTemplateEntry">The timetable entry to update.</param>
		/// <returns>The updated timetable entry.</returns>
		TimeTableTemplateEntry ITimeTableFacade.UpdateTimeTableTemplateEntry( TimeTableTemplateEntry timeTableTemplateEntry ) {
			try {
				TimeTableService.TimeTableTemplateEntry timeTableTemplateEntryParameter =
				(TimeTableService.TimeTableTemplateEntry)XmlSerialization.ConvertObject( timeTableTemplateEntry , typeof( TimeTableTemplateEntry ) , typeof( TimeTableService.TimeTableTemplateEntry ) );
				TimeTableService.TimeTableTemplateEntry timeTableTemplateEntryResult =
					GetService().UpdateTimeTableTemplateEntry( timeTableTemplateEntryParameter );
				return (TimeTableTemplateEntry)XmlSerialization.ConvertObject( timeTableTemplateEntryResult , typeof( TimeTableService.TimeTableTemplateEntry ) , typeof( TimeTableTemplateEntry ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Remove one or more timetable entries.
		/// </summary>
		/// <param name="timeTableTemplateEntries">A collection of timetable entries to remove.</param>
		void ITimeTableFacade.RemoveTimeTableTemplateEntries( TimeTableTemplateEntryCollection timeTableTemplateEntries ) {
			try {
				TimeTableService.TimeTableTemplateEntry[] timeTableTemplateEntriesParameter = new TimeTableService.TimeTableTemplateEntry[timeTableTemplateEntries.Count];
				foreach( TimeTableTemplateEntry timeTableTemplateEntry in timeTableTemplateEntries ) {
					timeTableTemplateEntriesParameter[timeTableTemplateEntries.IndexOf( timeTableTemplateEntry )] =
						(TimeTableService.TimeTableTemplateEntry)XmlSerialization.ConvertObject( timeTableTemplateEntry , typeof( TimeTableTemplateEntry ) , typeof( TimeTableService.TimeTableTemplateEntry ) );
				}
				GetService().RemoveTimeTableTemplateEntries( timeTableTemplateEntriesParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

	}

}
