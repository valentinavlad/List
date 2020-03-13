using System;
using System.Collections.Generic;
using System.Text;

namespace IntegerArrayWithReallocation
{
    class SortedList<T> : List<T> where T : IComparable<T>
    {

        public override void Add(T element)
        {
            base.Insert(FindInsertPosition(element), element);
        }

        private int FindInsertPosition(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                //this[i] >= element
                if (this[i].CompareTo(element) >= 0)
                {
                    return i;
                }
            }

            return Count;
        }

        public override T this[int index]
        {
            set
            {
                if (IsIndexInRange(index) &&
                            (IsValidFirstElem(index, value) || IsValidLastElem(index, value)
                            || IsValidElemInRange(index, value, this[index + 1])))
                {
                    base[index] = value;
                }

            }
        }

        public override void Insert(int index, T element)
        {
            if (!IsIndexInRange(index))
            {
                return;
            }
            if (IsValidFirstElem(index, element) || IsValidElemInRange(index, element, this[index]))
            {
                base.Insert(index, element);
            }
            if (IsValidLastElem(index, element))
            {
                base.Insert(index + 1, element);
            }
        }

        public bool IsValidLastElem(int index, T element)
        {
            return index == Count - 1 && element.CompareTo(this[index]) >= 0;
        }

        public bool IsValidFirstElem(int index, T element)
        {
            return index == 0 && element.CompareTo(this[index]) <= 0;
        }

        public bool IsValidElemInRange(int index, T element, T superiorElem)
        {
            return index >= 1 && index < Count - 1
                && element.CompareTo(this[index - 1]) >= 0 && element.CompareTo(superiorElem) <= 0;
        }

        public bool IsIndexInRange(int index)
        {
            return index >= 0 && index <= Count - 1;
        }

    }
}
