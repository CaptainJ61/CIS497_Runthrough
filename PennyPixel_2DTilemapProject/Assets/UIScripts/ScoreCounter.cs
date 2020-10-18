/*
 * James Difiglio
 * Assignment 5
 * Displays gem count, tried to attach to gem prefab but couldnt get it to work
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public GameOver gameEnd;

    // Start is called before the first frame update
    void Start()
    {
        
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        gameEnd = GameObject.FindGameObjectWithTag("Finish").GetComponent<GameOver>();

        scoreText.text = "Gems Collected: 0/10";
    }


    // Update is called once per frame
    void Update()
    {
        
        
            scoreText.text = "Gems Collected out of 10: " + score;
        if (gameEnd.gameOver == true)
        {
            scoreText.text = "Congratulations! You Win!";
        }

    }

    

}
