using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_5
{
    public class Solution
    {
        public class Stack<T>
        {
            private StackElement<T> head;
            private StackElement<T> tail;
            private int count = 0;
            public int Count { get { return count; } }

            public Stack() { }

            public void Push(T element)
            {
                if (count == 0)
                {
                    head = new StackElement<T>(element);
                    tail = head;
                }

                else
                {
                    var newTail = new StackElement<T>(element);
                    tail.Previous = newTail;
                    newTail.Next = tail;
                    tail = newTail;
                }

                count++;
            }

            public T Pop()
            {
                if (count == 0) throw new Exception("Stack is empty!");
                var result = tail;
                tail = tail.Next;
                count--;
                return result.Value;
            }

            private class StackElement<T>
            {
                public T Value;
                public StackElement<T> Previous;
                public StackElement<T> Next;

                public StackElement(T element)
                {
                    Value = element;
                }
            }

            public void Clear()
            {
                var current = tail;
                while (current != null)
                {
                    var next = current.Next;
                    current.Next = null;
                    if (next != null)
                    {
                        next.Previous = null;
                    }
                    current = next;
                }
            }

            public IEnumerator<T> GetEnumerator()
            {
                var current = tail;
                while (current != null)
                {
                    yield return current.Value;
                    current = current.Next;
                }
                yield break;
            }
        }
    }
}
