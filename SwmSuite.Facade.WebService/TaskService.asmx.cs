using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Business;
using System.ComponentModel;
using SwmSuite.Proxy.Interface;
using System.Web.Services.Protocols;
using SwmSuite.Framework.Exceptions;

namespace SwmSuite.Facade.WebService {

	/// <summary>
	/// Summary description for AgendaService
	/// </summary>
	[WebService( Namespace = "SimpleWorkfloorManagementSuiteNameSpace" )]
	[WebServiceBinding( ConformsTo = WsiProfiles.BasicProfile1_1 )]
	[ToolboxItem( false )]
	public class TaskService : System.Web.Services.WebService , ITaskFacade {

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the SOAP header.
		/// </summary>
		/// <value>The SOAP header.</value>
		public SwmSuiteSoapHeader SoapHeader { get; set; }

		#endregion

		/// <summary>
		/// Get all tasks for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the tasks for.</param>
		/// <param name="year">The year to get the tasks for.</param>
		/// <returns>A TaskCollection containing all tasks.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public TaskCollection GetTasksForEmployee( Employee employee , int year ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new TaskBll().GetTasksForEmployee( employee , year );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get all pending tasks for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the pending tasks for.</param>
		/// <param name="year">The year to get the tasks for.</param>
		/// <returns>A TaskCollection containing the requested tasks.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public TaskCollection GetPendingTasksForEmployee( Employee employee , int year ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new TaskBll().GetPendingTasksForEmployee( employee , year );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get all completed tasks for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the completed tasks for.</param>
		/// <param name="year">The year to get the tasks for.</param>
		/// <returns>A TaskCollection containing the requested tasks.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public TaskCollection GetCompletedTasksForEmployee( Employee employee , int year ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new TaskBll().GetCompletedTasksForEmployee( employee , year );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get all failed tasks for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the failed tasks for.</param>
		/// <param name="year">The year to get the tasks for.</param>
		/// <returns>A TaskCollection containing the requested tasks.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public TaskCollection GetFailedTasksForEmployee( Employee employee , int year ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new TaskBll().GetFailedTasksForEmployee( employee , year );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Get all overdue tasks for a specific employee.
		/// </summary>
		/// <param name="employee">The employee to get the overdue tasks for.</param>
		/// <param name="year">The year to get the tasks for.</param>
		/// <returns>A TaskCollection containing the requested tasks.</returns>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public TaskCollection GetOverDueTasksForEmployee( Employee employee , int year ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				return new TaskBll().GetOverDueTasksForEmployee( employee , year );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Create a new task.
		/// </summary>
		/// <param name="task">The task to create.</param>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public void CreateTask( Task task ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				new TaskBll().CreateTask( task );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

		/// <summary>
		/// Complete a task given the specified taskrun.
		/// </summary>
		/// <param name="taskRun">The taskrun that defines the completed task.</param>
		[WebMethod]
		[SoapHeader( "SoapHeader" )]
		public void CompleteTask( TaskRun taskRun ) {
			try {
				WebServerAuthentication.Authenticate( this.SoapHeader );
				new TaskBll().CompleteTask( taskRun );
			} catch( Exception e ) {
				throw SwmSuiteSoapExceptionHelper.WrapException( this , e );
			}
		}

	}
}
