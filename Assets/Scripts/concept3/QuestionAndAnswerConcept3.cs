using UnityEngine; // Ensure this is included

[System.Serializable]
public class QuestionAndAnswerConcept3
{
    public string Question;
    public string[] Answers; // Text options for answers
    public Sprite[] AnswerImages; // Images for each answer
    public int CorrectAnswer; // Index of the correct answer (1-based)
}
