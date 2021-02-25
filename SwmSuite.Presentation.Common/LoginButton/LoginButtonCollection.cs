using System;
using System.Collections.Generic;

using System.Text;
using System.Collections;

namespace SwmSuite.Presentation.Common.LoginButton {
	
	public class LoginButtonCollection {

		#region -_ Private Members _-

		List<LoginButtonControl> _list = new List<LoginButtonControl>();

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public LoginButtonCollection() {
		}

		#endregion

		#region -_ Public Methods _-

		public void Add( LoginButtonControl item ){
			_list.Add( item );
		}

		public void Remove( LoginButtonControl item ){
			_list.Remove( item );
		}

		public void Clear(){
			_list.Clear();
		}

		#endregion

	}

}
