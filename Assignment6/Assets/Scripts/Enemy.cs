using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour, IDamageable
{

    protected float speed;
    protected int health;
    protected Transform targetLocation;
    protected GameObject target;

    protected virtual void Awake()
    {
        
        speed = 2f;
        health = 50;
        target = GameObject.FindGameObjectWithTag("Player");
        targetLocation = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    protected abstract void Attack(int amount);

    public abstract void TakeDamage(int amount);

    protected abstract void MoveTowards3D();

    public void Die()
    {
        Destroy(gameObject);
        GameManager.score += 1;
    }

}
