using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ProgramManager : MonoBehaviour
{
    public TMP_Text questionText;
    public Button[] answerButtons; // array of buttons for the answer options

    private QuestionList questionList; // list of all questions
    private ProgramQuestion currentQuestion;

    private void Start()
    {
        LoadQuestions(); // Load questions from the JSON file
        DisplayRandomQuestion(); // Display the first question
    }

    private void LoadQuestions()
    {
        TextAsset json = Resources.Load<TextAsset>("programquestions"); // Load JSON file from Resources
        if (json == null)
        {
            Debug.LogError("Failed to load JSON file. Make sure it exists in the Resources folder.");
            return;
        }
        questionList = JsonUtility.FromJson<QuestionList>(json.text); // Deserialize the JSON into QuestionList
        if (questionList == null || questionList.questions.Length == 0)
        {
            Debug.LogError("No questions loaded! Check your JSON file or path.");
        }
    }

    private void DisplayRandomQuestion()
    {
        // Ensure there are questions to choose from
        if (questionList.questions.Length == 0) return;

        currentQuestion = questionList.questions[Random.Range(0, questionList.questions.Length)];

        // Debugging: Check what the current question is
        Debug.Log("Current Question: " + currentQuestion.questionsText);

        // Update the question text
        questionText.text = currentQuestion.questionsText; // Ensure this is updating

        // Set up answer buttons
        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i < currentQuestion.answers.Length)
            {
                answerButtons[i].gameObject.SetActive(true);
                answerButtons[i].GetComponentInChildren<TMP_Text>().text = currentQuestion.answers[i].answerText;
                int index = i; // Capture the index for the listener
                answerButtons[i].onClick.RemoveAllListeners();
                answerButtons[i].onClick.AddListener(() => OnAnswerSelected(index));
            }
            else
            {
                answerButtons[i].gameObject.SetActive(false); // Hide unused buttons
            }
        }
    }

private void OnAnswerSelected(int answerIndex)
    {
        // Handle the selected answer (e.g., scoring, feedback)
        Debug.Log("Selected answer: " + currentQuestion.answers[answerIndex].answerText);

        // Display a new question
        DisplayRandomQuestion();
    }
}