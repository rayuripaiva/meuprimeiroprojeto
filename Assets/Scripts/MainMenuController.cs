using TMPro;
using UnityEngine;

public class WinnerDisplay : MonoBehaviour
{
    public TextMeshProUGUI uiWinner;

    void Start()
    {
        var save = SaveController.Instance;
        save.Reset();

        string lastWinner = save.GetLastWinner();
        uiWinner.text = !string.IsNullOrEmpty(lastWinner) ? $"Último vencedor: {lastWinner}" : "";
    }
}
