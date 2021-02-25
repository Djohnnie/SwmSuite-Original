using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.BusinessObjects;
using System.Collections.ObjectModel;

namespace SimpleWorkfloorManagementSuite.Controls {

	public partial class AgendaSelectorControl : UserControl {

		#region -_ Private Members _-

		private Collection<Agenda> _agendas = new Collection<Agenda>();
		private Collection<AgendaSelectorButton> _buttons = new Collection<AgendaSelectorButton>();

		#endregion

		#region -_ Public Properties _-

		public AgendaSelectorRenderer Renderer { get; set; }

		public AgendaSelectorScheme Scheme { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="AgendaSelectorControl"/> class.
		/// </summary>
		public AgendaSelectorControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );

			this.BackColor = Color.Transparent;

			this.Renderer = new AgendaSelectorRenderer();
			this.Scheme = new AgendaSelectorScheme();
		}

		#endregion

		#region -_ Public Methods _-

		public void SetAgendas( Collection<Agenda> agendas ) {
			_buttons.Clear();
			_agendas = agendas;
			foreach( Agenda agenda in agendas ) {
				_buttons.Add( new AgendaSelectorButton( agenda ) );
			}
			this.Invalidate();
		}

		#endregion

		private void AgendaSelectorControl_Paint( object sender , PaintEventArgs e ) {
			int heigh = _buttons.Count * ( this.Scheme.ButtonHeight + 5 ) + 5;

			this.Renderer.RenderBackground( e.Graphics , new Rectangle( 0 , this.ClientRectangle.Height / 2 - heigh / 2 , this.ClientRectangle.Width - 1 , heigh ) , this.Scheme );
			
			foreach( AgendaSelectorButton button in _buttons ) {
				int top = this.ClientRectangle.Height / 2 - heigh / 2;
				top += _buttons.IndexOf( button ) * (this.Scheme.ButtonHeight + 5 );
				button.Bounds = new Rectangle( 5 , top + 5 , this.ClientRectangle.Width - 11 , this.Scheme.ButtonHeight );
				this.Renderer.DrawButton( e.Graphics , button.Bounds , this.Scheme , button , _buttons.IndexOf( button ) );
			}
			
		}

		private void AgendaSelectorControl_Resize( object sender , EventArgs e ) {
			this.Renderer.Invalidate();
			this.Invalidate();
		}

	}

}