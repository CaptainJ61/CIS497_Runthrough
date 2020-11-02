using UnityEngine;
using System.Collections;

public class Golem : Enemy
{
    protected int damage;

   

    // Use this for initialization
    protected override void Awake()
    {
        base.Awake();
        health = 50;
        
    }

    protected override void Attack(int amount)
    {
        GameManager.health -= amount;

    }


    public override void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Attack(damage);
        }
    }

    void Update()
    {
        MoveTowards3D();
    }

    protected override void MoveTowards3D()
    {
        transform.LookAt(targetLocation);
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
