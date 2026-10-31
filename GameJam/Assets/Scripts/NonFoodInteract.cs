using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class NonFoodInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite newSprite;
    private SpriteRenderer _spriteRenderer;
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Interact()
    {
        _spriteRenderer.sprite = newSprite;
    }
}
