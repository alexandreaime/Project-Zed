using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjectScript : MonoBehaviour
{

    [SerializeField] GameObject grenade;
    [SerializeField] int force = 800;


    void Update()
    {

        if (Input.GetKey(KeyCode.G))
        {
            GameObject Go = Instantiate(grenade, transform.position, Quaternion.identity);
            Go.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * force);
        }
    }
}
