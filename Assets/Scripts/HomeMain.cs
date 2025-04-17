using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeMain : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }

    public void HomeMenu()
    {
        SceneManager.LoadScene("HomeMenu");
    }
}
