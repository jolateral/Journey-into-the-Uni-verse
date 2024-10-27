using UnityEngine;
using TMPro;

public class SubmitButton : MonoBehaviour
{
    public TMP_InputField answerInputField;

    public void ClearField()
    {
        answerInputField.text = ""; // clear the input field
    }
}
