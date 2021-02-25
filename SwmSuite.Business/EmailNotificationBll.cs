using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Data.Common;
using System.Windows.Forms;

namespace SwmSuite.Business {
	
	public class EmailNotificationBll {

		public static void SendEmailNotification( EmployeeSettings employeeSettings , SwmSuite.Data.BusinessObjects.Message message ) {
			if( employeeSettings != null && message != null ) {
				String subject = "SwmSuite: u hebt een nieuw bericht ontvangen.";
				String title = "U hebt een bericht ontvangen van " + message.Sender.FullName;
				RichTextBox rtb = new RichTextBox();
				rtb.Rtf = message.Contents;
				String contents = rtb.Text;
				SendEmailNotification( employeeSettings , subject , title , contents );
			}
		}

		public static void SendEmailNotification( EmployeeSettings employeeSettings , String subject , String title , String message ){
			if( employeeSettings.EmailNotification ) {
				SwmSuiteNotificationMail notificationMail = new SwmSuiteNotificationMail();
				notificationMail.EmailAddress = employeeSettings.EmailAddress;
				notificationMail.SmtpServer = employeeSettings.SmtpServer;
				notificationMail.SmtpPort = employeeSettings.SmtpPort.HasValue ? employeeSettings.SmtpPort.Value : 25;
				notificationMail.SecureConnection = employeeSettings.SecureConnection;
				notificationMail.Authentication = employeeSettings.Authentication;
				notificationMail.Username = employeeSettings.Username;
				notificationMail.Password = employeeSettings.Password;

				StringBuilder messageBuilder = new StringBuilder();
				messageBuilder.Append( "<html>" );
				messageBuilder.Append( "<head>" );
				messageBuilder.Append( "<style type=\"text/css\">");
				messageBuilder.Append( "h1 { font-family: Verdana; size: 24; color: blue }");
				messageBuilder.Append( "h2 { font-family: Verdana; size: 16; color: blue }" );
				messageBuilder.Append( "p { font-family: Verdana; size: 12; color: black }");
				messageBuilder.Append( "</style>" );
				messageBuilder.Append( "</head>" );
				messageBuilder.Append( "<body>" );
				messageBuilder.Append( "<h1>Simple Workfloor Management Suite</h1>" );
				messageBuilder.Append( "<div>" + message + "</div>" );
				messageBuilder.Append( "</body>" );
				messageBuilder.Append( "</html>" );

				notificationMail.SendMailAsync( subject , messageBuilder.ToString() );
			}
		}

	}

}
