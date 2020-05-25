using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    private bool shopEnter = true;
    public GameObject shopButtonUI;

    public static bool isOn = false;

    public void ShopEnterQuit()
    {
        gameObject.SetActive(shopEnter);
        shopButtonUI.SetActive(!shopEnter);
        shopEnter = !shopEnter;
    }
}