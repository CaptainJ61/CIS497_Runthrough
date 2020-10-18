/*
 * James Difiglio
 * Assignment 5
 * Same code but added some stuff for ScoreCounter
 * 
 */
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBehaviour : MonoBehaviour
{
	[Header("References")]
	public GameObject gemVisuals;
	public GameObject collectedParticleSystem;
	public CircleCollider2D gemCollider2D;

	private float durationOfCollectedParticleSystem;

    //added this
    public ScoreCounter scoreCount;

	void Start()
	{
		durationOfCollectedParticleSystem = collectedParticleSystem.GetComponent<ParticleSystem>().main.duration;

        //this
        scoreCount = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreCounter>();
    }

	void OnTriggerEnter2D(Collider2D theCollider)
	{
		if (theCollider.CompareTag ("Player")) {
			GemCollected ();
		}
	}

	void GemCollected()
	{
        //and this
        scoreCount.score++;

		gemCollider2D.enabled = false;
		gemVisuals.SetActive (false);
		collectedParticleSystem.SetActive (true);
		Invoke ("DeactivateGemGameObject", durationOfCollectedParticleSystem);
	}

	void DeactivateGemGameObject()
	{
		gameObject.SetActive (false);
	}
}
