using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Networking;
using Debug = UnityEngine.Debug;

[RequireComponent(typeof(Player))]
public class PlayerSetup : NetworkBehaviour
{
    [SerializeField] private Behaviour[] componentsToDisable;

    [SerializeField] private string remoteLayerName = "RemotePlayer";

    [SerializeField] private GameObject playerUIPrefab;

    private GameObject playerUIInstance;
    
    Camera sceneCamera;

    private void Start()
    {
        if (!isLocalPlayer)
        {
            DisableComponents();
            AssignRemoteLayer();
        }
        else
        {
            sceneCamera = Camera.main;
            if (sceneCamera != null)
            {
                sceneCamera.gameObject.SetActive(false);
            }
        }
        Player _player = GetComponent<Player>();
        GetComponent<Player>().Setup();

        // Création du UI 
        playerUIInstance = Instantiate(playerUIPrefab);
        playerUIInstance.name = playerUIPrefab.name; // remplace le "(clone)" dans l'instance du jeu
        
        playerUIInstance.GetComponentInChildren<AllBar>().SetMax(_player);
        playerUIInstance.GetComponentInChildren<ArmeShop>().SetPlayer(_player);
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player _player = GetComponent<Player>();
        GameManager.RegisterPlayer(_netID, _player);
    }

    private void AssignRemoteLayer()
    {
        gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
    }
    
    private void DisableComponents()
    {
        // boucle pour désactiver les components des autres joueurs sur notre instance
        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].enabled = false;
        }
    }

    private void OnDisable()
    {
        Destroy(playerUIInstance);
        
        if (sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }

        GameManager.UnRegisterPlayer(transform.name);
    }
}
