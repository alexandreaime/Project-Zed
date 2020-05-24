using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class ScriptGrenade : MonoBehaviour
{
    
    public GameObject explosionEffet;
    public float delay = 3f;

    public float explosionForce = 10f;
    public float radius = 20f;

    private Rigidbody rb;
    private Collider[] Enemies;
    public Enemy enemy;
    
    void Start()
    {
        Invoke("Explode", delay);
        rb = GetComponent<Rigidbody>();
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider near in colliders)
        {
            Rigidbody rig = near.GetComponent<Rigidbody>();
            
            if (rig != null)
            rig.AddExplosionForce(explosionForce, transform.position, radius, 1f, ForceMode.Impulse);
        }

        Instantiate(explosionEffet, transform.position, transform.rotation);
        Enemies = Physics.OverlapSphere(transform.position, 15);
        foreach (Collider people in Enemies)
        {
            if (people.tag == "Enemy")
            {
                Destroy(people.gameObject);
            }
        }
        Destroy(gameObject);
    }
}
