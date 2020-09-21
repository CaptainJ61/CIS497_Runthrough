/*
 * James Difiglio
 * Prototype3
 * Counts score for UIManager
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneAddScore : MonoBehaviour
{
    private UIManager UIManager;

    private bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        UIManager = GameObject.FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            UIManager.score++;
        }
    }
}
