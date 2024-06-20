using AutomobileLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace AutomobileLibrary
{
    public class Suv : Automobile, IInit
    {
        public bool FourWheelDrive { get; set; }
        public string terrainType { get; set; }

        public string TerrainType { get; set; }

        public Suv() : base()
        {
            FourWheelDrive = false;
            TerrainType = "";
        }

        public Suv(string brand, int year, string color, int cost, int clearance, IdNumber id, bool fourWheelDrive, string terraintype) : base(brand, year, color, cost, clearance, id)
        {
            FourWheelDrive = fourWheelDrive;
            TerrainType = terraintype;
        }

        [ExcludeFromCodeCoverage]
        public override void Show()
        {
            base.Show();
            Console.Write($"Полный привод: {FourWheelDrive}, Тип бездорожья: {TerrainType}");
        }

        public override string ToString()
        {
            return base.ToString() + $", Полный привод: {FourWheelDrive}, Тип бездорожья: {TerrainType}";
        }

        public override void RandomInit()
        {
            base.RandomInit();
            FourWheelDrive = rand.Next() % 2 == 0;

            string[] roadTypes = { "болото", "снег", "камень", "песок" };
            TerrainType = roadTypes[rand.Next(roadTypes.Length)];
        }

        [ExcludeFromCodeCoverage]
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите ДА, если привод полный, и НЕТ, если привод не полный:");
            string fourwd = Console.ReadLine();
            if (fourwd == "ДА")
                FourWheelDrive = true;
            else
            if (fourwd == "НЕТ")
                FourWheelDrive = false;
            Console.WriteLine("Введите тип бездорожья");
            Console.ReadLine();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Suv v = (Suv)obj;
            return FourWheelDrive == v.FourWheelDrive && TerrainType == v.TerrainType;
        }
    }
}