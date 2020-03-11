using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static float health;
    public float startHealth = 100;

    public static int money;
    public int startMoney = 500;
    
    public static List<(int,Transform)> TotalArme;

    void Start()
    {
        money = startMoney;
        health = startHealth;
        TotalArme = new List<(int,Transform)>();
    }
}
