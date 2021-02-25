using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SimpleWorkfloorManagementSuite {
	public partial class SplashForm : Form {
		
		public SplashForm() {
			InitializeComponent();
		}

		private void SplashForm_Load( object sender , EventArgs e ) {
			//this.Region = splashControl1.SplashRegion;
			//Thread.Sleep( 10000 );
		}

		private void closeSplashTimer_Tick( object sender , EventArgs e ) {
			this.Close();
		}
	}
}
