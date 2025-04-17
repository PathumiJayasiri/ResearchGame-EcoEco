using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuConcept2 : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("RELevel 1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }


    public void PlayGame2()
    {
        SceneManager.LoadSceneAsync("RELevel 2");
    }
    public void PlayGame3()
    {
        SceneManager.LoadSceneAsync("RELevel 3");
    }
}
