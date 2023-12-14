using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject enemyPrefab;
    public List<Transform> enemySpawnPosition;

    private int score;
    public bool isGamePaused = false;
    private float gameTime;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        isGamePaused = false;
        UpdateScore(0);

        InvokeRepeating("SpawnEnemy", 2, 2);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();

        if(Input.GetKeyDown(KeyCode.Q))
        {
            PauseGame();
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        if (!isGamePaused)
        {
            score += scoreToAdd;
            scoreText.text = score.ToString();
        }
       
    }

    private void UpdateTime()
    {
        if (!isGamePaused)
        {
            gameTime += Time.deltaTime;

            float min = Mathf.FloorToInt(gameTime / 60);
            float sec = Mathf.FloorToInt(gameTime % 60);
            timerText.text = min + ":" + sec;
        }
    }

    public void PauseGame()
    {
        if(!isGamePaused)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            isGamePaused = true;
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        isGamePaused = false;
    }

    public void GameOver()
    {
        print("GameOver");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    private void SpawnEnemy()
    {
        if (!isGamePaused)
        {
            Instantiate(enemyPrefab, enemySpawnPosition[Random.Range(0, enemySpawnPosition.Count)].position, enemyPrefab.transform.rotation);
        }
    }
}
