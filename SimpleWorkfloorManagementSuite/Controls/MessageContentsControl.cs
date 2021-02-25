using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.BusinessObjects;
using SwmSuite.Proxy.Interface;

namespace SimpleWorkfloorManagementSuite.Controls {
	
	public partial class MessageContentsControl : UserControl {

		#region -_ Private Members _-

		private MessageContentsRenderer _renderer = new MessageContentsRenderer();
		private MessageContentsScheme _scheme = new MessageContentsScheme();

		#endregion

		#region -_ Public Properties _-

		public MessageContentsRenderer Renderer {
			get {
				return _renderer;
			}
			set {
				_renderer = value;
			}
		}

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public MessageContentsScheme Scheme {
			get {
				return _scheme;
			}
			set {
				_scheme = value;
			}
		} 

		public int TitleHeight { get; set; }

		public String Subject { get; set; }

		public String From { get; set; }

		public String Date { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="MessageContentsControl"/> class.
		/// </summary>
		public MessageContentsControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );

			this.TitleHeight = 75;
			richTextBox.BackColor = Color.White;
		}

		#endregion

		#region -_ Event Handling _-

		/// <summary>
		/// Handles the Paint event of the MessageContentsControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
		private void MessageContentsControl_Paint( object sender , PaintEventArgs e ) {
			Rectangle titleRectangle = new Rectangle( this.ClientRectangle.Left , this.ClientRectangle.Top , this.ClientRectangle.Width , this.TitleHeight );
			Rectangle borderRectangle = new Rectangle( this.ClientRectangle.Left , this.ClientRectangle.Top , this.ClientRectangle.Width - 1 , this.ClientRectangle.Height - 1 );
			this.Renderer.RenderTitle( e.Graphics , titleRectangle , this.Scheme );
			this.Renderer.RenderBorder( e.Graphics , borderRectangle , this.Scheme );
			this.Renderer.RenderTitleContents( e.Graphics , titleRectangle , this.Scheme , this.Subject , this.From , this.Date );
		}

		/// <summary>
		/// Handles the Resize event of the MessageContentsControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void MessageContentsControl_Resize( object sender , EventArgs e ) {
			Rectangle bounds = new Rectangle( this.ClientRectangle.Left + 1 , this.ClientRectangle.Top + this.TitleHeight , this.ClientRectangle.Width - 2 , this.ClientRectangle.Height - this.TitleHeight - 2 );
			richTextBox.Bounds = bounds;
			this.Renderer.Invalidate();
			this.Invalidate();
		}

		/// <summary>
		/// Handles the Load event of the MessageContentsControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void MessageContentsControl_Load( object sender , EventArgs e ) {
			richTextBox.SelectionRightIndent = 5;
			richTextBox.SelectionIndent = 5;
		}

		#endregion

		#region -_ Public methods _-

		public void SetMessage( SwmSuite.Data.BusinessObjects.Message message , MessageFolder folder ) {
			if( message != null && folder != null ) {
				if( message.IsNew ) {
					message.IsNew = false;
					SwmSuiteFacade.MessageFacade.UpdateNewFlag( message , folder );
				}
				this.Subject = "Onderwerp: " + message.Subject;
				this.From = "Verzonden door: " + message.Sender.FullName;
				//foreach( Employee employee in message.Recipients ) {
				//    bool isLastEmployee = message.Recipients.IndexOf( employee ) == message.Recipients.Count - 1;
				//    this.From += employee.FirstName + " " + employee.Name + ( isLastEmployee ? "" : "; " );
				//}
				this.Date = "Datum: " + message.Date.ToShortDateString() + " " + message.Date.ToShortTimeString();
				richTextBox.Rtf = message.Contents;
			} else {
				this.Subject = String.Empty;
				this.From = String.Empty;
				this.Date = String.Empty;
				richTextBox.Rtf = String.Empty;
			}
			this.Renderer.Invalidate();
			Invalidate();
		}

		#endregion

	}

}
