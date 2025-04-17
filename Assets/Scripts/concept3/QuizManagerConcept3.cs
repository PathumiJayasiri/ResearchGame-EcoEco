using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManagerConcept3 : MonoBehaviour
{
    public List<QuestionAndAnswerConcept3> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public Text textscore;
    public GameObject closeButton;
    public GameObject okButton;
    public Text QuestionTxt;
    public GameObject dialogBox;
    public Text dialogText;
    public Image correctImage;

    public AudioClip goodJobSound;
    public AudioSource soundPlayer;

    private bool isAnswered = false;

    private void Start()
    {
        dialogBox.SetActive(false);
        closeButton.SetActive(false);
        okButton.SetActive(false);
        soundPlayer = gameObject.AddComponent<AudioSource>();
        soundPlayer.clip = goodJobSound;
        generateQuestion();
    }

    public void correct()
    {
        if (isAnswered) return;
        isAnswered = true;

        dialogText.text = "Good choice: \"Great pick! This is eco-friendly and helps protect nature!\"";
        correctImage.gameObject.SetActive(true);
        soundPlayer.Play();
        Data.score += 10;
        textscore.text = Data.score.ToString();
        ShowDialogBox();
    }

    public void wrong()
    {
        if (isAnswered) return;
        isAnswered = true;

        dialogText.text = "Ohh! It's plastic: \"Plastic harms the environment and creates waste.\"";
        correctImage.gameObject.SetActive(false);
        ShowDialogBox();
    }

    void ShowDialogBox()
    {
        dialogBox.SetActive(true);
        okButton.SetActive(true);

        if (currentQuestion == QnA.Count - 1)
        {
            closeButton.SetActive(true);
        }
        else
        {
            closeButton.SetActive(false);
        }
    }

    public void OnOkButtonPressed()
    {
        dialogBox.SetActive(false);
        okButton.SetActive(false);

        if (currentQuestion < QnA.Count - 1)
        {
            NextQuestion();
        }
        else
        {
            Debug.Log("Quiz Completed!");
        }
    }

    void SetAnswer()
    {
        isAnswered = false;

        for (int i = 0; i < options.Length; i++)
        {
            var button = options[i];
            var answerScript = button.GetComponent<AnswerScriptConcept3>();

            answerScript.isCorrect = false;
            var textComponent = button.transform.GetChild(0).GetComponent<Text>();
            textComponent.text = QnA[currentQuestion].Answers[i];

            var imageComponent = button.GetComponent<Image>();
            if (QnA[currentQuestion].AnswerImages != null && i < QnA[currentQuestion].AnswerImages.Length)
            {
                imageComponent.sprite = QnA[currentQuestion].AnswerImages[i];
                imageComponent.enabled = true;
            }
            else
            {
                imageComponent.enabled = false;
            }

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                answerScript.isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        QuestionTxt.text = QnA[currentQuestion].Question;
        SetAnswer();
    }

    void NextQuestion()
    {
        currentQuestion++;
        if (currentQuestion < QnA.Count)
        {
            generateQuestion();
        }
        else
        {
            Debug.Log("Quiz Completed!");
        }
    }
}
