using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_4
{
    public class Solution
    {
        public class Queue<T>
        {
            private QueueElement<T> head;
            private QueueElement<T> tail;
            private int count = 0;
            public int Count { get { return count; } }

            public Queue(){}

            public void Enqueue(T element)
            {
                if (count == 0)
                {
                    head = new QueueElement<T>(element);
                    tail = head;
                }

                else
                {
                    var newTail = new QueueElement<T>(element);
                    tail.Previous = newTail;
                    newTail.Next = tail;
                    tail = newTail;
                }

                count++;
            }

            public T Dequeue()
            {
                if (count == 0) throw new Exception("Queue is empty!");
                var result = head;
                head = head.Previous;
                count--;
                return result.Value;
            }

            private class QueueElement<T>
            {
                public T Value;
                public QueueElement<T> Previous;
                public QueueElement<T> Next;

                public QueueElement(T element)
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
