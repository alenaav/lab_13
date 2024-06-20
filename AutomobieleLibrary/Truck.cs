using AutomobileLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace AutomobileLibrary
{
    public class Truck : Automobile, IInit
    {
        private int loadCapacity;
        public int LoadCapacity
        {
            get => loadCapacity;
            set
            {
                if (value < 0)
                    loadCapacity = 0;
                else
                    loadCapacity = value;
            }
        }

        public Truck() : base()
        {
            LoadCapacity = 0;
        }

        public Truck(string brand, int year, string color, int cost, int clearance, IdNumber id, int capacity) : base(brand, year, color, cost, clearance, id)
        {
            LoadCapacity = capacity;
        }

        public override void RandomInit()
        {
            base.RandomInit();
            LoadCapacity = rand.Next(1, 10);
        }

        [ExcludeFromCodeCoverage]
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите грузоподъемность:");
            try
            {
                LoadCapacity = int.Parse(Console.ReadLine());
            }
            catch
            {
                LoadCapacity = 0;
            }
        }

        [ExcludeFromCodeCoverage]
        public override void Show()
        {
            base.Show();
            Console.Write($"Грузоподъемность: {LoadCapacity}");
        }

        public override string ToString()
        {
            return base.ToString() + $", Грузоподъемность: {LoadCapacity}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Truck v = (Truck)obj;
            return LoadCapacity == v.LoadCapacity;
        }
    }
}