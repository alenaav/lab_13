using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomobileLibrary;

namespace lab12_4
{
    public class Point<T> where T : new()
    {
        public T Data { get; set; }
        public Point<T> Next { get; set; }
        public Point<T> Pred { get; set; }
        public static Point<T> MakeRandomData()
        {
            T data = new T();
            if (data is IInit)
            {
                (data as IInit).RandomInit();
            }
            else
            {
                throw new Exception("Type T does not implement the Ilist interface");
            }
            return new Point<T>(data);
        }
        public static T MakeRandomItem()
        {
            T data = new T();
            if (data is IInit)
            {
                (data as IInit).RandomInit();
            }
            else
            {
                throw new Exception("Type T does not implement the Ilist interface");
            }
            return data;
        }

        public Point()
        {
            this.Data = default(T);
            this.Pred = null;
            this.Next = null;
        }
        public Point(T data)
        {
            this.Data = data;
            this.Pred = null;
            this.Next = null;
        }

        public override string ToString()
        {
            return Data == null ? "" : Data.ToString();

        }
        public override int GetHashCode()
        {
            return Data == null ? 0 : Data.GetHashCode();
        }
    }
}