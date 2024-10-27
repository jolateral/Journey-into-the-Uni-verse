using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

[System.Serializable]
public class TextEntry
{
    public string entry;
}

[System.Serializable]
public class TextEntryList
{
    public List<TextEntry> entries = new List<TextEntry>();
}

public class DataManager : MonoBehaviour
{
    public ReadInterviewInput readInterviewInput;
    private int submitCounter = 0;
    private const int maxCounter = 5;   
    public GameObject currentCanvas;
    public GameObject nextCanvas;
    public TMP_InputField userInputField; // Reference to the InputField
    public Button submitButton; // Reference to the Submit Button
    private string filePath;
    private void Awake()
    {
        // Set the file path to the persistent data path
        filePath = Path.Combine(Application.dataPath, "Data", "textEntries.json");

        // Ensure the Data directory exists
        string directoryPath = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
            Debug.Log("Data directory created at: " + directoryPath);
        }
    
    }

    private void Start()
        {
            // Add listener to the submit button
            submitButton.onClick.AddListener(OnSubmit);
        }
    
     public void OnSubmit()
    {
        
        string inputText = readInterviewInput.GetInput();
        

        Debug.Log("Text entered: " + inputText);


        if (!string.IsNullOrEmpty(inputText))
        {
            SaveText(inputText); // Save if not empty
            submitCounter++;
            if(submitCounter >= maxCounter)
            {
                SwitchCanvas();
            }
            
        }
        else
        {
            Debug.LogWarning("Input field is empty or only contains spaces. Nothing to save.");
        }
    }

    public void SaveText(string text)
    {
        TextEntryList entryList = LoadData();

        entryList.entries.Add(new TextEntry { entry = text});

        string json = JsonUtility.ToJson(entryList, true);

        File.WriteAllText(filePath, json);

        ClearField();

        
    }

    public void ClearField()
    {
        userInputField.text = ""; // clear the input field
    }

    public TextEntryList LoadData()
    {
        if(!File.Exists(filePath))
        {
            return new TextEntryList();
        }

        string json = File.ReadAllText(filePath);
        return JsonUtility.FromJson<TextEntryList>(json);
    }

    private void SwitchCanvas()
    {
        currentCanvas.SetActive(false);
        nextCanvas.SetActive(true);
    }

    
}
