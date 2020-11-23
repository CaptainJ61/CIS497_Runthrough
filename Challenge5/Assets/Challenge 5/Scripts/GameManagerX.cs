/*
 * James Difiglio
 * Challenge5
 * Controls everything else
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerX : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI youWinText;//added this
    public TextMeshProUGUI timerText;//added this
    public GameObject titleScreen;
    public Button restartButton; 

    public List<GameObject> targetPrefabs;

    private int score;
    private float spawnRate = 3.5f;//increased spawn time
    public float timeLeft = 60.0f;//initial countdown

    public bool isGameActive;

    private float spaceBetweenSquares = 2.5f; 
    private float minValueX = -3.75f; //  x value of the center of the left-most square
    private float minValueY = -3.75f; //  y value of the center of the bottom-most square
    
    // Start the game, remove title screen, reset score, and adjust spawnRate based on difficulty button clicked
    //added a parameter to check difficulty
    public void StartGame(int difficulty)
    {
        spawnRate /= 5;
        isGameActive = true;
        StartCoroutine(SpawnTarget(difficulty));
        score = 0;
        UpdateScore(0);
        titleScreen.SetActive(false);
    }

    //added this to run the timer
    void Update()
    {
        if (isGameActive == true)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = "Time: " + (timeLeft).ToString("0");
            if (timeLeft < 0)
            {
                GameOverWin();
            }
        }
    }

    // While game is active spawn a random target
    //added a parameter to check difficulty
    IEnumerator SpawnTarget(int difficulty)
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate - difficulty); //subtracting spawnrate with difficulty
            int index = Random.Range(0, targetPrefabs.Count);

            if (isGameActive)
            {
                Instantiate(targetPrefabs[index], RandomSpawnPosition(), targetPrefabs[index].transform.rotation);
            }
            
        }
    }

    // Generate a random spawn position based on a random index from 0 to 3
    Vector3 RandomSpawnPosition()
    {
        float spawnPosX = minValueX + (RandomSquareIndex() * spaceBetweenSquares);
        float spawnPosY = minValueY + (RandomSquareIndex() * spaceBetweenSquares);

        Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, 0);
        return spawnPosition;

    }

    // Generates random square index from 0 to 3, which determines which square the target will appear in
    int RandomSquareIndex()
    {
        return Random.Range(0, 4);
    }

    // Update score with value from target clicked
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    // Stop game, bring up game over text and restart button
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    //same as GameOver() method but activates when the timer runs out
    public void GameOverWin()
    {
        youWinText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    // Restart game by reloading the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
