using System;
using System.Collections.Generic;
using System.Text;

namespace IntegerArrayWithReallocation
{
    class IntArray
    {
        private int[] elements;
        private int count = 0;
        private int capacity = 4;

        public IntArray()
        {
            elements = new int[this.capacity];
        }

        public virtual void Add(int element)
        {
            CheckArrayCapacity();
            elements[count] = element;
            count++;
        }

        public void CheckArrayCapacity()
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
            private set
            {
                count = value;
            }
        }

        public virtual int this[int index]
        {
            get => elements[index];
            set => elements[index] = value;
        }

        public bool Contains(int element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(int element)
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

        public virtual void Insert(int index, int element)
        {
            if (index < 0 || index > Count)
            {
                return;
            }
            CheckArrayCapacity();
            ShiftRight(index);
            elements[index] = element;
            count++;
        }

        public void ShiftRight(int index)
        {
            for (int i = Count - 1; i >= index; i--)
            {
                elements[i + 1] = elements[i];
            }
        }

        public void Clear()
        {
            elements = new int[0];
        }

        public void Remove(int element)
        {	
            int index = IndexOf(element);
            RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > Count)
            {
                return;
            }
            ShiftLeft(index);
            count--;
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < elements.Length - 1; i++)
            {
                elements[i] = elements[i + 1];
            }
        }
    }
}
