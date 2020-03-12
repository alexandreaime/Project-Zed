﻿using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour
{

    public PlayerWeapon weapon;
    
    [SerializeField] private Camera cam;

    [SerializeField] private LayerMask mask;
    void Start()
    {
        if (cam == null)
        {
            Debug.LogError("Pas de caméra référencée.");
            this.enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            Debug.Log("Tir effectué");
        } 
    }

    [Client] 
    private void Shoot()
    {
        //permet de récupérer des infos sur l'objet touché (type, distance ...)
        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask)) 
        {
            if (_hit.collider.tag == "Player")
            {
                CmdPlayerShot(_hit.collider.name, weapon.damage);
            }
            else
            {
                if (_hit.collider.tag == "Enemy")
                {
                    Enemy enemy = _hit.transform.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        enemy.DestroyTransform();
                    }
                }
            }
        }
    }

    [Command]
    private void CmdPlayerShot(string _playerID, int _damage)
    {
        Debug.Log(_playerID + " a été touché.");

        Player _player = GameManager.GetPlayer(_playerID);
        _player.RpcTakeDamage(_damage);
    }
}
