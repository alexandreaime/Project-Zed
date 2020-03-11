using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    [SerializeField] private int maxHealth = 100;
    
    [SyncVar] private int currentHealth;

    private void Awake()
    {
        SetDefaults();
    }

    public void TakeDamage(int _amount)
    {
        currentHealth -= _amount;
        Debug.Log(transform.name + "a maintenant " + currentHealth + " points de vie.");
    }

    private void SetDefaults()
    {
        currentHealth = maxHealth;
    }
}
