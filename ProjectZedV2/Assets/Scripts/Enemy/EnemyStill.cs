using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStill : MonoBehaviour
{
    [Header("Transform")]
    private Transform target;
    public Transform partToRotate;

    [Header("Setup")]
    public float range = 10f;
    private float turnSpeed = 6.5f;
    public string playerTag = "Player";

 
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    //Cherche une cible dans la zone de tir
    void UpdateTarget()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag(playerTag);
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
            //Debug.Log("Cible en vue");
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
            Attack();
        }
    }


    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }


    void Attack()
    {
        //Attack
    }


    [Header("Zone de tir")]
    public Color zoneAttack;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = zoneAttack;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
