using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ScriptHeal : MonoBehaviour
{
    
    public GameObject explosionEffet;
    public float delay = 2f;

    public float explosionForce = 10f;
    public float radius = 60f;

    private Rigidbody rb;
    private Collider[] Enemies;
    public Enemy enemy;
    private Player player;

    void Start()
    {
        Invoke("Heal", delay);
        rb = GetComponent<Rigidbody>();
    }

    private void Heal()
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
            if (people.tag == "Player")
            {
                this.player = people.GetComponent<Player>();
                player.RpcTakeHeal(50, transform.name);
            }
        }
        Destroy(gameObject);
    }
}