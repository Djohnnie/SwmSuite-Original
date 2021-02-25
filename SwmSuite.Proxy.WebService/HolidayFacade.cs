using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Utils;
using System.Diagnostics;
using System.Web.Services.Protocols;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Proxy.WebService {

	public sealed class HolidayFacade :
		ServiceFacade<HolidayService.HolidayService , HolidayService.SwmSuiteSoapHeader> ,
		IHolidayFacade {

		/// <summary>
		/// Get overtime entries for one or more employees and year.
		/// </summary>
		/// <param name="employees">The employees to get the overtime entries for.</param>
		/// <param name="year">The year to get the overtime entries for.</param>
		/// <returns>An OvertimeEntryCollection containing the requested overtime entries.</returns>
		OvertimeEntryCollection IHolidayFacade.GetOvertimeEntries( EmployeeCollection employees , int year ) {
			try {
				HolidayService.Employee[] employeesParameter = new HolidayService.Employee[employees.Count];
				foreach( Employee employee in employees ) {
					employeesParameter[employees.IndexOf( employee )] =
						(HolidayService.Employee)XmlSerialization.ConvertObject( employee , typeof( Employee ) , typeof( HolidayService.Employee ) );
				}
				OvertimeEntryCollection overtimeEntries = new OvertimeEntryCollection();
				foreach( HolidayService.OvertimeEntry overtimeEntry in GetService().GetOvertimeEntries( employeesParameter , year ) ) {
					overtimeEntries.Add( (OvertimeEntry)XmlSerialization.ConvertObject( overtimeEntry , typeof( HolidayService.OvertimeEntry ) , typeof( OvertimeEntry ) ) );
				}
				return overtimeEntries;
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Create a new overtime entry.
		/// </summary>
		/// <param name="overtimeEntry">The new overtime entry to create.</param>
		/// <returns>The created overtime entry.</returns>
		OvertimeEntry IHolidayFacade.CreateOvertimeEntry( OvertimeEntry overtimeEntry ) {
			try {
				HolidayService.OvertimeEntry overtimeEntryParameter = (HolidayService.OvertimeEntry)XmlSerialization.ConvertObject( overtimeEntry , typeof( OvertimeEntry ) , typeof( HolidayService.OvertimeEntry ) );
				HolidayService.OvertimeEntry overtimeEntryResult = GetService().CreateOvertimeEntry( overtimeEntryParameter );
				return (OvertimeEntry)XmlSerialization.ConvertObject( overtimeEntryResult , typeof( HolidayService.OvertimeEntry ) , typeof( OvertimeEntry ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Update an existing overtime entry.
		/// </summary>
		/// <param name="overtimeEntry">The existing overtime entry to update.</param>
		/// <returns>The updated overtime entry.</returns>
		OvertimeEntry IHolidayFacade.UpdateOvertimeEntry( OvertimeEntry overtimeEntry ) {
			try {
				HolidayService.OvertimeEntry overtimeEntryParameter = (HolidayService.OvertimeEntry)XmlSerialization.ConvertObject( overtimeEntry , typeof( OvertimeEntry ) , typeof( HolidayService.OvertimeEntry ) );
				HolidayService.OvertimeEntry overtimeEntryResult = GetService().UpdateOvertimeEntry( overtimeEntryParameter );
				return (OvertimeEntry)XmlSerialization.ConvertObject( overtimeEntryResult , typeof( HolidayService.OvertimeEntry ) , typeof( OvertimeEntry ) );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Accept the specified overtime entry.
		/// </summary>
		/// <param name="overtimeEntry">The overtime entry to accept.</param>
		void IHolidayFacade.AcceptOvertimeEntry( OvertimeEntry overtimeEntry ) {
			try {
				HolidayService.OvertimeEntry overtimeEntryParameter = (HolidayService.OvertimeEntry)XmlSerialization.ConvertObject( overtimeEntry , typeof( OvertimeEntry ) , typeof( HolidayService.OvertimeEntry ) );
				GetService().AcceptOvertimeEntry( overtimeEntryParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

		/// <summary>
		/// Deny the specified overtime entry.
		/// </summary>
		/// <param name="overtimeEntry">The overtime entry to deny.</param>
		void IHolidayFacade.DenyOvertimeEntry( OvertimeEntry overtimeEntry ) {
			try {
				HolidayService.OvertimeEntry overtimeEntryParameter = (HolidayService.OvertimeEntry)XmlSerialization.ConvertObject( overtimeEntry , typeof( OvertimeEntry ) , typeof( HolidayService.OvertimeEntry ) );
				GetService().DenyOvertimeEntry( overtimeEntryParameter );
			} catch( SoapException e ) {
				throw SwmSuiteSoapExceptionHelper.UnwrapException( e );
			}
		}

	}

}
