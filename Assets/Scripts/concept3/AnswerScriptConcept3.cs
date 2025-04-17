using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScriptConcept3 : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManagerConcept3 quizManagerConcept3;

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            quizManagerConcept3.correct();
        }
        else
        {
            Debug.Log("Wrong Answer");
            quizManagerConcept3.wrong();
        }
    }
}
