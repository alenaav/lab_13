using AutomobileLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace AutomobileLibrary
{
    public class Car : Automobile, IInit
    {
        private int seatCount;
        private int maxSpeed;
        public int SeatCount
        
        {
            get => seatCount;
            set
            {
                if (value < 0 || value > 7)
                    seatCount = 0;
                else
                    seatCount = value;
            }
        }

        public int MaxSpeed
        {
            get => maxSpeed;
            set
            {
                if (value < 0 || value > 300)
                    maxSpeed = 0;
                else
                    maxSpeed = value;
            }
        }

        public Car() : base()
        {
            SeatCount = 0;
            MaxSpeed = 0;
        }

        public Car(string brand, int year, string color, int cost, int clearance, IdNumber id, int seatCount, int maxSpeed) : base(brand, year, color, cost, clearance, id)
        {
            SeatCount = seatCount;
            MaxSpeed = maxSpeed;
        }

        public override void RandomInit()
        {
            base.RandomInit();
            SeatCount = rand.Next(2, 8);
            MaxSpeed = rand.Next(100, 300);
        }

        [ExcludeFromCodeCoverage]
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите количество мест:");
            try
            {
                SeatCount = int.Parse(Console.ReadLine());
            }
            catch
            {
                SeatCount = 0;
            }
            Console.WriteLine("Введите максимальную скорость:");
            try
            {
                MaxSpeed = int.Parse(Console.ReadLine());
            }
            catch
            {
                MaxSpeed = 0;
            }
        }

        [ExcludeFromCodeCoverage]
        public override void Show()
        {
            base.Show();
            Console.Write($"Количество мест: {SeatCount}, Максимальная скорость(км/ч): {MaxSpeed}");
        }

        public override string ToString()
        {
            return base.ToString() + $", Количество мест = {SeatCount}, Максимальная скорость(км/ч): {MaxSpeed}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Car v = (Car)obj;
            return SeatCount == v.SeatCount && MaxSpeed == v.MaxSpeed;
        }

        public Automobile GetBase
        {
            get => new Automobile(Brand, Year, Color, Price, Clearance, Id);
        }

        public override object Clone()
        {
            return new Car(Brand, Year, Color, Price, Clearance, Id, SeatCount, MaxSpeed);
        }

    }
}