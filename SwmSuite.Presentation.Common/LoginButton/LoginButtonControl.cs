using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace SwmSuite.Presentation.Common.LoginButton {
	
	public partial class LoginButtonControl : UserControl {

		#region -_ Private Members _-

		private bool _avatarEnabled = false;
		private LoginButtonState _state = LoginButtonState.Normal;
		private LoginButtonRenderer _renderer = new LoginButtonRenderer();
		private LoginButtonScheme _normalScheme = new LoginButtonScheme();
		private LoginButtonScheme _hoveredScheme = new LoginButtonScheme();
		private LoginButtonScheme _pushedScheme = new LoginButtonScheme();
		private LoginButtonScheme _disabledScheme = new LoginButtonScheme();
		private Image _avatar;
		private String _caption;

		#endregion

		#region -_ Public Properties _-

		public bool AvatarEnabled {
			get {
				return _avatarEnabled;
			}
			set {
				_avatarEnabled = value;
			}
		}

		public LoginButtonState State {
			get {
				return _state;
			}
			set {
				_state = value;
			}
		}

		public LoginButtonRenderer Renderer {
			get {
				return _renderer;
			}
			set {
				_renderer = value;
			}
		}

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public LoginButtonScheme NormalScheme {
			get {
				return _normalScheme;
			}
			set {
				_normalScheme = value;
			}
		}

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public LoginButtonScheme HoveredScheme {
			get {
				return _hoveredScheme;
			}
			set {
				_hoveredScheme = value;
			}
		}

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public LoginButtonScheme PushedScheme {
			get {
				return _pushedScheme;
			}
			set {
				_pushedScheme = value;
			}
		}

		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public LoginButtonScheme DisabledScheme {
			get {
				return _disabledScheme;
			}
			set {
				_disabledScheme = value;
			}
		}

		public LoginButtonScheme CurrentScheme {
			get {
				LoginButtonScheme current = this.NormalScheme;
				switch( this.State ) {
					case LoginButtonState.Normal: {
						current = this.NormalScheme;
						break;
					}
					case LoginButtonState.Hovered: {
						current = this.HoveredScheme;
						break;
					}
					case LoginButtonState.Pushed: {
						current = this.PushedScheme;
						break;
					}
					case LoginButtonState.Disabled: {
						current = this.DisabledScheme;
						break;
					}
				}
				return current;
			}
		}

		public Image Avatar {
			get {
				return _avatar;
			}
			set {
				_avatar = value;
			}
		}

		public String Caption {
			get {
				return _caption;
			}
			set {
				_caption = value;
			}
		}

		#endregion

		#region -_ Construction _-

		public LoginButtonControl() {
			InitializeComponent();

			this.SetStyle( ControlStyles.AllPaintingInWmPaint , true );
			this.SetStyle( ControlStyles.OptimizedDoubleBuffer , true );
			this.SetStyle( ControlStyles.ResizeRedraw , true );
			this.SetStyle( ControlStyles.SupportsTransparentBackColor , true );
			this.SetStyle( ControlStyles.UserPaint , true );
			this.BackColor = Color.Transparent;

			this.NormalScheme.OuterBorderColor = Color.FromArgb( 86 , 104 , 144 );
			this.NormalScheme.BorderColor = Color.FromArgb( 0 , 0 , 0 );
			this.NormalScheme.InnerBorderColor = Color.FromArgb( 182 , 186 , 198 );
			this.NormalScheme.BackgroundColor1 = Color.FromArgb( 161 , 169 , 190 );
			this.NormalScheme.BackgroundColor2 = Color.FromArgb( 50 , 53 , 62 );
			this.NormalScheme.BackgroundColor3 = Color.FromArgb( 0 , 0 , 0 );
			this.NormalScheme.BackgroundColor4 = Color.FromArgb( 56 , 69 , 103 );
			this.NormalScheme.AvatarBackgroundColor1 = Color.FromArgb( 140 , 155 , 198 );
			this.NormalScheme.AvatarBackgroundColor2 = Color.FromArgb( 81 , 104 , 180 );
			this.NormalScheme.AvatarBackgroundColor3 = Color.FromArgb( 25 , 57 , 158 );
			this.NormalScheme.AvatarBackgroundColor4 = Color.FromArgb( 76 , 173 , 224 );
			this.NormalScheme.AvatarAreaWidth = 100;
			this.NormalScheme.CaptionColor = Color.FromArgb( 255 , 255 , 255 );
			this.NormalScheme.CaptionFont = new Font( "Copperplate Gothic Light" , 12.0f , FontStyle.Bold );
			this.NormalScheme.BackgroundGlowColor = Color.Transparent;

			this.HoveredScheme.OuterBorderColor = Color.FromArgb( 86 , 104 , 144 );
			this.HoveredScheme.BorderColor = Color.FromArgb( 0 , 0 , 0 );
			this.HoveredScheme.InnerBorderColor = Color.FromArgb( 182 , 186 , 198 );
			this.HoveredScheme.BackgroundColor1 = Color.FromArgb( 161 , 169 , 190 );
			this.HoveredScheme.BackgroundColor2 = Color.FromArgb( 50 , 53 , 62 );
			this.HoveredScheme.BackgroundColor3 = Color.FromArgb( 0 , 0 , 0 );
			this.HoveredScheme.BackgroundColor4 = Color.FromArgb( 56 , 69 , 103 );
			this.HoveredScheme.AvatarBackgroundColor1 = Color.FromArgb( 140 , 155 , 198 );
			this.HoveredScheme.AvatarBackgroundColor2 = Color.FromArgb( 81 , 104 , 180 );
			this.HoveredScheme.AvatarBackgroundColor3 = Color.FromArgb( 25 , 57 , 158 );
			this.HoveredScheme.AvatarBackgroundColor4 = Color.FromArgb( 76 , 173 , 224 );
			this.HoveredScheme.AvatarAreaWidth = 100;
			this.HoveredScheme.CaptionColor = Color.FromArgb( 255 , 255 , 255 );
			this.HoveredScheme.CaptionFont = new Font( "Copperplate Gothic Light" , 12.0f , FontStyle.Bold );
			this.HoveredScheme.BackgroundGlowColor = Color.FromArgb( 0x30 , 0x73 , 0xCE );

			this.PushedScheme.OuterBorderColor = Color.FromArgb( 112 , 125 , 158 );
			this.PushedScheme.BorderColor = Color.FromArgb( 0 , 0 , 0 );
			this.PushedScheme.InnerBorderColor = Color.FromArgb( 75 , 75 , 75 );
			this.PushedScheme.BackgroundColor1 = Color.FromArgb( 44 , 51 , 70 );
			this.PushedScheme.BackgroundColor2 = Color.FromArgb( 50 , 54 , 64 );
			this.PushedScheme.BackgroundColor3 = Color.FromArgb( 0 , 0 , 0 );
			this.PushedScheme.BackgroundColor4 = Color.FromArgb( 20 , 47 , 85 );
			this.PushedScheme.AvatarBackgroundColor1 = Color.FromArgb( 140 , 155 , 198 );
			this.PushedScheme.AvatarBackgroundColor2 = Color.FromArgb( 81 , 104 , 180 );
			this.PushedScheme.AvatarBackgroundColor3 = Color.FromArgb( 25 , 57 , 158 );
			this.PushedScheme.AvatarBackgroundColor4 = Color.FromArgb( 76 , 173 , 224 );
			this.PushedScheme.AvatarAreaWidth = 100;
			this.PushedScheme.CaptionColor = Color.FromArgb( 255 , 255 , 255 );
			this.PushedScheme.CaptionFont = new Font( "Copperplate Gothic Light" , 12.0f , FontStyle.Bold );
			this.PushedScheme.BackgroundGlowColor = Color.FromArgb( 0x30 , 0x73 , 0xCE );

			this.DisabledScheme.OuterBorderColor = Color.FromArgb( 86 , 104 , 144 );
			this.DisabledScheme.BorderColor = Color.FromArgb( 0 , 0 , 0 );
			this.DisabledScheme.InnerBorderColor = Color.FromArgb( 182 , 186 , 198 );
			this.DisabledScheme.BackgroundColor1 = Color.FromArgb( 161 , 169 , 190 );
			this.DisabledScheme.BackgroundColor2 = Color.FromArgb( 50 , 53 , 62 );
			this.DisabledScheme.BackgroundColor3 = Color.FromArgb( 0 , 0 , 0 );
			this.DisabledScheme.BackgroundColor4 = Color.FromArgb( 56 , 69 , 103 );
			this.DisabledScheme.AvatarBackgroundColor1 = Color.FromArgb( 140 , 155 , 198 );
			this.DisabledScheme.AvatarBackgroundColor2 = Color.FromArgb( 81 , 104 , 180 );
			this.DisabledScheme.AvatarBackgroundColor3 = Color.FromArgb( 25 , 57 , 158 );
			this.DisabledScheme.AvatarBackgroundColor4 = Color.FromArgb( 76 , 173 , 224 );
			this.DisabledScheme.AvatarAreaWidth = 100;
			this.DisabledScheme.CaptionColor = Color.FromArgb( 100 , 100 , 100 );
			this.DisabledScheme.CaptionFont = new Font( "Copperplate Gothic Light" , 12.0f , FontStyle.Bold );
			this.DisabledScheme.BackgroundGlowColor = Color.Transparent;
		}

		#endregion

		private void LoginButtonControl_Paint( object sender , PaintEventArgs e ) {
			this.Renderer.Render( e.Graphics , this.ClientRectangle , this.CurrentScheme , this.AvatarEnabled );
			if( this.AvatarEnabled ) {
				this.Renderer.DrawAvatar( e.Graphics , new Rectangle( this.ClientRectangle.Left , this.ClientRectangle.Top , this.CurrentScheme.AvatarAreaWidth , this.ClientRectangle.Height ) , this.Avatar );
			}
			this.Renderer.RenderCaption( e.Graphics , new Rectangle( this.ClientRectangle.Left + this.CurrentScheme.AvatarAreaWidth , this.ClientRectangle.Top , this.ClientRectangle.Width - this.CurrentScheme.AvatarAreaWidth , this.ClientRectangle.Height ) , this.CurrentScheme , this.Caption );
		}

		private void LoginButtonControl_SizeChanged( object sender , EventArgs e ) {
			this.Renderer.Invalidate();
			this.Invalidate();
		}

		private void LoginButtonControl_MouseEnter( object sender , EventArgs e ) {
			if( this.State != LoginButtonState.Disabled ) {
				this.State = LoginButtonState.Hovered;
				this.Renderer.Invalidate();
				this.Invalidate();
			}
		}

		private void LoginButtonControl_MouseLeave( object sender , EventArgs e ) {
			if( this.State != LoginButtonState.Disabled ) {
				this.State = LoginButtonState.Normal;
				this.Renderer.Invalidate();
				this.Invalidate();
			}
		}

		private void LoginButtonControl_MouseDown( object sender , MouseEventArgs e ) {
			if( this.State != LoginButtonState.Disabled ) {
				this.State = LoginButtonState.Pushed;
				this.Renderer.Invalidate();
				this.Invalidate();
			}
		}

		private void LoginButtonControl_MouseUp( object sender , MouseEventArgs e ) {
			if( this.State != LoginButtonState.Disabled ) {
				this.State = LoginButtonState.Hovered;
				this.Renderer.Invalidate();
				this.Invalidate();
			}
		}

	}

}
