using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using SwmSuite.Framework;

namespace SwmSuite.Presentation.Common.AgendaControl {

	public partial class AgendaControl : UserControl {

		#region -_ Private Members _-

		private AgendaAppointmentCollection _appointments = new AgendaAppointmentCollection();

		private AgendaScheme _scheme = new AgendaScheme();

		private AgendaRenderer _dayRenderer = new AgendaDayRenderer();
		private AgendaRenderer _weekRenderer = new AgendaWeekRenderer();
		private AgendaRenderer _monthRenderer = new AgendaMonthRenderer();

		private AgendaHitTester _dayHitTester = new AgendaDayHitTester();
		private AgendaHitTester _weekHitTester = new AgendaWeekHitTester();
		private AgendaHitTester _monthHitTester = new AgendaMonthHitTester();

		private AgendaViewMode _viewMode = AgendaViewMode.Day;

		private DateTime _selection = DateTime.Today;

		private AgendaSettings _settings = new AgendaSettings();
		private AgendaAppointment _selectedAppointment;
		private AgendaAppointment _hoveredAppointment;


		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets the appointments.
		/// </summary>
		/// <value>The appointments.</value>
		public AgendaAppointmentCollection Appointments {
			get {
				return _appointments;
			}
		}

		/// <summary>
		/// Gets or sets the selection start.
		/// </summary>
		/// <value>The selection start.</value>
		public DateTime SelectionStart { get; set; }
		/// <summary>
		/// Gets or sets the selection end.
		/// </summary>
		/// <value>The selection end.</value>
		public DateTime SelectionEnd { get; set; }

		/// <summary>
		/// Gets the scheme.
		/// </summary>
		/// <value>The scheme.</value>
		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public AgendaScheme Scheme {
			get {
				return _scheme;
			}
		}

		/// <summary>
		/// Gets the renderer.
		/// </summary>
		/// <value>The renderer.</value>
		public AgendaRenderer Renderer {
			get {
				switch( this.ViewMode ) {
					case AgendaViewMode.Day: {
							return _dayRenderer;
						}
					case AgendaViewMode.Week: {
							return _weekRenderer;
						}
					case AgendaViewMode.Month: {
							return _monthRenderer;
						}
					default: {
							return null;
						}
				}
			}
		}

		/// <summary>
		/// Gets the hit tester.
		/// </summary>
		/// <value>The hit tester.</value>
		public AgendaHitTester HitTester {
			get {
				switch( this.ViewMode ) {
					case AgendaViewMode.Day: {
							return _dayHitTester;
						}
					case AgendaViewMode.Week: {
							return _weekHitTester;
						}
					case AgendaViewMode.Month: {
							return _monthHitTester;
						}
					default: {
							return null;
						}
				}
			}
		}

		/// <summary>
		/// Gets or sets the view mode.
		/// </summary>
		/// <value>The view mode.</value>
		public AgendaViewMode ViewMode {
			get {
				return _viewMode;
			}
			set {
				_viewMode = value;
				SetSelection( _selection );
				this.Renderer.Invalidate();
				this.Invalidate();
			}
		}

		/// <summary>
		/// Gets the settings.
		/// </summary>
		/// <value>The settings.</value>
		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public AgendaSettings Settings {
			get {
				return _settings;
			}
		}

		/// <summary>
		/// Gets or sets the selected appointment.
		/// </summary>
		/// <value>The selected appointment.</value>
		public AgendaAppointment SelectedAppointment {
			get {
				return _selectedAppointment;
			}
		}

		/// <summary>
		/// Gets the selection.
		/// </summary>
		/// <value>The selection.</value>
		public DateTime Selection {
			get {
				return _selection;
			}
		}

		#endregion

		#region -_ Public Events _-

		/// <summary>
		/// Event raised when this Agenda needs a data update.
		/// </summary>
		public event EventHandler<AgendaNeedsUpdateEventArgs> NeedsUpdate;

		/// <summary>
		/// Occurs when an appointment selection has changed.
		/// </summary>
		public event EventHandler<AppointmentSelectionChangedEventArgs> AppointmentSelectionChanged;

		private void RaiseAppointmentSelectionChanged( AgendaAppointment appointment ) {
			if( this.AppointmentSelectionChanged != null ) {
				AppointmentSelectionChanged( this , new AppointmentSelectionChangedEventArgs( appointment ) );
			}
		}

		#endregion

		#region -_ Construction _-

		public AgendaControl() {
			InitializeComponent();
			this.MouseWheel += new MouseEventHandler( AgendaControl_MouseWheel );
			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );
		}

		#endregion

		#region -_ Private Methods _-

		private void NeedUpdate( DateTime date ) {
			if( this.NeedsUpdate != null ) {
				List<DateTime> dates = new List<DateTime>();
				switch( this.ViewMode ) {
					case AgendaViewMode.Day: {
							dates.Add( date );
							break;
						}
					case AgendaViewMode.Week: {
							for( int i = 0 ; i < 7 ; i++ ) {
								dates.Add( date.StartOfWeek().AddDays( i ) );
							}
							break;
						}
					case AgendaViewMode.Month: {
							for( int i = 0 ; i < DateTime.DaysInMonth( date.Year , date.Month ) ; i++ ) {
								dates.Add( new DateTime( date.Year , date.Month , i + 1 ) );
							}
							break;
						}
				}
				NeedsUpdate( this , new AgendaNeedsUpdateEventArgs( dates.ToArray() ) );
			}
		}

		#endregion

		#region -_ Public Methods _-

		public void RefreshAgenda() {
			NeedUpdate( _selection );
			this.Invalidate();
		}

		/// <summary>
		/// Sets the selection.
		/// </summary>
		/// <param name="date">The date.</param>
		public void SetSelection( DateTime date ) {
			switch( this.ViewMode ) {
				case AgendaViewMode.Day: {
						_selection = date;
						break;
					}
				case AgendaViewMode.Week: {
						_selection = date.StartOfWeek();
						break;
					}
				case AgendaViewMode.Month: {
						_selection = new DateTime( date.Year , date.Month , 1 );
						break;
					}
			}
			NeedUpdate( date );
			this.Invalidate();
		}

		public void UpdateData() {
			NeedUpdate( _selection );
			this.Invalidate();
		}

		public void Forwards() {
			switch( this.ViewMode ) {
				case AgendaViewMode.Day: {
						SetSelection( _selection.AddDays( 1 ) );
						break;
					}
				case AgendaViewMode.Week: {
						SetSelection( _selection.AddDays( 7 ) );
						break;
					}
				case AgendaViewMode.Month: {
						SetSelection( _selection.AddMonths( 1 ) );
						break;
					}
			}
			NeedUpdate( _selection );
			this.Invalidate();
		}

		public void Backwards() {
			switch( this.ViewMode ) {
				case AgendaViewMode.Day: {
						SetSelection( _selection.AddDays( -1 ) );
						break;
					}
				case AgendaViewMode.Week: {
						SetSelection( _selection.AddDays( -7 ) );
						break;
					}
				case AgendaViewMode.Month: {
						SetSelection( _selection.AddMonths( -1 ) );
						break;
					}
			}
			NeedUpdate( _selection );
			this.Invalidate();
		}

		#endregion

		private void AgendaControl_Paint( object sender , PaintEventArgs e ) {
			Rectangle borderRectangle = new Rectangle( this.ClientRectangle.Left , this.ClientRectangle.Top , this.ClientRectangle.Width - 1 - verticalScrollBar.Width , this.ClientRectangle.Height - 1 );
			Rectangle headerRectangle = new Rectangle( this.ClientRectangle.Left , this.ClientRectangle.Top , this.ClientRectangle.Width - 1 - verticalScrollBar.Width , this.Scheme.HeaderHeight );
			Rectangle timeRulerRectangle = new Rectangle( this.ClientRectangle.Left , this.ClientRectangle.Top + this.Scheme.HeaderHeight , this.Scheme.TimeRulerWidth , this.ClientRectangle.Height - this.Scheme.HeaderHeight - 1 );
			Rectangle contentsRectangle = new Rectangle( this.ClientRectangle.Left + this.Scheme.TimeRulerWidth , this.ClientRectangle.Top + this.Scheme.HeaderHeight , this.ClientRectangle.Width - this.Scheme.TimeRulerWidth - 1 - verticalScrollBar.Width , this.ClientRectangle.Height - this.Scheme.HeaderHeight - 1 );

			this.Renderer.RenderSelection( e.Graphics , contentsRectangle , this.Scheme , this.Settings , _selection , SelectionStart , SelectionEnd );

			this.Renderer.RenderGrid( e.Graphics , contentsRectangle , this.Scheme , this.Settings );

			this.Renderer.RenderAppointments( e.Graphics , contentsRectangle , this.Scheme , this.Settings , _selection , this.Appointments );

			this.Renderer.RenderHeader( e.Graphics , headerRectangle , this.Scheme );

			this.Renderer.RenderTimeRuler( e.Graphics , timeRulerRectangle , this.Scheme , this.Settings );

			this.Renderer.RenderHeaderCaption( e.Graphics , headerRectangle , this.Scheme , _selection );

			this.Renderer.RenderSeperators( e.Graphics , borderRectangle , this.Scheme );

			this.Renderer.RenderBorder( e.Graphics , borderRectangle , this.Scheme );

		}

		private void AgendaControl_Resize( object sender , EventArgs e ) {
			this.Renderer.Invalidate();
			this.Invalidate();
		}



		#region -_ Mouse Logic _-

		/// <summary>
		/// Handles the MouseDown event of the AgendaControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
		private void AgendaControl_MouseDown( object sender , MouseEventArgs e ) {
			_selectedAppointment = null;
			switch( this.HitTester.HitTest( e.Location , this.ClientRectangle , this.Scheme , this.Settings , _selection , this.Appointments ) ) {
				case AgendaHitTestArea.Content: {
						SetSelectedAppointment( null );
						SelectionStart = this.HitTester.Selection;
						SelectionEnd = this.HitTester.Selection;
						this.Invalidate();
						break;
					}
				case AgendaHitTestArea.Appointment: {
						if( _selectedAppointment != this.HitTester.Appointment ) {
							SetSelectedAppointment( this.HitTester.Appointment );
							Invalidate();
						}
						break;
					}
				case AgendaHitTestArea.Header: {
						SetSelectedAppointment( null );
						break;
					}
				case AgendaHitTestArea.TimeRuler: {
						SetSelectedAppointment( null );
						break;
					}
			}
		}

		private void SetSelectedAppointment( AgendaAppointment agendaAppointment ) {
			RemoveSelectedState();
			_selectedAppointment = agendaAppointment;
			if( _selectedAppointment != null ) {
				_selectedAppointment.Selected = true;
			}
			RaiseAppointmentSelectionChanged( _selectedAppointment );
		}

		/// <summary>
		/// Handles the MouseMove event of the AgendaControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
		private void AgendaControl_MouseMove( object sender , MouseEventArgs e ) {
			switch( this.HitTester.HitTest( e.Location , this.ClientRectangle , this.Scheme , this.Settings , _selection , this.Appointments ) ) {
				case AgendaHitTestArea.Content: {
						if( _hoveredAppointment != null ) {
							RemoveHoveredState();
							_hoveredAppointment = null;
						}
						if( e.Button == MouseButtons.Left ) {
							if( this.HitTester.Selection <= SelectionStart ) {
								SelectionStart = this.HitTester.Selection;
							} else {
								SelectionEnd = this.HitTester.Selection;
							}
						}
						this.Invalidate();
						break;
					}
				case AgendaHitTestArea.Appointment: {
						if( _hoveredAppointment != this.HitTester.Appointment ) {
							RemoveHoveredState();
							_hoveredAppointment = this.HitTester.Appointment;
							_hoveredAppointment.Hovered = true;
							Invalidate();
						}
						break;
					}
				case AgendaHitTestArea.Header: {
						if( _hoveredAppointment != null ) {
							RemoveHoveredState();
							_hoveredAppointment.Hovered = false;
							_hoveredAppointment = null;
							Invalidate();
						}
						break;
					}
				case AgendaHitTestArea.TimeRuler: {
						if( _hoveredAppointment != null ) {
							RemoveHoveredState();
							_hoveredAppointment.Hovered = false;
							_hoveredAppointment = null;
							Invalidate();
						}
						break;
					}
			}
		}

		/// <summary>
		/// Handles the MouseUp event of the AgendaControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
		private void AgendaControl_MouseUp( object sender , MouseEventArgs e ) {
			if( this.HitTester.HitTest( e.Location , this.ClientRectangle , this.Scheme , this.Settings , _selection , this.Appointments ) == AgendaHitTestArea.Content ) {
				if( e.Button == MouseButtons.Left ) {
					if( this.HitTester.Selection <= SelectionStart ) {
						SelectionStart = this.HitTester.Selection;
					} else {
						SelectionEnd = this.HitTester.Selection;
					}
					this.Invalidate();
				}
			}
		}

		/// <summary>
		/// Handles the MouseWheel event of the AgendaControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
		private void AgendaControl_MouseWheel( object sender , MouseEventArgs e ) {
			if( e.Delta > 0 ) {
				if( verticalScrollBar.Value > verticalScrollBar.Minimum ) {
					verticalScrollBar.Value--;
				}
			} else {
				if( verticalScrollBar.Value < verticalScrollBar.Maximum - verticalScrollBar.LargeChange + 1 ) {
					verticalScrollBar.Value++;
				}
			}
		}

		#endregion

		private void RemoveHoveredState() {
			foreach( AgendaAppointment appointment in this.Appointments ) {
				appointment.Hovered = false;
			}
		}

		private void RemoveSelectedState() {
			foreach( AgendaAppointment appointment in this.Appointments ) {
				appointment.Selected = false;
			}
		}

		/// <summary>
		/// Handles the Load event of the AgendaControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void AgendaControl_Load( object sender , EventArgs e ) {
			verticalScrollBar.Minimum = 0;
			verticalScrollBar.Maximum = 23;
			verticalScrollBar.SmallChange = 1;
			verticalScrollBar.LargeChange = this.Settings.DefaultEndHour - this.Settings.DefaultBeginHour;
			verticalScrollBar.Value = this.Settings.CurrentBeginPosition;
		}

		/// <summary>
		/// Handles the ValueChanged event of the verticalScrollBar control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void verticalScrollBar_ValueChanged( object sender , EventArgs e ) {
			this.Settings.CurrentBeginPosition = verticalScrollBar.Value;
			this.Renderer.Invalidate();
			this.Invalidate();
		}

		/// <summary>
		/// Handles the Scroll event of the verticalScrollBar control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.ScrollEventArgs"/> instance containing the event data.</param>
		private void verticalScrollBar_Scroll( object sender , ScrollEventArgs e ) {
			this.Settings.CurrentBeginPosition = e.NewValue;
			this.Renderer.Invalidate();
			this.Invalidate();
		}

		/// <summary>
		/// Invalidates the entire surface of the control and causes the control to be redrawn.
		/// </summary>
		/// <PermissionSet>
		/// 	<IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
		/// </PermissionSet>
		public new void Invalidate() {
			foreach( AgendaAppointment appointment in _appointments ) {
				appointment.Bounds = null;
			}
			this.Renderer.Invalidate();
			base.Invalidate();
		}

	}

}
