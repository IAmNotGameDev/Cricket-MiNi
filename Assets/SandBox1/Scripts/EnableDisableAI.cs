using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnableDisableAIButton : MonoBehaviour
{
    public BattingAI battingAI;
    public Button button;
    public Color enabledColor = Color.red;
    public Color disabledColor = Color.white;

    void Start()
    {
        button.onClick.AddListener(ToggleAI);
    }

    void ToggleAI()
    {
        if (battingAI.enabled)
        {
            battingAI.enabled = false;
            button.GetComponent<Image>().color = disabledColor;
        }
        else
        {
            battingAI.enabled = true;
            button.GetComponent<Image>().color = enabledColor;
        }
    }
}
