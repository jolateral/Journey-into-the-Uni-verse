[System.Serializable]
public class QuestionList
{
    public ProgramQuestion[] questions; // Array of questions
}

[System.Serializable]
public class ProgramQuestion
{
    public string questionsText; // The text of the question
    public ProgramAnswer[] answers; // Array of answers
}

[System.Serializable]
public class ProgramAnswer
{
    public string answerText; // The text of the answer
}
