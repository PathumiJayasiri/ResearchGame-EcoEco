using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class REDataSample : MonoBehaviour
{
    public string nameTag;
    public AudioClip soudiobenar;
    public AudioClip soudiosalah;
    public AudioSource Mediaplayerbener;
    public AudioSource Mediaplayersalah;
    public Text textscore;
    public GameObject goodJobImage;
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

    void Start()
    {
        Mediaplayerbener = gameObject.AddComponent<AudioSource>();
        Mediaplayerbener.clip = soudiobenar;
        Mediaplayersalah = gameObject.AddComponent<AudioSource>();
        Mediaplayersalah.clip = soudiosalah;

        soundPlayer = gameObject.AddComponent<AudioSource>();
        soundPlayer.clip = goodJobSound;

        goodJobImage.SetActive(false);
        litLamp.SetActive(false);
        dialogBox.SetActive(false);
        starsContainer.SetActive(false);

        okButton.onClick.AddListener(OnOkButtonPressed);
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

                StartCoroutine(ShowCorrectDialogWithDelay());
            }
            Destroy(collision.gameObject);
        }
        else
        {
            Data.score -= 5;
            textscore.text = Data.score.ToString();
            Destroy(collision.gameObject);
            Mediaplayersalah.Play();

            StartCoroutine(ShowWrongDialogWithDelay());
        }

        remainingObjects--;


        if (litLampCount == 3)
        {
            StartCoroutine(ShowGoodJobImageDelayed());
            question.SetActive(false);
        }
    }

    void ReplaceWithLitLamp()
    {
        if (!litLamp.activeSelf)
        {
            litLamp.SetActive(true);
        }
    }

    IEnumerator ShowGoodJobImageDelayed()
    {
        yield return new WaitForSeconds(2);
        goodJobImage.SetActive(true);
        soundPlayer.Play();
    }

    IEnumerator ShowCorrectDialogWithDelay()
    {
        yield return new WaitForSeconds(0.5f);
        dialogText.text = "Correct! LCD bulbs are eco-friendly because they use less energy and last longer, reducing waste and pollution.";
        starsContainer.SetActive(true);
        dialogBox.SetActive(true);
    }

    IEnumerator ShowWrongDialogWithDelay()
    {
        yield return new WaitForSeconds(0.5f);
        dialogText.text = "Wrong! This bulb type is not eco-friendly because they waste energy and have a short lifespan.";
        starsContainer.SetActive(false);
        dialogBox.SetActive(true);
    }

    public void OnOkButtonPressed()
    {
        dialogBox.SetActive(false);
    }
}
