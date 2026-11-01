using Unity.VisualScripting;
using UnityEngine;

public class Traps : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    
    [SerializeField] Transform respawnPoint;
    
    private IAudioService _audio;

    void Awake()
    {
        _audio = ServiceLocator.Get<IAudioService>();
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            _audio.PlaySound(audioClip);
            collision.transform.position = respawnPoint.position;
        }
    }

    public void SetRespawn(Transform respawn)
    {
        respawnPoint = respawn;
    }
}
