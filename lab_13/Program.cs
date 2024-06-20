using lab_13;
using AutomobileLibrary;
using System.Collections.ObjectModel;
using lab13;

internal class Program
{
    private static void Main(string[] args)
    {
        // Создаем две коллекции MyObservableCollection
        MyObservableCollection<Automobile> collection1 = new();
        MyObservableCollection<Automobile> collection2 = new();


        // Создаем два объекта типа Journal
        Journal journal1 = new Journal();
        Journal journal2 = new Journal();

        // Подписываем первый Journal на события CollectionCountChanged и CollectionReferenceChanged из первой коллекции
        collection1.CollectionCountChanged += journal1.AddEntry;
        collection1.CollectionReferenceChanged += journal1.AddEntry;

        // Подписываем второй Journal на событие CollectionReferenceChanged из обеих коллекций
        collection1.CollectionReferenceChanged += journal2.AddEntry;
        collection2.CollectionReferenceChanged += journal2.AddEntry;

        // Демонстрация работы
        // string brand, int year, string color, int price, int groundClearance, IdNumber id
        var auto1 = new Automobile("BMW", 1223, "", 123, 123, new IdNumber(1));
        var auto2 = new Automobile("Mercedes-Benz", 1223, "", 123, 123, new IdNumber(2));

        // Добавляем и изменяем элементы в коллекциях
        collection1.Add(auto1);
        collection2.Add(auto2);
        collection1[0] = new Automobile("Renault", 1223, "", 123, 123, new IdNumber(3));
        collection2[0] = new Automobile("Hyundai", 1223, "", 123, 123, new IdNumber(4));

        // Печать журнала
        Console.WriteLine("Journal 1 entries:");
        journal1.PrintEntries();

        Console.WriteLine("Journal 2 entries:");
        journal2.PrintEntries();
    }
}