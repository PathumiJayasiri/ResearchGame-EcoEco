using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public Text QuestionTxt;
    public GameObject dialogBox;
    public Text dialogText;
    public Image correctImage;
    public Text textscore;

    public Image homeImage;
    public AudioClip goodJobSound;
    public AudioClip wrongAnswerSound;

    public AudioSource soundPlayer;
    public AudioSource soundPlayer2;

    private void Start()
    {
        dialogBox.SetActive(false);
        Debug.Log("Initial number of questions: " + QnA.Count);
        generateQuestion();
        soundPlayer = gameObject.AddComponent<AudioSource>();
        soundPlayer2 = gameObject.AddComponent<AudioSource>();

        soundPlayer.clip = goodJobSound;
        soundPlayer2.clip = wrongAnswerSound;

    }

    public void correct()
    {
        dialogText.text = "Correct Answer!LCD bulbs are eco-friendly because they use less energy and last longer, reducing waste and pollution.";
        correctImage.gameObject.SetActive(true);
        homeImage.gameObject.SetActive(true);
        Data.score += 10;
        textscore.text = Data.score.ToString();
        soundPlayer.Play();
        ShowDialogBox();
    }


    public void wrong()
    {
        dialogText.text = "Wrong Answer! This type of bulbs are not eco-friendly because they waste energy and have a short lifespan.";
        correctImage.gameObject.SetActive(false);
        soundPlayer2.Play();

        ShowDialogBox();
    }

    void ShowDialogBox()
    {
        dialogBox.SetActive(true);
    }

    public void OnOkButtonPressed()
    {
        dialogBox.SetActive(false);
    }


    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        currentQuestion = 0; // Always use the single question
        QuestionTxt.text = QnA[currentQuestion].Question;
        SetAnswer();
    }
}
