using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using SwmSuite.Presentation.Common.LoginButton;
using SwmSuite.Data.BusinessObjects;
using System.Web.Security;

namespace SimpleWorkfloorManagementSuite.Controls {
	
	public partial class LoginGroup : UserControl {

		#region -_ Private Members _-

		List<LoginButtonControl> _loginButtonList = new List<LoginButtonControl>();

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets or sets the height of the button.
		/// </summary>
		/// <value>The height of the button.</value>
		public int ButtonHeight { get; set; }

		/// <summary>
		/// Gets or sets the button gap.
		/// </summary>
		/// <value>The button gap.</value>
		public int ButtonGap { get; set; }

		/// <summary>
		/// Occurs when a user clicks a login button.
		/// </summary>
		public event EventHandler<LoginGroupLoginEventArgs> Login;

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public LoginGroup() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );

			this.ButtonHeight = 100;
			this.ButtonGap = 50;
		}

		#endregion

		#region -_ Public Methods _-

		public void SetEmployees(EmployeeCollection employees) {
			_loginButtonList.Clear();
			foreach( Employee employee in employees ){
				LoginButtonControl newControl = new LoginButtonControl();
				SetScheme( newControl );
				if( employee.Avatar != null ) {
					newControl.Avatar = employee.Avatar.Image;
				}
				newControl.Caption = SpaceCaption( employee.FirstName + " " + employee.Name );
				newControl.Tag = employee;
				newControl.Click += new EventHandler( newControl_Click );
				_loginButtonList.Add( newControl );
			}
			RefreshControls();
		}

		void newControl_Click( object sender , EventArgs e ) {
			LoginButtonControl loginButton = (LoginButtonControl)sender;
			if( this.Login != null ) {
				Login( this , new LoginGroupLoginEventArgs( (Employee)loginButton.Tag ) );
			}
		}

		#endregion

		#region -_ Private Methods _-

		private void RefreshControls() {
			Size buttonSize = new Size( (this.ClientRectangle.Width - this.ButtonGap) / 2 , this.ButtonHeight );
			Point firstColumnPosition = new Point( 0 , 0 );
			Point secondColumnPosition = new Point( buttonSize.Width + this.ButtonGap , 0 );
			Point centerColumnPosition = new Point( this.ClientRectangle.Width / 2 - ( buttonSize.Width + this.ButtonGap ) / 2 );

			bool oddNumberOfButtons = _loginButtonList.Count % 2 == 1;

			foreach( LoginButtonControl control in _loginButtonList ) {
				bool oddControl = _loginButtonList.IndexOf( control ) % 2 == 1;
				bool lastControl = _loginButtonList.IndexOf( control ) == _loginButtonList.Count - 1;

				if( lastControl && oddNumberOfButtons ) {
					control.Bounds = new Rectangle( centerColumnPosition , buttonSize );
				} else {
					if( oddControl ) {
						control.Bounds = new Rectangle( secondColumnPosition , buttonSize );
					} else {
						control.Bounds = new Rectangle( firstColumnPosition , buttonSize );
					}
				}

				if( oddControl ) {
					firstColumnPosition.Y += this.ButtonHeight + this.ButtonGap;
					secondColumnPosition.Y += this.ButtonHeight + this.ButtonGap;
					centerColumnPosition.Y += this.ButtonHeight + this.ButtonGap;
				}
			}

			this.SuspendLayout();
			this.Controls.Clear();
			foreach( LoginButtonControl control in _loginButtonList ) {
				this.Controls.Add( control );
			}
			this.ResumeLayout();
		}

		private void SetScheme( LoginButtonControl control ) {
			control.AvatarEnabled = true;

			control.NormalScheme = new LoginButtonScheme();
			control.NormalScheme.OuterBorderColor = Color.FromArgb( 86 , 104 , 144 );
			control.NormalScheme.BorderColor = Color.FromArgb( 0 , 0 , 0 );
			control.NormalScheme.InnerBorderColor = Color.FromArgb( 182 , 186 , 198 );
			control.NormalScheme.BackgroundColor1 = Color.FromArgb( 161 , 169 , 190 );
			control.NormalScheme.BackgroundColor2 = Color.FromArgb( 50 , 53 , 62 );
			control.NormalScheme.BackgroundColor3 = Color.FromArgb( 0 , 0 , 0 );
			control.NormalScheme.BackgroundColor4 = Color.FromArgb( 56 , 69 , 103 );
			control.NormalScheme.AvatarBackgroundColor1 = Color.FromArgb( 140 , 155 , 198 );
			control.NormalScheme.AvatarBackgroundColor2 = Color.FromArgb( 81 , 104 , 180 );
			control.NormalScheme.AvatarBackgroundColor3 = Color.FromArgb( 25 , 57 , 158 );
			control.NormalScheme.AvatarBackgroundColor4 = Color.FromArgb( 76 , 173 , 224 );
			control.NormalScheme.AvatarAreaWidth = 100;
			control.NormalScheme.CaptionColor = Color.FromArgb( 255 , 255 , 255 );
			control.NormalScheme.CaptionFont = new Font( "Copperplate Gothic Light" , 12.0f , FontStyle.Bold );
			control.NormalScheme.BackgroundGlowColor = Color.Transparent;

			control.HoveredScheme.OuterBorderColor = Color.FromArgb( 86 , 104 , 144 );
			control.HoveredScheme.BorderColor = Color.FromArgb( 0 , 0 , 0 );
			control.HoveredScheme.InnerBorderColor = Color.FromArgb( 182 , 186 , 198 );
			control.HoveredScheme.BackgroundColor1 = Color.FromArgb( 161 , 169 , 190 );
			control.HoveredScheme.BackgroundColor2 = Color.FromArgb( 50 , 53 , 62 );
			control.HoveredScheme.BackgroundColor3 = Color.FromArgb( 0 , 0 , 0 );
			control.HoveredScheme.BackgroundColor4 = Color.FromArgb( 56 , 69 , 103 );
			control.HoveredScheme.AvatarBackgroundColor1 = Color.FromArgb( 140 , 155 , 198 );
			control.HoveredScheme.AvatarBackgroundColor2 = Color.FromArgb( 81 , 104 , 180 );
			control.HoveredScheme.AvatarBackgroundColor3 = Color.FromArgb( 25 , 57 , 158 );
			control.HoveredScheme.AvatarBackgroundColor4 = Color.FromArgb( 76 , 173 , 224 );
			control.HoveredScheme.AvatarAreaWidth = 100;
			control.HoveredScheme.CaptionColor = Color.FromArgb( 255 , 255 , 255 );
			control.HoveredScheme.CaptionFont = new Font( "Copperplate Gothic Light" , 12.0f , FontStyle.Bold );
			control.HoveredScheme.BackgroundGlowColor = Color.FromArgb( 0x30 , 0x73 , 0xCE );

			control.PushedScheme.OuterBorderColor = Color.FromArgb( 112 , 125 , 158 );
			control.PushedScheme.BorderColor = Color.FromArgb( 0 , 0 , 0 );
			control.PushedScheme.InnerBorderColor = Color.FromArgb( 75 , 75 , 75 );
			control.PushedScheme.BackgroundColor1 = Color.FromArgb( 44 , 51 , 70 );
			control.PushedScheme.BackgroundColor2 = Color.FromArgb( 50 , 54 , 64 );
			control.PushedScheme.BackgroundColor3 = Color.FromArgb( 0 , 0 , 0 );
			control.PushedScheme.BackgroundColor4 = Color.FromArgb( 20 , 47 , 85 );
			control.PushedScheme.AvatarBackgroundColor1 = Color.FromArgb( 140 , 155 , 198 );
			control.PushedScheme.AvatarBackgroundColor2 = Color.FromArgb( 81 , 104 , 180 );
			control.PushedScheme.AvatarBackgroundColor3 = Color.FromArgb( 25 , 57 , 158 );
			control.PushedScheme.AvatarBackgroundColor4 = Color.FromArgb( 76 , 173 , 224 );
			control.PushedScheme.AvatarAreaWidth = 100;
			control.PushedScheme.CaptionColor = Color.FromArgb( 255 , 255 , 255 );
			control.PushedScheme.CaptionFont = new Font( "Copperplate Gothic Light" , 12.0f , FontStyle.Bold );
			control.PushedScheme.BackgroundGlowColor = Color.FromArgb( 0x30 , 0x73 , 0xCE );

			control.DisabledScheme.OuterBorderColor = Color.FromArgb( 86 , 104 , 144 );
			control.DisabledScheme.BorderColor = Color.FromArgb( 0 , 0 , 0 );
			control.DisabledScheme.InnerBorderColor = Color.FromArgb( 182 , 186 , 198 );
			control.DisabledScheme.BackgroundColor1 = Color.FromArgb( 161 , 169 , 190 );
			control.DisabledScheme.BackgroundColor2 = Color.FromArgb( 50 , 53 , 62 );
			control.DisabledScheme.BackgroundColor3 = Color.FromArgb( 0 , 0 , 0 );
			control.DisabledScheme.BackgroundColor4 = Color.FromArgb( 56 , 69 , 103 );
			control.DisabledScheme.AvatarBackgroundColor1 = Color.FromArgb( 140 , 155 , 198 );
			control.DisabledScheme.AvatarBackgroundColor2 = Color.FromArgb( 81 , 104 , 180 );
			control.DisabledScheme.AvatarBackgroundColor3 = Color.FromArgb( 25 , 57 , 158 );
			control.DisabledScheme.AvatarBackgroundColor4 = Color.FromArgb( 76 , 173 , 224 );
			control.DisabledScheme.AvatarAreaWidth = 100;
			control.DisabledScheme.CaptionColor = Color.FromArgb( 100 , 100 , 100 );
			control.DisabledScheme.CaptionFont = new Font( "Copperplate Gothic Light" , 12.0f , FontStyle.Bold );
			control.DisabledScheme.BackgroundGlowColor = Color.Transparent;
		}

		public static String SpaceCaption( String caption ) {
			String captionToReturn = "";
			foreach( char letter in caption.ToCharArray() ) {
				captionToReturn += letter + " ";
			}
			return captionToReturn;
		}

		#endregion

	}

}
