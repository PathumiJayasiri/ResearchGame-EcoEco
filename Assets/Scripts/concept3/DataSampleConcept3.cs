using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DataSampleConcept3 : MonoBehaviour
{
    public string nameTag;
    public AudioClip soudiobenar;
    public AudioClip soudiosalah;
    public AudioSource Mediaplayerbener;
    public AudioSource Mediaplayersalah;
    public Text textscore;
    public Text timerText;
    public GameObject dialogBox;
    public Text dialogText;
    public AudioClip goodJobSound;
    public AudioClip gameOverSound;
    public AudioSource soundPlayer;
    public GameObject homeButton;
    public GameObject starsImage;

    private static int remainingObjects = 10;
    private int correctObjects = 0;
    private float timeRemaining = 120f;
    private bool gameEnded = false;

    void Start()
    {
        Mediaplayerbener = gameObject.AddComponent<AudioSource>();
        Mediaplayerbener.clip = soudiobenar;
        Mediaplayersalah = gameObject.AddComponent<AudioSource>();
        Mediaplayersalah.clip = soudiosalah;

        soundPlayer = gameObject.AddComponent<AudioSource>();
        dialogBox.SetActive(false);
        starsImage.SetActive(false);

    }

    void Update()
    {
        if (!gameEnded)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                EndGame(false);
            }


            UpdateTimerDisplay();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameEnded) return;

        if (collision.tag.Equals(nameTag))
        {
            Data.score += 10;
            correctObjects++;
            textscore.text = Data.score.ToString();
            Mediaplayerbener.Play();

            dialogText.text = "Good choice: \"Great pick! This is eco-friendly and helps protect nature!\"";
            starsImage.SetActive(true);

        }
        else
        {
            Data.score -= 5;
            textscore.text = Data.score.ToString();
            Mediaplayersalah.Play();

            dialogText.text = "Ohh! It's plastic: \"Plastic harms the environment and creates waste.\"";
            starsImage.SetActive(false);

        }

        Destroy(collision.gameObject);
        StartCoroutine(ShowDialogBoxAfterDelay());

        remainingObjects--;

        if (correctObjects == 5 && !gameEnded)
        {
            EndGame(true);
        }
    }

    IEnumerator ShowDialogBoxAfterDelay()
    {
        yield return new WaitForSeconds(0.3f);
        dialogBox.SetActive(true);
    }

    void EndGame(bool success)
    {
        gameEnded = true;

        if (success)
        {
            dialogText.text = "Good Job! You completed the task!";
            soundPlayer.clip = goodJobSound;
            homeButton.SetActive(true);
        }
        else
        {
            dialogText.text = "Game Over! Time's up!";
            soundPlayer.clip = gameOverSound;
            homeButton.SetActive(true);
        }

        soundPlayer.Play();
        // Keep the dialog box visible until the player presses the button
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void OnOkButtonPressed()
    {
        dialogBox.SetActive(false);
    }
}
