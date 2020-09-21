/*
 * James Difiglio
 * Challenge3
 * Controls player motion
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver = false;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip boingSound;

    public bool isLowEnough = false;        //<----Added this

    private UIManager uIManager;            //<----Added this

    // Start is called before the first frame update
    void Start()
    {
        uIManager = GameObject.FindObjectOfType<UIManager>();   //<----Added this

        playerRb = GetComponent<Rigidbody>();                   //<----Added this

        if (Physics.gravity.y > -10)    //Added if statement around statement
        {
            Physics.gravity *= gravityModifier;
        }

        playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        if (playerRb.position.y >= 14.4)        //Added height bounds
        {
            isLowEnough = true;
        }

        else if (playerRb.position.y < 14.4)    //Added height bounds
        {
            isLowEnough = false;
        }

        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver && !isLowEnough)
        {                                           //Added !isLowEnough
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
            uIManager.score++;  //increment score

        }

        // if player collides with ground
        else if (other.gameObject.CompareTag("Ground") && !gameOver)    //Added ground collision
        {
            playerAudio.PlayOneShot(boingSound, 2.0f);
            playerRb.AddForce(Vector3.up * 30, ForceMode.Impulse);
        }

    }

}
