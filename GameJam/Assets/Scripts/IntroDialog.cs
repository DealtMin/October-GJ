using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroDialog : MonoBehaviour
{
    [SerializeField] MonologSO monolog;
    [SerializeField] DialogsController dialogsController;
    [SerializeField] private SpriteRenderer girl;
    [SerializeField] private Sprite newSprite;
    void Start()
    {        
        dialogsController.MonologStart(monolog.monologlines);
    }
    void OnEnable()
    {
        dialogsController.dialogEnds += EndDialog;
    }

    void OnDisable()
    {
        dialogsController.dialogEnds -= EndDialog;
    }

    void EndDialog()
    {
        girl.sprite = newSprite;
        Invoke("LoadMain", 3f);
    }

    private void LoadMain()
    {
        SceneManager.LoadScene("Main");
    }

}
