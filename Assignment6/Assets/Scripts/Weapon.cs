using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public int damage = 10;
    public float range = 100f;
    public Camera can;


    public float hitForce = 10f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {

        RaycastHit hitInfo;
        if (Physics.Raycast(can.transform.position, can.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.gameObject.name);

            Golem target = hitInfo.transform.gameObject.GetComponent<Golem>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hitInfo.rigidbody != null)
            {
                hitInfo.rigidbody.AddForce(can.transform.TransformDirection(Vector3.forward) * hitForce, ForceMode.Impulse);
            }
        }
    }
    
}
