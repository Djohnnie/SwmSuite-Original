using System;
using System.Collections.Generic;

using System.Windows.Forms;
using SimpleWorkfloorManagementSuite.SwmSuiteAdminWizard;
using System.Threading;
using SwmSuite.Framework.Application;
using SwmSuite.Presentation.Common.MessageDialog;
using System.Diagnostics;
using SwmSuite.Presentation.ConnectionWizard;
using SimpleWorkfloorManagementSuite.Dialogs;
using SwmSuite.Proxy.Interface;
using SwmSuite.Data.BusinessObjects;
using System.Net;
using System.Data.SqlClient;

namespace SimpleWorkfloorManagementSuite {
	static class Program {
		public static SwmSuiteSettings Settings { get; set; }

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			bool exit = false;

			// Enable visual styles for the application.
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );

			if( SystemInformation.PrimaryMonitorSize.Width < 1024 || SystemInformation.PrimaryMonitorSize.Height < 768 ) {
				ScreenResolutionWarningDialog.ShowScreenResolutionWarningDialog();
			}

			Thread.CurrentThread.Name = "Main";
			Application.ThreadException += new ThreadExceptionEventHandler( Application_ThreadException );
			//AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler( CurrentDomain_UnhandledException );

			// Show the splashform during initialization.
			SplashForm splashForm = new SplashForm();
			splashForm.Show();
			splashForm.Update();

			// Check for settings file.
			if( !SwmSuiteConnectionSettings.SettingsExist( "settings.xml" ) ) {
				//splashForm.Hide();
				//// Ask user for settings.
				SwmSuiteSettings.ConnectionSettings = new SwmSuiteConnectionSettings();
				splashForm.Close();
				splashForm.Dispose();
				MessageDialog.Show( "Simple Workfloor Management Suite" , "Instellingen..." , "Er konden geen instellingen worden gevonden. Dit kan zijn omdat het de eerste keer is dat u deze applicatie opstart, of omdat u het bestand met instellingen hebt gewist." );
				ConnectionDialog connectionDialog = new ConnectionDialog();
				if( connectionDialog.ShowDialog() == DialogResult.OK ) {
					Application.Restart();
				}
				exit = true;
			} else {
				// Load settings.
				//Program.Settings = ConnectionSettings.Load( "settings.xml" );
				SwmSuiteSettings.ConnectionSettings = SwmSuiteConnectionSettings.Load( "settings.xml" );
				SwmSuiteSettings.ConnectionSettings.WriteToApplicationConfiguration( Application.ExecutablePath );
			}

			if( !exit ) {
				// Test connection
				if( SwmSuiteFacade.ConnectionTestFacade.CheckConnection() ) {
					// Log connection.
					ConnectionLog connectionLog = new ConnectionLog();
					connectionLog.DateTime = DateTime.Now;
					connectionLog.Client = Dns.GetHostName();
					SwmSuiteFacade.LoggingFacade.LogConnection( connectionLog );

					SwmSuitePrincipal.AttachAnonymousPrincipal();

					SwmSuiteLogOnProblems problems = SwmSuiteLogOn.Go();
					//problems = SwmSuiteLogOnProblems.NoEmployees;

					splashForm.Close();
					splashForm.Dispose();

					switch( problems ) {
						case SwmSuiteLogOnProblems.NoEmployees: {
								SwmSuiteAdminWizardForm adminWizardForm = new SwmSuiteAdminWizardForm();
								if( adminWizardForm.ShowDialog() == DialogResult.OK ) {

								} else {

								}
								break;
							}
						case SwmSuiteLogOnProblems.Other: {
								MessageBox.Show( "Ander probleem!" );
								break;
							}
						default: {

								break;
							}
					}

					Application.Run( new LogOnForm() );
				} else {
					ErrorDialog.ShowErrorDialog( "Simple Workfloor Management Suite kan geen connectie maken met de door u opgegeven server. Controleer uw server-instellingen." );
					ConnectionDialog connectionDialog = new ConnectionDialog();
					if( connectionDialog.ShowDialog() == DialogResult.OK ) {
						Application.Restart();
					}
				}
			}
		}

		//static void CurrentDomain_UnhandledException( object sender , UnhandledExceptionEventArgs e ) {
		//  switch( ExceptionDialog.Show( (Exception)e.ExceptionObject ) ) {
		//    case ExceptionDialogResult.Continue: {
		//        break;
		//      }
		//    case ExceptionDialogResult.Exit: {
		//        Application.Exit();
		//        break;
		//      }
		//    case ExceptionDialogResult.Restart: {
		//        Application.Restart();
		//        break;
		//      }
		//    case ExceptionDialogResult.Details: {
		//        break;
		//      }
		//  }
		//}

		static void Application_ThreadException( object sender , ThreadExceptionEventArgs e ) {
			if( e.Exception is SqlException || e.Exception is WebException ) {
				ErrorDialog.ShowErrorDialog( "SwmSuite kan geen verbinding meer met de server maken en wordt afgesloten. Start SwmSuite opnieuw op als u nog eens wilt proberen." );
				Application.Exit();
			} else {
				switch( ExceptionDialog.Show( e.Exception ) ) {
					case ExceptionDialogResult.Continue: {
							break;
						}
					case ExceptionDialogResult.Exit: {
							Application.ExitThread();
							Application.Exit();
							break;
						}
					case ExceptionDialogResult.Restart: {
							Application.ExitThread();
							Application.Restart();
							break;
						}
					case ExceptionDialogResult.Details: {
							break;
						}
				}
			}
		}
	}
}