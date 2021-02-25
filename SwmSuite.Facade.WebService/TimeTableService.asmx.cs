using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business;
using SwmSuite.Proxy.Interface;
using System.ComponentModel;
using System.Web.Services.Protocols;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Facade.WebService {

	/// <summary>
	/// Summary description for AgendaService
	/// </summary>
	[WebService( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	[WebServiceBinding( ConformsTo = WsiProfiles.BasicProfile1_1 )]
	[ToolboxItem( false )]
	public class TimeTableService : System.Web.Services.WebService , ITimeTableFacade {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the SOAP header.
		/// </summary>
		/// <value>The SOAP header.</value>
		public SwmSuiteSoapHeader SoapHeader { get; set; }

		#endregion

		/// <summary>
		/// Get all timetable purposes for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to get the timetable purposes for.</param>
		/// <returns>A TimeTablePurposeCollection containing the requested timetable purposes.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public TimeTablePurposeCollection GetTimeTablePurposesForEmployeeGroup( EmployeeGroup employeeGroup ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new TimeTablePurposeBll().GetTimeTablePurposesForEmployeeGroup( employeeGroup );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Create a new timetable purpose for a specific employeegroup.
		/// </summary>
		/// <param name="timeTablePurpose">The timetable purpose to create.</param>
		/// <param name="employeeGroup">The employeegroup to create the new timetable purpose for.</param>
		/// <returns>The created timetable purpose.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public TimeTablePurpose CreateTimeTablePurpose( TimeTablePurpose timeTablePurpose , EmployeeGroup employeeGroup ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new TimeTablePurposeBll().CreateTimeTablePurpose( timeTablePurpose , employeeGroup );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Update an existing timetable purpose for a specific employeegroup.
		/// </summary>
		/// <param name="timeTablePurpose">The timetable purpose to update.</param>
		/// <param name="employeeGroup">The new employeegroup to associate with the updated timetable purpose.</param>
		/// <returns>The updated timetable purpose.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public TimeTablePurpose UpdateTimeTablePurpose( TimeTablePurpose timeTablePurpose , EmployeeGroup employeeGroup ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new TimeTablePurposeBll().UpdateTimeTablePurpose( timeTablePurpose , employeeGroup );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Remove one or more timetable purposes.
		/// </summary>
		/// <param name="timeTablePurposes">The timetable purposes to remove.</param>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public void RemoveTimeTablePurposes( TimeTablePurposeCollection timeTablePurposes ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				new TimeTablePurposeBll().RemoveTimeTablePurposes( timeTablePurposes );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get all timetable entries for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the time table entries for.</param>
		/// <param name="begin">The begindate of the period to get the timetable entries for.</param>
		/// <param name="end">The enddate of the period to get the timetable entries for.</param>
		/// <returns>A TimeTableEntryCollection containing the requested timetable entries.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public TimeTableEntryCollection GetTimeTableEntries( Employee employee , DateTime begin , DateTime end ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new TimeTableEntryBll().GetTimeTableEntries( employee , begin , end );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Create a new timetable entry.
		/// </summary>
		/// <param name="timeTableEntry">The timetable entry to create.</param>
		/// <returns>The created timetable entry.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public TimeTableEntry CreateTimeTableEntry( TimeTableEntry timeTableEntry ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new TimeTableEntryBll().CreateTimeTableEntry( timeTableEntry );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Update an existing timetable entry.
		/// </summary>
		/// <param name="timeTableEntry">The timetable entry to update.</param>
		/// <returns>The updated timetable entry.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public TimeTableEntry UpdateTimeTableEntry( TimeTableEntry timeTableEntry ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new TimeTableEntryBll().UpdateTimeTableEntry( timeTableEntry );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Remove one or more timetable entries.
		/// </summary>
		/// <param name="timeTableEntries">A collection of timetable entries to remove.</param>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public void RemoveTimeTableEntries( TimeTableEntryCollection timeTableEntries ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				new TimeTableEntryBll().RemoveTimeTableEntries( timeTableEntries );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Gets the time table template.
		/// </summary>
		/// <param name="timeTableTemplateSysId">The time table template sys id.</param>
		/// <returns></returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public TimeTableTemplate GetTimeTableTemplate( int timeTableTemplateSysId ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new TimeTableTemplateBll().GetTimeTableTemplate( timeTableTemplateSysId );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get all timetable purposes for a specific employeegroup.
		/// </summary>
		/// <param name="employeeGroup">The employeegroup to get the timetable purposes for.</param>
		/// <returns>A TimeTableTemplateCollection containing the requested timetable purposes.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public TimeTableTemplateCollection GetTimeTableTemplatesForEmployeeGroup( EmployeeGroup employeeGroup ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new TimeTableTemplateBll().GetTimeTableTemplatesForEmployeeGroup( employeeGroup );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Create a new timetable purpose for a specific employeegroup.
		/// </summary>
		/// <param name="timeTableTemplate">The timetable purpose to create.</param>
		/// <param name="employeeGroup">The employeegroup to create the new timetable purpose for.</param>
		/// <returns>The created timetable purpose.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public TimeTableTemplate CreateTimeTableTemplate( TimeTableTemplate timeTableTemplate , EmployeeGroup employeeGroup ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new TimeTableTemplateBll().CreateTimeTableTemplate( timeTableTemplate , employeeGroup );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Update an existing timetable purpose for a specific employeegroup.
		/// </summary>
		/// <param name="timeTableTemplate">The timetable purpose to update.</param>
		/// <param name="employeeGroup">The new employeegroup to associate with the updated timetable purpose.</param>
		/// <returns>The updated timetable purpose.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public TimeTableTemplate UpdateTimeTableTemplate( TimeTableTemplate timeTableTemplate , EmployeeGroup employeeGroup ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new TimeTableTemplateBll().UpdateTimeTableTemplate( timeTableTemplate , employeeGroup );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Remove one or more timetable purposes.
		/// </summary>
		/// <param name="timeTableTemplates">The timetable purposes to remove.</param>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public void RemoveTimeTableTemplates( TimeTableTemplateCollection timeTableTemplates ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				new TimeTableTemplateBll().RemoveTimeTableTemplates( timeTableTemplates );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get all timetable entries for a specific employee.
		/// </summary>
		/// <param name="timeTableTemplate">The employee to get the time table entries for.</param>
		/// <returns>A TimeTableTemplateEntryCollection containing the requested timetable entries.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public TimeTableTemplateEntryCollection GetTimeTableTemplateEntries( TimeTableTemplate timeTableTemplate ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new TimeTableTemplateEntryBll().GetTimeTableTemplateEntries( timeTableTemplate );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Create a new timetable entry.
		/// </summary>
		/// <param name="timeTableTemplateEntry">The timetable entry to create.</param>
		/// <param name="timeTableTemplate">The time table template to add this entry to.</param>
		/// <returns>The created timetable entry.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public TimeTableTemplateEntry CreateTimeTableTemplateEntry( TimeTableTemplateEntry timeTableTemplateEntry , TimeTableTemplate timeTableTemplate ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new TimeTableTemplateEntryBll().CreateTimeTableTemplateEntry( timeTableTemplateEntry , timeTableTemplate );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Update an existing timetable entry.
		/// </summary>
		/// <param name="timeTableTemplateEntry">The timetable entry to update.</param>
		/// <returns>The updated timetable entry.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public TimeTableTemplateEntry UpdateTimeTableTemplateEntry( TimeTableTemplateEntry timeTableTemplateEntry ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new TimeTableTemplateEntryBll().UpdateTimeTableTemplateEntry( timeTableTemplateEntry );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Remove one or more timetable entries.
		/// </summary>
		/// <param name="timeTableTemplateEntries">A collection of timetable entries to remove.</param>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public void RemoveTimeTableTemplateEntries( TimeTableTemplateEntryCollection timeTableTemplateEntries ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				new TimeTableTemplateEntryBll().RemoveTimeTableTemplateEntries( timeTableTemplateEntries );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}
	}
}