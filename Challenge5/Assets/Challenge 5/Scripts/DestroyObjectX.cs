/*
 * James Difiglio
 * Challenge5
 * Timer for deleting objects
 * didnt actually edit this script
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectX : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2); // destroy particle after 2 seconds
    }


}
