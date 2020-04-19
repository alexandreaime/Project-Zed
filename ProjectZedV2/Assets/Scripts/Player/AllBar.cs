using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllBar : MonoBehaviour
{
    private Player player;

    public Slider sliderHealth, sliderMoney;
    public Text moneyText, healthText, scoreText;

    public void SetMax(Player player)
    {
        this.player = player;
        sliderHealth.maxValue = player.maxHealth;
        sliderMoney.maxValue = player.maxMoney;
    }

    public void Update()
    {
        sliderHealth.value = player.currentHealth;
        healthText.text = " HEALTH : " + player.currentHealth;
        
        sliderMoney.value = player.currentMoney;
        moneyText.text = " MONEYS : " + player.currentMoney;

        scoreText.text = "SCORE : " + player.score;
    }
}