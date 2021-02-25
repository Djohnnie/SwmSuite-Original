using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

using System.Drawing.Text;
using SwmSuite.Data.BusinessObjects;

namespace SimpleWorkfloorManagementSuite.Modules.Notification {

	public partial class HolidayNotification : UserControl {

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
		/// Gets or sets the holiday data.
		/// </summary>
		/// <value>The holiday data.</value>
		public object HolidayData { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="HolidayNotification"/> class.
		/// </summary>
		public HolidayNotification() {
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
			_dataString = "Er zijn geen verlofgegevens.";
			_countString = "1/1";
		}

		private void DrawCount( Graphics surface , Rectangle bounds , String text ) {
			surface.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			TextRenderer.DrawText( surface , text , this.Scheme.MainTextFont , bounds , this.Scheme.TitleColor , TextFormatFlags.Right | TextFormatFlags.Top );
			surface.TextRenderingHint = TextRenderingHint.SystemDefault;
		}

		private void DrawTitle( Graphics surface , Rectangle bounds , String text ) {
			surface.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			TextRenderer.DrawText( surface , text , this.Scheme.TitleFont , bounds , this.Scheme.TitleColor , TextFormatFlags.HorizontalCenter | TextFormatFlags.Top );
			surface.TextRenderingHint = TextRenderingHint.SystemDefault;
		}

		private void DrawData( Graphics surface , Rectangle bounds , String text ) {
			surface.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			TextRenderer.DrawText( surface , text , this.Scheme.MainTextFont , bounds , this.Scheme.MainTextColor , TextFormatFlags.Left | TextFormatFlags.Top );
			surface.TextRenderingHint = TextRenderingHint.SystemDefault;
		}

		#endregion

		#region -_ Event Handlers _-

		/// <summary>
		/// Handles the Paint event of the HolidayNotification control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
		private void HolidayNotification_Paint( object sender , PaintEventArgs e ) {
			NotificationDrawer.DrawBackground(
				e.Graphics ,
				this.ClientRectangle ,
				this.Scheme ,
				_hovered );
			// If there is no data, display the loading text.
			if( this.HolidayData == null /*|| this.HolidayData.Count == 0*/ ) {
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
		/// Handles the MouseEnter event of the HolidayNotification control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void HolidayNotification_MouseEnter( object sender , EventArgs e ) {
			_hovered = true;
			this.Invalidate();
		}

		/// <summary>
		/// Handles the MouseLeave event of the HolidayNotification control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void HolidayNotification_MouseLeave( object sender , EventArgs e ) {
			_hovered = false;
			this.Invalidate();
		}

		/// <summary>
		/// Handles the DoWork event of the backgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
		private void backgroundWorker_DoWork( object sender , DoWorkEventArgs e ) {
			e.Result = null;
		}

		/// <summary>
		/// Handles the RunWorkerCompleted event of the backgroundWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
		private void backgroundWorker_RunWorkerCompleted( object sender , RunWorkerCompletedEventArgs e ) {
			this.HolidayData = e.Result;
			if( /*this.HolidayData.Count > 0*/ false ) {
				_titleString = "Er zijn geen verlofgegevens.";
				_currentMessage = 0;
				SetDataString();
				displayTimer.Enabled = true;
			} else {
				this.LoadingText = "Er zijn geen verlofgegevens.";
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
			if( _currentMessage == 0 /*this.HolidayData.Count*/ ) {
				_currentMessage = 0;
			}
			SetDataString();
			Invalidate();
		}

		#endregion

	}

}
