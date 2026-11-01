using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CollectableController : MonoBehaviour
{
    static public Dictionary<IEdible, bool> items {get; private set;}

    void Awake()
    {
        items = new Dictionary<IEdible, bool>();
    }

    static public void AddItem(IEdible item)
    {
        if (items.ContainsKey(item)) return;
        items[item] = false;
    }

    static public void CollectItem(IEdible item)
    {
         items[item] = true;
    }

    static public int CollectedCount()
    {
        return items.Count(kvp => kvp.Value);        
    }
}
