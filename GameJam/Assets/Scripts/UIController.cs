using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] float scaleFactor;
    [SerializeField] Sprite buttonHoverSprite;
    [SerializeField] Sprite buttonIdleSprite;
    [SerializeField] GameObject settingsPanel;
    
    public void OnHoverEnter(Transform obj)
    {
        obj.localScale *= scaleFactor;
    }
    
    public void OnHoverExit(Transform obj)
    {
        obj.localScale /= scaleFactor;
        
    }

    public void ChangeImageHover(Button button)
    {
        button.image.sprite = buttonHoverSprite;
    }
    
    public void ChangeImageExit(Button button)
    {
        button.image.sprite = buttonIdleSprite;
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
}
