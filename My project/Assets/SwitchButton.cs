using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SwitchButton : MonoBehaviour
{
    public GameObject image1; 
    public GameObject image2;
    
    public void ChangeImage()
    {
        if (image1.activeSelf)
        {
            image1.SetActive(false);  // Deactivate Image1
            image2.SetActive(true);   // Activate Image2
        }
        else
        {
            image1.SetActive(true);   // Activate Image1
            image2.SetActive(false);  // Deactivate Image2
        }
    }
}
