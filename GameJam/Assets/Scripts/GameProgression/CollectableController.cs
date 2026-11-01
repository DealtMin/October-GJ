using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CollectableController : MonoBehaviour
{
    static public Dictionary<IEdible, bool> items {get; private set;}
    [SerializeField] private GameObject[] edibles;

    void Awake()
    {
        items = new Dictionary<IEdible, bool>();
        foreach (var item in edibles) items[item.GetComponent<IEdible>()] = false;      
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
