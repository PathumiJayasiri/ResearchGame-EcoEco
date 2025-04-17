using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Level 1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }


    public void PlayGame2()
    {
        SceneManager.LoadSceneAsync("Level 2");
    }
    public void PlayGame3()
    {
        SceneManager.LoadSceneAsync("Level 3");
    }
}
