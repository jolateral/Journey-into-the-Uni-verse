[System.Serializable]
public class QuestionList
{
    public ProgramQuestion[] questions; // Array of questions
}

[System.Serializable]
public class ProgramQuestion
{
    public string questionsText; // The text of the question
    public Answer[] answers; // Array of answers
}

[System.Serializable]
public class Answer
{
    public string answerText; // The text of the answer
    public Points points; // Points categorized by area
}

[System.Serializable]
public class Points
{
    public int cs_eng_math; // Ensure this matches your JSON key
    public int life_sci_kin; // Ensure this matches your JSON key
    public int soc_sci_humanities_business; // Ensure this matches your JSON key
    public int arch_music; // Ensure this matches your JSON key
}


