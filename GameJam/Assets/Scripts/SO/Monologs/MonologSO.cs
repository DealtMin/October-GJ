using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonologSO", menuName = "Scriptable Objects/MonologSO")]
public class MonologSO : ScriptableObject
{
    [SerializeField] private List<string> lines;
    public List<string> monologlines => lines;
}
