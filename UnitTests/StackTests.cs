﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeQuestionsSharp.DataStructures;
using PracticeQuestionsSharp.Exercises.Stack;

namespace UnitTests
{
    //Unit tests for stack.
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void CanCreateNewStackValueType()
        {
            Stack<int> stack = new Stack<int>();

            Assert.IsNotNull(stack);
        }

        [TestMethod]
        public void CanCreateNewStackReferenceType()
        {
            Stack<DummyClass> stack = new Stack<DummyClass>();

            Assert.IsNotNull(stack);
        }

        [TestMethod]
        public void PushOntoStackCorrectlyAddsItem()
        {
            Stack<int> stackValueType = new Stack<int>();
            Stack<DummyClass> stackReferenceType = new Stack<DummyClass>();

            stackValueType.Push(3);
            stackReferenceType.Push(new DummyClass());

            Assert.AreEqual(3, stackValueType.Peek());
            Assert.AreEqual("method", stackReferenceType.Peek().DummyMethod());
        }

        [TestMethod]
        public void PopFromStackCorrectlyRemovesItem()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(3).Push(4).Push(5);

            int stackPop1 = stack.Pop();
            int stackPop2 = stack.Pop();

            Assert.AreEqual(5, stackPop1);
            Assert.AreEqual(4, stackPop2);
            Assert.AreEqual(3, stack.Peek());
        }

        [TestMethod]
        public void PopFromEmptyStackThrowsException()
        {
            Stack<int> stack = new Stack<int>();

            Assert.ThrowsException<InvalidOperationException>(() => stack.Pop());
        }

        [TestMethod]
        public void PeekReturnsCorrectItem()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(3).Push(2);

            Assert.AreEqual(2, stack.Peek());
        }

        [TestMethod]
        public void EmptyIsCorrect()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(3);

            bool notEmpty = stack.IsEmpty;
            stack.Pop();
            bool empty = stack.IsEmpty;

            Assert.AreEqual(false, notEmpty);
            Assert.AreEqual(true, empty);
        }

        [TestMethod]
        public void ClearEmptiesStack()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(3).Push(2);

            stack.Clear();

            Assert.AreEqual(true, stack.IsEmpty);
        }

        [TestMethod]
        public void CountIsCorrect()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(3).Push(2);

            int stackCount2 = stack.Count;
            int stackCount3 = stack.Push(1).Count;
            stack.Clear();

            Assert.AreEqual(2, stackCount2);
            Assert.AreEqual(3, stackCount3);
            Assert.AreEqual(0, stack.Count);
        }
    }

    [TestClass]
    public class StackExtensionTests
    {
        [TestMethod]
        public void CanSortInts()
        {
            Stack<int> stackToSort = new Stack<int>();
            for (int i = 150; i >= 0; --i)
            {
                stackToSort.Push(i);
            }

            stackToSort.Sort();

            int prev = stackToSort.Pop();

            while (!stackToSort.IsEmpty)
            {
                Assert.IsTrue(prev.CompareTo(stackToSort.Peek()) < 1);
                prev = stackToSort.Pop();
            }
        }

        [TestMethod]
        public void CanSortStrings()
        {
            Stack<string> stackToSort = new Stack<string>();
            for (int i = 150; i >= 0; --i)
            {
                stackToSort.Push(i.ToString());
            }

            stackToSort.Sort();

            string prev = stackToSort.Pop();

            while (!stackToSort.IsEmpty)
            {
                Assert.IsTrue(prev.CompareTo(stackToSort.Peek()) < 1);
                prev = stackToSort.Pop();
            }
        }
    }
}
