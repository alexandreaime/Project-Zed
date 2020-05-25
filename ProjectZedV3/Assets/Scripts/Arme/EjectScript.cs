using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjectScript : ArmeShop
{

    [SerializeField] GameObject grenade;
    [SerializeField] GameObject ultimate;
    [SerializeField] GameObject heal;
    [SerializeField] int force = 800;

    public AudioSource audioGre;


    void Update()
    {
        ThrowGrenade();
        ThrowUltimate();
        ThrowHeal();
    }

    public void ThrowGrenade()
    {
        if (Input.GetButtonDown("Grenade"))
        {
            if (grenaderestante != 0)
            {
                GameObject Go = Instantiate(grenade, transform.position, Quaternion.identity);

                Go.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * force);
                audioGre.Play();
                
                grenaderestante = grenaderestante - 1;
                
                Debug.Log("il te reste " + grenaderestante + " grenades");
            }
        }
    }

    public void ThrowUltimate()
    {
        if (Input.GetButtonDown("Ultimate"))
        {
            if (ultirestant != 0)
            {
                GameObject Go = Instantiate(ultimate, transform.position, Quaternion.identity);

                Go.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * force);

                ultirestant = ultirestant - 1;
            }
        }
    }
    
    public void ThrowHeal()
    {
        if (Input.GetButtonDown("Heal"))
        {
            if (healrestant != 0)
            {
                GameObject Go = Instantiate(heal, transform.position, Quaternion.identity);

                Go.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * force);

                healrestant = healrestant - 1;
            }
        }
    }
    
    public static void FiveGre()
    {
        grenaderestante = grenaderestante + 5;
    }
    
    public static void NewUlt()
    {
        ultirestant = ultirestant + 1;
    }
    
    public static void NewHeal()
    {
        healrestant = healrestant + 1;
    }
}
