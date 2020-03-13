using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IntegerArrayWithReallocation
{
    public class ObjectArray : IEnumerable
    {
        private object[] elements;
        private int count = 0;
        private int capacity = 4;

        public ObjectArray()
        {
            elements = new object[this.capacity];
        }

        public void Add(object element)
        {
            CheckArrayCapacity();
            elements[count] = element;
            count++;
        }
        private void CheckArrayCapacity()
        {
            if (count == capacity)
            {
                this.capacity *= 2;
                Array.Resize(ref elements, capacity);
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
            }
        }

        public object this[int index]
        {
            get => elements[index];
            set => elements[index] = value;
        }

        public bool Contains(object element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(object element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (elements[i] == element)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, object element)
        {
            if (index < 0 || index > elements.Length)
            {
                return;
            }
            ShiftRight(index);
            elements[index] = element;
            count++;
        }

        private void ShiftRight(int index)
        {
            CheckArrayCapacity();
            for (int i = Count - 1; i >= index; i--)
            {
                elements[i + 1] = elements[i];
            }
        }

        public void Clear()
        {
            elements = new object[0];
        }

        public void Remove(int element)
        {
            int index = IndexOf(element);
            RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > elements.Length)
            {
                return;
            }
            ShiftLeft(index);
            Array.Resize(ref elements, elements.Length - 1);
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < elements.Length - 1; i++)
            {
                elements[i] = elements[i + 1];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

       /* public ObjectArrayEnum GetEnumerator()
        {
            return new ObjectArrayEnum(this);
        }*/

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return elements[i];
            }
        }  

    }
}
