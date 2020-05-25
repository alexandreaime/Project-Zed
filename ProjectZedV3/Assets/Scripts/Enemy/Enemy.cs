using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
//using UnityEngine.PhysicsModule;


public class Enemy : MonoBehaviour
{
    //Player
    private Transform target;
    private Player player;

    //Attack
    public float speed = 0.05f;
    public int damage = 1;
    public int health = 5;

    private Animator anim;

    private int id;

    Rigidbody m_Rigidbody;
    Vector3 m_YAxis;
    CapsuleCollider caps;

    void Start()
    {
        caps = GetComponent<CapsuleCollider>();

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject nearestPlayer = null;

        anim = GetComponent<Animator>();

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

        m_Rigidbody = GetComponent<Rigidbody>();
        //Set up vector for moving the Rigidbody in the y axis
        m_YAxis = new Vector3(0, 5, 0);
    }


    void Update()
    {
        if (anim.GetBool("Die"))
        {
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            //m_Rigidbody.angularVelocity = Vector3.zero;
            speed = 0.0f;
            damage = 0;
            Destroy(caps);
            transform.rotation = new Quaternion (0.0f, 0.0f, 0.0f, 0.0f);
        }
        if (player != null && !anim.GetBool("Die"))
        {
            if (Vector3.Distance(transform.position, target.position) > 2.5f)
            {
                anim.SetBool("Attack", false);
                Vector3 dir = target.position - transform.position;
                transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
            }
            else
            {
                //InvokeRepeating("Attack", 1f, 1f);
                Attack();
            }
        }
    }

    void Attack()
    {
        anim.SetBool("Attack", true);
        player.RpcTakeDamage(damage, transform.name);
    }

    public void DieAnim(float waitTime, int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            anim.SetBool("Die", true); //faire passer ce booléen a true déclenche l'anim de mort
            //yield return new WaitForSeconds(5.0f);
        }
    }


    public void DestroyTransform()   //fonction appelée dans playershoot oupa lol 
    {
        Destroy(gameObject);
    }
}
