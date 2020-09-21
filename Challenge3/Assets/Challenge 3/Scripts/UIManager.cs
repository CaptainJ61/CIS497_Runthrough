/*
 * James Difiglio
 * Challenge3
 * Displays win/lose/score text
 * 
 */
 // Copy and pasted entire file from prototype3, Added exactly 2 X's
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    public PlayerControllerX playerControllerScript;

    public bool won = false;
    // Start is called before the first frame update
    void Start()
    {
        if (scoreText == null)
        {
            scoreText = FindObjectOfType<Text>();
        }
        if (playerControllerScript == null)
        {
            playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerX>();
        }

        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            scoreText.text = "Score: " + score;
        }

        if (playerControllerScript.gameOver && !won)
        {
            scoreText.text = "You Lose!\nPress R to Try Again! ";
        }

        if (score >= 30)
        {
            playerControllerScript.gameOver = true;
            won = true;

            //Stop player form running

            scoreText.text = "You Win!\nPress R to Try Again";
        }

        if (playerControllerScript.gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
