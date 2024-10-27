using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SwitchButton : MonoBehaviour
{
    public Sprite newButtonImage;
    public Button button;
    void Start()
    {

    }

    void Update()
    {

    }

    public void ChangeButtonImage()
    {
        button.image.sprite = newButtonImage;
    }
}
