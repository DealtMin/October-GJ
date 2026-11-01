using UnityEngine;

public class EatScript : MonoBehaviour, IEdible
{
    
    [SerializeField] AudioClip audioClip;
    
    private IAudioService _audio;
    HasDialog _hasDialog;

    void Awake()
    {
        _audio = ServiceLocator.Get<IAudioService>();
        _hasDialog = GetComponent<HasDialog>();
    }

    void Start()
    {
        CollectableController.AddItem(this);
    }

    public bool Eat()
    {
        if (_hasDialog.IsDialogReaden())
        {
            Debug.Log(gameObject.name + " съеден");
            _audio.PlaySound(audioClip);
            Destroy(gameObject);
            CollectableController.CollectItem(this);
            return true;
        }
        return false;
    }
}
