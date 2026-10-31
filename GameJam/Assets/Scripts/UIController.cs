using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] float scaleFactor;
    [SerializeField] Sprite buttonHoverSprite;
    [SerializeField] Sprite buttonIdleSprite;
    
    public void OnHoverEnter(Transform obj)
    {
        obj.localScale *= scaleFactor;
    }
    
    public void OnHoverExit(Transform obj)
    {
        obj.localScale /= scaleFactor;
        
    }

    public void ChangeSpriteHover(SpriteRenderer renderer)
    {
        renderer.sprite = buttonHoverSprite;
    }
    
    public void ChangeSpriteExit(SpriteRenderer renderer)
    {
        renderer.sprite = buttonIdleSprite;
    }
}
