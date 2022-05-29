using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private AsteroidSpawner asteroidSpawner;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private Button quitButton;

    
    private void Start()
    {
        gameOverDisplay.SetActive(false);
    }

    public void EndGame()
    {
        asteroidSpawner.enabled = false;
        gameOverDisplay.SetActive(true);

        int finalScore = scoreSystem.StopCounting();

        gameOverText.text = $"Your Score: {finalScore}";
    }

    public void PlayAgainButton()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Debug.Log("Application quitting");
        Application.Quit();
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
