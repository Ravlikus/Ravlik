using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task12_7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace Task12_7.Tests
{
    [TestClass()]
    public class BinaryTreeTests
    {
        [TestMethod()]
        public void AddingAndContain()
        {
            var tree = new BinaryTree<string>();
            tree.Add("Привет");
            tree.Add(" ");
            tree.Add("Мир");
            tree.Add("!!!");
            Assert.AreEqual(true, tree.Contain("Привет"));
            Assert.AreEqual(true, tree.Contain("Мир"));
            Assert.AreEqual(true, tree.Contain(" "));
            Assert.AreEqual(true, tree.Contain("!!!"));
            var pointTree = new BinaryTree<Point>();
            pointTree.CompareMethod = (a, b) => a.X - b.X;
            var pointValues = new[] { new Point(0, 0), new Point(-1, 0), new Point(1, 0) };
            foreach(var point in pointValues)
            {
                pointTree.Add(point);
                Assert.AreEqual(true, pointTree.Contain(point));
            }
            var bookTree = new BinaryTree<Book>();
            var bookValues = new[] { new Book(5), new Book(4), new Book(6) };
            foreach (var book in bookValues)
            {
                bookTree.Add(book);
                Assert.AreEqual(true, bookTree.Contain(book));
            }
        }

        [TestMethod()]
        public void Removing()
        {
            var tree = new BinaryTree<string>();
            tree.Add("Привет");
            tree.Add(" ");
            tree.Add("Мир");
            tree.Add("!!!");
            tree.Remove("Привет");
            Assert.AreEqual(false, tree.Contain("Привет"));
            Assert.AreEqual(true, tree.Contain("Мир"));
            Assert.AreEqual(true, tree.Contain(" "));
            Assert.AreEqual(true, tree.Contain("!!!"));
        }

        [TestMethod()]
        public void RemovingFunctionalTest()
        {
            var rnd = new Random();
            for (int i = 0; i < 1000; i++)
            {
                var numsCount = rnd.Next(1,10);
                var values = new int[numsCount];
                var tree = new BinaryTree<int>();
                for(int j = 0; j < numsCount; j++)
                {
                    var value = rnd.Next(numsCount * 4);
                    while(values.Contains(value))
                    {
                        value = rnd.Next(numsCount * 4);
                    }
                    values[j] = value;
                    tree.Add(values[j]);
                }
                var removedValue = values[rnd.Next(numsCount)];
                tree.Remove(removedValue);
                for (int j = 0; j < numsCount; j++)
                {
                    if (values[j]!=removedValue)
                    {
                        Assert.AreEqual(true, tree.Contain(values[j]));
                    }
                    else
                    {
                        Assert.AreEqual(false, tree.Contain(values[j]));
                    }
                }
            }
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            var tree = new BinaryTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);
            tree.Add(2);
            tree.Add(4);
            tree.Add(7);
            tree.Add(6);
            tree.Add(9);
            tree.TranseverceOrder = BinaryTree<int>.TranseverceOption.PreOrder;
            var expected = new[] { 5,3,2,4,8,7,6,9 };
            int i = 0;
            foreach(var value in tree)
            {
                Assert.AreEqual(expected[i], value);
                i++;
            }
            i = 0;
            tree.TranseverceOrder = BinaryTree<int>.TranseverceOption.InOrder;
            expected = new[] {2,3,4,5,6,7,8,9};
            foreach (var value in tree)
            {
                Assert.AreEqual(expected[i], value);
                i++;
            }
            i = 0;
            tree.TranseverceOrder = BinaryTree<int>.TranseverceOption.PostOrder;
            expected = new[] { 2,4,3,6,7,9,8,5};
            foreach (var value in tree)
            {
                Assert.AreEqual(expected[i], value);
                i++;
            }
        }

        class Book : IComparable
        {
            public int BookNumber;

            public Book(int bookNum)
            {
                BookNumber = bookNum;
            }

            public int CompareTo(object obj)
            {
                var b = obj as Book;
                return BookNumber - b.BookNumber;
            }
        }

        struct Point
        {
            public int X;
            public int Y;

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

    }
}