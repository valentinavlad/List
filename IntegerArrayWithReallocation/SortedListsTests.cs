using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntegerArrayWithReallocation
{
    public class SortedListsTests
    {
        [Fact]
        public void AddShouldReturnSortedArray()
        {
            var intArraySorted = new SortedList<int>();

            intArraySorted.Add(9);
            intArraySorted.Add(2);
            intArraySorted.Add(3);
            intArraySorted.Add(1);
            intArraySorted.Add(6);
            intArraySorted.Add(5);
            intArraySorted.Add(2);
            //1 2 2 3 5 6 9
            Assert.Equal(9, intArraySorted[6]);
            Assert.Equal(2, intArraySorted[2]);
            Assert.Equal(2, intArraySorted[1]);
        }

        [Fact]
        public void AddShouldReturnSortedArray2()
        {
            var intArraySorted = new SortedList<int>();

            intArraySorted.Add(9);
            intArraySorted.Add(2);
            intArraySorted.Add(3);

            intArraySorted.Add(15);
            intArraySorted.Add(18);
            //2 3 9 15 18

            Assert.Equal(15, intArraySorted[3]);
            Assert.Equal(18, intArraySorted[4]);

        }

        [Fact]
        public void InsertShouldReturnSortedArray()
        {
            var intArraySorted = new SortedList<int>();

            intArraySorted.Add(1);//0
            intArraySorted.Add(2);//1
            intArraySorted.Add(4);//2
            intArraySorted.Add(6);//3

            intArraySorted.Insert(3, 7);
            //1 2 4 6 7
            intArraySorted.Insert(2, 5); //e ok, nu insereaza

            Assert.Equal(6, intArraySorted[3]);
            Assert.Equal(7, intArraySorted[4]);
        }

        [Fact]
        public void InsertShouldReturnSortedArray2()
        {
            var intArraySorted = new SortedList<int>();

            intArraySorted.Add(2);
            intArraySorted.Add(4);
            intArraySorted.Add(6);//poz 2
            intArraySorted.Add(8);

            intArraySorted.Insert(1, 3);//ok
            intArraySorted.Insert(5, 3);//nu

            //2 3 4 6 8
            Assert.Equal(3, intArraySorted[1]);
            Assert.Equal(0, intArraySorted[5]);

        }


        [Fact]

        public void CheckRemoveAtShouldReturnChangedSortedArray()
        {
            var intArraySorted = new SortedList<int>();
            intArraySorted.Add(9);
            intArraySorted.Add(2);
            intArraySorted.Add(3);
            intArraySorted.Add(1);
            intArraySorted.Add(6);
            intArraySorted.Add(5);
            intArraySorted.Add(2);

            intArraySorted.RemoveAt(4);
            //1 2 2 3 6 9
            Assert.Equal(9, intArraySorted[5]);
            Assert.Equal(2, intArraySorted[2]);
        }

        [Fact]
        public void SetElementShouldReturnArrayWithChangedValue()
        {
            var intArraySorted = new SortedList<int>();

            intArraySorted.Add(1);
            intArraySorted.Add(2);
            intArraySorted.Add(3);
            intArraySorted.Add(5);

            intArraySorted[0] = 3;
            intArraySorted[4] = 4;
            intArraySorted[2] = 4;
            intArraySorted[2] = 6;
            intArraySorted[3] = 6;
            //1 2 4 6
            Assert.Equal(4, intArraySorted[2]);
            //Assert.Equal(0, intArraySorted[4]);
        }


        [Fact]
        public void StringTypeReturnArraySorted()
        {
            var intArraySorted = new SortedList<char>();

            intArraySorted.Add('b');
            intArraySorted.Add('c');
            intArraySorted.Add('e');
            intArraySorted.Add('a');

            Assert.Equal('a', intArraySorted[0]);
            Assert.Equal('e', intArraySorted[3]);
        }
    }
}
