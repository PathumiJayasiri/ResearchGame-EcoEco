using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeConcept2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GoToMainMenu() // Changed the method name
    {
        SceneManager.LoadScene("MainMenuConcept 2");
    }
}
