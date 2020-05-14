using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(WeaponManager))]
public class Audiotest : MonoBehaviour
{

    public AudioSource Reload;

    //public AudioSource Test;
    
    void Update()
    {
        if (Input.GetButtonDown("Reload"))
        {
            ReloadSound();
        }
    }

    public void ReloadSound()
    {
        Reload.Play();
    }
}
