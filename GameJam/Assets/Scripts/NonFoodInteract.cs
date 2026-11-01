using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class NonFoodInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite newSprite;
    [SerializeField] private GameObject spawnedObject;
    private SpriteRenderer _spriteRenderer;
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Interact()
    {
        Debug.Log("Interact");
        _spriteRenderer.sprite = newSprite;
        spawnedObject.SetActive(true);
        Destroy(this);
    }
}
