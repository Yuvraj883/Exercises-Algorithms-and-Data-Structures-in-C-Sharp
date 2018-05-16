﻿using System;
/*
Stack implementation using my linked list implementation.
We can implement our own (faster) count rather than LinkedList.Count() 
because we don't allow access to the list directly.
*/
namespace PracticeQuestionsSharp.DataStructures
{
    public class Stack<T>
    {
        public Stack()
        {
            list = new LinkedList<T>();
            Count = 0;
        }

        public Stack<T> Push(T data)
        {
            list.Add(data);
            Count++;
            return this;
        }

        public T Pop()
        {
            if (IsEmpty) throw new InvalidOperationException("Stack empty.");
            T result = list.Tail.Data;
            list.RemoveNode(list.Tail);
            Count--;
            return result;
        }

        public T Peek()
        {
            return list.Tail.Data;
        }

        public void Clear()
        {
            list.Clear();
            Count = 0;
        }

        public bool IsEmpty => Count == 0;
        public int Count { get; private set; }

        private readonly LinkedList<T> list;
    }
}