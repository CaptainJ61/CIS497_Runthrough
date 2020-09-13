/*
 * James Difiglio
 * Challenge2
 * Controls dog spawning
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private float spawnTimer = 1.0f;
    private bool canSpawn = true;

    public GameObject dogPrefab;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && canSpawn)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

            canSpawn = false;

            Invoke("dogSpawnDelay", spawnTimer);

            
        }
    }

    bool dogSpawnDelay()
    {
        return canSpawn = true;
        
    }
}
