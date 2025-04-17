using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class REDataSampleLevel3 : MonoBehaviour
{
    public string nameTag;
    public AudioClip soudiobenar;
    public AudioSource Mediaplayerbener;
    public Text textscore;
    public Text timerText;
    public GameObject goodJobImage;
    public GameObject gameOverImage;
    public GameObject litLamp;
    public AudioClip goodJobSound;
    public AudioSource soundPlayer;
    public GameObject question;

    public GameObject dialogBox;
    public Text dialogText;
    public GameObject starsContainer;
    public Button okButton;

    private static int remainingObjects = 3;
    private static int litLampCount = 0;
    private bool lampActivated = false;
    private float timeRemaining = 120f;
    private bool isGameOver = false;

    void Start()
    {
        Mediaplayerbener = gameObject.AddComponent<AudioSource>();
        Mediaplayerbener.clip = soudiobenar;

        soundPlayer = gameObject.AddComponent<AudioSource>();
        soundPlayer.clip = goodJobSound;

        goodJobImage.SetActive(false);
        gameOverImage.SetActive(false);
        litLamp.SetActive(false);

        dialogBox.SetActive(false);
        starsContainer.SetActive(false);

        okButton.onClick.AddListener(OnOkButtonPressed);

        StartCoroutine(UpdateTimer());
    }

    void Update()
    {

        if (!isGameOver)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                EndGame(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(nameTag))
        {
            if (!lampActivated)
            {
                Data.score += 10;
                textscore.text = Data.score.ToString();
                ReplaceWithLitLamp();
                lampActivated = true;
                litLampCount++;
                Mediaplayerbener.Play();
                ShowCorrectDialog();
            }
            Destroy(collision.gameObject);
        }
        else
        {
            Destroy(collision.gameObject);
            ShowWrongDialog();
        }

        remainingObjects--;


        if (litLampCount == 3 && !isGameOver)
        {
            EndGame(true);
        }
    }

    void ReplaceWithLitLamp()
    {
        if (!litLamp.activeSelf)
        {
            litLamp.SetActive(true);
        }
    }

    IEnumerator UpdateTimer()
    {
        while (timeRemaining > 0 && !isGameOver)
        {
            // Update the timer text in minutes and seconds format
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = $"{minutes:D2}:{seconds:D2}";
            yield return new WaitForSeconds(1f);
        }
    }

    void EndGame(bool success)
    {
        isGameOver = true;

        if (success)
        {
            StartCoroutine(ShowGoodJobImageDelayed());
            question.SetActive(false);
        }
        else
        {
            gameOverImage.SetActive(true);
            question.SetActive(false);
        }
    }

    IEnumerator ShowGoodJobImageDelayed()
    {
        yield return new WaitForSeconds(2);
        goodJobImage.SetActive(true);
        soundPlayer.Play();
    }

    void ShowCorrectDialog()
    {
        StartCoroutine(ShowDialogWithDelay("Good Job", true));
    }

    void ShowWrongDialog()
    {
        StartCoroutine(ShowDialogWithDelay("Wrong! ", false));
    }

    IEnumerator ShowDialogWithDelay(string message, bool isCorrect)
    {
        yield return new WaitForSeconds(0.5f);
        dialogText.text = message;
        starsContainer.SetActive(isCorrect);
        dialogBox.SetActive(true);
    }

    public void OnOkButtonPressed()
    {
        dialogBox.SetActive(false);
    }
}
