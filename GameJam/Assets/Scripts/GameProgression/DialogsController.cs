using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogsController : MonoBehaviour
{
    [SerializeField] DialogWindowController dialogWindow;
    public InputActionAsset inputActions;
    private InputAction dialogAction;
    public static DialogsController Instance { get; private set; }
    public event Action dialogStarts;
    public event Action dialogEnds;

    private bool isLastLine = true;
    private List<string> currlines;
    

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

    void OnEnable()
    {
        dialogAction.started += OnDialogPerformed;
        dialogEnds += dialogWindow.CloseDialog;
        dialogStarts += dialogWindow.ShowDialog;
        dialogAction.Enable();  
    }
    void OnDisable()
    {
        dialogAction.started -= OnDialogPerformed;
        dialogEnds -= dialogWindow.CloseDialog;
        dialogStarts -= dialogWindow.ShowDialog;
        dialogAction.Disable();  
    }
    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    public void Description(string objectDescription)
    {
        isLastLine = true;
        dialogStarts.Invoke();
        dialogWindow.ShowDialog();
        dialogWindow.SetInfoText(objectDescription);
    }

    public void MonologStart(List<string> lines)
    {
        currlines = new List<string>(lines);
        isLastLine = false;
        dialogStarts.Invoke();
        dialogWindow.ShowDialog();
        ShowNextLine();
    }

    public void OnDialogPerformed(InputAction.CallbackContext context)
    {
        if (isLastLine)
        {
            dialogEnds.Invoke();
            return;
        }
        ShowNextLine();
    }

    private void ShowNextLine()
    {
        if (currlines.Count == 1) isLastLine = true;
        else isLastLine = false;
        dialogWindow.SetInfoText(currlines[0]);
        currlines.RemoveAt(0);
    }

}