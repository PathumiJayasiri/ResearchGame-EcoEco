using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuConcept3 : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("ZWLevel 1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }


    public void PlayGame2()
    {
        SceneManager.LoadSceneAsync("ZWLevel 2");
    }
    public void PlayGame3()
    {
        SceneManager.LoadSceneAsync("ZWLevel 3");
    }
}
