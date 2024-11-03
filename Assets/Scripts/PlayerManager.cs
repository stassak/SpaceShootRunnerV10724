using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    public static int numberOfCoinEnerg;
    public Text coinsEnText;

    public static bool isGameStarted;
    public GameObject startText;

    public TextMeshProUGUI scoreText;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        isGameStarted = false;
        gameOver = false;
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
        numberOfCoinEnerg = 0;

        score = 0;
        // scoreText.text = "Score: " + score; 
        UpdateScore(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;     
            gameOverPanel.SetActive(true);
        }

        coinsEnText.text = "Coins:" + numberOfCoinEnerg;

        if (Input.GetKeyDown(KeyCode.T))
        {
            isGameStarted = true;
            Destroy(startText);
        }
    }

    public void UpdateScore(int scoreAdd)
    {
        score += scoreAdd;
        scoreText.text = "Score: " + score;
    }
}
