using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NameInputField : MonoBehaviour
{
    public string thename;
    public TMP_InputField inputField;
    public TMP_Text textdisplay;

    public void StoreName()
    {
        thename = inputField.text;
        textdisplay.text = thename ;
    }
}