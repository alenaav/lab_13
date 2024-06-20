using System;

namespace lab_13
{
    // Класс JournalEntry представляет одну запись в журнале изменений коллекции
    public class JournalEntry
    {
        // Имя коллекции, в которой произошло изменение
        public string CollectionName { get; }

        // Тип изменения (например, добавление, удаление, обновление)
        public string ChangeType { get; }

        // Данные измененного элемента в коллекции
        public string ChangedItemData { get; }

        // Конструктор для инициализации записи журнала
        public JournalEntry(string collectionName, string changeType, string changedItemData)
        {
            // Инициализация имени коллекции
            CollectionName = collectionName;
            // Инициализация типа изменения
            ChangeType = changeType;
            // Инициализация данных измененного элемента
            ChangedItemData = changedItemData;
        }

        // Переопределяем метод ToString для форматированного вывода записи журнала
        public override string ToString()
        {
            // Возвращаем строку с информацией о записи
            return $"{CollectionName} - {ChangeType}: {ChangedItemData}";
        }
    }
}
