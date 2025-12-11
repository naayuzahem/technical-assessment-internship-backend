using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // PART 1: Add Items
        Console.WriteLine("PART 1: Add Items\n");

        ItemManager manager = new ItemManager();

        manager.AddItem("Apple");
        manager.AddItem("Banana");
        manager.PrintAllItems();

        Console.WriteLine(); // space between Part 1 and Part 2


        // PART 2: Remove an Item
        Console.WriteLine("PART 2: Remove an Item\n");

        manager.RemoveItem("Apple");
        manager.PrintAllItems();

        Console.WriteLine(); // space between Part 2 and Part 3


        // PART 3: Fruit Manager Output
        Console.WriteLine("PART 3: Fruit Manager Output\n");

        ItemManager<Fruit> fruitManager = new ItemManager<Fruit>();

        fruitManager.AddItem(new Fruit("Apple", "Red"));
        fruitManager.AddItem(new Fruit("Banana", "Yellow"));
        fruitManager.AddItem(new Fruit("Grapes", "Purple"));

        fruitManager.PrintAllItems();

        Console.WriteLine(); // final space
    }
}


// PART 4 — INTERFACES
public interface IItemManager
{
    void AddItem(string item);
    void RemoveItem(string item);
    void PrintAllItems();
    void ClearAllItems();
}

public interface IItemManager<T>
{
    void AddItem(T item);
    void PrintAllItems();
    void ClearAllItems();
}


// ItemManager implements IItemManager
public class ItemManager : IItemManager
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


// Generic ItemManager implements generic IItemManager
public class ItemManager<T> : IItemManager<T>
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


// Fruit Class (for Part 3)
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
