using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroDialog : MonoBehaviour
{
    [SerializeField] MonologSO monolog;
    [SerializeField] DialogsController dialogsController;
    void Start()
    {        
        dialogsController.MonologStart(monolog.monologlines);
    }
    void OnEnable()
    {
        dialogsController.dialogEnds += LoadMain;
    }

    void OnDisable()
    {
        dialogsController.dialogEnds -= LoadMain;
    }

    private void LoadMain()
    {
        SceneManager.LoadScene("Main");
    }

}
