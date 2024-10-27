using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatCustomizer : MonoBehaviour
{
    public List<Sprite> hatSprites; // List of hat sprites to choose from
    public Image hatImage; // The Image component that will display the hat
    private int currentHatIndex = 0;

    private int requiredScore = 10;
    void Start()
    {
        // Display the first hat by default
        UpdateHat();
    }

    public void NextHat()
    {

        currentHatIndex = (currentHatIndex + 1) % (hatSprites.Count);
        if (currentHatIndex>= GameManager.score/requiredScore) {
            currentHatIndex=0;
        }
        UpdateHat();
    }

    public void PreviousHat()
    {
        currentHatIndex = (currentHatIndex - 1 + hatSprites.Count) % hatSprites.Count;
        if (currentHatIndex>= GameManager.score/requiredScore) {
            currentHatIndex=0;
        }
        UpdateHat();
    }

    void UpdateHat()
    {
        // Set the hat sprite based on the current index
        hatImage.sprite = hatSprites[currentHatIndex];
    }
}

