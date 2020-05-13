using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

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
    Vector3 m_ZAxis;

    void Start()
    {
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
    }


    void Update()
    {
        if (player != null)
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

    private IEnumerator DieAnim()
    {
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        anim.SetBool("Die", true);
        yield return new WaitForSeconds(100.0f);
    }


    public void DestroyTransform()
    {
        //m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        StartCoroutine(DieAnim());
        //anim.SetBool("Die", true);
        //yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    

}
