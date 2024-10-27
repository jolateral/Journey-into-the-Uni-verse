using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;

public class InterviewManager : MonoBehaviour
{
    public TMP_Text questionText; // UI Text to display the question
    public Button submitButton; // UI Button for submitting answers
    private QuestionList questionList; // List of questions
    private Question currentQuestion; // Current question being displayed

    private void Start()
    {
        LoadQuestions(); // Load questions from JSON file
        DisplayRandomQuestion(); // Display a random question

        // Add listener for button click
        submitButton.onClick.AddListener(OnSubmit);
    }

    //private void LoadQuestions()
    //{
    //    // Load the JSON file from Resources
    //    TextAsset json = Resources.Load<TextAsset>("questions");
    //    questionList = JsonUtility.FromJson<QuestionList>(json.text);
    //}

    private void LoadQuestions()
    {
        TextAsset json = Resources.Load<TextAsset>("questions");
        questionList = JsonUtility.FromJson<QuestionList>(json.text);

        // Debug to confirm questions were loaded
        if (questionList == null || questionList.questions.Length == 0)
        {
            Debug.LogError("No questions loaded! Check your JSON file or path.");
        }
        else
        {
            Debug.Log("Questions loaded successfully.");
        }
    }

    private void DisplayRandomQuestion()
    {
        // Select a random question
        currentQuestion = questionList.questions[Random.Range(0, questionList.questions.Length)];
        questionText.text = currentQuestion.questionText; // Update the UI text
    }

    private void OnSubmit()
    {
        // Display a new question
        DisplayRandomQuestion();
    }
}
