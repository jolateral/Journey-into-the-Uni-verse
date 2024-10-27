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
    private int totalLength = 0;
    public GameObject currentCanvas;
    public GameObject nextCanvas;
    public TMP_InputField userInputField; // Reference to the InputField
    public Button submitButton; // Reference to the Submit Button
    private string filePath;
    public TMP_Text displayText;
    public TMP_Text score_text;
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

        nextCanvas.SetActive(false);
    
    }

    private void Start()
        {
            // Add listener to the submit button
            submitButton.onClick.AddListener(OnSubmit);
            ResetDataFile();
        }
    
     public void OnSubmit()
    {

        string inputText = readInterviewInput.GetInput();
        

        Debug.Log("Text entered: " + inputText);


        if (!string.IsNullOrEmpty(inputText))
        {
            SaveText(inputText); // Save if not empty
            submitCounter++;
            totalLength += inputText.Length;
            if(submitCounter >= maxCounter)
            {
                DetermineScore();
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

        

        if (string.IsNullOrWhiteSpace(text))
        {
            Debug.LogWarning("Empty string detected, not saving.");
            return;
        }
        

        string json = JsonUtility.ToJson(entryList, true);

        File.WriteAllText(filePath, json);

        ClearField();

        readInterviewInput.ReadStringInput(""); 


        
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
        DisplaySavedData();
    }

    private void DisplaySavedData()
    {
        TextEntryList entryList = LoadData();
        string allEntries = "";

        foreach (TextEntry entry in entryList.entries)
        {
            allEntries += entry.entry + "\n";
        }

        if (displayText != null)
        {
            displayText.text = allEntries;
        }
        else
        {
            Debug.LogError("Display Text is not assigned");
        }
    }

    private void ResetDataFile()
    {
        TextEntryList entryList = new TextEntryList();
        string json = JsonUtility.ToJson(entryList, true);
        File.WriteAllText(filePath, json);
        Debug.Log("Data file has been reset.");
    }

    private void DetermineScore()
    {
        string score = "";
        int scoreint = 0;

        if(totalLength >= 150)
        {
            score = "Your Score: 10/10";
            scoreint = 10;
        }
        else if (totalLength >= 130)
        {
            score = "Your Score: 9/10";
            scoreint = 9;

        }
        else if (totalLength >= 110)
        {
            score = "Your Score: 8/10";
            scoreint = 8;
        }
        else if (totalLength >= 90)
        {
            score = "Your Score: 7/10";
            scoreint = 7;
        }
        else if (totalLength >= 70)
        {
            score = "Your Score: 6/10";
            scoreint = 6;
        }
        else if (totalLength >= 50)
        {
            score = "Your Score: 5/10";
            scoreint = 5;
        }
        else if (totalLength >= 30)
        {
            score = "Your Score: 4/10";
            scoreint = 4;
        }
        else if (totalLength >= 10)
        {
            score = "Your Score: 2/10";
            scoreint = 2;
        }
        else 
        {
            score = "Your Score: 0/10";
        }
        
        if (score_text != null)
        {
            score_text.text = score;
        }

        GameManager.score += scoreint;

        
    }
}
