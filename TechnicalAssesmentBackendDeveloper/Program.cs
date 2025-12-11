using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Item Manager!");

        ItemManager manager = new ItemManager();

        // Part One: Fix the NullReferenceException — DONE
        manager.AddItem("Apple");
        manager.AddItem("Banana");

        manager.PrintAllItems();

        // Part Two: Implement the RemoveItem method — DONE
        manager.RemoveItem("Apple");

        
    }
}

public class ItemManager
{
    // FIXED: Proper initialization to avoid NullReferenceException
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

    public void RemoveItem(string item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Console.WriteLine($"{item} has been removed.");
        }
        else
        {
            Console.WriteLine($"{item} not found in the list.");
        }
    }

    public void ClearAllItems()
    {
        items = new List<string>();
    }
}

public class ItemManager<T>
{
    // FIXED: Proper initialization
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
        items = new List<T>();
    }
}
