using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_7
{
    public class BinaryTree<T>: IEnumerable<T>
    {
        public delegate int Comparator(T a, T b);

        private Comparator compareMethod
        = (a, b) =>
        {
            if (a is IComparable)
            {
                var aComp = a as IComparable;
                var bComp = b as IComparable;
                return aComp.CompareTo(bComp);
            }
            throw new Exception("Override compare method to use non-ICompareable structures");
        };

        public Comparator CompareMethod
        { 
            get 
            {
                return compareMethod;
            } 
            set 
            {
                compareMethod = value;
                if (root != null)
                {
                    root.CompareMethod = value;
                }
            } 
        }

        public enum TranseverceOption
        {
            PreOrder,
            InOrder,
            PostOrder
        }

        public TranseverceOption TranseverceOrder
        {
            get { return transeverceOrder; }
            set
            {
                if (value == TranseverceOption.InOrder)
                {
                    if (root != null) TransverceMethod = root.InOrderTraversing;
                    transeverceOrder = TranseverceOption.InOrder;
                }
                if (value == TranseverceOption.PreOrder)
                {
                    if (root != null) TransverceMethod = root.PreOrderTraversing;
                    transeverceOrder = TranseverceOption.PreOrder;
                }
                if (value == TranseverceOption.PostOrder)
                {
                    if (root != null) TransverceMethod = root.PostOrderTraversing;
                    transeverceOrder = TranseverceOption.PostOrder;
                }
            }
        }

        private TranseverceOption transeverceOrder = TranseverceOption.InOrder;
        private TreeElement root;
        private delegate IEnumerable<T> Transversing();
        private Transversing TransverceMethod;


        public void Add(T value)
        {
            if (root == null) 
            { 
                root = new TreeElement(value);
                root.CompareMethod = CompareMethod;
                if (TranseverceOrder == TranseverceOption.InOrder)
                {
                    TransverceMethod = root.PreOrderTraversing;
                }
                if (TranseverceOrder == TranseverceOption.InOrder)
                {
                    TransverceMethod = root.InOrderTraversing;
                }
                if (TranseverceOrder == TranseverceOption.PostOrder)
                {
                    TransverceMethod = root.PostOrderTraversing;
                }
            }
            else root.Add(value);
        }

        public bool Contain(T value)
        {
            if (root == null) return false;
            else return root.Contain(value);
        }

        public void Remove(T value)
        {
            if (value.Equals(root.Value) && root.RightChildren == null && root.LeftChildren == null) root = null;
            else root.Remove(value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (root == null) yield break;
            foreach(var value in TransverceMethod.Invoke())
            {
                yield return value;
            }
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (root == null) yield break;
            foreach (var value in TransverceMethod.Invoke())
            {
                yield return value;
            }
            yield break;
        }

        private class TreeElement
        {
            public TreeElement Parent;
            public TreeElement RightChildren;
            public TreeElement LeftChildren;
            public T Value;
            private Comparator compareMethod;

            public Comparator CompareMethod 
            {
                get
                {
                    return compareMethod;
                }
                set
                {
                    compareMethod = value;
                    if (RightChildren != null) RightChildren.CompareMethod = value;
                    if (LeftChildren != null) LeftChildren.CompareMethod = value;
                }
            }


            public TreeElement(T value, TreeElement parent = null)
            {
                Value = value;
                Parent = parent;
            }

            public void Add(T value)
            {
                if (compareMethod.Invoke(value,Value) == 0) throw new ArgumentException("Added value are equal to tree element value");
                else if (compareMethod.Invoke(value, Value) > 0)
                {
                    if (RightChildren == null) 
                    { 
                        RightChildren = new TreeElement(value, this);
                        RightChildren.CompareMethod = compareMethod;
                    }
                    else RightChildren.Add(value);
                }
                else if (compareMethod.Invoke(value, Value) < 0)
                {
                    if (LeftChildren == null)
                    {
                        LeftChildren = new TreeElement(value, this);
                        LeftChildren.CompareMethod = compareMethod;
                    }
                    else LeftChildren.Add(value);
                }
            }

            public bool Contain(T value)
            {
                if (compareMethod.Invoke(value, Value) == 0) return true;
                else if(compareMethod.Invoke(value, Value) > 0)
                {
                    if (RightChildren == null) return false;
                    else return RightChildren.Contain(value);
                }
                else
                {
                    if (LeftChildren == null) return false;
                    else   return LeftChildren.Contain(value);
                }
            }

            public void Remove(T value)
            {
                if (compareMethod.Invoke(value, Value) == 0)
                {
                    if (RightChildren != null)
                    {
                        var flag = false;
                        var current = RightChildren;
                        while (current.LeftChildren != null)
                        {
                            current = current.LeftChildren;
                            flag = true;
                        }
                        Value = current.Value;
                        if (flag) // если это левый потомок
                        {
                            current.Parent.LeftChildren = current.RightChildren;
                        }
                        else current.Parent.RightChildren = current.RightChildren;
                    }
                    else if (LeftChildren != null)
                    {
                        var flag = false;
                        var current = LeftChildren;
                        while (current.RightChildren != null)
                        {
                            current = current.RightChildren;
                            flag = true;
                        }
                        Value = current.Value;
                        if (flag) // если это правый потомок
                        {
                            current.Parent.RightChildren = current.LeftChildren;
                        }
                        else current.Parent.LeftChildren = current.LeftChildren;
                    }
                    else if (RightChildren==null&&LeftChildren==null)
                    {
                        if (Parent.RightChildren!=null&&Parent.RightChildren.Value.Equals(Value))
                        {
                            Parent.RightChildren = null;
                        }
                        else Parent.LeftChildren = null;
                    }
                }
                else if (compareMethod.Invoke(value, Value) > 0)
                {
                    if (RightChildren == null) throw new ArgumentException("No such element");
                    else RightChildren.Remove(value);
                }
                else
                {
                    if (LeftChildren == null) throw new ArgumentException("No such element");
                    else LeftChildren.Remove(value);
                }
            }

            public TreeElement GetLeftEdge()
            {
                var current = this;
                while(current.LeftChildren!=null)
                {
                    current = LeftChildren;
                }
                return current;
            }

            public TreeElement GeRightEdge()
            {
                var current = this;
                while (current.RightChildren != null)
                {
                    current = RightChildren;
                }
                return current;
            }

            public IEnumerable<T> PreOrderTraversing()
            {
                yield return Value;
                if (LeftChildren != null)
                    foreach (var value in LeftChildren.PreOrderTraversing())
                    {
                        yield return value;
                    }
                if (RightChildren != null)
                    foreach (var value in RightChildren.PreOrderTraversing())
                    {
                        yield return value;
                    }
                yield break;
            }


            public IEnumerable<T> InOrderTraversing()
            {
                if (LeftChildren != null)
                    foreach (var value in LeftChildren.InOrderTraversing())
                    {
                        yield return value;
                    }
                yield return Value;
                if (RightChildren != null)
                    foreach (var value in RightChildren.InOrderTraversing())
                    {
                        yield return value;
                    }
                yield break;
            }


            public IEnumerable<T> PostOrderTraversing()
            {
                if (LeftChildren != null)
                    foreach (var value in LeftChildren.PostOrderTraversing())
                    {
                        yield return value;
                    }
                if (RightChildren != null)
                    foreach (var value in RightChildren.PostOrderTraversing())
                    {
                        yield return value;
                    }
                yield return Value;
                yield break;
            }
        }
    }
}
