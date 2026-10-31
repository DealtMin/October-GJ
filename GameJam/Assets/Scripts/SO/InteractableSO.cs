using UnityEngine;

[CreateAssetMenu(fileName = "Interactable", menuName = "Scriptable Objects/Interactable")]
public class Interactable_SO : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private bool isEatable;
    
    public string objectName => name; 
    public bool objectIsEatable => isEatable;
    public string objectDescription => description; 
}