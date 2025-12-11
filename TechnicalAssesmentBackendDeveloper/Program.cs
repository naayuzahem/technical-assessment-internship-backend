using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Item Manager!");

        ItemManager manager = new ItemManager();

        manager.AddItem("Apple");
        manager.AddItem("Banana");

        // Print BEFORE removing
        manager.PrintAllItems();

        // Remove Apple
        manager.RemoveItem("Apple");

        // Print AFTER removing
        manager.PrintAllItems();

        // Part Three: Using ItemManager<Fruit>
        ItemManager<Fruit> fruitManager = new ItemManager<Fruit>();

        fruitManager.AddItem(new Fruit("Apple", "Red"));
        fruitManager.AddItem(new Fruit("Banana", "Yellow"));
        fruitManager.AddItem(new Fruit("Grapes", "Purple"));

        Console.WriteLine("\nFruit List:");
        fruitManager.PrintAllItems();
    }
}

public class ItemManager
{
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

public class Fruit
{
    public string Name { get; set; }
    public string Color { get; set; }

    public Fruit(string name, string color)
    {
        Name = name;
        Color = color;
    }

    public override string ToString()
    {
        return $"{Name} ({Color})";
    }
}
