using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject pauseMenuScreen;
    public bool isPaused;

    private void Start()
    {
        pauseMenuScreen.SetActive(false);

    }

    public void PauseGame()
    {
        pauseMenuScreen.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                resumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }


    public void resumeGame()
    {
        pauseMenuScreen.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void backToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }


    public void quitGame()
    {
        Application.Quit();
    }
}
