using UnityEngine;

public class InteractableSoViewer : MonoBehaviour
{
    [SerializeField] private Interactable_SO inetrObject;
    public string name { get; private set; }
    public bool isEatable { get; private set; }
    public string description { get; private set; }
    private void Awake()
    {
        name = inetrObject.objectName;
        isEatable = inetrObject.objectIsEatable;
        description = inetrObject.objectDescription;
    }

}