using System;
using Xunit;

namespace IntegerArrayWithReallocation
{
    public class IntArrayTests
    {
        [Fact]
        public void CheckIfElementIsAddedCorrectly()
        {
            var sir = new IntArray();
            sir.Add(5);
            sir.Add(2);
            sir.Add(8);
            sir.Add(9);

            Assert.Equal(5, sir[0]);

        }

        [Fact]
        public void CheckSizeOfArrayAfterElementsAreAdded()
        {
            var sir = new IntArray();
            sir.Add(5);
            sir.Add(2);
            sir.Add(8);
  
            int length = sir.Count;
            Assert.Equal(3, length);

        }
        [Fact]
        public void CheckIfArrayDoublesSize()
        {
            var sir = new IntArray();
            sir.Add(5);
            sir.Add(2);
            sir.Add(8);
            sir.Add(9);
            sir.Add(56);

            Assert.Equal(56, sir[4]);
           // Assert.Equal(-1, sir.Element(10));
        }

        [Fact]

        public void CheckIndexOfShouldReturnTrue()
        {
            var sir = new IntArray();
            sir.Add(5);
            sir.Add(2);
            sir.Add(8);
            sir.Add(9);

            Assert.Equal(1, sir.IndexOf(2));
        }
        [Fact]

        public void CheckClearShouldReturnZero()
        {
            var sir = new IntArray();
            sir.Add(5);
            sir.Add(2);
            sir.Add(8);
            sir.Add(9);
            sir.Clear();
            Assert.Equal(4, sir.Count);
      
        }

        [Fact]

        public void CheckInsertShouldReturn()
        {
            var sir = new IntArray();
            sir.Add(5);
            sir.Add(8);
            sir.Add(9);
            sir.Insert(2, 7);
            Assert.Equal(7, sir[2]);    
        }

        [Fact]
        public void CheckInsert()
        {
            var sir = new IntArray();
            sir.Add(5);
            sir.Add(8);
            sir.Add(9);
            sir.Add(92);
            sir.Insert(2, 7);
            Assert.Equal(92, sir[4]);
        }

        [Fact]
        public void CheckElementIndex()
        {
            var sir = new IntArray();
            sir.Add(1);
            sir[0] = 2;
            sir.Add(8);
            sir.Add(9);
            sir.Add(92);
            Assert.Equal(2, sir[0]);
        }

        [Fact]

        public void CheckRemoveAtShouldReturnChangedArray()
        {
            var sir = new IntArray();
            sir.Add(5);
            sir.Add(8);
            sir.Add(9);
            sir.Add(8);
            sir.Add(88);

            sir.RemoveAt(0);
            Assert.Equal(8, sir[0]);
            Assert.Equal(88, sir[3]);
        }
    }
}
