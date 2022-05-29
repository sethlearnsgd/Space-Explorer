using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;


    private SpaceExplorer spaceExplorer;

    private void Awake()
    {
        spaceExplorer = new SpaceExplorer();

        spaceExplorer.Enable();

        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        PauseGame();
    }

    public void PauseGame()
    {
        bool isPauseKeyPressed = spaceExplorer.Player.Pause.ReadValue<float>() > 0.1f;

        if (isPauseKeyPressed)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }        

    }

    public void ContinueButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitButton()
    {
        Debug.Log("Application quitting");
        Application.Quit();
    }

    public void RestartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
