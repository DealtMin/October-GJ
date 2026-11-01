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

    public bool Eat()
    {
        if (_hasDialog.IsDialogReaden())
        {            
            Debug.Log(gameObject.name + " съеден");
            _audio.PlaySound(audioClip);            
            CollectableController.CollectItem(this);
            StoryController.ItemCollected.Invoke();
            Destroy(gameObject);
            return true;
        }
        return false;
    }
}
