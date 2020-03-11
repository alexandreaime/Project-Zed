using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Transform")]
    public Transform target;

    [Header("Calcul")]
    public float speed = 7f;
    public float damage = 10;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void Update()
    {
        if(Vector3.Distance(transform.position, target.position) <= 2.5f)
        {
            Attack();
            DestroyTransform();
        }
        else
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        }

    }

    
    void Attack()
    {
        float health = PlayerStats.health;
        
        if (PlayerStats.health > 0)
        {
            health -= damage * Time.deltaTime;

            if (health < 0)
            {
                health = 0;
            }

            PlayerStats.health = health;
        }
        
        if (health == 0)
        {
            Debug.Log("Dead !");
        }
    }


    void DestroyTransform()
    {
        Destroy(gameObject);
    }
}
