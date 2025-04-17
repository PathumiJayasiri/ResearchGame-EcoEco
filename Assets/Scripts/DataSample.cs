using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DataSample : MonoBehaviour
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
    private static int remainingObjects = 4;

    void Start()
    {
        Mediaplayerbener = gameObject.AddComponent<AudioSource>();
        Mediaplayerbener.clip = soudiobenar;
        Mediaplayersalah = gameObject.AddComponent<AudioSource>();
        Mediaplayersalah.clip = soudiosalah;

        soundPlayer = gameObject.AddComponent<AudioSource>();
        soundPlayer.clip = goodJobSound;

        goodJobImage.SetActive(false);
        messagePanel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(nameTag))
        {
            Data.score += 10;
            textscore.text = Data.score.ToString();
            Mediaplayerbener.Play();

            messageText.text = "Correct Bin: Good job!";
        }
        else
        {
            Data.score -= 5;
            textscore.text = Data.score.ToString();
            Mediaplayersalah.Play();


            messageText.text = "Wrong Bin!";
        }

        Destroy(collision.gameObject);
        remainingObjects--;


        StartCoroutine(HandleMessageAndGoodJob());


        if (remainingObjects <= 0)
        {

        }
    }

    IEnumerator HandleMessageAndGoodJob()
    {

        messagePanel.SetActive(true);

        // Wait for 0.2 seconds before hiding the message panel
        yield return new WaitForSeconds(0.8f);
        messagePanel.SetActive(false);

        if (remainingObjects <= 0)
        {
            yield return new WaitForSeconds(0.5f);
            goodJobImage.SetActive(true);
            soundPlayer.Play();
        }
    }
}
