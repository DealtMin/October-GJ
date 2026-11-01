using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class FinalComixController : MonoBehaviour
{
    [SerializeField] GameObject[] pages;
    [SerializeField] private GameObject pagesParentObj;
    [SerializeField] GameObject text;
    
    public InputActionAsset inputActions;
    private InputAction changeAction;
    int currentPage = 0;
    

    void Awake()
    {
        pages[0].GameObject().SetActive(true);
        var playerMap = inputActions.FindActionMap("Player");
        changeAction = playerMap.FindAction("Eat");
    }
    
    private void OnEnable()
    {        
 
        changeAction.started += OnChangePerformed;
        changeAction.Enable(); 
    }
    

    private void OnDisable()
    {
        changeAction.started -= OnChangePerformed;
        changeAction.Disable(); 
      
    }
    
    private void OnChangePerformed(InputAction.CallbackContext context)
    {
        pages[currentPage].SetActive(false);
        currentPage += 1;
        if  (currentPage != pages.Length)
            pages[currentPage].SetActive(true);
        else text.SetActive(true);
    }
}
