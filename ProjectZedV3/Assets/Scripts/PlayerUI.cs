﻿using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {
    
    [SerializeField]
    private RectTransform healthbarFill;

    [SerializeField]
    private Text ammoText;

    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private GameObject scoreboard;
    
    [SerializeField]
    private GameObject shopMenu;

    private Player player;
    private PlayerController controller;
    private WeaponManager weaponManager;

    public void SetPlayer(Player _player)
    {
        player = _player;
        controller = _player.GetComponent<PlayerController>();
        weaponManager = _player.GetComponent<WeaponManager>();
    }

    private void Start()
    {
        PauseMenu.isOn = false;
    }

    private void Update()
    {
        SetHealthAmount(player.GetHealthPct());
        SetAmmoAmount(weaponManager.GetCurrentWeapon().bullets);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            scoreboard.SetActive(true);
        }else if (Input.GetKeyUp(KeyCode.Tab))
        {
            scoreboard.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            shopMenu.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.B))
        {
            shopMenu.SetActive(false);
            ShopMenu.isOn = shopMenu.activeSelf;
        }
    }

    public void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        PauseMenu.isOn = pauseMenu.activeSelf;
    }

    void SetHealthAmount(float _amount)
    {
        healthbarFill.localScale = new Vector3(1f, _amount, 1f);
    }

    void SetAmmoAmount(int _amount)
    {
        ammoText.text = _amount.ToString();
    }
}
