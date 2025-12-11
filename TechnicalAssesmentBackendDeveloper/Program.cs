using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Item Manager!");

        ItemManager manager = new ItemManager();

        // Part One: Fix the NullReferenceException — NOW FIXED
        manager.AddItem("Apple");
        manager.AddItem("Banana");

        manager.PrintAllItems();

        // Part Two: Implement the RemoveItem method
        manager.RemoveItem("Apple");

        // Part Three: Introduce a Fruit class and use ItemManager<Fruit>
        // TODO: Implement this part three.

        // Part Four: Implement an interface IItemManager and make ItemManager implement it.
        // TODO: Implement this part four.
    }
}

public class ItemManager
{
    // FIX: Initialize list to avoid NullReferenceException
    private List<string> items = new List<string>();

    public void AddItem(string item)
    {
        items.Add(item);
    }

    public void PrintAllItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    // Part Two: To be implemented later
    public void RemoveItem(string item)
    {
        throw new NotImplementedException("RemoveItem method is not implemented yet. Please remove this line and implement this method.");
    }

    public void ClearAllItems()
    {
        // FIX: Replace invalid [] syntax
        items = new List<string>();
    }
}

public class ItemManager<T>
{
    // FIX: Initialize list
    private List<T> items = new List<T>();

    public void AddItem(T item)
    {
        items.Add(item);
    }

    public void PrintAllItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public void ClearAllItems()
    {
        // FIX: Replace invalid [] syntax
        items = new List<T>();
    }
}
