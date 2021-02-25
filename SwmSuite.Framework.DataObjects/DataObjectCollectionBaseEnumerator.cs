using System;
using System.Collections.Generic;

using System.Text;
using System.Collections.ObjectModel;

namespace SwmSuite.Data.DataObjects {

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class DataObjectCollectionBaseEnumerator<T> : IEnumerator<T> {

		#region -_ Private Members _-

		private Collection<T> _list;
		private T _current;

		#endregion

		#region -_ Construction _-

		public DataObjectCollectionBaseEnumerator( Collection<T> list ) {
			_list = list;
			_current = default( T );
		}

		#endregion

		#region IEnumerator Members

		public object Current {
			get {
				return _current;
			}
		}

		public bool MoveNext() {
			int currentIndex = _list.IndexOf( _current );
			bool toReturn = currentIndex < _list.Count - 1;
			if( toReturn ) {
				_current = _list[currentIndex + 1];
			}
			return toReturn;
		}

		public void Reset() {
			_current = default( T );
		}

		#endregion

		#region IEnumerator<T> Members

		T IEnumerator<T>.Current {
			get {
				return _current;
			}
		}

		#endregion

		#region IDisposable Members

		public void Dispose() {
			GC.SuppressFinalize( this );
		}

		#endregion
	}

}
