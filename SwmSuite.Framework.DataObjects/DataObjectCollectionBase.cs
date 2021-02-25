using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.Xml;

namespace SwmSuite.Data.DataObjects {

	/// <summary>
	/// A base class for creating object collections.
	/// </summary>
	/// <typeparam name="T">A type to create a collection for.</typeparam>
	public class DataObjectCollectionBase<T> : IEnumerable<T> {

		#region -_ Private Members _-

		private Collection<T> _list;

		#endregion

		#region -_ Public Properties _-

		/// <summary>
		/// Gets the number of elements this collection contains.
		/// </summary>
		public int Count {
			get {
				return _list.Count;
			}
		}

		#endregion

		#region -_ Construction _-

		/// <summary>
		/// Default constructor.
		/// </summary>
		public DataObjectCollectionBase() {
			_list = new Collection<T>();
		}

		#endregion

		#region -_ Public Methods _-

		/// <summary>
		/// Gets or sets the element at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index of the element to get or set.</param>
		/// <returns>The element at the specified index.</returns>
		public T this[int index] {
			get {
				return (T)_list[index];
			}
			set {
				_list[index] = value;
			}
		}

		/// <summary>
		/// Determines the index of a specific element in the TaskCollection.
		/// </summary>
		/// <param name="element">The element to locate in the TaskCollection.</param>
		/// <returns>The index of element if found in the TaskCollection; otherwise, -1.</returns>
		public int IndexOf( T element ) {
			return _list.IndexOf( element );
		}

		/// <summary>
		/// Adds an element to the TaskCollection.
		/// </summary>
		/// <param name="element">The element to add to the TaskCollection. </param>
		/// <returns>The position into which the new element was inserted.</returns>
		public void Add( T element ) {
			_list.Add( element );
		}

		/// <summary>
		/// Adds an element to the TaskCollection.
		/// </summary>
		/// <param name="element">The element to add to the TaskCollection. </param>
		/// <returns>The position into which the new element was inserted.</returns>
		public void Add( DataObjectCollectionBase<T> elements ) {
			foreach( T obj in elements ) {
				_list.Add( obj );
			}
		}

		/// <summary>
		/// Removes the first occurrence of a specific element from the TaskCollection.
		/// </summary>
		/// <param name="element">The element to remove from the TaskCollection.</param>
		public void Remove( T element ) {
			_list.Remove( element );
		}

		/// <summary>
		/// Convert this collection to a generic array.
		/// </summary>
		/// <returns>An array containing</returns>
		public T[] ToArray() {
			return _list.ToArray();
		}

		/// <summary>
		/// Serialize this collection to an xml document.
		/// </summary>
		/// <returns>A string representing an xml document defining this collection.</returns>
		public string Serialize() {
			XmlSerializer serializer = new XmlSerializer( typeof( DataObjectCollectionBase<T> ) );
			StringBuilder stringBuilder = new StringBuilder();
			XmlWriter writer = XmlWriter.Create( stringBuilder );
			serializer.Serialize( writer , this );
			writer.Flush();
			writer.Close();
			return stringBuilder.ToString();
		}

		#endregion




		#region IEnumerable<T> Members

		public IEnumerator<T> GetEnumerator() {
			return new DataObjectCollectionBaseEnumerator<T>( _list );
		}

		#endregion

		#region IEnumerable Members

		IEnumerator IEnumerable.GetEnumerator() {
			return new DataObjectCollectionBaseEnumerator<T>( _list );
		}

		#endregion
	}

}
