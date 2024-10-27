using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

[System.Serializable]
public class ButtonData
{
    public List<int> currentIndex; // Index of the currently selected button image
}

public class SwitchButton : MonoBehaviour
{
    public int cur_index;
    public List<Sprite> buttonImages; // List of button images to switch between
    public Button button;              // Reference to the UI Button
    private string filePath;           // Path to save button data

    void Start()
    {
        // Set the file path to save button data
        filePath = Path.Combine(Application.persistentDataPath, "buttonData.json");
        Debug.Log(filePath);

        // Load previous data if it exists
        if(! File.Exists(filePath)) {
            ButtonData buttonData = new ButtonData{
                currentIndex = new List<int>() {0,0,0,0,0,0,0}
            };
            SaveButtonData(buttonData);
        } else {
            LoadButtonData();
        }
    }

    public void ChangeButtonImage(int index)
    {
        // Cycle through the button images
        if (buttonImages.Count == 0)
        {
            Debug.LogWarning("Button images list is empty, cannot change image.");
            return;
        }

        // Get the current index and calculate the next index
        ButtonData buttonData = LoadButtonDataFromJson();
        int state = buttonData.currentIndex[index - 1];
        state = (state + 1) % buttonImages.Count;

        // Change the button's image
        button.image.sprite = buttonImages[state];

        // Save the button data
        buttonData.currentIndex[index - 1] = state;
        SaveButtonData(buttonData);
        Debug.Log($"Button image changed to {buttonImages[state].name} and data saved.");
    }

    private void SaveButtonData(ButtonData buttonData)
    {
        string json = JsonUtility.ToJson(buttonData, true);
        File.WriteAllText(filePath, json);
        Debug.Log("Button data saved: " + json);
    }

    private ButtonData LoadButtonDataFromJson()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<ButtonData>(json);
        }
        else
        {
            Debug.Log("No previous button data found, starting fresh.");
            return new ButtonData {};

        }
    }

    private void LoadButtonData()
    {
        ButtonData buttonData = LoadButtonDataFromJson();
        button.image.sprite = buttonImages[buttonData.currentIndex[cur_index- 1]];
        // Load the button image if the path exists
        // if (buttonData.currentIndex[index - 1] >= 0 && buttonData.currentIndex[index - 1] < buttonImages.Count)
        // {
        //     button.image.sprite = buttonImages[buttonData.currentIndex[index - 1]];
        //     Debug.Log($"Button image loaded: {buttonImages[buttonData.currentIndex[index - 1]].name}");
        // }
        // else
        // {
        //     Debug.LogWarning("Current index out of range, using default image.");
        //     button.image.sprite = buttonImages[0]; // Fallback to first image if out of range
        // }
    }
}
 