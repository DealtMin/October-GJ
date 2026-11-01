using System.Collections.Generic;
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
    }

    public void ShowDialog()
    {
        dialogPanel.SetActive(true);
    }

    public void CloseDialog()
    {
        dialogPanel.SetActive(false);
    }
}
