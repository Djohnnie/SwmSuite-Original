using System;
using System.Collections.Generic;

using System.Windows.Forms;
using SwmSuite.Framework.Application;
using SwmSuite.Presentation.Common.MessageDialog;
using System.Diagnostics;
using SwmSuite.Data.BusinessObjects;


namespace SwmSuiteAvatarManagement {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			bool exit = false;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );

			// Check for settings file.
			if( !SwmSuiteConnectionSettings.SettingsExist( "settings.xml" ) ) {
				//splashForm.Hide();
				//// Ask user for settings.
				MessageDialog.Show( "Simple Workfloor Management Suite" , "Instellingen..." , "Er konden geen instellingen worden gevonden. Dit kan zijn omdat het de eerste keer is dat u deze applicatie opstart, of omdat u het bestand met instellingen hebt gewist." );
				//ConnectionDialog connectionDialog = new ConnectionDialog();
				//connectionDialog.ShowDialog();
				//splashForm.Show();
				//splashForm.Update();
				exit = true;
			} else {
				// Load settings.
				//Program.Settings = ConnectionSettings.Load( "settings.xml" );
				SwmSuiteSettings.ConnectionSettings = SwmSuiteConnectionSettings.Load( "settings.xml" );
				SwmSuiteSettings.ConnectionSettings.WriteToApplicationConfiguration( Application.ExecutablePath );
			}

			if( !exit ) {
				SwmSuitePrincipal.AttachAnonymousPrincipal();

				Application.Run( new MainForm() );
			}
		}
	}
}
