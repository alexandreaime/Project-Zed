using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ins : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        //player = GetComponentInChildren<Player>();
        if (player != null)
        {
            player.Ins();
            Debug.Log("Player apparu");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
