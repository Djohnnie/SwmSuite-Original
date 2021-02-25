using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwmSuite.Data.BusinessObjects;

namespace SimpleWorkfloorManagementSuite.Controls {

	public partial class TaskContentsControl : UserControl {

		#region -_ Private Members _-

		private TaskContentsRenderer _renderer = new TaskContentsRenderer();
		private TaskContentsScheme _scheme = new TaskContentsScheme();

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the renderer.
		/// </summary>
		/// <value>The renderer.</value>
		public TaskContentsRenderer Renderer {
			get {
				return _renderer;
			}
			set {
				_renderer = value;
			}
		}

		/// <summary>
		/// Gets or sets the scheme.
		/// </summary>
		/// <value>The scheme.</value>
		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public TaskContentsScheme Scheme {
			get {
				return _scheme;
			}
			set {
				_scheme = value;
			}
		}

		/// <summary>
		/// Gets or sets the height of the title.
		/// </summary>
		/// <value>The height of the title.</value>
		public int TitleHeight { get; set; }

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		public String Title { get; set; }

		/// <summary>
		/// Gets or sets from.
		/// </summary>
		/// <value>From.</value>
		public String From { get; set; }

		/// <summary>
		/// Gets or sets the deadline.
		/// </summary>
		/// <value>The deadline.</value>
		public String Deadline { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="MessageContentsControl"/> class.
		/// </summary>
		public TaskContentsControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );

			this.TitleHeight = 75;
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
			this.Renderer.RenderTitleContents( e.Graphics , titleRectangle , this.Scheme , this.Title , this.From , this.Deadline );
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
		/// Handles the Load event of the TaskContentsControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void TaskContentsControl_Load( object sender , EventArgs e ) {
			richTextBox.SelectionRightIndent = 5;
			richTextBox.SelectionIndent = 5;
		}

		#endregion

		#region -_ Public methods _-

		/// <summary>
		/// Sets the task.
		/// </summary>
		/// <param name="task">The task to set.</param>
		public void SetTask( Task task ) {
			if( task != null ) {
				this.Title = "Onderwerp: " + task.Title;
				this.From = "Opdrachtgever: " + task.Commissioner.FullName;
				if( task.Deadline.HasValue ) {
					this.Deadline = "Ten laatste af te werken op: " + task.Deadline.Value.ToLongDateString() + " " + task.Deadline.Value.ToShortTimeString();
				} else {
					this.Deadline = "Deze taak heeft geen deadline.";
				}
				try {
					richTextBox.Rtf = task.Description;
				} catch( ArgumentException ) {
					richTextBox.Text = task.Description;
				}
				if( task.TaskRun != null ){

				}
				this.Renderer.Invalidate();
				Invalidate();
			}
		}

		#endregion

	}

}
