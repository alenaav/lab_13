using System;
using System.Collections;
using System.Collections.Generic;
using AutomobileLibrary;
using lab12_4;

namespace lab12_4
{
    public class MyCollection<T> : MyHashTable<T>, IEnumerable<T> where T : IInit, ICloneable, IComparable, new()
    {
        public Point<T>? beg;

        public int Count { get; private set; }

        public MyCollection() : base()
        {
            Count = 0;
        }

        public MyCollection(int length) : base(length)
        {
            Count = 0;
            for (int i = 0; i < length; i++)
            {
                T item = new T();
                item.RandomInit();
                AddPoint(item);
            }
        }

        public MyCollection(MyCollection<T> c) : base()
        {
            if (c == null)
                throw new ArgumentNullException(nameof(c));

            foreach (var item in c)
            {
                AddPoint((T)item.Clone());
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Point<T>? current = beg;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public new void AddPoint(T item)
        {
            if (beg == null)
            {
                beg = new Point<T>(item);
            }
            else
            {
                Point<T>? current = beg;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new Point<T>(item);
                current.Next.Pred = current;
            }
            base.AddPoint(item);
            Count++;
        }

        public new void PrintTable()
        {
            base.PrintTable();
        }

        public new bool RemoveData(T data)
        {
            if (beg == null)
            {
                return false;
            }

            if (beg.Data.Equals(data))
            {
                beg = beg.Next;
                if (beg != null)
                {
                    beg.Pred = null;
                }
                base.RemoveData(data);
                Count--;
                return true;
            }

            Point<T>? current = beg;
            while (current.Next != null)
            {
                if (current.Next.Data.Equals(data))
                {
                    current.Next = current.Next.Next;
                    if (current.Next != null)
                    {
                        current.Next.Pred = current;
                    }
                    base.RemoveData(data);
                    Count--;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public new bool Contains(T data)
        {
            return base.Contains(data);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (arrayIndex < 0 || arrayIndex > array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }
            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException("Недостаточно места в массиве.");
            }

            Point<T>? current = beg;
            while (current != null)
            {
                array[arrayIndex++] = current.Data;
                current = current.Next;
            }
        }
    }
}