using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SimpleWorkfloorManagementSuite.Controls {
	
	public class TaskContentsScheme {

		#region -_ Public Properties _-

		public Color BorderColor { get; set; }

		public Color TitleBackgroundColor1 { get; set; }

		public Color TitleBackgroundColor2 { get; set; }

		public Color TextColor { get; set; }

		public Font BigFont { get; set; }

		public Font SmallFont { get; set; }

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Initializes a new instance of the <see cref="MessageContentsScheme"/> class.
		/// </summary>
		public TaskContentsScheme() {
			this.BorderColor = Color.FromArgb( 0 , 0 , 0 );
			this.TitleBackgroundColor1 = Color.FromArgb( 10, 75, 115 );
			this.TitleBackgroundColor2 = Color.FromArgb( 50, 175, 175 );
			this.TextColor = Color.FromArgb( 0 , 28 , 191 );
			this.BigFont = new Font( "Verdana" , 11.0f , FontStyle.Bold );
			this.SmallFont = new Font( "Verdana" , 10.0f , FontStyle.Regular );
		}

		#endregion

	}

}
