/*
 * James Difiglio
 * Challenge2
 * Deletes objects
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float leftLimit = -30;
    private float bottomLimit = -5;

    private HealthSystem HealthSystemScript;

    private void Start()
    {
        HealthSystemScript = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        } 
        // Destroy balls if y position is less than bottomLimit
        else if (transform.position.y < bottomLimit)
        {
            HealthSystemScript.TakeDamage();

            Destroy(gameObject);
        }

    }
}
