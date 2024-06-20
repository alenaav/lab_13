using AutomobileLibrary;
using lab12_4;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12_4
{
    public class MyHashTable<T> where T : IInit, ICloneable, new()
    {
        Point<T>?[] table;
        private T[] collection;

        public int Capacity => table.Length;

        public MyHashTable(int length = 10)
        {
            table = new Point<T>[length];

        }

        public MyHashTable(T[] collection)
        {
            this.collection = collection;
        }

        public void PrintTable()
        {
            for (int i = 0; i < table.Length; i++)
            {
                Console.WriteLine($"{i}:");
                if (table[i] != null)
                {
                    Console.WriteLine(table[i].Data);
                    if (table[i].Next != null)
                    {
                        Point<T>? current = table[i].Next;
                        while (current != null)
                        {
                            Console.WriteLine(current.Data);
                            current = current.Next;
                        }
                    }
                }
            }
        }

        public void AddPoint(T data)
        {
            int index = GetIndex(data);

            if (table[index] == null)
            {
                table[index] = new Point<T>(data);
                table[index].Data = data;
            }
            else
            {
                Point<T>? current = table[index];

                while (current.Next != null)
                {
                    if (current.Equals(data))
                        return;
                    current = current.Next;
                }
                current.Next = new Point<T>(data);
                current.Next.Pred = current;
            }
        }

        public bool Contains(T data)
        {
            int index = GetIndex(data);
            if (table == null)
                throw new Exception("empty table");
            if (table[index] == null)
                return false;
            if (table[index].Data.Equals(data))
                return true;
            else
            {
                Point<T>? current = table[index];
                while (current != null)
                {
                    if (current.Data.Equals(data))
                        return true;
                    current = current.Next;
                }
            }
            return false;
        }

        public bool RemoveData(T data)
        {
            Point<T>? current;
            int index = GetIndex(data);
            if (table[index] == null)
                return false;
            if (table[index].Data.Equals(data))
            {
                if (table[index].Next == null)
                    table[index] = null;
                else
                {
                    table[index] = table[index].Next;
                    table[index].Pred = null;
                }
                return true;
            }
            else
            {
                current = table[index];
                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        Point<T>? prev = current.Pred;
                        Point<T>? next = current.Next;
                        prev.Next = next;
                        current.Pred = null;
                        if (next != null)
                            next.Pred = prev;
                        return true;
                    }
                    current = current.Next;
                }
            }
            return false;
        }

        public int GetIndex(T data)
        {
            return Math.Abs(data.GetHashCode()) % Capacity;
        }

        public bool RemoveByKey(T data)
        {
            int index = GetIndex(data);

            if (table[index] == null)
            {
                return false; // Элемент не найден по данному ключу
            }
            else if (table[index].Data.Equals(data))
            {
                // Элемент найден в начале цепочки
                table[index] = table[index].Next;
                return true;
            }
            else
            {
                // Элемент найден в середине или в конце цепочки
                Point<T>? current = table[index];
                while (current.Next != null)
                {
                    if (current.Next.Data.Equals(data))
                    {
                        current.Next = current.Next.Next; // Удаление элемента из цепочки
                        return true;
                    }
                    current = current.Next;
                }
                return false; // Элемент не найден по данному ключу
            }
        }

        public bool ContainsKey(T data)
        {
            int index = GetIndex(data);

            if (table[index] == null)
            {
                return false; // Элемент не найден по данному ключу
            }
            else
            {
                // Проверяем цепочку на наличие элемента с данными
                Point<T>? current = table[index];
                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        return true; // Элемент найден
                    }
                    current = current.Next;
                }
                return false; // Элемент не найден по данному ключу
            }
        }
    }
}