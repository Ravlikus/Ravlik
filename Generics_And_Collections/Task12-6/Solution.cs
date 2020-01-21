using System;
using System.Collections;
using System.Collections.Generic;

namespace Task12_6
{
    public class Set<T>: IEnumerable<T>
    {
        public int Count { get; private set; } = 0;

        private static int HashArrayLenght = 1000;
        private HashArrayElement<T>[] values = new HashArrayElement<T>[HashArrayLenght];

        public void Add(T value)
        {
            var s = new HashSet<int>();
            var hash = value.GetHashCode() % HashArrayLenght;
            if (values[hash] == null)
            {
                values[hash] = new HashArrayElement<T>(value);
            }
            else if (!values[hash].Value.Equals(value))
            {
                var current = values[hash];
                var valueContainedFlag = false;
                while(current.SameHashNextValue!=null)
                {
                    if (values[hash].Value.Equals(value))
                    {
                        valueContainedFlag = true;
                        break;
                    }
                }
                if (!valueContainedFlag)
                {
                    current.SameHashNextValue = new HashArrayElement<T>(value);
                }
            }
        }

        public bool Contain(T value)
        {
            var hash = value.GetHashCode() % HashArrayLenght;
            var current = values[hash];
            while(current!=null)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }
                current = current.SameHashNextValue;
            }
            return false;
        }

        public void Clear()
        {
            values = new HashArrayElement<T>[HashArrayLenght];
            Count = 0;
        }

        public void Remove(T value)
        {
            var hash = value.GetHashCode() % HashArrayLenght;
            var current = values[hash];
            throw new NotImplementedException("Доделать");
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0, index = 0; i<Count;index++)
            {
                var current = values[index];
                while(current!=null)
                {
                    yield return current.Value;
                    current = current.SameHashNextValue;
                    i++;
                }
            }
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0, index = 0; i < Count; index++)
            {
                var current = values[index];
                while (current != null)
                {
                    yield return current.Value;
                    current = current.SameHashNextValue;
                    i++;
                }
            }
            yield break;
        }

        class HashArrayElement<T>
        {
            public HashArrayElement<T> SameHashNextValue = null;
            public T Value;

            public HashArrayElement(T value)
            {
                Value = value;
            }
        }
    }
}
