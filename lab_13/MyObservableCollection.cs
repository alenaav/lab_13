using AutomobileLibrary;
using lab_13;
using lab12_4;
using System;
using System.Collections;
using System.Collections.Generic;

namespace lab13;

public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);

public class MyObservableCollection<T> : MyCollection<T> where T : IInit, ICloneable, IComparable, new()
{
    public event CollectionHandler CollectionCountChanged;
    public event CollectionHandler CollectionReferenceChanged;

    public MyObservableCollection() : base() { }

    public MyObservableCollection(int length) : base(length) { }

    public MyObservableCollection(MyCollection<T> c) : base(c) { }

    public new void Add(T item)
    {
        base.AddPoint(item);
        OnCollectionCountChanged(new CollectionHandlerEventArgs("Item Added", item));
    }

    public new bool Remove(T item)
    {
        bool result = base.RemoveData(item);
        if (result)
        {
            OnCollectionCountChanged(new CollectionHandlerEventArgs("Item Removed", item));
        }
        return result;
    }

    protected virtual void OnCollectionCountChanged(CollectionHandlerEventArgs e)
    {
        CollectionCountChanged?.Invoke(this, e);
    }

    protected virtual void OnCollectionReferenceChanged(CollectionHandlerEventArgs e)
    {
        CollectionReferenceChanged?.Invoke(this, e);
    }

    public T this[int index]
    {
        get
        {
            Point<T> current = GetPointAtIndex(index);
            return current.Data;
        }
        set
        {
            Point<T> current = GetPointAtIndex(index);
            current.Data = value;
            OnCollectionReferenceChanged(new CollectionHandlerEventArgs("Item Replaced", value));
        }
    }

    private Point<T> GetPointAtIndex(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }

        Point<T> current = beg;
        for (int i = 0; i < index; i++)
        {
            if (current.Next == null)
            {
                throw new InvalidOperationException("The collection is corrupted.");
            }
            current = current.Next;
        }
        return current;
    }
}