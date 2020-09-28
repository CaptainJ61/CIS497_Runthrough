/*
 * James Difiglio
 * Prototype3
 * Controls audio, animation, and jumping
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce;
    public ForceMode forceMode;
    public float gravityModifier;

    public bool isOnGround = true;
    public bool gameOver = false;

    public Animator playerAnimator;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirt;

    public AudioClip crash;
    public AudioClip jump;
    private AudioSource player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        playerAnimator = GetComponent<Animator>();

        playerAnimator.SetFloat("Speed_f", 1.0f);

        player = GetComponent<AudioSource>();

        forceMode = ForceMode.Impulse;

        if (Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, forceMode);
            isOnGround = false;

            playerAnimator.SetTrigger("Jump_trig");

            dirt.Stop();
            player.PlayOneShot(jump, 1.0f);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
            dirt.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log(gameOver);
            gameOver = true;

            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);

            explosionParticle.Play();
            player.PlayOneShot(crash, 1.0f);
        }
    }
}
