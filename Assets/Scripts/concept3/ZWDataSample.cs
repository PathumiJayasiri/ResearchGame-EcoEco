using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZWDataSample : MonoBehaviour
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
            }
            Destroy(collision.gameObject);
        }
        else
        {
            Data.score -= 5;
            textscore.text = Data.score.ToString();
            Destroy(collision.gameObject);
            Mediaplayersalah.Play();
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
}
