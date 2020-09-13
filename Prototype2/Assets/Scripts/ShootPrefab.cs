/*
 * James Difiglio
 * Prototype2
 * Shoots bananas out from player
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPrefab : MonoBehaviour
{
    public GameObject prefabeToShoot;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefabeToShoot, transform.position, prefabeToShoot.transform.rotation);
        }
        
    }
}
