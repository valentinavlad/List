using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IntegerArrayWithReallocation
{
    public class ObjectArrayEnum :  IEnumerator
    {
        ObjectArray elements;
        int position = -1;

        public ObjectArrayEnum(ObjectArray list)
        {
            elements = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < elements.Count);
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public object Current
        {
            get
            {
                try
                {
                    return elements[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
