using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Task2;
using Logic.Task1;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Int Binary Tree
            BinaryTree<int> intRoot1 = new BinaryTree<int>();

            intRoot1.Add(6);
            intRoot1.Add(10);
            intRoot1.Add(4);
            intRoot1.Add(5);
            intRoot1.Add(12);
            intRoot1.Add(9);
            intRoot1.Add(3);

            foreach (var element in intRoot1.PreorderWalk())
                Console.Write("{0}  ", element);
            Console.WriteLine();

            foreach (var element in intRoot1.PostorderWalk())
                Console.Write("{0}  ", element);
            Console.WriteLine();

            foreach (var element in intRoot1.InorderWalk())
                Console.Write("{0}  ", element);
            Console.WriteLine();

            BinaryTree<int> intRoot2 = new BinaryTree<int>(Comparer<int>.Create(ComparisonMethod));

            intRoot2.Add(6);
            intRoot2.Add(10);
            intRoot2.Add(-4);
            intRoot2.Add(-5);
            intRoot2.Add(12);
            intRoot2.Add(9);
            intRoot2.Add(-3);

            foreach (var element in intRoot2.PreorderWalk())
                Console.Write("{0}  ", element);
            Console.WriteLine();

            foreach (var element in intRoot2.PostorderWalk())
                Console.Write("{0}  ", element);
            Console.WriteLine();

            foreach (var element in intRoot2.InorderWalk())
                Console.Write("{0}  ", element);
            Console.WriteLine();

            #endregion

            #region String Binary Tree

            BinaryTree<string> stringRoot1 = new BinaryTree<string>();

            stringRoot1.Add("test6");
            stringRoot1.Add("test10");
            stringRoot1.Add("test4");
            stringRoot1.Add("test5");
            stringRoot1.Add("test12");
            stringRoot1.Add("test9");
            stringRoot1.Add("test3");

            foreach (var element in stringRoot1.PreorderWalk())
                Console.Write("{0}  ", element);
            Console.WriteLine();

            foreach (var element in stringRoot1.PostorderWalk())
                Console.Write("{0}  ", element);
            Console.WriteLine();

            foreach (var element in stringRoot1.InorderWalk())
                Console.Write("{0}  ", element);
            Console.WriteLine();

            BinaryTree<string> stringRoot2 = new BinaryTree<string>(Comparer<string>.Create(ComparisonMethod));

            stringRoot2.Add("asdfjk");
            stringRoot2.Add("asdfjkl;as");
            stringRoot2.Add("asdf");
            stringRoot2.Add("asdfj");
            stringRoot2.Add("asdfkjklsdfs");
            stringRoot2.Add("sdfsdfjkl");
            stringRoot2.Add("sdf");

            foreach (var element in stringRoot2.PreorderWalk())
                Console.Write("{0}  ", element);
            Console.WriteLine();

            foreach (var element in stringRoot2.PostorderWalk())
                Console.Write("{0}  ", element);
            Console.WriteLine();

            foreach (var element in stringRoot2.InorderWalk())
                Console.Write("{0}  ", element);
            Console.WriteLine();

            #endregion

            #region Book Binary Tree

            BinaryTree<Book> bookRoot1 = new BinaryTree<Book>();

            bookRoot1.Add(new Book("test6", 1986));
            bookRoot1.Add(new Book("test10", 1990));
            bookRoot1.Add(new Book("test4", 1984));
            bookRoot1.Add(new Book("test5", 1985));
            bookRoot1.Add(new Book("test12", 1992));
            bookRoot1.Add(new Book("test9", 1989));
            bookRoot1.Add(new Book("test3", 1983));

            foreach (var element in bookRoot1.PreorderWalk())
                Console.Write("{0} {1}  ", element.Title, element.Year);
            Console.WriteLine();

            foreach (var element in bookRoot1.PostorderWalk())
                Console.Write("{0} {1}  ", element.Title, element.Year);
            Console.WriteLine();

            foreach (var element in bookRoot1.InorderWalk())
                Console.Write("{0}  {1}  ", element.Title, element.Year);
            Console.WriteLine();

            BinaryTree<Book> bookRoot2 = new BinaryTree<Book>(Comparer<Book>.Create(ComparisonMethod));

            bookRoot2.Add(new Book("test6", 1986));
            bookRoot2.Add(new Book("test10", 1990));
            bookRoot2.Add(new Book("test4", 1984));
            bookRoot2.Add(new Book("test5", 1985));
            bookRoot2.Add(new Book("test12", 1992));
            bookRoot2.Add(new Book("test9", 1989));
            bookRoot2.Add(new Book("test3", 1983));

            foreach (var element in bookRoot2.PreorderWalk())
                Console.Write("{0}  {1}  ", element.Title, element.Year);
            Console.WriteLine();

            foreach (var element in bookRoot2.PostorderWalk())
                Console.Write("{0} {1}  ", element.Title, element.Year);
            Console.WriteLine();

            foreach (var element in bookRoot2.InorderWalk())
                Console.Write("{0}  {1}  ", element.Title, element.Year);
            Console.WriteLine();

            #endregion

            #region Point Binary Tree

            try
            {
                BinaryTree<Point> pointRoot1 = new BinaryTree<Point>();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            BinaryTree<Point> pointRoot2 = new BinaryTree<Point>(Comparer<Point>.Create(ComparisonMethod));

            pointRoot2.Add(new Point(2, 3));
            pointRoot2.Add(new Point(2, 5));
            pointRoot2.Add(new Point(2, 2));
            pointRoot2.Add(new Point(5, 1));
            pointRoot2.Add(new Point(2, 6));
            pointRoot2.Add(new Point(3, 3));
            pointRoot2.Add(new Point(3, 1));

            foreach (var element in pointRoot2.PreorderWalk())
                Console.Write("{0} {1}   ", element.X, element.Y);
            Console.WriteLine();

            foreach (var element in pointRoot2.PostorderWalk())
                Console.Write("{0} {1}   ", element.X, element.Y);
            Console.WriteLine();

            foreach (var element in pointRoot2.InorderWalk())
                Console.Write("{0} {1}   ", element.X, element.Y);
            Console.WriteLine();

            #endregion

            #region Matrix ElementChangedEvent

            SquareMatrix<int> matrix = new SquareMatrix<int>(new int[3][] { new int[3] { 1, 2, 3 }, new int[3] { 2, 3, 4 }, new int[3] { 3, 4, 5 } });

            matrix.OnElementChanged += OnChange<int>;

            matrix[1, 2] = 5;

            #endregion

            Console.ReadKey();
        }

        static void OnChange<T>(object sender, ElementChangedArgs e)
        {
            Console.WriteLine("element was changed at {0}, {1} and has value {2}", e.I, e.J, (sender as SquareMatrix<T>)[e.I, e.J]);
        }
        static int ComparisonMethod(int x, int y)
        {
            if (Math.Abs(x) > Math.Abs(y))
            {
                return 1;
            }
            else if (Math.Abs(x) < Math.Abs(y))
                return -1;
            else
                return 0;
        }

        static int ComparisonMethod(string x, string y)
        {
            if (x.Length > y.Length)
            {
                return 1;
            }
            else if (x.Length < y.Length)
                return -1;
            else
                return 0;
        }

        static int ComparisonMethod(Book x, Book y)
        {
            if (x.Year > y.Year)
            {
                return 1;
            }
            else if (x.Year < y.Year)
                return -1;
            else
                return 0;
        }

        static int ComparisonMethod(Point x, Point y)
        {
            if (x.X*x.Y > y.X*y.Y)
            {
                return 1;
            }
            else if (x.X * x.Y < y.X * y.Y)
                return -1;
            else
                return 0;
        }

        class Book: IComparable<Book>
        {
            public int Year { get; }

            public string Title { get; }
            public Book(string title, int year)
            {
                Title = title;
                Year = year;
            }

            public int CompareTo(Book other)
            {
                if (other == null)
                    return -1;
                return String.Compare(Title, other.Title);
            }
        }

        struct Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}
