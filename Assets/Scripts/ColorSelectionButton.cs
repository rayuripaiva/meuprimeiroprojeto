using UnityEngine;
using UnityEngine.UI;

public class ColorSelectionButton : MonoBehaviour
{
    public Button uiButton;
    public Image paddleReference;
    public bool isColorPlayer = false;

    
    public Color buttonColor = Color.white;

    private void Start()
    {
        if (uiButton == null) uiButton = GetComponent<Button>();
    }

    public void OnButtonClick()
    {
        
        paddleReference.color = buttonColor;

        var save = SaveController.Instance;
        if (isColorPlayer)
        {
            save.colorPlayer = buttonColor;
        }
        else
        {
            save.colorEnemy = buttonColor;
        }
    }
}
