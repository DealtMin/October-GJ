using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogsController : MonoBehaviour
{
    [SerializeField] DialogWindowController dialogWindow;
    public InputActionAsset inputActions;
    public InputAction dialogAction;
    public static DialogsController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        var playerMap = inputActions.FindActionMap("Player");
        dialogAction = playerMap.FindAction("Dialog");
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    public void Description(string objectDescription)
    {
        dialogWindow.ShowDialog();
        dialogWindow.SetInfoText(objectDescription);
    }

    public void CloseDescription()
    {
        dialogAction.started -= dialogWindow.OnDialogPerformed;
    }

    void OnDisable()
    {
        
    }

}