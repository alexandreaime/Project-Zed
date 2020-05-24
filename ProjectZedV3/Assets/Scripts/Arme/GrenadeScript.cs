using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class GrenadeScript : MonoBehaviour
{

    public float sec = 2f;
    public bool boom = false;
    public Enemy cible;

    [SerializeField] GameObject particle;

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(sec);
        boom = true;

    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(Explosion());
    }


    private void OnTriggerStay(Collider other)
    {
        if (!boom) return;

        if (other.CompareTag("Enemy"))
        {
            Destroy(other);
        }

        Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
