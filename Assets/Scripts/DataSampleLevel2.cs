using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DataSampleLevel2 : MonoBehaviour
{
    public string nameTag;
    public AudioClip soudiobenar;
    public AudioClip soudiosalah;
    public AudioSource Mediaplayerbener;
    public AudioSource Mediaplayersalah;
    public Text textscore;
    public GameObject messagePanel;
    public Text messageText;
    public GameObject goodJobImage;
    public AudioClip goodJobSound;
    public AudioSource soundPlayer;
    private static int remainingObjects = 7;

    void Start()
    {
        Mediaplayerbener = gameObject.AddComponent<AudioSource>();
        Mediaplayerbener.clip = soudiobenar;
        Mediaplayersalah = gameObject.AddComponent<AudioSource>();
        Mediaplayersalah.clip = soudiosalah;

        soundPlayer = gameObject.AddComponent<AudioSource>();
        soundPlayer.clip = goodJobSound;

        goodJobImage.SetActive(false); // Initially hide the "Good Job" image
        messagePanel.SetActive(false); // Initially hide the message panel
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(nameTag))
        {
            Data.score += 10;
            textscore.text = Data.score.ToString();

            // Display feedback message for correct bin
            messageText.text = "Correct Bin: Good job!";
            Mediaplayerbener.Play();
        }
        else
        {
            Data.score -= 5;
            textscore.text = Data.score.ToString();

            // Display feedback message for wrong bin
            messageText.text = "Wrong Bin!";
            Mediaplayersalah.Play();
        }

        Destroy(collision.gameObject); // Remove the dropped object
        remainingObjects--;

        // Show the message panel and handle subsequent actions
        StartCoroutine(HandleMessageAndGoodJob());
    }

    IEnumerator HandleMessageAndGoodJob()
    {
        // Show the message panel
        messagePanel.SetActive(true);

        // Wait for 0.2 seconds
        yield return new WaitForSeconds(0.8f);

        // Hide the message panel
        messagePanel.SetActive(false);

        // If all objects are processed, show the "Good Job" image
        if (remainingObjects <= 0)
        {
            yield return new WaitForSeconds(0.5f); // Small delay before "Good Job" image
            goodJobImage.SetActive(true);
            soundPlayer.Play();
        }
    }
}
