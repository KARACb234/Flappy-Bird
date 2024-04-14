using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;
    public GameObject startGamePanel;
    public SpawnManager spawnManager;
    public PlayerController playerController;
    public GameObject gameOverPanel;
    public TextMeshProUGUI bestScoreText;

    public void Start()
    {
        UpdateScoreText();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void AddScore()
    {
        score ++;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
    
    public void StartGame()
    {

        playerController.isIdle = false;
        spawnManager.StartGame();
        startGamePanel.SetActive(false);
    }

    public void GameOver()
    { 
        gameOverPanel.SetActive(true);
        SaveBestScore();
        UpdateBestScoretext();
    }

    private void UpdateBestScoretext()
    {
        int bestscore = PlayerPrefs.GetInt("BEST_SCORE");
        bestScoreText.text = $"Score: {score}\nBest score:{bestscore}";
    }


    private void SaveBestScore()
    {
        int bestScore = PlayerPrefs.GetInt("BEST_SCORE");
        if(bestScore < score)
        {
            PlayerPrefs.SetInt("BEST_SCORE", score);
            PlayerPrefs.Save();
        }
    }
}
