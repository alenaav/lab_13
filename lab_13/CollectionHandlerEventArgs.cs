using System;

namespace lab_13
{
    // Класс CollectionHandlerEventArgs представляет аргументы события для изменения коллекции
    public class CollectionHandlerEventArgs : EventArgs
    {
        // Свойство для хранения типа изменения (например, добавление, удаление)
        public string ChangeType { get; set; }

        // Свойство для хранения измененного элемента
        public object ChangedItem { get; set; }

        // Конструктор для инициализации свойств ChangeType и ChangedItem
        public CollectionHandlerEventArgs(string changeType, object changedItem)
        {
            ChangeType = changeType;
            ChangedItem = changedItem;
        }

        // Переопределение метода ToString для предоставления значимого строкового представления аргументов события
        public override string ToString()
        {
            return $"ChangeType: {ChangeType}, ChangedItem: {ChangedItem}";
        }
    }
}