using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.BusinessObjects;

using System.Drawing.Text;
using SwmSuite.Proxy.Interface;
using System.Globalization;

namespace SimpleWorkfloorManagementSuite.Modules.Notification {
	
	public partial class TimeTableNotification : UserControl {
		
		#region -_ Private Members _-

		private bool _hovered;

		private string _titleString;

		private string _dataString;

		private string _countString;

		private int _currentTimeTableEntry;

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
		/// Gets or sets the timetable data.
		/// </summary>
		/// <value>The agenda data.</value>
		public TimeTableEntryCollection TimeTableData { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeTableNotification"/> class.
		/// </summary>
		public TimeTableNotification() {
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

		private void SetDataString() {
			_dataString = "Van " + this.TimeTableData[_currentTimeTableEntry].From.ToShortTimeString() + " tot " + this.TimeTableData[_currentTimeTableEntry].To.ToShortTimeString() + "\n" + this.TimeTableData[_currentTimeTableEntry].TimeTablePurpose.Description;
			_countString = ( (int)_currentTimeTableEntry + 1 ).ToString( CultureInfo.CurrentCulture ) + "/" + this.TimeTableData.Count.ToString( CultureInfo.CurrentCulture );
		}

		private void DrawCount( Graphics surface , Rectangle bounds , String text ) {
			//StringFormat loadingTextFormat = new StringFormat() { Alignment = StringAlignment.Far , LineAlignment = StringAlignment.Near };
			//SolidBrush loadingTextBrush = new SolidBrush( this.Scheme.TitleColor );
			surface.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			//surface.DrawString( text , this.Scheme.MainTextFont , loadingTextBrush , bounds , loadingTextFormat );
			TextRenderer.DrawText( surface , text , this.Scheme.MainTextFont , bounds , Scheme.TitleColor , TextFormatFlags.Right | TextFormatFlags.Top );
			surface.TextRenderingHint = TextRenderingHint.SystemDefault;
			//loadingTextBrush.Dispose();
			//loadingTextFormat.Dispose();
		}

		private void DrawTitle( Graphics surface , Rectangle bounds , String text ) {
			//StringFormat loadingTextFormat = new StringFormat() { Alignment = StringAlignment.Center , LineAlignment = StringAlignment.Near };
			//SolidBrush loadingTextBrush = new SolidBrush( this.Scheme.TitleColor );
			surface.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			//surface.DrawString( text , this.Scheme.TitleFont , loadingTextBrush , bounds , loadingTextFormat );
			TextRenderer.DrawText( surface , text , this.Scheme.TitleFont , bounds , Scheme.TitleColor , TextFormatFlags.HorizontalCenter | TextFormatFlags.Top );
			surface.TextRenderingHint = TextRenderingHint.SystemDefault;
			//loadingTextBrush.Dispose();
			//loadingTextFormat.Dispose();
		}

		private void DrawData( Graphics surface , Rectangle bounds , String text ) {
			//StringFormat loadingTextFormat = new StringFormat() { Alignment = StringAlignment.Near , LineAlignment = StringAlignment.Near };
			//SolidBrush loadingTextBrush = new SolidBrush( this.Scheme.MainTextColor );
			surface.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			//surface.DrawString( text , this.Scheme.MainTextFont , loadingTextBrush , bounds , loadingTextFormat );
			TextRenderer.DrawText( surface , text , this.Scheme.MainTextFont , bounds , Scheme.MainTextColor , TextFormatFlags.Left | TextFormatFlags.Top );
			surface.TextRenderingHint = TextRenderingHint.SystemDefault;
			//loadingTextBrush.Dispose();
			//loadingTextFormat.Dispose();
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Paint event of the TimeTableNotification control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
		private void TimeTableNotification_Paint( object sender , PaintEventArgs e ) {
			NotificationDrawer.DrawBackground(
				e.Graphics ,
				this.ClientRectangle ,
				this.Scheme ,
				_hovered );
			// If there is no data, display the loading text.
			if( this.TimeTableData == null || this.TimeTableData.Count == 0 ) {
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

		/// <summary>
		/// Handles the MouseEnter event of the TimeTableNotification control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void TimeTableNotification_MouseEnter( object sender , EventArgs e ) {
			_hovered = true;
			this.Invalidate();
		}

		/// <summary>
		/// Handles the MouseLeave event of the TimeTableNotification control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void TimeTableNotification_MouseLeave( object sender , EventArgs e ) {
			_hovered = false;
			this.Invalidate();
		}

		/// <summary>
		/// Handles the DoWork event of the backgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
		private void backgroundWorker_DoWork( object sender , DoWorkEventArgs e ) {
			Employee employee = (Employee)e.Argument;
			TimeTableEntryCollection timeTableEntriesToReturn = 
				SwmSuiteFacade.TimeTableFacade.GetTimeTableEntries( employee , DateTime.Today , DateTime.Today );
			e.Result = timeTableEntriesToReturn;
		}

		/// <summary>
		/// Handles the RunWorkerCompleted event of the backgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
		private void backgroundWorker_RunWorkerCompleted( object sender , RunWorkerCompletedEventArgs e ) {
			this.TimeTableData = (TimeTableEntryCollection)e.Result;
			if( this.TimeTableData.Count > 0 ) {
				_titleString = "U moet vandaag werken.";
				_currentTimeTableEntry = 0;
				SetDataString();
				displayTimer.Enabled = true;
			} else {
				this.LoadingText = "U moet vandaag niet werken.";
			}
			Invalidate();
		}

		/// <summary>
		/// Handles the Tick event of the displayTimer control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void displayTimer_Tick( object sender , EventArgs e ) {
			_currentTimeTableEntry++;
			if( _currentTimeTableEntry == this.TimeTableData.Count ) {
				_currentTimeTableEntry = 0;
			}
			SetDataString();
			Invalidate();
		}

		#endregion

	}

}
