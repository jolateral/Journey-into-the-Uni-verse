using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ActuallyHatCustomizer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<Image> hatImages; // List of hat sprites to choose from
    private int currentHatIndex = 0;
    private int requiredScore = 25;

    void Start()
    {
        // Display the first hat by default
        //GameManager.score=500;
        for (int i=0; i<hatImages.Count;i++) {
            if (i!=currentHatIndex) {
                Color color = hatImages[i].color;
                color.a = 0f; // Set alpha to 0
                hatImages[i].color = color;
            } else {
                Color color = hatImages[i].color;
                color.a = 1f; // Set alpha to 0
                hatImages[i].color = color;
            }
        }
    }

    public void NextHat()
    {
        currentHatIndex = (currentHatIndex + 1) % hatImages.Count;
        if (currentHatIndex>= GameManager.score/requiredScore) {
            currentHatIndex=0;
        }
        for (int i=0; i<hatImages.Count;i++) {
            if (i!=currentHatIndex) {
                Color color = hatImages[i].color;
                color.a = 0f; // Set alpha to 0
                hatImages[i].color = color;
            } else {
                Color color = hatImages[i].color;
                color.a = 1f; // Set alpha to 0
                hatImages[i].color = color;
            }
        }
    }

    public void PreviousHat()
    {
        
        currentHatIndex = (currentHatIndex - 1 + hatImages.Count) % hatImages.Count;
        if (currentHatIndex>= GameManager.score/requiredScore) {
            currentHatIndex=0;
        }
        for (int i=0; i<hatImages.Count;i++) {
            if (i!=currentHatIndex) {
                Color color = hatImages[i].color;
                color.a = 0f; // Set alpha to 0
                hatImages[i].color = color;
            } else {
                Color color = hatImages[i].color;
                color.a = 1f; // Set alpha to 0
                hatImages[i].color = color;
            }
        }
    }
}
