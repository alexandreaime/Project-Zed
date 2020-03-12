using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllBar : MonoBehaviour
{
    public static Player player;

    public Slider sliderHealth, sliderMoney;
    public Text moneyText, healthText;

    private void Start()
    {
        sliderHealth.maxValue = player.maxHealth;
        sliderMoney.maxValue = player.maxMoney;
    }

    public void Update()
    {
        sliderHealth.value = player.currentHealth;
        healthText.text = " HEALTH : " + player.currentHealth;
        
        sliderMoney.value = player.currentMoney;
        moneyText.text = " MONEYS : " + player.currentMoney;
    }
}