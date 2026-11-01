using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogWindowController : MonoBehaviour
{
    [SerializeField] TMP_Text dialogText;
    [SerializeField] GameObject dialogPanel;

    public void SetInfoText(string text)
    {
        dialogText.text = text;
        ShowDialog();
        //Invoke(nameof(CloseDialog), 4f);
    }

    public void ShowDialog()
    {
        dialogPanel.SetActive(true);
        DialogsController.Instance.dialogAction.started += OnDialogPerformed;
    }

    public void CloseDialog()
    {
        dialogPanel.SetActive(false);
        DialogsController.Instance.dialogAction.started -= OnDialogPerformed;
    }

    public void OnDialogPerformed(InputAction.CallbackContext context)
    {
        CloseDialog();
    }
}
