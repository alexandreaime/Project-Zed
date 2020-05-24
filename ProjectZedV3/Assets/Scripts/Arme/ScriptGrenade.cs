using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptGrenade : MonoBehaviour
{
    
    public GameObject explosionEffet;
    public float delay = 3f;

    public float explosionForce = 10f;
    public float radius = 20f;
    
    void Start()
    {
        Invoke("Explode", delay);
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
        Destroy(gameObject);
    }
}
