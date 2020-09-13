/*
 * James Difiglio
 * Prototype2
 * Delete objects going out of bounds
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOutOfBounds : MonoBehaviour
{
    public float topBound = 20;
    public float bottomBound = -10;

    private HealthSystem HealthSystemScript;

    private void Start()
    {
        HealthSystemScript = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < bottomBound)
        {
            HealthSystemScript.TakeDamage();
            

            Destroy(gameObject);
        }
    }
}
