using AutomobileLibrary;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Diagnostics.CodeAnalysis;

namespace AutomobileLibrary
{
    public class IdNumber
    {
        public int id; // поле id
        public int Id // свойство для поля id
        {
            get => id;
            set
            {
                if (value < 0)
                    id = 0;
                else
                    id = value;
            }
        }
        public IdNumber(int id) // конструктор с параметром
        {
            Id = id;
        }
        public override string ToString() // перегруженный метод ToString()
        {
            return Id.ToString();
        }
        public override bool Equals(object obj) // перегруженный метод Equals()
        {
            if (obj == null) return false;
            if (obj is IdNumber i)
                return Id == i.Id;
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    public class Automobile : IInit, ICloneable, IComparable
    {
        private string brand;
        private int year;
        private string color;
        private int price;
        private int clearance;
        private IdNumber id;

        protected static Random rand = new Random();

        public IdNumber Id { get { return id; } }

        public string Brand { get; set; }
       
        public int Year
        {
            get => year;
            set
            {
                if (value > 2024 || value < 2000)
                    year = 2000;
                else
                    year = value;
            }
        }

        public string Color { get; set; }

        public int Price
        {
            get => price;
            set
            {
                if (value < 0)
                    price = 0;
                else
                    price = value;
            }
        }

        public int Clearance
        {
            get => clearance;
            set
            {
                if (value < 0 || value > 20)
                    clearance = 0;
                else
                    clearance = value;
            }
        }

        public Automobile()
        {
            Brand = "NoBrand";
            Year = 2000;
            Color = "Black";
            Price = 0;
            Clearance = 0;
            id = new IdNumber(0);
        }

        public Automobile(string brand, int year, string color, int price, int groundClearance, IdNumber id)
        {
            Brand = brand;
            Year = year;
            Color = color;
            Price = price;
            Clearance = groundClearance;
            this.id = id;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode()
                + Brand.GetHashCode()
                + Year.GetHashCode()
                + Color.GetHashCode()
                + Price.GetHashCode()
                + Clearance.GetHashCode();



        }

        [ExcludeFromCodeCoverage]
        public virtual void Show()
        {
            Console.WriteLine($"\nID: {id}, Бренд: {Brand}, Год: {Year}, Цвет: {Color}, Цена: {Price}, Дорожный просвет: {Clearance}");
        }

        [ExcludeFromCodeCoverage]
        public void ShowNonVirtual()
        {
            Console.WriteLine($"ID: {id}, Бренд: {Brand}, Год: {Year}, Цвет: {Color}, Цена: {Price}, Дорожный просвет: {Clearance}");
        }

        public override string ToString()
        {
            return $"ID: {id}, Бренд: {Brand}, Год: {Year}, Цвет: {Color}, Цена: {Price}, Дорожный просвет: {Clearance}";
        }

        [ExcludeFromCodeCoverage]
        public virtual void Init()
        {
            Console.WriteLine("Введите бренд:");
            Brand = Console.ReadLine();
            Console.WriteLine("Введите год выпуска:");
            try
            {
                Year = int.Parse(Console.ReadLine());
            }
            catch
            {
                Year = 2000;
            }
            Console.WriteLine("Введите цвет:");
            Color = Console.ReadLine();
            Console.WriteLine("Введите цену:");
            try
            {
                Price = int.Parse(Console.ReadLine());
            }
            catch
            {
                Price = 0;
            }
            Console.WriteLine("Введите дорожный просвет:");
            try
            {
                Clearance = int.Parse(Console.ReadLine());
            }
            catch
            {
                Clearance = 0;
            }
            Console.WriteLine("Введите ID");
            try
            {
                id.Id = int.Parse(Console.ReadLine());
            }
            catch
            {
                id.Id = 0;
            }
        }

        public virtual void RandomInit()
        {
            string[] brands = { "BMW", "Mercedes-Benz", "Renault", "Hyundai", "Ford", "Volkswagen", "Lamborghini", "Ferrari", "Alfa-Romeo"};
            string[] colors = { "Черный", "Белый", "Красный", "Серебристый", "Голубой", "Желтый", "Зеленый", "Серый", "Синий", "Коричневый" };
            int s = rand.Next(brands.Length);
            Brand = brands[rand.Next(brands.Length)]; ;
            Year = rand.Next(2001, 2023);
            Color = colors[rand.Next(colors.Length)]; ;
            Price = rand.Next(10000, 500000);
            Clearance = rand.Next(5, 15);
            id.Id = rand.Next(0, 100);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Automobile v = (Automobile)obj;
            return Brand == v.Brand && Year == v.Year && Color == v.Color && Price == v.Price &&
                   Clearance == v.Clearance;
        }

        public virtual int CompareTo(object? obj)
        {
            if (obj == null) return -1;
            if (obj is not Automobile) return -1;
            Automobile m = obj as Automobile;
            return String.Compare(this.brand, m.brand);
        }

        public virtual object Clone()
        {
            return new Automobile(Brand, Year, Color, Price, Clearance, id);
        }

        public Automobile ShallowCopy()
        {
            return (Automobile)this.MemberwiseClone();
        }
    }
}