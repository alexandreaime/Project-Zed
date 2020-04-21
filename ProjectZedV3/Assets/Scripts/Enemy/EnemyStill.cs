using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStill : MonoBehaviour
{
    //Player
    private Player player;
    private Transform target;
    
    //EnemyStill
    public Transform partToRotate;
    public float rotationSpeed = 6.5f;

    //Attack
    public float range = 10f;
    public int damage = 5;

 
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    //Cherche une cible dans la zone de tir
    void UpdateTarget()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag("Player");
        GameObject nearestEnemy = null;

        float shortestDistance = Mathf.Infinity;

        foreach (GameObject enemy in ennemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            player = target.GetComponent<Player>();
        }
        else
        {
            target = null;
        }
    }


    void Update()
    {
        if (target != null)
        {
            LockOnTarget();
            InvokeRepeating("Attack", 10000f, 1f);
        }
    }

    void Attack()
    {
        player.RpcTakeDamage(damage, transform.name);
    }


    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }


    [Header("Zone de tir")]
    public Color zoneAttack;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = zoneAttack;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
