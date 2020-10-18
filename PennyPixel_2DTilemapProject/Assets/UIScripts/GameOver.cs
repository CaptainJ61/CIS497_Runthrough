/*
 * James Difiglio
 * Assignment 5
 * simple true or false script
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public bool gameOver = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameOver = true;
        }
    }
}
