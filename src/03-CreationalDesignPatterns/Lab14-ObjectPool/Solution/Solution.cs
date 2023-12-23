using System;
using System.Collections.Generic;

namespace Lab14_ObjectPool.Solution;

// Object pool class
class ObjectPool<T>
{
    // List of pre-initialized objects
    private List<T> _objects;

    public int Count => _objects.Count;

    // Initialize the object pool with a specified number of objects
    public ObjectPool(int size)
    {
        _objects = new List<T>(size);
        for (int i = 0; i < size; i++)
        {
            _objects.Add(Activator.CreateInstance<T>());
        }
    }

    // Get an object from the pool
    public T GetObject()
    {
        if (_objects.Count > 0)
        {
            T obj = _objects[0];
            _objects.RemoveAt(0);
            return obj;
        }
        else
        {
            // In this example, we just create a new object if the pool is empty.
            // You could also throw an exception or return a null value here.
            return Activator.CreateInstance<T>();
        }
    }

    // Return an object to the pool
    public void ReturnObject(T obj)
    {
        _objects.Add(obj);
    }
}

class NPC
{
    public string Color { get; set; }
}

class Client
{
    public void Test()
    {
        // Create an object pool for strings with 50 NPC objects
        ObjectPool<NPC> stringPool = new ObjectPool<NPC>(50);
        Console.WriteLine($"Currently Object Pool has {stringPool.Count} items");

        // Get a NPC object from the pool and do something with it
        var npc = stringPool.GetObject();
        Console.WriteLine("An object from object pool is retieved: " + npc);

        Console.WriteLine($"Currently Object Pool has {stringPool.Count} items");

        // Return the NPC object to the pool
        stringPool.ReturnObject(npc);

        Console.WriteLine($"Currently Object Pool has {stringPool.Count} items");
    }
}
