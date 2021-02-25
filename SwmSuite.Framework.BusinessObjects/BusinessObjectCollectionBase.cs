using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections;
using System.Xml.Serialization;
using System.Xml;

namespace SwmSuite.Data.BusinessObjects {

	/// <summary>
	/// A base class for creating object collections.
	/// </summary>
	/// <typeparam name="T">A type to create a collection for.</typeparam>
	[Serializable]
	[XmlType( Namespace = "SwmSuite_v1" )]
	public class BusinessObjectCollectionBase<T> : IEnumerable<T> {

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
		public BusinessObjectCollectionBase() {
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
		/// Determines the index of a specific element in this collection.
		/// </summary>
		/// <param name="element">The element to locate in this collection.</param>
		/// <returns>The index of element if found in this collection; otherwise, -1.</returns>
		public int IndexOf( T element ) {
			return _list.IndexOf( element );
		}

		/// <summary>
		/// Adds an element to this collection.
		/// </summary>
		/// <param name="element">The element to add to this collection. </param>
		/// <returns>The position into which the new element was inserted.</returns>
		public void Add( T element ) {
			_list.Add( element );
		}

		/// <summary>
		/// Adds an element to this collection.
		/// </summary>
		/// <param name="element">The element to add to this collection. </param>
		/// <returns>The position into which the new element was inserted.</returns>
		public void Add( BusinessObjectCollectionBase<T> elements ) {
			foreach( T obj in elements ) {
				_list.Add( obj );
			}
		}

		/// <summary>
		/// Removes the first occurrence of a specific element from this collection.
		/// </summary>
		/// <param name="element">The element to remove from this collection.</param>
		public void Remove( T element ) {
			_list.Remove( element );
		}

		/// <summary>
		/// Removes all specified elements from this collection.
		/// </summary>
		/// <param name="elements">The elements.</param>
		public void Remove( BusinessObjectCollectionBase<T> elements ) {
			foreach( T element in elements ) {
				this.Remove( element );
			}
		}

		/// <summary>
		/// Removes all elements from this collection.
		/// </summary>
		public void Clear() {
			_list.Clear();
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
			XmlSerializer serializer = new XmlSerializer( typeof( BusinessObjectCollectionBase<T> ) );
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
			return new BusinessObjectCollectionBaseEnumerator<T>( _list );
		}

		#endregion

		#region IEnumerable Members

		IEnumerator IEnumerable.GetEnumerator() {
			return new BusinessObjectCollectionBaseEnumerator<T>( _list );
		}

		#endregion
	}

}