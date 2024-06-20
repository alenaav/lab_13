using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomobileLibrary;
using lab_13;
using System.Collections.ObjectModel;
using System;
using lab13;

namespace TestLab_13
{
    [TestClass]
    public class CollectionHandlerEventArgsTests
    {
        [TestMethod]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Установка
            string changeType = "Item Added";
            var changedItem = new object();

            // Действие
            var args = new CollectionHandlerEventArgs(changeType, changedItem);

            // Проверка
            Assert.AreEqual(changeType, args.ChangeType);
            Assert.AreEqual(changedItem, args.ChangedItem);
        }

        [TestMethod]
        public void ToString_ReturnsCorrectFormat()
        {
            string changeType = "Item Added";
            var changedItem = new object();
            var args = new CollectionHandlerEventArgs(changeType, changedItem);

            string result = args.ToString();

            Assert.AreEqual($"ChangeType: {changeType}, ChangedItem: {changedItem}", result);
        }
    }

    [TestClass]
    public class JournalTests
    {
        private Journal journal;
        private CollectionHandlerEventArgs eventArgs;

        [TestInitialize]
        public void Setup()
        {
            journal = new Journal();
            eventArgs = new CollectionHandlerEventArgs("Item Added", new object());
        }

        [TestMethod]
        public void AddEntry_AddsEntryToJournal()
        {
            var source = new object();

            journal.AddEntry(source, eventArgs);

            Assert.AreEqual(1, journal.Entries.Count);
        }

        [TestMethod]
        public void PrintEntries_PrintsAllEntries()
        {
            var source = new object();
            journal.AddEntry(source, eventArgs);
            journal.AddEntry(source, eventArgs);

            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                journal.PrintEntries();

                var expectedOutput = string.Join(Environment.NewLine, journal.Entries) + Environment.NewLine;
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }
    }

    [TestClass]
    public class MyObservableCollectionTests
    {
        private MyObservableCollection<Automobile> collection;
        private Journal journal;

        [TestInitialize]
        public void Setup()
        {
            collection = new MyObservableCollection<Automobile>();
            journal = new Journal();
            collection.CollectionCountChanged += journal.AddEntry;
            collection.CollectionReferenceChanged += journal.AddEntry;
        }

        [TestMethod]
        public void Add_ItemAdded_RaisesCollectionCountChangedEvent()
        {
            var auto = new Automobile("BMW", 2022, "Red", 50000, 150, new IdNumber(1));

            collection.Add(auto);

            Assert.AreEqual(1, journal.Entries.Count);
            Assert.AreEqual("Item Added", journal.Entries[0].ChangeType);
        }

        [TestMethod]
        public void Remove_ItemRemoved_RaisesCollectionCountChangedEvent()
        {
            var auto = new Automobile("BMW", 2022, "Red", 50000, 150, new IdNumber(1));
            collection.Add(auto);

            collection.Remove(auto);

            Assert.AreEqual(2, journal.Entries.Count);
            Assert.AreEqual("Item Removed", journal.Entries[1].ChangeType);
        }

        [TestMethod]
        public void Indexer_SetItem_RaisesCollectionReferenceChangedEvent()
        {
            var auto = new Automobile("BMW", 2022, "Red", 50000, 150, new IdNumber(1));
            collection.Add(auto);

            collection[0] = new Automobile("Audi", 2022, "Blue", 60000, 160, new IdNumber(2));

            Assert.AreEqual(2, journal.Entries.Count);
            Assert.AreEqual("Item Replaced", journal.Entries[1].ChangeType);
        }

        [TestMethod]
        public void GetPointAtIndex_ValidIndex_ReturnsCorrectPoint()
        {
            var auto1 = new Automobile("BMW", 2022, "Red", 50000, 150, new IdNumber(1));
            var auto2 = new Automobile("Audi", 2022, "Blue", 60000, 160, new IdNumber(2));
            collection.Add(auto1);
            collection.Add(auto2);

            var result = collection[1];

            Assert.AreEqual(auto2, result);
        }

        [TestMethod]
        public void GetPointAtIndex_InvalidIndex_ThrowsArgumentOutOfRangeException()
        {
            var auto = new Automobile("BMW", 2022, "Red", 50000, 150, new IdNumber(1));
            collection.Add(auto);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { var result = collection[1]; });
        }
    }
}
