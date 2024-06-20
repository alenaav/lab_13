using AutomobileLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary
{
    public class SortByPrice : IComparer
    {
        public int Compare(object? x, object? y)
        {
            Automobile car1 = (Automobile)x;
            Automobile car2 = (Automobile)y;

            if (car1.Price > car2.Price)
                return 1;
            else if (car1.Price < car2.Price)
                return -1;
            else
                return 0;
        }
    }
}