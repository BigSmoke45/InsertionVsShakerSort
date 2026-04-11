using System;

namespace DataStructures.LinkedList
{
    /// <summary>
    /// A single node in the linked list.
    /// </summary>
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
        }
    }

    /// <summary>
    /// Custom singly linked list implementation with 14 operations.
    /// Does not use System.Collections.Generic.LinkedList.
    /// </summary>
    public class CustomLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;

        /// <summary>Appends an element to the end of the list.</summary>
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;
            count++;
        }

        /// <summary>Inserts an element at the beginning of the list.</summary>
        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
            if (count == 0) tail = head;
            count++;
        }

        /// <summary>Appends an element to the end of the list.</summary>
        public void AddLast(T data)
        {
            Node<T> node = new Node<T>(data);
            if (tail != null) tail.Next = node;
            tail = node;
            if (count == 0) head = tail;
            count++;
        }

        /// <summary>Inserts an element after the element at the given index.</summary>
        public void InsertAfter(int index, T data)
        {
            int currIndex = 0;
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (currIndex == index)
                {
                    if (previous == null)
                    {
                        AppendFirst(data);
                        return;
                    }
                    Node<T> newNode = new Node<T>(data);
                    previous.Next = newNode;
                    newNode.Next = current;
                    count++;
                    return;
                }
                previous = current;
                current = current.Next;
                currIndex++;
            }
        }

        /// <summary>Appends the same element n times to the end of the list.</summary>
        public void AddMultiple(T data, int n)
        {
            for (int i = 0; i < n; i++)
                AddLast(data);
        }

        /// <summary>Removes every k-th element (by position) from the list.</summary>
        public void RemoveEveryKth(int k, bool singleMode)
        {
            Node<T> current = head;
            int currIndex = 1;

            while (current != null)
            {
                if (currIndex % k == 0)
                {
                    Node<T> next = current.Next;
                    RemoveNode(current);
                    current = next;
                    if (singleMode) break;
                }
                else
                {
                    current = current.Next;
                }
                currIndex++;
            }
        }

        /// <summary>Removes the last n elements from the list.</summary>
        public void RemoveLast(int n)
        {
            for (int i = 0; i < n; i++)
                RemoveNode(tail);
        }

        /// <summary>Removes the last element from the list.</summary>
        public void RemoveLast() => RemoveNode(tail);

        /// <summary>Removes a specific node from the list.</summary>
        public void RemoveNode(Node<T> node)
        {
            if (node == null) return;

            Node<T> prevNode = FindPrevNode(node);

            if (prevNode != null)
                prevNode.Next = node.Next;

            if (head == node)
                head = node.Next;

            if (tail == node)
                tail = prevNode;

            node.Next = null;
            count--;
        }

        /// <summary>Clears the entire list.</summary>
        public void Clear()
        {
            Node<T> current = head;
            while (current != null)
            {
                Node<T> next = current.Next;
                current.Next = null;
                current = next;
            }
            head = null;
            tail = null;
            count = 0;
        }

        /// <summary>Returns the number of elements in the list.</summary>
        public int Count() => count;

        /// <summary>Prints all elements from head to tail.</summary>
        public void Print()
        {
            Node<T> node = head;
            while (node != null)
            {
                Console.Write(node.Data + " ");
                node = node.Next;
            }
            Console.WriteLine();
        }

        /// <summary>Prints all elements from tail to head.</summary>
        public void PrintReverse()
        {
            Node<T> node = tail;
            while (node != null)
            {
                Console.Write(node.Data + " ");
                node = FindPrevNode(node);
            }
            Console.WriteLine();
        }

        /// <summary>Finds the node before the given node.</summary>
        private Node<T> FindPrevNode(Node<T> node)
        {
            Node<T> current = head;
            while (current != null && current.Next != node)
                current = current.Next;
            return current;
        }

        /// <summary>
        /// Builds a new list with values from a to b (inclusive, step = 1).
        /// </summary>
        public static CustomLinkedList<int> Range(int a, int b)
        {
            var list = new CustomLinkedList<int>();
            for (int i = a; i <= b; i++)
                list.Add(i);
            return list;
        }
    }

    /// <summary>
    /// Interactive console demo for CustomLinkedList operations.
    /// </summary>
    class LinkedListDemo
    {
        static void Main(string[] args)
        {
            var list = new CustomLinkedList<int>();

            Console.Write("Enter number of elements: ");
            int size = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < size; i++)
            {
                Console.Write($"Element {i + 1}: ");
                list.Add(Convert.ToInt32(Console.ReadLine()));
            }

            PrintMenu();

            int choice = -1;
            while (choice != 0)
            {
                Console.Write("\nOperation: ");
                choice = Convert.ToInt32(Console.ReadLine());
                int listSize;

                switch (choice)
                {
                    case 1:
                        Console.Write("List: ");
                        list.Print();
                        break;

                    case 2:
                        Console.Write("Reversed: ");
                        list.PrintReverse();
                        break;

                    case 3:
                        Console.WriteLine($"Count: {list.Count()}");
                        break;

                    case 4:
                        Console.Write("Value to insert at beginning: ");
                        list.AppendFirst(Convert.ToInt32(Console.ReadLine()));
                        break;

                    case 5:
                        list.RemoveLast();
                        Console.WriteLine("Last element removed.");
                        break;

                    case 6:
                        list.Clear();
                        Console.WriteLine("List cleared.");
                        break;

                    case 7:
                        Console.Write("Value to insert: ");
                        int val7 = Convert.ToInt32(Console.ReadLine());
                        listSize = list.Count();
                        Console.Write($"After index (1–{listSize}): ");
                        int idx7 = Convert.ToInt32(Console.ReadLine());
                        if (idx7 < 1 || idx7 > listSize)
                            Console.WriteLine("Invalid index.");
                        else if (idx7 == listSize)
                            list.AddLast(val7);
                        else
                            list.InsertAfter(idx7, val7);
                        break;

                    case 8:
                        Console.Write("Value to insert: ");
                        int val8 = Convert.ToInt32(Console.ReadLine());
                        listSize = list.Count();
                        Console.Write($"Before index (1–{listSize}): ");
                        int idx8 = Convert.ToInt32(Console.ReadLine());
                        if (idx8 < 1 || idx8 > listSize)
                            Console.WriteLine("Invalid index.");
                        else
                            list.InsertAfter(idx8 - 1, val8);
                        break;

                    case 9:
                        Console.Write("Value to append: ");
                        list.AddLast(Convert.ToInt32(Console.ReadLine()));
                        break;

                    case 10:
                        Console.Write("Value to add: ");
                        int val10 = Convert.ToInt32(Console.ReadLine());
                        Console.Write("How many times: ");
                        int times = Convert.ToInt32(Console.ReadLine());
                        list.AddMultiple(val10, times);
                        break;

                    case 11:
                        Console.Write("Start value (a): ");
                        int a = Convert.ToInt32(Console.ReadLine());
                        Console.Write("End value (b): ");
                        int b = Convert.ToInt32(Console.ReadLine());
                        list = CustomLinkedList<int>.Range(a, b);
                        break;

                    case 12:
                        listSize = list.Count();
                        Console.Write($"Remove every k-th element. k (1–{listSize}): ");
                        int k12 = Convert.ToInt32(Console.ReadLine());
                        if (k12 < 1 || k12 > listSize)
                            Console.WriteLine("Invalid value.");
                        else
                            list.RemoveEveryKth(k12, false);
                        break;

                    case 13:
                        listSize = list.Count();
                        Console.Write($"Remove last k elements. k (1–{listSize - 1}): ");
                        int k13 = Convert.ToInt32(Console.ReadLine());
                        if (k13 < 1 || k13 > listSize - 1)
                            Console.WriteLine("Invalid value.");
                        else
                            list.RemoveLast(k13);
                        break;

                    case 14:
                        listSize = list.Count();
                        Console.Write($"Remove element at index (1–{listSize}): ");
                        int idx14 = Convert.ToInt32(Console.ReadLine());
                        if (idx14 < 1 || idx14 > listSize)
                            Console.WriteLine("Invalid index.");
                        else
                            list.RemoveEveryKth(idx14, true);
                        break;

                    case 0:
                        break;

                    default:
                        Console.WriteLine("Unknown operation.");
                        break;
                }
            }

            Console.WriteLine("Exiting. Press any key...");
            Console.ReadKey();
        }

        static void PrintMenu()
        {
            Console.WriteLine("\nAvailable operations:");
            Console.WriteLine("  1  — Print list");
            Console.WriteLine("  2  — Print list in reverse");
            Console.WriteLine("  3  — Count elements");
            Console.WriteLine("  4  — Insert at beginning");
            Console.WriteLine("  5  — Remove last element");
            Console.WriteLine("  6  — Clear list");
            Console.WriteLine("  7  — Insert after i-th element");
            Console.WriteLine("  8  — Insert before i-th element");
            Console.WriteLine("  9  — Append to end");
            Console.WriteLine(" 10  — Append same element k times");
            Console.WriteLine(" 11  — Build list from range [a, b]");
            Console.WriteLine(" 12  — Remove every k-th element");
            Console.WriteLine(" 13  — Remove last k elements");
            Console.WriteLine(" 14  — Remove element at index i");
            Console.WriteLine("  0  — Exit");
        }
    }
}
