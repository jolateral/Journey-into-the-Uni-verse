using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [SerializeField] public List<QuestionAnswer> QnA;
    [SerializeField] public Button[] options;
    [SerializeField] public int currentQuestion = 0;
    [SerializeField] public Question[] questions;
    [SerializeField] public Text QuestionTxt;

    //Score Variables
    private int scoreA = 0;
    private int scoreB = 0;
    private int scoreC = 0;
    private int scoreD = 0;

    private void Start()
    {
        DisplayQuestion();

    }

    private void DisplayQuestion()
    {
        if(currentQuestion < questions.Length)
        {
            Question question = questions[currentQuestion];
            questionText.text = question.questionText;

            //Set each option button's text
            for(int i = 0; i < options.Length; i++)
            {
                options[i].GetComponentInChildren<Text>().text = question.options[i];
                int optionIndex = i;
                options[i].onClick.RemoveAllListeners();
                options[i].onClick.AddListener(() => SelectOption(optionIndex));            }
        }
    }
    else
    {
        Debug.Log("Quiz finished!");
        DisplayScores();

    }

    private void SelectOption(int selectedOption)
    {
        Question question = questions[currentQuestion];

        switch(selectedOption)
        {
            case 0:
                scoreA++;
                break;
            case 1:
                scoreB++
                break;
            case 2:
                scoreC++
                break;
            case 3:
                scoreD++;
                break;
        }

        currentQuestion++;
        DisplayQuestion();
    }


    public void DisplayScores()
        {
            Debug.Log("Quiz Scores:");
            Debug.Log("Score A: " + scoreA);
            Debug.Log("Score B: " + scoreB);
            Debug.Log("Score C: " + scoreC);
            Debug.Log("Score D: " + scoreD);
        }
 
    
}
