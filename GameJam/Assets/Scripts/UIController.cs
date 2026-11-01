using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] float scaleFactor;
    [SerializeField] Sprite buttonHoverSprite;
    [SerializeField] Sprite buttonIdleSprite;
    [SerializeField] GameObject settingsPanel;

    [SerializeField] private Sprite eyesOpen;
    [SerializeField] private Sprite eyesClosed;

    [SerializeField] private Image leftGirl;
    [SerializeField] private Image rightGirl;

    [SerializeField] private GameObject[] panels;
    
    private IAudioService _audio;
    [Header("For audio service")]
    [SerializeField] private AudioSource source;
    [SerializeField] private Slider slider;
    [SerializeField] private AudioMixer mixer;

    void Awake()
    {
        ServiceLocator.Register<IAudioService>(new AudioService(source, slider, mixer));
        
        _audio = ServiceLocator.Get<IAudioService>();
    }
    
    public void OnExitHover()
    {
        leftGirl.sprite = eyesClosed;
        rightGirl.sprite = eyesOpen;
    }
    
    public void OnPlayHover()
    {
        rightGirl.sprite = eyesClosed;
        leftGirl.sprite = eyesOpen;
    }
    
    public void OnHoverEnter(Transform obj)
    {
        obj.localScale *= scaleFactor;
    }
    
    public void OnHoverExit(Transform obj)
    {
        obj.localScale /= scaleFactor;
        leftGirl.sprite = eyesClosed;
        rightGirl.sprite = eyesClosed;
        
    }
    
    public void SetVolumeBySlider()
    {
        _audio.SetMasterVolume();
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

    public void OpenPanel(GameObject panel)
    {
        foreach (GameObject panelObj in panels)
            panelObj.SetActive(false);
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
}
