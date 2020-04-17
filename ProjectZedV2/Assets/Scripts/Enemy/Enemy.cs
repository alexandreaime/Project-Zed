using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Player
    private Transform target;
    public Player player;

    //Attack
    public float speed = 0.005f;
    public int damage = 1;
    //public int health = 50;

    private int id;
    
    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject nearestPlayer = null;
        
        float shortestDistance = Mathf.Infinity;
        
        foreach (GameObject player in players)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestPlayer = player;
            }
            
            target = nearestPlayer.transform;
            this.player = target.GetComponent<Player>();
        }
    }


    void Update()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, target.position) > 2.5f)
            {
                Vector3 dir = target.position - transform.position;
                transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
            }
            else
            {
                InvokeRepeating("Attack", 0f, 2f);
            }
        }
    }

    void Attack()
    {
        player.RpcTakeDamage(damage);
        DestroyTransform();
    }


    public void DestroyTransform()
    {
        Destroy(gameObject);
    }
}
