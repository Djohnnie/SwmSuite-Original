namespace SimpleWorkfloorManagementSuite.Screens {
	partial class ScreenSaver {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing ) {
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			SwmSuite.Presentation.Common.Marquee.MarqueeRenderer marqueeRenderer1 = new SwmSuite.Presentation.Common.Marquee.MarqueeRenderer();
			SwmSuite.Presentation.Common.Marquee.MarqueeScheme marqueeScheme1 = new SwmSuite.Presentation.Common.Marquee.MarqueeScheme();
			SwmSuite.Presentation.Common.AnalogClock.NiceAnalogClockRenderer niceAnalogClockRenderer1 = new SwmSuite.Presentation.Common.AnalogClock.NiceAnalogClockRenderer();
			SwmSuite.Presentation.Common.AnalogClock.NiceAnalogClockScheme niceAnalogClockScheme1 = new SwmSuite.Presentation.Common.AnalogClock.NiceAnalogClockScheme();
			SwmSuite.Presentation.Common.Marquee.MarqueeRenderer marqueeRenderer2 = new SwmSuite.Presentation.Common.Marquee.MarqueeRenderer();
			SwmSuite.Presentation.Common.Marquee.MarqueeScheme marqueeScheme2 = new SwmSuite.Presentation.Common.Marquee.MarqueeScheme();
			this.timer = new System.Windows.Forms.Timer( this.components );
			this.marqueeControl = new SwmSuite.Presentation.Common.Marquee.MarqueeControl();
			this.panel1 = new System.Windows.Forms.Panel();
			this.niceAnalogClockControl1 = new SwmSuite.Presentation.Common.AnalogClock.NiceAnalogClockControl();
			this.marqueeControl1 = new SwmSuite.Presentation.Common.Marquee.MarqueeControl();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// timer
			// 
			this.timer.Enabled = true;
			this.timer.Tick += new System.EventHandler( this.timer_Tick );
			// 
			// marqueeControl
			// 
			this.marqueeControl.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.marqueeControl.Location = new System.Drawing.Point( 0 , 640 );
			this.marqueeControl.MarqueeText = "!-! Test !-!";
			this.marqueeControl.Name = "marqueeControl";
			this.marqueeControl.Renderer = marqueeRenderer1;
			marqueeScheme1.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 136 ) ) ) ) , ( (int)( ( (byte)( 180 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
			marqueeScheme1.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 71 ) ) ) ) , ( (int)( ( (byte)( 139 ) ) ) ) , ( (int)( ( (byte)( 158 ) ) ) ) );
			marqueeScheme1.BackgroundColor3 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 19 ) ) ) ) , ( (int)( ( (byte)( 97 ) ) ) ) , ( (int)( ( (byte)( 119 ) ) ) ) );
			marqueeScheme1.BackgroundColor4 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 83 ) ) ) ) , ( (int)( ( (byte)( 159 ) ) ) ) , ( (int)( ( (byte)( 171 ) ) ) ) );
			marqueeScheme1.TextColor = System.Drawing.Color.White;
			marqueeScheme1.TextFont = new System.Drawing.Font( "Copperplate Gothic Light" , 20.25F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.marqueeControl.Scheme = marqueeScheme1;
			this.marqueeControl.Size = new System.Drawing.Size( 895 , 42 );
			this.marqueeControl.TabIndex = 9;
			// 
			// panel1
			// 
			this.panel1.Controls.Add( this.niceAnalogClockControl1 );
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point( 0 , 42 );
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding( 10 );
			this.panel1.Size = new System.Drawing.Size( 895 , 598 );
			this.panel1.TabIndex = 10;
			// 
			// niceAnalogClockControl1
			// 
			this.niceAnalogClockControl1.BackColor = System.Drawing.Color.Transparent;
			this.niceAnalogClockControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.niceAnalogClockControl1.Location = new System.Drawing.Point( 10 , 10 );
			this.niceAnalogClockControl1.Name = "niceAnalogClockControl1";
			this.niceAnalogClockControl1.Renderer = niceAnalogClockRenderer1;
			niceAnalogClockScheme1.FaceColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 189 ) ) ) ) , ( (int)( ( (byte)( 173 ) ) ) ) , ( (int)( ( (byte)( 231 ) ) ) ) );
			niceAnalogClockScheme1.FaceColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 57 ) ) ) ) , ( (int)( ( (byte)( 49 ) ) ) ) , ( (int)( ( (byte)( 74 ) ) ) ) );
			niceAnalogClockScheme1.HourHandColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			niceAnalogClockScheme1.HourIndicatorWidth = 0.75F;
			niceAnalogClockScheme1.InnerRingWidth = 2F;
			niceAnalogClockScheme1.MinuteHandColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			niceAnalogClockScheme1.MinuteIndicatorWidth = 0.1F;
			niceAnalogClockScheme1.OuterRingWidth = 8F;
			niceAnalogClockScheme1.SecondHandColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 255 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			niceAnalogClockScheme1.TextColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) );
			this.niceAnalogClockControl1.Scheme = niceAnalogClockScheme1;
			this.niceAnalogClockControl1.Size = new System.Drawing.Size( 875 , 578 );
			this.niceAnalogClockControl1.TabIndex = 1;
			// 
			// marqueeControl1
			// 
			this.marqueeControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.marqueeControl1.Location = new System.Drawing.Point( 0 , 0 );
			this.marqueeControl1.MarqueeText = "S i m p l e   W o r k f l o o r   M a n a g e m e n t   S u i t e";
			this.marqueeControl1.Name = "marqueeControl1";
			this.marqueeControl1.Renderer = marqueeRenderer2;
			marqueeScheme2.BackgroundColor1 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 136 ) ) ) ) , ( (int)( ( (byte)( 180 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
			marqueeScheme2.BackgroundColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 71 ) ) ) ) , ( (int)( ( (byte)( 139 ) ) ) ) , ( (int)( ( (byte)( 158 ) ) ) ) );
			marqueeScheme2.BackgroundColor3 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 19 ) ) ) ) , ( (int)( ( (byte)( 97 ) ) ) ) , ( (int)( ( (byte)( 119 ) ) ) ) );
			marqueeScheme2.BackgroundColor4 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 83 ) ) ) ) , ( (int)( ( (byte)( 159 ) ) ) ) , ( (int)( ( (byte)( 171 ) ) ) ) );
			marqueeScheme2.TextColor = System.Drawing.Color.White;
			marqueeScheme2.TextFont = new System.Drawing.Font( "Copperplate Gothic Light" , 20.25F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
			this.marqueeControl1.Scheme = marqueeScheme2;
			this.marqueeControl1.Size = new System.Drawing.Size( 895 , 42 );
			this.marqueeControl1.TabIndex = 11;
			// 
			// ScreenSaver
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.Controls.Add( this.panel1 );
			this.Controls.Add( this.marqueeControl );
			this.Controls.Add( this.marqueeControl1 );
			this.Name = "ScreenSaver";
			this.Size = new System.Drawing.Size( 895 , 682 );
			this.Paint += new System.Windows.Forms.PaintEventHandler( this.ScreenSaver_Paint );
			this.panel1.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.Timer timer;
		private SwmSuite.Presentation.Common.Marquee.MarqueeControl marqueeControl;
		private System.Windows.Forms.Panel panel1;
		private SwmSuite.Presentation.Common.AnalogClock.NiceAnalogClockControl niceAnalogClockControl1;
		private SwmSuite.Presentation.Common.Marquee.MarqueeControl marqueeControl1;

	}
}
