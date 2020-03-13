using System;
using System.Collections.Generic;
using System.Text;

namespace IntegerArrayWithReallocation
{
    class SortedIntArray : IntArray
    {
        public SortedIntArray()
        {
        }

        public override void Add(int element)
        {
            base.Insert(FindInsertPosition(element), element);
        }

   
        private int FindInsertPosition(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i] >= element)
                {
                    return i;
                }
            }

            return Count;
        }

        public override int this[int index]
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

        public override void Insert(int index, int element)
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

        public bool IsValidLastElem(int index, int element)
        {
            return index == Count - 1 && element >= this[index];
        }

        public bool IsValidFirstElem(int index, int element)
        {
            return index == 0 && element <= this[index];
        }

        public bool IsValidElemInRange(int index, int element, int superiorElem)
        {
            return index >= 1 && index < Count - 1
                && element >= this[index - 1] && element <= superiorElem;
        }

        public bool IsIndexInRange(int index)
        {
            return index >= 0 && index <= Count - 1;
        }
    }
}
