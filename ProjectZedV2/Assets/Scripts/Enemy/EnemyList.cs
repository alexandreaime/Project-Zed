using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;

public class EnemyList : MonoBehaviour
{
    public static List<Enemy> enemies;

    private void Start()
    {
        enemies = new List<Enemy>();
    }

    public static void Add(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    public static void Remove(Enemy enemy)
    {
        enemies.Remove(enemy);
    }

    public static void RemoveAll()
    {
        foreach (Enemy enemy in enemies)
        {
            enemies.Remove(enemy);
        }
    }
}