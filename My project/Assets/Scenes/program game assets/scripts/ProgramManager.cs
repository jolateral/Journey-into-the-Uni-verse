using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ProgramManager : MonoBehaviour
{
    public TMP_Text questionText;
    public Button[] answerButtons; // array of buttons for the answer options
    public GameObject csEngPanel; // Reference to the engineer results panel
    public GameObject LifeSciKinPanel; // Reference to the art results panel
    public GameObject HumanitiesBusinessPanel; // Reference to the science results panel
    public GameObject ArtArchPanel;
    public GameObject resultsPanel; // Reference to the results panel for ties

    private QuestionList questionList; // list of all questions
    private ProgramQuestion currentQuestion;
    private Points totalScore; // variable to accumulate points for each category
    private int totalQuestions; // to keep track of total questions answered
    private int questionsAnswered; // to keep track of questions answered

    private void Start()
    {
        LoadQuestions(); // Load questions from the JSON file
        totalQuestions = questionList.questions.Length; // Store the total number of questions
        DisplayRandomQuestion(); // Display the first question
        totalScore = new Points(); // Initialize the score object
        questionsAnswered = 0; // Initialize the answered question counter
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
        if (questionsAnswered >= totalQuestions) // Check if all questions have been answered
        {
            ShowResults(); // Show the results
            return;
        }

        currentQuestion = questionList.questions[Random.Range(0, questionList.questions.Length)];
        questionsAnswered++; // Increment the count of questions answered

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
        // Get the points for the selected answer
        Points pointsAwarded = currentQuestion.answers[answerIndex].points; // points is of type Points

        // Debug to check if points are being recorded
        Debug.Log($"Points Awarded: CS, Eng, Math: {pointsAwarded.cs_eng_math}, Life Sci, Kin: {pointsAwarded.life_sci_kin}, " +
                  $"Soc Sci, Humanities, Business: {pointsAwarded.soc_sci_humanities_business}, Arch + Music: {pointsAwarded.arch_music}");

        // Update the total score for each category using direct field access
        totalScore.cs_eng_math += pointsAwarded.cs_eng_math;
        totalScore.life_sci_kin += pointsAwarded.life_sci_kin;
        totalScore.soc_sci_humanities_business += pointsAwarded.soc_sci_humanities_business;
        totalScore.arch_music += pointsAwarded.arch_music;

        // Debug log for points awarded
        Debug.Log($"Total Score: CS, Eng, Math: {totalScore.cs_eng_math}, Life Sci, Kin: {totalScore.life_sci_kin}, " +
                  $"Soc Sci, Humanities, Business: {totalScore.soc_sci_humanities_business}, Arch + Music: {totalScore.arch_music}");

        // Display a new question
        DisplayRandomQuestion();
    }





    private void ShowResults()
    {
        // Determine which category has the most points
        int maxPoints = Mathf.Max(totalScore.cs_eng_math, totalScore.life_sci_kin, totalScore.soc_sci_humanities_business, totalScore.arch_music);

        // Hide all result panels initially
        csEngPanel.SetActive(false); // Update to reflect panel names you create for each category
        LifeSciKinPanel.SetActive(false);
        HumanitiesBusinessPanel.SetActive(false);
        ArtArchPanel.SetActive(false);
        resultsPanel.SetActive(false);

        // Check each category and display the panel with the highest score
        if (totalScore.cs_eng_math == maxPoints)
        {
            csEngPanel.SetActive(true); // Display panel for CS, Eng, Math
            GameManager.score += 150;
        }
        else if (totalScore.life_sci_kin == maxPoints)
        {
            LifeSciKinPanel.SetActive(true); // Display panel for Life Sci, Kin (adjust to appropriate name)
            GameManager.score += 150;
        }
        else if (totalScore.soc_sci_humanities_business == maxPoints)
        {
            HumanitiesBusinessPanel.SetActive(true); // Display panel for Soc Sci, Humanities, Business
            GameManager.score += 150;
        }
        else if (totalScore.arch_music == maxPoints)
        {
            ArtArchPanel.SetActive(true); // Display panel for Arch + Music
            GameManager.score += 150;
        }
    }

}
