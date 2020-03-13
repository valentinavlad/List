using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IntegerArrayWithReallocation
{
    public class List<T> : IList<T>
    {
        private T[] elements;
        private int count = 0;
        private int capacity = 4;

        private void CheckArrayCapacity()
        {
            if (count == capacity)
            {
                this.capacity *= 2;
                Array.Resize(ref elements, capacity);
            }
        }

        private void ShiftRight(int index)
        {
            CheckArrayCapacity();
            for (int i = Count - 1; i >= index; i--)
            {
                elements[i + 1] = elements[i];
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < elements.Length - 1; i++)
            {
                elements[i] = elements[i + 1];
            }
        }

        private void CheckIndexRange(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
            }
        }

        public List()
        {
            elements = new T[this.capacity];
        }

        public virtual void Add(T element)
        {
            CheckArrayCapacity();
            elements[count] = element;
            count++;
        }

        public int Count
        {
            get => count;
            set => count = value;

        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public  IList<T> AsReadOnly()
        {
            return new ReadOnlyList<T>(this);
        }
        
        public virtual T this[int index]
        {
            get
            {
                CheckIndexRange(index);
                return elements[index];
            }
            set
            {
                CheckIndexRange(index);
                elements[index] = value;
            }
        }

        public bool Contains(T element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (elements[i].Equals(element))
                {
                    return i;
                }
            }
            return -1;
        }

        public virtual void Insert(int index, T element)
        {
            CheckIndexRange(index);
            ShiftRight(index);
            elements[index] = element;
            count++;
        }

        public void Clear()
        {
            elements = new T[0];
        }

        public bool Remove(T element)
        {
            int index = IndexOf(element);
            if (index >= 0 && index <= Count - 1)
            {
                RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveAt(int index)
        {
            CheckIndexRange(index);
            ShiftLeft(index);
            count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Array is null.");
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Index is less than zero.");
            }
            if ((array.Length - arrayIndex) < Count)
            {
                throw new ArgumentException(nameof(arrayIndex), "The number of elements in the array is greater than the available space from index to the end of the destination array");
            }

            for (int i = arrayIndex; i <= Count; i++)
            {
                array[i] = elements[i - arrayIndex];
            }
        }

    }
}
