using TMPro;
using UnityEngine;

public class DialogWindowController : MonoBehaviour
{
    [SerializeField] TMP_Text dialogText;
    [SerializeField] GameObject dialogPanel;

    public void SetInfoText(string text)
    {
        dialogText.text = text;
        ShowDialog();
        Invoke(nameof(CloseDialog), 4f);
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
