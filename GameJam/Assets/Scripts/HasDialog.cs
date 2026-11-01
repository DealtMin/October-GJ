using UnityEngine;

public class HasDialog : MonoBehaviour, IInteractable
{
    private InteractableSoViewer objectInfo;

    private bool _isDialogReaden=false;
    public bool IsDialogReaden()
    {
        return _isDialogReaden;
    }
    
    
    void Awake()
    {
        objectInfo = GetComponent<InteractableSoViewer>();
    }

    public void Interact()
    {
        DialogsController.Instance.Description(objectInfo.description);
        _isDialogReaden=true;
    }
}
