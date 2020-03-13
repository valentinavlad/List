using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntegerArrayWithReallocation
{
    public class ListTests
    {
        [Fact]
        public void CheckIntArray()
        {
            //svar x = new SortedList<ListTests>();
            var arrayInt = new List<int>();
            arrayInt.Add(5);
            arrayInt.Add(8);
            arrayInt.Add(8);
            arrayInt.Insert(2, 7);
            
            Assert.Equal(7, arrayInt[2]);

        }

        [Fact]
        public void CheckDoubleArray()
        {
            var arrayInt = new List<double>();
            arrayInt.Add(5.56);
            arrayInt.Add(8.995);
            arrayInt.Add(56.22);
            arrayInt.Insert(2, 17.6597);
            Assert.Equal(17.6597, arrayInt[2]);
        }

        [Fact]
        public void CheckCharArray()
        {
            var arrayInt = new List<char>();
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
            var arrayInt = new List<char>();
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
            var arr = new List<int> { 3, 4, 5 };

            arr.Add(6);
            arr.Add(8);

            IEnumerator<int> enumerator = arr.GetEnumerator();
            Assert.True(enumerator.MoveNext());

            enumerator.MoveNext();
            Assert.Equal(4, enumerator.Current);
        }

        [Fact]
        public void CheckRemove()
        {
            var arrayInt = new List<int>();
            arrayInt.Add(2);
            arrayInt.Add(38);
            arrayInt.Add(4);

            Assert.True(arrayInt.Remove(2));
            Assert.Equal(2, arrayInt.Count);

        }

        [Fact]
        public void CheckIfCopyToReturnNewArray()
        {
            var arrayInt = new List<int> { 5, 8, 9, 55, 2, 3 }; //count =6
            int[] arr = new int[8];

            arrayInt.CopyTo(arr, 2);
            //0 0 5 8 9 55 2 3
            //		0 5 8 9 55 0 0
            Assert.Equal(0, arr[0]);
            Assert.Equal(5, arr[2]);

        }

        [Fact]
        public void InsertThrowError()
        {
            //arrange
            var c = new List<int>() { 2,6 };
          
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => c.Insert(-1, 9));
            var ex1 = Assert.Throws<ArgumentOutOfRangeException>(() => c.Insert(3, 9));
            c.Insert(1, 5);
            //assert
            Assert.Equal("Index is out of range (Parameter 'index')", ex.Message);
            Assert.Equal("Index is out of range (Parameter 'index')", ex1.Message);
            Assert.Equal(5, c[1]);
        }

        [Fact]
        public void CheckIfListIsReadOnly()
        {
            var arrayInt = new List<int> { 5, 8, 9, 55, 2, 3 };
            IList<int> readlist = arrayInt.AsReadOnly();
             //arunca o eroare
            var ex_add = Assert.Throws<NotSupportedException>(() => readlist.Add(889));
            var ex_remove = Assert.Throws<NotSupportedException>(() => readlist.Remove(0));
            var ex_clear = Assert.Throws<NotSupportedException>(() => readlist.Clear());
            var ex_insert = Assert.Throws<NotSupportedException>(() => readlist.Insert(0,8));
            var ex_set = Assert.Throws<NotSupportedException>(() => readlist[0]=6);

            Assert.Equal("Collection is read-only.", ex_add.Message);
            Assert.Equal("Collection is read-only.", ex_remove.Message);
            Assert.Equal("Collection is read-only.", ex_clear.Message);
            Assert.Equal("Collection is read-only.", ex_insert.Message);
            Assert.Equal("Collection is read-only.", ex_set.Message);
        }
    }
}
