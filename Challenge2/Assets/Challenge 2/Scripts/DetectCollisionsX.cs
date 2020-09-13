/*
 * James Difiglio
 * Challenge2
 * Reads object collisions
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    private DisplayScore displayScoreScript;

    private void Start()
    {
        displayScoreScript = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<DisplayScore>();
    }

    private void OnTriggerEnter(Collider other)
    {
        displayScoreScript.score++;
        Destroy(gameObject);
    }
}
