using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SwitchButton : MonoBehaviour
{
    public TMP_Text uiText; 
    void Start()
    {
        uiText = GetComponentInChildren<TMP_Text>(); 

    }
    public void ChangeText()
    {
        print(uiText.text.ToString());
        if (uiText.text.ToString()=="Not Done") {
            
            uiText.text = "Done";
        } else {
            uiText.text = "Not Done";
        }
    }
}
