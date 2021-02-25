using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace SwmSuite.Data.Common {

	public class SwmSuiteNotificationMail {

		#region -_ Private Members _-



		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the email address.
		/// </summary>
		/// <value>The email address.</value>
		public String EmailAddress { get; set; }

		/// <summary>
		/// Gets or sets the SMTP server.
		/// </summary>
		/// <value>The SMTP server.</value>
		public String SmtpServer { get; set; }

		/// <summary>
		/// Gets or sets the SMTP port.
		/// </summary>
		/// <value>The SMTP port.</value>
		public int SmtpPort { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to use a secure connection.
		/// </summary>
		/// <value><c>true</c> to use a secure connection; otherwise, <c>false</c>.</value>
		public bool SecureConnection { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to use authentication.
		/// </summary>
		/// <value><c>true</c> to use authentication; otherwise, <c>false</c>.</value>
		public bool Authentication { get; set; }

		/// <summary>
		/// Gets or sets the username.
		/// </summary>
		/// <value>The username.</value>
		public String Username { get; set; }

		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		/// <value>The password.</value>
		public String Password { get; set; }

		#endregion

		#region -_ Public Events _-

		/// <summary>
		/// Occurs when the SendMailAsync methods calls back.
		/// </summary>
		public event EventHandler<SwmSuiteNotificationMailEventArgs> SendMailCallBack;

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="SwmSuiteNotificationMail"/> class.
		/// </summary>
		public SwmSuiteNotificationMail() {

		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Sends the error mail.
		/// </summary>
		public void SendErrorMail( string subject , string body , string attachmentPath ) {
			MailMessage message = CreateErrorMessage( subject , body , attachmentPath );
			CreateSmtpClient().Send( message );
		}

		/// <summary>
		/// Sends the error mail.
		/// </summary>
		public void SendErrorMailAsync( string subject , string body , string attachmentPath ) {
			SmtpClient mailClient = CreateSmtpClient();
			MailMessage mailMessage = CreateErrorMessage( subject , body , attachmentPath );
			mailClient.SendCompleted += new SendCompletedEventHandler( mailClient_SendCompleted );
			mailClient.SendAsync( mailMessage , subject );
		}

		/// <summary>
		/// Sends the mail.
		/// </summary>
		/// <param name="subject">The subject.</param>
		/// <param name="body">The body.</param>
		public void SendMail( string subject , string body ) {
			CreateSmtpClient().Send( CreateMessage( subject , body ) );
		}

		/// <summary>
		/// Sends the mail asyncroniously.
		/// </summary>
		/// <param name="subject">The subject.</param>
		/// <param name="body">The body.</param>
		public void SendMailAsync( string subject , string body ) {
			SmtpClient mailClient = CreateSmtpClient();
			MailMessage mailMessage = CreateMessage( subject , body );
			mailClient.SendCompleted += new SendCompletedEventHandler( mailClient_SendCompleted );
			mailClient.SendAsync( mailMessage , subject );
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the SendCompleted event of the mailClient control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.AsyncCompletedEventArgs"/> instance containing the event data.</param>
		void mailClient_SendCompleted( object sender , System.ComponentModel.AsyncCompletedEventArgs e ) {
			if( this.SendMailCallBack != null ) {
				if( e.Error == null ) {
					SendMailCallBack( this , new SwmSuiteNotificationMailEventArgs() );
				} else {
					SendMailCallBack( this , new SwmSuiteNotificationMailEventArgs( (string)e.UserState ) );
				}
			}
		}

		#endregion

		#region -_ Private Methods _-

		private MailMessage CreateMessage( string subject , string body ) {
			MailMessage mailMessage = new MailMessage( new MailAddress( this.EmailAddress , "SwmSuite" ) , new MailAddress( this.EmailAddress ) );
			mailMessage.IsBodyHtml = true;
			mailMessage.Subject = subject;
			mailMessage.Body = body;
			return mailMessage;
		}

		private MailMessage CreateErrorMessage( string subject , string body , string attachmentPath ) {
			MailMessage mailMessage = new MailMessage( new MailAddress( this.EmailAddress , "SwmSuite" ) , new MailAddress( this.EmailAddress ) );
			mailMessage.IsBodyHtml = true;
			mailMessage.Subject = subject;
			mailMessage.Body = body;
			mailMessage.Attachments.Add( new Attachment( attachmentPath ) );
			return mailMessage;
		}

		private SmtpClient CreateSmtpClient() {
			SmtpClient mailClient = new SmtpClient( this.SmtpServer , this.SmtpPort );
			mailClient.EnableSsl = this.SecureConnection;
			if( this.Authentication ) {
				mailClient.Credentials = new NetworkCredential( this.Username , this.Password );
			}
			return mailClient;
		}

		#endregion

	}

}
