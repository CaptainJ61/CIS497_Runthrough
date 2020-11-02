using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public int health;

    private void Awake()
    {
        health = 50;
    }

    public int getHealth()
    {
        return health;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
    }

}
