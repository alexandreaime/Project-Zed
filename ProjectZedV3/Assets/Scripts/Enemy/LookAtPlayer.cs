using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    //Player
    public Transform target;
    private Player player;

    float speed = 50.0f;

    // Update is called once per frame
    void Update()
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
        transform.LookAt(target.position);
    }
}
