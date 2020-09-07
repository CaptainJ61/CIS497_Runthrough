using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool won;
    public static int score;

    public Text textBox;

    private void Start()
    {
        won = false;
        gameOver = false;
        score = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            textBox.text = "Score: " + score;
        }
        if (score >= 5)
        {
            won = true;
            gameOver = true;
        }
        if (gameOver)
        {
            if (won)
            {
                textBox.text = "You Win!\nPress R to try again";
            }
            else
            {
                textBox.text = "You Lose!\nPress R to try again";
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }
}