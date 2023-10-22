using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(3);
    }

    public void playTutorial()
    {
        SceneManager.LoadScene(1);
    }

    public void keyBinds()
    {
        SceneManager.LoadScene(4);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
