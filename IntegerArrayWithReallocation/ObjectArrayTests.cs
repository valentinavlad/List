using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntegerArrayWithReallocation
{
    public class ObjectArrayTests
    {
        [Fact]
        public void CheckIntArray()
        {
            var arrayInt = new ObjectArray();
            arrayInt.Add(5);
            arrayInt.Add(8);
            arrayInt.Add(8);
            arrayInt.Insert(2, 7);
            Assert.Equal(7, arrayInt[2]);
        }

        [Fact]
        public void CheckDoubleArray()
        {
            var arrayInt = new ObjectArray();
            arrayInt.Add(5);
            arrayInt.Add(8.995);
            arrayInt.Add('h');
            arrayInt.Insert(2, 17.6597);
            Assert.Equal(17.6597, arrayInt[2]);
        }

        [Fact]
        public void CheckCharArray()
        {
            var arrayInt = new ObjectArray();
            arrayInt.Add('a');
            arrayInt.Add('p');
            arrayInt.Add('l');
            arrayInt.Add('e');
            arrayInt.Insert(2, 'p');
            Assert.Equal('p', arrayInt[2]);
        }

        [Fact]

        public void CheckRemoveAtShouldReturnChangedArray()
        {
            var arrayInt = new ObjectArray();
            arrayInt.Add('a');
            arrayInt.Add('p');
            arrayInt.Add('l');
            arrayInt.Add('e');
            arrayInt.Insert(2, 'p');

            //pple
            arrayInt.RemoveAt(0);
            Assert.Equal('p', arrayInt[0]);
        }

        [Fact]

        public void CheckIfEnumerableWorks()
        {
            var arr = new ObjectArray { 3,  4, 5 };
            arr.Add(6);
            arr.Add(8);
     
            IEnumerator enumerator = arr.GetEnumerator();
            Assert.True(enumerator.MoveNext());

            enumerator.MoveNext();
            Assert.Equal(4, enumerator.Current);
        }

    }
}
