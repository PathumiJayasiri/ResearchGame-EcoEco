using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HomeMenu : MonoBehaviour
{

    public void PlayGame1()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }


    public void PlayGame2()
    {
        SceneManager.LoadSceneAsync("MainMenuConcept 2");
    }
    public void PlayGame3()
    {
        SceneManager.LoadSceneAsync("MainMenuConcept 3");
    }
}
