﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWithRayCasts : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera can;

    public ParticleSystem muzzleFlash;

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
        muzzleFlash.Play();

        RaycastHit hitInfo;
        if (Physics.Raycast(can.transform.position, can.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.gameObject.name);

            Target target = hitInfo.transform.gameObject.GetComponent<Target>();

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