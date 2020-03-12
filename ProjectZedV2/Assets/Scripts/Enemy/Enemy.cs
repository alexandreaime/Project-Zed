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
    public static Player player;

    //Attack
    public float speed;
    public int damage = 1;
    //public int health = 50;

    private int id;


    void Update()
    {
        if (player != null)
        {
            target = player.transform;
            if (Vector3.Distance(transform.position, target.position) > 2.5f)
            {
                Vector3 dir = target.position - transform.position;
                transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
            }
            else
            {
                InvokeRepeating("Attack", 0f, 1f);
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
        EnemyList.Remove(GetComponent<Enemy>());
    }

    public void Spawn(Vector3 position, Quaternion rotation)
    {
        Instantiate(transform, position, rotation);
        EnemyList.Add(GetComponent<Enemy>());
    }
}
