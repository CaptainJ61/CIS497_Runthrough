using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;
    private float minSpeed = 12f;
    private float maxSpeed = 16f;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -3;

    private GameManager gameManager;

    public int pointValue;

    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();

        //add force upwards
        targetRB.AddForce(RandomForce(), ForceMode.Impulse);

        //add torque with randomized xyz values
        targetRB.AddTorque(RandomTorque(), RandomTorque(),
            RandomTorque(), ForceMode.Impulse);

        //set position with a randomized x value
        transform.position = RandomSpawnPos();

        //set reference to gm
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            gameManager.UpdateScore(pointValue);

            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("Bad"));
        {
            gameManager.GameOver();
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
