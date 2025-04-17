using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DataSampleLevel3 : MonoBehaviour
{
    public string nameTag;
    public AudioClip soudiobenar;
    public AudioClip soudiosalah;
    public AudioSource Mediaplayerbener;
    public AudioSource Mediaplayersalah;
    public Text textscore;
    public GameObject goodJobImage;
    public AudioClip goodJobSound;
    public AudioSource soundPlayer;

    public Text messageText;
    public GameObject messagePanel;
    private static int remainingObjects = 10;

    void Start()
    {
        Mediaplayerbener = gameObject.AddComponent<AudioSource>();
        Mediaplayerbener.clip = soudiobenar;
        Mediaplayersalah = gameObject.AddComponent<AudioSource>();
        Mediaplayersalah.clip = soudiosalah;

        soundPlayer = gameObject.AddComponent<AudioSource>(); // Add AudioSource for "Good Job"
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
            Destroy(collision.gameObject);
            Mediaplayerbener.Play();

            // Set feedback message for correct bin
            messageText.text = "Correct Bin: Good job!";
        }
        else
        {
            Data.score -= 5;
            textscore.text = Data.score.ToString();
            Destroy(collision.gameObject);
            Mediaplayersalah.Play();

            // Set feedback message for wrong bin
            messageText.text = "Wrong Bin!";
        }

        remainingObjects--; // Decrease the count of remaining objects
        StartCoroutine(HandleMessageAndGoodJob()); // Handle feedback and transitions
    }

    IEnumerator HandleMessageAndGoodJob()
    {
        // Show the message panel
        messagePanel.SetActive(true);

        // Wait for 0.5 seconds before hiding the message panel
        yield return new WaitForSeconds(0.8f);
        messagePanel.SetActive(false);

        // If all objects are processed, show the "Good Job" image
        if (remainingObjects <= 0)
        {
            yield return new WaitForSeconds(0.5f); // Small delay for transition
            goodJobImage.SetActive(true); // Display the "Good Job" image
            soundPlayer.Play(); // Play the "Good Job" sound
        }
    }
}
