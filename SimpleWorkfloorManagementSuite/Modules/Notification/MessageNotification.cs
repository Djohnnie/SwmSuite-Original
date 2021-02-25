using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Proxy.Interface;
using System.Globalization;
using System.Drawing.Text;

namespace SimpleWorkfloorManagementSuite.Modules.Notification {

	public partial class MessageNotification : UserControl {

		#region -_ Private Members _-

		private bool _hovered;

		private string _titleString;

		private string _dataString;

		private string _countString;

		private int _currentMessage;

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the scheme.
		/// </summary>
		/// <value>The scheme.</value>
		public NotificationScheme Scheme { get; set; }

		/// <summary>
		/// Gets or sets the loading text.
		/// </summary>
		/// <value>The loading text.</value>
		public String LoadingText { get; set; }

		/// <summary>
		/// Gets or sets the message data.
		/// </summary>
		/// <value>The message data.</value>
		public MessageCollection MessageData { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="MessageNotification"/> class.
		/// </summary>
		public MessageNotification() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );

			this.Scheme = new NotificationScheme();
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Initialize this notification control.
		/// </summary>
		public void Initialize() {
			backgroundWorker.RunWorkerAsync( SwmSuitePrincipal.CurrentEmployee );
		}

		#endregion

		#region -_ Private Methods _-

		private void SetDataString(){
			_dataString = "Afzender: " + this.MessageData[_currentMessage].Sender.FullName + "\nOnderwerp: " + this.MessageData[_currentMessage].Subject;
			_countString = ( (int)_currentMessage + 1 ).ToString( CultureInfo.CurrentCulture ) + "/" + this.MessageData.Count.ToString( CultureInfo.CurrentCulture );
		}

		private void DrawCount( Graphics surface , Rectangle bounds , String text ) {
			//StringFormat loadingTextFormat = new StringFormat() { Alignment = StringAlignment.Far , LineAlignment = StringAlignment.Near };
			//SolidBrush loadingTextBrush = new SolidBrush( this.Scheme.TitleColor );
			surface.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			//surface.DrawString( text , this.Scheme.MainTextFont , loadingTextBrush , bounds , loadingTextFormat );
			TextRenderer.DrawText( surface , text , this.Scheme.MainTextFont , bounds , this.Scheme.TitleColor , TextFormatFlags.Right | TextFormatFlags.Top );
			surface.TextRenderingHint = TextRenderingHint.SystemDefault;
			//loadingTextBrush.Dispose();
			//loadingTextFormat.Dispose();
		}

		private void DrawTitle( Graphics surface , Rectangle bounds , String text ) {
			//StringFormat loadingTextFormat = new StringFormat() { Alignment = StringAlignment.Center , LineAlignment = StringAlignment.Near };
			//SolidBrush loadingTextBrush = new SolidBrush( this.Scheme.TitleColor );
			surface.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			//surface.DrawString( text , this.Scheme.TitleFont , loadingTextBrush , bounds , loadingTextFormat );
			TextRenderer.DrawText( surface , text , this.Scheme.TitleFont , bounds , this.Scheme.TitleColor , TextFormatFlags.HorizontalCenter | TextFormatFlags.Top );
			surface.TextRenderingHint = TextRenderingHint.SystemDefault;
			//loadingTextBrush.Dispose();
			//loadingTextFormat.Dispose();
		}

		private void DrawData( Graphics surface , Rectangle bounds , String text ) {
			//StringFormat loadingTextFormat = new StringFormat() { Alignment = StringAlignment.Near , LineAlignment = StringAlignment.Near };
			//SolidBrush loadingTextBrush = new SolidBrush( this.Scheme.MainTextColor );
			surface.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			//surface.DrawString( text , this.Scheme.MainTextFont , loadingTextBrush , bounds , loadingTextFormat );
			TextRenderer.DrawText( surface , text , this.Scheme.MainTextFont , bounds , this.Scheme.MainTextColor , TextFormatFlags.Left | TextFormatFlags.Top );
			surface.TextRenderingHint = TextRenderingHint.SystemDefault;
			//loadingTextBrush.Dispose();
			//loadingTextFormat.Dispose();
		}

		#endregion

		#region -_ Event Handlers _-

		private void MessageNotification_Paint( object sender , PaintEventArgs e ) {
			NotificationDrawer.DrawBackground(
				e.Graphics ,
				this.ClientRectangle ,
				this.Scheme ,
				_hovered );
			// If there is no data, display the loading text.
			if( this.MessageData == null || this.MessageData.Count == 0 ) {
				NotificationDrawer.DrawLoadingText(
					e.Graphics ,
					this.ClientRectangle ,
					this.LoadingText ,
					this.Scheme );
			} else {
				Rectangle titleRectangle = new Rectangle(
					this.ClientRectangle.Left + 10 ,
					this.ClientRectangle.Top + 10 ,
					this.ClientRectangle.Width - 21 ,
					this.ClientRectangle.Height - 21 );
				Rectangle countRectangle = new Rectangle(
					this.ClientRectangle.Left + 10 ,
					this.ClientRectangle.Top + 40 ,
					50 ,
					this.ClientRectangle.Height - 51 );
				Rectangle dataRectangle = new Rectangle(
					this.ClientRectangle.Left + 70 ,
					this.ClientRectangle.Top + 40 ,
					this.ClientRectangle.Width - 21 ,
					this.ClientRectangle.Height - 61 );
				DrawTitle(
					e.Graphics ,
					titleRectangle ,
					_titleString );
				DrawCount(
					e.Graphics ,
					countRectangle ,
					_countString );
				DrawData(
					e.Graphics ,
					dataRectangle ,
					_dataString );
			}
		}

		private void MessageNotification_MouseEnter( object sender , EventArgs e ) {
			_hovered = true;
			this.Invalidate();
		}

		private void MessageNotification_MouseLeave( object sender , EventArgs e ) {
			_hovered = false;
			this.Invalidate();
		}

		/// <summary>
		/// Handles the DoWork event of the backgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
		private void backgroundWorker_DoWork( object sender , DoWorkEventArgs e ) {
			MessageCollection messagesToReturn = new MessageCollection();
			Employee employee = (Employee)e.Argument;
			MessageFolderCollection messageFolders = 
				SwmSuiteFacade.MessageFacade.GetRootMessageFolders( employee );
			foreach( MessageFolder messageFolder in messageFolders ) {
				if( messageFolder.SpecialFolder == SwmSuite.Data.Common.MessageSpecialFolder.Inbox ) {
					MessageCollection messages = 
						SwmSuiteFacade.MessageFacade.GetMessagesForMessageFolder( messageFolder );
					foreach( SwmSuite.Data.BusinessObjects.Message message in messages ) {
						if( message.IsNew ) {
							messagesToReturn.Add( message );
						}
					}
				}
			}
			e.Result = messagesToReturn;
		}

		/// <summary>
		/// Handles the RunWorkerCompleted event of the backgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
		private void backgroundWorker_RunWorkerCompleted( object sender , RunWorkerCompletedEventArgs e ) {
			this.MessageData = (MessageCollection)e.Result;
			if( this.MessageData.Count > 0 ) {
				_titleString = "U hebt " + this.MessageData.Count.ToString( CultureInfo.CurrentCulture ) + " nieuwe berichten.";
				_currentMessage = 0;
				SetDataString();
				displayTimer.Enabled = true;
			} else {
				this.LoadingText = "U heeft geen nieuwe berichten.";
			}
			Invalidate();
		}

		/// <summary>
		/// Handles the Tick event of the displayTimer control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void displayTimer_Tick( object sender , EventArgs e ) {
			_currentMessage++;
			if( _currentMessage == this.MessageData.Count ) {
				_currentMessage = 0;
			}
			SetDataString();
			Invalidate();
		}

		#endregion

	}

}
