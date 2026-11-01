using System.Collections.Generic;
using UnityEngine;

public class MonologSOViewer : MonoBehaviour
{
    [SerializeField] private MonologSO monologObject;
    public List<string> monologlines { get; private set; }
    private void Awake()
    {
        monologlines = monologObject.monologlines;
    }
}
