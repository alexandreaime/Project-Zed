using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllBar : MonoBehaviour
{
    private Player player;

    public Slider sliderMoney;

    public void SetMax(Player player)
    {
        this.player = player;
        sliderMoney.maxValue = player.maxMoney;
    }

    public void SetMoney(int value)
    {
        sliderMoney.value = player.currentMoney;
    }
}