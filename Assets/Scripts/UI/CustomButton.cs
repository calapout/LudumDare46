using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CustomButton : MonoBehaviour
{
    public Color hoverColor;
    public Button btn;
    public Text btnText;
    private Color prevColor;
    private void Awake()
    {
        prevColor = btnText.color;
    }
}
