using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IntegerArrayWithReallocation
{
    public class ReadOnlyList<T> : IList<T>
    {
        private readonly IList<T> elements;

        public ReadOnlyList(IList<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list), "List is null.");
            }
            elements = list;
        }
        
        public T this[int index]
        {
            get => elements[index];
            set { throw new NotSupportedException("Collection is read-only."); }
        }

        public int Count { get => elements.Count; }

        public bool IsReadOnly => true;

        public void Add(T item)
        {
            throw new NotSupportedException("Collection is read-only.");
        }

        public void Clear()
        {
            throw new NotSupportedException("Collection is read-only.");
        }

        public bool Contains(T value) => elements.Contains(value);

        public void CopyTo(T[] array, int index) => elements.CopyTo(array, index);
      

        public IEnumerator<T> GetEnumerator() => elements.GetEnumerator();
        

        public int IndexOf(T value) => elements.IndexOf(value);
   

        public void Insert(int index, T item)
        {
            throw new NotSupportedException("Collection is read-only.");
        }

        public bool Remove(T item)
        {
            throw new NotSupportedException("Collection is read-only.");
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException("Collection is read-only.");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return elements.GetEnumerator();
        }
    }
}
