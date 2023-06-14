using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NameInputField : MonoBehaviour
{
    public string thename;
    public TMP_InputField inputField;
    public TMP_Text textdisplay;
    public static string thename1;

    public void StoreName()
    {
        thename = inputField.text;
        thename1=thename;
        textdisplay.text = thename ;
    }
}