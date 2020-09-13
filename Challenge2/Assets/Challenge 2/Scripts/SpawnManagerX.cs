/*
 * James Difiglio
 * Challenge2
 * Controls spawn behavior of balls
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 5.0f;

    public HealthSystem HealthSystem;
    public DisplayScore DisplayScore;

    // Start is called before the first frame update
    void Start()
    {
        HealthSystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();
        DisplayScore = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<DisplayScore>();

        //InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);

        StartCoroutine(SpawnRandomPrefabWithCoroutine());

    }

    IEnumerator SpawnRandomPrefabWithCoroutine()
    {
        yield return new WaitForSeconds(startDelay);

        while (HealthSystem.gameOver == false && DisplayScore.gameOver == false)
        {
            SpawnRandomBall();

            float randomDelay = Random.Range(spawnInterval - 2, spawnInterval);

            yield return new WaitForSeconds(1.5f);
        }
    }

        // Spawn random ball at random x position at top of play area
        void SpawnRandomBall ()
    {
        int prefabIndex = Random.Range(0, ballPrefabs.Length);

        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[prefabIndex], spawnPos, ballPrefabs[prefabIndex].transform.rotation);
    }

}
