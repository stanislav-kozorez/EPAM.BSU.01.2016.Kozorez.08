using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Task2
{
    public class BinaryTree<T>
    {
        private bool isEmpty;
        private IComparer<T> comparer;
        public BinaryTree<T> Left { get; set; }
        public BinaryTree<T> Right { get; set; }

        public T Value { get; private set; }

        public BinaryTree(IComparer<T> comparer = null)
        {
            if (comparer == null)
                if (typeof(T).GetInterface("IComparable") == null && typeof(T).GetInterface("IComparable`1") == null &&
                    typeof(T).GetInterface("IComparer") == null && typeof(T).GetInterface("IComparer`1") == null)
                    throw new ArgumentException("IComparable interface is not implemented");
            this.comparer = comparer ?? Comparer<T>.Default;
            Value = default(T);
            isEmpty = true;
        }

        private BinaryTree(T value, IComparer<T> comparer = null)
        {
            this.comparer = comparer;
            Value = value;
            isEmpty = false;
        }

        public IEnumerable<T> PreorderWalk() //прямой
        {
            yield return Value;
            if(Left != null)
                foreach (var element in Left.PreorderWalk())
                    yield return element;
            if(Right != null)
                foreach (var element in Right.PreorderWalk())
                    yield return element;

        }

        public IEnumerable<T> PostorderWalk() // обратный
        {
            if (Left != null)
                foreach (var element in Left.PostorderWalk())
                    yield return element;
            if (Right != null)
                foreach (var element in Right.PostorderWalk())
                    yield return element;
            yield return Value;
        }

        public IEnumerable<T> InorderWalk() //симметричный
        {
            if (Left != null)
                foreach (var element in Left.InorderWalk())
                    yield return element;
            yield return Value;
            if (Right != null)
                foreach (var element in Right.InorderWalk())
                    yield return element;
        }

        public void Add(T elem)
        {
            if (elem == null)
                throw new ArgumentNullException(nameof(elem));
            if (isEmpty)
            {
                Value = elem;
                isEmpty = false;
            }
            else
            {
                try
                {
                    if (comparer.Compare(Value, elem) == 1)
                    {
                        if (Left != null)
                            Left.Add(elem);
                        else
                            Left = new BinaryTree<T>(elem, comparer);
                    }
                    else
                        if (comparer.Compare(Value, elem) == -1)
                    {
                        if (Right != null)
                            Right.Add(elem);
                        else
                            Right = new BinaryTree<T>(elem, comparer);
                    }
                    else
                        throw new ArgumentException("Element already exists");
                }
                catch (ArgumentException e)
                {
                    throw new ComparerException("Bad comparer", e);
                }
            }

        }
    }

    public class ComparerException : Exception
    {
        public ComparerException()
            :base()
        { }
        public ComparerException(string message)
            :base(message)
        { }
        
        public ComparerException(string message, Exception innerException)
            :base(message, innerException)
        { }
    }
}
