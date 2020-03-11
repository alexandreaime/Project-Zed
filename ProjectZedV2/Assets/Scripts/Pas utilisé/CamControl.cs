using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CamControl : NetworkBehaviour
{
    
    void Start()
    {
        if (isLocalPlayer)
        {
            Camera.main.transform.position =
                this.transform.position - this.transform.forward * 10 + this.transform.up * 3;
            Camera.main.transform.LookAt(this.transform.position);
            Camera.main.transform.parent = this.transform;
        }
    }

    
}
