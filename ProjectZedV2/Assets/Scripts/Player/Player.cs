using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    [SyncVar]
    private bool _isDead = false;
    public bool isDead
    {
        get { return _isDead; }
        protected set { _isDead = value; }

    [SerializeField] private int maxHealth = 100;
    
    [SyncVar] private int currentHealth;

    private void Awake()
    {
        SetDefaults();
    }

    [ClientRpc]
    public void RpcTakeDamage(int _amount)
    {
        if (isDead)
        {
            return;
        }
        currentHealth -= _amount;
        Debug.Log(transform.name + "a maintenant " + currentHealth + " points de vie.");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        //DESACTIVER LES COMPO DU JOUEUR
        Debug.Log(transform.name + " est mort.");
    }

    private void SetDefaults()
    {
        currentHealth = maxHealth;
    }
}
