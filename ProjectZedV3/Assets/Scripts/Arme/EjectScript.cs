using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjectScript : MonoBehaviour
{

    [SerializeField] GameObject grenade;
    [SerializeField] int force = 800;

    public AudioSource audioGre;

    private bool throwing;    


    void Update()
    {
        ThrowGrenade();
    }

    public void ThrowGrenade()
    {
        if (Input.GetKey(KeyCode.G) /*&& !throwing*/)
        {
            GameObject Go = Instantiate(grenade, transform.position, Quaternion.identity);
            Go.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * force);
            audioGre.Play();
            
            throwing = true;
        }
    }
}
