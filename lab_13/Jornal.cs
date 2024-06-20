using System;
using System.Collections.Generic; // Необходимо для использования класса List<T>

namespace lab_13
{
    // Класс Journal отвечает за ведение списка журналов записей.
    public class Journal
    {
        // Список для хранения объектов JournalEntry
        public List<JournalEntry> Entries { get; private set; } = new List<JournalEntry>();

        // Метод для добавления новой записи в журнал
        public void AddEntry(object source, CollectionHandlerEventArgs args)
        {
            // Получить имя коллекции или объекта, который сгенерировал событие
            string collectionName = source.GetType().Name;

            // Создать новую запись журнала с деталями изменения
            var entry = new JournalEntry(collectionName, args.ChangeType, args.ChangedItem.ToString());

            // Добавить новую запись в список записей
            Entries.Add(entry);
        }

        // Метод для вывода всех записей журнала на консоль
        public void PrintEntries()
        {
            // Перебрать каждую запись в списке Entries
            foreach (var entry in Entries)
            {
                // Вывести запись на консоль
                Console.WriteLine(entry);
            }
        }
    }
}