using UnityEngine;

public class HasDialog : MonoBehaviour, IInteractable
{
    private InteractableSoViewer objectInfo;

    void Awake()
    {
        objectInfo = GetComponent<InteractableSoViewer>();
    }

    public void Interact()
    {
        DialogsController.Instance.Description(objectInfo.description);
    }
}
